using Newtonsoft.Json.FlexibleContractResolver.Configuration.Types.Members.Generic;

namespace Newtonsoft.Json.FlexibleContractResolver.Configuration.Types.Members
{
    /// <summary>
    /// Particular field resolving cofiguration
    /// </summary>
    public class FieldResolvingConfiguration : IMemberConfiguration
    {
        public string MemberName { get; set; }
        public string JsonBinding { get; set; }
        public bool Ignored { get; set; }
    }
}