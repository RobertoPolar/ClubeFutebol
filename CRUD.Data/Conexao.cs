using System.Configuration;

namespace CRUD.Data
{
    public class Conexao
    {
        public static string cadena = ConfigurationManager.ConnectionStrings["connDBATLETA"].ToString();
    }
}
