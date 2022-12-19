using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Car_LoactionV6.Models;

namespace Car_LoactionV6.Controllers
{
    public class ModelesController : Controller
    {
        private Context db = new Context();

        // GET: Modeles
        public ActionResult Index()
        {
            return View(db.modeles.ToList());
        }

        // GET: Modeles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modele modele = db.modeles.Find(id);
            if (modele == null)
            {
                return HttpNotFound();
            }
            return View(modele);
        }

        // GET: Modeles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Modeles/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdModel,NomMarque,NomSerie")] Modele modele)
        {

            db.modeles.Add(modele);
            db.SaveChanges();
            return RedirectToAction("Index");
           
        }

        // GET: Modeles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modele modele = db.modeles.Find(id);
            if (modele == null)
            {
                return HttpNotFound();
            }
            return View(modele);
        }

        // POST: Modeles/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdModel,NomMarque,NomSerie")] Modele modele)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modele).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modele);
        }

        // GET: Modeles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modele modele = db.modeles.Find(id);
            if (modele == null)
            {
                return HttpNotFound();
            }
            return View(modele);
        }

        // POST: Modeles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Modele modele = db.modeles.Find(id);
            db.modeles.Remove(modele);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
