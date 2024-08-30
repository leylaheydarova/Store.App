using Store.Servcice.Dtos.Category;
using Store.Service.Dtos.Category;
using Store.Service.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<ApiResponseWithData> GetAllAsync();
        Task<ApiResponse> CreateAsync(CategoryPostDto dto);
        Task<ApiResponseWithData> GetAsync(string id);
        Task<ApiResponse> DeleteAsync(string id);
        Task<ApiResponse> RemoveAsync(string id);
        Task<ApiResponse> UpdateAsync(CategoryPutDto dto, string id);
    }
}
