namespace WSEjercicioRest.Entidades.Services.User.Salida;

public class Rootobject
{
    public List<Class1> Property1 { get; set; } = new List<Class1>();
}

public class Class1
{
    public int id { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public string gender { get; set; }
    public string status { get; set; }
}

