namespace OOP_ICT.Third.Models;

public class UnknownCardException : Exception
{
    public UnknownCardException() : base("Unknown card value.")
    {
    }
}