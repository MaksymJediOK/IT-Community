using FluentValidation;
using IT_Community.Server.Core.Entities;
using IT_Community.Server.Infrastructure.Dtos.PostDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Community.Server.Infrastructure.Validators
{
    public class PostCreateValidator : AbstractValidator<PostCreateDto>
    {
        public PostCreateValidator()
        {
            RuleFor(p => p.Title)
                .NotNull()
                .NotEmpty()
                .Length(5,60)
                .WithMessage("Title must be between 5 and 60 symbols");

            //RuleFor(p => p.ImageFile)
            //    .NotNull()
            //    .NotEmpty();

            RuleFor(p => p.Description)
                .NotNull()
                .NotEmpty()
                .Length(10,250);

            RuleFor(p => p.Body)
                .NotNull()
                .NotEmpty()
                .Length(1,100000);

            RuleFor(p => p.ForumId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Invalid ForumId");
        }
    }
}
