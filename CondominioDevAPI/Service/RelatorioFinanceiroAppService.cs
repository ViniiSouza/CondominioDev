using AutoMapper;
using CondominioDevAPI.DTOs;
using CondominioDevAPI.Repository;

namespace CondominioDevAPI.Service
{
    public class RelatorioFinanceiroAppService
    {
        private readonly HabitanteRepository _repository;
        private readonly IMapper _mapper;

        public RelatorioFinanceiroAppService(HabitanteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public HabitanteGetDTO GetMaiorCusto()
        {
            var habitante = _repository.MoradorComMaiorCusto();
            return _mapper.Map<HabitanteGetDTO>(habitante);
        }
    }
}
