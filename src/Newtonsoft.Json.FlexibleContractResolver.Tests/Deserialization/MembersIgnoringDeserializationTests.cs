using System;
using Newtonsoft.Json.FlexibleContractResolver.Configuration;
using NUnit.Framework;

namespace Newtonsoft.Json.FlexibleContractResolver.Tests.Deserialization
{
    [TestFixture]
    public class MembersIgnoringDeserializationTests : JsonRelatedTestsBase
    {
        [Test]
        public void ShouldConsiderMemberIgnoringCondition()
        {
            var resolverWithoutCondition = new FlexibleContractResolver(ContractConfiguration.Of
                .Type<SampleTypes.WithSingleProperty>((t) =>
                {
                    t.Member(x => x.TheProperty).ShouldBe.Ignored();
                }));
            var resolverWithCondition = new FlexibleContractResolver(ContractConfiguration.Of
                .Type<SampleTypes.WithSingleProperty>((t) =>
                {
                    t.Member(x => x.TheProperty).ShouldBe.Ignored()
                        .When((SampleTypes.WithSingleProperty tt) => false);
                }));
            var serialized = JsonFromObject(new { TheProperty = "value" });

            var deserializedWithoutCondition = JsonConvert.DeserializeObject<SampleTypes.WithSingleProperty>(serialized,
                new JsonSerializerSettings() { ContractResolver = resolverWithoutCondition });
            var deserializedWithCondition = JsonConvert.DeserializeObject<SampleTypes.WithSingleProperty>(serialized,
                new JsonSerializerSettings() { ContractResolver = resolverWithCondition });

            // property should be ignored because no condition
            Assert.That(deserializedWithoutCondition.TheProperty, Is.Null);
            // property should be serialized because condition is always false
            Assert.That(deserializedWithCondition.TheProperty, Is.EqualTo("value"));
        }

        [Test]
        public void ShouldConsiderMembersIgnoring()
        {
            var resolver = new FlexibleContractResolver(ContractConfiguration.Of
                .Type<SampleTypes.Person>((person) =>
                {
                    person.Member(p => p.Name).BoundToJsonProperty.WithName("fullname");
                    person.Member(p => p.Age).ShouldBe.Ignored();
                }));
            var birthday = new DateTime(1993, 10, 25);
            var serializedPerson = JsonFromObject(new
            {
                fullname = "Pavel",
                years = 23,
                Birthday = birthday
            });

            var deserializedPerson = JsonConvert.DeserializeObject<SampleTypes.Person>(serializedPerson,
                new JsonSerializerSettings() { ContractResolver = resolver });

            Assert.That(deserializedPerson.Name, Is.EqualTo("Pavel"));
            Assert.That(deserializedPerson.Age, Is.EqualTo(default(int)));
            Assert.That(deserializedPerson.Birthday, Is.EqualTo(birthday));
        }
    }
}