namespace BonnhommePendu.Game;

using BonnhommePendu.Enums;
using BonnhommePendu.Interfaces;
using BonnhommePendu.Models;

public class HangmanGame
{
    private const int MaxIncorrectGuesses = 6;

    private readonly SecretWord _secretWord;
    private readonly GuessTracker _tracker;
    private readonly IGameDisplay _display;

    public HangmanGame(string word, IGameDisplay display)
    {
        _secretWord = new SecretWord(word);
        _tracker = new GuessTracker();
        _display = display;
    }

    public GameState State
    {
        get
        {
            if (_secretWord.IsFullyRevealed())
                return GameState.Won;
            if (_tracker.IncorrectCount >= MaxIncorrectGuesses)
                return GameState.Lost;
            return GameState.InProgress;
        }
    }

    public int RemainingAttempts => MaxIncorrectGuesses - _tracker.IncorrectCount;

    public GameResult Play()
    {
        while (State == GameState.InProgress)
        {
            RenderCurrentState();

            char guess = _display.PromptForGuess();

            if (_tracker.HasBeenGuessed(guess))
            {
                _display.ShowMessage($"You already guessed '{guess}'. Try another letter.");
                PauseBeforeClear();
                continue;
            }

            bool correct = _secretWord.RevealLetter(guess);
            _tracker.RecordGuess(guess, correct);

            if (correct)
                _display.ShowMessage($"✓ Nice! '{guess}' is in the word!");
            else
                _display.ShowMessage($"✗ '{guess}' is not in the word.");

            PauseBeforeClear();
        }

        RenderCurrentState();

        var result = new GameResult(
            IsWin: State == GameState.Won,
            SecretWord: _secretWord.GetActualWord(),
            TotalGuesses: _tracker.GuessedLetters.Count,
            IncorrectGuesses: _tracker.IncorrectCount
        );

        _display.ShowResult(result);

        return result;
    }

    private void RenderCurrentState()
    {
        _display.ClearScreen();
        _display.ShowHangman(_tracker.IncorrectCount);
        _display.ShowWordProgress(_secretWord.GetMaskedDisplay());
        _display.ShowGuessedLetters(_tracker.GetGuessedDisplay());
        _display.ShowRemainingAttempts(RemainingAttempts);
    }

    private static void PauseBeforeClear()
    {
        Thread.Sleep(1200);
    }
}
