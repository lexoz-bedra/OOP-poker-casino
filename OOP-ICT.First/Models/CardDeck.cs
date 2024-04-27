namespace OOP_ICT.Models;

public class CardDeck
{

    private readonly List<Card> _cards;

    public CardDeck()
    {
        _cards = (from suit in Enum.GetValues<CardSuit>()
             from value in Enum.GetValues<CardValue>()
             select new Card(value, suit)).ToList();
    }

    public CardDeck(List<Card> cards)
    {
        _cards = cards;
    }

    public List<Card> ShowCards()
    {
        return _cards.ToList();
    }

    public int CountCards()
    {
        return _cards.Count;
    }

    public bool IsEmpty()
    {
        return _cards.Count == 0;
    }

    public void DealCard()
    {
        if (IsEmpty())
        {
            throw new IndexOutOfRangeException("No cards left in the deck!");
        }
        
        _cards.RemoveAt(_cards.Count - 1);
    }
}
