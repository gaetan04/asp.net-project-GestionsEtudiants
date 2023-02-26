using System.ComponentModel.DataAnnotations.Schema;

namespace GestionEtudiants.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string SurName { get; set; }
        public string FirstName { get; set; }
        public int FiliereId { get; set; }
        public string Sexe { get; set; }

        [ForeignKey(nameof(FiliereId))]
        public virtual Filiere Filiere { get; set; }

        public virtual ICollection<Adresse> Adresses { get; set; }
    }
}
