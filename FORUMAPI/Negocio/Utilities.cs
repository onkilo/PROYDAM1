using Datos.SqlServer;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public static class Utilities
    {
        //Lectura de LibroBE desde Libro
        public static LibroBE ReadLibro(Libro l)
        {
            LibroBE libro = new LibroBE();
            if (libro != null)
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


        //Lectura de UsuarioBE desde Usuario
        public static UsuarioBE ReadUsuario(Usuario u)
        {
            UsuarioBE usuario = new UsuarioBE();
            if(u != null)
            {
                usuario = new UsuarioBE()
                {
                    IdUsuario = u.IdUsuario,
                    Activo = u.Activo,
                    Correo = u.Correo,
                    Direccion = u.Direccion,
                    Nombre = u.Nombre,
                    Telefono = u.Telefono
                };
            }

            return usuario;
        }


        //Lectura de IntercambioBE desde Intercambio
        public static IntercambioBE ReadIntercambio(Intercambio i)
        {
            IntercambioBE intercambio = new IntercambioBE();
            if (i != null)
            {
                intercambio = new IntercambioBE
                {
                    IdIntercambio = i.IdIntercambio,
                    IdUsuIni = i.IdUsuIni,
                    IdUsuDestino = i.IdUsuDestino,
                    Direccion = i.Direccion,
                    FechaIniciado = i.FechaIniciado,
                    FechaIntercambio = i.FechaIntercambio,
                    IdLibroElegido = i.IdLibroElegido,
                    IdLibroOfrecido = i.IdLibroOfrecido,
                    HoraIntercambio = i.HoraIntercambio,
                    Activo = i.Activo,
                    Estado = i.Estado,
                    LibroElegido = Utilities.ReadLibro(i.Libro),
                    LibroOfrecido = Utilities.ReadLibro(i.Libro1),
                    UsuInicial = Utilities.ReadUsuario(i.Usuario1),
                    UsuDestino = Utilities.ReadUsuario(i.Usuario)

                };
            }

            return intercambio;
        }
    }
}
