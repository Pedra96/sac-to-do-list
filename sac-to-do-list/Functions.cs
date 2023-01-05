using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sac_to_do_list {
    public static class Functions {
        //creare funzioni:
        //V. stampare la lista
        //V. aggiungere un elemento alla lista
        //V. rimuovere un elemento dalla lista
        //V. modificare il testo
        //modificare lo status
        //aggiungere o modificare la data di scadenza
        //stampare la lista con lo status "da fare"  
        public static void AzioniUtente(string input) {
            while (true) {
                try {
                    int inputConvertito = int.Parse(input);
                    switch (inputConvertito) {
                        case 0:
                            break;
                        case 1:
                            Console.WriteLine("Ecco la lista delle attività:");
                            MostraAttività();
                            break;
                        case 2:
                            AggiungereAttività();
                            Console.WriteLine("l'attività è stata aggiunta con successo");

                            break;
                        case 3:
                            MostraAttività();
                            Console.WriteLine("Inserire ID dell'attività che si vuole eliminare"); 
                            int InputUtente=int.Parse(Console.ReadLine());
                            RimuovereAttività(InputUtente);
                            break;
                        case 4:
                            MostraAttività();
                            Console.WriteLine("Inserire ID dell'attività che si vuole modificare");
                            InputUtente = int.Parse(Console.ReadLine());
                            ModifDescAttività(InputUtente);
                            break;
                            //case 5 e 6 verranno eliminate ed unite alla funzione per modificare l'attività.
                        case 5:
                            Console.WriteLine("modificato lo stato dell'attività scelta");
                            break;
                        case 6:
                            Console.WriteLine("modificata o aggiunta la data ad un attività precedente");
                            break;
                        case 7:
                            Console.WriteLine("Ecco la lista di attività ancora da fare:");
                            break;
                        default:
                            Console.WriteLine("Comando inesistente");
                            break;
                    }
                    break;
                }
                catch (FormatException) {
                    Console.WriteLine("l'input inserito non era un numero inserire nuovo input");
                    input = Console.ReadLine();
                }
            }
        }

        public static void MostraAttività() {
            using (AttivitaContext db = new AttivitaContext()) {
                List<Attivita> listaGiocatoriDB = db.Attività.ToList<Attivita>();
                foreach (Attivita attività in listaGiocatoriDB) {
                    Console.WriteLine(attività);
                }
            }
        }

        public static void AggiungereAttività() {
            using (AttivitaContext db = new AttivitaContext()) {
                Console.WriteLine("Scegli il nome dell'attività");
                string nome = Console.ReadLine();
                Console.WriteLine("Chi è persona incaricata?");
                string personaIncaricata = Console.ReadLine();
                Console.WriteLine("inserisci la data di scadenza");
                string dataScadenza = Console.ReadLine();


                Console.WriteLine("vuoi inserire anche la descrizione? si/no");
                string risposta = Console.ReadLine();
                if (risposta.Trim() == "si") {
                    Console.WriteLine("inserisci la descrizione");
                    string descrizione = Console.ReadLine();

                    Attivita nuovaAttività = new Attivita(nome, dataScadenza, personaIncaricata, descrizione);
                    db.Add(nuovaAttività);
                    db.SaveChanges();
                    MostraAttività();
                } else {
                    Attivita nuovaAttività = new Attivita(nome, dataScadenza, personaIncaricata);
                    db.Add(nuovaAttività);
                    db.SaveChanges();
                    MostraAttività();
                }

            }
        }

        static public void RimuovereAttività(int AttivitàIdDaCancellare)
        {
            using (AttivitaContext db = new AttivitaContext())
            {
                List<Attivita> listaAttività = db.Attività.ToList<Attivita>();
                foreach (Attivita elemento in listaAttività)
                {
                    if (elemento.AttivitaId == AttivitàIdDaCancellare)
                    {
                        db.Remove(elemento);
                        db.SaveChanges();

                        Console.WriteLine("cancellato l'attività");
                        MostraAttività();
                    }
                }
            }
        }
        //questa funzione diventerà una funzione di modifica generale
        static public void ModifDescAttività(int AttivitàId)
        {
            string nuovaDescrizione="";
            Console.WriteLine("Inserire nuova descrizione");
            nuovaDescrizione = Console.ReadLine();
            
            using (AttivitaContext db = new AttivitaContext())
            {
                List<Attivita> listaAttività = db.Attività.ToList<Attivita>();
                foreach (Attivita elemento in listaAttività)
                {
                    if (AttivitàId == elemento.AttivitaId)
                    {
                        elemento.SetDescrizione(nuovaDescrizione);
                        db.SaveChanges();
                        Console.WriteLine("Modificata eseguita nuova descrizione " + elemento.Desc);
                    }     
                }
                
            }
        }

    }
}
