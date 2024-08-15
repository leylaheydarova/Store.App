using FluentValidation;
using Store.Service.Dtos.Category;

namespace Store.Service.Validations.Category
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
