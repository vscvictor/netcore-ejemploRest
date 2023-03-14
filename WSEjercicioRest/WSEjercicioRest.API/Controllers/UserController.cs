using BP.API.Constantes;
using BP.API.Entidades;
using BP.API.Entidades.Excepciones;
using BP.API.Entidades.Extensiones;
using BP.Comun.Extensiones;
using BP.Comun.Logs.Base.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WSEjercicioRest.Dominio.Interfaces.Services.ServiceName;
using WSEjercicioRest.Entidades;

namespace WSEjercicioRest.API.Controllers
{
    #region DEFINICION DE VERSION DE API

    [ApiVersion("1")]

    #endregion DEFINICION DE VERSION DE API FIN

    [Route(Controlador.RutaVersion)]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserIfraestructure _iUserIfraestructure;
        public UserController(IUserIfraestructure iUserIfraestructure)
        {
            _iUserIfraestructure = iUserIfraestructure;
        }

        #region HealthChecks

        /// Método para chequear la disponibilidad del Pod 
        /// </summary>
        /// <param name="entrada"></param>
        /// <returns>Http Status Code</returns>
        [HttpGet]
        [Route("HealthChecks")]
        public IActionResult HealthChecks()
        {
            return StatusCode(HttpStatusCode.OK.ToInt());
        }


        [HttpGet]
        //[Route("HealthChecksServicio")]
        public async Task<IActionResult> ObtenerUsuarios()
        {


            try
            {
                return Ok(_iUserIfraestructure.ObtenerUsuarios());
            }
            catch (CoreNegocioError negocioError)
            {
                //
            }
            catch (Exception excepcion)
            {
                //
            }
            return StatusCode(HttpStatusCode.InternalServerError.ToInt(), "Error");
        }

        #endregion

    }
}
