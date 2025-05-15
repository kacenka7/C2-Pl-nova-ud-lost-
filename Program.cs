
internal class Program
{
    public class Event 
    {
        public string Name {get; set;}  
        public DateTime Date {get; set;}
    }
    private static void Main(string[] args)

    {
        Event lekce = new Event() {Name="Lekce Czechitas", Date = DateTime.Parse("2025-05-25")};
        Event oslava = new Event() {Name="Oslava", Date = DateTime.Parse("2025-10-15")};
        Event uloha = new Event() {Name="Odevzdat úlohu", Date = DateTime.Parse("2025-05-25")};
        Event zubar = new Event() {Name="Zubař", Date = DateTime.Parse("2025-05-25")};

        List<Event> events = new List<Event>() {lekce, oslava, uloha, zubar};

        bool pokracovat = true;

        while (pokracovat)
        {
            Console.WriteLine("Zadej EVENT pro zadání nové události, LIST pro vypsání všech událostí, STAS pro výpis statistik nebo END pro ukončení programu. ");
            string vstup = Console.ReadLine().ToUpper();

            switch (vstup)
            {
                case "EVENT":
                    Console.WriteLine("Zadej událost ve formátu: Název události,YYYY-MM-DD");
                    string udalostVstup = Console.ReadLine();
                    string[] parts = udalostVstup.Split(",");
                    string udalostNazev = parts[0].Trim();
                    string udalostDatum = parts[1].Trim();

                    if (DateTime.TryParse(udalostDatum, out DateTime parseDate))
                    {
                        events.Add(new Event { Name = udalostNazev, Date = parseDate });
                        Console.WriteLine("Událost byla přidána.");
                    }
                    else
                    {
                        Console.WriteLine("Chybně zadaný vstup");
                    }

                    break;
                case "LIST":
                    foreach (var e in events)
                    {
                        DateTime dnes = DateTime.Today;
                        TimeSpan rozdil = e.Date - dnes;
                        int rozdilDny = rozdil.Days; 
                        Console.WriteLine($"Událost {e.Name}  s datem {e.Date.ToString("yyyy-MM-dd")} bude za {rozdilDny} dní");
                    }
                break;
                case "STAS":
                    var stejneDatumy = events.GroupBy(e => e.Date.Date).ToDictionary(g => g.Key, g => g.Count());
                    foreach (var e in stejneDatumy)
                    {
                        Console.WriteLine($"{e.Key:yyyy-MM-dd}: {e.Value} akce");
                    }
                break;
                case "END":
                    Console.WriteLine("Program se ukončí.");
                    pokracovat = false;
                break;
                default:
                    
                    do 
                    {
                        Console.WriteLine("Chybně zadaný vstup, zadej znovu:");
                        vstup = Console.ReadLine();

                    }
                    while (vstup != "LIST" &&  vstup != "STAS" && vstup != "LIST" && vstup != "END");

                break;

            }
        }
    }
}