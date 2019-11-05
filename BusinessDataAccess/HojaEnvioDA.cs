using BusinessEntity;
using System;
using System.Collections.Generic;
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

        public List<HojaEnvio> BuscarHojaPorFechas(string fechaInicio, string fechaFin)
        {
            SqlCommand cmd = null;
            List<HojaEnvio> lista = new List<HojaEnvio>();
            HojaEnvio oHojaEnvio;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("_spBuscarPorFechas", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@fechaFin", fechaFin);
                cn.Open();
                SqlDataReader data = cmd.ExecuteReader();
                while (data.Read())
                {
                    oHojaEnvio = new HojaEnvio
                    {
                        Id = Convert.ToInt32(data["idHoja"]),
                        Fecha = Convert.ToString(data["fecha"]),
                        IdCourier = Convert.ToInt32(data["idCourier"]),
                    };

                    lista.Add(oHojaEnvio);
                };
                    return lista;
                
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
