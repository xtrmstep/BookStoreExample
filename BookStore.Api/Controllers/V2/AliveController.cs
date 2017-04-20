using System.Web.Http;

namespace BookStore.Api.Controllers.V2
{
    /// <summary>
    ///     Root endpoint
    /// </summary>
    public class AliveController : ApiController
    {
        /// <summary>
        ///     Information about API
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            return Ok("Book Store Inventory API V2");
        }
    }
}