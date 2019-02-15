using Senai.SviGufo.WebApi.Controllers;
using Senai.SviGufo.WebApi.Domains;
using Senai.SviGufo.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SviGufo.WebApi.Repositories
{
    public class TipoEventoReposity : ITipoEventoRepository
    {

        //Data Source - nome do servidor
        //Initial Catalog - nome do banco
        // user id = usuario
        //password - senha
        //caso seja auteticaçao do windows usar integrated security = true

        private string StringConexao = @"Data Source=.\sqlExpress; initial catalog=SENAI_SVIGUFO_DANIEL; user id=sa;password=132";
        public List<TipoEventoDomain> Listar()
        {
            List<TipoEventoDomain> tiposEventos = new List<TipoEventoDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QuerySelect = "SELECT ID, TITULO FROM TIPOS_EVENTOS";
                using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        TipoEventoDomain tipoEvento = new TipoEventoDomain
                        {
                            Id = Convert.ToInt32(rdr["ID"]),
                            Nome = rdr["TITULO"].ToString()
                        };

                        tiposEventos.Add(tipoEvento);
                    }
                }
            }
            return tiposEventos;
        }

    }
}
