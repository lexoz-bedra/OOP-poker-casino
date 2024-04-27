using OOP_ICT.Models;
using OOP_ICT.Second.Models;

namespace OOP_ICT.Fourth.Models;

public class RoyalFlushLink : ChainLinkBase
{
    public override Combination Handle(PlayerHand hand)
    {
        var cardValues = hand.Cards.Select(card => card.GetValue()).ToList();
        var cardSuits = hand.Cards.Select(card => card.GetSuit()).ToList();
        if (hand.Cards.Count >= 5 && cardValues.Contains(CardValue.Ace) &&
            cardValues.Contains(CardValue.King) && cardValues.Contains(CardValue.Queen) &&
            cardValues.Contains(CardValue.Jack) && cardValues.Contains(CardValue.Ten) &&
            cardSuits.Distinct().Count() == 1)
        {
            return Combination.RoyalFlush;
        }

        return Next.Handle(hand);
    }
}