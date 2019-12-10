using MinhasContas.DAL.Interface.Entities;
using MinhasContas.Domain.Models;
using MinhasContas.Service.Interface.Mapper;
using System.Collections.Generic;
using System.Linq;

namespace MinhasContas.Service.Mapper
{
    public sealed class InvoiceItemMapper : IMapper<InvoiceItemModel, InvoiceItem>
    {
        private readonly IMapper<InvoiceModel, Invoice> mapperInvoice;

        public InvoiceItemMapper(IMapper<InvoiceModel, Invoice> mapperInvoice)
        {
            this.mapperInvoice = mapperInvoice;
        }
        public IEnumerable<InvoiceItem> ListMapToEntity(IEnumerable<InvoiceItemModel> listModel) =>
            listModel.Select(MapToEntity);
        public IEnumerable<InvoiceItemModel> ListMapToModel(IEnumerable<InvoiceItem> listEntity) =>
            listEntity.Select(MapToModel);

        public InvoiceItem MapToEntity(InvoiceItemModel model)
        {
            return new InvoiceItem
            {
                Description = model.Description,
                Invoice = mapperInvoice.MapToEntity(model.Invoice),
                TotalItemValue = model.TotalItemValue,
                InstallmentsValue = model.InstallmentsValue,
                BuyDate = model.BuyDate,
                Installments = model.Installments,
                AmountInstallments = model.AmountInstallments
            };
        }

        public InvoiceItemModel MapToModel(InvoiceItem entity)
        {
            return new InvoiceItemModel
            {
                Description = entity.Description,
                Invoice = mapperInvoice.MapToModel(entity.Invoice),
                TotalItemValue = entity.TotalItemValue,
                InstallmentsValue = entity.InstallmentsValue,
                BuyDate = entity.BuyDate,
                Installments = entity.Installments,
                AmountInstallments = entity.AmountInstallments
            };
        }
    }
}
