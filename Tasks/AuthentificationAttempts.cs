namespace Tasks;

public struct AuthenticationResult
{
    public bool IsAuthenticated { get; }
    public int TriesRemaining { get; }

    public AuthenticationResult(bool isAuthenticated, int triesRemaining)
    {
        IsAuthenticated = isAuthenticated;
        TriesRemaining = triesRemaining;
    }
}
public class AuthentificationAttempts
{
    private readonly int _maxTries;
    private readonly string _correctLogin;
    private readonly string _correctPassword;
    private int _triesCount;

    public AuthentificationAttempts(string correctLogin, string correctPassword, int maxTries = 3)
    {
        _maxTries = maxTries;
        _correctPassword = correctPassword;
        _correctLogin = correctLogin;
        _triesCount = 0;
    }

    public AuthenticationResult Authenticate(string login, string password)
    {
        if (_triesCount >= _maxTries)
        {
            return new AuthenticationResult(false,0);
        }

        if (login == _correctLogin && password == _correctPassword)
        {
            _triesCount = 0;
            return new AuthenticationResult(true,_maxTries);
        }

        _triesCount++;
        return new AuthenticationResult(false,_maxTries - _triesCount);
    }
    
}