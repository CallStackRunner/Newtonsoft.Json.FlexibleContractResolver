using System.Collections.Generic;

namespace Newtonsoft.Json.FlexibleContractResolver.Configuration.Types.Members.Generic
{
    /// <summary>
    /// Base type for member type resolving configuration
    /// </summary>
    /// <typeparam name="TMemberConfiguration">member configuration type</typeparam>
    public abstract class MemberTypeResolvingConfigrationBase<TMemberConfiguration> : IMemberTypeResolvingConfigration<TMemberConfiguration>
        where TMemberConfiguration : IMemberConfiguration, new()
    {
        private readonly IDictionary<string, TMemberConfiguration> _memberTypeNamesConfigurationsMapping
            = new Dictionary<string, TMemberConfiguration>();

        /// <inheritdoc />
        public bool HasMemberConfiguration(string memberName)
        {
            return _memberTypeNamesConfigurationsMapping.ContainsKey(memberName);
        }

        /// <inheritdoc />
        public TMemberConfiguration GetMemberConfiguration(string memberName)
        {
            _memberTypeNamesConfigurationsMapping.TryGetValue(memberName, out TMemberConfiguration configuration);
            return configuration;
        }

        /// <inheritdoc />
        public TMemberConfiguration CreateMemberConfiguration(string memberName)
        {
            if (this.HasMemberConfiguration(memberName))
            {
                return GetMemberConfiguration(memberName);
            }

            var memberTypeResolvingConfiguration = new TMemberConfiguration() { MemberName = memberName };
            _memberTypeNamesConfigurationsMapping[memberName] = memberTypeResolvingConfiguration;
            return memberTypeResolvingConfiguration;
        }
    }
}