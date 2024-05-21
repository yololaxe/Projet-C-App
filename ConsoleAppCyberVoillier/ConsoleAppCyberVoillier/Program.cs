// See https://aka.ms/new-console-template for more information

namespace ConsoleAppCyberVoillier
{
    class Program
    {
        static void Main(string[] args)
        {
            Personne vincent = new Personne(1, "Jorland", "Vincent", "Skipper");
            Personne Romain = new Personne(2, "Fouletier", "Romain", "Patate");
            Sponsor Logitech = new Sponsor(1, "Logitech");
            Sponsor Razer = new Sponsor(1, "Razer");
            VoilierInscrit voilier1 = new VoilierInscrit(1, "0258", [vincent, Romain], [Logitech, Razer]);
            Console.WriteLine("code : " + voilier1.Code + " id : " + voilier1.Id + "capitaine : " + voilier1.Equipage[0].Nom + " sponsorisé par : " + voilier1.Entreprise[0].Nom);
        }
    }
}