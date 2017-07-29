namespace Newtonsoft.Json.FlexibleContractResolver.Configuration.Generic
{
    /// <summary>
    /// A container for entity configurations
    /// </summary>
    /// <typeparam name="TEntity">entity type</typeparam>
    /// <typeparam name="TConfiguration">entity configuration type</typeparam>
    public interface IEntityConfigurationsContainer<in TEntity, out TConfiguration>
    {
        /// <summary>
        /// Determines if there is configuration for particular entity
        /// </summary>
        /// <param name="entity">entity</param>
        bool HasConfigurationForEntity(TEntity entity);

        /// <summary>
        /// Provides configuration for particular entity
        /// </summary>
        /// <param name="entity">entity</param>
        /// <returns>an instance of <see cref="TConfiguration"/> or null if there is no configuration for specified entity</returns>
        TConfiguration GetConfigurationForEntity(TEntity entity);

        /// <summary>
        /// Creates configuration for particular entity if not exists
        /// </summary>
        /// <param name="entity">entity</param>
        /// <returns>newly created configuration or existing one</returns>
        TConfiguration CreateConfigurationForEntity(TEntity entity);
    }
}
