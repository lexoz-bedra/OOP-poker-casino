using OOP_ICT.Second.Models;

namespace OOP_ICT.Fourth;

public class NotEnoughCardsException : NotEnoughException
{
    public NotEnoughCardsException() : base("Not enough cards.")
    {
    }
}