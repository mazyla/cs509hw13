using Xunit;
using Moq;

public class UnitTests
{
    [Fact]
    public void Test_f1_ShouldIncrementValue()
    {
        var result = A.f1(1);
        Assert.Equal(2, result);
    }

    [Fact]
    public void Test_f5_ShouldDivideXbyY()
    {
        var result = A.f5(10, 2);
        Assert.Equal(5.0, result);
    }

    [Fact]
    public void Test_f5_ShouldThrowDivideByZeroException()
    {
        Assert.Throws<DivideByZeroException>(() => A.f5(10, 0));
    }

    [Fact]
    public void Test_f6_ShouldAddFive()
    {
        var result = A.f6(3);
        Assert.Equal(8, result);
    }

    [Fact]
    public void Test_f6_ShouldThrowExceptionWhenNegative()
    {
        var exception = Assert.Throws<Exception>(() => A.f6(-1));
        Assert.Equal("x can't be negative", exception.Message);
    }

    [Fact]
    public void Test_f7_ShouldAppendMoreStuff()
    {
        var result = A.f7("hello");
        Assert.Equal("hello more stuff", result);
    }

    [Fact]
    public void Test_f8_ShouldAddEight()
    {
        var a = new A();
        var result = a.f8(1);
        Assert.Equal(9, result);
    }

    // Example of mocking the IA interface to test interaction with the f8 method via class B
    [Fact]
    public void Test_g1_UsingMock()
    {
        var mock = new Mock<IA>();
        mock.Setup(x => x.f8(It.IsAny<int>())).Returns(9); // Mocking return as 9 for any input

        var result = B.g1(1, mock.Object);
        Assert.Equal(9, result);
    }
}
