using NUnit.Framework;
using ConsoleAppCyberVoillier;
using System.Collections.Generic;

namespace TestProject1
{

    [TestFixture]
    public class VoilierInscritTests
    {
        [Test]
        public void All()
        {
            // Arrange
            List<Personne> equipage1 = new List<Personne>
            {
                new Personne(1, "Doe", "John", "Skipper"),
                new Personne(2, "Ouagro", "Jack", "Skipper"),
                new Personne(3, "Rogue", "Louise", "AutreRôle"),
                new Personne(4, "Panamous", "Martha", "AutreRôle")
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

            List<Sponsor> sponsors = new List<Sponsor> { new Sponsor(1, "Sponsor1"), new Sponsor(2, "Sponsor2") };
            List<Epreuve> epreuves = new List<Epreuve>
            {
                new Epreuve(1, "water", 2),
                new Epreuve(2, "earth", 1),
                new Epreuve(3, "fire", 3),
                new Epreuve(4, "air", 4),
            };

            Course course = new Course(epreuves);

            // Act
            course.InscrireVoilier(voilier1, sponsors);
            course.InscrireVoilier(voilier2, sponsors);
            course.InscrireVoilier(voilier3, sponsors);
            course.InscrireVoilier(voilier4, sponsors);

            // Assert
            Assert.That(course.Inscrits[0].Id, Is.EqualTo(voilier1.Id));
            Assert.That(course.Inscrits[0].Id, Is.EqualTo(voilier1.Id));
            Assert.That(course.Inscrits[0].Entreprises.Count, Is.EqualTo(2));
            Assert.That(course.Inscrits[0].Entreprises[0].Nom, Is.EqualTo("Sponsor1"));

            course.DebuterLaCourse();

            // Vérifier l'ordre des épreuves
            Assert.That(course.Epreuves[0].Libelle, Is.EqualTo("earth"));
            Assert.That(course.Epreuves[1].Libelle, Is.EqualTo("water"));
            Assert.That(course.Epreuves[2].Libelle, Is.EqualTo("fire"));
            Assert.That(course.Epreuves[3].Libelle, Is.EqualTo("air"));

            // Vérifier les voiliers en course
            Assert.That(course.EnCourse.Count, Is.EqualTo(4));

            // Enregistrer les temps
            course.EnregistrerTemps(voilier1.Id, 1, 97);
            course.EnregistrerTemps(voilier2.Id, 1, 87);
            course.EnregistrerTemps(voilier3.Id, 1, 77);

            // Disqualification
            course.Disqualification(voilier4.Id);

            // Vérifier qu'il a bien été supprimé de la liste des voiliers en course
            Assert.That(course.EnCourse.Exists(v => v.Id == voilier4.Id), Is.False);

            course.EnregistrerTemps(voilier1.Id, 2, 98);
            course.EnregistrerTemps(voilier2.Id, 2, 456);
            course.EnregistrerTemps(voilier3.Id, 2, 435);

            course.EnregistrerTemps(voilier1.Id, 3, 922);
            course.EnregistrerTemps(voilier2.Id, 3, 87);
            course.EnregistrerTemps(voilier3.Id, 3, 566);

            // Tester si on peut finir alors que tous les voiliers n'ont pas fini la course
            Assert.IsFalse(course.FinDeCourse(), "La course ne devrait pas pouvoir se terminer car tous les voiliers n'ont pas enregistré leurs temps.");

            course.EnregistrerTemps(voilier1.Id, 4, 789);
            course.EnregistrerTemps(voilier2.Id, 4, 986);
            course.EnregistrerTemps(voilier3.Id, 4, 456);

            course.AjouterPenalite(voilier1.Id, new Penalite("red_line", 12, "non respect de la ligne rouge"));

            // Vérifier la pénalité
            Assert.That(course.EnCourse[0].Penalites.Count, Is.EqualTo(1));
            Assert.That(course.EnCourse[0].Penalites[0].Id, Is.EqualTo("red_line"));

            course.FinDeCourse();

            // Vérifier que la course est terminée
            bool courseTerminee = course.FinDeCourse();
            Assert.That(courseTerminee, Is.True);

            // Vérifier le classement
            var classement = course.ClasserVoiliers();
            Assert.That(classement.Count, Is.EqualTo(3));
            Assert.That(classement[0].Code, Is.EqualTo("HT201MNTP")); //1821 sec
            Assert.That(classement[1].Code, Is.EqualTo("VA103SETE")); //1529 sec
            Assert.That(classement[2].Code, Is.EqualTo("VA102SETE")); //1457 sec
        }
    }
}
