using System;
using Newtonsoft.Json.FlexibleContractResolver.Configuration;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Newtonsoft.Json.FlexibleContractResolver.Tests.Deserialization
{
    [TestFixture]
    public class MembersDeserializationTests : JsonRelatedTestsBase
    {
        [Test]
        public void ShouldConsiderMembersJsonBindings()
        {
            var resolver = new FlexibleContractResolver(ContractConfiguration.Of
                .Type<Person>((person) =>
                {
                    person.Member(p => p.Name).HasJsonBinding("fullname");
                    person.Member(p => p.Age).HasJsonBinding("years");
                }));
            var birthday = new DateTime(1993, 10, 25);
            var serializedPerson = JObject.FromObject(new
            {
                fullname = "Pavel",
                years = 23,
                Birthday = birthday
            }).ToString();

            var deserialized = JsonConvert.DeserializeObject<Person>(serializedPerson, new JsonSerializerSettings() {ContractResolver = resolver});

            Assert.That(deserialized.Name, Is.EqualTo("Pavel"));
            Assert.That(deserialized.Age, Is.EqualTo(23));
            Assert.That(deserialized.Birthday, Is.EqualTo(birthday));
        }

        [Test]
        public void ShouldConsiderMembersIgnoring()
        {
            var resolver = new FlexibleContractResolver(ContractConfiguration.Of
                .Type<Person>((person) =>
                {
                    person.Member(p => p.Name).HasJsonBinding("fullname");
                    person.Member(p => p.Age).HasJsonBinding("years").ShouldBeIgnored();
                }));
            var birthday = new DateTime(1993, 10, 25);
            var serializedPerson = JsonFromObject(new
            {
                fullname = "Pavel",
                years = 23,
                Birthday = birthday
            });

            var deserializedPerson = JsonConvert.DeserializeObject<Person>(serializedPerson, 
                new JsonSerializerSettings() { ContractResolver = resolver });

            Assert.That(deserializedPerson.Name, Is.EqualTo("Pavel"));
            Assert.That(deserializedPerson.Age, Is.EqualTo(default(int)));
            Assert.That(deserializedPerson.Birthday, Is.EqualTo(birthday));
        }

        private class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public DateTime Birthday { get; set; }
        }
    }
}
