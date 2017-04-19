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
    [RoutePrefix("api/v1/publishers")]
    public class PublishersController : ApiController
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublishersController(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        [ResponseType(typeof(List<PublisherReadModel>))]
        public IHttpActionResult Get()
        {
            var listOfPublishers = _publisherRepository.GetList();
            var publishers = Mapper.Map<List<PublisherReadModel>>(listOfPublishers);
            return Ok(publishers);
        }

        [Route("{id:guid}")]
        [ResponseType(typeof(PublisherReadModel))]
        public IHttpActionResult Get(Guid id)
        {
            var publisher = _publisherRepository.Find(id);
            if (publisher == null)
                return NotFound();

            var publisherViewModel = Mapper.Map<PublisherReadModel>(publisher);
            return Ok(publisherViewModel);
        }

        public IHttpActionResult Post([FromBody]PublisherCreateModel publisherModel)
        {
            var newPublisher = Mapper.Map<Publisher>(publisherModel);
            var id = _publisherRepository.Add(newPublisher);
            var location = new Uri(Request.RequestUri + "/" + id);
            return Created(location, id);
        }

        public IHttpActionResult Put(int id, [FromBody]PublisherUpdateModel publisherModel)
        {
            var updatedPublisher = Mapper.Map<Publisher>(publisherModel);
            _publisherRepository.Update(updatedPublisher);
            return Ok();
        }

        [Route("{id:guid}")]
        public IHttpActionResult Delete(Guid id)
        {
            _publisherRepository.Remove(id);
            return Ok();
        }
    }
}