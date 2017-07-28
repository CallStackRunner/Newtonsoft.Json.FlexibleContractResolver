using System.Reflection;
using Newtonsoft.Json.FlexibleContractResolver.Configuration.Types.Members.Handlers.Generic;
using Newtonsoft.Json.Serialization;

namespace Newtonsoft.Json.FlexibleContractResolver.Configuration.Types.Members.Handlers
{
    public class PropertyConfigurationHandler : MemberConfigurationHandlerBase<PropertyResolvingConfiguration>
    {
        public override MemberTypeResolvingConfigrationFactoryMethod<PropertyResolvingConfiguration> MemberTypeResolvingConfigrationFactoryMethod
            => (config) => config.Properties;

        public override void HandleMemberConfiguration(MemberInfo member, JsonProperty property, PropertyResolvingConfiguration configuration)
        {
        }
    }
}