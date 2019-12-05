using Datos.SqlServer;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class LibroManager
    {
        FarumEntities context = new FarumEntities();

        public List<LibroBE> GetNotByUser(int idUser)
        {
            List<LibroBE> libros = new List<LibroBE>();
            List<Libro> aux = context.Libro
                .Where(l => l.Activo == "01" && l.IdUsuario != idUser)
                .ToList();

            foreach (Libro l in aux)
            {
                libros.Add(Utilities.ReadLibro(l));
            }

            return libros;
        }

        public List<LibroBE> GetByUser(int idUser)
        {
            List<LibroBE> libros = new List<LibroBE>();
            List<Libro> aux = context.Libro
                .Where(l => l.Activo == "01" && l.IdUsuario == idUser)
                .ToList();

            foreach (Libro l in aux)
            {
                libros.Add(Utilities.ReadLibro(l));
            }
            
            return libros;
        }

        public List<LibroBE> GetByGenero(int idGenero)
        {
            List<LibroBE> libros = new List<LibroBE>();
            List<Libro> aux = context.Libro
                .Where(l => l.Activo == "01" && l.IdGenero == idGenero)
                .ToList();

            foreach (Libro l in aux)
            {
                libros.Add(Utilities.ReadLibro(l));
            }
            return libros;
        }

        public List<LibroBE> GetByGeneroNoUsuario(int idGenero, int idUsuario)
        {
            List<LibroBE> libros = new List<LibroBE>();
            List<Libro> aux = context.Libro
                .Where(l => l.Activo == "01" && l.IdGenero == idGenero && l.IdUsuario !=idUsuario)
                .ToList();

            foreach (Libro l in aux)
            {
                libros.Add(Utilities.ReadLibro(l));
            }
            return libros;
        }

        public List<LibroBE> GetByNombre(string nombre)
        {
            List<LibroBE> libros = new List<LibroBE>();
            List<Libro> aux = context.Libro
                .Where(l => l.Activo == "01" && l.Nombre.Contains(nombre))
                .ToList();

            foreach (Libro l in aux)
            {
                libros.Add(Utilities.ReadLibro(l));
            }

            return libros;
        }

        public List<LibroBE> GetByNombreNoUsuario(int idUsuario, string nombre)
        {
            List<LibroBE> libros = new List<LibroBE>();
            List<Libro> aux = context.Libro
                .Where(l => l.Activo == "01" && l.Nombre.Contains(nombre) && l.IdUsuario != idUsuario)
                .ToList();

            foreach (Libro l in aux)
            {
                libros.Add(Utilities.ReadLibro(l));
            }

            return libros;
        }

        public void Insert(LibroBE libro)
        {
            Libro l = new Libro
            {
                Nombre = libro.Nombre,
                Resenia = libro.Resenia,
                Imagen = libro.Imagen,
                FechaRegistro = libro.FechaRegistro,
                FechaAdquisicion = libro.FechaAdquisicion,
                Estado = libro.Estado,
                IdGenero = libro.IdGenero,
                IdAutor = libro.IdAutor,
                IdUsuario = libro.IdUsuario,
                Activo = "01"
            };
            context.Libro.Add(l);
            context.SaveChanges();
        }

        public void Update(LibroBE libro)
        {
            Libro l = new Libro
            {
                IdLibro = libro.IdLibro,
                Nombre = libro.Nombre,
                Resenia = libro.Resenia,
                Imagen = libro.Imagen,
                FechaRegistro = libro.FechaRegistro,
                FechaAdquisicion = libro.FechaAdquisicion,
                Estado = libro.Estado,
                IdGenero = libro.IdGenero,
                IdAutor = libro.IdAutor,
                IdUsuario = libro.IdUsuario,
                Activo = "01"
            };
            context.Entry(l).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Libro l = context.Libro.Find(id);
            l.Activo = "00";
            context.Entry(l).State = EntityState.Modified;
            context.SaveChanges();
        }

        public LibroBE Find(int id)
        {
            LibroBE libro = new LibroBE();
            Libro l = context.Libro.Find(id);
            if(l != null)
            {
                libro = ReadLibro(l);
            }

            return libro;
        }


        //Lectura de LibroBE desde Libro
        private LibroBE ReadLibro(Libro l)
        {
            LibroBE libro = new LibroBE();
            if(libro != null)
            {
                libro = new LibroBE
                {
                    IdLibro = l.IdLibro,
                    Nombre = l.Nombre,
                    Resenia = l.Resenia,
                    Imagen = l.Imagen,
                    FechaAdquisicion = l.FechaAdquisicion,
                    FechaRegistro = l.FechaRegistro,
                    Estado = l.Estado,
                    IdGenero = l.IdGenero,
                    IdAutor = l.IdAutor,
                    IdUsuario = l.IdUsuario,
                    Activo = l.Activo,
                    Autor = new AutorBE
                    {
                        IdAutor = l.Autor.IdAutor,
                        Nombres = l.Autor.Nombres
                    },
                    Genero = new GeneroBE
                    {
                        IdGenero = l.Genero.IdGenero,
                        Descripcion = l.Genero.Descripcion
                    },
                    Usuario = new UsuarioBE
                    {
                        IdUsuario = l.Usuario.IdUsuario,
                        Nombre = l.Usuario.Nombre
                    }
                };
            }

            return libro;
        }
    }
}
