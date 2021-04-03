using Mogze.Core.MiniBus;

public class TestMessage : IMessage
{
    public readonly int TestInt;

    public TestMessage(int testInt)
    {
        TestInt = testInt;
    }
}