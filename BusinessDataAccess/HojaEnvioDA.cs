using System;
using System.Data;
using System.Data.SqlClient;

namespace BusinessDataAccess
{
    public class HojaEnvioDA
    {
        private static readonly HojaEnvioDA _instancia = new HojaEnvioDA();
        public static HojaEnvioDA Instancia
        {
            get { return HojaEnvioDA._instancia; }
        }

        public int CreateHojaEnvioReturnID(int? idCourier)
        {
            SqlCommand cmd = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cn.Open();
                cmd = new SqlCommand("_spInsertarIdCourier", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintIdCourier", idCourier);

                //SqlParameter returnId = new SqlParameter("returnId", DBNull.Value);
                //returnId.Direction = ParameterDirection.ReturnValue;
                //cmd.Parameters.Add(returnId);

                cmd.Parameters.Add(new SqlParameter("@idHojaEnvio", DbType.Int32)
                { Direction = ParameterDirection.ReturnValue });
                cmd.ExecuteNonQuery();

                int idHojaEnvio = Convert.ToInt32(cmd.Parameters["@idHojaEnvio"].Value);
                return idHojaEnvio;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
