using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GCP_CF.Models;

namespace GCP_CF.Controllers
{
    public class ActividadesFasesController : Controller
    {
        private GCPContext db = new GCPContext();

        // GET: ActividadesFases
        public ActionResult Index()
        {
            var actividadesFases = db.ActividadesFases.Include(a => a.EstadosActividad).Include(a => a.FasesContrato);
            return View(actividadesFases.ToList());
        }

        // GET: ActividadesFases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActividadesFases actividadesFases = db.ActividadesFases.Find(id);
            if (actividadesFases == null)
            {
                return HttpNotFound();
            }
            return View(actividadesFases);
        }

        // GET: ActividadesFases/Create
        public ActionResult Create()
        {
            ViewBag.EstadoActividad_Id = new SelectList(db.EstadosActividads, "EstadoActividad_Id", "Descripcion");
            ViewBag.FaseContrato_Id = new SelectList(db.FasesContratoes, "FaseContrato_Id", "Descripcion");
            return View();
        }

        // POST: ActividadesFases/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Actividad_Id,Contratos_Id,FaseContrato_Id,Item,Descripción,DiasHabiles,FechaInicio,FechaFinal,EstadoActividad_Id")] ActividadesFases actividadesFases)
        {
            if (ModelState.IsValid)
            {
                db.ActividadesFases.Add(actividadesFases);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstadoActividad_Id = new SelectList(db.EstadosActividads, "EstadoActividad_Id", "Descripcion", actividadesFases.EstadoActividad_Id);
            ViewBag.FaseContrato_Id = new SelectList(db.FasesContratoes, "FaseContrato_Id", "Descripcion", actividadesFases.FaseContrato_Id);
            return View(actividadesFases);
        }

        // GET: ActividadesFases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActividadesFases actividadesFases = db.ActividadesFases.Find(id);
            if (actividadesFases == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstadoActividad_Id = new SelectList(db.EstadosActividads, "EstadoActividad_Id", "Descripcion", actividadesFases.EstadoActividad_Id);
            ViewBag.FaseContrato_Id = new SelectList(db.FasesContratoes, "FaseContrato_Id", "Descripcion", actividadesFases.FaseContrato_Id);
            return View(actividadesFases);
        }

        // POST: ActividadesFases/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Actividad_Id,Contratos_Id,FaseContrato_Id,Item,Descripción,DiasHabiles,FechaInicio,FechaFinal,EstadoActividad_Id")] ActividadesFases actividadesFases)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actividadesFases).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstadoActividad_Id = new SelectList(db.EstadosActividads, "EstadoActividad_Id", "Descripcion", actividadesFases.EstadoActividad_Id);
            ViewBag.FaseContrato_Id = new SelectList(db.FasesContratoes, "FaseContrato_Id", "Descripcion", actividadesFases.FaseContrato_Id);
            return View(actividadesFases);
        }

        // GET: ActividadesFases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActividadesFases actividadesFases = db.ActividadesFases.Find(id);
            if (actividadesFases == null)
            {
                return HttpNotFound();
            }
            return View(actividadesFases);
        }

        // POST: ActividadesFases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ActividadesFases actividadesFases = db.ActividadesFases.Find(id);
            db.ActividadesFases.Remove(actividadesFases);
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
