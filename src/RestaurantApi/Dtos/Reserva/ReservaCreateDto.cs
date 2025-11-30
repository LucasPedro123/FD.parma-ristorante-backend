namespace RestaurantAPI.Dtos.Reserva
{
    public class ReservaCreateDto
    {
        public string Nome { get; set; } = default!;
        public string Telefone { get; set; }
        public int QuantidadePessoas { get; set; }
        public DateTime DataReserva { get; set; }
        public string Observacoes { get; set; }
    }
}