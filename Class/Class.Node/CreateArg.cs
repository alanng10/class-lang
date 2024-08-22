namespace Class.Node;

public class CreateArg : Any
{
    public virtual long NodeIndex { get; set; }
    public virtual Data NodeData { get; set; }
    public virtual Array NodeArray { get; set; }
    public virtual long ListIndex { get; set; }
    public virtual Data ListData { get; set; }
    public virtual Array ListArray { get; set; }
    public virtual long ErrorIndex { get; set; }
    public virtual Array ErrorArray { get; set; }
    public virtual long NameValueIndex { get; set; }
    public virtual Data NameValueCountData { get; set; }
    public virtual long NameValueTextIndex { get; set; }
    public virtual Data NameValueTextData { get; set; }
    public virtual Array NameValueArray { get; set; }
    public virtual long StringValueIndex { get; set; }
    public virtual Data StringValueCountData { get; set; }
    public virtual long StringValueTextIndex { get; set; }
    public virtual Data StringValueTextData { get; set; }
    public virtual Array StringValueArray { get; set; }
}