// See https://aka.ms/new-console-template for more information

namespace ConsoleAppCyberVoillier

{
    class Program 
    { 
        static void Main(string[] args)
        {
            List<Personne> equipage = new List<Personne>
            {
                new Personne(1, "Jorland", "Vincent", "Skipper"),
                new Personne(2, "Fouletier", "Romain", "Patate")
            };
            
            Voilier voilier = new Voilier(1, "Hesspsien\n", equipage); 
            Console.WriteLine($"Code: \n{voilier.Code} \nEquipage:"); 
            
            foreach (var personne in voilier.Equipage)
            {
                Console.WriteLine($"{personne.Nom} {personne.Prenom}, {personne.Post}");
            }
        }
    }
}