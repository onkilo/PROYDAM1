//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Datos.SqlServer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Intercambio
    {
        public int IdIntercambio { get; set; }
        public Nullable<int> IdUsuIni { get; set; }
        public Nullable<int> IdUsuDestino { get; set; }
        public string Direccion { get; set; }
        public Nullable<System.DateTime> FechaIniciado { get; set; }
        public string HoraIntercambio { get; set; }
        public Nullable<System.DateTime> FechaAceptado { get; set; }
        public Nullable<int> IdLibroElegido { get; set; }
        public Nullable<int> IdLibroOfrecido { get; set; }
        public string Activo { get; set; }
        public string Estado { get; set; }
    
        public virtual Libro Libro { get; set; }
        public virtual Libro Libro1 { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Usuario Usuario1 { get; set; }
    }
}
