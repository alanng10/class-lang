namespace Avalon.Thread;





public class Current : Any
{
    public virtual bool Wait(long timeMilliSecond)
    {
        ulong u;

        u = (ulong)timeMilliSecond;



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