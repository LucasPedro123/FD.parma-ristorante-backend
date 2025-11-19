namespace RestaurantAPI.Models
{
    public class Cardapio
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public string Categoria { get; set; } = string.Empty;
        public bool Ativo { get; set; } = true;
        public string ImagemUrl { get; set; } = string.Empty;
    }
}