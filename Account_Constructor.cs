using Xunit;

namespace MultipleAssertions;
public class Account_Constructor
{
    private readonly string _testName = "Acme";
    private readonly string _testNumber = "12345";
    private readonly decimal _testBalance = 123.50m;

    [Fact]
    public void SetsAssociatedProperties_NoGrouping()
    {
        var account = new Account(_testName, _testNumber, _testBalance);

        // Individual assertions will only catch the first problem
        Assert.Equal(_testName, account.Name);
        Assert.Equal(_testNumber, account.Number);
        Assert.Equal(_testBalance, account.Balance);
    }

    [Fact]
    public void SetsAssociatedProperties_ManualGrouping()
    {
        var account = new Account(_testName, _testNumber, _testBalance);

        var exceptions = new List<Exception>();
        try
        {
            Assert.Equal(_testName, account.Name);
        }
        catch (Exception ex)
        {
            exceptions.Add(ex);
        }
        try
        {
            Assert.Equal(_testNumber, account.Number);
        }
        catch (Exception ex)
        {
            exceptions.Add(ex);
        }
        try
        {
            Assert.Equal(_testBalance, account.Balance);
        }
        catch (Exception ex)
        {
            exceptions.Add(ex);
        }

        if(exceptions.Any())
        {
            throw new AggregateException(exceptions.ToArray()); 
        }
    }
}