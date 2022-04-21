using ListaAppuntamenti;
List<Appuntamento> listaAppuntamenti = new List<Appuntamento>();

Console.WriteLine("Benvenuto nella tua agenda!");
Console.WriteLine("Quanti appuntamenti vuoi aggiungere?");
int numeroDiAppuntamenti = int.Parse(Console.ReadLine());           //TODO: controllo input numerico

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
        DateTime dataOraAppuntamento = DateTime.Now;
        bool formatoDataCorretto = false;
        while (!formatoDataCorretto)
        {
        Console.WriteLine("Aggiungi la data e l'ora del tuo appuntamento: [gg/mm/aaaa hh:mm]");
            try
            {
                dataOraAppuntamento = DateTime.Parse(Console.ReadLine());                          //aggiungere controllo data corretta
                formatoDataCorretto=true;
            }
            catch (Exception)
            {
                Console.WriteLine("Il formato della data non è corretto");
            }

        }

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











