using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppArenaWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppArenaWeb.Controllers
{
    public class AgendaController : Controller
    {
        [HttpGet]
        [HttpPost]
        public IActionResult Index(AgendacModel formulario)
        {            
            AgendacModel objAgenda = new AgendacModel();
            ViewBag.ListaAgendac = objAgenda.ListaAgendac();
            ViewBag.ListaAgendac = formulario.ListaAgendac();

            ClienteModel objCliente = new ClienteModel();
            ViewBag.ListaClientes = objCliente.ListaClientes();
            return View();
        }

        [HttpPost]
        public IActionResult Agendar(AgendacModel formulario) 
        {
            if (ModelState.IsValid)
            {
              //  formulario.Sql_Insert_update();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Agendar(int? Id)
        {
            if (Id != null)
            {
                AgendacModel objAgenda = new AgendacModel();
                ViewBag.Registro = objAgenda.CarregarRegistro(Id);
                ViewBag.ListaAgendai = objAgenda.ListaAgendai(Id);
            }
            else 
            { 
                ViewBag.ListaAgendai = new AgendacModel().ListaAgendai(0);            
            }
            ViewBag.ListaClientes = new ClienteModel().ListaClientes();          
            return View();
        }
    }
}
