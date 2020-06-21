using AppArenaWeb.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AppArenaWeb.Models
{
    public class FornecedorModel
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required(ErrorMessage = "Informe o Nome!")]
        public string Nome { get; set; }        
        public string Atividade { get; set; }
        [Required(ErrorMessage = "Informe o Nome da Rua ou Avenida!")]
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
        [EmailAddress(ErrorMessage = "Email não é valido!")]
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Celular2 { get; set; }
        public string Obs { get; set; }


        public FornecedorModel() 
        { 
        }

        public List<FornecedorModel> ListaFornecedores() 
        {
            List<FornecedorModel> lista = new List<FornecedorModel>();
            FornecedorModel item;
            string sql = "";


            if (Nome != null && Atividade == null)// Pesquisar por Nome
            {
                sql = $"SELECT ID, NOME, ATIVIDADE, RUA, NUMERO, COMPLEMENTO, BAIRRO, CIDADE, UF, EMAIL, TELEFONE, CELULAR, CELULAR2, OBS FROM FORNECEDOR WHERE NOME LIKE '%{Nome}%' ORDER BY NOME ASC";
            }
            else if (Nome == null && Atividade != null)
            {
                sql = $"SELECT ID, NOME, ATIVIDADE, RUA, NUMERO, COMPLEMENTO, BAIRRO, CIDADE, UF, EMAIL, TELEFONE, CELULAR, CELULAR2, OBS FROM FORNECEDOR WHERE ATIVIDADE LIKE '%{Atividade}%' ORDER BY NOME ASC";
            }
            else if (Nome != null && Atividade != null)
            {
                sql = $"SELECT ID, NOME, ATIVIDADE, RUA, NUMERO, COMPLEMENTO, BAIRRO, CIDADE, UF, EMAIL, TELEFONE, CELULAR, CELULAR2, OBS FROM FORNECEDOR WHERE NOME LIKE '%{Nome}%' AND ATIVIDADE LIKE '%{Atividade}%' ORDER BY NOME ASC";
            }
            else
            {
                sql = $"SELECT ID, NOME, ATIVIDADE, RUA, NUMERO, COMPLEMENTO, BAIRRO, CIDADE, UF, EMAIL, TELEFONE, CELULAR, CELULAR2, OBS FROM FORNECEDOR ORDER BY NOME ASC";
            }

            DAL objDal = new DAL();
            DataTable dt = objDal.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new FornecedorModel();
                item.Id = int.Parse(dt.Rows[i]["ID"].ToString());
                item.Nome = dt.Rows[i]["NOME"].ToString();
                item.Atividade = dt.Rows[i]["ATIVIDADE"].ToString();
                item.Rua = dt.Rows[i]["RUA"].ToString();
                item.Numero = dt.Rows[i]["Numero"].ToString();
                item.Complemento = dt.Rows[i]["COMPLEMENTO"].ToString();
                item.Bairro = dt.Rows[i]["BAIRRO"].ToString();
                item.Cidade = dt.Rows[i]["CIDADE"].ToString();
                item.UF = dt.Rows[i]["UF"].ToString();
                item.Email = dt.Rows[i]["EMAIL"].ToString();
                item.Telefone = dt.Rows[i]["TELEFONE"].ToString();
                item.Celular = dt.Rows[i]["CELULAR"].ToString();
                item.Celular2 = dt.Rows[i]["CELULAR2"].ToString();
                item.Obs = dt.Rows[i]["OBS"].ToString();
                lista.Add(item);
            }
            return lista;
        }

        public FornecedorModel CarregarRegistro(int? id) 
        {
            FornecedorModel item = new FornecedorModel();
            string sql = $"SELECT ID, NOME, ATIVIDADE, RUA, NUMERO, COMPLEMENTO, BAIRRO, CIDADE, UF, EMAIL, TELEFONE, CELULAR, CELULAR2, OBS FROM FORNECEDOR WHERE ID = '{id}' ORDER BY NOME ASC";
            DAL objDao = new DAL();
            DataTable dt = objDao.RetDataTable(sql);

            item = new FornecedorModel();
            item.Id = int.Parse(dt.Rows[0]["ID"].ToString());
            item.Nome = dt.Rows[0]["NOME"].ToString();
            item.Atividade = dt.Rows[0]["ATIVIDADE"].ToString();
            item.Rua = dt.Rows[0]["RUA"].ToString();
            item.Numero = dt.Rows[0]["Numero"].ToString();
            item.Complemento = dt.Rows[0]["COMPLEMENTO"].ToString();
            item.Bairro = dt.Rows[0]["BAIRRO"].ToString();
            item.Cidade = dt.Rows[0]["CIDADE"].ToString();
            item.UF = dt.Rows[0]["UF"].ToString();
            item.Email = dt.Rows[0]["EMAIL"].ToString();
            item.Telefone = dt.Rows[0]["TELEFONE"].ToString();
            item.Celular = dt.Rows[0]["CELULAR"].ToString();
            item.Celular2 = dt.Rows[0]["CELULAR2"].ToString();
            item.Obs = dt.Rows[0]["OBS"].ToString();
            return item;
        }

        public void Sql_Insert_update()
        {
            string sql = "";

            if (Id == 0)
            {
                sql = $"INSERT INTO FORNECEDOR (NOME, ATIVIDADE, RUA, NUMERO, COMPLEMENTO, BAIRRO, CIDADE, UF, EMAIL, TELEFONE, CELULAR, CELULAR2, OBS) VALUES ('{Nome}', '{Atividade}','{Rua}', '{Numero}', '{Complemento}','{Bairro}','{Cidade}', '{UF}', '{Email}','{Telefone}', '{Celular}', '{Celular2}', '{Obs}' );";
            }
            else
            {
                sql = $"UPDATE FORNECEDOR SET NOME = '{Nome}', ATIVIDADE = '{Atividade}', RUA = '{Rua}',  NUMERO = '{Numero}', COMPLEMENTO = '{Complemento}', BAIRRO = '{Bairro}', CIDADE = '{Cidade}', UF = '{UF}', EMAIL = '{Email}', TELEFONE ='{Telefone}', CELULAR = '{Celular}', CELULAR2 = '{Celular2}', OBS = '{Obs}' WHERE ID = '{Id}'";
            }
            DAL objDal = new DAL();
            objDal.ExecutarComandoSQL(sql);
        }
    }
}
