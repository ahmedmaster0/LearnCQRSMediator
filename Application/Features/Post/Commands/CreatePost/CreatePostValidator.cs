

using FluentValidation;

namespace Application.Features.Post.Commands.CreatePost
{
    public class CreatePostValidator : AbstractValidator<CreatePostCommand>
    {
        public CreatePostValidator()
        {
            RuleFor( m => m.Title )
                .NotNull()
                .MaximumLength(100)
                .NotEmpty();

            RuleFor(m => m.Content)
                .NotNull()
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
