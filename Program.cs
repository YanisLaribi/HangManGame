using BonnhommePendu.Game;
using BonnhommePendu.Models;
using BonnhommePendu.Views;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var wordBank = new WordBank();
var display  = new ConsoleDisplay();
var session  = new GameSession(wordBank, display);

session.Start();
