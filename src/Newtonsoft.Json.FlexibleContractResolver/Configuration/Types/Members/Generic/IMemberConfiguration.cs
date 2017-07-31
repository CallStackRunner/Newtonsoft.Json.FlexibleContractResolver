using System;

namespace Newtonsoft.Json.FlexibleContractResolver.Configuration.Types.Members.Generic
{
    /// <summary>
    /// An interface for any member type configuration
    /// </summary>
    public interface IMemberConfiguration
    {
        string MemberName { get; set; }
        MemberJsonPropertyNameConfiguration JsonPropertyName { get; set; }
        MemberIgnoringConfiguration Ignoring { get; set; }
    }

    public class MemberJsonPropertyNameConfiguration
    {
        public IMemberConfiguration ParentConfiguration { get; }
        public string Name { get; set; }
        public Delegate ComputeJsonPropertyName { get; set; }

        public MemberJsonPropertyNameConfiguration(IMemberConfiguration parentConfiguration)
        {
            ParentConfiguration = parentConfiguration;
        }
    }

    public class MemberIgnoringConfiguration
    {
        public bool ShouldBeIgnored { get; set; }
        public Delegate WhenShouldBeIgnored { get; set; }
    }
}