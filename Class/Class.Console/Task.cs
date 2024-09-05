namespace Class.Console;

public class Task : Any
{
    public virtual TaskKind Kind { get; set; }
    public virtual String Node { get; set; }
    public virtual String Path { get; set; }
    public virtual String Source { get; set; }
    public virtual String Dest { get; set; }
    public virtual bool ArgBool { get; set; }
    public virtual bool Print { get; set; }
    public virtual Out Out { get; set; }
    public virtual Out Err { get; set; }
}