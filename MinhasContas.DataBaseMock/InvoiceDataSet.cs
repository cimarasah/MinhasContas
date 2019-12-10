using MinhasContas.DataBaseMock;
using System.Collections.Generic;

namespace MinhasContas.WebApi.DataBaseMock
{
    public class InvoiceDataSet : DataBaseMock<Invoice>
    {
       private static List<Invoice> dataSetInvoice;

        public InvoiceDataSet()
            :base(dataSetInvoice)
        {
            this.GetRepository();
        }

        public List<Invoice> GetRepository()
        {
            if (dataSetInvoice == null) dataSetInvoice = new List<Invoice>();

            return dataSetInvoice;
        }
        public Invoice GetInvoiceCurrentByCard(long idCard)
        {
            return dataSetInvoice.Where(inv => inv.Card.Id == idCard && inv.Month == DateTime.Now.Month)
                .FirstOrDefault();
        }
        public Invoice GetInvoice(long idInvoice)
        {
            return dataSetInvoice.Where(inv => inv.Id == idInvoice)
                .FirstOrDefault();
        }

    }
}
