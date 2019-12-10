using Microsoft.AspNetCore.Mvc;

namespace MinhasContas.WebApi.Controllers
{
    [Route("api/invoice")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
       // IInvoiceFacade facade = new InvoiceFacade();
       // // GET api/invoice
       // //[HttpGet]
       // //public ActionResult<IEnumerable<InvoiceModel>> Get() =>
       // //    facade.GetCurrentInvoices();


       //// GET api/invoice/5
       // [HttpGet("getInvoice/{idInvoice}")]
       // public ActionResult<InvoiceModel> Get(int idInvoice) =>
       //      facade.GetInvoice(idInvoice);


       // // POST api/invoice
       // [HttpPost]
       // public void Post([FromBody] InvoiceModel invoice) =>
       //     facade.InsertInvoice(invoice);

       // [HttpGet("getInvoice/{idInvoice}")]
       // public ActionResult<InvoiceModel> PayInvoice(int idInvoice) =>
       //      facade.Get(idInvoice);

       // //// DELETE api/invoice/5
       // //[HttpDelete("{id}")]
       // //public void Delete(int id) =>
       // //    facade.DeleteInvoice(id);
    }
}
