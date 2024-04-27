namespace OOP_ICT.Fourth.Models;

public class ButtonGivenException : Exception
{
    public ButtonGivenException() : base("Button already given.")
    {
    }
}