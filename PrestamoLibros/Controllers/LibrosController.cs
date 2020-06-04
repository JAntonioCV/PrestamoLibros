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
    public class LibrosController : Controller
    {
        private Cartera db = new Cartera();

        // GET: Libros
        [Authorize(Roles = "Reportero,Admin,Operador")]
        public ActionResult Index()
        {
            var libros = db.Libros.Include(l => l.Materia);
            return View(libros.ToList());
        }

        // GET: Libros/Details/5
        [Authorize(Roles = "Reportero,Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = db.Libros.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        // GET: Libros/Create
        [Authorize(Roles = "Admin,Operador")]
        public ActionResult Create()
        {
            ViewBag.MateriaId = new SelectList(db.Materias, "Id", "DescripcionDeMateria"); /*Aqui Mostrar Campo en create */
            return View();
        }

        // POST: Libros/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CodigoDeLibro,TituloDeLibro,ISBN,Autor,MateriaId")] Libro libro)
        {
            //Validacion de no iguales
            Libro OLibro = db.Libros.DefaultIfEmpty(null).FirstOrDefault(l => l.CodigoDeLibro.Trim() == libro.CodigoDeLibro.Trim());
            if (OLibro != null)
            {
                ModelState.AddModelError("ErrAdd", "El codigo especificado ya existe");
            }

            if (ModelState.IsValid)
            {
                db.Libros.Add(libro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MateriaId = new SelectList(db.Materias, "Id", "DescripcionDeMateria", libro.MateriaId); /*Aqui Mostrar Campo Create */
            return View(libro);
        }

        // GET: Libros/Edit/5
        [Authorize(Roles = "Admin,Operador")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = db.Libros.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            ViewBag.MateriaId = new SelectList(db.Materias, "Id", "DescripcionDeMateria", libro.MateriaId); /*Aqui Mostrar Campo Edicion*/
            return View(libro);
        }

        // POST: Libros/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CodigoDeLibro,TituloDeLibro,ISBN,Autor,MateriaId")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(libro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MateriaId = new SelectList(db.Materias, "Id", "DescripcionDeMateria", libro.MateriaId); /*Aqui Mostrar Campo Edicion*/
            return View(libro);
        }

        // GET: Libros/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            ViewBag.Error = "";

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = db.Libros.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        // POST: Libros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            Libro libro = db.Libros.Find(id);
            CopiaDeLibro Ocopia = db.CopiasDelibro.DefaultIfEmpty(null).FirstOrDefault(c => c.LibroId == libro.Id);
            ViewBag.Error = "";
            if(Ocopia==null)
            {
                db.Libros.Remove(libro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Error = "Hay copias en este Libro";
            return (View());
            
        }
        [Authorize(Roles = "Admin")]
        public PartialViewResult Busqueda(string Titulo = "",string Autor="")
        {
            string condicion = "";
            //Armar condicion según los datos que llenó
            if (Titulo.Trim().Length > 0)
                condicion += " && TituloDeLibro.Contains(\"" + Titulo.Trim() + "\")";
            if (!string.IsNullOrEmpty(Autor))
                condicion += " && Autor.Contains(\"" + Autor.Trim() + "\")";

            if (string.IsNullOrEmpty(condicion))
            {
                condicion = "1==0";  //Impedir que cargue si no hay filtro.
            }
            else
            {
                condicion = condicion.Substring(4); //Dejar la condición unicamente
            }


            var libros = db.Libros.Include("Materia")
                .Where(condicion);

            //Cambiar nombre al return de la vista parcial
            return PartialView("_BusquedaDeLibro", libros.ToList());
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
