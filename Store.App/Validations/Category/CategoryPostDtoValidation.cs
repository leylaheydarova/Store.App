using FluentValidation;
using Store.App.Dtos.Category;

namespace Store.App.Validations.Category
{
    public class CategoryPostDtoValidation:AbstractValidator<CategoryPostDto>
    {
        public CategoryPostDtoValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3);
        }
    }
}
