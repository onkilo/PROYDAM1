using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class LibroBE
    {
        public int IdLibro { get; set; }
        public string Nombre { get; set; }
        public string Resenia { get; set; }
        public string Imagen { get; set; }
        public Nullable<System.DateTime> FechaRegistro { get; set; }
        public Nullable<System.DateTime> FechaAdquisicion { get; set; }
        public string Estado { get; set; }
        public Nullable<int> IdGenero { get; set; }
        public Nullable<int> IdAutor { get; set; }
        public Nullable<int> IdUsuario { get; set; }
        public string Activo { get; set; }

        public string Imagen64 { get; set; }

        public AutorBE Autor { get; set; }
        public GeneroBE Genero { get; set; }
        public UsuarioBE Usuario { get; set; }
    }
}
