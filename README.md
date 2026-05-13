# The HangedMan

Console-based Hangman game developed in C# with .NET 8, applying core object-oriented programming principles.

## Features

- ASCII art gallows with 7 progressive stages
- Color-coded console output (lives, feedback, prompts)
- Heart-based life indicator (6 attempts per round)
- Sorted display of previously guessed letters
- Multi-round sessions with persistent scoreboard
- Input validation on every guess

## Project Structure

```
BonnhommePendu/
├── Program.cs
├── Enums/
│   └── GameState.cs
├── Interfaces/
│   └── IGameDisplay.cs
├── Models/
│   ├── GameResult.cs
│   ├── GuessTracker.cs
│   ├── SecretWord.cs
│   └── WordBank.cs
├── Game/
│   ├── GameSession.cs
│   └── HangmanGame.cs
└── Views/
    └── ConsoleDisplay.cs
```

## Architecture

The project follows a layered architecture separating concerns across distinct responsibilities:

| Layer | Classes | Role |
|---|---|---|
| Models | `SecretWord`, `GuessTracker`, `WordBank`, `GameResult` | Data and state management |
| Enums | `GameState` | Game status representation |
| Interfaces | `IGameDisplay` | Abstraction for display operations |
| Views | `ConsoleDisplay` | Console rendering and user input |
| Game | `HangmanGame`, `GameSession` | Game flow and session orchestration |

### OOP Principles

- **Encapsulation** -- `SecretWord` hides the actual word behind a masked display. `GuessTracker` manages guess state internally with a private `HashSet`.
- **Abstraction** -- `IGameDisplay` defines a contract for all rendering operations, decoupling game logic from the console.
- **Composition** -- `GameSession` composes `WordBank` and `HangmanGame` to manage multi-round play.
- **Single Responsibility** -- Each class handles one concern: word state, guess tracking, rendering, or game flow.
- **Dependency Inversion** -- `HangmanGame` depends on the `IGameDisplay` interface rather than the concrete `ConsoleDisplay` class.

## Prerequisites

- .NET SDK 8.0 or later

## How to Run

```bash
cd BonnhommePendu
dotnet run
```

## Gameplay

1. A random word is selected from a bank of 30 programming-related terms.
2. The player guesses one letter at a time.
3. Correct guesses reveal letter positions. Incorrect guesses add a body part to the gallows.
4. The game ends when the word is fully revealed (win) or after 6 incorrect guesses (loss).
5. The player can choose to play again; the scoreboard carries over across rounds.
