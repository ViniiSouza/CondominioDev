using AutoMapper;
using CondominioDevAPI.DTOs;
using CondominioDevAPI.Models;
using CondominioDevAPI.Repository;

namespace CondominioDevAPI.Service
{
    public class HabitanteAppService
    {
        private readonly HabitanteRepository _repository;
        private readonly IMapper _mapper;

        public HabitanteAppService(HabitanteRepository repository, IMapper mapper)
        //public HabitanteAppService(HabitanteRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public bool Add(HabitantePostDTO habitante)
        {
            var habitanteExistente = _repository.GetByCPF(habitante.CPF) != null ? true : false;
            if (habitanteExistente)
            {
                return false;
            }
            var habitanteConvertido = _mapper.Map<Habitante>(habitante);
            //var habitanteConvertido = new Habitante();
            _repository.Add(habitanteConvertido);
            return true;
        }

        public void Update(Habitante habitante)
        {
            _repository.Update(habitante);
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public Habitante GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<HabitanteGetDTO> GetAll()
        {
            var habitantes = _repository.GetAll();
            return _mapper.Map<IEnumerable<HabitanteGetDTO>>(habitantes);
        }

        public IEnumerable<HabitanteGetDTO> GetByName(string nome)
        {
            var habitantes = _repository.GetByName(nome);
            return _mapper.Map<IEnumerable<HabitanteGetDTO>>(habitantes);
        }

        public IEnumerable<HabitanteGetDTO> GetByMonth(int month)
        {
            var habitantes = _repository.GetByMonth(month);
            return _mapper.Map<IEnumerable<HabitanteGetDTO>>(habitantes);
        }

        public IEnumerable<HabitanteGetDTO> GetByAgeBiggerThan(int idade)
        {
            var dataMaxima = DateTime.Now.AddYears(-idade);
            var habitantes = _repository.GetByDateOrBefore(dataMaxima);
            return _mapper.Map<IEnumerable<HabitanteGetDTO>>(habitantes);
        }

        public HabitanteDetailDTO GetDetailsById(int id)
        {
            var habitante = _repository.GetById(id);
            return _mapper.Map<HabitanteDetailDTO>(habitante);
        }
    }
}
