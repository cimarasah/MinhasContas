using System;

namespace MinhasContas.DAL.Interface.Entities
{
    public class InvoiceItem : BaseEntity
    {
        public string Description { get; set; }
        public Invoice Invoice { get; set; }
        public double TotalItemValue { get; set; }
        public double InstallmentsValue { get; set; }
        public DateTime BuyDate { get; set; }
        public int Installments { get; set; }
        public int AmountInstallments { get; set; }
    }
}
