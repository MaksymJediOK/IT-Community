using FluentValidation;
using IT_Community.Server.Infrastructure.Dtos.VacancyDTOs;

namespace IT_Community.Server.Infrastructure.Validators.Vacancy
{
    public class VacancyCreateValidator : AbstractValidator<VacancyCreateDto>
    {
        public VacancyCreateValidator()
        {
            RuleFor(p => p.Title)
                .NotNull()
                .NotEmpty();

            RuleFor(p => p.Experience)
                .NotNull()
                .NotEmpty();

            RuleFor(p => p.Description)
                .NotNull()
                .NotEmpty();

            RuleFor(p => p.CategoryId)
                .NotEmpty();

            RuleFor(x => x.Email).EmailAddress();
        }
    }
}
