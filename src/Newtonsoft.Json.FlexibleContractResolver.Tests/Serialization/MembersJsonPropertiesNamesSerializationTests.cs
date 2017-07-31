using System;
using Newtonsoft.Json.FlexibleContractResolver.Configuration;
using NUnit.Framework;

namespace Newtonsoft.Json.FlexibleContractResolver.Tests.Serialization
{
    [TestFixture]
    public class MembersJsonPropertiesNamesSerializationTests : JsonRelatedTestsBase
    {
        [Test]
        public void ShouldConsiderMembersJsonBindings()
        {
            var resolver = new FlexibleContractResolver(ContractConfiguration.Of
                .Type<SampleTypes.Person>((_person) =>
                {
                    _person.Member(p => p.Name).BoundToJsonProperty.WithName("fullname");
                    _person.Member(p => p.Age).BoundToJsonProperty.WithName("years");
                }));
            var birthday = new DateTime(1993, 10, 25);
            var person = new SampleTypes.Person() { Name = "Pavel", Age = 23, Birthday = birthday };

            var serialized = JsonConvert.SerializeObject(person,
                new JsonSerializerSettings() { ContractResolver = resolver });

            Assert.That(JsonsAreSame(serialized, JsonFromObject(new
            {
                fullname = "Pavel",
                years = 23,
                Birthday = birthday
            })));
        }
    }
}