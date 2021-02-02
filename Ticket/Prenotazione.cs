using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket
{
    public class Prenotazione
    {
        private const double PREZZO = 20.99;

        public string Ora { get; set; }
        public DateTime Data { get; set; }

        public Cliente Cliente { get; set; }

        public Prenotazione(DateTime data, string ora, Cliente Cliente)
        {
            this.Cliente = Cliente;
            Cliente.AddPrenotazione(this);
            this.Data = data;
            this.Ora = ora;
        }
        public string Stampa()
        {
            return $"{Cliente.Stampa()}{Data.ToShortDateString()}{Ora} {CostoPrenotazione()}€";
        }
        public double CostoPrenotazione()
        {
            double prezzo = 0;
            if((Cliente.GetSesso()=="M" && this.Ora=="18:00")|| Cliente.GetSesso()=="F")
            {
                prezzo = PREZZO - ((PREZZO * 10) / 100);
            }
            else
            {
                prezzo = PREZZO;
            }
            return prezzo;
        }
    }
}
    

