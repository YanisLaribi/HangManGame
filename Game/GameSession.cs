namespace BonnhommePendu.Game;

using BonnhommePendu.Interfaces;
using BonnhommePendu.Models;

public class GameSession
{
    private readonly WordBank _wordBank;
    private readonly IGameDisplay _display;

    private int _wins;
    private int _losses;

    public GameSession(WordBank wordBank, IGameDisplay display)
    {
        _wordBank = wordBank;
        _display = display;
        _wins = 0;
        _losses = 0;
    }

    public void Start()
    {
        _display.ClearScreen();
        _display.ShowWelcome();

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("  Press Enter to begin...");
        Console.ResetColor();
        Console.ReadLine();

        bool playing = true;

        while (playing)
        {
            string word = _wordBank.GetRandomWord();
            var game = new HangmanGame(word, _display);

            GameResult result = game.Play();

            if (result.IsWin)
                _wins++;
            else
                _losses++;

            _display.ShowScoreboard(_wins, _losses);

            playing = _display.PromptPlayAgain();
        }

        ShowFarewell();
    }

    private void ShowFarewell()
    {
        _display.ClearScreen();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine();
        Console.WriteLine("  ╔══════════════════════════════════════════╗");
        Console.WriteLine("  ║     Thanks for playing Hangman!          ║");
        Console.WriteLine("  ╚══════════════════════════════════════════╝");
        Console.ResetColor();

        _display.ShowScoreboard(_wins, _losses);

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("  À la prochaine! 👋");
        Console.ResetColor();
        Console.WriteLine();
    }
}
