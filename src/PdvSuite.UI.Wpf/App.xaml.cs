using System.Windows;
using PdvSuite.UI.Wpf.Tema;

namespace PdvSuite.UI.Wpf
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // Define o tema padrao apos os recursos serem carregados
            GerenciadorTema.DefinirTema(false);
        }
    }
}