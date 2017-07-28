using System.Reflection;
using Newtonsoft.Json.FlexibleContractResolver.Configuration.Types.Members.Generic;
using Newtonsoft.Json.Serialization;

namespace Newtonsoft.Json.FlexibleContractResolver.Configuration.Types.Members.Handlers.Generic
{
    /// <summary>
    /// A base class for member types configuration handlers
    /// </summary>
    /// <typeparam name="TMemberConfiguration"></typeparam>
    public abstract class MemberConfigurationHandlerBase<TMemberConfiguration> : IMemberConfigurationHandler<TMemberConfiguration> 
        where TMemberConfiguration : IMemberConfiguration, new()
    {
        /// <inheritdoc />
        public abstract MemberTypeResolvingConfigrationFactoryMethod<TMemberConfiguration> MemberTypeResolvingConfigrationFactoryMethod { get; }

        /// <inheritdoc />
        void IMemberConfigurationHandler.HandleMemberConfiguration(MemberInfo member, JsonProperty property, TypeResolvingConfiguration configuration)
        {
            var config = MemberTypeResolvingConfigrationFactoryMethod.Invoke(configuration);
            if (config.HasMemberConfiguration(member.Name))
            {
                var memberConfiguration = config.GetMemberConfiguration(member.Name);
                property.PropertyName = memberConfiguration.JsonBinding;
                if (memberConfiguration.Ignored)
                {
                    // PropertyName cannot be null
                    property.Ignored = true;
                    property.PropertyName = string.Empty;
                }

                HandleMemberConfiguration(member, property, memberConfiguration);
            }
        }

        /// <summary>
        /// Handling particular member type configuration
        /// </summary>
        public abstract void HandleMemberConfiguration(MemberInfo member, 
            JsonProperty property,
            TMemberConfiguration configuration);
    }
}