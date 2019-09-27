using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
