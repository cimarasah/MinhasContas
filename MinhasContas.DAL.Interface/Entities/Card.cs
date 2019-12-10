using System;

namespace MinhasContas.DAL.Interface.Entities
{
    public class Card : BaseEntity
    {
        public string Name { get; set; }
        public string CardNumber { get; set; }
        public int CardBanner { get; set; }
        public int ClosingDay { get; set; }
        public int DueDay { get; set; }
        public double Limit { get; set; }
        public int Color { get; set; }
    }
}
