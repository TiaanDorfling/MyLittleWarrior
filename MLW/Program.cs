namespace MLW;
using MLW.View;
using MLW.Controller;
using MLW.Model;
using System.Runtime.CompilerServices;

public class Program
{
    public static void Main(string[] args)
    {
        GameState gameLoop = new GameState();
        gameLoop.GameLoop();
    }
}