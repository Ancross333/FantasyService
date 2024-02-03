using System.Text.RegularExpressions;
using FluentValidation;

public class CreateUserValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.Email)
        .NotEmpty()
        .WithMessage(x => $"Field {nameof(x.Email)} cannot be empty")
        .Must(BeAValidEmailAddress)
        .WithMessage("Email address is invalid");

        RuleFor(x => x.Username)
        .Must(NotExist)
        .WithMessage("Entered username is taken");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage(x => $"Field {nameof(x.Password)} cannot be empty")
            .Must(HaveAtLeastEightCharacters)
            .WithMessage(x => $"Field {nameof(x.Password)} must have at least 8 characters")
            .Must(HaveAtLeastOneUpperCaseLetter)
            .WithMessage(x => $"Field {nameof(x.Password)} must have at least 1 uppercase letter")
            .Must(HaveAtLeastOneLowerCaseLetter)
            .WithMessage(x => $"Field {nameof(x.Password)} must have at least 1 lowercase letter")
            .Must(HaveAtLeastOneDigit)
            .WithMessage(x => $"Field {nameof(x.Password)} must have at least 1 digit");

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage(x => $"Field {nameof(x.FirstName)} cannot be empty")
            .MinimumLength(2).WithMessage("First name must be at least 2 characters long")
            .MaximumLength(50).WithMessage("First name must be less than 50 characters long")
            .Matches("^[a-zA-Z-'\\s]+$").WithMessage("First name can only contain letters, hyphens, apostrophes or spaces");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage(x => $"Field {nameof(x.LastName)} cannot be empty")
            .MinimumLength(2).WithMessage("Last name must be at least 2 characters long")
            .MaximumLength(50).WithMessage("Last name must be less than 50 characters long")
            .Matches("^[a-zA-Z-'\\s]+$").WithMessage("Last name can only contain letters, hyphens, apostrophes or spaces");


            
    }

    private static bool BeAValidEmailAddress(string email)
    {
        if (string.IsNullOrEmpty(email))
            return false;

        string emailRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(email, emailRegex);
    }

    private static bool HaveAtLeastEightCharacters(string password)
    {
        return !string.IsNullOrEmpty(password) && password.Length >= 8;
    }

    private static bool HaveAtLeastOneUpperCaseLetter(string password)
    {
        return !string.IsNullOrEmpty(password) && password.Any(char.IsUpper);
    }

    private static bool HaveAtLeastOneLowerCaseLetter(string password)
    {
        return !string.IsNullOrEmpty(password) && password.Any(char.IsLower);
    }

    private static bool HaveAtLeastOneDigit(string password)
    {
        return !string.IsNullOrEmpty(password) && password.Any(char.IsDigit);
    }

    private bool NotExist(string username)
    {
        //TODO: Add De-Duplication logic
        return true;
    }
}