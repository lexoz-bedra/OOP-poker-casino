using OOP_ICT.Models;
using OOP_ICT.Second.Models;

namespace OOP_ICT.Third.Models;

public class DealerWithHand : Dealer
{
    public PlayerHand Hand { get; private set; } = new();
}