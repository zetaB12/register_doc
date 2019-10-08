using System;
using System.Collections.Generic;
using BusinessDataAccess;
using BusinessEntity;

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

        public List<Destino> Buscar_Destinos(string num_sis)
        {
            try
            {
                return DestinoDA.Instancia.Buscar_Destinos(num_sis);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RegistrarFechaNotificacion(string destino, string date)
        {
            try
            {
                return DestinoDA.Instancia.RegistrarFechaNotificacion(destino, date);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}
