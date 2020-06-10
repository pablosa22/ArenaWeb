using AppArenaWeb.Util;
using Microsoft.AspNetCore.Razor.Language;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AppArenaWeb.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required(ErrorMessage = "Informe o Nome!")]
        public string Nome { get; set; }                
        [Required(ErrorMessage = "Informe o CPF!")]
        public string CPF { get; set; }        
        [Required(ErrorMessage ="Informe o nome da rua!")]
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        [Required(ErrorMessage = "Informe o bairro!")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "Informe a cidade!")]
        public string Cidade { get; set; }
        [StringLength(2, MinimumLength = 2)]
        [Required(ErrorMessage = "Informe a UF!")]
        public string UF { get; set; }
        public string Telefone { get; set; }
        [Required(ErrorMessage = "Informe o Número do Celular!")]
        public string Celular1 { get; set; }
        [Required(ErrorMessage = "Preencha o campo Email!")]
        [EmailAddress (ErrorMessage ="Email não é valido!")]
        public string Email { get; set; }

        public ClienteModel()
        {

        }


        public List<ClienteModel> ListaClientes()//int opcao, string valor_Nome_CPF
        {
            List<ClienteModel> lista = new List<ClienteModel>();
            ClienteModel item;
            string sql = "";


            if (Nome != null && CPF == null)// Pesquisar por Nome
            {
                sql = $"SELECT ID, NOME, CPF, RUA, NUMERO, COMPLEMENTO, BAIRRO, CIDADE, UF, TELEFONE, CELULAR1, EMAIL FROM CLIENTE WHERE NOME LIKE '%{Nome}%' ORDER BY NOME ASC";
            }
            else if (Nome == null && CPF != null) 
            {
                sql = $"SELECT ID, NOME, CPF, RUA, NUMERO, COMPLEMENTO, BAIRRO, CIDADE, UF, TELEFONE, CELULAR1, EMAIL FROM CLIENTE WHERE CPF LIKE '%{CPF}%' ORDER BY NOME ASC";
            }
            else if (Nome != null && CPF != null) 
            {
                sql = $"SELECT ID, NOME, CPF, RUA, NUMERO, COMPLEMENTO, BAIRRO, CIDADE, UF, TELEFONE, CELULAR1, EMAIL FROM CLIENTE WHERE NOME LIKE '%{Nome}%' AND CPF LIKE '%{CPF}%' ORDER BY NOME ASC";
            }
            else 
            {
                sql = $"SELECT ID, NOME, CPF, RUA, NUMERO, COMPLEMENTO, BAIRRO, CIDADE, UF, TELEFONE, CELULAR1, EMAIL FROM CLIENTE ORDER BY NOME ASC";
            }
            

            DAL objDal = new DAL();
            DataTable dt = objDal.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ClienteModel();
                item.Id = int.Parse(dt.Rows[i]["ID"].ToString());
                item.Nome = dt.Rows[i]["NOME"].ToString();
                item.CPF = dt.Rows[i]["CPF"].ToString();
                item.Rua = dt.Rows[i]["RUA"].ToString();
                item.Numero = dt.Rows[i]["Numero"].ToString();
                item.Complemento = dt.Rows[i]["COMPLEMENTO"].ToString();
                item.Bairro = dt.Rows[i]["BAIRRO"].ToString();
                item.Cidade = dt.Rows[i]["CIDADE"].ToString();
                item.UF = dt.Rows[i]["UF"].ToString();
                item.Telefone = dt.Rows[i]["TELEFONE"].ToString();
                item.Celular1 = dt.Rows[i]["CELULAR1"].ToString();
                item.Email = dt.Rows[i]["EMAIL"].ToString();
                lista.Add(item);
            }
            return lista;
        }


        public ClienteModel CarregarRegistro(int? id) 
        {
            ClienteModel item = new ClienteModel();
            string sql = $"SELECT ID, NOME, CPF, RUA, NUMERO, COMPLEMENTO, BAIRRO, CIDADE, UF, TELEFONE, CELULAR1, EMAIL FROM CLIENTE WHERE ID = '{id}' ORDER BY NOME ASC";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            item = new ClienteModel();
            item.Id = int.Parse(dt.Rows[0]["ID"].ToString());
            item.Nome = dt.Rows[0]["NOME"].ToString();
            item.CPF = dt.Rows[0]["CPF"].ToString();
            item.Rua = dt.Rows[0]["RUA"].ToString();
            item.Numero = dt.Rows[0]["Numero"].ToString();
            item.Complemento = dt.Rows[0]["COMPLEMENTO"].ToString();
            item.Bairro = dt.Rows[0]["BAIRRO"].ToString();
            item.Cidade = dt.Rows[0]["CIDADE"].ToString();
            item.UF = dt.Rows[0]["UF"].ToString();
            item.Telefone = dt.Rows[0]["TELEFONE"].ToString();
            item.Celular1 = dt.Rows[0]["CELULAR1"].ToString();
            item.Email = dt.Rows[0]["EMAIL"].ToString();

            return item;
        }

        public void Sql_Insert_update() 
        {
            string sql = "";

            if (Id == 0)
            {
                sql = $"INSERT INTO CLIENTE (NOME, CPF, RUA, NUMERO, COMPLEMENTO, BAIRRO, CIDADE, UF, TELEFONE, CELULAR1, EMAIL) VALUES ('{Nome}', '{CPF}', '{Rua}', '{Numero}', '{Complemento}','{Bairro}','{Cidade}', '{UF}','{Telefone}', '{Celular1}', '{Email}');";
            }
            else 
            {
                sql = $"UPDATE CLIENTE SET NOME = '{Nome}', CPF = '{CPF}', NUMERO = '{Numero}', COMPLEMENTO = '{Complemento}', BAIRRO = '{Bairro}', CIDADE = '{Cidade}', UF = '{UF}', TELEFONE ='{Telefone}', CELULAR1 = '{Celular1}', EMAIL = '{Email}' WHERE ID = '{Id}'";
            }
            DAL objDal = new DAL();
            objDal.ExecutarComandoSQL(sql);
        }
    }
}
