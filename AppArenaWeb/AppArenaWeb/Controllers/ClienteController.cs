using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppArenaWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppArenaWeb.Controllers
{
    public class ClienteController : Controller
    {
        [HttpGet]
        [HttpPost]
        public IActionResult Index(ClienteModel formulario)
        {
            ClienteModel objCliente = new ClienteModel();
            ViewBag.ListaClientes = objCliente.ListaClientes();
            ViewBag.ListaClientes = formulario.ListaClientes();
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarCliente(ClienteModel formulario) 
        {
            if (ModelState.IsValid)                
            {
                formulario.Sql_Insert_update();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]        
        public IActionResult CadastrarCliente(int? id) 
        {           
            if (id != null)
            {                
                ClienteModel objCliente = new ClienteModel();
                ViewBag.Registro = objCliente.CarregarRegistro(id);                
            }            
            return View();
        }
    }
}