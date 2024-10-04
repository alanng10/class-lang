namespace Saber.Binary;

public class ReadArg : Any
{
    public virtual long Index { get; set; }
    public virtual long BinaryIndex { get; set; }
    public virtual Array BinaryArray { get; set; }
    public virtual long ClassIndex { get; set; }
    public virtual Array ClassArray { get; set; }
    public virtual long ImportIndex { get; set; }
    public virtual Array ImportArray { get; set; }
    public virtual long PartIndex { get; set; }
    public virtual Array PartArray { get; set; }
    public virtual long FieldIndex { get; set; }
    public virtual Array FieldArray { get; set; }
    public virtual long MaideIndex { get; set; }
    public virtual Array MaideArray { get; set; }
    public virtual long VarIndex { get; set; }
    public virtual Array VarArray { get; set; }
    public virtual long ClassIndexIndex { get; set; }
    public virtual Array ClassIndexArray { get; set; }
    public virtual long ModuleRefIndex { get; set; }
    public virtual Array ModuleRefArray { get; set; }
    public virtual long RangeIndex { get; set; }
    public virtual Array RangeArray { get; set; }
    public virtual long StringIndex { get; set; }
    public virtual Data StringCountData { get; set; }
    public virtual long StringTextIndex { get; set; }
    public virtual Data StringTextData { get; set; }
    public virtual Array StringArray { get; set; }
    public virtual long ArrayIndex { get; set; }
    public virtual Data ArrayCountData { get; set; }
    public virtual Array ArrayArray { get; set; }
}