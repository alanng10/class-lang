namespace Saber.Test;

public class Entry : EntryEntry
{
    protected override long ExecuteMain()
    {
        Test a;
        a = new Test();
        a.Init();

        long o;
        o = a.Execute();
        return o;
    }
}