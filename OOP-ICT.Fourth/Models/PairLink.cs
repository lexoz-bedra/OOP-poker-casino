using OOP_ICT.Second.Models;

namespace OOP_ICT.Fourth.Models;

public class PairLink : ChainLinkBase
{
    public override Combination Handle(PlayerHand hand)
    {
        var cardValues = hand.Cards.Select(card => card.GetValue()).ToList();
        if (hand.Cards.Count >= 5 && cardValues.Distinct().Count() == 4)
        {
            return Combination.Pair;
        }

        return Next.Handle(hand);
    }
}