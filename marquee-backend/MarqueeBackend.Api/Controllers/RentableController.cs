using AutoMapper;
using dotnetFullstack.DataService.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace dotnetFullstack.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
class RentableController : BaseController
{
    public RentableController(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork, mapper) { }
}
