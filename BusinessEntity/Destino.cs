using System;

namespace BusinessEntity
{
    public class Destino
    {
        public int Id { get; set; }
        public string NombreDestino { get; set; }
        public Documento Documento { get; set; }
        public DateTime FechaNotif { get; set; }
        public int IdDocumento { get; set; }
    }
}
