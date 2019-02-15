using Senai.SviGufo.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SviGufo.WebApi.Interfaces
{
    public interface ITipoEventoRepository
    {
        List<TipoEventoDomain> Listar();

        void Cadastrar(TipoEventoDomain tipoEvento)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = | "INSERT INTO TIPOS_EVENTOS(TITULO) VALUES(@TITULO)";
                SqlCommand cmd = new SqlCommand(queryInsert, con);
                cmd.Parameters.AddWithValue("@TITULO", tipoEvento.Nome);
                con.Open();
                cmd.ExecuteNonQuery();

            }
        }
    }
}
