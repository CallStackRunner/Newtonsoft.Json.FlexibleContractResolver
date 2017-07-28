using Newtonsoft.Json.FlexibleContractResolver.Configuration.Types.Members;
using Newtonsoft.Json.FlexibleContractResolver.Configuration.Types.Members.Generic;

namespace Newtonsoft.Json.FlexibleContractResolver.Configuration.Types.Builders
{
    public class MemberConfigurationBuilder
    {
        protected IMemberConfiguration Configuration { get; }

        public MemberConfigurationBuilder(IMemberConfiguration configuration)
        {
            Configuration = configuration;
        }

        public MemberConfigurationBuilder HasJsonBinding(string jsonBinding)
        {
            Configuration.JsonBinding = jsonBinding;
            return this;
        }

        public MemberConfigurationBuilder ShouldBeIgnored()
        {
            Configuration.Ignored = true;
            return this;
        }
    }
}