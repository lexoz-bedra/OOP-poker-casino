using OOP_ICT.Second.Models;
using Xunit;

namespace OOP_ICT.Second.Tests;

public class TestBankFunctions
{
    [Fact]
    public void CanBankDepositMoneyToAccount_InputIsAccountAndMoney_ReturnTrue()
    {
        var bank = new Bank();
        var player = new PlayerBuilder().WithBankAccount(100).WithCasinoAccount(200).Build();
        
        bank.GiveMoney(player.BankAccount, 100);
        
        Assert.Equal(200, player.BankAccount.Balance);
    }
    
    [Fact]
    public void CanBankWithdrawMoneyFromAccount_InputIsAccountAndMoney_ReturnTrue()
    {
        var bank = new Bank();
        var player = new PlayerBuilder().WithBankAccount(100).WithCasinoAccount(200).Build();
        
        bank.TakeMoney(player.BankAccount, 100);
        
        Assert.Equal(0, player.BankAccount.Balance);
    }
    
    [Fact]
    public void CanBankDepositMoneyToAccount_InputIsAccountAndMoney_ReturnFalse()
    {
        var bank = new Bank();
        var player = new PlayerBuilder().WithBankAccount(100).WithCasinoAccount(200).Build();
        
        Assert.Throws<NotEnoughMoneyException>(() => bank.TakeMoney(player.BankAccount, 200));
    }
    
    [Fact]
    public void CanBankWithdrawMoneyFromAccount_InputIsAccountAndMoney_ReturnFalse()
    {
        var bank = new Bank();
        var player = new PlayerBuilder().WithBankAccount(100).WithCasinoAccount(200).Build();
        
        Assert.Throws<NotEnoughMoneyException>(() => bank.TakeMoney(player.BankAccount, 200));
    }
}