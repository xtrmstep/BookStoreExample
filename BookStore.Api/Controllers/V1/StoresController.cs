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
    public class StoresController : ApiController
    {
        protected readonly IStoreRepository _storeRepository;

        public StoresController(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        [ResponseType(typeof (List<StoreReadModel>))]
        public virtual IHttpActionResult Get()
        {
            var listOfStores = _storeRepository.GetList();
            var stores = Mapper.Map<List<StoreReadModel>>(listOfStores);
            return Ok(stores);
        }

        [ResponseType(typeof (StoreReadModel))]
        public IHttpActionResult Get(Guid id)
        {
            var store = _storeRepository.Find(id);
            if (store == null)
                return NotFound();

            var storeViewModel = Mapper.Map<StoreReadModel>(store);
            return Ok(storeViewModel);
        }

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
    }
}