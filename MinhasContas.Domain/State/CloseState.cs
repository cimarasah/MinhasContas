using System;
using MinhasContas.Domain.Models;


namespace MinhasContas.Domain.State
{
    public class CloseState : IInvoiceState
    {
        public void CloseInvoice(InvoiceModel invoice) { }

        public void OpenInvoice(InvoiceModel invoice) { invoice.Status = 4; }

        public void PayInvoice(InvoiceModel invoice)
        {
            invoice.PaymentDate = new DateTime();
            invoice.StateInvoice = new PayState();
        }
    }
}
