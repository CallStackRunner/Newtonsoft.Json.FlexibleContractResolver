using System;
using Newtonsoft.Json.FlexibleContractResolver.Configuration;
using NUnit.Framework;

namespace Newtonsoft.Json.FlexibleContractResolver.Tests.Serialization
{
    [TestFixture]
    public class MembersSerializationTests : JsonRelatedTestsBase
    {
        [Test]
        public void ShouldConsiderMembersJsonBindings()
        {
            var resolver = new FlexibleContractResolver(ContractConfiguration.Of
                .Type<Person>((_person) =>
                {
                    _person.Member(p => p.Name).HasJsonBinding("fullname");
                    _person.Member(p => p.Age).HasJsonBinding("years");
                }));
            var birthday = new DateTime(1993, 10, 25);
            var person = new Person() { Name = "Pavel", Age = 23, Birthday = birthday };

            var serialized = JsonConvert.SerializeObject(person,
                new JsonSerializerSettings() { ContractResolver = resolver });

            Assert.That(JsonsAreSame(serialized, JsonFromObject(new
            {
                fullname = "Pavel",
                years = 23,
                Birthday = birthday
            })));
        }

        [Test]
        public void ShouldConsiderMembersIgnoring()
        {
            var resolver = new FlexibleContractResolver(ContractConfiguration.Of
                .Type<Person>((_person) =>
                {
                    _person.Member(p => p.Name).ShouldBeIgnored();
                    _person.Member(p => p.Age).ShouldBeIgnored();
                }));
            var birthday = new DateTime(1993, 10, 25);
            var person = new Person() { Name = "Pavel", Age = 23, Birthday = birthday };

            var serialized = JsonConvert.SerializeObject(person, new JsonSerializerSettings() { ContractResolver = resolver });

            Assert.That(JsonsAreSame(serialized, JsonFromObject(new
            {
                Birthday = birthday
            })));
        }

        private class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public DateTime Birthday { get; set; }
        }
    }
}