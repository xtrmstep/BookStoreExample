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
    ///     Information about stores
    /// </summary>
    public class StoresController : V1.StoresController
    {
        /// <summary>
        ///     constructor
        /// </summary>
        /// <param name="storeRepository"></param>
        public StoresController(IStoreRepository storeRepository) : base(storeRepository)
        {
        }

        /// <summary>
        ///     Query store data with OData
        /// </summary>
        /// <returns></returns>
        [EnableQuery]
        [ResponseType(typeof (List<Store>))]
        public override IHttpActionResult Get()
        {
            return Ok(_storeRepository.GetQuery());
        }

        /// <summary>
        ///     Get all authors of the publisher
        /// </summary>
        /// <param name="id">Store's identifier</param>
        /// <returns></returns>
        [Route("~/api/v2/stores/{id:guid}/authors")]
        [ResponseType(typeof(List<AuthorReadModel>))]
        public virtual IHttpActionResult GetAuthorsByStore(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Get all books of the publisher
        /// </summary>
        /// <param name="id">Store's identifier</param>
        /// <returns></returns>
        [Route("~/api/v2/stores/{id:guid}/books")]
        [ResponseType(typeof(List<BookReadModel>))]
        public virtual IHttpActionResult GetBooksByStore(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Get all books of the publisher
        /// </summary>
        /// <param name="id">Store's identifier</param>
        /// <returns></returns>
        [Route("~/api/v2/stores/{id:guid}/publishers")]
        [ResponseType(typeof(List<PublisherReadModel>))]
        public virtual IHttpActionResult GetPublishersByStore(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}