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
    public class PublishersController : ApiController
    {
        protected readonly IPublisherRepository _publisherRepository;

        public PublishersController(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        [ResponseType(typeof (List<PublisherReadModel>))]
        public virtual IHttpActionResult Get()
        {
            var listOfPublishers = _publisherRepository.GetList();
            var publishers = Mapper.Map<List<PublisherReadModel>>(listOfPublishers);
            return Ok(publishers);
        }

        [ResponseType(typeof (PublisherReadModel))]
        public IHttpActionResult Get(Guid id)
        {
            var publisher = _publisherRepository.Find(id);
            if (publisher == null)
                return NotFound();

            var publisherViewModel = Mapper.Map<PublisherReadModel>(publisher);
            return Ok(publisherViewModel);
        }

        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Created", Type = typeof (Guid))]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "BadRequest")]
        public IHttpActionResult Post([FromBody] PublisherCreateModel publisherModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var newPublisher = Mapper.Map<Publisher>(publisherModel);
            var id = _publisherRepository.Add(newPublisher);
            var location = new Uri(Request.RequestUri + "/" + id);
            return Created(location, id);
        }

        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "BadRequest")]
        [SwaggerResponse(HttpStatusCode.NotFound, Description = "Not Found")]
        public IHttpActionResult Put(Guid id, [FromBody] PublisherUpdateModel publisherModel)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();

                var updatedPublisher = Mapper.Map<Publisher>(publisherModel);
                updatedPublisher.Id = id;
                _publisherRepository.Update(updatedPublisher);
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
                _publisherRepository.Remove(id);
                return Ok();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }
    }
}