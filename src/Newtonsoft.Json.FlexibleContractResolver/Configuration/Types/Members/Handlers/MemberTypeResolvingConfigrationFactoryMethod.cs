using Newtonsoft.Json.FlexibleContractResolver.Configuration.Types.Members.Generic;

namespace Newtonsoft.Json.FlexibleContractResolver.Configuration.Types.Members.Handlers
{
    public delegate IMemberTypeResolvingConfigration<TMemberConfigration>
        MemberTypeResolvingConfigrationFactoryMethod<out TMemberConfigration>(TypeResolvingConfiguration configuration)
        where TMemberConfigration : IMemberConfiguration, new();
}