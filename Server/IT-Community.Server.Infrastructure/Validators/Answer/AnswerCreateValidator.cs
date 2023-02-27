using FluentValidation;
using IT_Community.Server.Infrastructure.Dtos.AnswerDTOs;

namespace IT_Community.Server.Infrastructure.Validators.Answer
{
    public class AnswerCreateValidator : AbstractValidator<AnswerCreateDto>
    {
        public AnswerCreateValidator()
        {
            RuleFor(p => p.VacancyId)
                .NotNull()
                .NotEmpty();

            RuleFor(p => p.CVFile.Length)
                .NotNull()
                .LessThanOrEqualTo(3 * 1024 * 1024)
                .WithMessage("File size is larger than allowed");

            RuleFor(p => p.CVFile.ContentType)
                .NotNull()
                .Must(p => p.Equals("application/msword")
                || p.Equals("application/vnd.openxmlformats-officedocument.wordprocessingml.document")
                || p.Equals("application/pdf"))
                .WithMessage("File type is not allowed");

            RuleFor(p => p.CVFile)
                .NotNull()
                .NotEmpty();
        }
    }
}
