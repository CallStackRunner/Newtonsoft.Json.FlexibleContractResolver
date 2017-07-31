using Newtonsoft.Json.FlexibleContractResolver.Configuration.Types.Members.Generic;

namespace Newtonsoft.Json.FlexibleContractResolver.Configuration.Types.Builders
{
    public class MemberConfigurationBuilderShouldBe
    {
        private readonly IMemberConfiguration _memberConfiguration;

        public MemberIgnoringConfigurationBuilder Ignored()
        {
            _memberConfiguration.Ignoring.ShouldBeIgnored = true;
            return new MemberIgnoringConfigurationBuilder(_memberConfiguration.Ignoring);
        }

        public MemberConfigurationBuilderShouldBe(IMemberConfiguration memberConfiguration)
        {
            _memberConfiguration = memberConfiguration;
        }
    }
}