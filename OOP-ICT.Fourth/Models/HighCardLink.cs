using OOP_ICT.Second.Models;

namespace OOP_ICT.Fourth.Models;

public class HighCardLink : ChainLinkBase
{
    public override Combination Handle(PlayerHand hand)
    {
        return Combination.HighCard;
    }
}