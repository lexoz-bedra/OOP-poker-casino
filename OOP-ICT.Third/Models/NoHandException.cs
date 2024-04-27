namespace OOP_ICT.Third.Models;

public class NoHandException : Exception
{
    public NoHandException() : base("No player hand.")
    {
    }
}