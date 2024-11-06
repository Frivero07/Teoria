using builder;

namespace builder
{
    public class CuentaBancaria
    {
        public string TipoCuenta { get; set; }
        public double BalanceInicial { get; set; }
        public string Moneda { get; set; }

        public override string ToString()
        {
            return $"[Tipo de cuenta: {TipoCuenta}, Balance Inicial {BalanceInicial:C}, Tipo de moneda {Moneda}]";
        }
    }

    public class CuentaBuilder
    {
        private CuentaBancaria cuenta;

        public CuentaBuilder()
        {
            cuenta = new CuentaBancaria();
        }


        public CuentaBuilder Tipocuenta(string tipo)
        {
            cuenta.TipoCuenta = tipo;
            return this;
        }

        public CuentaBuilder Balance(double balance)
        {
            cuenta.BalanceInicial = balance;
            return this;
        }

        public CuentaBuilder Tipomoneda(string moneda)
        {
            cuenta.Moneda = moneda;
            return this;
        }

        public CuentaBancaria Contruir()
        {
            return cuenta;
        }
    }
}

public class Program
{
    static void Main()
    {
        CuentaBuilder builder = new CuentaBuilder();
        CuentaBancaria cuenta = builder
                              .Tipocuenta("corriente")
                              .Balance(10000)
                              .Tipomoneda("dolares")
                              .Contruir();
        Console.WriteLine(cuenta);

    }
}

