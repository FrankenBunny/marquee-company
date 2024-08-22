using AutoMapper;
using MarqueeBackend.DataService.Repositories.Interfaces;
using MarqueeBackend.Entities.DbSet;
using MarqueeBackend.Entities.Dtos.Requests;
using MarqueeBackend.Entities.Dtos.Response;
using Microsoft.AspNetCore.Mvc;

namespace MarqueeBackend.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PartController : BaseController
{
    public PartController(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork, mapper) { }

    [HttpGet]
    [Route("{rentableId:guid}")]
    public async Task<IActionResult> GetRentableParts(Guid rentableId)
    {
        var rentableParts = await _unitOfWork.Parts.GetRentablePartAsync(rentableId);

        if (rentableParts == null)
            return NotFound("Parts not found.");

        var result = _mapper.Map<PartResponse>(rentableParts);

        return Ok(result);
    }

    [HttpPost("")]
    public async Task<IActionResult> AddPart([FromBody] CreatePartRequest part)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var result = _mapper.Map<Part>(part);
        await _unitOfWork.Parts.Add(result);
        await _unitOfWork.CompleteAsync();

        return CreatedAtAction(
            nameof(GetRentableParts),
            new { rentableId = result.RentableId },
            result
        );
    }
}
