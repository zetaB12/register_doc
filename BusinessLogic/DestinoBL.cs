using System;
using BusinessDataAccess;

namespace BusinessLogic
{
    public class DestinoBL
    {
        private static readonly DestinoBL _instancia = new DestinoBL();

        public static DestinoBL Instancia
        {
            get { return DestinoBL._instancia; }
        }

        public int AgregarDestino(int idDoc, string destino)
        {
            try
            {
                return DestinoDA.Instancia.AgregarDestino(idDoc, destino);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
