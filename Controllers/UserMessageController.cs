using Microsoft.AspNetCore.Mvc;
using SignalRChat.Data.Repositories;
using SignalRChat.Models;
using SignalRChat.Models.InputModels;

namespace SignalRChat.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class UserMessageController : ControllerBase
    {
        private IUserMessageRepository _userMessageRepository;

        public UserMessageController(IUserMessageRepository userMessageRepository)
        {
            _userMessageRepository = userMessageRepository;
        }

        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            var response = _userMessageRepository.GetAll();
            return Ok(response);
        }

         [HttpGet("{id}")]        
        public IActionResult Get(Guid id)
        {         
            var response = _userMessageRepository.Get(id);
            if(response is null)
                return NotFound();

            return Ok(response);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] UserMessageDTO userMessage)
        {
            try{
                var newUser = new UserMessage(userMessage.Name);

                _userMessageRepository.Create(newUser);
                return Created("", newUser);
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }            
        }

        [HttpPut("{id}")]        
        public IActionResult Update(Guid id, [FromBody] UserMessageDTO userMessage)
        {
            try{
                var user = _userMessageRepository.Get(id);
                if(user is null)
                    return NotFound();

                user.Update(userMessage.Name);

                _userMessageRepository.Update(id, user);
                return Ok(user);
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }            
        }

         [HttpDelete("{id}")]        
        public IActionResult Delete(Guid id)
        {
            try{
                var user = _userMessageRepository.Get(id);
                if(user is null)
                    return NotFound();

                user.Delete();

                _userMessageRepository.Update(id, user);
                return Ok(user);
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }            
        }

        [HttpGet]
        [Route("hello")]
        public IActionResult Hello()
        {
            return Ok("Hello Word!");
        }
    }
}