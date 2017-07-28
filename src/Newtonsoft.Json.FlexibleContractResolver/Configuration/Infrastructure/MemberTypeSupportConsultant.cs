using System.Linq;
using System.Reflection;

namespace Newtonsoft.Json.FlexibleContractResolver.Configuration.Infrastructure
{
    public class MemberTypeSupportConsultant
    {
        private readonly MemberTypes[] _supportedTypes = new[] {MemberTypes.Property, MemberTypes.Field};
        public bool IsMemberTypeSupported(MemberTypes type)
        {
            return _supportedTypes.Contains(type);
        }
    }
}