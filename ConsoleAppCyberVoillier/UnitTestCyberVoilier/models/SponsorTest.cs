using ConsoleAppCyberVoillier;

namespace UnitTestCyberVoilier.models;

[TestFixture]
[TestOf(typeof(Sponsor))]
public class SponsorTest
{

    [Test]
        public void Constructor_ValidParameters_ShouldCreateSponsor()
        {
            var sponsor = new Sponsor(1, "Sponsor1");

            // Assert
            Assert.That(sponsor.Id, Is.EqualTo(1));
            Assert.That(sponsor.Nom, Is.EqualTo("Sponsor1"));
        }

        [Test]
        public void Constructor_InvalidId_ShouldThrowArgumentOutOfRangeException()
        {
           
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Sponsor(0, "Sponsor1"));
            Assert.That(ex.Message, Does.Contain("Id doit être plus grand que zero."));
        }

        [Test]
        public void Constructor_NullName_ShouldThrowArgumentNullException()
        {
            
            var ex = Assert.Throws<ArgumentNullException>(() => new Sponsor(1, null));
            Assert.That(ex.ParamName, Is.EqualTo("value"));
        }

        [Test]
        public void Constructor_EmptyName_ShouldThrowArgumentException()
        {
           
            var ex = Assert.Throws<ArgumentException>(() => new Sponsor(1, ""));
            Assert.That(ex.Message, Does.Contain("Nom ne peut pas être vide ou un espace."));
        }

        [Test]
        public void Constructor_WhitespaceName_ShouldThrowArgumentException()
        {
          
            var ex = Assert.Throws<ArgumentException>(() => new Sponsor(1, " "));
            Assert.That(ex.Message, Does.Contain("Nom ne peut pas être vide ou un espace."));
        }

        [Test]
        public void SetId_ValidValue_ShouldSetId()
        {
            
            var sponsor = new Sponsor(1, "Sponsor1");

            
            sponsor.Id = 2;

            // Assert
            Assert.That(sponsor.Id, Is.EqualTo(2));
        }

        [Test]
        public void SetId_InvalidValue_ShouldThrowArgumentOutOfRangeException()
        {
         
            var sponsor = new Sponsor(1, "Sponsor1");

            //Assert
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => sponsor.Id = 0);
            Assert.That(ex.Message, Does.Contain("Id doit être plus grand que zero."));
        }

        [Test]
        public void SetNom_ValidValue_ShouldSetNom()
        {
            var sponsor = new Sponsor(1, "Sponsor1");
            sponsor.Nom = "Sponsor2";

            // Assert
            Assert.That(sponsor.Nom, Is.EqualTo("Sponsor2"));
        }

        [Test]
        public void SetNom_NullValue_ShouldThrowArgumentNullException()
        {
            // Arrange
            var sponsor = new Sponsor(1, "Sponsor1");

            // Act & Assert
            var ex = Assert.Throws<ArgumentNullException>(() => sponsor.Nom = null);
            Assert.That(ex.ParamName, Is.EqualTo("value"));
        }

        [Test]
        public void SetNom_EmptyValue_ShouldThrowArgumentException()
        {
            // Arrange
            var sponsor = new Sponsor(1, "Sponsor1");

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => sponsor.Nom = "");
            Assert.That(ex.Message, Does.Contain("Nom ne peut pas être vide ou un espace."));
        }

        [Test]
        public void SetNom_WhitespaceValue_ShouldThrowArgumentException()
        {
            // Arrange
            var sponsor = new Sponsor(1, "Sponsor1");

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => sponsor.Nom = " ");
            Assert.That(ex.Message, Does.Contain("Nom ne peut pas être vide ou un espace."));
        }

}