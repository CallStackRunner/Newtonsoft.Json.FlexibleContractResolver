namespace Newtonsoft.Json.FlexibleContractResolver.Configuration.Types.Members.Generic
{
    /// <summary>
    /// An interface for member type resolving configuration
    /// </summary>
    /// <typeparam name="TMemberConfiguration">member configuration type</typeparam>
    public interface IMemberTypeResolvingConfigration<out TMemberConfiguration>
        where TMemberConfiguration : IMemberConfiguration, new()
    {
        /// <summary>
        /// Determines is member configured
        /// </summary>
        /// <param name="memberName">a member name</param>
        bool HasMemberConfiguration(string memberName);

        /// <summary>
        /// Provides a member configuration
        /// </summary>
        /// <param name="memberName">member name</param>
        /// <returns>member configuration or null if it's not exists</returns>
        TMemberConfiguration GetMemberConfiguration(string memberName);

        /// <summary>
        /// Creating member configuration if it's not exists
        /// </summary>
        /// <param name="memberName">member name</param>
        /// <returns>newly created member configuration or or existing one</returns>
        TMemberConfiguration CreateMemberConfiguration(string memberName);
    }
}