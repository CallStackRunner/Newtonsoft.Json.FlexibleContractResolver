using System;

namespace Newtonsoft.Json.FlexibleContractResolver.Configuration.Types.Builders
{
    public class TypesResolvingConfigurationBuilder
    {
        private ContractConfiguration ContractConfiguration { get; }

        public TypesResolvingConfigurationBuilder(ContractConfiguration contractConfiguration)
        {
            ContractConfiguration = contractConfiguration;
        }

        public TypesResolvingConfigurationBuilder Type<T>(Action<TypeResolvingConfigurationBuilder<T>> typeConfig)
        {
            var type = typeof(T);
            var typeResolvingConfiguration = ContractConfiguration.TypesResolving.HasConfigurationForEntity(type)
                ? ContractConfiguration.TypesResolving.GetConfigurationForEntity(type)
                : ContractConfiguration.TypesResolving.CreateConfigurationForEntity(type);
            typeConfig(new TypeResolvingConfigurationBuilder<T>(typeResolvingConfiguration));
            return this;
        }

        public static implicit operator ContractConfiguration(TypesResolvingConfigurationBuilder builder)
        {
            return builder.ContractConfiguration;
        }
    }
}