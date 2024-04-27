using OOP_ICT.Models;
using OOP_ICT.Second.Models;

namespace OOP_ICT.Third.Models;

public class BlackjackGame
{
    private BlackjackCasino Casino { get; set; } = new();
    public List<Player> Players { get; private set; } = new();
    public DealerWithHand Dealer { get; private set; } = new();
    public int Bet { get; private set; }


    public void AddPlayer(Player player)
    {
        Players.Add(player);
    }

    public void StartGame()
    {
        Dealer.ShuffleDeck();
        foreach (var player in Players)
        {
            player.Bet(Bet);
            player.PlayerHand.ClearHand();
        }

        Dealer.Hand.ClearHand();
        DealInitialCards();
    }

    public void DealInitialCards()
    {
        foreach (var player in Players)
        {
            player.PlayerHand.TakeCard(Dealer.DealCard());
            player.PlayerHand.TakeCard(Dealer.DealCard());
        }

        foreach (var player in Players)
        {
            while (GetTotalPoints(player.PlayerHand) < 21)
            {
                if (Dealer.IsDeckEmpty())
                {
                    throw new InvalidOperationException("No cards left.");
                }

                player.PlayerHand.TakeCard(Dealer.DealCard());
            }
        }

        const int maxDealerPoints = 17;
        Dealer.Hand.TakeCard(Dealer.DealCard());
        while (GetTotalPoints(Dealer.Hand) < maxDealerPoints)
        {
            if (Dealer.IsDeckEmpty())
            {
                throw new InvalidOperationException("No cards left.");
            }

            Dealer.Hand.TakeCard(Dealer.DealCard());
        }
    }

    public void ChooseBetSize(int bet)
    {
        if (bet >= 0)
        {
            Bet = bet;
            Console.WriteLine("Bet chosen successfully.");
            return;
        }

        throw new InvalidOperationException("Negative bet.");
    }

    public void CompareHands()
    {
        const int maxPoints = 21;
        if (Players is null)
        {
            throw new NoPlayersException();
        }
        foreach (var player in Players)
        {
            if (player.PlayerHand is null)
            {
                throw new NoHandException();
            }
            if (GetTotalPoints(player.PlayerHand) > maxPoints)
            {
                Casino.AccrueLoss(player, Bet);
            }
            else if (Casino.CheckForBlackjack(player))
            {
                Casino.AccrueWinnings(player, Bet);
            }
            else if (GetTotalPoints(player.PlayerHand) > GetTotalPoints(Dealer.Hand))
            {
                Casino.AccrueWinnings(player, Bet);
            }
            else if (GetTotalPoints(player.PlayerHand) < GetTotalPoints(Dealer.Hand))
            {
                Casino.AccrueLoss(player, Bet);
            }
        }
    }

    public int GetTotalPoints(PlayerHand hand)
    {
        var adapter = new CardValueAdapter();
        const int aceIfManyPoints = 1;
        const int maxPoints = 21;
        var totalPoints = 0;
        var aces = 0;
        foreach (var card in hand.Cards)
        {
            if (card.GetValue() == CardValue.Ace)
            {
                aces++;
            }
            else
            {
                totalPoints += adapter.GetCardPoints(card.GetValue());
            }
        }
        
        for (var i = 0; i < aces; i++)
        {
            if (totalPoints + adapter.GetCardPoints(CardValue.Ace) <= maxPoints)
            {
                totalPoints += adapter.GetCardPoints(CardValue.Ace);
            }
            else
            {
                totalPoints += aceIfManyPoints;
            }
        }

        return totalPoints;
    }
}