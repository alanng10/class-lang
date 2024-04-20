namespace Class.Test;



public class Entry : EntryEntry
{
    public override int Execute()
    {
        Main main;
        main = new Main();
        main.Init();


        Test a;

        a = new Test();

        a.Init();



        int o;

        o = a.Execute();

        main.Final();

        return o;
    }
}