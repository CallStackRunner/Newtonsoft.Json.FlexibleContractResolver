using System;
using Newtonsoft.Json.FlexibleContractResolver.Infrastructure.Configuration.Members;
using NUnit.Framework;

namespace Newtonsoft.Json.FlexibleContractResolver.Tests.Infrastructure.Configuration.Members
{
    [TestFixture]
    public class MemberTypeConfigurationHandlingRouterTests : MemberTypesRelatedTestsBase
    {
        [Test]
        public void ShouldSupportSupportedMemberTypes()
        {
            var supportConsultant = new MemberTypeSupportConsultant();
            var router = new MemberTypeConfigurationHandlingRouter();

            foreach (var supportedMemberType in supportConsultant.SupportedTypes)
            {
                // absence of NotSupportedException means type is supported
                router.GetMemberConfigurationHandlerByMemberType(supportedMemberType);
            }
        }

        [Test]
        public void ShouldThrowNotSupportedException_WhenMemberTypeIsNotSupported()
        {
            var router = new MemberTypeConfigurationHandlingRouter();
            var notSupportedMemberType = NotSupportedMemberType;

            Assert.Throws<NotSupportedException>(() => router.GetMemberConfigurationHandlerByMemberType(notSupportedMemberType));
        }
    }
}