using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using BookStore.Api.Controllers.V1;
using BookStore.Api.Models;
using BookStore.Data.Models;
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