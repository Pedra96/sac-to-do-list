using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sac_to_do_list {
    public class AttivitaContext : DbContext {
        public DbSet<Attivita> Attività { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Cliente> Clienti { get; set; }
        public DbSet<Dipendente> Dipendenti { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=AttivitaDatabase2;" +
            "Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
