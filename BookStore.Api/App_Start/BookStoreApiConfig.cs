using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using BookStore.Api.Models;
using BookStore.Data;
using BookStore.Data.Models;

namespace BookStore.Api.App_Start
{
    /// <summary>
    /// Book Store configuration
    /// </summary>
    public class BookStoreApiConfig
    {
        /// <summary>
        /// Register configuration
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();
            builder.RegisterModule<DependencyConfiguration>();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(builder.Build());

            InitMapper();
        }

        internal static void InitMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Author, AuthorReadModel>();
                cfg.CreateMap<Author, AuthorCreateModel>()
                    .ForMember(src => src.Books, opt => opt.Ignore());
                cfg.CreateMap<Author, AuthorUpdateModel>();
                cfg.CreateMap<AuthorCreateModel, Author>()
                    .ForMember(src => src.Books, opt => opt.Ignore());
                cfg.CreateMap<AuthorUpdateModel, Author>();

                cfg.CreateMap<Book, BookReadModel>();
                cfg.CreateMap<Book, BookCreateModel>()
                    .ForMember(src => src.Authors, opt => opt.Ignore());
                cfg.CreateMap<Book, BookUpdateModel>();
                cfg.CreateMap<BookCreateModel, Book>()
                    .ForMember(src => src.Authors, opt => opt.Ignore());
                cfg.CreateMap<BookUpdateModel, Book>();

                cfg.CreateMap<Store, StoreReadModel>();
                cfg.CreateMap<Store, StoreCreateModel>()
                    .ForMember(src => src.Authors, opt => opt.Ignore())
                    .ForMember(src => src.Books, opt => opt.Ignore())
                    .ForMember(src => src.Publishers, opt => opt.Ignore());
                cfg.CreateMap<Store, StoreUpdateModel>();
                cfg.CreateMap<StoreCreateModel, Store>()
                    .ForMember(src => src.Authors, opt => opt.Ignore())
                    .ForMember(src => src.Books, opt => opt.Ignore())
                    .ForMember(src => src.Publishers, opt => opt.Ignore());
                cfg.CreateMap<StoreUpdateModel, Store>();

                cfg.CreateMap<Publisher, PublisherReadModel>();
                cfg.CreateMap<Publisher, PublisherCreateModel>()
                    .ForMember(src => src.Authors, opt => opt.Ignore())
                    .ForMember(src => src.Books, opt => opt.Ignore());
                cfg.CreateMap<Publisher, PublisherUpdateModel>();
                cfg.CreateMap<PublisherCreateModel, Publisher>()
                    .ForMember(src => src.Authors, opt => opt.Ignore())
                    .ForMember(src => src.Books, opt => opt.Ignore());
                cfg.CreateMap<PublisherUpdateModel, Publisher>();

                cfg.CreateMap<LocationAddress, LocationAddressModel>();
                cfg.CreateMap<LocationAddressModel, LocationAddress>();
            });
        }
    }
}