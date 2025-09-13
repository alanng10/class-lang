namespace Avalon.Storage;

public class Entry : Any
{
    public virtual String Name { get; set; }
    public virtual bool Exist { get; set; }
    public virtual bool Fold { get; set; }
    public virtual long Size { get; set; }
    public virtual TimeTime CreateTime { get; set; }
    public virtual TimeTime ModifyTime { get; set; }
    public virtual long Owner { get; set; }
    public virtual long Group { get; set; }
}