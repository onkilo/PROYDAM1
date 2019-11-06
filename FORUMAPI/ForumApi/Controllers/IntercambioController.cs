using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ForumApi.Controllers
{
    public class IntercambioController : ApiController
    {
        IntercambioManager manager = new IntercambioManager();
        // GET: api/Intercambio
        [HttpGet]
        [Route("api/Intercambio/Iniciador/{iduser}")]
        public IEnumerable<IntercambioBE> GetByIniciador(int idUser)
        {
            return manager.GetByIniciador(idUser);
        }

        [HttpGet]
        [Route("api/Intercambio/Receptor/{iduser}")]
        public IEnumerable<IntercambioBE> GetByReceptor(int idUser)
        {
            return manager.GetByReceptor(idUser);
        }

        [HttpPost]
        [Route("api/Intercambio/{idInt}/Estado")]
        public void CambiaEstadoInter(int idInt, IntercambioBE intercambio)
        {
            manager.CambiaEstadoInter(idInt, intercambio.Estado);
        }

        public IntercambioBE Get(int id)
        {
            return manager.Find(id);
        }

        // POST: api/Intercambio
        public void Post(IntercambioBE intercambio)
        {
            manager.Insert(intercambio);
        }

       

        
    }
}
