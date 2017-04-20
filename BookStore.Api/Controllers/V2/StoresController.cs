using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.OData;
using BookStore.Api.Controllers.V1;
using BookStore.Data.Models;
using BookStore.Data.Repositories;

namespace BookStore.Api.Controllers.V2
{
    public class StoresController : V1.StoresController
    {
        public StoresController(IStoreRepository storeRepository) : base(storeRepository)
        {
        }

        [EnableQuery]
        [ResponseType(typeof(List<Store>))]
        public override IHttpActionResult Get()
        {
            return Ok(_storeRepository.GetQuery());
        }
    }
}