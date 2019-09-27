using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class Documento
    {
        public int Id { get; set; }
        public string NumeroSisgedo { get; set; }
        public string Asunto { get; set; }
        public int Fol { get; set; }
        public string NumeroDocumento { get; set; }
        public string Firma { get; set; }
    }
}
