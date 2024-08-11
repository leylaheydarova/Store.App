using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.App.Context;
using Store.App.Dtos.Category;
using Store.App.Models;

namespace Store.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(StoreDbContext context, IMapper mapper) : ControllerBase
    {
        private readonly StoreDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var query = _context.Categories.Where(x => !x.isDeleted).AsQueryable();
            List<CategoryGetDto> dtos = new List<CategoryGetDto>();
            dtos = await query.Select(x => new CategoryGetDto { Name = x.Name, Id = x.Id.ToString() }).ToListAsync();
            return StatusCode(200);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CategoryPostDto dto)
        {
            if (await _context.Categories.AnyAsync(x => x.Name == dto.Name))
            {
                return StatusCode(400, new { desc = $"{dto.Name} already exists!" });
            }
            if (!ModelState.IsValid)
            {
                return StatusCode(400, new { desc = "Not Valid Input" });
            }
            Category category = _mapper.Map<Category>(dto);
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            Category? category = await _context.Categories.FirstOrDefaultAsync(x => x.Id.ToString() == id && !x.isDeleted);
            if (category == null)
            {
                return StatusCode(404, new { desc = "Not Found!" });
            }
            CategoryGetDto dt0 = _mapper.Map<CategoryGetDto>(category);
            return StatusCode(200);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(string id, [FromBody]CategoryPutDto dto)
        {
            if (await _context.Categories.AnyAsync(x => x.Name == dto.Name && x.Id.ToString() == id))
            {
                return StatusCode(400, new { desc = "No changes" });
            }

            if (await _context.Categories.AnyAsync(x=>x.Name == dto.Name))
            {
                return StatusCode(400, new { desc = $"{dto.Name} already exists" });
            }
            
            Category category = await _context.Categories.FirstOrDefaultAsync(x => x.Id.ToString() == id && !x.isDeleted );
            if (category == null)
            {
                return StatusCode(404);
            }
            category.Name = dto.Name;
            await _context.SaveChangesAsync();
            return StatusCode(200);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(string id)
        {
            Category category = await _context.Categories.FirstOrDefaultAsync(x => x.Id.ToString() == id && !x.isDeleted);
            if (category == null)
            {
                return StatusCode(404);
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return StatusCode(200, new { desc = "Deleted successfully!"});

        }
    }
}
