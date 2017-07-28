using System;
using System.Collections.Generic;

namespace Newtonsoft.Json.FlexibleContractResolver.Configuration.Types
{
    /// <summary>
    /// Configuration of how types will be resolved during [de]serialization
    /// </summary>
    public class TypesResolvingConfiguration
    {
        private readonly IDictionary<Type, TypeResolvingConfiguration> _typesResolvingConfigs = new Dictionary<Type, TypeResolvingConfiguration>();

        /// <summary>
        /// Determines if there is configuration for particular type
        /// </summary>
        /// <param name="type">type</param>
        public bool HasTypeResolvingConfiguration(Type type)
        {
            return _typesResolvingConfigs.ContainsKey(type);
        }

        /// <summary>
        /// Provides resolving configuration for particular type
        /// </summary>
        /// <param name="type">type</param>
        /// <returns>an instance of <see cref="TypeResolvingConfiguration"/> or null if there is no configuration for specified type</returns>
        public TypeResolvingConfiguration GetTypeResolvingConfiguration(Type type)
        {
            _typesResolvingConfigs.TryGetValue(type, out TypeResolvingConfiguration configuration);
            return configuration;
        }

        /// <summary>
        /// Creates resolving configuration for particular type if it's not exists
        /// </summary>
        /// <param name="type">type</param>
        /// <returns>newly created configuration or existing one</returns>
        public TypeResolvingConfiguration CreateTypeResolvingConfiguration(Type type)
        {
            if (_typesResolvingConfigs.ContainsKey(type))
            {
                return GetTypeResolvingConfiguration(type);
            }

            var configuration = new TypeResolvingConfiguration(type);
            _typesResolvingConfigs[type] = configuration;
            return configuration;
        }
    }
}