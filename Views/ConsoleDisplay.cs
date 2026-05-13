namespace BonnhommePendu.Views;

using BonnhommePendu.Interfaces;
using BonnhommePendu.Models;

public class ConsoleDisplay : IGameDisplay
{
    private static readonly string[][] HangmanStages =
    {
        new[]
        {
            "  ┌───────┐ ",
            "  │       │ ",
            "  │         ",
            "  │         ",
            "  │         ",
            "  │         ",
            "══╧════════ "
        },
        new[]
        {
            "  ┌───────┐ ",
            "  │       │ ",
            "  │      😵 ",
            "  │         ",
            "  │         ",
            "  │         ",
            "══╧════════ "
        },
        new[]
        {
            "  ┌───────┐ ",
            "  │       │ ",
            "  │      😵 ",
            "  │       │ ",
            "  │       │ ",
            "  │         ",
            "══╧════════ "
        },
        new[]
        {
            "  ┌───────┐ ",
            "  │       │ ",
            "  │      😵 ",
            "  │      /│ ",
            "  │       │ ",
            "  │         ",
            "══╧════════ "
        },
        new[]
        {
            "  ┌───────┐ ",
            "  │       │ ",
            "  │      😵 ",
            "  │      /│\\",
            "  │       │ ",
            "  │         ",
            "══╧════════ "
        },
        new[]
        {
            "  ┌───────┐ ",
            "  │       │ ",
            "  │      😵 ",
            "  │      /│\\",
            "  │       │ ",
            "  │      /  ",
            "══╧════════ "
        },
        new[]
        {
            "  ┌───────┐ ",
            "  │       │ ",
            "  │      😵 ",
            "  │      /│\\",
            "  │       │ ",
            "  │      / \\",
            "══╧════════ "
        }
    };

    public void ShowWelcome()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine();
        Console.WriteLine("  ╔══════════════════════════════════════════╗");
        Console.WriteLine("  ║                                          ║");
        Console.WriteLine("  ║      LE  BONHOMME  PENDU                ║");
        Console.WriteLine("  ║         ── Hangman Game ──              ║");
        Console.WriteLine("  ║                                          ║");
        Console.WriteLine("  ╚══════════════════════════════════════════╝");
        Console.ResetColor();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("  Guess the word one letter at a time.");
        Console.WriteLine("  You have 6 attempts before the hangman is complete!");
        Console.ResetColor();
        Console.WriteLine();
    }

    public void ShowHangman(int incorrectGuesses)
    {
        int stage = Math.Clamp(incorrectGuesses, 0, HangmanStages.Length - 1);
        Console.ForegroundColor = incorrectGuesses >= 5 ? ConsoleColor.Red : ConsoleColor.Yellow;

        foreach (string line in HangmanStages[stage])
        {
            Console.WriteLine(line);
        }

        Console.ResetColor();
        Console.WriteLine();
    }

    public void ShowWordProgress(string maskedWord)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("  Word:    ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(maskedWord);
        Console.ResetColor();
    }

    public void ShowGuessedLetters(string letters)
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($"  Guessed: [{letters}]");
        Console.ResetColor();
    }

    public void ShowRemainingAttempts(int remaining)
    {
        ConsoleColor color = remaining switch
        {
            <= 1 => ConsoleColor.Red,
            <= 3 => ConsoleColor.Yellow,
            _    => ConsoleColor.Green
        };

        Console.ForegroundColor = color;
        Console.WriteLine($"  Lives:   {new string('♥', remaining)}{new string('♡', 6 - remaining)}  ({remaining}/6)");
        Console.ResetColor();
        Console.WriteLine();
    }

    public void ShowMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"  >> {message}");
        Console.ResetColor();
    }

    public void ShowResult(GameResult result)
    {
        Console.WriteLine();

        if (result.IsWin)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  ╔══════════════════════════════════════════╗");
            Console.WriteLine("  ║          🎉  YOU WON!  🎉               ║");
            Console.WriteLine("  ╚══════════════════════════════════════════╝");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  ╔══════════════════════════════════════════╗");
            Console.WriteLine("  ║          💀  GAME OVER  💀              ║");
            Console.WriteLine("  ╚══════════════════════════════════════════╝");
        }

        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"  The word was: {result.SecretWord}");
        Console.WriteLine($"  Total guesses: {result.TotalGuesses} | Incorrect: {result.IncorrectGuesses}");
        Console.ResetColor();
        Console.WriteLine();
    }

    public void ShowScoreboard(int wins, int losses)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("  ┌─────────────────────────┐");
        Console.WriteLine($"  │  Scoreboard             │");
        Console.WriteLine($"  │  Wins:   {wins,-5}          │");
        Console.WriteLine($"  │  Losses: {losses,-5}          │");
        Console.WriteLine("  └─────────────────────────┘");
        Console.ResetColor();
        Console.WriteLine();
    }

    public char PromptForGuess()
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("  Enter a letter: ");
            Console.ForegroundColor = ConsoleColor.Cyan;

            string? input = Console.ReadLine()?.Trim();
            Console.ResetColor();

            if (!string.IsNullOrEmpty(input) && input.Length == 1 && char.IsLetter(input[0]))
            {
                return char.ToUpper(input[0]);
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  ✗ Please enter a single letter (A-Z).");
            Console.ResetColor();
        }
    }

    public bool PromptPlayAgain()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("  Play again? (Y/N): ");
        Console.ForegroundColor = ConsoleColor.Cyan;

        string? input = Console.ReadLine()?.Trim().ToUpper();
        Console.ResetColor();

        return input == "Y" || input == "YES";
    }

    public void ClearScreen()
    {
        try { Console.Clear(); }
        catch (IOException) { }
    }
}
