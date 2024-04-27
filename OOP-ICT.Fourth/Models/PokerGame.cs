using OOP_ICT.Models;
using OOP_ICT.Second.Models;

namespace OOP_ICT.Fourth.Models;

public class PokerGame
{
    public List<PokerPlayer> Players { get; private set; }
    public DealerButton Button { get; private set; }
    public PokerBank Bank { get; private set; }
    public CardDeck Deck { get; private set; }
    
    public PokerGame(List<PokerPlayer> players, DealerButton button, PokerBank bank)
    {
        
        Players = players;
        Button = button;
        Bank = bank;
    }

    public void StartNewGame(List<PokerPlayer> players, int bet)
    {
        Players = players;
        Button = new DealerButton();
        Bank = new PokerBank();
        Deck = new CardDeck();
        
        foreach (var player in Players)
        {
            Bank.TakeBet(player, bet);
            player.PlayerHand.ClearHand();
        }
        
        players[0].GiveButton(Button, Deck);
        players[0].ShuffleDeck();
        DealCards(players);
    }
    
    public void DealCards(List<PokerPlayer> players)
    {
        var numCards = 5;
        foreach (var player in players)
        {
            for (var j = 0; j < numCards; j++)
            {
                player.PokerHand.Hand.TakeCard(players[0].DealCard());
            }
        }
    }
    
    public void GetBets(int amount) {
        foreach (var player in Players)
        {
            if (player.CasinoAccount.Chips < amount)
            {
                throw new NotEnoughMoneyException("Not enough chips.");
            }
            player.Bet(amount);
        }
    }
    
    public void CompareHands(List<PokerPlayer> players, int bet)
    {
        var bestHand = players[0].PokerHand;
        var bestPlayer = players[0];
        for (var i = 1; i < players.Count; i++)
        {
            if (players[i].PokerHand.CompareTo(bestHand) > 0)
            {
                bestHand = players[i].PokerHand;
                bestPlayer = players[i];
            }
        }
        AccrueWinnings(bestPlayer, bet);
        foreach (var player in players)
        {
            if (player != bestPlayer)
            {
                AccrueLosses(player, bet);
            }
        }
    }
    
    public void AccrueWinnings(PokerPlayer player, int bet) {
        player.GetChips(bet * 2);
    }
    
    public void AccrueLosses(PokerPlayer player, int bet) {
        player.GiveChips(bet);
    }
}