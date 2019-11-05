using BusinessDataAccess;
using BusinessEntity;
using System.Collections.Generic;

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

        public List<HojaEnvio> BuscarHojaPorFechas(string fechaInicio, string fechaFin)
        {
            return HojaEnvioDA.Instancia.BuscarHojaPorFechas(fechaInicio, fechaFin);
        }
    }
}
