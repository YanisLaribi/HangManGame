namespace BonnhommePendu.Interfaces;

using BonnhommePendu.Models;

public interface IGameDisplay
{
    void ShowWelcome();
    void ShowHangman(int incorrectGuesses);
    void ShowWordProgress(string maskedWord);
    void ShowGuessedLetters(string letters);
    void ShowRemainingAttempts(int remaining);
    void ShowMessage(string message);
    void ShowResult(GameResult result);
    void ShowScoreboard(int wins, int losses);
    char PromptForGuess();
    bool PromptPlayAgain();
    void ClearScreen();
}
