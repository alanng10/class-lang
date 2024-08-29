namespace Class.Port;

public class ReadArg : Any
{
    public virtual long StringIndex { get; set; }
    public virtual Data StringTextData { get; set; }
    public virtual Array StringArray { get; set; }
    public virtual long ArrayIndex { get; set; }
    public virtual Data ArrayCountData { get; set; }
    public virtual Array ArrayArray { get; set; }
    public virtual long PortIndex { get; set; }
    public virtual Array PortArray { get; set; }
    public virtual long ModuleRefIndex { get; set; }
    public virtual Array ModuleRefArray { get; set; }
    public virtual long ImportIndex { get; set; }
    public virtual Array ImportArray { get; set; }
    public virtual long ImportClassIndex { get; set; }
    public virtual Array ImportClassArray { get; set; }
    public virtual long ExportIndex { get; set; }
    public virtual Array ExportArray { get; set; }
    public virtual long StorageIndex { get; set; }
    public virtual Array StorageArray { get; set; }
}