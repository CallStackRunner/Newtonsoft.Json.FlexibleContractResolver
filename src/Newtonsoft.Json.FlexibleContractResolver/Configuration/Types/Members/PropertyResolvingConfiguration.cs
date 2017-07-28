using Newtonsoft.Json.FlexibleContractResolver.Configuration.Types.Members.Generic;

namespace Newtonsoft.Json.FlexibleContractResolver.Configuration.Types.Members
{
    /// <summary>
    /// Particular property resolving configuration
    /// </summary>
    public class PropertyResolvingConfiguration : IMemberConfiguration
    {
        public string MemberName { get; set; }
        public string JsonBinding { get; set; }
        public bool Ignored { get; set; }
    }
}