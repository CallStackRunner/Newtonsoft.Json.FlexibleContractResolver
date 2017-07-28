using System.Reflection;
using Newtonsoft.Json.FlexibleContractResolver.Configuration.Types.Members.Generic;
using Newtonsoft.Json.Serialization;

namespace Newtonsoft.Json.FlexibleContractResolver.Configuration.Types.Members.Handlers.Generic
{
    /// <inheritdoc />
    public interface IMemberConfigurationHandler<out TMemberConfigration> : IMemberConfigurationHandler 
        where TMemberConfigration : IMemberConfiguration, new()
    {
        /// <summary>
        /// A factory method for retrieving member type resolving configuration from <see cref="TypeResolvingConfiguration"/>
        /// </summary>
        MemberTypeResolvingConfigrationFactoryMethod<TMemberConfigration> MemberTypeResolvingConfigrationFactoryMethod { get; }
    }

    /// <summary>
    /// An interface for particular members configuration handlers
    /// </summary>
    public interface IMemberConfigurationHandler
    {
        /// <summary>
        /// Handling particular member type configuration
        /// </summary>
        void HandleMemberConfiguration(MemberInfo member, JsonProperty property, TypeResolvingConfiguration configuration);
    }
}