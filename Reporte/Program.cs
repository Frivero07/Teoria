namespace Reporte
{
    public class Reporte
    {
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public string Formato { get; set; }

        public override string ToString()
        {
            return $"Reporte: [Tiulo: {Titulo}, Contenido: {Contenido}, Formato: {Formato}]";
        }
    }
    public interface IReporteBuilder
    {
        void ConfigurarTitulo();
        void ConfigurarContenido();
        void ConfigurarFormato();
        Reporte Contruir();
    }
    public class TextoBuilder : IReporteBuilder
    {
        private Reporte reporte = new Reporte();
        public void ConfigurarTitulo() => reporte.Titulo = "Titulotexto";
        public void ConfigurarFormato() => reporte.Formato = "texto";
        public void ConfigurarContenido() => reporte.Contenido = "texto mucho";
        public Reporte Contruir() => reporte;
    }
    public class PDFBuilder : IReporteBuilder
    {
        private Reporte reporte = new Reporte();
        public void ConfigurarTitulo() => reporte.Titulo = "TituloPDF";
        public void ConfigurarFormato() => reporte.Formato = "PDF";
        public void ConfigurarContenido() => reporte.Contenido = "texto mucho";
        public Reporte Contruir() => reporte;
    }

    public class ReporteDirecctor
    {
        private IReporteBuilder _builder;
        public ReporteDirecctor(IReporteBuilder builder)
        {
            _builder = builder;
        }

        public Reporte Contruir()
        {
            //optiene los pasos para crear y lo crea 
            _builder.ConfigurarTitulo();
            _builder.ConfigurarFormato();
            _builder.ConfigurarContenido();
            return _builder.Contruir();
        }
    }
    public class Program
    {
        static void Main()
        {
            ReporteDirecctor direcctor = new ReporteDirecctor(new TextoBuilder());
            Reporte texto = direcctor.Contruir();
            Console.WriteLine(texto);

            direcctor = new ReporteDirecctor(new PDFBuilder());
            Reporte pdf = direcctor.Contruir();
            Console.WriteLine(pdf);
        }
    }
}
