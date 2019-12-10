using MinhasContas.Domain.Enuns;

namespace MinhasContas.Domain.Models
{
    public class CardModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CardNumber { get; set; }
        public CardBannerEnum CardBanner { get; set; }
        public int ClosingDay { get; set; }
        public int DueDay { get; set; }
        public double Limit { get; set; }
        public ColorEnum Color { get; set; }
    }
}
