
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

        //extra
        public string NombreDestino { get; set; }
        public string FechaNotif { get; set; }
        public string FechaDev { get; set; }
        public bool Devolucion { get; set; }
    }
}
