using Tasks.HangManGame;

namespace Tests.HangManGameTests;

public class HangManGameTests
{
    [Test]
    public void Game_InitialState_ExpectEmptyWordWithUnderscores()
    {
        var game = new HangMan("hello");
        Assert.That("_____", Is.EqualTo(game.WordToShow));
    }
    
    [Test]
    public void Game_InitialState_ExpectCorrectLetterInWord()
    {
        var game = new HangMan("ronaldo");
        game.Guess('r');
        Assert.That("r______", Is.EqualTo(game.WordToShow));
    }

    [Test]
    public void Game_GuessIncorrectLetter_ExpectTriesLeftDecreased()
    {
        var game = new HangMan("ronaldo");
        game.Guess('y');
        Assert.That(4, Is.EqualTo(game.TriesLeft));
    }

    [Test]
    public void Game_GuessCorrectWord_ExpectVictoryIsTrue()
    {
        var game = new HangMan("ronaldo");
        game.Guess('o');
        game.Guess('r');
        game.Guess('n');
        game.Guess('a');
        game.Guess('d');
        game.Guess('l');
        Assert.That(game.Victory,Is.True);
    }
    
    [Test]
    public void Game_GuessWrongWord_ExpectVictoryIsFalse()
    {
        var game = new HangMan("ronaldo");
        game.Guess('x');
        game.Guess('y');
        game.Guess('z');
        game.Guess('g');
        game.Guess('k');
        game.Guess('p');
        Assert.That(game.Victory,Is.False);
    }
}