using FluentValidation;
using IT_Community.Server.Infrastructure.Dtos.CompanyDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Community.Server.Infrastructure.Validators.Company
{
    public class CompanyEditValidator : AbstractValidator<CompanyEditDto>
    {
        public CompanyEditValidator()
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

            RuleFor(x => x.Site)
                .NotNull()
                .NotEmpty()
                .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _)).When(x => !string.IsNullOrEmpty(x.Site))
                .WithMessage("Must be valid URI");
        }
    }
}
