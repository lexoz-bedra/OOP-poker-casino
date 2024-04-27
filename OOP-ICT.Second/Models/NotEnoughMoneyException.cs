namespace OOP_ICT.Second.Models;

public class NotEnoughMoneyException : NotEnoughException
{
    public NotEnoughMoneyException() : base("Not enough money.")
    {
    }
    
    public NotEnoughMoneyException(string message) : base(message)
    {
    }
}