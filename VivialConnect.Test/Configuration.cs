using NUnit.Framework;
using VivialConnect;

[SetUpFixture]
public class Configuration
{
    [OneTimeSetUp]
    public static void SetUp()
    {
        VcClient.Init(10000, "123abc123abc123abc", "000111000111000");
    }

    [OneTimeTearDown]
    public static void TearDown()
    { }
}