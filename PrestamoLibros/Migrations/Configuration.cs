namespace PrestamoLibros.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using PrestamoLibros.Models;


    internal sealed class Configuration : DbMigrationsConfiguration<PrestamoLibros.Models.Cartera>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "PrestamoLibros.Models.Cartera";

        }

        protected override void Seed(PrestamoLibros.Models.Cartera context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //



            /*********************************************
             * * Agregando semillas del proyecto * * 
             ********************************************/
            context.Materias.AddOrUpdate(
                m => m.CodigoDeMateria,
                new Materia { CodigoDeMateria = "100", DescripcionDeMateria = "Lengua y Literatura" },
                new Materia { CodigoDeMateria = "101", DescripcionDeMateria = "Ciencias Sociales" },
                new Materia { CodigoDeMateria = "102", DescripcionDeMateria = "Lengua Extranjera" },
                new Materia { CodigoDeMateria = "103", DescripcionDeMateria = "Ciencias Naturales" },
                new Materia { CodigoDeMateria = "104", DescripcionDeMateria = "Informática" },
                new Materia { CodigoDeMateria = "105", DescripcionDeMateria = "Matemática" }
                );
            context.SaveChanges();

            context.Clientes.AddOrUpdate(
                c => c.CodigoDeCliente,
                new Cliente { CodigoDeCliente = "100", NombresDelCliente = "Margarita", ApellidosDelCliente = "López" },
                new Cliente { CodigoDeCliente = "101", NombresDelCliente = "Olga", ApellidosDelCliente = "Mendéz" },
                new Cliente { CodigoDeCliente = "102", NombresDelCliente = "Camilo", ApellidosDelCliente = "Cadenas" },
                new Cliente { CodigoDeCliente = "103", NombresDelCliente = "Uman", ApellidosDelCliente = "Umanzor" },
                new Cliente { CodigoDeCliente = "104", NombresDelCliente = "Will", ApellidosDelCliente = "Iam" },
                new Cliente { CodigoDeCliente = "105", NombresDelCliente = "Lia", ApellidosDelCliente = "Villegas" },
                new Cliente { CodigoDeCliente = "106", NombresDelCliente = "Karla", ApellidosDelCliente = "Torrez" },
                new Cliente { CodigoDeCliente = "107", NombresDelCliente = "Cecilia", ApellidosDelCliente = "Martínez" },
                new Cliente { CodigoDeCliente = "108", NombresDelCliente = "Francisco", ApellidosDelCliente = "Umaña" },
                new Cliente { CodigoDeCliente = "109", NombresDelCliente = "Zamira", ApellidosDelCliente = "Espinoza" }
                );
            context.SaveChanges();

            context.Libros.AddOrUpdate(
                l => l.CodigoDeLibro,
                new Libro { CodigoDeLibro = "100", ISBN = "7894561236985", TituloDeLibro = "Azul", Autor = "Rubén Darío", MateriaId = 1 },
                new Libro { CodigoDeLibro = "101", ISBN = "4485621999878", TituloDeLibro = "Mi cuerpo y yo", Autor = "Marco Polo", MateriaId = 4 },
                new Libro { CodigoDeLibro = "102", ISBN = "2147895423666", TituloDeLibro = "Top Notch", Autor = "Kenia Kingstone", MateriaId = 3 },
                new Libro { CodigoDeLibro = "103", ISBN = "8795564654544", TituloDeLibro = "Historia", Autor = "Pedro el Escamoso", MateriaId = 2 },
                new Libro { CodigoDeLibro = "104", ISBN = "7541698563332", TituloDeLibro = "El gran libro de HTML y CSS3", Autor = "Camilo Sesto", MateriaId = 5 },
                new Libro { CodigoDeLibro = "105", ISBN = "7878787878788", TituloDeLibro = "Herramientas CASE", Autor = "Kimball Tercero", MateriaId = 5 },
                new Libro { CodigoDeLibro = "106", ISBN = "1458746923354", TituloDeLibro = "Baldor", Autor = "Juan Baldor", MateriaId = 6 },
                new Libro { CodigoDeLibro = "107", ISBN = "4115454687978", TituloDeLibro = "Implementación de un DW empresarial", Autor = "Hefesto Quinto", MateriaId = 5 },
                new Libro { CodigoDeLibro = "108", ISBN = "4256548978798", TituloDeLibro = "Lengua, Comunicación y Literatura", Autor = "Pedro Franco", MateriaId = 1 },
                new Libro { CodigoDeLibro = "109", ISBN = "2020202020202", TituloDeLibro = "Nuestro Idioma", Autor = "Matus Lazo", MateriaId = 1 },
                new Libro { CodigoDeLibro = "110", ISBN = "5254689774466", TituloDeLibro = "La Fauna y Flora", Autor = "Pedro Joaquín Chamorro", MateriaId = 4 },
                new Libro { CodigoDeLibro = "111", ISBN = "8785454654585", TituloDeLibro = "Aprender a sumar cantidades de 1 dígitos", Autor = "Osscar Loro", MateriaId = 6 },
                new Libro { CodigoDeLibro = "112", ISBN = "2245678788887", TituloDeLibro = "Lengua y Literatura I", Autor = "Diego Maradona", MateriaId = 1 },
                new Libro { CodigoDeLibro = "113", ISBN = "2245678788884", TituloDeLibro = "Lengua y Literatura II", Autor = "Diego Maradona", MateriaId = 1 },
                new Libro { CodigoDeLibro = "114", ISBN = "0987654322228", TituloDeLibro = "La selección natural", Autor = "Camilo Zapata", MateriaId = 4 },
                new Libro { CodigoDeLibro = "115", ISBN = "8734578798454", TituloDeLibro = "Summit I", Autor = "Katy Perry", MateriaId = 3 },
                new Libro { CodigoDeLibro = "116", ISBN = "1565487878785", TituloDeLibro = "Summit II", Autor = "Katy Perry", MateriaId = 3 },
                new Libro { CodigoDeLibro = "117", ISBN = "2254787995000", TituloDeLibro = "Summit III", Autor = "Katy Perry", MateriaId = 3 },
                new Libro { CodigoDeLibro = "118", ISBN = "6987451112250", TituloDeLibro = "Historia de Nicaragua", Autor = "Pancho Madrigal", MateriaId = 2 },
                new Libro { CodigoDeLibro = "119", ISBN = "0000000000000", TituloDeLibro = "Java Programming", Autor = "Elon Musk", MateriaId = 5 },
                new Libro { CodigoDeLibro = "120", ISBN = "4444444444444", TituloDeLibro = "HTML for Babys", Autor = "Avicci", MateriaId = 5 },
                new Libro { CodigoDeLibro = "121", ISBN = "5458789951111", TituloDeLibro = "Geometría Euclidiana", Autor = "Kim Kardashian", MateriaId = 6 },
                new Libro { CodigoDeLibro = "122", ISBN = "4115454687978", TituloDeLibro = "Python for Dummies", Autor = "Josiel Valle", MateriaId = 5 },
                new Libro { CodigoDeLibro = "123", ISBN = "8887851005789", TituloDeLibro = "La historia de la tilde", Autor = "Winnie The Pooh", MateriaId = 1 },
                new Libro { CodigoDeLibro = "124", ISBN = "9854123878786", TituloDeLibro = "Poesia vacía", Autor = "Gioconda Belli", MateriaId = 1 },
                new Libro { CodigoDeLibro = "125", ISBN = "5254689774466", TituloDeLibro = "El medio ambiente y yo", Autor = "Kathya Katiuska", MateriaId = 4 },
                new Libro { CodigoDeLibro = "126", ISBN = "8785454654585", TituloDeLibro = "Como pasar Cálculo II en paralelo", Autor = "Danilo Zeledón", MateriaId = 6 }
                );
            context.SaveChanges();

            context.CopiasDelibro.AddOrUpdate(
                cl => cl.NumeroCopia,
                new CopiaDeLibro { NumeroCopia = 1, LibroId = 1 },
                new CopiaDeLibro { NumeroCopia = 2, LibroId = 1 },
                new CopiaDeLibro { NumeroCopia = 1, LibroId = 2 },
                new CopiaDeLibro { NumeroCopia = 2, LibroId = 2 },
                new CopiaDeLibro { NumeroCopia = 1, LibroId = 3 },
                new CopiaDeLibro { NumeroCopia = 2, LibroId = 3 },
                new CopiaDeLibro { NumeroCopia = 1, LibroId = 4 },
                new CopiaDeLibro { NumeroCopia = 2, LibroId = 4 },
                new CopiaDeLibro { NumeroCopia = 1, LibroId = 5 },
                new CopiaDeLibro { NumeroCopia = 2, LibroId = 5 },
                new CopiaDeLibro { NumeroCopia = 1, LibroId = 6 },
                new CopiaDeLibro { NumeroCopia = 2, LibroId = 6 },
                new CopiaDeLibro { NumeroCopia = 1, LibroId = 7 },
                new CopiaDeLibro { NumeroCopia = 2, LibroId = 7 },
                new CopiaDeLibro { NumeroCopia = 1, LibroId = 8 },
                new CopiaDeLibro { NumeroCopia = 2, LibroId = 8 },
                new CopiaDeLibro { NumeroCopia = 1, LibroId = 9 },
                new CopiaDeLibro { NumeroCopia = 2, LibroId = 9 },
                new CopiaDeLibro { NumeroCopia = 1, LibroId = 10 },
                new CopiaDeLibro { NumeroCopia = 2, LibroId = 10 },
                new CopiaDeLibro { NumeroCopia = 1, LibroId = 11 },
                new CopiaDeLibro { NumeroCopia = 2, LibroId = 11 },
                new CopiaDeLibro { NumeroCopia = 1, LibroId = 12 },
                new CopiaDeLibro { NumeroCopia = 2, LibroId = 12 },
                new CopiaDeLibro { NumeroCopia = 1, LibroId = 13 },
                new CopiaDeLibro { NumeroCopia = 1, LibroId = 14 },
                new CopiaDeLibro { NumeroCopia = 2, LibroId = 14 },
                new CopiaDeLibro { NumeroCopia = 1, LibroId = 15 },
                new CopiaDeLibro { NumeroCopia = 2, LibroId = 15 },
                new CopiaDeLibro { NumeroCopia = 1, LibroId = 16 },
                new CopiaDeLibro { NumeroCopia = 1, LibroId = 17 },
                new CopiaDeLibro { NumeroCopia = 2, LibroId = 17 },
                new CopiaDeLibro { NumeroCopia = 1, LibroId = 18 },
                new CopiaDeLibro { NumeroCopia = 2, LibroId = 18 },
                new CopiaDeLibro { NumeroCopia = 1, LibroId = 19 },
                new CopiaDeLibro { NumeroCopia = 1, LibroId = 20 },
                new CopiaDeLibro { NumeroCopia = 1, LibroId = 21 },
                new CopiaDeLibro { NumeroCopia = 1, LibroId = 22 },
                new CopiaDeLibro { NumeroCopia = 1, LibroId = 23 },
                new CopiaDeLibro { NumeroCopia = 1, LibroId = 24 },
                new CopiaDeLibro { NumeroCopia = 1, LibroId = 25 },
                new CopiaDeLibro { NumeroCopia = 2, LibroId = 25 },
                new CopiaDeLibro { NumeroCopia = 1, LibroId = 26 },
                new CopiaDeLibro { NumeroCopia = 1, LibroId = 27 },
                new CopiaDeLibro { NumeroCopia = 2, LibroId = 27 }
                );
            context.SaveChanges();

            context.AlquileresDeLibro.AddOrUpdate(
                al => al.CodigoAlquiler,
                new AlquilerDeLibro { CodigoAlquiler = "100", FechaAlquiler = new DateTime(2018, 1, 14), FechaRealDevolucion = new DateTime(2018, 1, 19), CopiaId = 1, ClienteId = 1 },
                new AlquilerDeLibro { CodigoAlquiler = "101", FechaAlquiler = new DateTime(2018, 1, 14), FechaRealDevolucion = new DateTime(2018, 1, 18), CopiaId = 2, ClienteId = 2 },
                new AlquilerDeLibro { CodigoAlquiler = "102", FechaAlquiler = new DateTime(2018, 1, 14), FechaRealDevolucion = new DateTime(2018, 1, 30), CopiaId = 3, ClienteId = 3 },
                new AlquilerDeLibro { CodigoAlquiler = "103", FechaAlquiler = new DateTime(2018, 1, 16), FechaRealDevolucion = new DateTime(2018, 1, 30), CopiaId = 4, ClienteId = 4 },
                new AlquilerDeLibro { CodigoAlquiler = "104", FechaAlquiler = new DateTime(2018, 1, 17), FechaRealDevolucion = new DateTime(2018, 2, 01), CopiaId = 5, ClienteId = 1 },
                new AlquilerDeLibro { CodigoAlquiler = "105", FechaAlquiler = new DateTime(2018, 1, 17), FechaRealDevolucion = new DateTime(2018, 2, 03), CopiaId = 6, ClienteId = 2 },
                new AlquilerDeLibro { CodigoAlquiler = "106", FechaAlquiler = new DateTime(2018, 1, 18), FechaRealDevolucion = new DateTime(2018, 2, 03), CopiaId = 7, ClienteId = 5 },
                new AlquilerDeLibro { CodigoAlquiler = "107", FechaAlquiler = new DateTime(2018, 1, 20), FechaRealDevolucion = new DateTime(2018, 2, 03), CopiaId = 8, ClienteId = 6 },
                new AlquilerDeLibro { CodigoAlquiler = "108", FechaAlquiler = new DateTime(2018, 1, 25), FechaRealDevolucion = new DateTime(2018, 2, 03), CopiaId = 9, ClienteId = 3 },
                new AlquilerDeLibro { CodigoAlquiler = "109", FechaAlquiler = new DateTime(2018, 1, 25), FechaRealDevolucion = new DateTime(2018, 2, 05), CopiaId = 10, ClienteId = 7 },
                new AlquilerDeLibro { CodigoAlquiler = "110", FechaAlquiler = new DateTime(2018, 1, 27), FechaRealDevolucion = new DateTime(2018, 2, 06), CopiaId = 11, ClienteId = 2 },
                new AlquilerDeLibro { CodigoAlquiler = "111", FechaAlquiler = new DateTime(2018, 1, 30), FechaRealDevolucion = new DateTime(2018, 2, 06), CopiaId = 12, ClienteId = 1 },
                new AlquilerDeLibro { CodigoAlquiler = "112", FechaAlquiler = new DateTime(2018, 1, 31), FechaRealDevolucion = new DateTime(2018, 2, 06), CopiaId = 13, ClienteId = 5 },
                new AlquilerDeLibro { CodigoAlquiler = "113", FechaAlquiler = new DateTime(2018, 2, 02), FechaRealDevolucion = new DateTime(2018, 2, 10), CopiaId = 14, ClienteId = 1 },
                new AlquilerDeLibro { CodigoAlquiler = "114", FechaAlquiler = new DateTime(2018, 2, 02), FechaRealDevolucion = new DateTime(2018, 2, 10), CopiaId = 4, ClienteId = 5 },

                new AlquilerDeLibro { CodigoAlquiler = "115", FechaAlquiler = new DateTime(2018, 2, 03), FechaRealDevolucion = new DateTime(1900, 01, 01), CopiaId = 10, ClienteId = 1 },
                new AlquilerDeLibro { CodigoAlquiler = "116", FechaAlquiler = new DateTime(2018, 2, 03), FechaRealDevolucion = new DateTime(1900, 01, 01), CopiaId = 2, ClienteId = 7 },
                new AlquilerDeLibro { CodigoAlquiler = "117", FechaAlquiler = new DateTime(2018, 2, 03), FechaRealDevolucion = new DateTime(1900, 01, 01), CopiaId = 1, ClienteId = 5 },
                new AlquilerDeLibro { CodigoAlquiler = "118", FechaAlquiler = new DateTime(2018, 2, 05), FechaRealDevolucion = new DateTime(2018, 02, 08), CopiaId = 14, ClienteId = 3 },
                new AlquilerDeLibro { CodigoAlquiler = "119", FechaAlquiler = new DateTime(2018, 2, 06), FechaRealDevolucion = new DateTime(1900, 01, 01), CopiaId = 13, ClienteId = 2 },
                new AlquilerDeLibro { CodigoAlquiler = "120", FechaAlquiler = new DateTime(2018, 2, 06), FechaRealDevolucion = new DateTime(2018, 02, 10), CopiaId = 6, ClienteId = 3 },
                new AlquilerDeLibro { CodigoAlquiler = "121", FechaAlquiler = new DateTime(2018, 2, 06), FechaRealDevolucion = new DateTime(2018, 02, 10), CopiaId = 7, ClienteId = 4 },
                new AlquilerDeLibro { CodigoAlquiler = "122", FechaAlquiler = new DateTime(2018, 2, 07), FechaRealDevolucion = new DateTime(2018, 02, 12), CopiaId = 9, ClienteId = 6 },
                new AlquilerDeLibro { CodigoAlquiler = "123", FechaAlquiler = new DateTime(2018, 2, 07), FechaRealDevolucion = new DateTime(2018, 02, 11), CopiaId = 3, ClienteId = 6 }                
                );
            context.SaveChanges();







        }
    }
}
