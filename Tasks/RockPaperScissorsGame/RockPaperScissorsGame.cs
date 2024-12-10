namespace Tasks.RockPaperScissorsGame
{
    public enum Move
    {
        Rock,
        Paper,
        Scissors
    }

    public class Game
    {
        public string Play(Move playerMove, Move pcMove)
        {
            if (playerMove == pcMove)
            {
                return "Draw!";
            }

            return playerMove switch
            {
                Move.Rock => (pcMove == Move.Scissors) ? "You win!" : "You loss!",
                Move.Paper => (pcMove == Move.Rock) ? "You win!" : "You loss!",
                Move.Scissors => (pcMove == Move.Paper) ? "You win" : "You loss!",
                _ => throw new ArgumentOutOfRangeException(nameof(playerMove), "The move should be Rock, Paper, or Scissors.")
            };
        }

        public Move GetPcMove()
        {
            var random = new Random();
            var values = Enum.GetValues(typeof(Move));
            return (Move)values.GetValue(random.Next(values.Length));
        }
    }
}