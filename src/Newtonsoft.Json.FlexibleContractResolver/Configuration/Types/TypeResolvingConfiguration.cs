using System;
using Newtonsoft.Json.FlexibleContractResolver.Configuration.Types.Members;
using Newtonsoft.Json.FlexibleContractResolver.Configuration.Types.Members.Generic;

namespace Newtonsoft.Json.FlexibleContractResolver.Configuration.Types
{
    /// <summary>
    /// Configuration of how types will be resolved during [de]serialization
    /// </summary>
    public class TypeResolvingConfiguration
    {
        /// <summary>
        /// Gets or sets configurated type
        /// </summary>
        public Type Type { get; set; }

        /// <summary>
        /// Gets or sets properties resolving configuration
        /// </summary>
        public IMemberTypeResolvingConfigration<PropertyResolvingConfiguration> Properties { get; set; } = new PropertiesResolvingConfiguration();

        /// <summary>
        /// Gets or sets fields resolving configuration
        /// </summary>
        public IMemberTypeResolvingConfigration<FieldResolvingConfiguration> Fields { get; set; } = new FieldsResolvingConfiguration();
        
        public TypeResolvingConfiguration(Type type)
        {
            Type = type;
        }
    }
}