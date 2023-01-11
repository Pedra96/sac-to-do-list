
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace sac_to_do_list {
    [Table("Accounts")]
    public class Account {

        [Key]
        public string Email { get; set; }
        public string NomeUtente { get; set; }
        public string Password { get; set; }


        public Account() { }
        public Account(string Email,string NomeUtente,string Password) {
            this.Email = Email;
            this.NomeUtente = NomeUtente;
            this.Password = Password;
        }
    }

}
