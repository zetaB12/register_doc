using System.Data.SqlClient;

namespace BusinessDataAccess
{
    public class Conexion
    {
        private static readonly Conexion _instancia = new Conexion();
        public static Conexion Instancia
        {
            get { return Conexion._instancia; }
        }

        public SqlConnection conectar()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=.; Initial Catalog=inventarioDos;" +
                                "Integrated Security=true";
            //"User ID=sa; Password=123456";
            return cn;
        }
    }
}
