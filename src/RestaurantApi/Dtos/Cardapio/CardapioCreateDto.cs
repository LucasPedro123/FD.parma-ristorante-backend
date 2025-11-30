namespace RestaurantAPI.Dtos.Cardapio
{
    public class CardapioCreateDto
    {
        public string Nome { get; set; } = default!;
        public string Descricao { get; set; } = default!;
        public decimal Preco { get; set; } = default!;
        public bool Disponivel { get; set; } = default!;
        public string Categoria { get; set; } = default!;
        
    }
}
