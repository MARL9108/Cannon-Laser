using CannonLaser.Domain.Services;
using CannonLaser.Repository.Models;
using CannonLaser.Repository.Response;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CannonLaser.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CannonController : ControllerBase
    {
        private readonly ICannonLoader cannonLoader;

        public CannonController(ICannonLoader cannonLoader)
        {
            this.cannonLoader = cannonLoader;
        }
        /// <summary>
        /// Get deploy cannons lasers
        /// </summary>
        /// <param name="measuredHeights"></param>
        /// <returns></returns>
        [HttpPost(Name = "GetCannonLasers")]
        [ProducesResponseType(typeof(CannonLaserResponse), 200)]
        [ProducesResponseType(typeof(void), 400)]
        public async Task<ActionResult<CannonLaserResponse>> Get([FromBody]MeasuredHeights measuredHeights)
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
