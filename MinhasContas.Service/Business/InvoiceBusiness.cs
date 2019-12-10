using MinhasContas.Domain.Models;
using MinhasContas.Service.Interface.Business;
using MinhasContas.Service.Mapper;

namespace MinhasContas.Service.Business
{
    public class InvoiceBusiness : IInvoiceBusiness
    {
        //InvoiceDataSet repo;
        
        //public InvoiceBusiness()
        //{
        //    repo.GetRepository();   
        //}

        //public InvoiceModel GetInvoice(long IdInvoice)
        //{
        //    return InvoiceMapper.GetInstance().MapToModel(repo.GetInvoice(IdInvoice));
        //}

        //public bool InsertInvoice(InvoiceModel Invoice)
        //{
        //    return repo.Insert(InvoiceMapper.GetInstance().MapToEntity(Invoice));
        //}

        //public void PayInvoice(long IdCard, double value)
        //{
        //    var invoice = InvoiceMapper.GetInstance().MapToModel(repo.GetInvoiceCurrentByCard(IdCard));
        //    if (invoice.Value == value)
        //    {
        //        invoice.StateInvoice.PayInvoice(invoice);
        //    }
        //    else
        //    {
        //        invoice.Value = invoice.Value - value;
        //    }
        //    repo.Update(InvoiceMapper.GetInstance().MapToEntity(invoice));
        //}

        
    }
}
