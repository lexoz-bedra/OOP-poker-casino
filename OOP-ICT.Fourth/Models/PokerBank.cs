using OOP_ICT.Second.Models;

namespace OOP_ICT.Fourth.Models;

public class PokerBank : Bank
{
    public void AccrueWinnings(Player player, int amount)
    {
        player.GetChips(amount);
    }
    
    public void AccrueLoss(Player player, int amount)
    {
        player.GiveChips(amount);
    }
    
    public bool CheckForSufficientFunds(Player player, int bet)
    {
        return player.CasinoAccount.Chips >= bet;
    }
    
    public void TakeBet(Player player, int bet)
    {
        if (!CheckForSufficientFunds(player, bet))
        {
            throw new NotEnoughMoneyException("Not enough chips.");
        }
        player.Bet(bet);
    }
}