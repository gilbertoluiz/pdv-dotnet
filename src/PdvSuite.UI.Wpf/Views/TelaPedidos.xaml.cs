using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using PdvSuite.Dominio.Modelos;

namespace PdvSuite.UI.Wpf.Views
{
    public partial class TelaPedidos : Page
    {
        private ObservableCollection<Pedido> _pedidos = new();

        public TelaPedidos()
        {
            InitializeComponent();
            GridPedidos.ItemsSource = _pedidos;
            // TODO: Carregar via serviço real
        }

        private void Novo_Click(object sender, RoutedEventArgs e)
        {
            var novo = new Pedido { DocumentoCliente = "00000000000", Status = StatusPedido.Rascunho };
            _pedidos.Add(novo);
            // TODO: Salvar via serviço
        }

        private void Editar_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Editar e salvar
        }

        private void Excluir_Click(object sender, RoutedEventArgs e)
        {
            if (GridPedidos.SelectedItem is Pedido p)
            {
                _pedidos.Remove(p);
                // TODO: Excluir via serviço
            }
        }
    }
}