using BookStore.Api.Controllers.V1;
using BookStore.Data.Repositories;

namespace BookStore.Api.Controllers.V2
{
    public class PublishersController : V1.PublishersController
    {
        public PublishersController(IPublisherRepository publisherRepository) : base(publisherRepository)
        {
        }
    }
}