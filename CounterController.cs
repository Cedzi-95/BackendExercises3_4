using Microsoft.AspNetCore.Mvc;
namespace CounterApp.Controllers
{
  

    [ApiController]
    [Route("api/[controller]")]
    public class CounterController : ControllerBase
    {
        private readonly CounterService _counterService;

        //inject service through the constructor
        public CounterController(CounterService counterService)
        {
            _counterService = counterService;
        }

        [HttpGet]
        public IActionResult GetCount()
        {
            int currentCount = _counterService.Increment();
            return Ok( new { 
                message = $"This request has been sent {currentCount} times.", 
                count = currentCount
                
            });
        }

    }



}

 