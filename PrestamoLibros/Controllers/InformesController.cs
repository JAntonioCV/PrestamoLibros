using PrestamoLibros.Models.DataSets.DS_InformeTableAdapters;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrestamoLibros.Controllers
{
    [Authorize]
    public class InformesController : Controller
    {
        // GET: Informes

        [Authorize(Roles = "Reportero,Admin")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Reportero,Admin")]
        public ActionResult RptAlquilerMensual()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RptAlquilerMensual(string Desde = "")
        {
            if (Desde != "")
            {
                ReporteMensualTableAdapter dt = new ReporteMensualTableAdapter();
                ReportViewer rpt = new ReportViewer();
                rpt.ProcessingMode = ProcessingMode.Local;
                rpt.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reportes/RptPrestamosMensual.rdlc";
                rpt.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt.GetData(DateTime.Parse(Desde)).ToList()));
                rpt.SizeToReportContent = true;
                rpt.ShowPrintButton = true;
                rpt.ShowZoomControl = true;
                ViewBag.rpt = rpt;
                return View();
            }
            else
                return RptAlquilerMensual();
        }

        [Authorize(Roles = "Reportero,Admin")]
        public ActionResult RptLibrosAlquilados()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RptLibrosAlquilados(string Desde = "")
        {
            if (Desde != "")
            {
                LibrosAlquiladosPorMesTableAdapter dt = new LibrosAlquiladosPorMesTableAdapter();
                ReportViewer rpt = new ReportViewer();
                rpt.ProcessingMode = ProcessingMode.Local;
                rpt.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reportes/RptLibrosAlquilados.rdlc";
                rpt.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt.GetData(DateTime.Parse(Desde)).OrderBy(o => o.Alquileres).ToList()));
                rpt.SizeToReportContent = true;
                rpt.ShowPrintButton = true;
                rpt.ShowZoomControl = true;
                ViewBag.rpt = rpt;
                return View();
            }
            return RptLibrosAlquilados();
        }
        [Authorize(Roles = "Reportero,Admin")]
        public ActionResult RptVisitasClientes()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RptVisitasClientes(string Desde = "")
        {
            if (Desde != "")
            {
                VisitasDeClientesPorMesTableAdapter dt = new VisitasDeClientesPorMesTableAdapter();
                ReportViewer rpt = new ReportViewer();
                rpt.ProcessingMode = ProcessingMode.Local;
                rpt.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reportes/RptVisitaClientes.rdlc";
                rpt.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt.GetData(DateTime.Parse(Desde)).OrderBy(o => o.Alquileres).ToList()));
                rpt.SizeToReportContent = true;
                rpt.ShowPrintButton = true;
                rpt.ShowZoomControl = true;
                ViewBag.rpt = rpt;
                return View();
            }
            else
                return RptVisitasClientes();
        }

        [Authorize(Roles = "Reportero,Admin")]
        public ActionResult RptAlquileresPendientes()
        {

            AlquilerespendientesTableAdapter dt = new AlquilerespendientesTableAdapter();
            ReportViewer rpt = new ReportViewer();
            rpt.ProcessingMode = ProcessingMode.Local;
            rpt.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reportes/RptAlquileresPendientes.rdlc";
            rpt.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt.GetData().ToList()));
            rpt.SizeToReportContent = true;
            rpt.ShowPrintButton = true;
            rpt.ShowZoomControl = true;
            ViewBag.rpt = rpt;
            return View();
        }

        [Authorize(Roles = "Reportero,Admin")]
        public ActionResult RptLibrosPrestados(int idCli = 0, string Desde = "", string Hasta = "", string Nombre = "")
        {
            LibrosPrestadosTableAdapter dt = new LibrosPrestadosTableAdapter();
            ReportViewer rpt = new ReportViewer();
            rpt.ProcessingMode = ProcessingMode.Local;
            rpt.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reportes/RptLibrosPrestados.rdlc";
            rpt.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt.GetData(idCli, DateTime.Parse(Desde), DateTime.Parse(Hasta)).ToList()));
            rpt.SizeToReportContent = true;
            rpt.ShowPrintButton = true;
            rpt.ShowZoomControl = true;
            ViewBag.rpt = rpt;
            rpt.LocalReport.SetParameters(new ReportParameter("Nombre", Nombre));
            return View();
        }

    }
}