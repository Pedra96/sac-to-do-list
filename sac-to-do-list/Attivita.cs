using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sac_to_do_list {
    public class Attivita {
        public int id;
        public string nome;
        public string desc;
        public bool fatto;
        public DateTime dataScadenza;       
        public string incaricato;

        public Attivita() { }

        /* public Attivita(string nome, string desc, string dataScadenza, string incaricato, bool fatto = false)
        {

            this.nome = nome;
            this.desc = desc;
            this.fatto = fatto;
            this.incaricato = incaricato;
            SetScadenza(dataScadenza);
        }


        GETTERS
        public string GetNome()
        {
            return nome;
        }
        public string GetDescrizione()
        {
            return desc;
        }
        public bool GetStato()
        {
            return fatto;
        }

        public DateTime GetScadenza()
        {
            return dataScadenza;
        }

        public string GetIncaricato()
        {
            return incaricato;
        }

        SETTERS
        public void SetNome(string nome)
        {
            this.nome = nome;
        }

        public void SetDescrizione(string desc)
        {
            this.desc = desc;
        }

        public void SetStato(bool fatto) 
        { 
            this.fatto = fatto;
        }

        public void SetScadenza(string dataScadenza)
        {
            this.dataScadenza = DateTime.Parse(dataScadenza);
        }

        public void SetIncaricato(string incaricato)
        {
            this.incaricato = incaricato;
        }*/


        public override string ToString() {
            string result = @$"Titolo: {this.nome}
            Descrizione: {this.desc} 
            Persona Incaricata: {this.incaricato}
            Data di Scadenza: {this.dataScadenza}
            ";
            if (this.fatto)
            {
                result += @$"Stato: è gia fatto";
            }
            else
            {
                result += @$"Stato: è da fare";
            }
            return result;
        }

    }
}
