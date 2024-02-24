namespace Class.Node;

public class GetOperate : Operate
{
    public virtual Operate This { get; set; }
    public virtual FieldName Field { get; set; }
}