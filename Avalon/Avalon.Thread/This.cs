namespace Avalon.Thread;

public class This : Any
{
    public virtual bool Wait(long time)
    {
        ulong u;
        u = (ulong)time;
        Extern.Thread_Sleep(u);
        return true;
    }

    public virtual Thread Thread
    {
        get
        {
            return (Thread)InternIntern.ThisThread;
        }
        set
        {
        }
    }
}