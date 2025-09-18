namespace Saber.Console;

public class BinaryStateArg : Any
{
    public virtual long Index { get; set; }
    public virtual Data Data { get; set; }
    public virtual long StateIndex { get; set; }
    public virtual long OperateIndex { get; set; }
    public virtual Data OperateCountData { get; set; }
}