using System.Windows;
using System.Windows.Media;
using MaterialDesignThemes.Wpf;

namespace PdvSuite.UI.Wpf.Tema
{
    public static class GerenciadorTema
    {
        public static void DefinirTema(bool escuro)
        {
            var palette = new PaletteHelper();

            // Corrigido: parâmetros corretos para Theme.Create (primary, accent)
            var theme = Theme.Create(
                escuro ? Theme.Dark : Theme.Light,
                Colors.Teal,    // primary
                Colors.Orange   // accent (secondary)
            );

            palette.SetTheme(theme);
            Application.Current.Resources["TemaEscuro"] = escuro;
        }
    }
}