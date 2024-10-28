public class ConexionBaseDeDatos
{
    // simula la conexion
    private bool _ConexionAbierta;
    static string Archivo = 

    public ConexionBaseDeDatos()
    {
        _ConexionAbierta = false;
        using StreamWriter writer = new StreamWriter(archivo)
        w
    }


    public void AbrirBase()
    {
        if (!_ConexionAbierta)
        {
            _ConexionAbierta = true;
            Console.WriteLine("Conexion a la base de datos abierta");
        }
        else
        {
            Console.WriteLine("La conexion ya esta abierta");
        }
    }
    public void CerrarConexion()
    {
        if (_ConexionAbierta)
        {
            _ConexionAbierta = false;
            Console.WriteLine("Conexion a la base de datos cerrada");
        }
        else
        {
            Console.WriteLine("La conexion ya esta cerrada");
        }
    }

    //Destructor
   ~ConexionBaseDeDatos()
   {
        if (_ConexionAbierta)
        {
            using StreamWriter writer = new StreamWriter(archivo, true);
            writer.WriteLine("La conexion se cerro ")
            CerrarConexion();
            
            Console.WriteLine("Destructor llamado: conexion cerrada automaticamente");
        }
   }
}

public class Program
{
    static void Main()
    {
        static void Main()
        {
            ConexionBaseDeDatos conexion = new ConexionBaseDeDatos();
            conexion.AbrirBase();

            // Al finalizar eñ programa o salir del alcance del obejeto, el destructor sera llamado
        }
    }
}