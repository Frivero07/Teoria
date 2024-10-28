using System.Text.Json.Serialization;

public class Empleado
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Departamento { get; set; }
    public static int TotalEmpleados { get; private set; }

    //1. Contructor por defecto 
    public Empleado()
    {
        ID = 0;
        Name = "Sin nombre";
        Departamento = "Sin departamento";
        TotalEmpleados++;
        Console.WriteLine("Empleado creado con datos predeterminados.");
    }
    //2. Contructor Parametrizado
    public Empleado(int id, string name, string departamento)
    {
        ID = id;
        Name = name;
        Departamento = departamento;
        TotalEmpleados++;
        Console.WriteLine($"Empleado{Name} creado");
    }
    //3. Contructor Copia
    public Empleado(Empleado empleado)
    {
        ID += empleado.ID;
        Name += empleado.Name;
        Departamento += empleado.Departamento;
        TotalEmpleados++;
        Console.WriteLine($"Empleado Copiado: {Name}");
    }
    //4. Contructor Estatico(sirve para afectar a todas  las propiedades estaticas en mi clase no estatica, no puede ser invocado)
     static Empleado()
     {
        TotalEmpleados = 0;
        Console.WriteLine("Sistema de empleados inicializado.");
     }
    //5. Contructor Privado(solo accesible internamente)

    private Empleado (string name)
    {
        ID = -1;
        Name = name;
        Departamento = "Administracion";
        TotalEmpleados++;
        Console.WriteLine($"Administrador {Name} creado");
    }

    //metodo estatico para crear un administrador(utiliza el contructor privado)

    public static Empleado CrearAdministrador(string name)
    {
        return new Empleado (name);
    }
    public void MostrarDetalles()
    {
        Console.WriteLine($"ID{ID}, Nombre{Name}, Departamento {Departamento}");
    }
}

public class Program
{
    static void Main()
    {
        Empleado empleado1 = new Empleado();
        empleado1.MostrarDetalles();

        Empleado empleado2 = new Empleado(101, "juan", "Ventas");
        empleado2 .MostrarDetalles();
        //contructor por copia
        Empleado empleado3 = new Empleado(empleado2);
        empleado3 .MostrarDetalles();

        Empleado empleado4 = Empleado.CrearAdministrador("juan");
        empleado4 .MostrarDetalles();

        Console.WriteLine($"Total de empleados creador {Empleado.TotalEmpleados}");
    }
}
