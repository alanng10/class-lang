namespace Avalon.Intern;

public class MathCompose : object
{
    public virtual bool Init()
    {
        return true;
    }

    public virtual ulong Significand { get; set; }

    public virtual ulong Exponent { get; set; }
}