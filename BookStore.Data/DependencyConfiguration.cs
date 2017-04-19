using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using BookStore.Data.Repositories;
using BookStore.Data.Repositories.Impl;

namespace BookStore.Data
{
    public class DependencyConfiguration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthorRepository>().As<IAuthorRepository>().InstancePerLifetimeScope();
            builder.RegisterType<BookRepository>().As<IBookRepository>().InstancePerLifetimeScope();
            builder.RegisterType<StoreRepository>().As<IStoreRepository>().InstancePerLifetimeScope();
            builder.RegisterType<PublisherRepository>().As<IPublisherRepository>().InstancePerLifetimeScope();
        }
    }
}
