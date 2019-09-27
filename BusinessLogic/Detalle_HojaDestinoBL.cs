using BusinessDataAccess;

namespace BusinessLogic
{
    public class Detalle_HojaDestinoBL
    {
        private static readonly Detalle_HojaDestinoBL _instancia = new Detalle_HojaDestinoBL();
        public static Detalle_HojaDestinoBL Instancia
        {
            get { return Detalle_HojaDestinoBL._instancia; }
        }

        public void CreateHojaEnvio_Destino(int idHoja, int idDestino)
        {
            Detalle_HojaDestinoDA.Instancia.CreateHojaEnvio_Destino(idHoja, idDestino);
        }
    }
}
