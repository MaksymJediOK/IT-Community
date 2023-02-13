using FluentValidation;
using IT_Community.Server.Infrastructure.Dtos.CommentDTOs;
using IT_Community.Server.Infrastructure.Dtos.PostDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Community.Server.Infrastructure.Validators
{
    public class CommentCreateValidator : AbstractValidator<CommentCreateDto>
    {
        public CommentCreateValidator()
        {
            RuleFor(p => p.Body)
                .NotNull()
                .NotEmpty()
                .MinimumLength(15)
                .WithMessage("Comment must contain at least 15 characters");

            RuleFor(p => p.PostId)
                .NotNull()
                .NotEmpty();
        }
    }
}
