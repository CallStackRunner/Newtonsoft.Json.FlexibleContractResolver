using System.Reflection;
using Newtonsoft.Json.FlexibleContractResolver.Configuration;
using Newtonsoft.Json.FlexibleContractResolver.Infrastructure.Configuration.Members;
using Newtonsoft.Json.Serialization;

namespace Newtonsoft.Json.FlexibleContractResolver
{
    /// <summary>
    /// A flexibly configurable implementation of IContractResolver
    /// </summary>
    public class FlexibleContractResolver : DefaultContractResolver
    {
        private readonly MemberTypeSupportConsultant _memberTypeSupportConsultant = new MemberTypeSupportConsultant();
        private readonly MemberTypeConfigurationHandlingRouter _memberTypeConfigurationHandlingRouter = new MemberTypeConfigurationHandlingRouter();

        public ContractConfiguration Configuration { get; set; }

        public FlexibleContractResolver(ContractConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            if (!_memberTypeSupportConsultant.IsMemberTypeSupported(member.MemberType))
            {
                // nothing to do here
                return property;
            }

            var typeResolvingConfiguration = Configuration.TypesResolving.GetConfigurationForEntity(member.DeclaringType);
            if (typeResolvingConfiguration != null)
            {
                _memberTypeConfigurationHandlingRouter
                    .GetMemberConfigurationHandlerByMemberType(member.MemberType)
                    .HandleMemberConfiguration(member, property, typeResolvingConfiguration);
            }

            return property;
        }

        public static FlexibleContractResolver WithConfiguration(ContractConfiguration configuration)
        {
            return new FlexibleContractResolver(configuration);
        }
    }
}
