using BusinessEntity;
using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WebPresentation.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            
            return View();
        }

        public JsonResult BuscarNumSisgedo(string num_sisgedo)
        {

            var doc = new Documento();
            doc = DocumentoBL.Instancia.buscar_DocSis(num_sisgedo);

            return Json(doc, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult GuardarDestino(string Fecha, int? IdCourier, List<Destino> ListadoDetalle)
        {
            string mensaje = "";
            List<int> listIdDestino = new List<int>();

            if (IdCourier != null)
            {
                var idHojaEnvio = HojaEnvioBL.Instancia.CreateHojaEnvio(IdCourier); //obtener el id de hoja de envio

                foreach (var data in ListadoDetalle)
                {
                    string nombreDestino = data.NombreDestino.ToString();
                    int idDocumento = Convert.ToInt32(data.IdDocumento.ToString());
                    //var objDestino = new entDestino(nombreDestino, idDocumento);
                    var idDestino = DestinoBL.Instancia.AgregarDestino(idDocumento, nombreDestino);
                    listIdDestino.Add(idDestino);
                }

                foreach (var item in listIdDestino)
                {
                    Detalle_HojaDestinoBL.Instancia.CreateHojaEnvio_Destino(idHojaEnvio, item);
                }
                mensaje = "success";
            }

            return Json(mensaje);
        }

        public ActionResult BuscarDocumentosPorFecha()
        {
            return View();
        }

        public ActionResult RegistrarFechaDeNotificacion()
        {
            return View();
        }

        public JsonResult BuscarDestinos(string num_sisgedo)
        {
            var destinos = DestinoBL.Instancia.Buscar_Destinos(num_sisgedo);
            return Json(destinos, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult RegistrarFechaNotificacion(string destino, string date)
        {
            var mensaje = "success";
            var success = DestinoBL.Instancia.RegistrarFechaNotificacion(destino, date);
            if (!success)
                return Json("error");

            return Json(mensaje);
        }
    }
}