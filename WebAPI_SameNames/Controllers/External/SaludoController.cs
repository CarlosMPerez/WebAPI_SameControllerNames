using System;
using System.Web.Http;
using WebAPI_SameNames.Models.External;

namespace WebAPI_SameNames.Controllers.External
{
    /// <summary>
    /// Saludo Controller EXTERNO
    /// </summary>
    //[RoutePrefix("External/Saludo")]
    public class SaludoController : ApiController
    {
        /// <summary>
        /// Devuelve un SaludoOut con la propiedad TextoSaludo EXTERNA rellena
        /// </summary>
        /// <param name="item">SaludoIn</param>
        /// <returns>SaludoOut</returns>
        [HttpPost]
        //[Route("ObtenerSaludo")]
        public SaludoOut ObtenerSaludo(SaludoIn item)
        {
            var response = new SaludoOut();
            response.TextoSaludo = String.Format("Hola, {0}! WebAPI te saluda EXTERNAMENTE.", item.Nombre);
            return response;
        }
    }
}
