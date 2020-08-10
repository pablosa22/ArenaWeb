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
        public int Id_Cliente { get; set; }
        public string Cliente { get; set; }
        public string DtInicial { get; set; }
        public string DtFinal { get; set; }
        public decimal VlTotal { get; set; }
        public decimal VlDesconto { get; set; }
        public int Pedido { get; set; }
        public decimal VlPago { get; set; }
        public decimal VlRestante { get; set; }
        public string Obs { get; set; }

        // AgendaI

        public int Id_AgendaI { get; set; }        
        public int Id_Produto { get; set; }
        public string Descricao { get; set; } // campo descricao da tabela de produto
        public int Qtde { get; set; }
        public decimal Punit { get; set; }
        public decimal VlDescontoI { get; set; }
        public int PedidoI { get; set; }



        public AgendacModel() 
        { 
        
        }

        public List<AgendacModel> ListaAgendac() 
        {
            List<AgendacModel> lista = new List<AgendacModel>();
            AgendacModel agenda;
            string sql = "";            

            if (Id != 0 && Id_Cliente == 0 && DtInicial == null && DtFinal == null)
            {
                sql = $"SELECT A.ID, A.TIPO, A.ID_CLIENTE, C.NOME, A.DTHORAINICIO, A.DTHORAFIM, A.VLTOTAL, A.VLDESCONTO, A.PEDIDO, A.VLPAGO, A.VLRESTANTE, A.OBS FROM AGENDAC A, CLIENTE C WHERE A.ID = '{Id}' AND C.ID = A.ID_CLIENTE AND A.PEDIDO = '{Pedido}'  ORDER BY DTHORAINICIO ASC";
            }
            else if (Id == 0 && Id_Cliente != 0 && DtInicial == null && DtFinal == null)
            {
                sql = $"SELECT A.ID, A.TIPO, A.ID_CLIENTE, C.NOME, A.DTHORAINICIO, A.DTHORAFIM, A.VLTOTAL, A.VLDESCONTO, A.PEDIDO, A.VLPAGO, A.VLRESTANTE, A.OBS FROM AGENDAC A, CLIENTE C WHERE ID_CLIENTE = '{Id_Cliente}' AND A.PEDIDO = '{Pedido}' AND C.ID = A.ID_CLIENTE ORDER BY DTHORAINICIO ASC";
            }
            else if (Id == 0 && Id_Cliente == 0 && DtInicial != null && DtFinal != null)
            {
                sql = $"SELECT A.ID, A.TIPO, A.ID_CLIENTE, C.NOME, A.DTHORAINICIO, A.DTHORAFIM, A.VLTOTAL, A.VLDESCONTO, A.PEDIDO, A.VLPAGO, A.VLRESTANTE, A.OBS FROM AGENDAC A, CLIENTE C " +
                    $"WHERE DATE(A.DTHORAINICIO)  BETWEEN '{DateTime.Parse(DtInicial).ToString("yyyy-MM-dd")}' AND  '{DateTime.Parse(DtFinal).ToString("yyyy-MM-dd")}' AND A.PEDIDO = '{Pedido}' AND C.ID = A.ID_CLIENTE ORDER BY DTHORAINICIO ASC";
            }
            else if (Id == 0 && Id_Cliente == 0 && DtInicial == null && DtFinal == null) 
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
                agenda.Id_Cliente = int.Parse(dt.Rows[i]["ID_CLIENTE"].ToString());
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

        public List<AgendacModel> ListaAgendai(int? Id)
        {
            List<AgendacModel> listaItens = new List<AgendacModel>();
            AgendacModel agendai;
            string sql = $"SELECT I.ID, I.ID_PRODUTO, P.DESCRICAO, I.QTDE, I.PUNIT, I.VLDESCONTO FROM AGENDAI I, PRODUTO P WHERE ID_PRODUTO = P.ID AND I.ID_AGENDAC = '{Id}' ORDER BY P.DESCRICAO ASC";            
            DAL objDal = new DAL();
            DataTable dt = objDal.RetDataTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                agendai = new AgendacModel();
                agendai.Id_AgendaI = int.Parse(dt.Rows[i]["ID"].ToString());
                agendai.Id_Produto = int.Parse(dt.Rows[i]["ID_PRODUTO"].ToString());
                agendai.Descricao = dt.Rows[i]["DESCRICAO"].ToString();
                agendai.Qtde = int.Parse(dt.Rows[i]["QTDE"].ToString());
                agendai.Punit = decimal.Parse(dt.Rows[i]["PUNIT"].ToString());
                agendai.VlDescontoI = decimal.Parse(dt.Rows[i]["VLDESCONTO"].ToString());
                listaItens.Add(agendai);
            }
            return listaItens;
        }

        public AgendacModel CarregarRegistro(int? Id)
        {
            AgendacModel item = new AgendacModel();
            string sql = $"SELECT A.ID, A.TIPO, A.ID_CLIENTE, C.NOME, A.DTHORAINICIO, A.DTHORAFIM, A.VLTOTAL, A.VLDESCONTO, A.PEDIDO, A.VLPAGO, A.VLRESTANTE, A.OBS FROM AGENDAC A, CLIENTE C WHERE A.ID = '{Id}' AND C.ID = A.ID_CLIENTE ";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            item = new AgendacModel();
            item.Id = int.Parse(dt.Rows[0]["ID"].ToString());
            item.Tipo = dt.Rows[0]["TIPO"].ToString();
            
            item.Id_Cliente = int.Parse(dt.Rows[0]["ID_CLIENTE"].ToString());

            item.Cliente = dt.Rows[0]["NOME"].ToString();
            item.DtInicial = dt.Rows[0]["DTHORAINICIO"].ToString();
            item.DtFinal = dt.Rows[0]["DTHORAFIM"].ToString();
            item.VlTotal = decimal.Parse(dt.Rows[0]["VLTOTAL"].ToString());
            item.VlDesconto = decimal.Parse(dt.Rows[0]["VLDESCONTO"].ToString());
            item.Pedido = int.Parse(dt.Rows[0]["PEDIDO"].ToString());
            item.VlPago = decimal.Parse(dt.Rows[0]["VLPAGO"].ToString());
            item.VlRestante = decimal.Parse(dt.Rows[0]["VLRESTANTE"].ToString());
            item.Obs = dt.Rows[0]["OBS"].ToString();
            return item;
        }       

    }
}
