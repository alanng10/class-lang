namespace Avalon.Intern;





public class DrawGradientStopPoint : object
{
    public virtual bool Init()
    {
        return true;
    }


    
    public virtual ulong Pos { get; set; }


    public virtual ulong Color { get; set; }
}