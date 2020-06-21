using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppArenaWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppArenaWeb.Controllers
{
    public class FornecedorController : Controller
    {
        [HttpGet]
        [HttpPost]
        public IActionResult Index(FornecedorModel formulario)
        {
            FornecedorModel objCliente = new FornecedorModel();
            ViewBag.ListaFornecedores = objCliente.ListaFornecedores();
            ViewBag.ListaFornecedores = formulario.ListaFornecedores();
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarFornecedor(FornecedorModel formulario)
        {
            if (ModelState.IsValid)
            {
                formulario.Sql_Insert_update();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult CadastrarFornecedor(int? id)
        {
            if (id != null)
            {
                FornecedorModel objFornecedor = new FornecedorModel();
                ViewBag.Registro = objFornecedor.CarregarRegistro(id);
            }
            return View();
        }
    }
}
