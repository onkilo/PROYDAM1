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
    public class GeneroManager
    {

        ForumEntities context = new ForumEntities();

        public List<GeneroBE> GetAll()
        {
            List<GeneroBE> generos = context.Genero
                .Where(g => g.Activo == "01")
                .Select(g => new GeneroBE
                {
                    IdGenero = g.IdGenero,
                    Descripcion = g.Descripcion,
                    Activo = g.Activo
                }).ToList();

            return generos;
        }

        public void Insert(GeneroBE generoBE)
        {
            Genero genero = new Genero()
            {
                Descripcion = generoBE.Descripcion,
                Activo = "01"
            };
            context.Genero.Add(genero);
            context.SaveChanges();
        }

        public void Update(GeneroBE generoBE)
        {
            Genero genero = new Genero()
            {
                IdGenero = generoBE.IdGenero,
                Descripcion = generoBE.Descripcion,
                Activo = "01"
            };
            context.Entry(genero).State = EntityState.Modified;
            context.SaveChanges();
        }


        public void Delete(int id)
        {
            try
            {
                Genero genero = context.Genero.Find(id);
                genero.Activo = "00";
                context.Entry(genero).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public GeneroBE Find(int id)
        {
            Genero genero = context.Genero.Find(id);

            return new GeneroBE()
            {
                IdGenero = genero.IdGenero,
                Descripcion = genero.Descripcion,
                Activo = genero.Activo
            };
        }
    }
}
