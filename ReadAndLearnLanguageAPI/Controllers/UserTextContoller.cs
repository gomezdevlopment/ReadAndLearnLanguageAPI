using Microsoft.AspNetCore.Mvc;
using ReadAndLearnLanguageAPI.Interfaces;
using ReadAndLearnLanguageAPI.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReadAndLearnLanguageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTextController : ControllerBase
    {
        private readonly IUserTextRepository _repository;

        public UserTextController(IUserTextRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserText>))]
        public async Task<ActionResult<IEnumerable<UserText>>> GetAllTexts(int userId)
        {
            var userTexts = _repository.GetAllTexts(userId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await userTexts);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateText(UserText userText)
        {
            if (userText == null)
                return BadRequest(ModelState);

            if (!await _repository.CreateText(userText))
            {
                return StatusCode(500, ModelState);
            }
            return Ok();
        }

        [HttpDelete("{textId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteText(int textId)
        {
            if (!await _repository.DeleteText(textId))
            {
                return StatusCode(500, ModelState);
            }
            return Ok();
        }
    }
}