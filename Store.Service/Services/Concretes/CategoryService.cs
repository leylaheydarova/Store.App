using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Store.Core.Models;
using Store.Core.Repositories.Abstractions.Categories;
using Store.Servcice.Dtos.Category;
using Store.Service.Dtos.Category;
using Store.Service.Responses;
using Store.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Services.Concretes
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryReadRepository _readRepository;
        private readonly ICategoryWriteRepository _writeRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryReadRepository readRepository, ICategoryWriteRepository writeRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse> CreateAsync(CategoryPostDto dto)
        {
            Category category = _mapper.Map<Category>(dto);
            await _writeRepository.AddAsync(category);
            await _writeRepository.SaveAsync();
            return new ApiResponse { StatusCode = 201, Message = "Created Successfully" };
        }

        public async Task<ApiResponse> DeleteAsync(string id)
        {
            Category category = await _readRepository.GetWhere(x => x.Id.ToString() == id);
            if (category == null)
            {
                return new ApiResponse { StatusCode = 404, Message = "NOT FOUND!" };
            }
            _writeRepository.Delete(category);
            await _writeRepository.SaveAsync();
            return new ApiResponse { StatusCode = 204, Message = "Deleted Temporarily!" };
        }

        public async Task<ApiResponseWithData> GetAllAsync()
        {
            var query = _readRepository.GetAllWhereAsync(x=>!x.isDeleted, false);
            List<CategoryGetDto> dtos = new List<CategoryGetDto>();
            dtos = await query.Select(x=> new CategoryGetDto { Id = x.Id.ToString(), Name = x.Name }).ToListAsync();
            return new ApiResponseWithData { StatusCode = 200, Datas = dtos };

        }

        public async Task<ApiResponseWithData> GetAsync(string id)
        {
            Category category = await _readRepository.GetWhere(x => x.Id.ToString() == id);
            if (category == null)
            {
                return new ApiResponseWithData { StatusCode = 404, Message = "NOT FOUND!" };
            }
            CategoryGetDto dto = _mapper.Map<CategoryGetDto>(category);
            return new ApiResponseWithData { StatusCode = 200, Datas = dto };
        }

        public async Task<ApiResponse> RemoveAsync(string id)
        {
            Category category = await _readRepository.GetWhere(x => x.Id.ToString() == id);
            if (category == null)
            {
                return new ApiResponse { StatusCode = 404, Message = "NOT FOUND!" };
            }
            _writeRepository.Remove(category);
            await _writeRepository.SaveAsync();
            return new ApiResponse { StatusCode = 204, Message = "Deleted Permanently!" };
        }

        public async Task<ApiResponse> UpdateAsync(CategoryPutDto dto, string id)
        {
            Category category = await _readRepository.GetWhere(x => x.Id.ToString() == id);
            if (category == null)
            {
                return new ApiResponse { StatusCode = 404, Message = "NOT FOUND!" };
            }
            category.Name = dto.Name;
            category.UpdatedAt = DateTime.UtcNow.AddHours(4);
            _writeRepository.Update(category);
            await _writeRepository.SaveAsync();
            return new ApiResponse { StatusCode = 200, Message = "Updated Successfully!" };
        }
    }
}
