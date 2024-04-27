using OOP_ICT.Models;

namespace OOP_ICT.Second;

using Models;

public class Program
{
    private static void Main(string[] args)
    {
        var casino = new BlackjackCasino();
        var player1 = new PlayerBuilder().Build();
        var player2 = new PlayerBuilder().Build();
        var dealer = new Dealer();
    }
}


