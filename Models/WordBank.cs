namespace BonnhommePendu.Models;

public class WordBank
{
    private readonly List<string> _words;
    private readonly Random _random;

    public WordBank()
    {
        _random = new Random();
        _words = new List<string>
        {
            "PROGRAMMING", "ALGORITHM", "DEVELOPER", "COMPUTER", "SOFTWARE",
            "KEYBOARD",    "FUNCTION",  "VARIABLE",  "COMPILER", "DATABASE",
            "NETWORK",     "SECURITY",  "ABSTRACT",  "INHERIT",  "POLYMORPHISM",
            "INTERFACE",   "EXCEPTION", "DEBUGGING", "TERMINAL", "ENCAPSULATE",
            "ITERATION",   "RECURSION", "FRAMEWORK", "LIBRARY",  "OPERATOR",
            "CONSTRUCTOR", "DESTRUCTOR","PARAMETER", "ARGUMENT", "NAMESPACE"
        };
    }

    public string GetRandomWord()
    {
        int index = _random.Next(_words.Count);
        return _words[index];
    }

    public int Count => _words.Count;
}
