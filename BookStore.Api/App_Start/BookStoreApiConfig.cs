using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BookStore.Api.Models;
using BookStore.Data.Models;

namespace BookStore.Api.App_Start
{
    public class BookStoreApiConfig
    {
            public static void Register()
            {
                InitMapper();
            }

            internal static void InitMapper()
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<Author, AuthorReadModel>();
                    cfg.CreateMap<Author, AuthorCreateModel>();
                    cfg.CreateMap<Author, AuthorUpdateModel>();
                    cfg.CreateMap<AuthorCreateModel, Author>();
                    cfg.CreateMap<AuthorUpdateModel, Author>();

                    cfg.CreateMap<Book, BookReadModel>();
                    cfg.CreateMap<Book, BookCreateModel>();
                    cfg.CreateMap<Book, BookUpdateModel>();
                    cfg.CreateMap<BookCreateModel, Book>();
                    cfg.CreateMap<BookUpdateModel, Book>();

                    cfg.CreateMap<Store, StoreReadModel>();
                    cfg.CreateMap<Store, StoreCreateModel>();
                    cfg.CreateMap<Store, StoreUpdateModel>();
                    cfg.CreateMap<StoreCreateModel, Store>();
                    cfg.CreateMap<StoreUpdateModel, Store>();

                    cfg.CreateMap<Publisher, PublisherReadModel>();
                    cfg.CreateMap<Publisher, PublisherCreateModel>();
                    cfg.CreateMap<Publisher, PublisherUpdateModel>();
                    cfg.CreateMap<PublisherCreateModel, Publisher>();
                    cfg.CreateMap<PublisherUpdateModel, Publisher>();
                });
            }
        
    }
}