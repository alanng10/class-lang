namespace Mirai.Draw;

public class BrushKind : Any
{
    public virtual long Index { get; set; }
    internal virtual ulong Intern { get; set; }
}