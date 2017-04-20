using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using BookStore.Api.Models;
using BookStore.Data.Models;
using BookStore.Data.Repositories;
using Swashbuckle.Swagger.Annotations;

namespace BookStore.Api.Controllers.V1
{
    /// <summary>
    ///     Information about stores
    /// </summary>
    public class StoresController : ApiController
    {
        protected readonly IStoreRepository _storeRepository;

        /// <summary>
        ///     constructor
        /// </summary>
        /// <param name="storeRepository"></param>
        public StoresController(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        /// <summary>
        ///     Get list of all stores
        /// </summary>
        /// <returns></returns>
        [ResponseType(typeof (List<StoreReadModel>))]
        public virtual IHttpActionResult Get()
        {
            var listOfStores = _storeRepository.GetList();
            var stores = Mapper.Map<List<StoreReadModel>>(listOfStores);
            return Ok(stores);
        }

        /// <summary>
        ///     Get information about one store
        /// </summary>
        /// <param name="id">Store's identifier</param>
        /// <returns></returns>
        [ResponseType(typeof (StoreReadModel))]
        [SwaggerResponse(HttpStatusCode.NotFound, Description = "Not Found")]
        public IHttpActionResult Get(Guid id)
        {
            var store = _storeRepository.Find(id);
            if (store == null)
                return NotFound();

            var storeViewModel = Mapper.Map<StoreReadModel>(store);
            return Ok(storeViewModel);
        }

        /// <summary>
        ///     Add new store
        /// </summary>
        /// <param name="storeModel">Store create model</param>
        /// <returns></returns>
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Created", Type = typeof (Guid))]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "BadRequest")]
        public IHttpActionResult Post([FromBody] StoreCreateModel storeModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var newStore = Mapper.Map<Store>(storeModel);
            var id = _storeRepository.Add(newStore);
            var location = new Uri(Request.RequestUri + "/" + id);
            return Created(location, id);
        }

        /// <summary>
        ///     Update a store
        /// </summary>
        /// <param name="id">Store's identifier</param>
        /// <param name="storeModel">Store update model</param>
        /// <returns></returns>
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "BadRequest")]
        [SwaggerResponse(HttpStatusCode.NotFound, Description = "Not Found")]
        public IHttpActionResult Put(Guid id, [FromBody] StoreUpdateModel storeModel)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();

                var updatedStore = Mapper.Map<Store>(storeModel);
                updatedStore.Id = id;
                _storeRepository.Update(updatedStore);
                return Ok();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        /// <summary>
        ///     Delete a store
        /// </summary>
        /// <param name="id">Store's identifier</param>
        /// <returns></returns>
        [SwaggerResponse(HttpStatusCode.NotFound, Description = "Not Found")]
        public IHttpActionResult Delete(Guid id)
        {
            try
            {
                _storeRepository.Remove(id);
                return Ok();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        /// <summary>
        ///     Get all authors of the publisher
        /// </summary>
        /// <param name="id">Store's identifier</param>
        /// <returns></returns>
        [Route("~/api/v1/stores/{id:guid}/authors")]
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
        [Route("~/api/v1/stores/{id:guid}/books")]
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
        [Route("~/api/v1/stores/{id:guid}/publishers")]
        [ResponseType(typeof(List<PublisherReadModel>))]
        public virtual IHttpActionResult GetPublishersByStore(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}