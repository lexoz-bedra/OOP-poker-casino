namespace OOP_ICT.Models;

public class Dealer : IDealer
{
    private CardDeck _deck = new();
    

    public void ShuffleDeck()
    {
        var cardsToShuffle = _deck.ShowCards();
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

        _deck = new CardDeck(cardsToShuffle);
    }

    public List<Card> GetCards()
    {
        return _deck.ShowCards();
    }

    public void DealDeck()
    {
        var cardsToDeal = _deck.ShowCards();
        while (!_deck.IsEmpty())
        {
            _deck.DealCard();
        }
    }
    
    public Card DealCard()
    {
        var card = _deck.ShowCards().Last();
        _deck.DealCard();
        return card;
    }
    
    public bool IsDeckEmpty()
    {
        return _deck.IsEmpty();
    }
}