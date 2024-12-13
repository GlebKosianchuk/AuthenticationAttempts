namespace Tasks.RockPaperScissorsGame
{
    public enum Move
    {
        Rock,
        Paper,
        Scissors
    }

    public enum GameResult
    {
        Win,
        Loss,
        Draw
    }

    public interface IPlayer
    {
        Move MakeMove();
    }

    public class RandomComputerPlayer : IPlayer
    {
        private readonly Random _random;

        public RandomComputerPlayer(Random random)
        {
            _random = random;
        }

        public Move MakeMove()
        {
            var values = Enum.GetValues(typeof(Move));
            return (Move)values.GetValue(_random.Next(values.Length));
        }
    }

    public class Game
    {
        private readonly IPlayer _player1;
        private readonly IPlayer _player2;
        private readonly int _bestOfN;

        public Game(IPlayer player1, IPlayer player2, int bestOfN)
        {
            _player1 = player1;
            _player2 = player2;
            _bestOfN = bestOfN;
        }

        public GameResult Play()
        {
            var player1Wins = 0;
            var player2Wins = 0;

            while (player1Wins < (_bestOfN / 2) + 1 && player2Wins < (_bestOfN / 2) + 1)
            {
                Move player1Move = _player1.MakeMove();
                Move player2Move = _player2.MakeMove();

                GameResult result = DetermineWinner(player1Move, player2Move);

                if (result == GameResult.Win)
                {
                    player1Wins++;
                }
                else if (result == GameResult.Loss)
                {
                    player2Wins++;
                }
            }

            if (player1Wins > player2Wins)
            {
                return GameResult.Win;
            }
            else if (player2Wins > player1Wins)
            {
                return GameResult.Loss;
            }
            else
            {
                return GameResult.Draw;
            }
        }

        public GameResult DetermineWinner(Move player1Move, Move player2Move)
        {
            if (player1Move == player2Move)
            {
                return GameResult.Draw;
            }

            return player1Move switch
            {
                Move.Rock => player2Move == Move.Scissors ? GameResult.Win : GameResult.Loss,
                Move.Paper => player2Move == Move.Rock ? GameResult.Win : GameResult.Loss,
                Move.Scissors => player2Move == Move.Paper ? GameResult.Win : GameResult.Loss,
                _ => throw new ArgumentOutOfRangeException(nameof(player1Move),
                    "The move should be Rock, Paper, or Scissors.")
            };
        }
    }
}