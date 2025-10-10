namespace Saber.Module;

public class Info : Any
{
    public virtual Class Class { get; set; }
    public virtual Field Field { get; set; }
    public virtual Maide Maide { get; set; }
    public virtual Var Var { get; set; }
    public virtual Class MarkClass { get; set; }
    public virtual Class OperateClass { get; set; }
    public virtual Field GetField { get; set; }
    public virtual Field SetField { get; set; }
    public virtual Maide CallMaide { get; set; }
}