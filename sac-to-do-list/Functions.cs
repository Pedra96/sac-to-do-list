using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace sac_to_do_list {
    public static class Functions {
        //creare funzioni:
        //V. stampare la lista
        //V. aggiungere un elemento alla lista
        //V. rimuovere un elemento dalla lista
        //V. modificare il testo
        //V. modificare lo status
        //V. aggiungere o modificare la data di scadenza
        //stampare la lista con lo status "da fare"  
        public static void AzioniUtente(string input) {
            while (true) {
                try {
                    int inputConvertito = int.Parse(input);
                    string[] attributeNames = { "Nome", "Desc", "Stato", "DataScadenza", "Incaricato" };
                    switch (inputConvertito) {

                        case 0:
                            break;

                        case 1:
                            Console.WriteLine("Ecco la lista delle attività:");
                            MostraAttività();
                            InputReflection();
                            break;

                        case 2:
                            AggiungereAttività();
                            Console.WriteLine("l'attività è stata aggiunta con successo");
                            InputReflection();
                            break;

                        case 3:
                            MostraAttività();
                            Console.WriteLine("Inserire ID dell'attività che si vuole eliminare");
                            int InputUtente = int.Parse(Console.ReadLine());
                            RimuovereAttività(InputUtente);
                            InputReflection();
                            break;

                        case 4:
                            MostraAttività();
                            Console.WriteLine("Inserire ID dell'attività che si vuole modificare");
                            int id = int.Parse(Console.ReadLine());
                            Console.WriteLine("Quale attributo vuoi modificare? (inserire numero corrispondente)");
                            string attribute = "";
                            while (true) {
                                try {
                                    for (int i = 0; i < attributeNames.Length; i++) {
                                        Console.WriteLine($"{i}: {attributeNames[i]}");
                                    }
                                    attribute = attributeNames[int.Parse(Console.ReadLine())];
                                    break;
                                }
                                catch (Exception) {

                                }
                            }
                            
                            while (true) {
                                try {
                                    Console.WriteLine("Inserisci modifica");
                                    string value = Console.ReadLine();
                                    ModificaAttributo(id, value, attribute);
                                    break; ;
                                }
                                catch (FormatException) {
                                    Console.WriteLine("l'input inserito non è valido per l'attributo, riprovare");
                                }
                            }
                            InputReflection();
                            break;

                        case 5:
                            Console.WriteLine("Ecco la lista di attività ancora da completare:");
                            VisualizzaAttivitàDaFare();
                            InputReflection();
                            break;
                        default:
                            Console.WriteLine("Comando inesistente");
                            InputReflection();
                            break;
                    }
                    break;
                }
                catch (FormatException) {
                    Console.WriteLine("1 - visualizzare la lista delle attività\n" +
                    "2 - aggiungere una nuova attività alla lista\n" +
                    "3 - rimuovere un'attività dalla lista\n" +
                    "4 - modificare un'attività inserita precedentemente\n" +
                    "5 - visualizzare solo le attività ancora da fare\n" +
                    "0 - chiudere il programma\n" +
                    "Inserire il numero dell'azione che desidera fare:");
                    input = Console.ReadLine();
                }
            }
        }
        public static void InputReflection() {
                Console.WriteLine("desidera fare altro?");
                string flag = Console.ReadLine();
            string print = "1 - visualizzare la lista delle attività\n" +
"2 - aggiungere una nuova attività alla lista\n" +
"3 - rimuovere un'attività dalla lista\n" +
"4 - modificare un'attività inserita precedentemente\n" +
"5 - visualizzare solo le attività ancora da fare\n" +
"0 - chiudere il programma\n" +
"Inserire il numero dell'azione che desidera fare:";
            if (flag.ToLower() == "si") {
                    Console.WriteLine(print);
                    string userinput = Console.ReadLine();
                    Functions.AzioniUtente(userinput);
                }

        }

        public static void MostraAttività() {
            using (AttivitaContext db = new AttivitaContext()) {
                List<Attivita> DB = db.Attività.ToList<Attivita>();
                foreach (Attivita attività in DB) {
                    Console.WriteLine(attività);
                }
            }
        }

        public static void AggiungereAttività() {
            using (AttivitaContext db = new AttivitaContext()) {
                Console.WriteLine("Inserire il nome dell'attività");
                string nome = Console.ReadLine();
                Console.WriteLine("selezionare l'id del dipendente da incaricare");
                    List<Dipendente> listaDipendenti = db.Dipendenti.ToList();
                string personaIncaricata = Console.ReadLine();
                var incaricato = new Dipendente(nome, personaIncaricata);
                List<Dipendente> list = new();
                list.Add(incaricato);


                Console.WriteLine("inserisci la data di consegna");
                string dataScadenza = Console.ReadLine();
                Console.WriteLine("vuoi inserire una descrizione? si/no");
                string risposta = Console.ReadLine();
                Attivita NuovaAttivita;
                string descrizione = "";
                if (risposta.Trim().ToLower() == "si") {
                    Console.WriteLine("inserisci la descrizione");
                    descrizione = Console.ReadLine();
                }
                NuovaAttivita = new Attivita(nome, dataScadenza, list, descrizione);
                db.Add(NuovaAttivita);
                db.SaveChanges();
                MostraAttività();

            }
        }

        static public void RimuovereAttività(int id) {
            using (AttivitaContext db = new AttivitaContext()) {
                List<Attivita> listaAttività = db.Attività.ToList<Attivita>();
                Attivita elemento = listaAttività.Find(x => x.AttivitaId == id);
                db.Remove(elemento);
                db.SaveChanges();
                Console.WriteLine("Attività eliminata");
                MostraAttività();
            }
        }

        static public void ModificaAttributo(int id, string value, string attribute) {
            using (AttivitaContext db = new AttivitaContext()) {
                List<Attivita> listaAttività = db.Attività.ToList<Attivita>();
                Attivita elemento = listaAttività.Find(x => x.AttivitaId == id);

                elemento[attribute] = value;
                db.SaveChanges();
                Console.WriteLine("Modifica eseguita su " + attribute + ": " + elemento[attribute]);
            }
        }

        //1visualizzaAttivitàDaFare


        static public void VisualizzaAttivitàDaFare() {
            using (AttivitaContext db = new AttivitaContext()) {
                List<Attivita> listaAttività = db.Attività.Where(x => x.Stato == false && x.DataScadenza >= DateTime.Today).ToList<Attivita>();
                MostraAttivitàDellaLista(listaAttività);

            }
        }

        //2funzione che mostra attività nella lista
        public static void MostraAttivitàDellaLista(List<Attivita> lista) {
            int pagina = 0;
            for (int i = 0; i < lista.Count(); i++) {
                Console.WriteLine(lista[i]);
            }


        }

    }
}