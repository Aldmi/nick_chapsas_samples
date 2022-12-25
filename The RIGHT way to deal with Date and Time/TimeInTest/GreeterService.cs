using Tests.Unit;

namespace TimeInTest;

public class GreeterService
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public GreeterService(IDateTimeProvider dateTimeProvider )
    {
        _dateTimeProvider = dateTimeProvider;
    }
    
    
    public string GenerateGreetText()
    {
        var dateTimeNow = _dateTimeProvider.Now;
        return dateTimeNow.Hour switch
        {
            >= 5 and < 12 => "Good Moning",
            >= 12 and < 18 => "Good afternoon",
            _ => "good evening"
        };
    }
}