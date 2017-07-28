namespace Newtonsoft.Json.FlexibleContractResolver.Configuration.Infrastructure
{
    public class MemberTypeSupportFacade
    {
        public MemberTypeConfigurationHandlingRouter MemberTypeConfigurationHandlingRouter { get; } = new MemberTypeConfigurationHandlingRouter();
        public MemberTypeSupportConsultant MemberTypeSupportConsultant { get; } = new MemberTypeSupportConsultant();
        public MemberConfigurationFactory MemberConfigurationFactory { get; } = new MemberConfigurationFactory();
    }
}