namespace BonnhommePendu.Models;

public record GameResult(
    bool IsWin,
    string SecretWord,
    int TotalGuesses,
    int IncorrectGuesses
);
