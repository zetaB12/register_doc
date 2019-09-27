using BusinessDataAccess;

namespace BusinessLogic
{
    public class HojaEnvioBL
    {
        private static readonly HojaEnvioBL _instancia = new HojaEnvioBL();
        public static HojaEnvioBL Instancia
        {
            get { return HojaEnvioBL._instancia; }
        }

        public int CreateHojaEnvio(int? idCourier)
        {
            return HojaEnvioDA.Instancia.CreateHojaEnvioReturnID(idCourier);
        }
    }
}
