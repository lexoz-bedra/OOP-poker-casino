namespace OOP_ICT.Third.Models;

public class NoPlayersException : Exception
{
    public NoPlayersException() : base("No players in game.")
    {
    }
}