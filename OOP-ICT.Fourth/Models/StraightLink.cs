using OOP_ICT.Second.Models;

namespace OOP_ICT.Fourth.Models;

public class StraightLink : ChainLinkBase
{
    public override Combination Handle(PlayerHand hand)
    {
        
        var cardValues = hand.Cards.Select(card => card.GetValue()).ToList();
        if (hand.Cards.Count >= 5 && cardValues.Max() - cardValues.Min() == 4)
        {
            return Combination.Straight;
        }

        return Next.Handle(hand);
    }
}