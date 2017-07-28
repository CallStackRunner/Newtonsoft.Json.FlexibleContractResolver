namespace Newtonsoft.Json.FlexibleContractResolver.Configuration.Types.Members.Generic
{
    /// <summary>
    /// An interface for any member type
    /// </summary>
    public interface IMemberConfiguration
    {
        string MemberName { get; set; }
        string JsonBinding { get; set; }
        bool Ignored { get; set; }
    }
}