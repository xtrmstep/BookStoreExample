using BookStore.Api.Controllers.V1;
using BookStore.Data.Repositories;

namespace BookStore.Api.Controllers.V2
{
    public class StoresV2Controller : StoresV1Controller
    {
        public StoresV2Controller(IStoreRepository storeRepository) : base(storeRepository)
        {
        }
    }
}