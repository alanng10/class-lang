namespace Class.Console;

public class Task : Any
{
    public virtual TaskKind Kind { get; set; }
    public virtual string Node { get; set; }
    public virtual string Check { get; set; }
    public virtual string Source { get; set; }
    public virtual bool Print { get; set; }
    public virtual Out Out { get; set; }
    public virtual Out Err { get; set; }
}