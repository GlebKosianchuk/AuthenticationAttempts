using Moq;
using Tasks.RockPaperScissorsGame;

namespace Tests.RockPaperScissorsGameTests;

public class RockPaperScissorsGameTests
{
    [Test]
        public void DetermineWinner_RockVsScissors_Player1Wins()
        {
            var game = new Game(null, null, 1);
            var result = game.DetermineWinner(Move.Rock, Move.Scissors);
            Assert.That(GameResult.Win, Is.EqualTo(result));
        }

        [Test]
        public void DetermineWinner_PaperVsRock_Player1Wins()
        {
            var game = new Game(null, null, 1);
            var result = game.DetermineWinner(Move.Paper, Move.Rock);
            Assert.That(GameResult.Win, Is.EqualTo(result));
        }
        
        [Test]
        public void DetermineWinner_Draw()
        {
            var game = new Game(null, null, 1);
            var result = game.DetermineWinner(Move.Rock, Move.Rock);
            Assert.That(GameResult.Draw, Is.EqualTo(result));
        }

        [Test]
        public void DetermineWinner_Player2Wins()
        {
            var game = new Game(null, null, 1);
            var result = game.DetermineWinner(Move.Rock, Move.Paper);
            Assert.That(GameResult.Loss, Is.EqualTo(result));
        }
        [Test]
        public void Play_BestOf3_Player1Wins()
        {
            var player1Mock = new Mock<IPlayer>();
            player1Mock.SetupSequence(p => p.MakeMove())
                .Returns(Move.Rock)
                .Returns(Move.Paper)
                .Returns(Move.Scissors);

            var player2Mock = new Mock<IPlayer>();
            player2Mock.SetupSequence(p => p.MakeMove())
                .Returns(Move.Scissors)
                .Returns(Move.Rock)
                .Returns(Move.Paper);

            var game = new Game(player1Mock.Object, player2Mock.Object, 3);
            var result = game.Play();
            Assert.That(GameResult.Win, Is.EqualTo(result));
        }

}