using CondominioDevAPI.Context;
using CondominioDevAPI.Models;

namespace CondominioDevAPI.Repository
{
    public class HabitanteRepository
    {
        private readonly CondominioDbContext _context;

        public HabitanteRepository(CondominioDbContext context)
        {
            _context = context;
        }

        public void Add(Habitante habitante)
        {
            _context.Habitante.Add(habitante);
            _context.SaveChanges();
        }

        public void Update(Habitante habitante)
        {
            _context.Habitante.Update(habitante);
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var habitante = _context.Habitante.Find(id);
            if (habitante == null)
            {   
                return false;
            }
            _context.Habitante.Remove(habitante);
            _context.SaveChanges();
            return true;
        }

        public Habitante GetById(int id)
        {
            return _context.Habitante.Find(id);
        }

        public IEnumerable<Habitante> GetAll()
        {
            return _context.Habitante.ToList();
        }

        public IEnumerable<Habitante> GetByName(string nome)
        {
            return _context.Habitante.Where(x => x.Nome.Contains(nome)).ToList();
        }

        public IEnumerable<Habitante> GetByMonth(int month)
        {
            return _context.Habitante.Where(x => x.DataNascimento.Month == month).ToList();
        }

        public IEnumerable<Habitante> GetByAge(int idade)
        {
            var dataMaxima = DateTime.Now.AddYears(-idade).AddYears(-1);
            return _context.Habitante.Where(x => x.DataNascimento < dataMaxima);
        }

        public Habitante? GetByCPF(string cpf)
        {
            return _context.Habitante.Where(x => x.CPF == cpf).FirstOrDefault();
        }

        public IEnumerable<Habitante> GetByDateOrBefore(DateTime dataMaxima)
        {
            return _context.Habitante.Where(where => where.DataNascimento <= dataMaxima);
        }
    }
}
