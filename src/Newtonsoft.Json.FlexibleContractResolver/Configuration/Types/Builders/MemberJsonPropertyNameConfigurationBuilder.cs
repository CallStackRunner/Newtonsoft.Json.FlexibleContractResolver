using System;
using Newtonsoft.Json.FlexibleContractResolver.Configuration.Types.Members.Generic;

namespace Newtonsoft.Json.FlexibleContractResolver.Configuration.Types.Builders
{
    public class MemberJsonPropertyNameConfigurationBuilder
    {
        private readonly MemberJsonPropertyNameConfiguration _configuration;

        public MemberJsonPropertyNameConfigurationBuilder(MemberJsonPropertyNameConfiguration configuration)
        {
            _configuration = configuration;
        }

        public MemberJsonPropertyNameConfigurationBuilder WithSameName
        {
            get
            {
                _configuration.Name = _configuration.ParentConfiguration.MemberName;
                return this;
            }
        }

        public MemberJsonPropertyNameConfigurationBuilder WithName(string jsonPropertyName)
        {
            _configuration.Name = jsonPropertyName;
            return this;
        }

        public MemberJsonPropertyNameConfigurationBuilder WithComputedName<TDeclaringType>(Func<TDeclaringType, string> computeJsonPropertyName)
        {
            _configuration.ComputeJsonPropertyName = computeJsonPropertyName;
            return this;
        }
    }
}