using System;
using System.Data;
using System.Data.SqlClient;


namespace BusinessDataAccess
{
    public class Detalle_HojaDestinoDA
    {
        private static readonly Detalle_HojaDestinoDA _instancia = new Detalle_HojaDestinoDA();
        public static Detalle_HojaDestinoDA Instancia
        {
            get { return Detalle_HojaDestinoDA._instancia; }
        }

        public void CreateHojaEnvio_Destino(int idHojaEnvio, int idDestino)
        {
            SqlCommand cmd = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("_spInsertarDetalleHojaEnvio_Destino", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintidHojaEnvio", idHojaEnvio);
                cmd.Parameters.AddWithValue("@prmintidDestino", idDestino);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { throw ex; }
            finally { cmd.Connection.Close(); }
        }
    }
}
