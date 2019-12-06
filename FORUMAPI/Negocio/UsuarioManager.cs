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
    public class UsuarioManager
    {
        FarumEntities context = new FarumEntities();
        public List<UsuarioBE> GetAll()
        {
            List<UsuarioBE> usuarios = new List<UsuarioBE>();
            usuarios = context.Usuario
                .Where(u => u.Activo == "01")
                .Select(u => new UsuarioBE()
            {
                IdUsuario = u.IdUsuario,
                Activo = u.Activo,
                Correo = u.Correo,
                Direccion = u.Direccion,
                Nombre = u.Nombre,
                Telefono = u.Telefono
            }).ToList();

            return usuarios;
        }

        public UsuarioBE Find(int id)
        {
            UsuarioBE usuario = new UsuarioBE();

            Usuario u = context.Usuario.Find(id);
            if( u != null)
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

        public void Insert(UsuarioBE usuario)
        {
            Usuario u = new Usuario
            {
                Nombre = usuario.Nombre,
                Contrasenia = usuario.Contrasenia,
                Direccion = usuario.Direccion,
                Correo = usuario.Correo,
                Telefono = usuario.Telefono,
                Activo = "01"
            };

            context.Usuario.Add(u);
            context.SaveChanges();
        }

        public void Udpate(UsuarioBE usuario)
        {
            Usuario u = new Usuario
            {
                IdUsuario = usuario.IdUsuario,
                Nombre = usuario.Nombre,
                Contrasenia = usuario.Contrasenia,
                Direccion = usuario.Direccion,
                Correo = usuario.Correo,
                Telefono = usuario.Telefono,
                Activo = "01"
            };

            context.Entry(u).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Usuario u = context.Usuario.Find(id);
            u.Activo = "00";
            context.Entry(u).State = EntityState.Modified;
            context.SaveChanges();
        }

        public UsuarioBE Login(string correo, string pass)
        {
            UsuarioBE usuario = new UsuarioBE();
            Usuario u = context.Usuario
                .Where(usu => usu.Correo == correo && usu.Contrasenia == pass)
                .FirstOrDefault();
            if (u != null)
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

        public void ActualizarDatos(UsuarioBE usuario)
        {
            Usuario u = context.Usuario.Find(usuario.IdUsuario);
            u.Nombre = usuario.Nombre;
            u.Correo = usuario.Correo;
            u.Telefono = usuario.Telefono;
            u.Direccion = usuario.Direccion;
            u.Activo = "01";

            context.Entry(u).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
