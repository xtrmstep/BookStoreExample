using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.OData;
using BookStore.Api.Models;
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

        /// <summary>
        ///     Get all authors of the publisher
        /// </summary>
        /// <param name="id">Publisher's identifier</param>
        /// <returns></returns>
        [Route("~/api/v2/publishers/{id:guid}/authors")]
        [ResponseType(typeof(List<AuthorReadModel>))]
        public virtual IHttpActionResult GetAuthorsByPublisher(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Get all books of the publisher
        /// </summary>
        /// <param name="id">Publisher's identifier</param>
        /// <returns></returns>
        [Route("~/api/v2/publishers/{id:guid}/books")]
        [ResponseType(typeof(List<BookReadModel>))]
        public virtual IHttpActionResult GetBooksByPublisher(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}