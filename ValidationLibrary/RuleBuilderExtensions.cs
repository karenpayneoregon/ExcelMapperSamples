using FluentValidation;

namespace ValidationLibrary;
public static class RuleBuilderExtensions
{

    /// <summary>
    /// Defines a validation rule that ensures the string property contains only ASCII characters.
    /// </summary>
    /// <typeparam name="T">The type of the object being validated.</typeparam>
    /// <param name="ruleBuilder">The rule builder on which the validation rule is defined.</param>
    /// <returns>An instance of <see cref="IRuleBuilderOptions{T, string}"/> to continue building the rule.</returns>
    public static IRuleBuilderOptions<T, string> NoNoneAsciiCharacters<T>(this IRuleBuilder<T, string> ruleBuilder) 
        => ruleBuilder
            .NotEmpty()
            .Must(m => m.IsOnlyAsciiLetters())
            .WithMessage("'{PropertyName}' is not valid");
}
