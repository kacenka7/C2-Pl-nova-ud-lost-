
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
        Event uloha = new Event() {Name="Odevzdat úlohu", Date = DateTime.Parse("2025-05-20")};

        List<Event> events = new List<Event>() {lekce, oslava, uloha};

        bool pokracovat = true;

        while (pokracovat)
        {
            Console.WriteLine("Zadej LIST pro vypsání všech událostí, STAS pro výpis statistik nebo END pro ukončení programu. ");
            string vstup = Console.ReadLine();

            switch (vstup)
            {
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