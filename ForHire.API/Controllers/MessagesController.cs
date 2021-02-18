using AutoMapper;
using ForHire.API.Data;
using ForHire.API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ForHire.API.Controllers
{

    [ServiceFilter(typeof(LogUserActivity))]
    // [Authorize]
    [Route("api/users/{userId}/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IDataRepository _repo;
        private readonly IMapper _mapper;
        public MessagesController(IDataRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

    }
}