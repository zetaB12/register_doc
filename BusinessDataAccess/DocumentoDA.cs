using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BusinessEntity;

namespace BusinessDataAccess
{
    public class DocumentoDA
    {
        private static readonly DocumentoDA _instancia = new DocumentoDA();
        public static DocumentoDA Instancia
        {
            get { return DocumentoDA._instancia; }
        }

        public Documento Buscar_DocSis(string numSis)
        {
            SqlCommand cmd = null;
            Documento doc = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("spBuscar_DocSis", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmstrNumSis", numSis);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    doc = new Documento();
                    doc.Id = Convert.ToInt16(dr["id_documento"]);
                    doc.Asunto = dr["asunto"].ToString();
                    doc.Fol = Convert.ToInt16(dr["fol"]);
                    doc.NumeroDocumento = dr["num_doc"].ToString();
                    doc.Firma = dr["firma"].ToString();
                    doc.NumeroSisgedo = dr["num_sisgedo"].ToString();
                }
            }
            catch (Exception e) { throw e; }
            finally { cmd.Connection.Close(); }
            return doc;
        }
    }
}
