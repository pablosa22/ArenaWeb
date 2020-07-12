using AppArenaWeb.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AppArenaWeb.Models
{
    public class DepartamentoModel
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required(ErrorMessage = "Informe o campo descrição!")]
        public string Descricao { get; set; }
        public string Status { get; set; }

        public DepartamentoModel() 
        { 

        }

        public List<DepartamentoModel> ListaDepartamentos() 
        {
            List<DepartamentoModel> lista = new List<DepartamentoModel>();
            DepartamentoModel item;
            string sql = "";

            if (Descricao != null)
            {
                sql = $"SELECT ID, DESCRICAO, STATUS FROM DEPARTAMENTO WHERE DESCRICAO LIKE '%{Descricao}%' ORDER BY DESCRICAO ASC";
            }
            else if (Descricao == null && Status == "ATIVO")
            {
                sql = $"SELECT ID, DESCRICAO, STATUS FROM DEPARTAMENTO WHERE STATUS ='ATIVO' ORDER BY DESCRICAO ASC";
            }
            else if (Descricao == null && Status == "INATIVO")
            {
                sql = $"SELECT ID, DESCRICAO, STATUS FROM DEPARTAMENTO WHERE STATUS ='INATIVO' ORDER BY DESCRICAO ASC";
            }
            else 
            {
                sql = $"SELECT ID, DESCRICAO, STATUS FROM DEPARTAMENTO ORDER BY DESCRICAO ASC";
            }

            DAL objDal = new DAL();
            DataTable dt = objDal.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new DepartamentoModel();
                item.Id = int.Parse(dt.Rows[i]["ID"].ToString());
                item.Descricao = dt.Rows[i]["DESCRICAO"].ToString();
                item.Status = dt.Rows[i]["STATUS"].ToString();
                lista.Add(item);
            }
            return lista;
        }

        public DepartamentoModel CarregarRegistro(int? id) 
        {
            DepartamentoModel departamento = new DepartamentoModel();
            string sql = $"SELECT ID, DESCRICAO, STATUS FROM DEPARTAMENTO WHERE ID ='{id}' ORDER BY DESCRICAO ASC";
            DAL objDal = new DAL();
            DataTable dt = objDal.RetDataTable(sql);

            departamento = new DepartamentoModel();
            departamento.Id = int.Parse(dt.Rows[0]["ID"].ToString());
            departamento.Descricao = dt.Rows[0]["DESCRICAO"].ToString();
            departamento.Status = dt.Rows[0]["STATUS"].ToString();
            return departamento;
        }

        public void Sql_Insert_update()
        {
            string sql = "";

            if (Id == 0)
            {
                sql = $"INSERT INTO DEPARTAMENTO (DESCRICAO, STATUS) VALUES ('{Descricao}', '{Status}');";
            }
            else
            {
                sql = $"UPDATE DEPARTAMENTO SET DESCRICAO = '{Descricao}', STATUS = '{Status}' WHERE ID = '{Id}'";
            }
            DAL objDal = new DAL();
            objDal.ExecutarComandoSQL(sql);
        }
    }
}
