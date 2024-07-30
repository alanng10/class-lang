namespace Class.Node;

public class CreateArg : Any
{
    public virtual int NodeIndex { get; set; }
    public virtual Data NodeData { get; set; }
    public virtual Array NodeArray { get; set; }
    public virtual int ListIndex { get; set; }
    public virtual Data ListData { get; set; }
    public virtual Array ListArray { get; set; }
    public virtual int ErrorIndex { get; set; }
    public virtual Array ErrorArray { get; set; }
    public virtual int NameValueIndex { get; set; }
    public virtual int NameValueTotalIndex { get; set; }
    public virtual Data NameValueText { get; set; }
    public virtual Data NameValueData { get; set; }
    public virtual Array NameValueArray { get; set; }
    public virtual int StringValueIndex { get; set; }
    public virtual int StringValueTotalIndex { get; set; }
    public virtual Data StringValueText { get; set; }
    public virtual Data StringValueData { get; set; }
    public virtual Array StringValueArray { get; set; }
}