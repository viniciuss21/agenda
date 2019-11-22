using AgendaContato.Arquivo;
using AgendaContato.DAO;
using AgendaContato.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AgendaContato
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Contato contato = new Contato();

            DaoContato dao = new DaoContato();


            dtGridContato.ItemsSource = dao.BuscarTodos(contato);
        }

        private void btnIncluir_Click(object sender, RoutedEventArgs e)
        {
            Contato contato = new Contato();

            DaoContato dao = new DaoContato();

            contato.nome = tbxNome.Text;
            contato.telefone = tbxTelefone.Text;

            if (String.IsNullOrEmpty(tbxNome.Text))
            {
                MessageBox.Show("Nome é obrigatorio");
                this.tbxNome.Focus();
            }
            else
            {
                dao.Salvar(contato);
                
                dtGridContato.ItemsSource = dao.BuscarTodos(contato);
            }

            tbxNome.Clear();
            tbxTelefone.Clear();

        }

        private void BtnListar_Click(object sender, RoutedEventArgs e)
        {
            Contato contato = new Contato();
            DaoContato dao = new DaoContato();
            dtGridContato.ItemsSource = dao.BuscarTodos(contato);
        }

        private void BtnRemover_Click(object sender, RoutedEventArgs e)
        {
            Contato contato = new Contato();
            DaoContato dao = new DaoContato();

            ExportarArquivo exportarArquivo = new ExportarArquivo();
            exportarArquivo.exportCsv(dtGridContato);
        }
    }
}
