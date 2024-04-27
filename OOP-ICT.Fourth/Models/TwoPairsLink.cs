using OOP_ICT.Second.Models;

namespace OOP_ICT.Fourth.Models;

public class TwoPairsLink : ChainLinkBase
{
    public override Combination Handle(PlayerHand hand)
    {
        var cardValues = hand.Cards.Select(card => card.GetValue()).ToList();
        if (hand.Cards.Count >= 5 && cardValues.Distinct().Count() == 3)
        {
            return Combination.TwoPairs;
        }

        return Next.Handle(hand);
    }
}