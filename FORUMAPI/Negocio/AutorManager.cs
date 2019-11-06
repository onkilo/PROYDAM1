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
    public class AutorManager
    {
        FarumEntities context = new FarumEntities();

        public List<AutorBE> GetAll()
        {
            List<AutorBE> autores = new List<AutorBE>();
            autores = context.Autor
                .Where(a => a.Activo == "01")
                .Select(a => new AutorBE
                {
                    IdAutor = a.IdAutor,
                    Nombres = a.Nombres,
                    Activo = a.Activo
                }).ToList();

            return autores;
        }

        public AutorBE Find(int id)
        {
            AutorBE autor = new AutorBE();
            Autor a = context.Autor.Find(id);
            if(a != null)
            {
                autor = new AutorBE
                {
                    IdAutor = a.IdAutor,
                    Nombres = a.Nombres,
                    Activo = a.Activo
                };
            }
            return autor;
        }

        public void Insert(AutorBE autor)
        {
            Autor a = new Autor
            {
                Nombres = autor.Nombres,
                Activo = "01"
            };
            context.Autor.Add(a);
            context.SaveChanges();
        }

        public void Update(AutorBE autor)
        {
            Autor a = new Autor
            {
                IdAutor = autor.IdAutor,
                Nombres = autor.Nombres,
                Activo = "01"
            };
            context.Entry(a).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Autor a = context.Autor.Find(id);
            a.Activo = "00";
            context.Entry(a).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
