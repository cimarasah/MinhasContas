using MinhasContas.Domain.Enuns;
using System;
using System.Collections.Generic;

namespace MinhasContas.DAL.Interface.Entities
{
    public class Invoice : BaseEntity
    {
        public int Month { get; set; }
        public double Value { get; set; }
        public Card Card { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public InvoiceStatus StateInvoice { get; set; }
        public ICollection<InvoiceItem> Itens { get; set; }

    }
}
