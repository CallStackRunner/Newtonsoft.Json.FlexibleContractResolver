using Newtonsoft.Json.FlexibleContractResolver.Generic;

namespace Newtonsoft.Json.FlexibleContractResolver.Configuration.Types.Members.Generic
{
    /// <summary>
    /// Base type for member type resolving configuration
    /// </summary>
    /// <typeparam name="TMemberConfiguration">member configuration type</typeparam>
    public abstract class MemberTypeResolvingConfigrationBase<TMemberConfiguration> : EntityConfigurationsContainerBase<string, TMemberConfiguration>,
        IMemberTypeResolvingConfigration<TMemberConfiguration>
        where TMemberConfiguration : IMemberConfiguration, new()
    {
        /// <inheritdoc />
        public bool HasMemberConfiguration(string memberName)
        {
            return base.HasConfigurationForEntity(memberName);
        }

        /// <inheritdoc />
        public TMemberConfiguration GetMemberConfiguration(string memberName)
        {
            return base.GetConfigurationForEntity(memberName);
        }

        /// <inheritdoc />
        public TMemberConfiguration CreateMemberConfiguration(string memberName)
        {
            return base.CreateConfigurationForEntity(memberName);
        }

        protected override TMemberConfiguration CreateConfigurationFromEntity(string entity)
        {
            return new TMemberConfiguration { MemberName = entity };
        }
    }
}