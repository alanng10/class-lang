namespace Class.Port;

public class ReadArg : Any
{
    public virtual int StringIndex { get; set; }
    public virtual Data StringTextData { get; set; }
    public virtual Array StringArray { get; set; }
    public virtual int ArrayIndex { get; set; }
    public virtual Data ArrayCountData { get; set; }
    public virtual Array ArrayArray { get; set; }
    public virtual int PortIndex { get; set; }
    public virtual Array PortArray { get; set; }
    public virtual int ModuleRefIndex { get; set; }
    public virtual Array ModuleRefArray { get; set; }
    public virtual int ImportIndex { get; set; }
    public virtual Array ImportArray { get; set; }
    public virtual int ImportClassIndex { get; set; }
    public virtual Array ImportClassArray { get; set; }
    public virtual int ExportIndex { get; set; }
    public virtual Array ExportArray { get; set; }
    public virtual int StorageIndex { get; set; }
    public virtual Array StorageArray { get; set; }
}