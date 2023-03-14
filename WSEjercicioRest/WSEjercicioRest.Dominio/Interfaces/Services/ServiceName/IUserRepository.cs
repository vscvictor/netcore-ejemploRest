using WSEjercicioRest.Entidades.Services.User.Salida;

namespace WSEjercicioRest.Dominio.Interfaces.Services.ServiceName
{
    public interface IUserRepository
    {
        List<EUser> ObtenerUsuarios();
    }
}
