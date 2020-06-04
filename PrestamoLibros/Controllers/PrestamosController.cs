using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using PrestamoLibros.Models; 
using PrestamoLibros.Models.Extension;
using System.Data.SqlClient;

namespace PrestamoLibros.Controllers
{
    [Authorize]
    public class PrestamosController : Controller
    {
        private Cartera db = new Cartera();
        // GET: Prestamos
        [Authorize(Roles = "Reportero,Admin,Operador")]
        public ActionResult Index(string CodE = "0")
        {
            var alquileres = db.AlquileresDeLibro.Include(al => al.CopiaDeLibro).Include(al => al.CopiaDeLibro.Libro).Include(al => al.Cliente).Where(al => al.Cliente.CodigoDeCliente.Trim() == CodE.Trim() && al.FechaRealDevolucion.Year == 1900);
            var oCli = db.Clientes.DefaultIfEmpty(null).FirstOrDefault(c => c.CodigoDeCliente.Trim() == CodE.Trim());

            if (oCli != null)
            {
                ViewBag.Codigo = oCli.CodigoDeCliente.ToString();
                ViewBag.NombCompleto = oCli.NombreCompleto;
            }
            else
            {
                ViewBag.Codigo = "";
                ViewBag.NombCompleto = "";
            }
            return View(alquileres.ToList());
        }

        [Authorize(Roles = "Reportero,Admin,Operador")]
        public ActionResult Devolucion(string CodE = "0")
        {
            var alquileres = db.AlquileresDeLibro.Include(al => al.CopiaDeLibro).Include(al => al.CopiaDeLibro.Libro).Include(al => al.Cliente).Where(al => al.Cliente.CodigoDeCliente.Trim() == CodE.Trim() && al.FechaRealDevolucion.Year == 1900);
            var oCli = db.Clientes.DefaultIfEmpty(null).FirstOrDefault(c => c.CodigoDeCliente.Trim() == CodE.Trim());
            if (oCli != null)
            {
                ViewBag.Codigo = oCli.CodigoDeCliente.ToString();
                ViewBag.NombCompleto = oCli.NombreCompleto;
            }
            else
            {
                ViewBag.Codigo = "";
                ViewBag.NombCompleto = "";
            }
            return View(alquileres.ToList());
        }

        // GET: Creditos/Details/5
        [Authorize(Roles = "Reportero,Admin,Operador")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlquilerDeLibro alquiler = db.AlquileresDeLibro.Find(id);
            if (alquiler == null)
            {
                return HttpNotFound();
            }
            return View(alquiler);
        }

        // GET: Creditos/Edit/5
        [Authorize(Roles = "Admin,Operador")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            AlquilerDeLibro alquiler = db.AlquileresDeLibro.Find(id);
            var copia = db.CopiasDelibro.DefaultIfEmpty(null).FirstOrDefault(cl => cl.Id == alquiler.CopiaId);

            if (alquiler == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes.Where(c => c.Id == alquiler.ClienteId), "Id", "NombreCompleto", alquiler.ClienteId);
            ViewBag.CopiaId = new SelectList(db.CopiasDelibro.Where(cp => cp.Id == alquiler.CopiaId), "Id", "NumeroCopia", alquiler.CopiaId);
            ViewBag.LibroId = new SelectList(db.Libros.Where(l => l.Id == copia.LibroId), "Id", "TituloDeLibro");

            return View(alquiler);
        }


        // POST: Creditos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CodigoAlquiler,FechaAlquiler,FechaRealDevolucion,ClienteId,CopiaId")]AlquilerDeLibro alquilerDeLibro)
        {
            string CodE = db.Clientes.First(c => c.Id == alquilerDeLibro.ClienteId).CodigoDeCliente;
            AlquilerDeLibro oAlq = db.AlquileresDeLibro.DefaultIfEmpty(null).FirstOrDefault(al => al.CodigoAlquiler == alquilerDeLibro.CodigoAlquiler && al.Id != alquilerDeLibro.Id);
            var copia = db.CopiasDelibro.DefaultIfEmpty(null).FirstOrDefault(cl => cl.Id == alquilerDeLibro.CopiaId);
            if (oAlq != null)
            {
                ModelState.AddModelError("FactExist", "El Codigo ya existe");
            }

            if (ModelState.IsValid)
            {
                db.Entry(alquilerDeLibro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { CodE = CodE });
            }
            ViewBag.ClienteId = new SelectList(db.Clientes.Where(c => c.Id == alquilerDeLibro.ClienteId), "Id", "NombreCompleto", alquilerDeLibro.ClienteId);
            ViewBag.CopaId = new SelectList(db.CopiasDelibro.Where(cl => cl.Id == alquilerDeLibro.CopiaId), "Id", "NumeroCopia", alquilerDeLibro.CopiaId);
            ViewBag.LibroId = new SelectList(db.Libros.Where(l => l.Id == copia.LibroId), "Id", "TituloDeLibro");
            return View(alquilerDeLibro);
        }


        // GET: CreditosDevolucion /Edit/5
        [Authorize(Roles = "Admin,Operador")]
        public ActionResult EditDev(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            AlquilerDeLibro alquiler = db.AlquileresDeLibro.Find(id);
            var copia = db.CopiasDelibro.DefaultIfEmpty(null).FirstOrDefault(cl => cl.Id == alquiler.CopiaId);

            if (alquiler == null)
            {
                return HttpNotFound();
            }
            alquiler.FechaRealDevolucion = DateTime.Now;
            ViewBag.ClienteId = new SelectList(db.Clientes.Where(c => c.Id == alquiler.ClienteId), "Id", "NombreCompleto", alquiler.ClienteId);
            ViewBag.CopiaId = new SelectList(db.CopiasDelibro.Where(cp => cp.Id == alquiler.CopiaId), "Id", "NumeroCopia", alquiler.CopiaId);
            ViewBag.LibroId = new SelectList(db.Libros.Where(l => l.Id == copia.LibroId), "Id", "TituloDeLibro");
            return View(alquiler);
        }

        // POST: CreditosDevolucion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDev([Bind(Include = "Id,CodigoAlquiler,FechaAlquiler,FechaRealDevolucion,ClienteId,CopiaId")]AlquilerDeLibro alquilerDeLibro)
        {
            string CodE = db.Clientes.First(c => c.Id == alquilerDeLibro.ClienteId).CodigoDeCliente;
            AlquilerDeLibro oAlq = db.AlquileresDeLibro.DefaultIfEmpty(null).FirstOrDefault(al => al.CodigoAlquiler == alquilerDeLibro.CodigoAlquiler && al.Id != alquilerDeLibro.Id);
            var copia = db.CopiasDelibro.DefaultIfEmpty(null).FirstOrDefault(cl => cl.Id == alquilerDeLibro.CopiaId);
            if (oAlq != null)
            {
                ModelState.AddModelError("FactExist", "El Codigo ya existe");
            }
            if (ModelState.IsValid)
            {
                db.Entry(alquilerDeLibro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Devolucion", new { CodE = CodE });
            }
            ViewBag.ClienteId = new SelectList(db.Clientes.Where(c => c.Id == alquilerDeLibro.ClienteId), "Id", "CodigoDeCliente", alquilerDeLibro.ClienteId);
            ViewBag.CopaId = new SelectList(db.CopiasDelibro.Where(cl => cl.Id == alquilerDeLibro.CopiaId), "Id", "NumeroCopia", alquilerDeLibro.CopiaId);
            ViewBag.LibroId = new SelectList(db.Libros.Where(l => l.Id == copia.LibroId), "Id", "TituloDeLibro");

            return View(alquilerDeLibro);
        }

        // GET: Creditos/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlquilerDeLibro alquiler = db.AlquileresDeLibro.Find(id);
            if (alquiler == null)
            {
                return HttpNotFound();
            }
            return View(alquiler);
        }

        // POST: Creditos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AlquilerDeLibro alquiler = db.AlquileresDeLibro.Find(id);
            string CodE = db.Clientes.First(c => c.Id == alquiler.ClienteId).CodigoDeCliente;

            db.AlquileresDeLibro.Remove(alquiler);
            db.SaveChanges();
            return RedirectToAction("Index", new { CodE = CodE });
        }



        // GET: Creditos/Create
        [Authorize(Roles = "Admin,Operador")]
        public ActionResult Create(string pCodE)
        {
            ViewBag.ClienteId = new SelectList(db.Clientes.Where(c => c.CodigoDeCliente == pCodE), "Id", "NombreCompleto");
            ViewBag.LibroId = new SelectList(db.Libros, "Id", "TituloDeLibro");
            ViewBag.CopiaId = new SelectList(db.CopiasDelibro, "Id", "NumeroCopia");
            ViewBag.Codigo = pCodE;

            return View();
        }

        //Copias sin Prestar de los libros
        [Authorize(Roles = "Admin,Operador")]
        public ActionResult GetElementsCopias(int id = 0)
        {
            List<CopiaDeLibro> elements = (from c in db.CopiasDelibro
                                           where c.LibroId == id &&
                                           !(from a in db.AlquileresDeLibro where a.FechaRealDevolucion.Year == 1900 select a.CopiaId).Contains(c.Id)
                                           select c).ToList();

            if (elements == null)
                throw new ArgumentException("Categoría no es correcta");
            var data = new
            {
                rows = from c
                       in elements
                       select new
                       {
                           id = c.Id,
                           NumeroCopia = c.NumeroCopia.ToString()
                       }
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //POST: Creditos/Create
        //To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CodigoAlquiler,FechaAlquiler,ClienteId,CopiaId")]AlquilerDeLibro alquilerDeLibro)
        {
            Cliente oCli = db.Clientes.DefaultIfEmpty(null).FirstOrDefault(c => c.Id == alquilerDeLibro.ClienteId);

            ViewBag.ClienteId = new SelectList(db.Clientes.Where(c => c.Id == alquilerDeLibro.ClienteId), "Id", "NombreCompleto", alquilerDeLibro.ClienteId);
            ViewBag.CopiaId = new SelectList(db.CopiasDelibro, "Id", "NumeroCopia", alquilerDeLibro.CopiaId);
            ViewBag.LibroId = new SelectList(db.Libros, "Id", "TituloDeLibro");

            //estableciendo fecha a 1900 
            alquilerDeLibro.FechaRealDevolucion = DateTime.Parse("01/01/1900");

            AlquilerDeLibro oAlq = db.AlquileresDeLibro.DefaultIfEmpty(null).FirstOrDefault(alq => alq.CodigoAlquiler == alquilerDeLibro.CodigoAlquiler);

            if (oAlq != null)
            {
                ModelState.AddModelError("FactExist", "El número de factura ya existe");
            }
            if (ModelState.IsValid)
            {
                db.AlquileresDeLibro.Add(alquilerDeLibro);
                db.SaveChanges();
                return RedirectToAction("Index", new { CodE = alquilerDeLibro.Cliente.CodigoDeCliente });
            }
            return View(alquilerDeLibro);
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