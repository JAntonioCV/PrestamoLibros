using System.Web;
using System.Web.Optimization;

namespace PrestamoLibros
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui.min.js",
                        "~/Scripts/FechaEspanol.js",
                        "~/Scripts/CargarCombo.js",
                        "~/Scripts/jquery.unobtrusive-ajax.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/webgrid.css",
                      "~/Content/jquery-ui.css",
                      "~/Content/menubootstrapNiveles.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/Busqueda").Include(
                      "~/Scripts/Busqueda.js"));

            bundles.Add(new ScriptBundle("~/bundles/prestamo").Include(
                      "~/Scripts/prestamo.js"));




        }
    }
}
