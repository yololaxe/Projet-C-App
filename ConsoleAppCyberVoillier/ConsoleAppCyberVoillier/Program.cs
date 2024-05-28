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
                new Personne(3, "Abancourt", "Enzo", "Skipper"),
                new Personne(4, "Moragny", "Alban", "Patate")
            };
            List<Personne> equipage3 = new List<Personne>
            {
                new Personne(5, "Vouis", "Ruben", "Skipper"),
                new Personne(6, "Poura", "Killian", "Patate")
            };
            List<Personne> equipage4 = new List<Personne>
            {
                new Personne(7, "Martin", "Gamin", "Skipper"),
                new Personne(8, "Poutar", "Louis", "Patate")
            };
            
            Voilier voilier1 = new Voilier(1, "VA102SETE", equipage1);
            
            Voilier voilier2 = new Voilier(2, "VA103SETE", equipage2);
            
            Voilier voilier3 = new Voilier(3, "HT201MNTP", equipage3);
            
            Voilier voilier4 = new Voilier(4, "AU101CCSN", equipage4);
            
            
            Console.WriteLine($"Code: \n{voilier1.Code} \nEquipage:");
        }
    }
}