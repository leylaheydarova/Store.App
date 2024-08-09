using FluentValidation;
using Store.App.Dtos.Category;

namespace Store.App.Validations.Category
{
    public class CategoryPutDtoValidation:AbstractValidator<CategoryPutDto>
    {
        public CategoryPutDtoValidation()
        {
            RuleFor(x => x.Name)
               .NotEmpty()
               .NotNull()
               .MinimumLength(3);
        }
    }
}
