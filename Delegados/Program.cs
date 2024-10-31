namespace Delegados
{
        public delegate void Midelegado(string mensaje);
        public delegate int  Operador (int a , int b);
        public delegate void NootificarEvento ();


    public class Sistema
    {
        public static void EventoUno()
        {
            Console.WriteLine("Ejecutando evento 1 ");
        }
        public static void EventoDos()
        {
            Console.WriteLine("Ejecutando evento 2 ");
        }
        public static void EventoTres()
        {
            Console.WriteLine("Ejecutando evento 3 ");
        }
    }
    public class Calculadora
    {
        public static int Sumar(int a, int b) => a + b; 
        public static int Restar(int a, int b) => a - b;

        public static void EjecutarOperacion(Operador operacion , int a, int b)
        {
            int resultado = operacion (a,b);
            Console.WriteLine($"Resultado: {resultado}");
        }
    }
    public class Program
    {
        //los delegados sirven para cambiar el comportamiento de una cosa o otra, lugar donde guardo un metodo

        static void Main()
        {
            // Ejemplo1();
            // Ejemplo2();
            Ejemplo3();
        }
        static void Ejemplo1()
        {

            void MostrarMensajeEnmayus (string mensaje)
            {
                //lo mustra en mayusculas 
                Console.WriteLine($"Mensaje mostrado: {mensaje.ToUpper()}");
            }
            void  MostrarMensaje(string mensaje)
            {
                //lo muestra normal
                Console.WriteLine($"Mensaje mostrado: {mensaje}");
            }
            Midelegado delegado = MostrarMensaje;
            delegado ("Hola");

            delegado = MostrarMensajeEnmayus;
            delegado("hola");
        }

        static void Ejemplo2()
        {
            Operador operacionsuma = Calculadora.Sumar;
            Operador operacionresta = Calculadora.Restar;

            Calculadora.EjecutarOperacion(operacionsuma, 10, 5);
            Calculadora.EjecutarOperacion(operacionresta, 10, 5);
        }

        static void Ejemplo3()
        {
            //multicast
            NootificarEvento eventos = Sistema.EventoUno;
            //concateno eventos 
            eventos += Sistema.EventoDos;
            eventos += Sistema.EventoTres;
            eventos();


        }
    }
}
