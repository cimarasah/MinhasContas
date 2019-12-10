
using Microsoft.Extensions.DependencyInjection;
using MinhasContas.DAL.Interface.Entities;
using MinhasContas.Domain.Models;
using MinhasContas.Service.Interface.Mapper;
using MinhasContas.Service.Mapper;

namespace MinhasContas.IoC
{
    public static class DependencyInjector
    {
        public static void Register(IServiceCollection service)
        {
            RegisterMapper(service);
        }
        public static void RegisterMapper(IServiceCollection service)
        {
            service.AddScoped<IMapper<CardModel, Card>, CardMapper>();
            service.AddScoped<IMapper<InvoiceModel, Invoice>, InvoiceMapper>();
            service.AddScoped<IMapper<InvoiceItemModel, InvoiceItem>, InvoiceItemMapper>();
        }
    }
}
