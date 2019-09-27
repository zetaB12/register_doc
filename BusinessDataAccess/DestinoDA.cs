using System;
using System.Data;
using System.Data.SqlClient;

namespace BusinessDataAccess
{
    public class DestinoDA
    {
        private static readonly DestinoDA _instancia = new DestinoDA();

        public static DestinoDA Instancia
        {
            get { return DestinoDA._instancia; }
        }

        public int AgregarDestino(int idDoc, string destino)
        {
            SqlCommand cmd = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("_spAgregarDestino", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintIdDoc", idDoc);
                cmd.Parameters.AddWithValue("@prmstrDestino", destino);
                cn.Open();
                cmd.Parameters.Add(new SqlParameter("@id_destino", DbType.Int32)
                { Direction = ParameterDirection.ReturnValue });
                cmd.ExecuteNonQuery();

                int idDestino = Convert.ToInt32(cmd.Parameters["@id_destino"].Value);
                return idDestino;
            }
            catch (Exception ex) { throw ex; }
            finally { cmd.Connection.Close(); }

        }
    }
}
