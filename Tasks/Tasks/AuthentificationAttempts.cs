namespace Tasks;

public class AuthentificationAttempts
{
    private readonly int _maxTries;
    private readonly string _correctLogin;
    private readonly string _correctPassword;
    private int _triesCount;
    
    public bool IsLogged { get; private set; }
    public int TriesRemaining => _maxTries - _triesCount;

    public AuthentificationAttempts(string correctLogin, string correctPassword, int maxTries = 3)
    {
        _maxTries = maxTries;
        _correctPassword = correctPassword;
        _correctLogin = correctLogin;
        _triesCount = 0;
    }

    public bool Authenticate(string login, string password)
    {
        if (_triesCount >= _maxTries)
        {
            return false;
        }

        if (login == _correctLogin && password == _correctPassword)
        {
            _triesCount = 0;
            IsLogged = true;
            return true;
        }

        _triesCount++;
        return false;
    }
    
}