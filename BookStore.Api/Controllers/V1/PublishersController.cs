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
    /// <summary>
    ///     Information abut publishers
    /// </summary>
    public class PublishersController : ApiController
    {
        protected readonly IPublisherRepository _publisherRepository;

        /// <summary>
        ///     constructor
        /// </summary>
        /// <param name="publisherRepository"></param>
        public PublishersController(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        /// <summary>
        ///     Get list of all publishers
        /// </summary>
        /// <returns></returns>
        [ResponseType(typeof (List<PublisherReadModel>))]
        public virtual IHttpActionResult Get()
        {
            var listOfPublishers = _publisherRepository.GetList();
            var publishers = Mapper.Map<List<PublisherReadModel>>(listOfPublishers);
            return Ok(publishers);
        }

        /// <summary>
        ///     Get information about one publisher
        /// </summary>
        /// <param name="id">Publisher's identifier</param>
        /// <returns></returns>
        [ResponseType(typeof (PublisherReadModel))]
        [SwaggerResponse(HttpStatusCode.NotFound, Description = "Not Found")]
        public IHttpActionResult Get(Guid id)
        {
            var publisher = _publisherRepository.Find(id);
            if (publisher == null)
                return NotFound();

            var publisherViewModel = Mapper.Map<PublisherReadModel>(publisher);
            return Ok(publisherViewModel);
        }

        /// <summary>
        ///     Add new publisher
        /// </summary>
        /// <param name="publisherModel">Publisher create model</param>
        /// <returns></returns>
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

        /// <summary>
        ///     Update a publisher
        /// </summary>
        /// <param name="id">Publisher's identifier</param>
        /// <param name="publisherModel">Publisher update model</param>
        /// <returns></returns>
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

        /// <summary>
        ///     Delete a publisher
        /// </summary>
        /// <param name="id">Publisher's identifier</param>
        /// <returns></returns>
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

        /// <summary>
        ///     Get all authors of the publisher
        /// </summary>
        /// <param name="id">Publisher's identifier</param>
        /// <returns></returns>
        [Route("~/api/v1/publishers/{id:guid}/authors")]
        [ResponseType(typeof(List<AuthorReadModel>))]
        public virtual IHttpActionResult GetAuthorsByPublisher(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Get all books of the publisher
        /// </summary>
        /// <param name="id">Publisher's identifier</param>
        /// <returns></returns>
        [Route("~/api/v1/publishers/{id:guid}/books")]
        [ResponseType(typeof(List<BookReadModel>))]
        public virtual IHttpActionResult GetBooksByPublisher(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}