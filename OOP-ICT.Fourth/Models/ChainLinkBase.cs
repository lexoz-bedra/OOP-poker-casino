using OOP_ICT.Second.Models;

namespace OOP_ICT.Fourth.Models;

public abstract class ChainLinkBase
{
    protected ChainLinkBase Next { get; set; }
    
    public virtual void AddNext(ChainLinkBase next)
    {
        Next = next;
    }

    public abstract Combination Handle(PlayerHand hand);
}