using System.Reflection;
using Newtonsoft.Json.FlexibleContractResolver.Configuration;
using Newtonsoft.Json.FlexibleContractResolver.Configuration.Infrastructure;
using Newtonsoft.Json.Serialization;

namespace Newtonsoft.Json.FlexibleContractResolver
{
    /// <summary>
    /// A flexibly configurable implementation of IContractResolver
    /// </summary>
    public class FlexibleContractResolver : DefaultContractResolver
    {
        private MemberTypeSupportFacade MemberTypeSupportFacade { get; }
        public ContractConfiguration Configuration { get; set; }

        public FlexibleContractResolver(ContractConfiguration configuration)
        {
            Configuration = configuration;
            MemberTypeSupportFacade = new MemberTypeSupportFacade();
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            if (!MemberTypeSupportFacade.MemberTypeSupportConsultant.IsMemberTypeSupported(member.MemberType))
            {
                // nothing to do here
                return property;
            }

            var typeResolvingConfiguration = Configuration.TypesResolving.GetTypeResolvingConfiguration(member.DeclaringType);
            if (typeResolvingConfiguration != null)
            {
                MemberTypeSupportFacade.MemberTypeConfigurationHandlingRouter
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
