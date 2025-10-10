namespace Saber.Binary;

public class Operate : Any
{
    public virtual long Kind { get; set; }
    public virtual OperateArg ArgA { get; set; }
    public virtual OperateArg ArgB { get; set; }
    public virtual OperateArg ArgC { get; set; }
}