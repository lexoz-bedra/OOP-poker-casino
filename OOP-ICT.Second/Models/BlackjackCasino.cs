namespace OOP_ICT.Second.Models;

using OOP_ICT.Models;

public class BlackjackCasino
{
    private bool _checkCards(List<Card> cards)
    {
        return cards.Where(card => card.GetValue() == CardValue.Ace).Any(card => cards.Any(card1 => 
            card1.GetValue() == CardValue.Ten || 
            card1.GetValue() == CardValue.Jack ||
            card1.GetValue() == CardValue.Queen || card1.GetValue() == CardValue.King));
    }
    public bool CheckForBlackjack(Player player)
    {
        return player.PlayerHand.Cards.Count >= 2 && _checkCards(player.PlayerHand.Cards);
    }

    public void AccrueWinnings(Player player, int bet)
    {
        player.GetChips(bet * 2);
    }

    public void AccrueLoss(Player player, int bet)
    {
        player.GiveChips(bet);
    }
}