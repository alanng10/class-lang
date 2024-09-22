namespace Avalon.Intern;

public class DrawPolateStopPoint : object
{
    public virtual bool Init()
    {
        return true;
    }
    
    public virtual ulong Pos { get; set; }

    public virtual ulong Color { get; set; }
}