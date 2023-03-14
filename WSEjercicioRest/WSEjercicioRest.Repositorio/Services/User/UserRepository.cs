using BP.API.Entidades;
using BP.Comun.Extensiones;
using BP.Comun.Logs.Base.Handlers;
using BP.Comun.Rest.Interfaces;
using Newtonsoft.Json;
using System.Net;
using System.Security.Principal;
using WSEjercicioRest.Dominio.Interfaces.Services.ServiceName;
using WSEjercicioRest.Entidades;
using WSEjercicioRest.Entidades.Services.User.Salida;
using static System.Net.WebRequestMethods;

namespace WSEjercicioRest.Repositorio.Services.User
{
    public class UserRepository : IUserRepository
    {
        private readonly IApi _iApi;

        public UserRepository(IApi iApi)
        {
            this._iApi = iApi;
        }

        //[Loggable]
        public  List<EUser> ObtenerUsuarios()
        {
            List<EUser> eUsers= new List<EUser>();
            List<Class1> resultadoServ = new List<Class1>();

            try
            {
                string url = $"{"https://gorest.co.in/public/v2/users"}";
                var respuestaServicio = Task.Run(() => _iApi.GetAsync(url)).Result;
                if (respuestaServicio.StatusCode == HttpStatusCode.OK)
                {
                    resultadoServ = JsonConvert.DeserializeObject<List<Class1>>(respuestaServicio.Values);
                }
                eUsers = (
                     from cust in resultadoServ
                     select new EUser
                     {
                         id = cust.id,
                         email = cust.email,
                         gender = cust.gender,
                         name = cust.name,
                         status = cust.status

                     }
                    ).ToList();
            }
            catch (Exception ex)
            {
                
                throw;
            }

            return eUsers;

        }
    }
}
