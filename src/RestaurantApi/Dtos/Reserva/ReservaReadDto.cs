namespace RestaurantAPI.Dtos.Reserva
{
    public class CardapioReadDto
    {
        public int Id { get; set; } = default!;
        public string Nome { get; set; } = default!;
        public string Telefone { get; set; } = default!;
        public decimal QuantidadePessoas { get; set; } = default!;
        public DateTime DataReserva { get; set; } = default!;
        public string Observacoes { get; set; } = default!;
    }
}