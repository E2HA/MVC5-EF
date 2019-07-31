using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MantenimientosConMenu.Models;

namespace MantenimientosConMenu.Controllers
{
    public class VehículosController : Controller
    {
        private miBDMvcEntities db = new miBDMvcEntities();

        // GET: Vehículos
        public ActionResult Index()
        {
            return View(db.Vehículos.ToList());
        }

        // GET: Vehículos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehículos vehículos = db.Vehículos.Find(id);
            if (vehículos == null)
            {
                return HttpNotFound();
            }
            return View(vehículos);
        }

        // GET: Vehículos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vehículos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Marca,Modelo,Color")] Vehículos vehículos)
        {
            if (ModelState.IsValid)
            {
                db.Vehículos.Add(vehículos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehículos);
        }

        // GET: Vehículos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehículos vehículos = db.Vehículos.Find(id);
            if (vehículos == null)
            {
                return HttpNotFound();
            }
            return View(vehículos);
        }

        // POST: Vehículos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Marca,Modelo,Color")] Vehículos vehículos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehículos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehículos);
        }

        // GET: Vehículos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehículos vehículos = db.Vehículos.Find(id);
            if (vehículos == null)
            {
                return HttpNotFound();
            }
            return View(vehículos);
        }

        // POST: Vehículos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehículos vehículos = db.Vehículos.Find(id);
            db.Vehículos.Remove(vehículos);
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
