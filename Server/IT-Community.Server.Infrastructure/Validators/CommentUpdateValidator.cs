﻿using FluentValidation;
using IT_Community.Server.Infrastructure.Dtos.CommentDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Community.Server.Infrastructure.Validators
{
    public class CommentUpdateValidator : AbstractValidator<CommentUpdateDto>
    {
        public CommentUpdateValidator()
        {
            RuleFor(p => p.Body)
                .NotNull()
                .NotEmpty()
                .MinimumLength(15)
                .WithMessage("Comment must contain at least 15 characters");

            RuleFor(p => p.CommentId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Comment id is null or empty");
        }
    }
}
