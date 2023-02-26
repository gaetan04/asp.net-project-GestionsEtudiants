using System.ComponentModel.DataAnnotations.Schema;

namespace GestionEtudiants.Models
{
    public class Adresse
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int StudentId { get; set; }

        [ForeignKey(nameof(StudentId))]
        public virtual Student Student { get; set; }
    }
}
