using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadAndLearnLanguageAPI.Interfaces;
using ReadAndLearnLanguageAPI.Model;

namespace ReadAndLearnLanguageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserWordController : ControllerBase
    {
        private readonly IRepository _repository;

        public UserWordController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserWord>))]
        public async Task<ActionResult<IEnumerable<UserWord>>> GetUserWords(int userId)
        {
            var userWords = _repository.GetAll<UserWord>(userId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await userWords);
        }
    }
}