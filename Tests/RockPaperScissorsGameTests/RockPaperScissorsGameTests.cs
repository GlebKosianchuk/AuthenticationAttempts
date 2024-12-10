using Tasks.RockPaperScissorsGame;

namespace Tests.RockPaperScissorsGameTests;

public class RockPaperScissorsGameTests
{
    [Test]

    public void Game_PlayerWins_WithRockAgainstScissors()
    {
        var game = new Game();
        var result = game.Play(Move.Rock, Move.Scissors);
        Assert.That("You win!", Is.EqualTo(result));
    }

    [Test]

    public void Game_PlayerLose_WithScissorsAgainstRock()
    {
        var game = new Game();
        var result = game.Play(Move.Scissors, Move.Rock);
        Assert.That("You loss!", Is.EqualTo(result));
    }
    
    [Test]

    public void Game_DrawWithSameMoves()
    {
        var game = new Game();
        
        var result = game.Play(Move.Scissors, Move.Scissors);
        Assert.That("Draw!", Is.EqualTo(result));
        
        result = game.Play(Move.Rock, Move.Rock);
        Assert.That("Draw!", Is.EqualTo(result));
        
        result = game.Play(Move.Paper, Move.Paper);
        Assert.That("Draw!", Is.EqualTo(result));
    }
    
    [Test]
    
    public void Game_ComputerMoveIsRandom()
    {
        var game = new Game();
        var result = game.GetPcMove();
        Assert.That(result, Is.AnyOf(Move.Rock, Move.Paper, Move.Scissors));
    }
}