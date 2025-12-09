using System.Windows;
using PdvSuite.UI.Wpf.Tema;

namespace PdvSuite.UI.Wpf.Views
{
    public partial class TelaLogin : Window
    {
        public TelaLogin()
        {
            InitializeComponent();
        }

        private void ToggleTema_Checked(object sender, RoutedEventArgs e)
        {
            GerenciadorTema.DefinirTema(true);
        }

        private void ToggleTema_Unchecked(object sender, RoutedEventArgs e)
        {
            GerenciadorTema.DefinirTema(false);
        }

        private void Entrar_Click(object sender, RoutedEventArgs e)
        {
            var home = new TelaHomePdv();
            home.Show();
            Close();
        }
    }
}