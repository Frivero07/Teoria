using linq.Modelos;

namespace linq
{
    public class Program
    {
        static void Main()
        {
            //Ejemplo1();
            //Ejemplo2();
            //Ejemplo3();
            Ejemplo4();
        }
        static void Ejemplo1()
        {
            List<Producto> lista = new List<Producto>
            {
                new Producto { Id = 1, Nombre = "Remera", Precio = 25 },
                new Producto { Id = 2, Nombre = "Pantalon", Precio = 55 },
                new Producto { Id = 3, Nombre = "Zapatos", Precio = 75 },
                new Producto { Id = 3, Nombre = "Sombrero", Precio = 30 }
            };
            //esto es para traer todos los productos con precio sean mayor a 50 (linq secuencia sql en codigo)

            var productosFiltrados = from p in lista
                                     where p.Precio > 50
                                     orderby p.Nombre ascending
                                     select p;
            //lo mismo que arriba pero con la sintaxis de linq
            var productosFiltrados2 = lista.Select(p => p).Where(p => p.Precio > 50).OrderBy(p => p.Nombre).ToList();

            // esto es para que lo muestre por pantalla 
            foreach (var prod in productosFiltrados)
            {
                Console.WriteLine($"{prod.Nombre} - {prod.Precio:C}");
            }

        }
        static void Ejemplo2()
        {
            List<Estudiante> estudiantes = new List<Estudiante>
        {
            new Estudiante {Nombre = "Juan", Calificacion = 100},
            new Estudiante {Nombre = "Pedro", Calificacion = 100},
            new Estudiante {Nombre = "Luis", Calificacion = 88},
            new Estudiante {Nombre = "Ana", Calificacion = 92},
            new Estudiante {Nombre = "Maria", Calificacion = 74},
            new Estudiante {Nombre = "Carlos", Calificacion = 50},
        };
            //agrupa por grupo con la misma nota y con el nombre 
            var EstudianteFiltrados = from e in estudiantes
                                      group e by e.Calificacion into grupo
                                      select grupo;
            foreach (var grupo in EstudianteFiltrados)
            {
                Console.WriteLine($"Calificacion: {grupo.Key}");
                foreach (var e in grupo)
                {
                    Console.WriteLine($" - {e.Nombre}");
                }

            }
        }
        static void Ejemplo3()
        {
            List<Cliente> clientes = new List<Cliente>
            {
                new Cliente { Id = 1 , Name = "Pedro"},
                new Cliente { Id = 2 , Name = "Ana"},
                new Cliente { Id = 3 , Name = "Julia"},
            };
            List<Pedido> pedidos = new List<Pedido>
            {
                new Pedido { Id = 1 , ClienteId = 1 , Producto = "Libro" },
                new Pedido { Id = 2 , ClienteId = 3 , Producto = "Pala" },
                new Pedido { Id = 3 , ClienteId = 2 , Producto = "Tablet" },
                new Pedido { Id = 4 , ClienteId = 1 , Producto = "Cuadernillo"},
            };

            var PedidosClientes = from c in clientes
                                  //Para saber que dos tablas son iguales y no que apunta al mismo lugar con el equals
                                  join p in pedidos on c.Id equals p.ClienteId
                                  select new { c.Name, p.Producto };
            foreach ( var item in PedidosClientes)
            {
                Console.WriteLine($"{item.Name} ha comprado un {item.Producto}");
            }
                                  
        }
        static void Ejemplo4()
        {
            List<string> nombres = new List<string>
            {
                "Ana", "Luis", "Carlos", "Luis", "Sofia", "Ana"
            };
            //trae nombres unicos 
            var nombreUnico = (from nombre in nombres
                              select nombre).Distinct();

            foreach ( var nombre in nombreUnico)
            {
                Console.WriteLine(nombre);
            }
            
        }
    }
}
