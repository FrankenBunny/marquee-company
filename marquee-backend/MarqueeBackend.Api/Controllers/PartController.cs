using AutoMapper;
using dotnetFullstack.DataService.Repositories.Interfaces;
using dotnetFullstack.Entities.Dtos.Response;
using Microsoft.AspNetCore.Mvc;

namespace dotnetFullstack.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PartController : BaseController
{
    public PartController(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork, mapper) { }

    [HttpGet]
    [Route("{rentableid:guid}")]
    public async Task<IActionResult> GetRentableParts(Guid rentableId)
    {
        var rentableParts = await _unitOfWork.Parts.GetRentablePartAsync(rentableId);

        if (rentableParts == null)
            return NotFound("Parts not found.");

        var result = _mapper.Map<RentablePartResponse>(rentableParts);

        return Ok(result);
    }
}
