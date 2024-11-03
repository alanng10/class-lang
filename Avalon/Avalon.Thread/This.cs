namespace Avalon.Thread;

public class This : Any
{
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