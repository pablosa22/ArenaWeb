using AppArenaWeb.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AppArenaWeb.Models
{
    public class AgendaiModel
    {
        public int Id { get; set; }
        public int Id_Agendac { get; set; }
        public int Id_Produto { get; set; }
        public string Descricao { get; set; } // campo descricao da tabela de produto
        public int Qtde { get; set; }
        public decimal Punit { get; set; }
        public decimal VlDesconto { get; set; }
        public int Pedido { get; set; }
        
        public AgendaiModel() 
        { 
    
        }

        public List<AgendaiModel> ListaAgendai()        
        {
            List<AgendaiModel> listaItens = new List<AgendaiModel>();
            AgendaiModel agendai;
            string sql = "";

            if (Id_Agendac != 0)
            {
                sql = $"SELECT I.ID, I.ID_PRODUTO, P.DESCRICAO, I.QTDE, I.PUNIT, I.VLDESCONTO FROM AGENDAI I, PRODUTO P WHERE ID_PRODUTO = P.ID AND I.ID_AGENDAC = '{Id_Agendac}' ORDER BY P.DESCRICAO ASC";
            }            
            DAL objDal = new DAL();
            DataTable dt = objDal.RetDataTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                agendai = new AgendaiModel();
                agendai.Id = int.Parse(dt.Rows[i]["ID"].ToString());
                agendai.Id_Produto = int.Parse(dt.Rows[i]["ID_PRODUTO"].ToString());
                agendai.Descricao = dt.Rows[i]["DESCRICAO"].ToString();
                agendai.Qtde = int.Parse(dt.Rows[i]["QTDE"].ToString());
                agendai.Punit = decimal.Parse(dt.Rows[i]["PUNIT"].ToString());
                agendai.VlDesconto = decimal.Parse(dt.Rows[i]["VLDESCONTO"].ToString());
                listaItens.Add(agendai);
            }
            return listaItens;
        }
    }
}
