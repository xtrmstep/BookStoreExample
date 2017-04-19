using BookStore.Api.Controllers.V1;
using BookStore.Data.Repositories;

namespace BookStore.Api.Controllers.V2
{
    public class PublishersV2Controller : PublishersV1Controller
    {
        public PublishersV2Controller(IPublisherRepository publisherRepository) : base(publisherRepository)
        {
        }
    }
}