using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.OData;
using BookStore.Api.Controllers.V1;
using BookStore.Data.Models;
using BookStore.Data.Repositories;

namespace BookStore.Api.Controllers.V2
{
    public class PublishersController : V1.PublishersController
    {
        public PublishersController(IPublisherRepository publisherRepository) : base(publisherRepository)
        {
        }

        [EnableQuery]
        [ResponseType(typeof(List<Publisher>))]
        public override IHttpActionResult Get()
        {
            return Ok(_publisherRepository.GetQuery());
        }
    }
}