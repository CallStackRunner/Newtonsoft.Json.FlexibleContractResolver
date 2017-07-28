using Newtonsoft.Json.Linq;

namespace Newtonsoft.Json.FlexibleContractResolver.Tests
{
    public abstract class JsonRelatedTestsBase
    {
        protected string JsonFromObject(object obj)
        {
            return JObject.FromObject(obj).ToString();
        }

        protected bool JsonsAreSame(string json1, string json2)
        {
            return JToken.DeepEquals(JObject.Parse(json1), JObject.Parse(json2));
        }
    }
}