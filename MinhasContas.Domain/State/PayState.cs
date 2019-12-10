using MinhasContas.Domain.Models;

namespace MinhasContas.Domain.State
{
    public class PayState : IInvoiceState
    {

        public void CloseInvoice(InvoiceModel invoice) { }

        public void OpenInvoice(InvoiceModel invoice) { }

        public void PayInvoice(InvoiceModel invoice) { }

    }
}
