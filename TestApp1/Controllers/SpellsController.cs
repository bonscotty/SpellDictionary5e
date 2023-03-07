using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestApp1.Data;

namespace TestApp1.Controllers
{
    [ServiceFilter(typeof(TestAsyncActionFilter))]
    [Route("api/v1/[controller]")]
    [ApiController]

    public class SpellsController : ControllerBase
    {
        private readonly ISpellRepo _repo;
        private readonly IMapper _mapper;
    }

}
