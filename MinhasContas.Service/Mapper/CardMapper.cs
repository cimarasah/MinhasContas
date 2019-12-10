using MinhasContas.DAL.Interface.Entities;
using MinhasContas.Domain.Enuns;
using MinhasContas.Domain.Models;
using MinhasContas.Service.Interface.Mapper;
using System.Collections.Generic;
using System.Linq;

namespace MinhasContas.Service.Mapper
{
    public sealed class CardMapper : IMapper<CardModel, Card>
    {
        
        public IEnumerable<Card> ListMapToEntity(IEnumerable<CardModel> listModel) =>
            listModel.Select(MapToEntity);
        public IEnumerable<CardModel> ListMapToModel(IEnumerable<Card> listEntity) =>
            listEntity.Select(MapToModel);

        public Card MapToEntity(CardModel model)
        {
            return new Card
            {
                Name = model.Name,
                CardNumber = model.CardNumber,
                CardBanner = (int) model.CardBanner,
                ClosingDay = model.ClosingDay,
                DueDay = model.DueDay,
                Limit = model.Limit,
                Color = (int)model.Color


            };
        }

        public CardModel MapToModel(Card entity)
        {
            return new CardModel
            {
                Name = entity.Name,
                CardNumber = entity.CardNumber,
                CardBanner = (CardBannerEnum)entity.CardBanner,
                ClosingDay = entity.ClosingDay,
                DueDay = entity.DueDay,
                Limit = entity.Limit,
                Color = (ColorEnum)entity.Color
            };
        }
    }
}
