using AutoMapper;
using MarqueeBackend.DataService.Repositories.Interfaces;
using MarqueeBackend.Entities.DbSet;
using MarqueeBackend.Entities.Dtos.Requests;
using Microsoft.AspNetCore.Mvc;

namespace MarqueeBackend.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : BaseController
{
    public CategoryController(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork, mapper) { }

    [HttpGet]
    [Route("{categoryId:guid}")]
    public async Task<IActionResult> GetCategory(Guid categoryId)
    {
        var category = await _unitOfWork.Categories.GetById(categoryId);

        if (category == null)
            return NotFound("Category not found.");

        var result = _mapper.Map<Category>(category);
        return Ok(result);
    }

    [HttpPost("")]
    public async Task<IActionResult> AddCategory([FromBody] CreateCategoryRequest category)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var result = _mapper.Map<Category>(category);
        await _unitOfWork.Categories.Add(result);
        await _unitOfWork.CompleteAsync();

        return CreatedAtAction(nameof(GetCategory), new { categoryId = result.Id }, result);
    }

    [HttpPut("")]
    public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryRequest category)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var result = _mapper.Map<Category>(category);
        await _unitOfWork.Categories.Update(result);
        await _unitOfWork.CompleteAsync();

        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var categories = await _unitOfWork.Categories.All();

        var result = _mapper.Map<IEnumerable<Category>>(categories);
        return Ok(result);
    }

    [HttpDelete]
    [Route("{categoryId}")]
    public async Task<IActionResult> DeleteCategory(Guid categoryId)
    {
        var category = await _unitOfWork.Categories.GetById(categoryId);

        if (category == null)
            return NotFound("Category not found.");

        await _unitOfWork.Categories.Delete(categoryId);
        await _unitOfWork.CompleteAsync();

        return NoContent();
    }
}
