using FluentValidation;
using IT_Community.Server.Infrastructure.Dtos.CompanyDTOs;

namespace IT_Community.Server.Infrastructure.Validators.Company
{
    public class CompanyCreateValidator : AbstractValidator<CompanyCreateDto>
    {
        public CompanyCreateValidator()
        {
            RuleFor(p => p.Name)
                .NotNull()
                .NotEmpty();

            RuleFor(p => p.EmployeesAmount)
                .NotNull()
                .NotEmpty();

            RuleFor(p => p.Description)
                .NotNull()
                .NotEmpty();

            RuleFor(p => p.ImageFile)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Site)
                .NotNull()
                .NotEmpty()
                .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _)).When(x => !string.IsNullOrEmpty(x.Site))
                .WithMessage("Must be valid URI");
        }
    }
}
