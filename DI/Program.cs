
//patron de diseño INYECCION DE DEPENDECIA (DI)
public interface INotificador
{
    void Enviar(string mensaje);

}

public class NotificadorSMS : INotificador
{
     public void Enviar(string mensaje)
     {
        Console.WriteLine($"Enviando SMS: {mensaje}");
     }
}

public class NotificadorEmail : INotificador
{
    public void Enviar( string mensaje)
    {
       Console.WriteLine($"Enviando Email: {mensaje}");
    }
}

public class ServicioNotificaciones
{
    //se llama al notificador pero sin saber cual y se puede usar cualquiera, cambio de dependencia raido
    private readonly INotificador _notificador;
    public ServicioNotificaciones(INotificador notificador)
    {
        _notificador = notificador;
    }

    public void  NotificarUsuario(string mensaje)
    {
        _notificador.Enviar(mensaje);
    }
}
public class Program
{
    static void Main()
    {
        INotificador notificador = new NotificadorSMS();
        ServicioNotificaciones servicioNotificaciones = new ServicioNotificaciones(notificador);
        servicioNotificaciones.NotificarUsuario("Hola");
    }
}