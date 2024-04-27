namespace OOP_ICT.Second.Models;

using OOP_ICT.Models;


public class PlayerHand
{
    public List<Card> Cards { get; private set; }
    
    public PlayerHand()
    {
        Cards = new List<Card>();
    }
    
    public PlayerHand(List<Card> cards)
    {
        Cards = cards;
    }
    
    public void TakeCard(Card card)
    {
        Cards.Add(card);
    }
    
    public void ClearHand()
    {
        Cards.Clear();
    }
    
    public List<string> ShowHand()
    {
        var cardNames = new List<string>();
        foreach (var card in Cards)
        {
            cardNames.Add(Enum.GetName(card.GetValue()));
        }

        return cardNames;
    }
}