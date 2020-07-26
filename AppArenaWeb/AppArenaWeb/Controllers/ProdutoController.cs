using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppArenaWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppArenaWeb.Controllers
{
    public class ProdutoController : Controller
    {
        [HttpGet]
        [HttpPost]
        public IActionResult Index(ProdutoModel formulario)
        {         
            ProdutoModel objProduto = new ProdutoModel();
            ViewBag.ListaProdutos = objProduto.ListaProdutos();
            ViewBag.ListaProdutos = formulario.ListaProdutos();            
            
            DepartamentoModel objDepartamento = new DepartamentoModel();
            ViewBag.ListaDepartamentos = objDepartamento.ListaDepartamentos();
            
            FornecedorModel objFornecedor = new FornecedorModel();
            ViewBag.ListaFornecedores = objFornecedor.ListaFornecedores();

            return View();
        }

        [HttpPost]
        public IActionResult CadastrarProduto(ProdutoModel formulario)
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
            ViewBag.ListaFornecedores = new FornecedorModel().ListaFornecedores();
            return View();
        }
    }
}
