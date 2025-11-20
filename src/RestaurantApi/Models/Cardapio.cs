namespace RestaurantAPI.Models
{
    public class Cardapio
    {
        public int Id { get; set; } = default!;
        public string Nome { get; set; } = default!;
        public string Descricao { get; set; } = default!;
        public decimal Preco { get; set; } = default!;
        public string Categoria { get; set; } = default!;
        public bool Disponivel { get; set; } = true;
        public string ImagemUrl { get; set; } = default!;
    }
}