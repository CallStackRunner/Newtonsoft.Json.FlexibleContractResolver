using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Newtonsoft.Json.FlexibleContractResolver.Infrastructure.Configuration.Members
{
    public class MemberTypeSupportConsultant
    {
        private readonly MemberTypes[] _supportedTypes =  {MemberTypes.Property, MemberTypes.Field };

        public IEnumerable<MemberTypes> SupportedTypes => _supportedTypes;

        public bool IsMemberTypeSupported(MemberTypes type)
        {
            return _supportedTypes.Contains(type);
        }
    }
}