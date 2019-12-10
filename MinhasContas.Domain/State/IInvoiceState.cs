using MinhasContas.Domain.Models;

namespace MinhasContas.Domain.State
{
    public interface IInvoiceState
    {
        void OpenInvoice(InvoiceModel invoice);
        void CloseInvoice(InvoiceModel invoice);
        void PayInvoice(InvoiceModel invoice);
    }
}
