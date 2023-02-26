using GestionEtudiants.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionEtudiants.Context
{
    public class AppDbContext: DbContext 
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Filiere> Filieres { get; set; }
        public DbSet<Adresse> Adresses { get; set; }

        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions options) : base(options) { }
    }
}
