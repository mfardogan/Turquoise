﻿using Autofac;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MyWallet.Administration.Infrastructure.IoC
{
    using MyWallet.Administration.Domain.Abstraction;
    using MyWallet.Administration.Infrastructure.Multitenancy;
    using MyWallet.Administration.Infrastructure.Persistence;

    public class ServiceContainer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            IConfigurationRoot root = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            builder.Register(x =>
            {
                var optsBuilder = new DbContextOptionsBuilder<MyDbContext>();
                optsBuilder.UseNpgsql(root.GetConnectionString("MyWalletLocal"));
                return new MyDbContext(optsBuilder.Options);
            }).InstancePerLifetimeScope();

            builder.RegisterType<MultitenancyHttpInterceptor>()
                .As<IMultitenancyAccessor>()
                .InstancePerLifetimeScope();

            builder.RegisterType<Transaction>()
                .As<ITransaction>();

            base.Load(builder);
        }
    }
}