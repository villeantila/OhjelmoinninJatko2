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

        public JsonResult GetListProjektit()
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

        public ActionResult UpdateProjekti(Projektit proj)
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
        
        public ActionResult DeleteProjekti(int id)
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


        //*******************************************************************************

        // Henkilot-taulun osuus alkaa


        public ActionResult Henkilot()
        {
            return View();
        }

        public JsonResult GetListHenkilot()
        {
            OhjelmoinninJatkoEntities entities = new OhjelmoinninJatkoEntities();

            var model = (from c in entities.Henkilot
                         select new
                         {
                             HenkiloId = c.HenkiloId,
                             Identity = c.Identity,
                             Etunimi = c.Etunimi,
                             Sukunimi = c.Sukunimi,
                             Osoite = c.Osoite,
                             Esimies = c.Esimies
                         }).ToList();

            string json = JsonConvert.SerializeObject(model);
            entities.Dispose();

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSingleHenkilo(int id)
        {
            OhjelmoinninJatkoEntities entities = new OhjelmoinninJatkoEntities();

            var model = (from c in entities.Henkilot
                         where c.HenkiloId == id
                         select new
                         {
                             HenkiloId = c.HenkiloId,
                             Identity = c.Identity,
                             Etunimi = c.Etunimi,
                             Sukunimi = c.Sukunimi,
                             Osoite = c.Osoite,
                             Esimies = c.Esimies
                         }).FirstOrDefault();

            string json = JsonConvert.SerializeObject(model);
            entities.Dispose();

            return Json(json, JsonRequestBehavior.AllowGet);
        }


        public ActionResult UpdateHenkilo(Henkilot henk)
        {
            OhjelmoinninJatkoEntities entities = new OhjelmoinninJatkoEntities();
            int id = henk.HenkiloId;

            bool OK = false;

            // onko kyseessä muokkaus vai uuden lisääminen?
            if (id == 0)
            {
                // kyseessä on uuden henkilön lisääminen, kopioidaan kentät
                Henkilot dbItem = new Henkilot()
                {
                    Identity = henk.Identity,
                    Etunimi = henk.Etunimi,
                    Sukunimi = henk.Sukunimi,
                    Osoite = henk.Osoite,
                    Esimies = henk.Esimies
                };

                // tallennus tietokantaan, Henkilö-Id muodostuu automaattisesti
                entities.Henkilot.Add(dbItem);
                entities.SaveChanges();
                OK = true;
            }

            else
            {
                // muokkaus, haetaan id:n perusteella riviä tietokannasta
                Henkilot dbItem = (from c in entities.Henkilot
                                    where c.HenkiloId == id
                                    select c).FirstOrDefault();
                if (dbItem != null)
                {
                    dbItem.Identity = henk.Identity;
                    dbItem.Etunimi = henk.Etunimi;
                    dbItem.Sukunimi = henk.Sukunimi;
                    dbItem.Osoite = henk.Osoite;
                    dbItem.Esimies = henk.Esimies;

                    // tallennus tietokantaan
                    entities.SaveChanges();
                    OK = true;
                }
            }

            entities.Dispose();

            return Json(OK, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteHenkilo(int id)
        {
            OhjelmoinninJatkoEntities entities = new OhjelmoinninJatkoEntities();

            bool OK = false;

            Henkilot dbItem = (from c in entities.Henkilot
                               where c.HenkiloId == id
                               select c).FirstOrDefault();

            if (dbItem != null)
            {
                // poisto tietokannasta
                entities.Henkilot.Remove(dbItem);
                entities.SaveChanges();
                OK = true;
            }

            entities.Dispose();

            return Json(OK, JsonRequestBehavior.AllowGet);
        }


        //public ActionResult henkilotvanha()
        //{
        //    OhjelmoinninJatkoEntities entities = new OhjelmoinninJatkoEntities();
        //    List<Henkilot> model = entities.Henkilot.ToList();
        //    entities.Dispose();
        //    return View(model);
        //}




        //*******************************************************************************

        // Henkilot-taulun osuus alkaa


        public ActionResult Tunnit()
        {
            return View();
        }

        public JsonResult GetListTunnit()
        {
            OhjelmoinninJatkoEntities entities = new OhjelmoinninJatkoEntities();

            var model = (from c in entities.Tunnit
                         select new
                         {
                             TuntiId = c.TuntiId,
                             Identity = c.Identity,
                             ProjektiId = c.ProjektiId,
                             HenkiloId = c.HenkiloId,
                             Pvm = c.Pvm,
                             ProjektinTunnit = c.ProjektinTunnit
                         }).ToList();

            string json = JsonConvert.SerializeObject(model);
            entities.Dispose();

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSingleTunti(int id)
        {
            OhjelmoinninJatkoEntities entities = new OhjelmoinninJatkoEntities();

            var model = (from c in entities.Tunnit
                         where c.TuntiId == id
                         select new
                         {
                             TuntiId = c.TuntiId,
                             Identity = c.Identity,
                             ProjektiId = c.ProjektiId,
                             HenkiloId = c.HenkiloId,
                             Pvm = c.Pvm,
                             ProjektinTunnit = c.ProjektinTunnit
                         }).FirstOrDefault();

            string json = JsonConvert.SerializeObject(model);
            entities.Dispose();

            return Json(json, JsonRequestBehavior.AllowGet);
        }


        public ActionResult UpdateTunti(Tunnit tunn)
        {
            OhjelmoinninJatkoEntities entities = new OhjelmoinninJatkoEntities();
            int id = tunn.TuntiId;

            bool OK = false;

            // onko kyseessä muokkaus vai uuden lisääminen?
            if (id == 0)
            {
                // kyseessä on uuden henkilön lisääminen, kopioidaan kentät
                Tunnit dbItem = new Tunnit()
                {
                    Identity = tunn.Identity,
                    ProjektiId = tunn.ProjektiId,
                    HenkiloId = tunn.HenkiloId,
                    Pvm = tunn.Pvm,
                    ProjektinTunnit = tunn.ProjektinTunnit
                };

                // tallennus tietokantaan, Tunti-Id muodostuu automaattisesti
                entities.Tunnit.Add(dbItem);
                entities.SaveChanges();
                OK = true;
            }

            else
            {
                // muokkaus, haetaan id:n perusteella riviä tietokannasta
                Tunnit dbItem = (from c in entities.Tunnit
                                   where c.TuntiId == id
                                   select c).FirstOrDefault();
                if (dbItem != null)
                {
                    dbItem.Identity = tunn.Identity;
                    dbItem.ProjektiId = tunn.ProjektiId;
                    dbItem.HenkiloId = tunn.HenkiloId;
                    dbItem.Pvm = tunn.Pvm;
                    dbItem.ProjektinTunnit = tunn.ProjektinTunnit;

                    // tallennus tietokantaan
                    entities.SaveChanges();
                    OK = true;
                }
            }

            entities.Dispose();

            return Json(OK, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteTunti(int id)
        {
            OhjelmoinninJatkoEntities entities = new OhjelmoinninJatkoEntities();

            bool OK = false;

            Tunnit dbItem = (from c in entities.Tunnit
                               where c.TuntiId == id
                               select c).FirstOrDefault();

            if (dbItem != null)
            {
                // poisto tietokannasta
                entities.Tunnit.Remove(dbItem);
                entities.SaveChanges();
                OK = true;
            }

            entities.Dispose();

            return Json(OK, JsonRequestBehavior.AllowGet);
        }
    }
}