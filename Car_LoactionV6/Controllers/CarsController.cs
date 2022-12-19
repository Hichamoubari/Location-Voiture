using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Car_LoactionV6.Models;

namespace Car_LoactionV6.Controllers
{
    public class CarsController : Controller
    {
        private Context db = new Context();

        // GET: Cars
        public ActionResult Index()
        {
            var cars = db.Cars.Include(c => c.Category).Include(c => c.Modele);
            return View(cars.ToList());
        }

        // GET: Cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var carss = db.Cars.Include(c => c.Category).Include(c => c.Modele);
            var cars = carss.Where(c => c.IdCar == id).First();
            if (cars == null)
            {
                return HttpNotFound();
            }
            return View(cars);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            ViewBag.Idcategory = new SelectList(db.categories, "Idcategory", "NomCategory");
            ViewBag.IdModel = new SelectList(db.modeles, "IdModel", "NomMarque");
            return View();
        }

        // POST: Cars/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCar,Matriculation,DateCirculation,TypeCarburant,Prix,Image,ImageFile,Idcategory,IdModel")] Cars cars)
        {
            string fileName = Path.GetFileName(cars.ImageFile.FileName);

            cars.Image = fileName;
            string chemin = Server.MapPath("~/photos/" + fileName);
            cars.ImageFile.SaveAs(chemin);

            db.Cars.Add(cars);
            db.SaveChanges();
              //  return RedirectToAction("Index");
            
            ViewBag.Idcategory = new SelectList(db.categories, "Idcategory", "NomCategory", cars.Idcategory);
            ViewBag.IdModel = new SelectList(db.modeles, "IdModel", "NomMarque", cars.IdModel);
            return RedirectToAction("Index");
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars cars = db.Cars.Find(id);
            if (cars == null)
            {
                return HttpNotFound();
            }
            ViewBag.Idcategory = new SelectList(db.categories, "Idcategory", "NomCategory", cars.Idcategory);
            ViewBag.IdModel = new SelectList(db.modeles, "IdModel", "NomMarque", cars.IdModel);
            return View(cars);
        }

        // POST: Cars/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCar,Matriculation,DateCirculation,TypeCarburant,Prix,Image,Idcategory,IdModel")] Cars cars)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cars).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Idcategory = new SelectList(db.categories, "Idcategory", "NomCategory", cars.Idcategory);
            ViewBag.IdModel = new SelectList(db.modeles, "IdModel", "NomMarque", cars.IdModel);
            return View(cars);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars cars = db.Cars.Find(id);
            if (cars == null)
            {
                return HttpNotFound();
            }
            return View(cars);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cars cars = db.Cars.Find(id);
            db.Cars.Remove(cars);
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
