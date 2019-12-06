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
    public class IntercambioManager
    {
        FarumEntities context = new FarumEntities();

        public List<IntercambioBE> GetByIniciador(int id)
        {
            List<IntercambioBE> intercambios = new List<IntercambioBE>();
            List<Intercambio> aux = new List<Intercambio>();
            aux = context.Intercambio
                .Where(i => i.IdUsuIni == id)
                .ToList();

            foreach(Intercambio i in aux)
            {
                intercambios.Add(Utilities.ReadIntercambio(i));
            }

            return intercambios;
        }

        public List<IntercambioBE> GetByReceptor(int id)
        {
            List<IntercambioBE> intercambios = new List<IntercambioBE>();
            List<Intercambio> aux = new List<Intercambio>();
            aux = context.Intercambio
                .Where(i => i.IdUsuDestino == id)
                .ToList();

            foreach (Intercambio i in aux)
            {
                intercambios.Add(Utilities.ReadIntercambio(i));
            }

            return intercambios;
        }

        public void Insert(IntercambioBE intercambio)
        {
            Intercambio i = new Intercambio();
            if(intercambio != null)
            {
                i = new Intercambio
                {
                    IdUsuIni = intercambio.IdUsuIni,
                    IdUsuDestino = intercambio.IdUsuDestino,
                    Direccion = intercambio.Direccion,
                    FechaIniciado = intercambio.FechaIniciado,
                    FechaIntercambio = intercambio.FechaIntercambio,
                    HoraIntercambio = intercambio.HoraIntercambio,
                    IdLibroElegido = intercambio.IdLibroElegido,
                    IdLibroOfrecido = intercambio.IdLibroOfrecido,
                    Activo = "01",
                    Estado = "01" // Estado de Iniciado
                };
                context.Intercambio.Add(i);
                context.SaveChanges();
            }
        }

        public IntercambioBE Find(int id)
        {
            IntercambioBE intercambio = new IntercambioBE();
            Intercambio i = context.Intercambio.Find(id);
            if(i != null)
            {
                intercambio = Utilities.ReadIntercambio(i);
            }

            return intercambio;
        }

        //Acepta o rechaza el Intercambio
        public void CambiaEstadoInter(int id, string estado)
        {
            Intercambio i = context.Intercambio.Find(id);
            i.Estado = estado;
            context.Entry(i).State = EntityState.Modified;
            context.SaveChanges();
            if(estado == "02")
            {
                Libro lElegido = context.Libro.Find(i.IdLibroElegido);
                lElegido.Activo = "00";

                Libro lOfrecido = context.Libro.Find(i.IdLibroOfrecido);
                lOfrecido.Activo = "00";

                context.Entry(lOfrecido).State = EntityState.Modified;
                context.Entry(lElegido).State = EntityState.Modified;

                context.SaveChanges();
            }

        }

        private IntercambioBE ReadIntercambio(Intercambio i)
        {
            IntercambioBE intercambio = new IntercambioBE();
            if(i != null)
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
