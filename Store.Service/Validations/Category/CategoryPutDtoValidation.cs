using FluentValidation;
using Store.Servcice.Dtos.Category;
using Store.Service.Dtos.Category;

namespace Store.Service.Validations.Category
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
