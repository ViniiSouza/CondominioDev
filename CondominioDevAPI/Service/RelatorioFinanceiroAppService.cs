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

        public float GetGastoTotal()
        {
            float somaTotal = 0;
            var rendas = _repository.GetRendaDosHabitantes();
            foreach (var renda in rendas)
            {
                somaTotal += renda;
            }
            return somaTotal;
        }

        public float OrcamentoCondominio()
        {
            return _repository.GetOrcamentoCondominio();
        }

        public string DiferencaOrcamentoEGasto()
        {
            float rendaTotal = 0;
            var listaRendas = _repository.GetRendaDosHabitantes();
            var numeroHabitantes = listaRendas.Count;
            listaRendas.ForEach(each =>
            {
                rendaTotal += each;
            });
            var valorCondominio = _repository.GetOrcamentoCondominio() * numeroHabitantes;
            var gastoTotal = rendaTotal - valorCondominio;
            return $"A renda total do condomínio é de R$ {rendaTotal}. Descontando o valor de R$ 450 para cada habitante pelo orçamento do condomínio, o valor de renda final é de R$ {gastoTotal}.";
        }
    }
}
