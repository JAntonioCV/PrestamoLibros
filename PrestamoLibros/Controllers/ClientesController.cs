using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PrestamoLibros.Models;

namespace PrestamoLibros.Controllers
{
    [Authorize]
    public class ClientesController : Controller
    {
        private Cartera db = new Cartera();

        // GET: Clientes
        [Authorize(Roles ="Reportero,Admin,Operador")]
        public ActionResult Index()
        {
            return View(db.Clientes.ToList());
        }

        // GET: Clientes/Details/5
        [Authorize(Roles ="Reportero,Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        [Authorize(Roles ="Admin,Operador")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CodigoDeCliente,NombresDelCliente,ApellidosDelCliente")] Cliente cliente)
        {
            Cliente OCliente = db.Clientes.DefaultIfEmpty(null).FirstOrDefault(c => c.CodigoDeCliente.Trim() == cliente.CodigoDeCliente.Trim());
            if (OCliente != null)
            {
                ModelState.AddModelError("ErrAdd", "El codigo especificado ya existe");
            }

            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET: Clientes/Edit/5
        [Authorize(Roles = "Admin,Operador")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CodigoDeCliente,NombresDelCliente,ApellidosDelCliente")] Cliente cliente)
        {

            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            ViewBag.Error = "";

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            AlquilerDeLibro OAlquiler = db.AlquileresDeLibro.DefaultIfEmpty(null).FirstOrDefault(al=>al.ClienteId==cliente.Id);
            ViewBag.Error = "";
            if (OAlquiler == null)
            {
                db.Clientes.Remove(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Error = "Hay Alquileres en este Cliente";
            return (View());

        }

        [Authorize(Roles = "Admin")]
        public PartialViewResult Busqueda(string Nombres = "", string Apellido1 = "")
        {
            string condicion = "";
            //Armar condicion según los datos que llenó
            if (Nombres.Trim().Length > 0)
                condicion += " && NombresDelCliente.Contains(\"" + Nombres.Trim() + "\")";
            if (!string.IsNullOrEmpty(Apellido1))
                condicion += " && ApellidosDelCliente .Contains(\"" + Apellido1.Trim() + "\")";


            if (string.IsNullOrEmpty(condicion))
            {
                condicion = "1==0";  //Impedir que cargue si no hay filtro.
            }
            else
            {
                condicion = condicion.Substring(4); //Dejar la condición unicamente
            }


            var clientes = db.Clientes.Where(condicion);

            //Cambiar nombre al return de la vista parcial
            return PartialView("_BusquedaDeCliente", clientes.ToList());
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
