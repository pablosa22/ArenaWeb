using AppArenaWeb.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AppArenaWeb.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }
        [StringLength(199, MinimumLength = 3)]
        [Required(ErrorMessage = "Informe a Descrição do produto com tamanho maior que 3 e menor que 200!")]
        public string Descricao { get; set; }
        [StringLength(20, MinimumLength = 3)]
        [Required(ErrorMessage = "Informe a Dimenção maior que 3 e menor que 20!")]
        public string Dimensao { get; set; }
        public int IdadeMaxima { get; set; }
        [Range(1, 1000)]
        [Required(ErrorMessage = "Informe o Departamento")]
        public int Id_Departamento { get; set; }
        [Range(1, 1000)]        
        [Required(ErrorMessage = "Informe o Fornecedor")]
        public int Id_Fornecedor { get; set; }
        public string Status { get; set; }        
        public string Obs { get; set; }

        public ProdutoModel() 
        { 

        }

        public List<ProdutoModel> ListaProdutos() 
        {
            List<ProdutoModel> produtos = new List<ProdutoModel>();
            ProdutoModel item;
            string sql = "";


            if (Descricao != null && Id == 0 && Id_Departamento == 0)// Pesquisar por descricao
            {
                sql = $"SELECT ID, DESCRICAO, DIMENSAO, IDADE_MAXIMA, ID_DEPARTAMENTO, ID_FORNECEDOR, STATUS, OBS FROM PRODUTO WHERE DESCRICAO LIKE '%{Descricao}%' ORDER BY DESCRICAO ASC";
            }
            else if (Descricao == null && Id != 0 && Id_Departamento == 0)// Pesquisar pelo codigo
            {
                sql = $"SELECT ID, DESCRICAO, DIMENSAO, IDADE_MAXIMA, ID_DEPARTAMENTO, ID_FORNECEDOR, STATUS, OBS FROM PRODUTO WHERE ID = '{Id}' ORDER BY DESCRICAO ASC";
            }
            else if (Descricao != null && Id != 0 && Id_Departamento == 0)
            {
                sql = $"SELECT ID, DESCRICAO, DIMENSAO, IDADE_MAXIMA, ID_DEPARTAMENTO, ID_FORNECEDOR, STATUS, OBS FROM PRODUTO WHERE ID = '{Id}' ORDER BY DESCRICAO ASC";
            }
            else if (Id_Departamento != 0 && Descricao != null && Id == 0)
            {
                sql = $"SELECT ID, DESCRICAO, DIMENSAO, IDADE_MAXIMA, ID_DEPARTAMENTO, ID_FORNECEDOR, STATUS, OBS FROM PRODUTO WHERE DESCRICAO LIKE '%{Descricao}%' AND ID_DEPARTAMENTO = '{Id_Departamento}' ORDER BY DESCRICAO ASC";
            }
            else if (Id_Departamento != 0 && Descricao == null && Id != 0)
            {
                sql = $"SELECT ID, DESCRICAO, DIMENSAO, IDADE_MAXIMA, ID_DEPARTAMENTO, ID_FORNECEDOR, STATUS, OBS FROM PRODUTO WHERE ID = '{Id}' AND ID_DEPARTAMENTO = '{Id_Departamento}' ORDER BY DESCRICAO ASC";
            }
            else if (Id_Departamento != 0 && Descricao == null && Id == 0) 
            {
                sql = $"SELECT ID, DESCRICAO, DIMENSAO, IDADE_MAXIMA, ID_DEPARTAMENTO, ID_FORNECEDOR, STATUS, OBS FROM PRODUTO WHERE ID_DEPARTAMENTO = '{Id_Departamento}' ORDER BY DESCRICAO ASC";
            }
            else if (Id_Departamento != 0 && Descricao != null && Id != 0)
            {
                sql = $"SELECT ID, DESCRICAO, DIMENSAO, IDADE_MAXIMA, ID_DEPARTAMENTO, ID_FORNECEDOR, STATUS, OBS FROM PRODUTO WHERE ID_DEPARTAMENTO = '{Id_Departamento}' AND ID = '{Id}' AND DESCRICAO LIKE '%{Descricao}%'  ORDER BY DESCRICAO ASC";
            }
            else
            {
                sql = $"SELECT ID, DESCRICAO, DIMENSAO, IDADE_MAXIMA, ID_DEPARTAMENTO, ID_FORNECEDOR, STATUS, OBS FROM PRODUTO WHERE DESCRICAO LIKE '%{Descricao}%' ORDER BY DESCRICAO ASC";
            }

            DAL objDal = new DAL();
            DataTable dt = objDal.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ProdutoModel();
                item.Id = int.Parse(dt.Rows[i]["ID"].ToString());
                item.Descricao = dt.Rows[i]["DESCRICAO"].ToString();
                item.Dimensao = dt.Rows[i]["DIMENSAO"].ToString();
                item.IdadeMaxima = int.Parse(dt.Rows[i]["IDADE_MAXIMA"].ToString());
                item.Id_Departamento = int.Parse(dt.Rows[i]["ID_DEPARTAMENTO"].ToString());
                item.Id_Fornecedor = int.Parse(dt.Rows[i]["ID_FORNECEDOR"].ToString());
                item.Status = dt.Rows[i]["STATUS"].ToString();
                item.Obs = dt.Rows[i]["OBS"].ToString();                
                produtos.Add(item);
            }
            return produtos;
        }

        public ProdutoModel CarregarRegistro(int? Id) 
        {
            ProdutoModel item = new ProdutoModel();
            string sql = $"SELECT ID, DESCRICAO, DIMENSAO, IDADE_MAXIMA, ID_DEPARTAMENTO, ID_FORNECEDOR, STATUS, OBS FROM PRODUTO WHERE ID = '{Id}' ORDER BY DESCRICAO ASC";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            item = new ProdutoModel();
            item.Id = int.Parse(dt.Rows[0]["ID"].ToString());
            item.Descricao = dt.Rows[0]["DESCRICAO"].ToString();
            item.Dimensao = dt.Rows[0]["DIMENSAO"].ToString();
            item.IdadeMaxima = int.Parse(dt.Rows[0]["IDADE_MAXIMA"].ToString());
            item.Id_Departamento = int.Parse(dt.Rows[0]["ID_DEPARTAMENTO"].ToString());
            item.Id_Fornecedor = int.Parse(dt.Rows[0]["ID_FORNECEDOR"].ToString());
            item.Status = dt.Rows[0]["STATUS"].ToString();
            item.Obs = dt.Rows[0]["OBS"].ToString();
            return item;
        }

        public void Sql_Insert_update()
        {
            string sql = "";

            if (Id == 0)
            {
                sql = $"INSERT INTO PRODUTO (DESCRICAO, DIMENSAO, IDADE_MAXIMA, ID_DEPARTAMENTO, ID_FORNECEDOR, STATUS, OBS) VALUES ('{Descricao}', '{Dimensao}', '{IdadeMaxima}', '{Id_Departamento}', '{Id_Fornecedor}','{Status}','{Obs}');";
            }
            else
            {
                sql = $"UPDATE CLIENTE SET DESCRICAO = '{Descricao}', DIMENSAO = '{Dimensao}', IDADE_MAXIMA = '{IdadeMaxima}', ID_DEPARTAMENTO = '{Id_Departamento}', ID_FORNECEDOR = '{Id_Fornecedor}', STATUS = '{Status}', OBS = '{Obs}'  WHERE ID = '{Id}'";
            }
            DAL objDal = new DAL();
            objDal.ExecutarComandoSQL(sql);
        }
    }
}
