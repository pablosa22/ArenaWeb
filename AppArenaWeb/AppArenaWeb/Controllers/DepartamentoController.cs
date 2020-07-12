using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppArenaWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppArenaWeb.Controllers
{
    public class DepartamentoController : Controller
    {
        [HttpGet]
        [HttpPost]
        public IActionResult Index(DepartamentoModel formulario)
        {
            DepartamentoModel objCliente = new DepartamentoModel();
            ViewBag.List = objCliente.ListaDepartamentos();
            ViewBag.ListaDepartamentos = formulario.ListaDepartamentos();
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarDepartamento(DepartamentoModel formulario)
        {
            if (ModelState.IsValid)
            {
                formulario.Sql_Insert_update();
                return RedirectToAction("Index");
            }
            return View();
        }     

        [HttpGet]
        public IActionResult CadastrarDepartamento(int? id)
        {
            if (id != null)
            {
                DepartamentoModel objCliente = new DepartamentoModel();
                ViewBag.Registro = objCliente.CarregarRegistro(id);
            }
            return View();
        }       
    }
}
