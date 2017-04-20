using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.OData;
using BookStore.Data.Models;
using BookStore.Data.Repositories;

namespace BookStore.Api.Controllers.V2
{
    /// <summary>
    ///     Information about publishers
    /// </summary>
    public class PublishersController : V1.PublishersController
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="publisherRepository"></param>
        public PublishersController(IPublisherRepository publisherRepository) : base(publisherRepository)
        {
        }

        /// <summary>
        ///     Query publisher data with OData
        /// </summary>
        /// <returns></returns>
        [EnableQuery]
        [ResponseType(typeof (List<Publisher>))]
        public override IHttpActionResult Get()
        {
            return Ok(_publisherRepository.GetQuery());
        }
    }
}