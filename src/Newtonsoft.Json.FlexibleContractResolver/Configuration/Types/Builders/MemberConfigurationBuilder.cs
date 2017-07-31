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

        public MemberJsonPropertyNameConfigurationBuilder BoundToJsonProperty 
            => new MemberJsonPropertyNameConfigurationBuilder(Configuration.JsonPropertyName);

        public MemberConfigurationBuilderShouldBe ShouldBe => new MemberConfigurationBuilderShouldBe(Configuration);
    }
}