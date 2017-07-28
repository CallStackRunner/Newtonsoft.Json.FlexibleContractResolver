using System.Reflection;
using Newtonsoft.Json.FlexibleContractResolver.Configuration.Types.Members.Handlers.Generic;
using Newtonsoft.Json.Serialization;

namespace Newtonsoft.Json.FlexibleContractResolver.Configuration.Types.Members.Handlers
{
    public class FieldConfigurationHandler : MemberConfigurationHandlerBase<FieldResolvingConfiguration>
    {
        public override MemberTypeResolvingConfigrationFactoryMethod<FieldResolvingConfiguration> MemberTypeResolvingConfigrationFactoryMethod
            => config => config.Fields;

        public override void HandleMemberConfiguration(MemberInfo member, JsonProperty property, FieldResolvingConfiguration configuration)
        {
        }
    }
}