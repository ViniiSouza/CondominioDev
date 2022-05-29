namespace CondominioDevAPI.DTOs
{
    public class HabitanteDetailDTO
    {
        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public DateTime DataNascimento { get; set; }

        public float Renda { get; set; }

        public string CPF { get; set; }
    }
}
