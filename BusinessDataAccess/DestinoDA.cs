using BusinessEntity;
using System;
using System.Collections.Generic;
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

        public List<Destino> Buscar_Destinos(string num_sis)
        {
            SqlCommand cmd = null;
            
            var parametros = new List<SqlParameter>();
            var listaDestinos = new List<Destino>();
            Destino destino = null;

            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("_spListarDestinos", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@num_sis", Convert.ToInt32(num_sis));
                cn.Open();
                SqlDataReader data = cmd.ExecuteReader();
                while (data.Read())
                {
                    destino = new Destino()
                    {
                        Id = Convert.ToInt32(data["id_destino"]),
                        NombreDestino = data["nombreDestino"].ToString()
                    };
                    listaDestinos.Add(destino);
                }
            }
            catch (Exception x)
            {
                throw x;
            }
            finally { cmd.Connection.Close(); }
            return listaDestinos;
        }

        public bool RegistrarFechaNotificacion(int destino, string date)
        {
            SqlCommand cmd = null;
            bool insert = false;
            
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("_spRegistrarFechaNotificacion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@destino", destino);
                cmd.Parameters.AddWithValue("@date", date);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                insert = i > 0 ? true : false;
            }
            catch (Exception ex) { throw ex; }
            finally { cmd.Connection.Close(); }
            return insert;
        }
    }
}