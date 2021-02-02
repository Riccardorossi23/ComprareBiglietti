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
using Ticket;

namespace ComprareBiglietti
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Cliente> clienti = new List<Cliente>();
        private List<Prenotazione> prenotazioni = new List<Prenotazione>();
        private string[] orario = new string[] { "18:00", "20:30", "23:00" };
        public MainWindow()
        {
            InitializeComponent();
            rdbM.IsChecked = true;
        }
        private void btnAggiungi_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnAggiungiCli_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string nome = null;
                string cognome = null;

                if (txtName.Text != null)
                {
                    nome = txtName.Text;

                }
                else MessageBox.Show("Inserire un nome", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);

                if (txtCognome.Text != "")
                {
                    cognome = txtCognome.Text;

                }
                else MessageBox.Show("Inserire un cognome", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);

                Cliente cliente = new Cliente(nome, cognome);

                if (rdbF.IsChecked == false && rdbM.IsChecked == false)
                    MessageBox.Show("Selezionare il sesso", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                {
                    if (rdbM.IsChecked == true)
                    {
                        cliente.SetSesso(true);
                    }
                    else
                    {
                        cliente.SetSesso(false);
                    }
                }

                cliente.SetCellulare(txtCell.Text);


                cmbSelezionaCliente1.Items.Add(cliente.Stampa());
                cmbSelezionaCliente2.Items.Add(cliente.Stampa());

                txtName.Clear();
                txtCognome.Clear();
                txtCell.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}