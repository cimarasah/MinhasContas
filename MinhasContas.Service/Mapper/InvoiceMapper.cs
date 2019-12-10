using MinhasContas.DAL.Interface.Entities;
using MinhasContas.Domain.Enuns;
using MinhasContas.Domain.Models;
using MinhasContas.Domain.State;
using MinhasContas.Service.Interface.Mapper;
using System.Collections.Generic;
using System.Linq;

namespace MinhasContas.Service.Mapper
{
    public sealed class InvoiceMapper : IMapper<InvoiceModel, Invoice>
    {
        private readonly IMapper<CardModel, Card> mapperCard;

        public InvoiceMapper(IMapper<CardModel, Card> mapperCard)
        {
            this.mapperCard = mapperCard;
        }

        public IEnumerable<Invoice> ListMapToEntity(IEnumerable<InvoiceModel> listModel) =>
            listModel.Select(MapToEntity);
        public IEnumerable<InvoiceModel> ListMapToModel(IEnumerable<Invoice> listEntity) =>
            listEntity.Select(MapToModel);

        public Invoice MapToEntity(InvoiceModel model)
        {
            return new Invoice
            {
                Month = (int)model.Month,
                Value = model.Value,
                Card = mapperCard.MapToEntity(model.Card),                
                DueDate = model.DueDate,
                PaymentDate = model.PaymentDate,
                StateInvoice = MaptoStateEntity(model.StateInvoice),

            };
        }

        public InvoiceModel MapToModel(Invoice entity)
        {
            return new InvoiceModel(mapperCard.MapToModel(entity.Card))
            {
                Month = (MonthEnum)entity.Month,
                Value = entity.Value,
                DueDate = entity.DueDate,
                Card = mapperCard.MapToModel(entity.Card),
                PaymentDate = entity.PaymentDate,
                StateInvoice = MaptoStateModel(entity.StateInvoice),
            };
        }

        private IInvoiceState MaptoStateModel(InvoiceStatus status)
        {
            switch (status)
            {
                case InvoiceStatus.Open: return new OpenState();
                case InvoiceStatus.Close: return new CloseState();
                case InvoiceStatus.Pay: return new PayState();
                default: return null;
            }
        }
        private InvoiceStatus MaptoStateEntity(IInvoiceState status)
        {
            if (status is OpenState) return InvoiceStatus.Open; 
            else if(status is CloseState) return InvoiceStatus.Close; 
            else if (status is PayState) return InvoiceStatus.Pay;
            return InvoiceStatus.Open;
        }
    }
}
