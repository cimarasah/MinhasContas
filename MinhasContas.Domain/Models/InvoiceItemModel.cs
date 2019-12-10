using System;

namespace MinhasContas.Domain.Models
{
    public class InvoiceItemModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public InvoiceModel Invoice { get; set; }
        public double TotalItemValue { get; set; }
        public double InstallmentsValue { get; set; }
        public DateTime BuyDate { get; set; }
        public int Installments { get; set; }
        public int AmountInstallments { get; set; }



    }
}
