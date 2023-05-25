using Microsoft.AspNetCore.Mvc;
using companyData;
using company.Models;

namespace company.Controllers
{
    public class ClientController : Controller
    {
        ClientDTO? clientDTO;
        ClientCtx? clientCtx;

        [HttpGet]
        [HttpPost]
        public IActionResult Register(ClientModel viewDataClient)
        {
            if (ModelState.IsValid)
            {
                clientCtx = new ClientCtx();
                clientDTO = new ClientDTO();
                clientDTO.Sin = viewDataClient.Sin;
                clientDTO.Name = viewDataClient.Name;
                clientDTO.Age = viewDataClient.Age;

                clientCtx.insertClientData(clientDTO);

                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
