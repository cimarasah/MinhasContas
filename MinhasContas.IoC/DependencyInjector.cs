
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MinhasContas.DAL.Data;
using MinhasContas.DAL.Interface.Entities;
using MinhasContas.DAL.Interface.Services;
using MinhasContas.DAL.Interface.UnitOfWork;
using MinhasContas.DAL.UnitOfWork;
using MinhasContas.Domain.Models;
using MinhasContas.Service.Interface.Mapper;
using MinhasContas.Service.Mapper;
using System;

namespace MinhasContas.IoC
{
    public static class DependencyInjector
    {
        public static void Register(IServiceCollection service)
        {
            RegisterUnitOfWork(service);
            RegisterMapper(service);
        }
        public static void RegisterMapper(IServiceCollection service)
        {
            service.AddScoped<IMapper<CardModel, Card>, CardMapper>();
            service.AddScoped<IMapper<InvoiceModel, Invoice>, InvoiceMapper>();
            service.AddScoped<IMapper<InvoiceItemModel, InvoiceItem>, InvoiceItemMapper>();
        }
        private static void RegisterUnitOfWork(IServiceCollection services) =>
           services.TryAddScoped<IUnitOfWork, ExtensibleUnitOfWork<DataContext, IApplicationContextService>>();
    }
}
