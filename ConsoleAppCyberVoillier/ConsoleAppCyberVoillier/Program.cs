using ConsoleAppCyberVoillier.database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleAppCyberVoillier;

class Program
{
    static void Main(string[] args)
    {
        using (var context = new VoilierCourseContext())
        {
            // Assurez-vous que la base de données est créée
            context.Database.EnsureCreated();

            // Ajouter des données à la base de données
            AjouterDonnees(context);

            // Récupérer et afficher les données
            AfficherDonnees(context);
        }
    }

    static void AjouterDonnees(VoilierCourseContext context)
    {
        Console.WriteLine("\nAjout de nouvelles données à la base de données...");

        // Ajouter un nouveau voilier
        var nouveauVoilier = new Voilier
        {
            Code = "V006"
        };
        context.Voiliers.Add(nouveauVoilier);
        context.SaveChanges();
        Console.WriteLine("Nouveau voilier ajouté.");

        // Ajouter un nouveau voilier inscrit
        var nouveauVoilierInscrit = new VoilierInscrit(
            id: 0, // Laissez EF générer l'ID automatiquement
            code: nouveauVoilier.Code,
            equipage: new List<Personne>(),
            entreprises: new List<Sponsor>(),
            codeInscription: "VI006"
        );
        context.VoiliersInscrits.Add(nouveauVoilierInscrit);
        context.SaveChanges();
        Console.WriteLine("Nouveau voilier inscrit ajouté.");

        // Ajouter un sponsor au nouveau voilier inscrit
        var nouveauSponsor = new Sponsor(
            id: 0,
            nom: "Sponsor6"
        )
        {
            VoilierInscritId = nouveauVoilierInscrit.Id
        };
        context.Sponsors.Add(nouveauSponsor);
        context.SaveChanges();
        Console.WriteLine("Nouveau sponsor ajouté.");

        // Ajouter une nouvelle personne au voilier
        var nouvellePersonne = new Personne(
            id: 0,
            nom: "Lemoine",
            prenom: "Anna",
            post: "Capitaine"
        )
        {
            VoilierId = nouveauVoilier.Id
        };
        context.Personnes.Add(nouvellePersonne);
        context.SaveChanges();
        Console.WriteLine("Nouvelle personne ajoutée.");

        // Ajouter une nouvelle course
        var nouvelleCourse = new Course
        {
            Nom = "Course 4"
        };
        context.Courses.Add(nouvelleCourse);
        context.SaveChanges();
        Console.WriteLine("Nouvelle course ajoutée.");

        // Ajouter des épreuves à la nouvelle course
        var nouvelleEpreuve1 = new Epreuve(
            numero: 1, // Utilisez un numéro valide supérieur à 0
            libelle: "Epreuve 4.1",
            ordre: 1
        )
        {
            CourseId = nouvelleCourse.Id
        };
        var nouvelleEpreuve2 = new Epreuve(
            numero: 2, // Utilisez un numéro valide supérieur à 0
            libelle: "Epreuve 4.2",
            ordre: 2
        )
        {
            CourseId = nouvelleCourse.Id
        };
        context.Epreuves.AddRange(nouvelleEpreuve1, nouvelleEpreuve2);
        context.SaveChanges();
        Console.WriteLine("Nouvelles épreuves ajoutées.");

        // Ajouter un nouveau voilier course
        var nouveauVoilierCourse = new VoilierCourse(
            id: 0, // Laissez EF générer l'ID automatiquement
            code: nouveauVoilier.Code,
            equipage: new List<Personne>(),
            entreprises: new List<Sponsor>(),
            codeInscription: nouveauVoilierInscrit.CodeInscription,
            tempsBrute: 350.75
        );
        context.VoiliersCourse.Add(nouveauVoilierCourse);
        context.SaveChanges();
        Console.WriteLine("Nouveau voilier course ajouté.");

        // Ajouter une pénalité au nouveau voilier course
        var nouvellePenalite = new Penalite(
            id: "P006",
            duree: 10,
            description: "Infraction mineure"
        )
        {
            VoilierCourseId = nouveauVoilierCourse.Id
        };
        context.Penalites.Add(nouvellePenalite);
        context.SaveChanges();
        nouveauVoilierCourse.CalculerTempsReel(); // Mettre à jour TempsReel après l'ajout de pénalités
        context.SaveChanges();
        Console.WriteLine("Nouvelle pénalité ajoutée.");
    }

    static void AfficherDonnees(VoilierCourseContext context)
    {
        // Récupérer les voiliers inscrits et les afficher
        var voiliersInscrits = context.VoiliersInscrits
            .Include(vi => vi.Sponsors)
            .ToList();

        Console.WriteLine("\nVoiliers Inscrits:");
        foreach (var vi in voiliersInscrits)
        {
            Console.WriteLine($"Voilier Inscrit ID: {vi.Id}, Code Inscription: {vi.CodeInscription}, Voilier Code: {vi.Code}");
            foreach (var sponsor in vi.Sponsors)
            {
                Console.WriteLine($" - Sponsor: {sponsor.Nom}");
            }
        }

        // Récupérer les voiliers courses et leurs informations
        var voiliersCourse = context.VoiliersCourse
            .Include(vc => vc.Sponsors)
            .Include(vc => vc.Penalites)
            .ToList();

        Console.WriteLine("\nVoiliers Courses:");
        foreach (var vc in voiliersCourse)
        {
            Console.WriteLine($"Voilier Course ID: {vc.Id}, Temps Brute: {vc.TempsBrute}, Temps Reel: {vc.TempsReel}");
            foreach (var sponsor in vc.Sponsors)
            {
                Console.WriteLine($" - Sponsor: {sponsor.Nom}");
            }
            foreach (var penalite in vc.Penalites)
            {
                Console.WriteLine($" - Penalite: {penalite.Description}, Duree: {penalite.Duree} minutes");
            }
        }

        // Récupérer les courses et leurs épreuves
        var courses = context.Courses
            .Include(c => c.Epreuves)
            .ToList();

        Console.WriteLine("\nCourses:");
        foreach (var course in courses)
        {
            Console.WriteLine($"Course ID: {course.Id}, Nom: {course.Nom}");
            foreach (var epreuve in course.Epreuves)
            {
                Console.WriteLine($" - Epreuve: {epreuve.Libelle}, Ordre: {epreuve.Ordre}");
            }
        }

        // Récupérer les personnes et leurs voiliers
        var personnes = context.Personnes
            .Include(p => p.Voilier)
            .ToList();

        Console.WriteLine("\nPersonnes:");
        foreach (var personne in personnes)
        {
            Console.WriteLine($"Personne ID: {personne.Id}, Nom: {personne.Nom} {personne.Prenom}, Post: {personne.Post}, Voilier Code: {personne.Voilier.Code}");
        }
    }
}
