using JetBrains.Annotations;
using NUnit.Framework;

namespace NamingStylesLib;
public class MyClass
{
    private int _field;
    private static int _staticField;
    [UsedImplicitly]
    public void StandardMethod()
    {
        _field += 1;
    }

    [UsedImplicitly]
    public static void StaticMethod()
    {
        _staticField += 1;
    }

    [UsedImplicitly]
    public async Task AsyncMethod()
    {
        _field += 1;
        await Task.CompletedTask;
    }
}


[TestFixture]
public class SomeNUnitFixture
{
    [Test]
    public void StandardTest()
    {
        Assert.Pass();
    }

    [Test]
    public async Task AsyncTest()
    {
        Assert.Pass();
        await Task.CompletedTask;
    }
}
