using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ConsoleAppCyberVoillier.database
{
    public partial class VoilierCourseContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Epreuve> Epreuves { get; set; }
        public DbSet<Penalite> Penalites { get; set; }
        public DbSet<Personne> Personnes { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<Voilier> Voiliers { get; set; }
        public DbSet<VoilierCourse> VoiliersCourse { get; set; }
        public DbSet<VoilierInscrit> VoiliersInscrits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=localhost;Database=voiliercoursedb;Uid=root;");
                          //.EnableSensitiveDataLogging()
                          //.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Epreuves)
                .WithOne(e => e.Course)
                .HasForeignKey(e => e.CourseId);

            modelBuilder.Entity<Epreuve>()
                .HasKey(e => e.Numero);

            modelBuilder.Entity<Voilier>()
                .HasKey(v => v.Id);
            modelBuilder.Entity<Voilier>()
                .HasMany(v => v.Equipage)
                .WithOne(p => p.Voilier)
                .HasForeignKey(p => p.VoilierId);

            modelBuilder.Entity<VoilierInscrit>()
                .ToTable("VoiliersInscrits")
                .HasMany(vi => vi.Sponsors)
                .WithOne(s => s.VoilierInscrit)
                .HasForeignKey(s => s.VoilierInscritId);

            modelBuilder.Entity<VoilierCourse>()
                .ToTable("VoiliersCourse");

            modelBuilder.Entity<Personne>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Sponsor>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<Penalite>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Penalite>()
                .Property(p => p.Id)
                .HasMaxLength(191);

            modelBuilder.Entity<Penalite>()
                .HasOne(p => p.VoilierCourse)
                .WithMany(vc => vc.Penalites)
                .HasForeignKey(p => p.VoilierCourseId);
        }
    }
}
