namespace Saber.Binary;

public class OperateArg : Any
{
    public virtual long Kind { get; set; }
    public virtual bool Bool { get; set; }
    public virtual long Int { get; set; }
    public virtual String String { get; set; }
}