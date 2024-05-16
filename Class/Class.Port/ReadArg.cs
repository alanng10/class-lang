namespace Class.Port;

public class ReadArg : Any
{
    public virtual int StringIndex { get; set; }
    public virtual int ModuleRefIndex { get; set; }
    public virtual int ArrayIndex { get; set; }
    public virtual int ImportIndex { get; set; }
    public virtual int ImportClassIndex { get; set; }
    public virtual int ExportIndex { get; set; }
    public virtual int StorageIndex { get; set; }
}