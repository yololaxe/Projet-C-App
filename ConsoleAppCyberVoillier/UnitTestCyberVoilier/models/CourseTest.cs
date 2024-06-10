using ConsoleAppCyberVoillier;

namespace UnitTestCyberVoilier.models;

[TestFixture]
[TestOf(typeof(Course))]
public class CourseTest
{

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
        var course = new Course(8, epreuves);

        course.InscrireVoilier(voilier, sponsors);
        course.DebuterLaCourse();

        // Act
        course.EnregistrerTemps(voilier.Id, 1, 100);

        // Assert
        Assert.That(course.EnCourse.First(v => v.Id == voilier.Id).EpreuvesEffectuees.Count, Is.EqualTo(1));
        Assert.That(course.EnCourse.First(v => v.Id == voilier.Id).TempsBrute, Is.EqualTo(100));
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
        var course = new Course(4, epreuves);

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
        var course = new Course(5, epreuves);

        // Assert
        Assert.Throws<InvalidOperationException>(() => course.Disqualification(999), "Le voilier n'est pas inscrit.");
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
        var course = new Course(6,epreuves);

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
        var course = new Course(7,epreuves);

        course.InscrireVoilier(voilier, sponsors);
        course.DebuterLaCourse();

        // Act & Assert
        Assert.IsFalse(course.FinDeCourse(), "La course ne peut pas se terminer sans temps enregistrés.");
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
        var course = new Course(1,epreuves);

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
        var course = new Course(2, epreuves);

        // Assert
        Assert.Throws<InvalidOperationException>(() => course.DebuterLaCourse(), "Il n'y a pas de voiliers inscrits pour débuter la course.");
    }

    [Test]
    public void EnregistrerTemps_VoilierNonInscrit_DoitLancerUneException()
    {
        // Arrange
        var epreuves = new List<Epreuve> { new Epreuve(1, "test", 1) };
        var course = new Course(3,epreuves);

        // Assert
        Assert.Throws<InvalidOperationException>(() => course.EnregistrerTemps(999, 1, 100), "Le voilier n'est pas inscrit.");
    }
}