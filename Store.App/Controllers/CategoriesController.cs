using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.App.Context;

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
            var query = _context.Categories.AsQueryable();

        }
    }
}
