using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sac_to_do_list {
    public static class Functions {
        //creare funzioni:
        //stampare la lista
        //aggiungere un elemento alla lista
        //rimuovere un elemento dalla lista
        //modificare il test
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
                            break;
                        case 2:
                            Console.WriteLine("l'attività è stata aggiunta con successo");

                            break;
                        case 3:
                            Console.WriteLine("l'attività è stata rimossa con successo");
                            break;
                        case 4:
                            Console.WriteLine("modificato il testo dell'attvità scelta");
                            break;
                        case 5:
                            Console.WriteLine("modificato lo stato dell'attvità scelta");
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
        /*
        public static void MostraAttivitàDellaLista(List<Attivita> lista)
        {
            foreach(var Attivita in lista)
                {
                Console.WriteLine(Attivita);
            }
        }
        */


    }
}
