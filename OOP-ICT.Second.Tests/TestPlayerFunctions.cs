namespace OOP_ICT.Second.Tests;

using Xunit;
using Models;

public class TestPlayerFunctions
{
    [Fact]
    public void CanPlayerPutMoneyToBank_InputIsPlayerAndMoney_ReturnTrue()
    {
        var player = new PlayerBuilder().WithBankAccount(100).WithCasinoAccount(200).Build();
        int amount = 100;
        
        player.PutMoneyToAccount(amount, player.BankAccount);
        
        Assert.Equal(200, player.BankAccount.Balance);
        Assert.Equal(100, player.Balance);
    }
    
    [Fact]
    public void CanPlayerPutMoneyToBank_InputIsPlayerAndMoney_ReturnFalse()
    {
        var player = new PlayerBuilder().WithBankAccount(100).WithCasinoAccount(200).Build();
        int amount = 300;
        
        Assert.Throws<NotEnoughMoneyException>(() => player.PutMoneyToAccount(amount, player.BankAccount));
    }
    
    [Fact]
    public void CanPlayerTakeMoneyFromBank_InputIsPlayerAndMoney_ReturnTrue()
    {
        var player = new PlayerBuilder().WithBankAccount(100).WithCasinoAccount(200).Build();
        int amount = 100;
        
        player.TakeMoneyFromAccount(amount, player.BankAccount);
        
        Assert.Equal(0, player.BankAccount.Balance);
        Assert.Equal(300, player.Balance);
    }
    
    [Fact]
    public void CanPlayerTakeMoneyFromBank_InputIsPlayerAndMoney_ReturnFalse()
    {
        var player = new PlayerBuilder().WithBankAccount(100).WithCasinoAccount(200).Build();
        int amount = 300;
        
        Assert.Throws<NotEnoughMoneyException>(() => player.TakeMoneyFromAccount(amount, player.BankAccount));
    }
    
    [Fact]
    public void CanPlayerPutMoneyToCasino_InputIsPlayerAndMoney_ReturnTrue()
    {
        var player = new PlayerBuilder().WithBankAccount(100).WithCasinoAccount(200).Build();
        int amount = 100;
        
        player.PutMoneyToAccount(amount, player.CasinoAccount);
        
        Assert.Equal(300, player.CasinoAccount.Balance);
        Assert.Equal(100, player.Balance);
    }
    
    [Fact]
    public void CanPlayerPutMoneyToCasino_InputIsPlayerAndMoney_ReturnFalse()
    {
        var player = new PlayerBuilder().WithBankAccount(100).WithCasinoAccount(200).Build();
        int amount = 300;
        
        Assert.Throws<NotEnoughMoneyException>(() => player.PutMoneyToAccount(amount, player.CasinoAccount));
    }
    
    [Fact]
    public void CanPlayerTakeMoneyFromCasino_InputIsPlayerAndMoney_ReturnTrue()
    {
        var player = new PlayerBuilder().WithBankAccount(100).WithCasinoAccount(200).Build();
        int amount = 100;
        
        player.TakeMoneyFromAccount(amount, player.CasinoAccount);
        
        Assert.Equal(100, player.CasinoAccount.Balance);
        Assert.Equal(300, player.Balance);
    }
    
    [Fact]
    public void CanPlayerTakeMoneyFromCasino_InputIsPlayerAndMoney_ReturnFalse()
    {
        var player = new PlayerBuilder().WithBankAccount(100).WithCasinoAccount(200).Build();
        int amount = 300;
        
        Assert.Throws<NotEnoughMoneyException>(() => player.TakeMoneyFromAccount(amount, player.CasinoAccount));
    }
    
    [Fact]
    public void CanPlayerBet_InputIsPlayerAndMoney_ReturnTrue()
    {
        var player = new PlayerBuilder().WithBankAccount(100).WithCasinoAccount(200).Build();
        int amount = 100;
        
        player.BuyChips(amount);
        player.Bet(amount);
        
        Assert.Equal(100, player.CasinoAccount.Chips);
    }
    
    [Fact]
    public void CanPlayerBuyChips_InputIsPlayerAndMoney_ReturnTrue()
    {
        var player = new PlayerBuilder().WithBankAccount(100).WithCasinoAccount(200).Build();
        int amount = 100;
        
        player.BuyChips(amount);
        
        Assert.Equal(100, player.CasinoAccount.Balance);
        Assert.Equal(100, player.CasinoAccount.Chips);
    }
    
    [Fact]
    public void CanPlayerBuyChips_InputIsPlayerAndMoney_ReturnFalse()
    {
        var player = new PlayerBuilder().WithBankAccount(100).WithCasinoAccount(200).Build();
        int amount = 300;
        
        Assert.Throws<NotEnoughMoneyException>(() => player.BuyChips(amount));
    }
    
    [Fact]
    public void CanPlayerSellChips_InputIsPlayerAndMoney_ReturnTrue()
    {
        var player = new PlayerBuilder().WithBankAccount(100).WithCasinoAccount(200).Build();
        player.BuyChips(100);
        int amount = 100;
        
        player.SellChips(amount);
        
        Assert.Equal(200, player.CasinoAccount.Balance);
        Assert.Equal(0, player.CasinoAccount.Chips);
    }
    
    [Fact]
    public void CanPlayerSellChips_InputIsPlayerAndMoney_ReturnFalse()
    {
        var player = new PlayerBuilder().WithBankAccount(100).WithCasinoAccount(200).Build();
        player.BuyChips(100);
        int amount = 300;
        
        Assert.Throws<NotEnoughMoneyException>(() => player.SellChips(amount));
    }
    
    [Fact]
    public void CanPlayerGetChips_InputIsPlayer_ReturnTrue()
    {
        var player = new PlayerBuilder().WithBankAccount(100).WithCasinoAccount(200).Build();
        int amount = 100;
        
        player.GetChips(amount);
        
        Assert.Equal(100, player.CasinoAccount.Chips);
    }
    
    [Fact]
    public void CanPlayerGiveChips_InputIsPlayer_ReturnTrue()
    {
        var player = new PlayerBuilder().WithBankAccount(100).WithCasinoAccount(200).Build();
        player.GetChips(100);
        int amount = 100;
        
        player.GiveChips(amount);
        
        Assert.Equal(0, player.CasinoAccount.Chips);
    }
    
    [Fact]
    public void CanPlayerGiveChips_InputIsPlayer_ReturnFalse()
    {
        var player = new PlayerBuilder().WithBankAccount(100).WithCasinoAccount(200).Build();
        player.GetChips(100);
        int amount = 300;
        
        Assert.Throws<NotEnoughMoneyException>(() => player.GiveChips(amount));
    }
}