using OOP_ICT.Models;
using OOP_ICT.Second.Models;

namespace OOP_ICT.Fourth.Models;

public class ThreeOfAKindLink : ChainLinkBase
{
    public override Combination Handle(PlayerHand hand)
    {
        var cardValues = hand.Cards.Select(card => card.GetValue()).ToList();
        if (cardValues.Count(cardValue => cardValue == CardValue.Ace) == 3 ||
            cardValues.Count(cardValue => cardValue == CardValue.King) == 3 ||
            cardValues.Count(cardValue => cardValue == CardValue.Queen) == 3 ||
            cardValues.Count(cardValue => cardValue == CardValue.Jack) == 3 ||
            cardValues.Count(cardValue => cardValue == CardValue.Ten) == 3 ||
            cardValues.Count(cardValue => cardValue == CardValue.Nine) == 3 ||
            cardValues.Count(cardValue => cardValue == CardValue.Eight) == 3 ||
            cardValues.Count(cardValue => cardValue == CardValue.Seven) == 3 ||
            cardValues.Count(cardValue => cardValue == CardValue.Six) == 3 ||
            cardValues.Count(cardValue => cardValue == CardValue.Five) == 3 ||
            cardValues.Count(cardValue => cardValue == CardValue.Four) == 3 ||
            cardValues.Count(cardValue => cardValue == CardValue.Three) == 3 ||
            cardValues.Count(cardValue => cardValue == CardValue.Two) == 3)
        {
            return Combination.ThreeOfAKind;
        }

        return Next.Handle(hand);
    }
}