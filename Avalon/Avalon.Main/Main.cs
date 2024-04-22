namespace Avalon.Main;

public class Main : Any
{
    public override bool Init()
    {
        base.Init();
        Environment.SetEnvironmentVariable("QT_PLUGIN_PATH", "Avalon.Intern.data/Lib");

        ulong ua;
        ua = 1;
        Extern.Main_IsCSharpSet(ua);
        Extern.Main_Init();

        ThreadThread a;
        a = new ThreadThread();
        a.InitMainThread();
        return true;
    }

    public virtual bool Final()
    {
        Extern.Main_Final();
        return true;
    }

    public virtual int Execute()
    {
        ulong u;
        u = Extern.Main_ExecuteEventLoop();
        int a;
        a = (int)u;
        return a;
    }

    public virtual bool Exit(int code)
    {
        ulong u;
        u = (ulong)code;
        Extern.Main_ExitEventLoop(u);
        return true;
    }
}