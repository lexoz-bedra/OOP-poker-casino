using OOP_ICT.Models;
using Xunit;

namespace OOP_ICT.FIrst.Tests;

public class TestCardFunctions
{
    /// <summary>
    /// Тесты пишутся из трех частей итог - данные - что вернуло 
    /// </summary>
    [Fact]
    public void AreEquals_InputIsValueAndSuit_ReturnTrue()
    {
        // Пока карты не написаны, давайте проверим числа и строки
        var value = 10;
        var suit = "some suit";

        Assert.Equal(10, value);
        Assert.Equal("some suit", suit);
    }

    [Fact]
    public void IsValidCard_InputIsCard_ReturnTrue()
    {
        var card = new Card(CardValue.Ace, CardSuit.Hearts);

        Assert.Contains(CardValue.Ace, Enum.GetValues<CardValue>());
        Assert.Contains(CardSuit.Hearts, Enum.GetValues<CardSuit>());
    }
    
    [Fact]
    public void AreEqualCardsEqual_InputIsCard_ReturnTrue()
    {
        var card = new Card(CardValue.Ace, CardSuit.Hearts);
        var cardToCompare = new Card(CardValue.Ace, CardSuit.Hearts);
        
        Assert.Equal(card, cardToCompare);
    }
}