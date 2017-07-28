using Newtonsoft.Json.FlexibleContractResolver.Configuration.Types;
using Newtonsoft.Json.FlexibleContractResolver.Configuration.Types.Builders;

namespace Newtonsoft.Json.FlexibleContractResolver.Configuration
{
    /// <summary>
    /// Configuration for cref="FlexibleContractResolver"/>
    /// </summary>
    public class ContractConfiguration
    {
        /// <summary>
        /// Resolving configuration for particular types
        /// </summary>
        public TypesResolvingConfiguration TypesResolving { get; set; } = new TypesResolvingConfiguration();

        public static TypesResolvingConfigurationBuilder Of => new TypesResolvingConfigurationBuilder(new ContractConfiguration());
    }
}