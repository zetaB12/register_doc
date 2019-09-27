using System;
using System.Collections.Generic;
using BusinessEntity;
using BusinessDataAccess;

namespace BusinessLogic
{
    public class DocumentoBL
    {
        private static readonly DocumentoBL _instancia = new DocumentoBL();

        public static DocumentoBL Instancia
        {
            get { return DocumentoBL._instancia; }
        }

        public Documento buscar_DocSis(string num_sis)
        {
            try
            {
                return DocumentoDA.Instancia.Buscar_DocSis(num_sis);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
