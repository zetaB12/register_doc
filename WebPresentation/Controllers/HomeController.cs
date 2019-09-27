using BusinessEntity;
using BusinessLogic;
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
    }
}