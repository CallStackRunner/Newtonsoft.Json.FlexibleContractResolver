using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json.FlexibleContractResolver.Configuration.Types;
using Newtonsoft.Json.FlexibleContractResolver.Configuration.Types.Members.Generic;

namespace Newtonsoft.Json.FlexibleContractResolver.Infrastructure.Configuration.Members
{
    public class MemberConfigurationAccessController
    {
        private readonly IDictionary<MemberTypes, Func<TypeResolvingConfiguration, string, IMemberConfiguration>> _memberTypesConfigurationsFactoriesMapping 
            = new Dictionary<MemberTypes, Func<TypeResolvingConfiguration, string, IMemberConfiguration>>()
            {
                { MemberTypes.Field, (trc, name) => trc.Fields.CreateMemberConfiguration(name) },
                { MemberTypes.Property, (trc, name) => trc.Properties.CreateMemberConfiguration(name) }
            };
        private readonly IDictionary<MemberTypes, Func<TypeResolvingConfiguration, string, IMemberConfiguration>> _memberTypesConfigurationsAccessorsMapping
            = new Dictionary<MemberTypes, Func<TypeResolvingConfiguration, string, IMemberConfiguration>>()
            {
                { MemberTypes.Field, (trc, name) => trc.Fields.GetMemberConfiguration(name) },
                { MemberTypes.Property, (trc, name) => trc.Properties.CreateMemberConfiguration(name) }
            };
        private readonly IDictionary<MemberTypes, Func<TypeResolvingConfiguration, string, bool>> _memberTypesConfigurationsExistenceHandlersMapping
            = new Dictionary<MemberTypes, Func<TypeResolvingConfiguration, string, bool>>()
            {
                { MemberTypes.Field, (trc, name) => trc.Fields.HasMemberConfiguration(name) },
                { MemberTypes.Property, (trc, name) => trc.Properties.HasMemberConfiguration(name) }
            };
        private readonly MemberTypeSupportConsultant _memberTypeSupportConsultant = new MemberTypeSupportConsultant();

        public IMemberConfiguration CreateMemberConfigurationForType(string memberName, MemberTypes memberType, TypeResolvingConfiguration typeResolvingConfiguration)
        {
            if (!_memberTypeSupportConsultant.IsMemberTypeSupported(memberType))
            {
                throw new NotSupportedException("can't create configuration for member that type is not supported");
            }

            return _memberTypesConfigurationsFactoriesMapping[memberType]
                .Invoke(typeResolvingConfiguration, memberName);
        }

        public IMemberConfiguration GetMemberConfigurationType(string memberName, MemberTypes memberType,
            TypeResolvingConfiguration typeResolvingConfiguration)
        {
            if (!_memberTypeSupportConsultant.IsMemberTypeSupported(memberType))
            {
                throw new NotSupportedException("can't get configuration for member that type is not supported");
            }

            return _memberTypesConfigurationsAccessorsMapping[memberType]
                .Invoke(typeResolvingConfiguration, memberName);
        }

        public bool HasMemberConfigurationType(string memberName, MemberTypes memberType,
            TypeResolvingConfiguration typeResolvingConfiguration)
        {
            if (!_memberTypeSupportConsultant.IsMemberTypeSupported(memberType))
            {
                throw new NotSupportedException("can't determine existence of configuration for member that type is not supported");
            }

            return _memberTypesConfigurationsExistenceHandlersMapping[memberType]
                .Invoke(typeResolvingConfiguration, memberName);
        }
    }
}