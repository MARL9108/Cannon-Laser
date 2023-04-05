using CannonLaser.Domain.Services;
using CannonLaser.Repository.Models;
using CannonLaser.Repository.Response;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Swashbuckle.AspNetCore.Annotations;

namespace CannonLaser.API.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class CannonController : ControllerBase
    {
        private readonly ICannonLoader cannonLoader;

        public CannonController(ICannonLoader cannonLoader)
        {
            this.cannonLoader = cannonLoader;
        }

        /// <summary>
        /// Get deployed cannons lasers
        /// </summary>
        /// <response code="200">Returns a list with the available sample responses.</response>
        [HttpPost("GetCannonLasers")]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse(StatusCodes.Status200OK, Type = typeof(CannonLaserResponse))]
        [Swashbuckle.AspNetCore.Annotations.SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CannonLaserResponse>> GetCannonLasers([FromBody]MeasuredHeights measuredHeights)
        {
            CannonLaserResponse cannonLaser = new CannonLaserResponse();
            var validator = new Validator<MeasuredHeights>();

            cannonLaser.Message = validator.ValidateRequest(measuredHeights);
            if (!String.IsNullOrEmpty(cannonLaser.Message)) return BadRequest(cannonLaser.Message);

            cannonLaser.Cannons = cannonLoader.GetCannonCount(measuredHeights);
            return cannonLaser;
        }
    }
}
