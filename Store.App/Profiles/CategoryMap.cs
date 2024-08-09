using AutoMapper;
using Store.App.Dtos.Category;
using Store.App.Models;

namespace Store.App.Profiles
{
    public class CategoryMap:Profile
    {
        public CategoryMap()
        {
            CreateMap<CategoryPostDto, Category>().ReverseMap();
            CreateMap<CategoryPutDto, Category>().ReverseMap();
            CreateMap<Category, CategoryGetDto>().ReverseMap();
        }
    }
}
