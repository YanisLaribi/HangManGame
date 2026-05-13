namespace BonnhommePendu.Models;

public class GuessTracker
{
    private readonly HashSet<char> _guessedLetters;

    public GuessTracker()
    {
        _guessedLetters = new HashSet<char>();
        IncorrectCount = 0;
    }

    public int IncorrectCount { get; private set; }

    public IReadOnlyCollection<char> GuessedLetters => _guessedLetters;

    public bool HasBeenGuessed(char letter)
    {
        return _guessedLetters.Contains(char.ToUpper(letter));
    }

    public bool RecordGuess(char letter, bool wasCorrect)
    {
        letter = char.ToUpper(letter);

        if (!_guessedLetters.Add(letter))
            return false;

        if (!wasCorrect)
            IncorrectCount++;

        return true;
    }

    public string GetGuessedDisplay()
    {
        var sorted = _guessedLetters.OrderBy(c => c);
        return string.Join(", ", sorted);
    }
}
