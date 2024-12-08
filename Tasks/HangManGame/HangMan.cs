namespace Tasks.HangManGame;

public class HangMan
{
    private string wordToGuess;
    private string wordToShow;
    private List<char> guessedLetters;
    private int maxTries;
    private int triesLeft;

    public string WordToShow
    {
        get
        {
            var result = "";
            foreach (var c in wordToGuess)
            {
                result += guessedLetters.Contains(c) ? c.ToString() : "_";
            }
            return result;
        }
    }
    public int TriesLeft => triesLeft;
    public bool GameOver => triesLeft == 0 || wordToGuess == wordToShow;
    public bool Victory => wordToGuess == WordToShow;

    public HangMan(string wordToGuess, int maxTries = 5)
    {
        this.wordToGuess = wordToGuess.ToLower();
        this.maxTries = maxTries;
        guessedLetters = new List<char>();
        triesLeft = maxTries;
    }

    public bool Guess(char letter)
    {
        letter = char.ToLower(letter);
        
        if (guessedLetters.Contains(letter))
        {
            return false;
        }
        
        guessedLetters.Add(letter);

        if (wordToGuess.Contains(letter))
        {
            return (true);
        }
        else
        {
            triesLeft--;
            return false;
        }
    }
}