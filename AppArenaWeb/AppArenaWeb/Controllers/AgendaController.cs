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
            AgendacModel objAgendac = new AgendacModel();
            ViewBag.ListaAgendac = objAgendac.ListaAgendac();
            ViewBag.ListaAgendac = formulario.ListaAgendac();
            return View();
        }
    }
}
