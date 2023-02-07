namespace NamingStylesLib;
public class MyClass
{
    private int _field;
    public void StandardMethod()
    {
        _field += 1;
    }

    public async Task AsyncMethod()
    {
        _field += 1;
        await Task.CompletedTask;
    }
}
