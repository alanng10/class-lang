namespace Avalon.Intern;

public class MathComp : object
{
    public virtual bool Init()
    {
        return true;
    }

    public virtual ulong Cand { get; set; }

    public virtual ulong Exponent { get; set; }
}