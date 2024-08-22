using AutoMapper;
using MarqueeBackend.DataService.Repositories.Interfaces;
using MarqueeBackend.Entities.DbSet;
using MarqueeBackend.Entities.Dtos.Requests;
using MarqueeBackend.Entities.Dtos.Response;
using Microsoft.AspNetCore.Mvc;

namespace MarqueeBackend.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RentableController : BaseController
{
    public RentableController(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork, mapper) { }

    [HttpGet]
    [Route("category/{categoryId:guid}")]
    public async Task<IActionResult> GetCategoryRentable(Guid categoryId)
    {
        var categoryParts = await _unitOfWork.Rentables.GetCategoryRentablesAsync(categoryId);

        if (categoryParts == null)
            return NotFound("Rentables not found.");

        var result = _mapper.Map<CategoryResponse>(categoryParts);

        return Ok(result);
    }

    [HttpGet]
    [Route("{rentableId:guid}")]
    public async Task<IActionResult> GetRentable(Guid rentableId)
    {
        var rentable = await _unitOfWork.Rentables.GetById(rentableId);

        if (rentable == null)
            NotFound("Rentable not found.");

        var result = _mapper.Map<RentableResponse>(rentable);

        return Ok(result);
    }

    [HttpPost("")]
    public async Task<IActionResult> AddRentable([FromBody] CreateRentableRequest rentable)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var result = _mapper.Map<Rentable>(rentable);
        await _unitOfWork.Rentables.Add(result);
        await _unitOfWork.CompleteAsync();
        return CreatedAtAction(nameof(GetRentable), new { rentableId = result.Id }, result);
    }

    [HttpPut("{rentableId:guid}")]
    public async Task<IActionResult> UpdateRentable([FromBody] UpdateRentableRequest rentable)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var result = _mapper.Map<Rentable>(rentable);

        await _unitOfWork.Rentables.Update(result);
        await _unitOfWork.CompleteAsync();

        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRentables()
    {
        var rentables = await _unitOfWork.Rentables.All();

        var result = _mapper.Map<IEnumerable<RentableResponse>>(rentables);

        return Ok(result);
    }

    [HttpDelete("{rentableId:guid}")]
    public async Task<IActionResult> DeleteRentable(Guid rentableId)
    {
        var rentable = await _unitOfWork.Rentables.GetById(rentableId);

        if (rentable == null)
            return NotFound("Rentable not found.");

        await _unitOfWork.Rentables.Delete(rentableId);
        await _unitOfWork.CompleteAsync();

        return NoContent();
    }
}
