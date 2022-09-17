using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Colaboradores;

namespace Colaboradores.Controllers
{
    public class COLABORADORESController : Controller
    {
        private ORGANIZACIONEntities db = new ORGANIZACIONEntities();

        // GET: COLABORADORES
        public ActionResult Index()
        {
            return View(db.COLABORADORES.ToList());
        }

        // GET: COLABORADORES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COLABORADORES cOLABORADORES = db.COLABORADORES.Find(id);
            if (cOLABORADORES == null)
            {
                return HttpNotFound();
            }
            return View(cOLABORADORES);
        }

        // GET: COLABORADORES/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: COLABORADORES/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDCOLABORADOR,NOMBRE,APELLIDO,FECHANACIMIENTO,ESTADOCIVIL,GRADOACADEMICO,DIRECCION")] COLABORADORES cOLABORADORES)
        {
            if (ModelState.IsValid)
            {
                db.COLABORADORES.Add(cOLABORADORES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cOLABORADORES);
        }

        // GET: COLABORADORES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COLABORADORES cOLABORADORES = db.COLABORADORES.Find(id);
            if (cOLABORADORES == null)
            {
                return HttpNotFound();
            }
            return View(cOLABORADORES);
        }

        // POST: COLABORADORES/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDCOLABORADOR,NOMBRE,APELLIDO,FECHANACIMIENTO,ESTADOCIVIL,GRADOACADEMICO,DIRECCION")] COLABORADORES cOLABORADORES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOLABORADORES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cOLABORADORES);
        }

        // GET: COLABORADORES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COLABORADORES cOLABORADORES = db.COLABORADORES.Find(id);
            if (cOLABORADORES == null)
            {
                return HttpNotFound();
            }
            return View(cOLABORADORES);
        }

        // POST: COLABORADORES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            COLABORADORES cOLABORADORES = db.COLABORADORES.Find(id);
            db.COLABORADORES.Remove(cOLABORADORES);
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
