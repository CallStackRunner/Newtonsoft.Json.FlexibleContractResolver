using System;
using Newtonsoft.Json.FlexibleContractResolver.Configuration.Types.Members.Generic;

namespace Newtonsoft.Json.FlexibleContractResolver.Configuration.Types.Builders
{
    public class MemberIgnoringConfigurationBuilder
    {
        private readonly MemberIgnoringConfiguration _configuration;

        public MemberIgnoringConfigurationBuilder(MemberIgnoringConfiguration configuration)
        {
            _configuration = configuration;
        }

        public MemberIgnoringConfigurationBuilder When<TDeclaringType>(Func<TDeclaringType, bool> condition)
        {
            _configuration.WhenShouldBeIgnored = condition;
            return this;
        }
    }
}