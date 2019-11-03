using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class IntercambioBE
    {
        public int IdIntercambio { get; set; }
        public Nullable<int> IdUsuIni { get; set; }
        public Nullable<int> IdUsuDestino { get; set; }
        public string Direccion { get; set; }
        public Nullable<System.DateTime> FechaIniciado { get; set; }
        public Nullable<System.DateTime> FechaAceptado { get; set; }
        public Nullable<int> IdLibro { get; set; }
        public string Activo { get; set; }
        public string Estado { get; set; }

        public virtual LibroBE Libro { get; set; }
        public virtual UsuarioBE UsuInicial { get; set; }
        public virtual UsuarioBE UsuDestino { get; set; }
    }
}
