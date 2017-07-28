using System;
using System.Linq.Expressions;
using Newtonsoft.Json.FlexibleContractResolver.Configuration.Infrastructure;

namespace Newtonsoft.Json.FlexibleContractResolver.Configuration.Types.Builders
{
    public class TypeResolvingConfigurationBuilder<T>
    {
        private TypeResolvingConfiguration Configuration { get; }
        private MemberTypeSupportFacade MemberTypeSupportFacade { get; }

        public TypeResolvingConfigurationBuilder(TypeResolvingConfiguration configuration)
        {
            Configuration = configuration;
            MemberTypeSupportFacade = new MemberTypeSupportFacade();
        }

        public MemberConfigurationBuilder Member<TMember>(Expression<Func<T, TMember>> member)
        {
            if (member == null)
            {
                throw new ArgumentNullException(nameof(member));
            }

            var expression = member.Body as MemberExpression;
            if (expression == null 
                || !MemberTypeSupportFacade.MemberTypeSupportConsultant.IsMemberTypeSupported(expression.Member.MemberType))
            {
                // expression contains access to not [supported] member
                throw new ArgumentException("only supported member returning expressions are allowed to pass in \"Member\" method");
            }

            return new MemberConfigurationBuilder(MemberTypeSupportFacade.MemberConfigurationFactory.CreateMemberConfiguration(expression.Member.Name, 
                expression.Member.MemberType, 
                Configuration));
        }
    }
}