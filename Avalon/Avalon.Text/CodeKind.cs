namespace Avalon.Text;

public class CodeKind : Any
{
    public virtual long Index { get; set; }
    internal virtual SystemTextCode Intern { get; set; }
}