using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppArenaWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppArenaWeb.Controllers
{
    public class ProdutoController : Controller
    {
        [HttpGet]
        [HttpPost]
        public IActionResult Index(ProdutoModel formulario)
        {         
            ProdutoModel objProduto = new ProdutoModel();
            DepartamentoModel objDepartamento = new DepartamentoModel();
            ViewBag.ListaDepartamentos = objDepartamento.ListaDepartamentos();
            ViewBag.ListaProdutos = objProduto.ListaProdutos();
            ViewBag.ListaProdutos = formulario.ListaProdutos();
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarProdutos(ProdutoModel formulario)
        {
            if (ModelState.IsValid)
            {
                formulario.Sql_Insert_update();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult CadastrarProduto(int? Id)
        {
            if (Id != null)
            {
                ProdutoModel objProduto = new ProdutoModel();
                ViewBag.Registro = objProduto.CarregarRegistro(Id);             
            }
            ViewBag.ListaDepartamentos = new DepartamentoModel().ListaDepartamentos();
            return View();
        }
    }
}
