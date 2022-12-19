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
    public class UsersController : Controller
    {
       
        private Context db = new Context();
        // GET: Users
        public ActionResult Index()
        {
            return View(db.users.ToList());
        }
        public ActionResult IndexAdmin()
        {
            return View(db.users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UID,Nom,AdresseMail,TypeUser,MotDePasse,Telephone,DateNaissance,Cin,CinFile,PermisConduire,PermisConduireFile")] Users users)
        {
            users.TypeUser = "Client";

            string fileName1 = Path.GetFileName(users.CinFile.FileName);
            string fileName2 = Path.GetFileName(users.PermisConduireFile.FileName);
            users.Cin = fileName1;
            string chemin1 = Server.MapPath("~/photos1/" + fileName1);
            
            users.CinFile.SaveAs(chemin1);

            users.PermisConduire = fileName2;
            string chemin2 = Server.MapPath("~/photos2/" + fileName2);
            users.PermisConduireFile.SaveAs(chemin2);

            db.users.Add(users);
                db.SaveChanges();
                return RedirectToAction("Login");
            

           // return View(users);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Users user)
        {
            var obj = db.users.Where(x => x.AdresseMail.Equals(user.AdresseMail) && x.MotDePasse.Equals(user.MotDePasse)).FirstOrDefault();
            if (obj != null)
            {
                if (obj.TypeUser == "Client")
                {
                    Session["Iduser"] = obj.UID;
                    Session["Email"] = user.AdresseMail.ToString();
                    Session["Type"] = obj.TypeUser.ToString();
                    //return RedirectToAction("CLS");
                    return RedirectToAction("Index" , "Cars");
                }
                else if(obj.TypeUser == "Admin")
                {
                    Session["Iduser"] = obj.UID;
                    Session["Email"] = user.AdresseMail.ToString();
                    Session["Type"] = obj.TypeUser.ToString();
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Cars");
        }

       public ActionResult CLS()
        {
            return View();
        }

        public ActionResult ADM()
        {
            return View();
        }
        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: Users/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UID,Nom,AdresseMail,TypeUser,MotDePasse,Telephone,DateNaissance,Cin,PermisConduire")] Users users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(users);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Users users = db.users.Find(id);
            db.users.Remove(users);
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
