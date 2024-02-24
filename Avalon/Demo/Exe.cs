namespace Demo;

class Exe : ExeExe
{
    public override int Execute()
    {
        Demo demo;
        demo = new Demo();
        demo.Init();
        demo.Execute();
        return 0;
    }

    [STAThread]
    static int Main(string[] arg)
    {
        Exe exe;
        exe = new Exe();
        exe.Init();
        int o;
        o = exe.Execute();
        return o;
    }
}