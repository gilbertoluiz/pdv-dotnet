using System.Windows;
using PdvSuite.UI.Wpf.Tema;

namespace PdvSuite.UI.Wpf.Views;

public partial class TelaHomePdv : Window
{
    public TelaHomePdv() { InitializeComponent(); }
    private void AbrirPedidos_Click(object sender, RoutedEventArgs e) => FramePrincipal.Navigate(new TelaPedidos());
    private void ToggleTema_Checked(object sender, RoutedEventArgs e) => GerenciadorTema.DefinirTema(true);
    private void ToggleTema_Unchecked(object sender, RoutedEventArgs e) => GerenciadorTema.DefinirTema(false);
}