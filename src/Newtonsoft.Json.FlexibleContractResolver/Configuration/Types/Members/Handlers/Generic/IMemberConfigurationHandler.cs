using System.Reflection;
using Newtonsoft.Json.Serialization;

namespace Newtonsoft.Json.FlexibleContractResolver.Configuration.Types.Members.Handlers.Generic
{
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