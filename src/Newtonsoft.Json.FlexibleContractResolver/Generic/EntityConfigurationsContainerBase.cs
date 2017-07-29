using System.Collections.Generic;

namespace Newtonsoft.Json.FlexibleContractResolver.Generic
{
    /// <inheritdoc />
    public abstract class EntityConfigurationsContainerBase<TEntity, TConfiguration> : IEntityConfigurationsContainer<TEntity, TConfiguration>
    {
        private readonly IDictionary<TEntity, TConfiguration> _entitiesConfigs = new Dictionary<TEntity, TConfiguration>();

        /// <inheritdoc />
        public TConfiguration CreateConfigurationForEntity(TEntity entity)
        {
            if (HasConfigurationForEntity(entity))
            {
                return GetConfigurationForEntity(entity);
            }

            var configuration = CreateConfigurationFromEntity(entity);
            _entitiesConfigs[entity] = configuration;
            return configuration;
        }

        /// <inheritdoc />
        public TConfiguration GetConfigurationForEntity(TEntity entity)
        {
            _entitiesConfigs.TryGetValue(entity, out TConfiguration result);
            return result;
        }

        /// <inheritdoc />
        public bool HasConfigurationForEntity(TEntity entity)
        {
            return _entitiesConfigs.ContainsKey(entity);
        }

        /// <summary>
        /// Provide entity type-specific logic of instantiating configuration based on entity
        /// </summary>
        /// <param name="entity">entity</param>
        /// <returns>an instance of <see cref="TConfiguration"/></returns>
        protected abstract TConfiguration CreateConfigurationFromEntity(TEntity entity);
    }
}