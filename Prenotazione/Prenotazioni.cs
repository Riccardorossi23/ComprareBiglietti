using Clienti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prenotazione
{
    public class Prenotazione
    {
        private const double PREZZO = 20.99;

        public string Ora { get; set; }
        public DateTime Data { get; set; }

        public Cliente Cliente { get; set; }

        public Prenotazione(DateTime data,string ora, Cliente cliente)
        {
            Cliente = cliente;
            cliente.AddPrenotazione(this);
        }
    }
}
