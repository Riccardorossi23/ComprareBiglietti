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
            try
            {
                if (cmbSelezionaCliente1.SelectedIndex != -1 && cmbOrario.SelectedIndex != -1 && dpData.SelectedDate!= null)
                {
                    DateTime data = Convert.ToDateTime(dpData.Text);
                    string ora = cmbOrario.Text;
                    Cliente cliente = clienti[cmbSelezionaCliente1.SelectedIndex];
                    Prenotazione pre = new Prenotazione(data, ora, cliente);
                    string prezzo = Convert.ToString(pre.CostoPrenotazione());
                    prenotazioni.Add(pre);
                    lboStampaPrenotazioni.Items.Add(pre.Stampa());

                }
                cmbSelezionaCliente1.SelectedIndex = -1;
                cmbOrario.SelectedIndex = -1;
                dpData.SelectedDate = null;
            }
            
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Attenzione", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        private void btnCancella_Click(object sender, RoutedEventArgs e)
        {
            int selezione = lboStampaPrenotazioni.SelectedIndex;
            if(selezione>=0)
            {
                string nomeCliente = prenotazioni[selezione].Cliente.ToString();
                for(int i=0;i<clienti.Count;i++)
                {
                    if(nomeCliente==clienti[i].ToString())
                    {
                        clienti[i].RemovePrenotazione(prenotazioni[selezione]);
                    }
                }
            }
            else
            {
                MessageBox.Show("Non è stato selezionato nulla", "Attenzione", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            lboStampaPrenotazioni.Items.RemoveAt(selezione);
            lboStampaPrenotazioni.Items.Clear();
           prenotazioni.RemoveAt(selezione);
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
                clienti.Add(cliente);

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

        private void CmbOrario_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (string s in orario)
            {
                cmbOrario.Items.Add(s);
            }
        }

        private void btnPrenotaCliente_Click(object sender, RoutedEventArgs e)
        {
            if (cmbSelezionaCliente2.SelectedIndex != -1)
            {
                lboStampaBiglietto.Items.Clear();
                double prezzo = 0;
                prezzo = clienti[cmbSelezionaCliente2.SelectedIndex].Contaprecli();
                int count = clienti[cmbSelezionaCliente2.SelectedIndex].Contapre();
                lboStampaBiglietto.Items.Add($"{cmbSelezionaCliente2.SelectedIndex}: Prenotazione {count}, Prenotazione {prezzo}€ ");
              
            }

            else
            {
                MessageBox.Show("Devi selezionare il cliente", "Attenzione", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

            
        }

        private void btnPrenotaEvento_Click(object sender, RoutedEventArgs e)
        {
            if(cmbSelezionaCliente2.SelectedIndex!=-1 && cmbSelezionaOrario.SelectedIndex != -1)
            {
                lboStampaBiglietto.Items.Clear();
                int contaOra = clienti[cmbSelezionaCliente2.SelectedIndex].ContapreEvent(cmbSelezionaOrario.SelectedValue.ToString());
                lboStampaBiglietto.Items.Add(contaOra);
            }
            else
                {
                MessageBox.Show("Devi selezionare prima tutti i parametri", "Attenzione", MessageBoxButton.OK, MessageBoxImage.Exclamation);
               
            }
        }
        private void btnPulisci_Click(object sender, RoutedEventArgs e)
        {
            txtCell.Clear(); // prima parte
            txtCognome.Clear(); // prima parte
            txtName.Clear(); //prima parte
            // ------------------------------------
            cmbSelezionaCliente1.SelectedIndex = -1; //seconda parte
            dpData.SelectedDate = null; //seconda parte
            cmbOrario.SelectedIndex = -1; //seconda parte
            lboStampaPrenotazioni.Items.Clear(); //seconda parte
            //------------------------------------
            cmbSelezionaCliente2.SelectedIndex = -1; //terza parte
            cmbSelezionaOrario.SelectedIndex = -1; //terza parte
            lboStampaBiglietto.Items.Clear(); //terza parte
        }

        private void btnEsci_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
        private void cmbSelezionaOrario_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (string s in orario)
            {
                cmbSelezionaOrario.Items.Add(s);
            }
        }
    }
}