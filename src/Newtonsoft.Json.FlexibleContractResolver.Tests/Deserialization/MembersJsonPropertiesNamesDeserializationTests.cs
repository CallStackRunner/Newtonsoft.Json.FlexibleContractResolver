using System;
using Newtonsoft.Json.FlexibleContractResolver.Configuration;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Newtonsoft.Json.FlexibleContractResolver.Tests.Deserialization
{
    [TestFixture]
    public class MembersJsonPropertiesNamesDeserializationTests : JsonRelatedTestsBase
    {
        [Test]
        public void ShouldConsiderMembersJsonBindings()
        {
            var resolver = new FlexibleContractResolver(ContractConfiguration.Of
                .Type<SampleTypes.Person>((person) =>
                {
                    person.Member(p => p.Name).BoundToJsonProperty.WithName("fullname");
                    person.Member(p => p.Age).BoundToJsonProperty.WithName("years");
                }));
            var birthday = new DateTime(1993, 10, 25);
            var serializedPerson = JObject.FromObject(new
            {
                fullname = "Pavel",
                years = 23,
                Birthday = birthday
            }).ToString();

            var deserialized = JsonConvert.DeserializeObject<SampleTypes.Person>(serializedPerson, new JsonSerializerSettings() {ContractResolver = resolver});

            Assert.That(deserialized.Name, Is.EqualTo("Pavel"));
            Assert.That(deserialized.Age, Is.EqualTo(23));
            Assert.That(deserialized.Birthday, Is.EqualTo(birthday));
        }
    }
}
