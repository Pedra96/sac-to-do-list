using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sac_to_do_list {

    [Table("Attività")]
    public class Attivita {
        [Key]
        public int AttivitaId { get; set;}
        [Required]
        public string Nome { get; set; }
        public string Desc { get; set; }
        [Required]
        public bool Fatto { get; set; }
        public DateTime DataScadenza { get; set; }

        public string Incaricato { get; set; }

        public Attivita() { }

        public Attivita(string nome, string dataScadenza, string incaricato, string descrizione="", bool fatto = false)
        {

            this.Nome = nome;
            SetScadenza(dataScadenza);
            this.Incaricato = incaricato;
            SetDescrizione(descrizione);
            this.Fatto = fatto;

        }

        //SETTERS
        public void SetScadenza(string dataScadenza)
        {
            DateTime DataScadenza = DateTime.Parse(dataScadenza);
            if (DataScadenza > DateTime.Now)
            {
                this.DataScadenza = DataScadenza;
                Console.WriteLine("la data di scadenza è giusto");
            }
            else
            {
                throw new Exception("la data che hai inserito è gia passato");
            }
        }

        public void SetIncaricato(string incaricato)
        {

            this.Incaricato = incaricato;
        }

        public void SetDescrizione(string descrizione)
        {
            this.Desc = descrizione;

        }

        public string GetData() {
            return DataScadenza.ToShortDateString();
        }



        public override string ToString() {
            string result = @$"Titolo: {this.Nome}
            ID Attività: {this.AttivitaId}
            Descrizione: {this.Desc} 
            Persona Incaricata: {this.Incaricato}
            Data di Scadenza: {GetData()}
            ";
            if (this.Fatto)
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
