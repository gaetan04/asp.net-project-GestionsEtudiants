using GestionEtudiants.Context;
using GestionEtudiants.Interfaces;
using GestionEtudiants.Models;

namespace GestionEtudiants.Application
{
    public class FiliereRepository : IFiliereRepository
    {
        private AppDbContext _appDbContext;

        public FiliereRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Filiere Add(Filiere filiere)
        {
            _appDbContext.Filieres.Add(filiere);
            _appDbContext.SaveChanges();
            return filiere;
        }

        public int Delete(int id)
        {
            var fil = _appDbContext.Filieres.Find(id);
            _appDbContext.Filieres.Remove(fil);
            return _appDbContext.SaveChanges() ;
        }

        public List<Filiere> GetAll()
        {
            var filieres = _appDbContext.Filieres.ToList();

            return filieres;
        }

        public Filiere GetFiliereById(int id)
        {
            var filiere = _appDbContext.Filieres.Find(id);

            return filiere;
        }

        public Filiere Update(Filiere filiere)
        {
            _appDbContext.Update(filiere);

            _appDbContext.SaveChanges ();
            return filiere;
        }
    }
}
