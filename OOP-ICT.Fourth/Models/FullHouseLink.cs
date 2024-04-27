using OOP_ICT.Second.Models;

namespace OOP_ICT.Fourth.Models;

public class FullHouseLink : ChainLinkBase
{
    public override Combination Handle(PlayerHand hand)
    {
        var cardValues = hand.Cards.Select(card => card.GetValue()).ToList();
        if (hand.Cards.Count >= 5 && cardValues.Distinct().Count() == 2)
        {
            return Combination.FullHouse;
        }

        return Next.Handle(hand);
    }
}