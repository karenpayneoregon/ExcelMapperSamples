using FluentValidation;

namespace ValidationLibrary;
public static class RuleBuilderExtensions
{

    public static IRuleBuilderOptions<T, string> NoNoneAsciiCharacters<T>(this IRuleBuilder<T, string> ruleBuilder) 
        => ruleBuilder
            .NotEmpty()
            .Must(m => m.IsOnlyAsciiLetters())
            .WithMessage("'{PropertyName}' is not valid");
}
