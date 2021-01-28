﻿using Prenotazione;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente
{
    public class Cliente
    {
        public string nome { get; set; }
        public string cognome { get; set; }

        private string cellulare;
        private string sesso;

        private List<Prenotazioni> prenotazioni = new List<Prenotazioni>();
        public Cliente(string nome, string cognome)
        {
            this.nome = nome;
            this.cognome = cognome;
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
                    int c = int.Parse(cellulare);
                }
                catch (Exception)
                {
                    throw new Exception("Inserire soltanto numeri nel campo 'cellulare'!");
                }
            }
            else throw new Exception("Il campo 'cellulare' deve contenere esattamente 10 numeri!");
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

        public string Stampa()
        {
            return $"{nome} {cognome}";
        }
    }
}
            

    

