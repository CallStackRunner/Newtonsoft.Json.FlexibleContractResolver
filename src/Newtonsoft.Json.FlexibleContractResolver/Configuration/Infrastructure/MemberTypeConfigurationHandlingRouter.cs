using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json.FlexibleContractResolver.Configuration.Types.Members.Handlers;
using Newtonsoft.Json.FlexibleContractResolver.Configuration.Types.Members.Handlers.Generic;

namespace Newtonsoft.Json.FlexibleContractResolver.Configuration.Infrastructure
{
    public class MemberTypeConfigurationHandlingRouter
    {
        #region member types handlers mapping
        private readonly IDictionary<MemberTypes, IMemberConfigurationHandler> _memberTypesConfigurationHandlersMapping
            = new Dictionary<MemberTypes, IMemberConfigurationHandler>()
            {
                {MemberTypes.Property, new PropertyConfigurationHandler()},
                {MemberTypes.Field, new FieldConfigurationHandler()}
            };
        #endregion

        public IMemberConfigurationHandler GetMemberConfigurationHandlerByMemberType(MemberTypes type)
        {
            if (!IsThereMemberConfigurationHandlerForType(type))
            {
                throw new NotSupportedException("handler for such member type is not supported");
            }

            return _memberTypesConfigurationHandlersMapping[type];
        }

        private bool IsThereMemberConfigurationHandlerForType(MemberTypes type)
        {
            return _memberTypesConfigurationHandlersMapping.ContainsKey(type);
        }
    }
}