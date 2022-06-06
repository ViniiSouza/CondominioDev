using System.ComponentModel.DataAnnotations;

namespace CondominioDevAPI.DTOs
{
    public class HabitantePostDTO
    {
        [Required(ErrorMessage = "O nome do habitante é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O sobrenome do habitante é obrigatório.")]
        public string Sobrenome { get; set; }

        [RegularExpression(@"\d{2}\/\d{2}\/\d{4}", ErrorMessage = "Informe a data no padrão brasileiro dd/mm/aaaa")]
        [Required(ErrorMessage = "A data de nascimento do habitante é obrigatória.")]
        public string DataNascimento { get; set; }

        [Required(ErrorMessage = "A renda do habitante é obrigatória.")]
        public float Renda { get; set; }

        [RegularExpression(@"(\d{3}(.|-)?){3}\d{2}", ErrorMessage = "Informe o CPF corretamente")]
        [Required(ErrorMessage = "O CPF do habitante é obrigatório.")]
        public string CPF { get; set; }
    }
}
