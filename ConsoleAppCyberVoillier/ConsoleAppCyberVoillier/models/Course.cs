using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppCyberVoillier
{
    public class Course
    {
        private int id; 
        public string Nom { get; set; }
        private List<VoilierInscrit> inscrits = new List<VoilierInscrit>();
        private List<VoilierCourse> enCourse = new List<VoilierCourse>();
        private List<Epreuve> epreuves;

        
        
        public int Id
        {
            get => id;
            set => id = value;
        }

        public List<VoilierInscrit> Inscrits
        {
            get => inscrits;
            set => inscrits = value ?? throw new ArgumentNullException(nameof(value), "La liste des inscrits ne peut pas être null");
        }

        
        public List<Epreuve> Epreuves
        {
            get => epreuves;
            set => epreuves = value;
        }

        public List<VoilierCourse> EnCourse
        {
            get => enCourse;
            set => enCourse = value ?? throw new ArgumentNullException(nameof(value), "La liste des voiliers en course ne peut pas être null");
        }

        public Course()
        {
            Epreuves = [];
        }
        
        public Course(int Id, List<Epreuve> epreuves)
        {
            Id = id;
            Epreuves = epreuves;
        }

        #region CRUD VoilierInscrit
        public void AddVoilierInscrit(VoilierInscrit voilier)
        {
            if (GetVoilierCourse(voilier.Id) != null) throw new ArgumentException("Voilier is already in course", nameof(voilier));
            inscrits.Add(voilier);
        }

        public VoilierInscrit GetVoilierInscrit(int id)
        {
            return inscrits.Find(v => v.Id == id);
        }

        public void UpdateVoilierInscrit(VoilierInscrit updatedVoilier)
        {
            VoilierInscrit voilier = GetVoilierInscrit(updatedVoilier.Id);
            if (voilier == null) throw new KeyNotFoundException("Voilier not found");

            int index = inscrits.IndexOf(voilier);
            inscrits[index] = updatedVoilier;
        }

        public void DeleteVoilierInscrit(int id)
        {
            VoilierInscrit voilier = GetVoilierInscrit(id);
            if (voilier == null) throw new KeyNotFoundException("Voilier not found");

            inscrits.Remove(voilier);
        }
        #endregion

        #region CRUD VoilierCourse
        public VoilierCourse GetVoilierCourse(int id)
        {
            return enCourse.Find(v => v.Id == id);
        }

        public void UpdateVoilierCourse(VoilierCourse updatedVoilier)
        {
            VoilierCourse voilier = GetVoilierCourse(updatedVoilier.Id);
            if (voilier == null) throw new KeyNotFoundException("Voilier not found");

            int index = enCourse.IndexOf(voilier);
            enCourse[index] = updatedVoilier;
        }

        public void DeleteVoilierCourse(int id)
        {
            VoilierCourse voilier = GetVoilierCourse(id);
            if (voilier == null) throw new KeyNotFoundException("Voilier not found");

            enCourse.Remove(voilier);
        }
        #endregion

        #region CRUD Epreuves
        public void AddEpreuve(Epreuve epreuve)
        {
            if (GetEpreuve(epreuve.Numero) != null) throw new ArgumentException("Epreuve already exists", nameof(epreuve));
            epreuves.Add(epreuve);
        }

        public Epreuve GetEpreuve(int numero)
        {
            return epreuves.FirstOrDefault(e => e.Numero == numero);
        }

        public void UpdateEpreuve(Epreuve updatedEpreuve)
        {
            Epreuve epreuve = GetEpreuve(updatedEpreuve.Numero);
            if (epreuve == null) throw new KeyNotFoundException("Epreuve not found");

            int index = epreuves.IndexOf(epreuve);
            epreuves[index] = updatedEpreuve;
        }

        public void DeleteEpreuve(int id)
        {
            Epreuve epreuve = GetEpreuve(id);
            if (epreuve == null) throw new KeyNotFoundException("Epreuve not found");

            epreuves.Remove(epreuve);
        }
        #endregion

        // CRUD INSCRIPTION DES VOILIERS
        public VoilierInscrit InscrireVoilier(Voilier voilier, List<Sponsor> sponsors)
        {
            if (inscrits.Any(v => v.Code == voilier.Code))
                throw new Exception($"Voilier déjà inscrit: {voilier.Code}");

            VoilierInscrit voilierInscrit = new VoilierInscrit(
                voilier.Id,
                voilier.Code,
                voilier.Equipage,
                sponsors,
                $"C{DateTime.Now.Year}{inscrits.Count + 1:0000}"
            );

            inscrits.Add(voilierInscrit);
            return voilierInscrit;
        }

        public bool DesinscrireVoilier(string codeInscription)
        {
            VoilierInscrit voilierInscrit = inscrits.FirstOrDefault(v => v.CodeInscription == codeInscription);
            if (voilierInscrit == null)
            {
                return false;
            }
            inscrits.Remove(voilierInscrit);
            return true;
        }

        // METHODES 
        public void Disqualification(int voilierCourseId)
        {
            VoilierCourse voilierCourse = GetVoilierCourse(voilierCourseId);
            if (voilierCourse != null)
            {
                DeleteVoilierCourse(voilierCourseId);
            }
            else
            {
                throw new Exception("Le voilier n'existe pas/plus dans la course");
            }
        }

        public void DebuterLaCourse()
        {
            foreach (VoilierInscrit voilierInscrit in inscrits)
            {
                enCourse.Add(new VoilierCourse(voilierInscrit, 0));
            }

            epreuves.Sort((e1, e2) => e1.Ordre.CompareTo(e2.Ordre));
        }

        public bool EnregistrerTemps(int voilierCourseId, int numero, double temps)
        {
            if (temps < 0)
                return false;
            VoilierCourse voilierCourse = EnCourse.FirstOrDefault(v => v.Id == voilierCourseId);
            if (voilierCourse != null)
            {
                voilierCourse.TempsBrute += temps;
                voilierCourse.EpreuvesEffectuees.Add(GetEpreuve(numero));
                return true;
            }

            throw new Exception("Ce voilier n'est pas en course");
        }

        public void AjouterPenalite(int voilierCourseId, Penalite penalite)
        {
            VoilierCourse voilierCourse = EnCourse.FirstOrDefault(v => v.Id == voilierCourseId);
            voilierCourse?.Penalites.Add(penalite);
        }

        public bool FinDeCourse()
        {
            foreach (VoilierCourse voilierCourse in enCourse)
            {
                if (voilierCourse.EpreuvesEffectuees.Count != epreuves.Count)
                {
                    return false;
                }
                voilierCourse.CalculerTempsReel();
            }
            Console.WriteLine($"Classement des voiliers de la course : ");
            List<VoilierCourse> list = ClasserVoiliers();
            for (int i = 0; i < list.Count; i++)
            {
                VoilierCourse voilier = list[i];
                Console.WriteLine($"{i + 1}. {voilier.Code} avec {voilier.TempsReel / 3600}h {(voilier.TempsReel % 3600) / 60}m {voilier.TempsReel % 60}s");
            }

            return true;
        }

        public List<VoilierCourse> ClasserVoiliers()
        {
            List<VoilierCourse> voiliersComplets = EnCourse
                .Where(v => v.EpreuvesEffectuees.Count == Epreuves.Count)
                .ToList();

            foreach (VoilierCourse voiliersComplet in voiliersComplets)
            {
                voiliersComplet.CalculerTempsReel();
            }

            List<VoilierCourse> classement = voiliersComplets.OrderBy(v => v.TempsReel).ToList();
            return classement;
        }
    }
}
