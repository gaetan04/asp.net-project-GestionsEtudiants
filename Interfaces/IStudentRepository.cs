using GestionEtudiants.Models;

namespace GestionEtudiants.Interfaces
{
    public interface IStudentRepository
    {
        Student GetStudentById(int StudentId);
        List<Student> GetAll();

        Student Add(Student student);
        Student Update(Student student);
        int Delete(int StudentId);
    }
}
