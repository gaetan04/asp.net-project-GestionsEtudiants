using GestionEtudiants.Models;

namespace GestionEtudiants.Interfaces
{
    public interface IFiliereRepository
    {
        Filiere GetFiliereById(int id);
        List<Filiere> GetAll();
        Filiere Add(Filiere filiere);
        Filiere Update(Filiere filiere);
        int Delete(int id);
    }
}
