using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Servcice.Dtos.Category;
using Store.Service.Dtos.Category;
using Store.Service.Services.Abstractions;

namespace Store.App.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service ;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CategoryPostDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var result = await _service.GetAsync(id);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var result = await _service.DeleteAsync(id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(string id)
        {
            var result = await _service.RemoveAsync(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(CategoryPutDto dto, string id)
        {
            var result = await _service.UpdateAsync(dto, id);
            return Ok(result);
        }
    }
}
