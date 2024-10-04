namespace Class.Console;

public class Result : Any
{
    public virtual TokenResult Token { get; set; }
    public virtual NodeResult Node { get; set; }
    public virtual ModuleResult Module { get; set; }
}