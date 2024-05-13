using Microsoft.AspNetCore.Mvc;
using WebApp.DTO;
using WebApp.Services;

namespace WebApp.ApiControllers;

[Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
[ApiController]
public class JourneyController(JourneyService journeyService) : ControllerBase
{
    
    
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<Journey>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Journey>>> GetJourneys([FromQuery] JourneySearchParams journeySearchParams)
    {
        var temp = journeyService.GetJourneys(journeySearchParams);
        return temp;
    }
}