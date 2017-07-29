using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json.FlexibleContractResolver.Infrastructure.Configuration.Members;

namespace Newtonsoft.Json.FlexibleContractResolver.Tests.Infrastructure.Configuration.Members
{
    public abstract class MemberTypesRelatedTestsBase
    {
        protected MemberTypes NotSupportedMemberType = Enum.GetValues(typeof(MemberTypes))
            .Cast<MemberTypes>()
            .Except(new MemberTypeSupportConsultant().SupportedTypes)
            .First();
    }
}