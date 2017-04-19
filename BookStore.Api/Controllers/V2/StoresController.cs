using BookStore.Api.Controllers.V1;
using BookStore.Data.Repositories;

namespace BookStore.Api.Controllers.V2
{
    public class StoresController : V1.StoresController
    {
        public StoresController(IStoreRepository storeRepository) : base(storeRepository)
        {
        }
    }
}