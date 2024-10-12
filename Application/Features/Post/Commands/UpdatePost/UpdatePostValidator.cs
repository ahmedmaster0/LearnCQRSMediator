
using FluentValidation;

namespace Application.Features.Post.Commands.UpdatePost
{
    public class UpdatePostValidator : AbstractValidator<UpdatePostCommand>
    {
        public UpdatePostValidator()
        {
            RuleFor(m => m.Id)
                .NotNull()
                .NotEmpty();

            RuleFor(m => m.Content)
               .NotNull()
               .NotEmpty();

            RuleFor(m => m.Title)
              .NotNull()
              .Length(100)
              .NotEmpty();

            RuleFor(m => m.ImageUrl)
             .NotNull()
             .NotEmpty();

            RuleFor(m => m.CategoryId)
              .NotNull()
              .NotEmpty();
        }
    }
}
