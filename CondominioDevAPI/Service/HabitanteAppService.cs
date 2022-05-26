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

        public void Delete(int id)
        {
            _repository.Delete(id);
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
    }
}
