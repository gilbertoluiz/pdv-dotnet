using System.Windows;
using PdvSuite.UI.Wpf.Tema;

namespace PdvSuite.UI.Wpf.Views;

public partial class TelaConfiguracaoInicial : Window
{
    public TelaConfiguracaoInicial()
    {
        InitializeComponent();
        GerenciadorTema.DefinirTema(false);
    }
    private void ToggleTema_Checked(object sender, RoutedEventArgs e) => GerenciadorTema.DefinirTema(true);
    private void ToggleTema_Unchecked(object sender, RoutedEventArgs e) => GerenciadorTema.DefinirTema(false);
    private void Salvar_Click(object sender, RoutedEventArgs e)
    {
        new TelaLogin().Show();
        Close();
    }
}