using OhjelmoinninJatko2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OhjelmoinninJatko2.Controllers
{
    public class OmaController : Controller
    {
        // GET: Oma
        public ActionResult Projektit()
        {
            //ViewBag.TestiTieto = "Testiä";
            OhjelmoinninJatkoEntities2 entities = new OhjelmoinninJatkoEntities2();
            List<Projektit> model = entities.Projektit.ToList();
            entities.Dispose();
            return View(model);
        }
        public ActionResult Henkilot()
        {
            OhjelmoinninJatkoEntities2 entities = new OhjelmoinninJatkoEntities2();
            List<Henkilot> model = entities.Henkilot.ToList();
            entities.Dispose();
            return View(model);
        }
                public ActionResult Tunnit()
        {
            OhjelmoinninJatkoEntities2 entities = new OhjelmoinninJatkoEntities2();
            List<Tunnit> model = entities.Tunnit.ToList();
            entities.Dispose();
            return View(model);
        }
    }
}