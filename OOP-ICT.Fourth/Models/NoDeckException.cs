namespace OOP_ICT.Fourth.Models;

public class NoDeckException : Exception
{
    public NoDeckException() : base("No deck.")
    {
    }
    
}