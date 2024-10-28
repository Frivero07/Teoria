public class Producto
{
    public string Nombre { get; set; }
    public double Precio { get; set; } = 0;
    public int Stock { get; set; } = 0;

    public Producto (string nombre, double precio, int stock)
    {
        Nombre = nombre;
        Precio = precio;
        Stock = stock;
    }
}

public class Tienda
{
    // Metodo que calcula el costo total sin modificar precio original (por valor)
    public void CalcularCostoTotal(int cantidad,double precioUnitario)
    {
        double CostoTotal = cantidad * precioUnitario;
        Console.WriteLine($"Costo Total: {CostoTotal:C}");
    }

    // Metodo que despacha un pedido y actaliza el stock (por referencia)
    // se indica cual es el valor que va aser cambiado con el ref 
    // modifica el original
    public void DespacharProducto(ref int stock, int cantidadpedida)
    {
        stock -= cantidadpedida;
        Console.WriteLine($"Stock actualizado: {stock} unidades restantantes");
    }

    //Metodo que utiliza un argumento de entrada para asegurar que no se modifica (in)

    public void MostrarPrecioUnitario( in double precioUnitario)
    {
        Console.WriteLine($"El´precio por unidad es {precioUnitario:C} (no se puedemodificar)");
    }

    //Metodo que utiliza un argumento de salida para devolver cuantas unidades no fueron despachadas  (uot)
    public void CalcularUnidadesFaltantes (int StockDisponible, int cantidadPedida, out int unidadesFaltantes)
    {
        if (StockDisponible >=  cantidadPedida)
        {
            unidadesFaltantes = 0;
        }
        else
        {
            unidadesFaltantes = cantidadPedida - StockDisponible;
        }
    }
}

public class Program
{
    static void Main()
    {
        Producto producto = new Producto("Yerba", 5000, 10);
        Tienda tienda = new Tienda();

        int cantidadPedida = 2;

        Console.WriteLine($"Producto: {producto.Nombre}");
        Console.WriteLine($"Stock Disponible: {producto.Stock}");

        tienda.MostrarPrecioUnitario(producto.Precio);
        tienda.CalcularCostoTotal(cantidadPedida, producto.Precio);

        int stock = producto.Stock;
        tienda.DespacharProducto(ref stock, cantidadPedida);
        Console.WriteLine($"Stock: {stock}");

        tienda.CalcularUnidadesFaltantes(producto.Stock, cantidadPedida, out int unidadesFaltantes);
        if (unidadesFaltantes > 0)
        {
            Console.WriteLine($"Faltan por despachar {unidadesFaltantes} unidades");
        }
        else
        {
            Console.WriteLine("Todas las unidades fueron despachadas");
        }
    }
}

//public class Program
//{
//    //static void Main()
//    //{
//    //    //argumento
//    //    Test(2, 4);
//    //}
//    //   public void Test(int n1,int n2)
//    //   {
//    //    //parametro
//    //    return n1+ n2;
//    //   }
//}  

