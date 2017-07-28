using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json.FlexibleContractResolver.Configuration.Types;
using Newtonsoft.Json.FlexibleContractResolver.Configuration.Types.Members;
using Newtonsoft.Json.FlexibleContractResolver.Configuration.Types.Members.Generic;

namespace Newtonsoft.Json.FlexibleContractResolver.Configuration.Infrastructure
{
    public class MemberConfigurationFactory
    {
        private readonly IDictionary<MemberTypes, Func<TypeResolvingConfiguration, string, IMemberConfiguration>> _memberTypesConfigurationsFactoriesMapping 
            = new Dictionary<MemberTypes, Func<TypeResolvingConfiguration, string, IMemberConfiguration>>()
            {
                { MemberTypes.Field, (trc, name) => trc.Fields.CreateMemberConfiguration(name) },
                {MemberTypes.Property, (trc, name) => trc.Properties.CreateMemberConfiguration(name) }
            };
        private MemberTypeSupportConsultant MemberTypeSupportConsultant { get; }

        public MemberConfigurationFactory()
        {
            MemberTypeSupportConsultant = new MemberTypeSupportConsultant();
        }

        public IMemberConfiguration CreateMemberConfiguration(string memberName, MemberTypes memberType, TypeResolvingConfiguration typeResolvingConfiguration)
        {
            if (!MemberTypeSupportConsultant.IsMemberTypeSupported(memberType))
            {
                throw new NotSupportedException("can't create configuration for member type that's not supported");
            }

            return _memberTypesConfigurationsFactoriesMapping[memberType].Invoke(typeResolvingConfiguration, memberName);
        }
    }
}