using System;
using System.Web.Http;
using WebAPI_SameNames.Models.Internal;

namespace WebAPI_SameNames.Controllers.Internal
{
    /// <summary>
    /// Saludo Controller INTERNO
    /// </summary>
    [RoutePrefix("Internal/Saludo")]
    public class SaludoController : ApiController
    {
        /// <summary>
        /// Devuelve un SaludoOut con la propiedad TextoSaludo INTERNA rellena
        /// </summary>
        /// <param name="item">SaludoIn</param>
        /// <returns>SaludoOut</returns>
        [HttpPost]
        [Route("ObtenerSaludo")]
        public SaludoOut ObtenerSaludo(SaludoIn item)
        {
            var response = new SaludoOut();
            response.TextoSaludo = String.Format("Hola, {0}! WebAPI te saluda INTERNAMENTE.", item.Nombre);
            return response;
        }
    }
}
