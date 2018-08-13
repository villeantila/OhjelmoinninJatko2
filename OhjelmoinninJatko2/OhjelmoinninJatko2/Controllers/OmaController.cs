using Newtonsoft.Json;
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
        public ActionResult ProjektitVanha()
        {
            //ViewBag.TestiTieto = "Testiä";
            OhjelmoinninJatkoEntities2 entities = new OhjelmoinninJatkoEntities2();
            List<Projektit> model = entities.Projektit.ToList();
            entities.Dispose();
            return View(model);
        }
        public ActionResult HenkilotVanha()
        {
            OhjelmoinninJatkoEntities2 entities = new OhjelmoinninJatkoEntities2();
            List<Henkilot> model = entities.Henkilot.ToList();
            entities.Dispose();
            return View(model);
        }
        public ActionResult TunnitVanha()
        {
            OhjelmoinninJatkoEntities2 entities = new OhjelmoinninJatkoEntities2();
            List<Tunnit> model = entities.Tunnit.ToList();
            entities.Dispose();
            return View(model);
        }

        public ActionResult ProjektitVanha2()
        {
           
            return View();
        }

        public ActionResult Projektit()
        {

            return View();
        }

        public JsonResult GetList()
        {
            OhjelmoinninJatkoEntities2 entities = new OhjelmoinninJatkoEntities2();
            //List<Projektit> model = entities.Projektit.ToList();

            var model = (from c in entities.Projektit
                         select new
                         {
                             ProjektiId = c.ProjektiId,
                             Identity = c.Identity,
                             Nimi = c.Nimi
                         }).ToList();

            string json = JsonConvert.SerializeObject(model);
            entities.Dispose();

            return Json(json, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetSingleProjekti(int id) //vai pitääkö olla string??
        {
            OhjelmoinninJatkoEntities2 entities = new OhjelmoinninJatkoEntities2();
           
            var model = (from c in entities.Projektit
                         where c.ProjektiId == id
                         select new
                         {
                             ProjektiId = c.ProjektiId,
                             Identity = c.Identity,
                             Nimi = c.Nimi
                         }).FirstOrDefault();

            string json = JsonConvert.SerializeObject(model);
            entities.Dispose();

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update(Projektit proj)
        {
            OhjelmoinninJatkoEntities2 entities = new OhjelmoinninJatkoEntities2();
            int id = proj.ProjektiId;

            bool OK = false;
            
            Projektit dbItem = (from c in entities.Projektit
                                where c.ProjektiId == id
                                select c).FirstOrDefault();
            if (dbItem != null)
            {
                dbItem.Identity = proj.Identity;
                dbItem.Nimi = proj.Nimi;

                // tallennus tietokantaan
                entities.SaveChanges();
                OK = true;
            }

            entities.Dispose();

            return Json(OK);
        }
           
    }
    
}