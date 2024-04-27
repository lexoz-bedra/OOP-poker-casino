using OOP_ICT.Second.Models;

namespace OOP_ICT.Fourth.Models;

public class FlushLink : ChainLinkBase
{
    public override Combination Handle(PlayerHand hand)
    {
        var cardSuits = hand.Cards.Select(card => card.GetSuit()).ToList();
        if (hand.Cards.Count >= 5 && cardSuits.Distinct().Count() == 1)
        {
            return Combination.Flush;
        }

        return Next.Handle(hand);
    }
}