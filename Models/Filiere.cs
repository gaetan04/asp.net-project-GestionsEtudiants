namespace GestionEtudiants.Models
{
    public class Filiere
    {
        public int FiliereId { get; set; }
        public string FiliereName { get; set;}

        public virtual ICollection<Student> Students { get; set; }
    }
}
