using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace sac_to_do_list {

    [Table("Attività")]
    public class Attivita {
        [Key]
        public int AttivitaId { get; set; }
        [Required]
        public string Nome { get; set; }
        public string? Desc { get; set; }
        [Required]
        public bool Stato { get; set; }
        public DateTime DataScadenza { get; set; }

        //relazione molti a molti Dipendente => Attività

        public List<Dipendente?> Dipendente { get; set; }

        public Attivita() { }

        public Attivita(string nome, string dataScadenza, List<Dipendente> incaricato, string descrizione = "", bool Stato = false) {

            this.Nome = nome;
            SetScadenza(dataScadenza);
            this.Dipendente = incaricato;
            SetDescrizione(descrizione);
            this.Stato = Stato;

        }

        public object this[string name]
        {
            get
            {
                var properties = typeof(Attivita)
                        .GetProperties(BindingFlags.Public | BindingFlags.Instance);

                foreach (var property in properties) {
                    if (property.Name == name && property.CanRead)
                        return property.GetValue(this, null);
                }

                throw new ArgumentException("Proprietà non trovata");

            }

            set {
                Type myType = typeof(Attivita);
                PropertyInfo myPropInfo = myType.GetProperty(name);
                myPropInfo.SetValue(this, Convert.ChangeType(value, myPropInfo.PropertyType), null);

            }
        }

        //SETTERS
        public void SetScadenza(string dataScadenza) {
            DateTime DataScadenza = DateTime.Parse(dataScadenza);
            if (DataScadenza > DateTime.Now) {
                this.DataScadenza = DataScadenza;
            } else {
                throw new Exception("la data che hai inserito è gia passato");
            }
        }

        public void SetIncaricato(List<Dipendente> incaricato) {

            this.Dipendente = incaricato;
        }

        public void SetDescrizione(string descrizione) {
            this.Desc = descrizione;

        }

        public string GetData() {

            return DataScadenza.ToShortDateString();

        }
        public string Stampadipendenti(int id)
        {
            using (AttivitaContext db = new AttivitaContext()) {
                string listaStringaDipendenti = "";
                List<Dipendente> listaDipendenti = db.Dipendenti.ToList();

                foreach(Dipendente dipendente in listaDipendenti)
                {
                    listaStringaDipendenti+= dipendente;
                }

                   return listaStringaDipendenti;

            }

        }

    

        public override string ToString() {
            string result = @$"Titolo: {this.Nome}
            ID Attività: {this.AttivitaId}
            Descrizione: {this.Desc} 
            Persona Incaricata: {Stampadipendenti(this.AttivitaId)}
            Data di Scadenza: {GetData()}
            ";
            if (this.Stato)
            {
                result += @$"Stato: Consegnato";
            }
            else
            {
                result += @$"Stato: Da consegnare";
            }
            return result;
        }

    }
}
