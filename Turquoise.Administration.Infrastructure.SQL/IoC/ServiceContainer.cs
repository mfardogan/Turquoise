﻿using Autofac;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Turquoise.Administration.Infrastructure.SQL.IoC
{
    using Turquoise.Administration.Domain.Abstraction;
    using Turquoise.Administration.Domain.Aggregation.Administrator;
    using Turquoise.Administration.Infrastructure.SQL.Service;

    public class ServiceContainer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            IConfigurationRoot root = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            builder.Register((System.Func<IComponentContext, Database>)(x =>
            {
                var optsBuilder = new DbContextOptionsBuilder<Database>();
                optsBuilder.UseNpgsql(root.GetConnectionString("TurquoiseLocal"));
                return new Database(optsBuilder.Options);
            })).InstancePerLifetimeScope();

            builder.RegisterType<AdministratorDAO>().As<IAdministratorDAO>().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUoW>().InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}