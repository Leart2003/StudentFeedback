using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentFeedback.Models;

namespace StudentFeedback.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Subject> Subjects => Set<Subject>();
    public DbSet<Feedback> Feedbacks => Set<Feedback>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); 

        modelBuilder.Entity<Subject>().HasData(
            new Subject { Id = 1, Name = "Kompjutimi Grid dhe Cloud", IsElective = false },
            new Subject { Id = 2, Name = "Siguria kibernetike dhe mbrojtja e të dhënave", IsElective = false },
            new Subject { Id = 3, Name = "Tema të avancuara në rrjeta kompjuterike", IsElective = false },
            new Subject { Id = 4, Name = "Gërmimi i avancuar i të dhënave", IsElective = false },
            new Subject { Id = 5, Name = "Etika profesionale e IT", IsElective = true }
        );
    }
}