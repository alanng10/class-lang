namespace Class.Test.Exe;



class Exe : ExeExe
{
    public override int Execute()
    {
        TestTest a;

        a = new TestTest();

        a.Init();



        int o;

        o = a.Execute();


        return o;
    }



    static int Main()
    {
        Exe exe;

        exe = new Exe();

        exe.Init();



        int o;

        o = exe.Execute();


        return o;
    }
}