using AppArenaWeb.Util;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AppArenaWeb.Models
{
    public class AgendacModel
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public int Id_Clinte { get; set; }
        public string Cliente { get; set; }
        public string DtInicial { get; set; }
        public string DtFinal { get; set; }
        public decimal VlTotal { get; set; }
        public decimal VlDesconto { get; set; }
        public int Pedido { get; set; }
        public decimal VlPago { get; set; }
        public decimal VlRestante { get; set; }
        public string Obs { get; set; }

        public AgendacModel() 
        { 
        
        }

        public List<AgendacModel> ListaAgendac() 
        {
            List<AgendacModel> lista = new List<AgendacModel>();
            AgendacModel agenda;
            string sql = "";            

            if (Id != 0 && Id_Clinte == 0 && DtInicial == null && DtFinal == null)
            {
                sql = $"SELECT A.ID, A.TIPO, A.ID_CLIENTE, C.NOME, A.DTHORAINICIO, A.DTHORAFIM, A.VLTOTAL, A.VLDESCONTO, A.PEDIDO, A.VLPAGO, A.VLRESTANTE, A.OBS FROM AGENDAC A, CLIENTE C WHERE A.ID = '{Id}' AND C.ID = A.ID_CLIENTE AND A.PEDIDO = '{Pedido}'  ORDER BY DTHORAINICIO ASC";
            }
            else if (Id == 0 && Id_Clinte != 0 && DtInicial == null && DtFinal == null)
            {
                sql = $"SELECT A.ID, A.TIPO, A.ID_CLIENTE, C.NOME, A.DTHORAINICIO, A.DTHORAFIM, A.VLTOTAL, A.VLDESCONTO, A.PEDIDO, A.VLPAGO, A.VLRESTANTE, A.OBS FROM AGENDAC A, CLIENTE C WHERE ID_CLIENTE = '{Id_Clinte}' AND A.PEDIDO = '{Pedido}' AND C.ID = A.ID_CLIENTE ORDER BY DTHORAINICIO ASC";
            }
            else if (Id == 0 && Id_Clinte == 0 && DtInicial != null && DtFinal != null)
            {
                sql = $"SELECT A.ID, A.TIPO, A.ID_CLIENTE, C.NOME, A.DTHORAINICIO, A.DTHORAFIM, A.VLTOTAL, A.VLDESCONTO, A.PEDIDO, A.VLPAGO, A.VLRESTANTE, A.OBS FROM AGENDAC A, CLIENTE C " +
                    $"WHERE DATE(A.DTHORAINICIO)  BETWEEN '{DateTime.Parse(DtInicial).ToString("yyyy-MM-dd")}' AND  '{DateTime.Parse(DtFinal).ToString("yyyy-MM-dd")}' AND A.PEDIDO = '{Pedido}' AND C.ID = A.ID_CLIENTE ORDER BY DTHORAINICIO ASC";
            }
            else if (Id == 0 && Id_Clinte == 0 && DtInicial == null && DtFinal == null) 
            {
                sql = $"SELECT A.ID, A.TIPO, A.ID_CLIENTE, C.NOME, A.DTHORAINICIO, A.DTHORAFIM, A.VLTOTAL, A.VLDESCONTO, A.PEDIDO, A.VLPAGO, A.VLRESTANTE, A.OBS FROM AGENDAC A, CLIENTE C  WHERE A.PEDIDO = '{Pedido}' AND C.ID = A.ID_CLIENTE  ORDER BY DTHORAINICIO ASC";
            }
            else
            {
                sql = $"SELECT A.ID, A.TIPO, A.ID_CLIENTE, C.NOME, A.DTHORAINICIO, A.DTHORAFIM, A.VLTOTAL, A.VLDESCONTO, A.PEDIDO, A.VLPAGO, A.VLRESTANTE, A.OBS FROM AGENDAC A, CLIENTE C WHERE C.ID = A.ID_CLIENTE ORDER BY DTHORAINICIO ASC";
            }
            DAL objDal = new DAL();
            DataTable dt = objDal.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                agenda = new AgendacModel();
                agenda.Id = int.Parse(dt.Rows[i]["ID"].ToString());
                agenda.Tipo = dt.Rows[i]["TIPO"].ToString();
                agenda.Id_Clinte = int.Parse(dt.Rows[i]["ID_CLIENTE"].ToString());
                agenda.Cliente = dt.Rows[i]["NOME"].ToString();
                agenda.DtInicial = dt.Rows[i]["DTHORAINICIO"].ToString();
                agenda.DtFinal = dt.Rows[i]["DTHORAFIM"].ToString();
                agenda.VlTotal = decimal.Parse(dt.Rows[i]["VLTOTAL"].ToString());
                agenda.VlDesconto = decimal.Parse(dt.Rows[i]["VLDESCONTO"].ToString());
                agenda.Pedido = int.Parse(dt.Rows[i]["PEDIDO"].ToString());
                agenda.VlPago = decimal.Parse(dt.Rows[i]["VLPAGO"].ToString());
                agenda.VlRestante = decimal.Parse(dt.Rows[i]["VLRESTANTE"].ToString());
                agenda.Obs = dt.Rows[i]["OBS"].ToString();
                lista.Add(agenda);
            }
            return lista;
        } 
    }
}
