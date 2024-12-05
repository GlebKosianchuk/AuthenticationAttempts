using NUnit.Framework;

namespace Tasks.Tests;

public class AuthentificationAttemptsTests
{
    [Test]
    public void TestAuthenticate_CorrectLoginAndPassword_ShouldReturnTrue()
    {
        var auth = new AuthentificationAttempts("King", "Lion");
        var result = auth.Authenticate("King", "Lion");
        Assert.That(result, Is.True);
        Assert.That(auth.TriesRemaining, Is.EqualTo(3));
    }
    
    [Test]
    public void TestAuthenticate_InCorrectLoginAndPassword_ShouldReturnFalse()
    {
        var auth = new AuthentificationAttempts("King", "Lion");
        var result = auth.Authenticate("Prince", "Lion");
        Assert.That(result, Is.False);
        Assert.That(auth.TriesRemaining, Is.EqualTo(2));
    }

    [Test]
    public void TheTriesAreOver_AfterMaxFailedAttempts()
    {
        var auth = new AuthentificationAttempts("Martin", "Luter");

        auth.Authenticate("Gloria", "Luter");
        auth.Authenticate("Martin", "Muller");
        var result = auth.Authenticate("Martin", "Nuter");
        
        Assert.That(result, Is.False);
        Assert.That(auth.TriesRemaining, Is.EqualTo(0));
    }
    
    [Test]
    public void ShouldResetTriesCount_AfterSuccessfulLogin()
    {
        var auth = new AuthentificationAttempts("Martin", "Luter");

        auth.Authenticate("Gloria", "Luter");
        auth.Authenticate("Martin", "Muller");
        var result = auth.Authenticate("Martin", "Luter");
        
        Assert.That(result, Is.True);
        Assert.That(auth.TriesRemaining, Is.EqualTo(3));
    }
    
    [Test]
    public void PropertyFalseAutentificationAttempts()
    {
        var auth = new AuthentificationAttempts("King", "Lion");
        Assert.That(auth.IsLogged,Is.False);
    }
    
    [Test]
    public void PropertyTrueAutentificationAttempts()
    {
        var auth = new AuthentificationAttempts("King", "Lion");
        auth.Authenticate("King", "Lion");
        Assert.That(auth.IsLogged,Is.True);
    }
}