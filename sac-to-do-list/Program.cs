using sac_to_do_list;
using static System.Net.Mime.MediaTypeNames;

/*Realizzare una console application per gestire una lista di attività da svolgere.
V. Ogni attività è composta da un testo, un stato (inteso come “fatto”/”da fare”) ed
eventualmente una data (opzionale).
V. All 'avvio dell'applicazione il sistema chiede all'utente cosa vuole fare:
1- visualizzare la lista delle attività (con testo, stato e data, se presente)
2 - aggiungere una nuova attività alla lista
3- rimuovere un'attività dalla lista
4- modificare il testo di un'attività inserita precedentemente
5- modificare lo stato di un'attività inserita precedentemente (se lo stato era
impostato come "da fare", diventa "fatto" e viceversa)
6 - aggiungere o modificare una data ad un'attività inserita precedentemente (NB:
questa operazione si può svolgere solo su attività che sono ancora da fare)
7 - visualizzare solo le attività ancora da fare, paginate di 3 in 3 (questa è una
funzionalità desiderabile ma opzionale)
0 - chiudere il programma*/

using (AttivitaContext db = new AttivitaContext()) {
    string print = "1 - visualizzare la lista delle attività\n" +
    "2 - aggiungere una nuova attività alla lista\n" +
    "3 - rimuovere un'attività dalla lista\n" +
    "4 - modificare il testo di un'attività inserita precedentemente\n" +
    "5 - modificare lo stato di un'attività inserita precedentemente\n" +
    "6 - aggiungere o modificare una data ad un'attività inserita precedentemente\n" +
    "7 - visualizzare solo le attività ancora da fare, paginate di 3 in 3\n" +
    "0 - chiudere il programma\n" +
    "Inserire il numero dell'azione che desidera fare:";
    Console.WriteLine(print);

    string userinput = Console.ReadLine();

    Functions.AzioniUtente(userinput);
    Console.WriteLine("desidera fare altro?");
    userinput= Console.ReadLine();

    if(userinput.ToLower() == "si") {
        Console.WriteLine(print);
        userinput = Console.ReadLine();
        Functions.AzioniUtente(userinput);
    }
}

