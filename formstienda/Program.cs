

using formstienda.capa_de_presentación;
using static formstienda.Arqueo_Caja;

namespace formstienda
{
    internal static class Program
    {
                
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Informes());
            Application.ApplicationExit += (s, e) => CacheArqueo.Limpiar();
        }
    }
}