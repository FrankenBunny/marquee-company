using AutoMapper;
using MarqueeBackend.DataService.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MarqueeBackend.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    protected readonly IUnitOfWork _unitOfWork;
    protected readonly IMapper _mapper;

    public BaseController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
}
