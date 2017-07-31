using System;

namespace Newtonsoft.Json.FlexibleContractResolver.Tests
{
    public class SampleTypes
    {
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public DateTime Birthday { get; set; }
        }

        public class WithSingleProperty
        {
            public string TheProperty { get; set; }
        }
    }
}