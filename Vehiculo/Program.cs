namespace Vehiculo
{
    public class Vehiculo
    {
        public string Tipo { get; set; }
        public string Motor { get; set; }

        public int Puertas { get; set; }

        public bool TieneRemolque { get; set; }

        public override string ToString()
        {
            return $"Vehiculo:[Tipo: {Tipo}, Motor: {Motor}, Puertas {Puertas}, Remolque {TieneRemolque}]";
        }
    }

    public interface IVehiculoBuilder
    {
        void CofigurarMotor();
        void CofigurarPuertas();
        void CofigurarRemolque();
        Vehiculo Contruir();
    }

    public class CocheBuilder : IVehiculoBuilder
    {

        private Vehiculo vehiculo = new Vehiculo {Tipo = "Coche" };
        public void CofigurarMotor() => vehiculo.Motor = "Motor gasolina 1.6L";


        public void CofigurarPuertas() => vehiculo.Puertas = 4;
      

        public void CofigurarRemolque() => vehiculo.TieneRemolque = false;


        public Vehiculo Contruir() => vehiculo;
        
    }
    public class CamionBuilder : IVehiculoBuilder
    {
        private Vehiculo vehiculo = new Vehiculo { Tipo = "Camion" };
        public void CofigurarMotor() => vehiculo.Motor = "Motor diesel 5.0L";
        public void CofigurarPuertas() => vehiculo.Puertas = 2;
        public void CofigurarRemolque() => vehiculo.TieneRemolque = true;
        public Vehiculo Contruir() => vehiculo;

    }

    public class VehiculoDirecctor
    {
        private IVehiculoBuilder _builder;
        public VehiculoDirecctor (IVehiculoBuilder builder)
        {
            _builder = builder;
        }

        public Vehiculo Contruir()
        {
            //optiene los pasos para crear y lo crea 
            _builder.CofigurarMotor ();
            _builder.CofigurarPuertas ();
            _builder.CofigurarRemolque ();
            return _builder.Contruir ();
        }
    }
    public class Program
    {
       static void Main()
       {
            VehiculoDirecctor direcctor = new VehiculoDirecctor(new CocheBuilder());
            Vehiculo coche = direcctor.Contruir();

            Console.WriteLine(coche);

            direcctor = new VehiculoDirecctor(new CamionBuilder());
            Vehiculo camion = direcctor.Contruir();
            Console.WriteLine(camion);
        }
    }
    
}