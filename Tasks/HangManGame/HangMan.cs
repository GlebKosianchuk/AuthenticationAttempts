namespace Tasks.HangManGame;

public class HangMan
{
    private string wordToGuess;
    private string wordToShow;
    private List<char> guessedLetters;
    private int maxTries;
    private int triesLeft;

    public string WordToShow => wordToShow;
    public int TriesLeft => triesLeft;
    public bool GameOver => triesLeft == 0 || wordToGuess == wordToShow;
    public bool Victory => wordToGuess == wordToShow;

    public HangMan(string wordToGuess, int maxTries = 5)
    {
        this.wordToGuess = wordToGuess.ToLower();
        this.maxTries = maxTries;
        wordToShow = new string('_', wordToGuess.Length);
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
            NewWordToShow(letter);
            return (true);
        }
        else
        {
            triesLeft--;
            return false;
        }
    }

    public void NewWordToShow(char letter)
    {
        var newWord = wordToShow.ToCharArray();

        for (var i = 0; i < wordToGuess.Length; i++)
        {
            if (wordToGuess[i] == letter)
            {
                newWord[i] = letter;
            }
        }
        wordToShow = new string(newWord);
    }
}