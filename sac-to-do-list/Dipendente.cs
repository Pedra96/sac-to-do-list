using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sac_to_do_list {
    public class Dipendente {
        [Key]
        public int DipendenteId { get; set; }
        public string NomeUtente { get; set; }
        public string CognomeUtente { get; set; }
        
        public List<Attivita> Attività { get; set; }

        public Dipendente() { }
        public Dipendente(string nome, string cognome)
        {
            this.NomeUtente = nome;
            this.CognomeUtente = cognome;
            
        }
        public override string ToString() {
            string print = "Nome: "+this.NomeUtente +" Cognome: "+ this.CognomeUtente+" Id: "+this.DipendenteId+" ";
            return print;
        }

    }
}
