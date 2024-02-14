using Microsoft.AspNetCore.Mvc;

namespace WebSocket_SignalR.Controllers
{
    [ApiController, Route("api/[controller]/[action]")]
    public class WSController : ControllerBase
    {
        public WSController() { }

        [HttpGet]
        public async Task<IActionResult> StartWS()
        {
            return Ok(0);
        }
    }
}
