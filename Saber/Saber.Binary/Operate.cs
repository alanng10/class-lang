namespace Saber.Binary;

public class Operate : Any
{
    public virtual long Kind { get; set; }
    public virtual Value ArgA { get; set; }
    public virtual Value ArgB { get; set; }
}