using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Italika.Models;
using System.Data.Entity.Validation;

namespace Italika.Controllers
{
    public class ProductoController : Controller
    {
        private Entities db = new Entities();

        // GET: Producto
        public ActionResult Index(string filtro)
        {
            if (!string.IsNullOrEmpty(filtro))
            {
                var query = db.Producto.Where(o => o.SKU.Contains(filtro) || o.Modelo.Contains(filtro)).ToList();
                return View(query);
            }
            return View(db.Producto.Take(5).ToList());
        }

        // GET: Producto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Tipo")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                producto.Tipo = producto.TipoP.GetDescription();
                try
                {
                    db.Producto.Add(producto);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        ViewBag.MiMensaje = "Entity of type \"{0}\" in state \"{1}\" has the following validation errors:" + "-" + eve.Entry.State;
                        var msage = eve.Entry.Entity.GetType().Name + " " + eve.Entry.State;

                        ViewBag.MiMensaje0 = msage.ToString();

                        foreach (var ve in eve.ValidationErrors)
                        {
                            ViewBag.MiMensaje1 = "- Property:  \"{0}\", Value:  \"{1}\", Error:  \"{2}\"" + "-" + ve.PropertyName + " " + eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName) + " " + ve.ErrorMessage;
                        }

                    }
                    throw;

                }
            }

            return View(producto);
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Producto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Exclude = "Tipo")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                producto.Tipo = producto.TipoP.GetDescription();
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producto);
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = db.Producto.Find(id);
            db.Producto.Remove(producto);
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
