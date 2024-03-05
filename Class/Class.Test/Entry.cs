namespace Class.Test;



public class Entry : EntryEntry
{
    public override int Execute()
    {
        Test a;

        a = new Test();

        a.Init();



        int o;

        o = a.Execute();


        return o;
    }
}