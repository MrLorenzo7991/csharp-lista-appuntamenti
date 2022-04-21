using ListaAppuntamenti;
List<Appuntamento> listaAppuntamenti = new List<Appuntamento>();

Console.WriteLine("Benvenuto nella tua agenda!");
Console.WriteLine("Quanti appuntamenti vuoi aggiungere?");

int numeroDiAppuntamenti = ChiediNumeroDiAppuntamenti();

for (int i = 0; i < numeroDiAppuntamenti; i++)
{
    Console.WriteLine("Appuntamento numero " + (i + 1));
    Console.WriteLine("Aggiungi il nome del tuo appuntamento: ");
    string nomeAppuntamento = Console.ReadLine();
    Console.WriteLine("Aggiungi il luogo del tuo appuntamento: ");
    string localitaAppuntamento = Console.ReadLine();

    bool dataCorretta = false;
    while (!dataCorretta)
    {
        DateTime dataOraAppuntamento = InserisciData();
        try
        {
            listaAppuntamenti.Add(new Appuntamento(nomeAppuntamento, localitaAppuntamento, dataOraAppuntamento));
            dataCorretta = true;
        }
        catch (InvalidDataException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

foreach(Appuntamento appuntamento in listaAppuntamenti)
{
    appuntamento.ToString();
}

Console.WriteLine("Vuoi Cambiare la data di un appuntamento? [si/no]");
string scelta = Console.ReadLine();
switch (scelta)
{
    case "si":
        Console.WriteLine("Quale appuntamento vuoi modificare? (inserisci il nome)");
        string nomeAppuntamentoDaModificare = Console.ReadLine();
        bool nomeTrovato = false;
        for(int i = 0; i < listaAppuntamenti.Count; i++)
        {
            if (listaAppuntamenti[i].GetNomeAppuntamento() == nomeAppuntamentoDaModificare)
            {
                Console.WriteLine("Inserisci la nuova datata dell' appuntamento: ");
                DateTime nuovaData = InserisciData();
                listaAppuntamenti[i].CambiaDataAppuntamento(nuovaData);
                Console.WriteLine("Data modificata correttamente.");
                nomeTrovato = true;

                Console.WriteLine("Ecco la tua lista di appuntamenti con l'appuntamento modificato");
                foreach (Appuntamento appuntamento in listaAppuntamenti)
                {
                    appuntamento.ToString();
                }
                break;
            }   
        }
        if (!nomeTrovato)
        {
            Console.WriteLine("Non ho trovato nessun appuntamento con quel nome");
        }
        
        break;
    case "no":

        break;
    default:

        break;
}




////////////funzioni////////////////

int ChiediNumeroDiAppuntamenti()
{
    int numeroDiAppuntamenti = 0;
    bool numeroDiAppuntamentiCorretto = false;
    while (!numeroDiAppuntamentiCorretto)
    {
        if (int.TryParse(Console.ReadLine(), out int result))
        {
            numeroDiAppuntamenti = result;
            numeroDiAppuntamentiCorretto = true;
        }
        else
        {
            Console.WriteLine("Inserisci un numero intero");
        }

    }
    return numeroDiAppuntamenti;
}

DateTime InserisciData()
{
    bool formatoDataCorretto = false;
    DateTime dataOra = DateTime.Now;
    while (!formatoDataCorretto)
    {
        Console.WriteLine("Aggiungi la data e l'ora del tuo appuntamento: [gg/mm/aaaa hh:mm]");

        try
        {
            dataOra = DateTime.Parse(Console.ReadLine());                          //aggiungere controllo data corretta
            formatoDataCorretto = true;
        }
        catch (Exception)
        {
            Console.WriteLine("Il formato della data non è corretto");
        }
    }
    return dataOra;
}


