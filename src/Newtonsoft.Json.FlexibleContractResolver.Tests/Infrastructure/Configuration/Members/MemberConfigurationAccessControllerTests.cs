using System;
using Newtonsoft.Json.FlexibleContractResolver.Configuration.Types;
using Newtonsoft.Json.FlexibleContractResolver.Infrastructure.Configuration.Members;
using NUnit.Framework;

namespace Newtonsoft.Json.FlexibleContractResolver.Tests.Infrastructure.Configuration.Members
{
    [TestFixture]
    public class MemberConfigurationAccessControllerTests : MemberTypesRelatedTestsBase
    {
        [Test]
        public void ShouldSupportSupportedMemberTypes()
        {
            var supportConsultant = new MemberTypeSupportConsultant();
            var controller = new MemberConfigurationAccessController();

            foreach (var supportedMemberType in supportConsultant.SupportedTypes)
            {
                // absence of NotSupportedExceptions means type is supported
                controller.CreateMemberConfigurationForType("member", supportedMemberType,
                    new TypeResolvingConfiguration(typeof(object)));
                controller.GetMemberConfigurationType("member", supportedMemberType,
                    new TypeResolvingConfiguration(typeof(object)));
                controller.HasMemberConfigurationType("member", supportedMemberType,
                    new TypeResolvingConfiguration(typeof(object)));
            }
        }

        [Test]
        public void ShouldThrowNotSupportedException_WhenMemberTypeIsNotSupported()
        {
            var controller = new MemberConfigurationAccessController();
            var notSupportedMemberType = NotSupportedMemberType;

            Assert.Throws<NotSupportedException>(() => controller.CreateMemberConfigurationForType("member",
                notSupportedMemberType,
                new TypeResolvingConfiguration(typeof(object))));
            Assert.Throws<NotSupportedException>(() => controller.GetMemberConfigurationType("member",
                notSupportedMemberType,
                new TypeResolvingConfiguration(typeof(object))));
            Assert.Throws<NotSupportedException>(() => controller.HasMemberConfigurationType("member",
                notSupportedMemberType,
                new TypeResolvingConfiguration(typeof(object))));
        }
    }
}
