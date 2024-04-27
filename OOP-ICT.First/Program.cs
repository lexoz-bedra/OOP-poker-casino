using OOP_ICT.Models;

namespace OOP_ICT;

public class Program
{
    static void Main(string[] args)
    {
        var dealer = new Dealer();
        dealer.ShuffleDeck();
        dealer.DealDeck();
    }
}