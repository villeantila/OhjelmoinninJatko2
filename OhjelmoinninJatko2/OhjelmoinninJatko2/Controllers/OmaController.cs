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
       
        public ActionResult Projektit()
        {
            return View();
        }

        public JsonResult GetList()
        {
            OhjelmoinninJatkoEntities entities = new OhjelmoinninJatkoEntities();
            
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

        public JsonResult GetSingleProjekti(int id)
        {
            OhjelmoinninJatkoEntities entities = new OhjelmoinninJatkoEntities();
           
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
            OhjelmoinninJatkoEntities entities = new OhjelmoinninJatkoEntities();
            int id = proj.ProjektiId;

            bool OK = false;

            // onko kyseessä muokkaus vai uuden lisääminen?
            if (id == 0)
            {
                // kyseessä on uuden projektin lisääminen, kopioidaan kentät
                Projektit dbItem = new Projektit()
                {
                    Identity = proj.Identity,
                    Nimi = proj.Nimi
                };

                // tallennus tietokantaan, Projekti-Id muodostuu automaattisesti
                entities.Projektit.Add(dbItem);
                entities.SaveChanges();
                OK = true;
            }

            else
            {
                // muokkaus, haetaan id:n perusteella riviä tietokannasta
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
            }

            entities.Dispose();

            return Json(OK, JsonRequestBehavior.AllowGet);
        }  
        
        public ActionResult Delete(int id)
        {
            OhjelmoinninJatkoEntities entities = new OhjelmoinninJatkoEntities();

            bool OK = false;

            Projektit dbItem = (from c in entities.Projektit
                                where c.ProjektiId == id
                                select c).FirstOrDefault();

            if (dbItem != null)
            {
                // poisto tietokannasta
                entities.Projektit.Remove(dbItem);
                entities.SaveChanges();
                OK = true;
            }

            entities.Dispose();

            return Json(OK, JsonRequestBehavior.AllowGet);
        }
    }
}