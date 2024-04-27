using OOP_ICT.Models;
using OOP_ICT.Second.Models;

namespace OOP_ICT.Fourth.Models;

public class FourOfAKindLink : ChainLinkBase
{
    public override Combination Handle(PlayerHand hand)
    {
        var cardValues = hand.Cards.Select(card => card.GetValue()).ToList();
        if (cardValues.Count(cardValue => cardValue == CardValue.Ace) == 4 ||
            cardValues.Count(cardValue => cardValue == CardValue.King) == 4 ||
            cardValues.Count(cardValue => cardValue == CardValue.Queen) == 4 ||
            cardValues.Count(cardValue => cardValue == CardValue.Jack) == 4 ||
            cardValues.Count(cardValue => cardValue == CardValue.Ten) == 4 ||
            cardValues.Count(cardValue => cardValue == CardValue.Nine) == 4 ||
            cardValues.Count(cardValue => cardValue == CardValue.Eight) == 4 ||
            cardValues.Count(cardValue => cardValue == CardValue.Seven) == 4 ||
            cardValues.Count(cardValue => cardValue == CardValue.Six) == 4 ||
            cardValues.Count(cardValue => cardValue == CardValue.Five) == 4 ||
            cardValues.Count(cardValue => cardValue == CardValue.Four) == 4 ||
            cardValues.Count(cardValue => cardValue == CardValue.Three) == 4 ||
            cardValues.Count(cardValue => cardValue == CardValue.Two) == 4)
        {
            return Combination.FourOfAKind;
        }

        return Next.Handle(hand);
    }
}