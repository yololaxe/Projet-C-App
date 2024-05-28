// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;

namespace ConsoleAppCyberVoillier

{
    class Program 
    { 
        static void Main(string[] args)
        {
            List<Personne> equipage1 = new List<Personne>
            {
                new Personne(1, "Jorland", "Vincent", "Skipper"),
                new Personne(2, "Fouletier", "Romain", "Patate")
            };
            List<Personne> equipage2 = new List<Personne>
            {
                new Personne(3, "Abancourt", "Vincent", "Skipper"),
                new Personne(4, "", "Romain", "Patate")
            };
            List<Personne> equipage3 = new List<Personne>
            {
                new Personne(5, "Jorlande", "Vincent", "Skipper"),
                new Personne(6, "Fouletier", "Romain", "Patate")
            };
            List<Personne> equipage4 = new List<Personne>
            {
                new Personne(7, "Jorlande", "Vincent", "Skipper"),
                new Personne(8, "Fouletier", "Romain", "Patate")
            };
            
            Voilier voilier = new Voilier(1, "VA102SETE", equipage1); 
            Console.WriteLine($"Code: \n{voilier.Code} \nEquipage:"); 
            
            foreach (var personne in voilier.Equipage)
            {
                Console.WriteLine($"{personne.Nom} {personne.Prenom}, {personne.Post}");
            }
            
            
        }
    }
}