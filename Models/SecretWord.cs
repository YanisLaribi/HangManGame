namespace BonnhommePendu.Models;

public class SecretWord
{
    private readonly string _word;
    private readonly bool[] _revealed;

    public SecretWord(string word)
    {
        _word = word.ToUpper();
        _revealed = new bool[_word.Length];
    }

    public int Length => _word.Length;

    public bool RevealLetter(char letter)
    {
        letter = char.ToUpper(letter);
        bool found = false;

        for (int i = 0; i < _word.Length; i++)
        {
            if (_word[i] == letter)
            {
                _revealed[i] = true;
                found = true;
            }
        }

        return found;
    }

    public string GetMaskedDisplay()
    {
        char[] display = new char[_word.Length];

        for (int i = 0; i < _word.Length; i++)
        {
            display[i] = _revealed[i] ? _word[i] : '_';
        }

        return string.Join(' ', display);
    }

    public bool IsFullyRevealed()
    {
        return _revealed.All(r => r);
    }

    public string GetActualWord() => _word;
}
