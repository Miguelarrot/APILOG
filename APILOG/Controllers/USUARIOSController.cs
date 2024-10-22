using Conector;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
namespace APILOG.Controllers
{
    public class UsuariosController : ApiController
    {
        // GET: api/Usuarios
        public IEnumerable<USUARIOS> Get()
        {
            using (ELCONTENTOEntities objEntidad = new ELCONTENTOEntities())
            {
                return objEntidad.USUARIOS.ToList();
            }
        }


        // GET: api/Usuarios/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Usuarios
        public HttpResponseMessage Post([FromBody] USUARIOS objCuenta)
        {
            int resp = 0;
            HttpResponseMessage objMenRespuesta = null;
            try
            {
                using (ELCONTENTOEntities objEntidad = new ELCONTENTOEntities())
                {
                    objEntidad.Entry(objCuenta).State = EntityState.Added;
                    resp = objEntidad.SaveChanges();
                    objMenRespuesta = Request.CreateResponse(HttpStatusCode.OK, resp);
                }
            }
            catch (Exception er)
            {
                objMenRespuesta = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, er.Message);
            }
            return objMenRespuesta;
        }


        // PUT: api/Usuarios/5
        public HttpResponseMessage Put([FromBody] USUARIOS objUsuarios)
        {
            EntityState operacion = EntityState.Modified;
            return opercion(objUsuarios, operacion);
        }
        // DELETE: api/Usuarios/5
        public HttpResponseMessage Delete([FromBody] USUARIOS objUsuarios)
        {
            EntityState operacion = EntityState.Deleted;
            return opercion(objUsuarios, operacion);
        }
        private HttpResponseMessage opercion([FromBody] USUARIOS objUsuarios, EntityState operacion)
        {
            int resp = 0;
            HttpResponseMessage objMenRespuesta = null;
            try
            {
                using (ELCONTENTOEntities objEntidad = new ELCONTENTOEntities())
                {
                    objEntidad.Entry(objUsuarios).State = operacion;
                    resp = objEntidad.SaveChanges();
                    objMenRespuesta = Request.CreateResponse(HttpStatusCode.OK, resp);
                }
            }
            catch (Exception er)
            {
                objMenRespuesta = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, er.Message);
            }
            return objMenRespuesta;
        }
    }
}

    

