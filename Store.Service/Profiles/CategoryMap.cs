using AutoMapper;
using Store.Service.Dtos.Category;
using Store.Core.Models;
using Store.Servcice.Dtos.Category;

namespace Store.Service.Profiles
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
