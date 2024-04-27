namespace OOP_ICT.Second.Models;

public abstract class NotEnoughException : Exception
{
    protected NotEnoughException(string message) : base(message)
    {
    }
}