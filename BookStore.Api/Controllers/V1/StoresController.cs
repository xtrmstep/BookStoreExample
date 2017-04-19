using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using BookStore.Api.Models;
using BookStore.Data.Models;
using BookStore.Data.Repositories;

namespace BookStore.Api.Controllers.V1
{
    [RoutePrefix("api/v1/stores")]
    public class StoresController : ApiController
    {
        private readonly IStoreRepository _storeRepository;

        public StoresController(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        [ResponseType(typeof(List<StoreReadModel>))]
        public IHttpActionResult Get()
        {
            var listOfStores = _storeRepository.GetList();
            var stores = Mapper.Map<List<StoreReadModel>>(listOfStores);
            return Ok(stores);
        }

        [Route("{id:guid}")]
        [ResponseType(typeof(StoreReadModel))]
        public IHttpActionResult Get(Guid id)
        {
            var store = _storeRepository.Find(id);
            if (store == null)
                return NotFound();

            var storeViewModel = Mapper.Map<StoreReadModel>(store);
            return Ok(storeViewModel);
        }

        public IHttpActionResult Post([FromBody]StoreCreateModel storeModel)
        {
            var newStore = Mapper.Map<Store>(storeModel);
            var id = _storeRepository.Add(newStore);
            var location = new Uri(Request.RequestUri + "/" + id);
            return Created(location, id);
        }

        public IHttpActionResult Put(int id, [FromBody]StoreUpdateModel storeModel)
        {
            var updatedStore = Mapper.Map<Store>(storeModel);
            _storeRepository.Update(updatedStore);
            return Ok();
        }

        [Route("{id:guid}")]
        public IHttpActionResult Delete(Guid id)
        {
            _storeRepository.Remove(id);
            return Ok();
        }
    }
}