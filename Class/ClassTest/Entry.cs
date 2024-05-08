namespace Class.Test;

public class Entry : EntryEntry
{
    protected override int ExecuteMain()
    {
        Test a;
        a = new Test();
        a.Init();

        int o;
        o = a.Execute();
        return o;
    }
}