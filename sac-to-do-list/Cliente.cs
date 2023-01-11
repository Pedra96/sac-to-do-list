using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sac_to_do_list {
    public class Cliente {

        [Key]
        public int ClienteId { get; set; }
        public string NomeUtente { get; set; }
        public string CognomeUtente { get; set; }     
        public string EmailUtente { get; set; }

        //relazione 1 a molti Cliente => Attività


        public Cliente() { }

        public Cliente(string nome, string cognome, string email)
        {
            this.NomeUtente = nome;
            this.CognomeUtente = cognome;
            this.EmailUtente = email;
        }

    }
}
