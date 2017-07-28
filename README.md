# Newtonsoft.Json.FlexibleContractResolver
The goal of this library is to provide alternative way to configure how your types will be [de]serialized using an awesome [Newtonsoft.Json library](https://github.com/JamesNK/Newtonsoft.Json).

## Quick example
```cs
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public DateTime Birthday { get; set; }
}

var configuration = ContractConfiguration.Of
    .Type<Person>((person) =>
    {
        person.Member(p => p.Name).HasJsonBinding("fullname");
        person.Member(p => p.Age).HasJsonBinding("years");
        person.Member(p => p.Birthday).ShouldBeIgnored();
    });
var person = new Person() { Name = "Pavel", Age = 23, Birthday = DateTime.Now.AddYears(-23) };
var serialized = JsonConvert.SerializeObject(person, 
    new JsonSerializerSettings() { ContractResolver = new FlexibleContractResolver(configuration) });
// serialized:
// {
//     "fullname":"Pavel",
//     "years":23
// }
```
Check out the [Introduction](https://github.com/CallStackRunner/Newtonsoft.Json.FlexibleContractResolver/wiki/Introduction); this example explained more detailed there and compared with traditional Newtonsoft.Json way of defining JSON serialization schema.

## Features
* A fluent way to define your serialization settings instead of attributes
* An opportunity to organize your configuration outside from model (useful when you should serialize classes that don't belongs to you (e.g. from 3rd party library) or just don't like attributes in your model)

## Development status
Active development. Current version is very early, not recommended to use in production. Check out [roadmap](https://github.com/CallStackRunner/Newtonsoft.Json.FlexibleContractResolver/wiki/Development-status-and-roadmap) for details.