using OOP_ICT.Models;
using OOP_ICT.Second.Models;
using OOP_ICT.Third.Models;

namespace OOP_ICT.Fourth.Models;

public class PokerPlayer : Player
{
    public DealerButton Button { get; private set; }
    private CardDeck Deck { get; set; }
    public PokerHand PokerHand { get; private set; }

    public PokerPlayer(BankAccount bankAccount, CasinoAccount casinoAccount,
        PlayerHand hand) : base(bankAccount, casinoAccount, hand)
    {
        PokerHand = new PokerHand(hand);
    }
    
    public void GiveButton(DealerButton button, CardDeck deck)
    {
        if (Button is not null)
        {
            throw new ButtonGivenException();
        }

        Button = button;
        Deck = deck;
    }
    
    public void TakeButton()
    {
        if (Button is null)
        {
            throw new NoButtonException();
        }

        Button = null;
        Deck = null;
    }
    
    public void MoveButtonTo(PokerPlayer player)
    {
        if (player is null)
        {
            throw new NoPlayersException();
        }

        if (Button is null)
        {
            throw new NoButtonException();
        }

        var button = Button;
        var deck = Deck;
        TakeButton();
        player.GiveButton(button, deck);
    }

    public void ShuffleDeck()
    {
        if (Button is null)
        {
            throw new NoButtonException();
        }
        
        if (Deck is null)
        {
            throw new NoDeckException();
        }

        var cardsToShuffle = Deck.ShowCards();
        var half1 = new List<Card>();
        var half2 = new List<Card>();

        for (var i = 0; i < cardsToShuffle.Count; i++)
        {
            if (i < cardsToShuffle.Count / 2)
            {
                half1.Add(cardsToShuffle[i]);
            }
            else
            {
                half2.Add(cardsToShuffle[i]);
            }
        }

        cardsToShuffle.Clear();

        for (var i = 0; i < half1.Count; i++)
        {
            cardsToShuffle.Add(half1[i]);
            cardsToShuffle.Add(half2[i]);
        }

        Deck = new CardDeck(cardsToShuffle);
    }


    public Card DealCard()
    {
        if (Button is null)
        {
            throw new NoButtonException();
        }

        if (Deck is null)
        {
            throw new NoDeckException();
        }

        if (Deck.IsEmpty())
        {
            throw new NotEnoughCardsException();
        }

        var card = Deck.ShowCards().Last();
        Deck.DealCard();
        return card;
    }
}