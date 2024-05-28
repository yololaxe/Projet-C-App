using NUnit.Framework;
using ConsoleAppCyberVoillier;
using System.Collections.Generic;

namespace TestProject1
{
    [TestFixture]
    public class VoilierTests
    {
        [Test]
        public void CreerVoilier_AvecCodeEtEquipage_CreeCorrectement()
        {
            string code = "VA102SETE";
            List<Personne> equipage = new List<Personne>
            {
                new Personne(1,"Doe","John", "Skipper"),
                new Personne(2,"Ouagro","Jack", "Skipper"),
                new Personne(3,"Rogue","Louise", "AutreRôle"),
                new Personne(4,"Panamous","Martha", "AutreRôle")
            };
            
            
            Voilier voilier = new Voilier(1, code, equipage);
            
            Assert.That(voilier.Code, Is.EqualTo(code));
            Assert.That(voilier.Equipage.Count, Is.EqualTo(4));
            Assert.That(voilier.Equipage[0].Nom, Is.EqualTo("Doe"));
        }
    }

    [TestFixture]
    public class VoilierInscritTests
    {
        [Test]
        public void InscrireVoilier_AUneCourse_InscritCorrectement()
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
        [Test]
        
    public void InscrireVoilier_DejaInscrit_DoitLancerUneException()
    {
        // Arrange
        var equipage = new List<Personne>
        {
            new Personne(1, "Dupont", "Jean", "Skipper")
        };
        var voilier = new Voilier(1, "VOILIER1", equipage);
        var sponsors = new List<Sponsor> { new Sponsor(1, "Sponsor1") };
        var epreuves = new List<Epreuve> { new Epreuve(1, "test", 1) };
        var course = new Course(epreuves);

        // Act
        course.InscrireVoilier(voilier, sponsors);

        // Assert
        Assert.Throws<InvalidOperationException>(() => course.InscrireVoilier(voilier, sponsors), "Le voilier est déjà inscrit.");
    }

    [Test]
    public void DebuterLaCourse_SansInscrits_DoitLancerUneException()
    {
        // Arrange
        var epreuves = new List<Epreuve> { new Epreuve(1, "test", 1) };
        var course = new Course(epreuves);

        // Assert
        Assert.Throws<InvalidOperationException>(() => course.DebuterLaCourse(), "Il n'y a pas de voiliers inscrits pour débuter la course.");
    }

    [Test]
    public void EnregistrerTemps_VoilierNonInscrit_DoitLancerUneException()
    {
        // Arrange
        var epreuves = new List<Epreuve> { new Epreuve(1, "test", 1) };
        var course = new Course(epreuves);

        // Assert
        Assert.Throws<InvalidOperationException>(() => course.EnregistrerTemps(999, 1, 100), "Le voilier n'est pas inscrit.");
    }

    [Test]
    public void EnregistrerTemps_EpreuveNonExistante_DoitLancerUneException()
    {
        // Arrange
        var equipage = new List<Personne>
        {
            new Personne(1, "Dupont", "Jean", "Skipper")
        };
        var voilier = new Voilier(1, "VOILIER1", equipage);
        var sponsors = new List<Sponsor> { new Sponsor(1, "Sponsor1") };
        var epreuves = new List<Epreuve> { new Epreuve(1, "test", 1) };
        var course = new Course(epreuves);

        course.InscrireVoilier(voilier, sponsors);
        course.DebuterLaCourse();

        // Assert
        Assert.Throws<InvalidOperationException>(() => course.EnregistrerTemps(voilier.Id, 999, 100), "L'épreuve n'existe pas.");
    }

    [Test]
    public void FinDeCourse_SansTempsEnregistres_DoitRetournerFalse()
    {
        // Arrange
        var equipage = new List<Personne>
        {
            new Personne(1, "Dupont", "Jean", "Skipper")
        };
        var voilier = new Voilier(1, "VOILIER1", equipage);
        var sponsors = new List<Sponsor> { new Sponsor(1, "Sponsor1") };
        var epreuves = new List<Epreuve> { new Epreuve(1, "test", 1) };
        var course = new Course(epreuves);

        course.InscrireVoilier(voilier, sponsors);
        course.DebuterLaCourse();

        // Act & Assert
        Assert.IsFalse(course.FinDeCourse(), "La course ne peut pas se terminer sans temps enregistrés.");
    }

    [Test]
    public void EnregistrerTemps_TempsNegatif_DoitLancerUneException()
    {
        // Arrange
        var equipage = new List<Personne>
        {
            new Personne(1, "Dupont", "Jean", "Skipper")
        };
        var voilier = new Voilier(1, "VOILIER1", equipage);
        var sponsors = new List<Sponsor> { new Sponsor(1, "Sponsor1") };
        var epreuves = new List<Epreuve> { new Epreuve(1, "test", 1) };
        var course = new Course(epreuves);

        course.InscrireVoilier(voilier, sponsors);
        course.DebuterLaCourse();

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => course.EnregistrerTemps(voilier.Id, 1, -100), "Le temps ne peut pas être négatif.");
    }

    [Test]
    public void Disqualification_VoilierNonInscrit_DoitLancerUneException()
    {
        // Arrange
        var epreuves = new List<Epreuve> { new Epreuve(1, "test", 1) };
        var course = new Course(epreuves);

        // Assert
        Assert.Throws<InvalidOperationException>(() => course.Disqualification(999), "Le voilier n'est pas inscrit.");
    }

    [Test]
    public void EnregistrerTemps_TempsEnregistresCorrectement()
    {
        // Arrange
        var equipage = new List<Personne>
        {
            new Personne(1, "Dupont", "Jean", "Skipper")
        };
        var voilier = new Voilier(1, "VOILIER1", equipage);
        var sponsors = new List<Sponsor> { new Sponsor(1, "Sponsor1") };
        var epreuves = new List<Epreuve> { new Epreuve(1, "test", 1) };
        var course = new Course(epreuves);

        course.InscrireVoilier(voilier, sponsors);
        course.DebuterLaCourse();

        // Act
        course.EnregistrerTemps(voilier.Id, 1, 100);

        // Assert
        Assert.That(course.EnCourse.First(v => v.Id == voilier.Id).EpreuvesEffectuees.Count, Is.EqualTo(1));
        Assert.That(course.EnCourse.First(v => v.Id == voilier.Id).TempsBrute, Is.EqualTo(100));
    }

    
}
    }
    [TestFixture]
    public class EpreuveTests
    {
        [Test]
        public void CreerEpreuve_AvecNumeroLibelleEtOrdre_CreeCorrectement()
        {
            // Arrange
            int numero = 1;
            string libelle = "Test Epreuve";
            int ordre = 2;

            // Act
            Epreuve epreuve = new Epreuve(numero, libelle, ordre);

            // Assert
            Assert.That(epreuve.Numero, Is.EqualTo(numero));
            Assert.That(epreuve.Libelle, Is.EqualTo(libelle));
            Assert.That(epreuve.Ordre, Is.EqualTo(ordre));
        }

        [Test]
        public void CreerEpreuve_AvecNumeroNegatif_DevraitLeverArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Epreuve(-1, "Test Epreuve", 2));
        }

        [Test]
        public void CreerEpreuve_AvecLibelleNull_DevraitLeverArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Epreuve(1, null, 2));
        }

        [Test]
        public void CreerEpreuve_AvecLibelleVide_DevraitLeverArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Epreuve(1, "", 2));
        }

        [Test]
        public void CreerEpreuve_AvecOrdreNegatif_DevraitLeverArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Epreuve(1, "Test Epreuve", -2));
        }
        
}
