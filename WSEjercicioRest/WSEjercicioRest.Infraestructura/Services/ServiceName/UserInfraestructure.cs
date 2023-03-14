using BP.Comun.Logs.Base.Handlers;
using WSEjercicioRest.Dominio.Interfaces.Services.ServiceName;
using WSEjercicioRest.Entidades.Services.User.Salida;

namespace WSEjercicioRest.Infraestructura.Services.ServiceName
{
    public class UserInfraestructure : IUserIfraestructure
    {
        private readonly IUserRepository _iUserRepository;
        public UserInfraestructure(IUserRepository iUserRepository)
        {
            _iUserRepository = iUserRepository;
        }
        
        //[Loggable]
        public List<EUser> ObtenerUsuarios()
        {
            return _iUserRepository.ObtenerUsuarios();

        }
    }
}
