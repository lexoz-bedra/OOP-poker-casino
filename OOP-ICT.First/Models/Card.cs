namespace OOP_ICT.Models;

public class Card
{
    private readonly CardSuit _suit;
    private readonly CardValue _value;

    public Card(CardValue value, CardSuit suit)
    {
        _suit = suit;
        _value = value;
    }
    
    public CardSuit GetSuit()
    {
        return _suit;
    }
    
    public CardValue GetValue()
    {
        return _value;
    }

    public override bool Equals(object obj)
    {
        obj = (Card) obj;
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        return ((Card) obj).GetSuit() == _suit && ((Card) obj).GetValue() == _value;
    }
}
