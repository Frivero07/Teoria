using System.Xml.Serialization;

namespace generics
{
    //un tipo de dato que puede ser cualquier cosa (los genericos)

    public class Almacen<T>
    {
        //declarar un generico, que es T
        private T _item; 
        public void Guardar(T nuevoitem)
        {
           _item = nuevoitem;
            Console.WriteLine($"Item guardado: {_item}");
        }
        //retornar directamente el item generico que es T 
        public T Obtener()
        {
            return _item;
        }
        //T != any 
    }

    public class Utilidades
    {
        //sin los parametros de referencia no funciona  
        public static void Intercambiar<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }

    public delegate T Operacion<T> (T valor1, T valor2);
    public class Calculadora
    {
        public static int Sumar(int a, int b) => a + b;
        public static string Concatenar (string a, string b) => a + " " + b;
    }
    public class Program
    {
        static void Main()
        {
            //Ejemplo1();
            //Ejemplo2();
            Ejemplo3();
        }

        static void Ejemplo1()
        {
            //le paso el entero por que es un almacen de enteros solamente 
            Almacen<int> almacenEnteros = new();
            almacenEnteros.Guardar(2);
            Console.WriteLine($"Item recuperado: {almacenEnteros.Obtener()}");
            //le paso el texto por que es un almacen de texto solamente 
            Almacen<string> almacenTexto = new();
            almacenTexto.Guardar("Hola!");
            Console.WriteLine($"Item recuperado: {almacenTexto.Obtener()}");
        }

        static void Ejemplo2()
        {
            int x = 10;
            int y = 20;

            Console.WriteLine($"Antes de intercambiar: x= {x}, y = {y}");
            Utilidades.Intercambiar(ref x, ref y);
            Console.WriteLine($"Antes de intercambiar: x= {x}, y = {y}");
            string str1 = "hola";
            string str2 = "asda";

            Console.WriteLine($"Antes de intercambiar: x= {str1}, y = {str2}");
            Utilidades.Intercambiar(ref str1, ref str2);
            Console.WriteLine($"Antes de intercambiar: x= {str1}, y = {str2}");

        }
        static void Ejemplo3()
        {
            Operacion<int> operacionSuma = Calculadora.Sumar;
            Console.WriteLine($"Suma de enteros: {operacionSuma(5,11)}");
            Operacion<string> operacionConcatenar = Calculadora.Concatenar;
            Console.WriteLine($"Suma de enteros: {operacionConcatenar("hola", "Mundo")}");
        }
    }
}