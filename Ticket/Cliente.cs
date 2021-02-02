using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket
{
    public class Cliente
    {
        public string nome { get; set; }
        public string cognome { get; set; }
        private string cellulare;
        private string sesso;

        private List<Prenotazione> prenotazioni = new List<Prenotazione>();

        public Cliente(string nome, string cognome)
        {
            this.nome = nome;
            this.cognome = cognome;
        }

        internal void AddPrenotazione(Prenotazione p)
        {
            prenotazioni.Add(p);
        }

        public string GetSesso()
        {
            return sesso;
        }

        public void SetSesso(bool s)
        {
            if (s == true)
            {
                sesso = "M";
            }
            else sesso = "F";
        }

        public string GetCellulare()
        {
            return cellulare;
        }

        public void SetCellulare(string cellulare)
        {
            if (cellulare.Length == 10)
            {
                try
                {
                    Int64.Parse(cellulare);
                    this.cellulare = cellulare;
                }
                catch (Exception)
                {
                    throw new Exception("Il cellulare deve essere di 10 cifre e deve contenere soltanto numeri");
                }
            }
            else throw new Exception("Il cellulare deve essere di 10 cifre e deve contenere soltanto numeri");
        }



        public string Stampa()
        {
            return $"{sesso},{nome} {cognome}";
        }
        
    }
}
