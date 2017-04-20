using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.OData;
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
    }
}