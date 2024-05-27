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
            List<Personne> equipage = new List<Personne>
            {
                new Personne(1, "Doe", "John", "Skipper"),
                new Personne(2, "Ouagro", "Jack", "Skipper"),
                new Personne(3, "Rogue", "Louise", "AutreRôle"),
                new Personne(4, "Panamous", "Martha", "AutreRôle")
            };
            Voilier voilier = new Voilier(1, "VA102SETE", equipage);
            List<Sponsor> sponsors = new List<Sponsor> { new Sponsor(1, "Sponsor1"), new Sponsor(2, "Sponsor2") };
            List<VoilierInscrit> voiliersInscrits = new List<VoilierInscrit>();
            List<VoilierCourse> voiliersEnCourse = new List<VoilierCourse>();
            List<Epreuve> epreuves = new List<Epreuve>();
            Course course = new Course(voiliersInscrits, voiliersEnCourse, epreuves);

            // Act
            VoilierInscrit voilierInscrit = course.InscrireVoilier(voilier, sponsors);

            // Assert
            Assert.That(voilierInscrit.Id, Is.EqualTo(voilier.Id));
            Assert.That(voilierInscrit, Is.EqualTo(course.Inscrits[0]));
            Assert.That(voilierInscrit.Entreprises.Count, Is.EqualTo(2));
            Assert.That(voilierInscrit.Entreprises[0].Nom, Is.EqualTo("Sponsor1"));
        }
    }
    

    
}
