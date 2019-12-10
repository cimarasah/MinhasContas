using MinhasContas.Domain.Enuns;
using MinhasContas.Domain.Extension;
using MinhasContas.Domain.State;
using System;
using System.Collections.Generic;

namespace MinhasContas.Domain.Models
{
    public class InvoiceModel
    {
        public InvoiceModel(CardModel Card)
        {
            this.Card = Card;
            DueDate = InvoiceCardExtension.GetDate(Card.DueDay, (MonthEnum)DateTime.Now.Month);
            StateInvoice = new OpenState();
        }
        public int Id { get; set; }
        public MonthEnum Month { get; set; }
        public double Value { get; set; }
        public CardModel Card { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public IInvoiceState StateInvoice { get; set; }
        public ICollection<InvoiceItemModel> InvoiceItens { get; set; }

        public void OpenInvoice() => this.StateInvoice.OpenInvoice(this);
        public void CloseInvoice() => this.StateInvoice.CloseInvoice(this);
        public void PayInvoice() => this.StateInvoice.PayInvoice(this);

        public int Status { get; set; }
    }
}
