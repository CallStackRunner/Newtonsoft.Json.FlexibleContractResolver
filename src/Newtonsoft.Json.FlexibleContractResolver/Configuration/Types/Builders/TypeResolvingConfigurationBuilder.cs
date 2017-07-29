using System;
using System.Linq.Expressions;
using Newtonsoft.Json.FlexibleContractResolver.Infrastructure.Configuration.Members;

namespace Newtonsoft.Json.FlexibleContractResolver.Configuration.Types.Builders
{
    public class TypeResolvingConfigurationBuilder<T>
    {
        private readonly MemberTypeSupportConsultant _memberTypeSupportConsultant = new MemberTypeSupportConsultant();
        private readonly MemberConfigurationFactory _memberConfigurationFactory = new MemberConfigurationFactory();

        private TypeResolvingConfiguration Configuration { get; }

        public TypeResolvingConfigurationBuilder(TypeResolvingConfiguration configuration)
        {
            Configuration = configuration;
        }

        public MemberConfigurationBuilder Member<TMember>(Expression<Func<T, TMember>> member)
        {
            if (member == null)
            {
                throw new ArgumentNullException(nameof(member));
            }

            var expression = member.Body as MemberExpression;
            if (expression == null 
                || !_memberTypeSupportConsultant.IsMemberTypeSupported(expression.Member.MemberType))
            {
                // expression contains access to not [supported] member
                throw new ArgumentException("only supported member returning expressions are allowed to pass in \"Member\" method");
            }

            return new MemberConfigurationBuilder(_memberConfigurationFactory.CreateMemberConfigurationForType(expression.Member.Name, 
                expression.Member.MemberType, 
                Configuration));
        }
    }
}