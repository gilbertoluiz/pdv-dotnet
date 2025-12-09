using MaterialDesignThemes.Wpf;
using System.Windows;

namespace PdvSuite.UI.Wpf.Tema;

public static class GerenciadorTema
{
    public static void DefinirTema(bool escuro)
    {
        var paleta = new PaletteHelper();
        ITheme tema = paleta.GetTheme();
        tema.SetBaseTheme(escuro ? Theme.Dark : Theme.Light);
        paleta.SetTheme(tema);
        Application.Current.Resources["TemaEscuro"] = escuro;
    }
}