using MinhasContas.Domain.Models;

namespace MinhasContas.Domain.State
{
    public class OpenState : IInvoiceState
    {
        public void CloseInvoice(InvoiceModel invoice) => invoice.StateInvoice = new CloseState();

        public void OpenInvoice(InvoiceModel invoice) { }

        public void PayInvoice(InvoiceModel invoice) { }
    }
}
