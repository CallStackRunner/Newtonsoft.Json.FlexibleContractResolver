using System.Reflection;
using Newtonsoft.Json.FlexibleContractResolver.Configuration.Types.Members.Generic;
using Newtonsoft.Json.FlexibleContractResolver.Infrastructure.Configuration.Members;
using Newtonsoft.Json.Serialization;

namespace Newtonsoft.Json.FlexibleContractResolver.Configuration.Types.Members.Handlers.Generic
{
    /// <summary>
    /// A base class for member types configuration handlers
    /// </summary>
    /// <typeparam name="TMemberConfiguration"></typeparam>
    public abstract class MemberConfigurationHandlerBase<TMemberConfiguration> : IMemberConfigurationHandler
        where TMemberConfiguration : class, IMemberConfiguration, new()
    {
        private readonly MemberConfigurationAccessController _memberConfigurationAccessController = new MemberConfigurationAccessController();

        /// <inheritdoc />
        void IMemberConfigurationHandler.HandleMemberConfiguration(MemberInfo member, JsonProperty property, TypeResolvingConfiguration configuration)
        {
            if (_memberConfigurationAccessController.HasMemberConfigurationType(member.Name, 
                member.MemberType, 
                configuration))
            {
                var memberConfiguration = _memberConfigurationAccessController.GetMemberConfigurationType(member.Name, 
                    member.MemberType,
                    configuration);
                property.PropertyName = memberConfiguration.JsonPropertyName.Name;
                if (memberConfiguration.Ignoring.ShouldBeIgnored)
                {
                    // PropertyName cannot be null
                    property.Ignored = true;
                    property.PropertyName = string.Empty;
                }

                HandleMemberConfiguration(member, property, memberConfiguration as TMemberConfiguration);
            }
        }

        //private void HandleIgnoringConfiguration(MemberIgnoringConfiguration ignoringConfiguration, JsonProperty property)
        //{
        //    if (ignoringConfiguration.ShouldBeIgnored)
        //    {
        //        if (ignoringConfiguration.WhenShouldBeIgnored != null)
        //        {
        //            ignoringConfiguration.WhenShouldBeIgnored.DynamicInvoke(property.)
        //        }
        //    }
        //}

        /// <summary>
        /// Handling particular member type configuration
        /// </summary>
        public abstract void HandleMemberConfiguration(MemberInfo member, 
            JsonProperty property,
            TMemberConfiguration configuration);
    }
}