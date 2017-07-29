using System;
using Newtonsoft.Json.FlexibleContractResolver.Generic;

namespace Newtonsoft.Json.FlexibleContractResolver.Configuration.Types
{
    /// <summary>
    /// Type [de]serialization configuration 
    /// </summary>
    public class TypesResolvingConfiguration : EntityConfigurationsContainerBase<Type, TypeResolvingConfiguration>
    {
        protected override TypeResolvingConfiguration CreateConfigurationFromEntity(Type entity)
        {
            return new TypeResolvingConfiguration(entity);
        }
    }
}