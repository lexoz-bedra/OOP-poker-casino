using OOP_ICT.Second.Models;
using OOP_ICT.Third.Models;

namespace OOP_ICT.Third;

public class Program
{
    static void Main(string[] args)
    {
        var game = new BlackjackGame();
        game.ChooseBetSize(100);
        var player1 = new PlayerBuilder().WithCasinoAccount(300).WithBankAccount(100).Build();
        var player2 = new PlayerBuilder().WithCasinoAccount(300).WithBankAccount(100).Build();
        player1.BuyChips(200);
        player2.BuyChips(200);
        
        game.AddPlayer(player1);
        game.AddPlayer(player2);
        game.StartGame();
        game.CompareHands();
    }
}