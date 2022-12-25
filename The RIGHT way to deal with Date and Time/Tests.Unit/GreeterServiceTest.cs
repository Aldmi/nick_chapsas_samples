using System.Diagnostics;
using FluentAssertions;
using Moq;
using TimeInTest;

namespace Tests.Unit;

public class GreeterServiceTest
{
    private readonly GreeterService _sut;
    private readonly Mock<IDateTimeProvider> _mockDateTimeProvider = new();

    public GreeterServiceTest()
    {
        _sut = new GreeterService(_mockDateTimeProvider.Object);
    }

    [Fact]
    public void GenerateGreetText_ShouldReturnGoodMoning_WhenItsMoning()
    {
        _mockDateTimeProvider.Setup(provider => provider.Now)
            .Returns(new DateTimeOffset(2022, 1, 1, 9, 8, 0, 0, TimeSpan.Zero));
        
        var message = _sut.GenerateGreetText();

        message.Should().Be("Good Moning");
    }
    
    
    [Fact]
    public void GenerateGreetText_ShouldReturnGoodAfternoon_WhenItsAgternoon()
    {
        _mockDateTimeProvider.Setup(provider => provider.Now)
            .Returns(new DateTimeOffset(2022, 1, 1, 15, 8, 0, 0, TimeSpan.Zero));
    

        var message = _sut.GenerateGreetText();

        message.Should().Be("Good afternoon");
    }
    
    
    [Fact]
    public void GenerateGreetText_ShouldReturnGoodEvening_WhenItsEvening()
    {
        _mockDateTimeProvider.Setup(provider => provider.Now)
            .Returns(new DateTimeOffset(2022, 1, 1, 20, 8, 0, 0, TimeSpan.Zero));
    

        var message = _sut.GenerateGreetText();

        message.Should().Be("good evening");
    }
}