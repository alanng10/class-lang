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
    public virtual Data NameValueCountData { get; set; }
    public virtual int NameValueTextIndex { get; set; }
    public virtual Data NameValueTextData { get; set; }
    public virtual Array NameValueArray { get; set; }
    public virtual int StringValueIndex { get; set; }
    public virtual Data StringValueCountData { get; set; }
    public virtual int StringValueTextIndex { get; set; }
    public virtual Data StringValueTextData { get; set; }
    public virtual Array StringValueArray { get; set; }
}