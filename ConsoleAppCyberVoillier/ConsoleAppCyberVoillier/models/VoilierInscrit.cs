using System;
using System.Collections.Generic;

namespace ConsoleAppCyberVoillier
{
    public class VoilierInscrit : Voilier
    {
        private List<Sponsor> sponsors;
        private string codeInscription;
        
        // Properties
        public List<Sponsor> Sponsors
        {
            get => sponsors;
            set => sponsors = value ?? new List<Sponsor>(); // Allow empty list
        }

        public string CodeInscription
        {
            get => codeInscription;
            set {
                codeInscription = (value ?? throw new ArgumentNullException(nameof(value)))
                    .Trim().Length == 0
                        ? throw new ArgumentException("CodeInscription ne peut être vide ou un espace.", nameof(value))
                        : value;
            }
        }

        // Constructor
        protected VoilierInscrit()
        {
            sponsors = new List<Sponsor>(); // Initialize the list
        }

        public VoilierInscrit(int id, string code, List<Personne> equipage, List<Sponsor> entreprises, string codeInscription) 
            : base(id, code, equipage)
        {
            Sponsors = entreprises;
            CodeInscription = codeInscription;
        }
        
        // CREATE, READ, UPDATE, DELETE
        private bool AddSponsor(Sponsor sponsor)
        {
            if (sponsor == SearchSponsor(sponsor.Id))
                return false;
            sponsors.Add(sponsor);
            return true;
        }

        private Sponsor SearchSponsor(int id)
        {
            return sponsors.Find(a => a.Id == id);
        }

        private bool RemoveSponsor(Sponsor sponsor)
        {
            if (!sponsors.Contains(sponsor))
                return false;
            sponsors.Remove(sponsor);
            return true;
        }
    }
}