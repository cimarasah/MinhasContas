using AutoMapper;
using MinhasContas.DAL.Interface.Entities;
using MinhasContas.DAL.Interface.UnitOfWork;
using MinhasContas.Domain.Models;
using MinhasContas.Service.Interface.Business;
using MinhasContas.Service.Interface.Mapper;
using MinhasContas.Service.Mapper;

namespace MinhasContas.Service.Business
{
    public class InvoiceBusiness : BaseBusiness<Invoice, InvoiceModel>,IInvoiceBusiness
    {
        public InvoiceBusiness(
            IUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        {}

        //public InvoiceModel GetInvoice(long IdInvoice)
        //{
        //    return mapper.Map<InvoiceModel>(repo.GetInvoice(IdInvoice));
        //}

        //public bool InsertInvoice(InvoiceModel Invoice)
        //{
        //    return repo.Insert(mapperInvoice.MapToEntity(Invoice));
        //}

        //public void PayInvoice(long IdCard, double value)
        //{
        //    var invoice = mapperInvoice.MapToModel(repo.GetInvoiceCurrentByCard(IdCard));
        //    if (invoice.Value == value)
        //    {
        //        invoice.StateInvoice.PayInvoice(invoice);
        //    }
        //    else
        //    {
        //        invoice.Value = invoice.Value - value;
        //    }
        //    repo.Update(mapperInvoice.MapToEntity(invoice));
        //}


    }
}
