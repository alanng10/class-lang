namespace Class.Console;

public class Result : Any
{
    public virtual TokenResult Token { get; set; }
    public virtual NodeResult Node { get; set; }
    public virtual ReferResult Refer { get; set; }
}