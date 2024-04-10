namespace Class.Binary;

public class ReadArg : Any
{
    public virtual int Index { get; set; }
    public virtual int ReferIndex { get; set; }
    public virtual Array ReferArray { get; set; }
    public virtual int ClassIndex { get; set; }
    public virtual Array ClassArray { get; set; }
    public virtual int ImportIndex { get; set; }
    public virtual Array ImportArray { get; set; }
    public virtual int PartIndex { get; set; }
    public virtual Array PartArray { get; set; }
    public virtual int FieldIndex { get; set; }
    public virtual Array FieldArray { get; set; }
    public virtual int MaideIndex { get; set; }
    public virtual Array MaideArray { get; set; }
    public virtual int VarIndex { get; set; }
    public virtual Array VarArray { get; set; }
    public virtual int ClassIndexIndex { get; set; }
    public virtual Array ClassIndexArray { get; set; }
    public virtual int ModuleRefIndex { get; set; }
    public virtual Array ModuleRefArray { get; set; }
    public virtual int StringIndex { get; set; }
    public virtual Data StringCountData { get; set; }
    public virtual int StringTextIndex { get; set; }
    public virtual Data StringTextData { get; set; }
    public virtual Array StringArray { get; set; }
    public virtual int ArrayIndex { get; set; }
    public virtual Data ArrayCountData { get; set; }
    public virtual Array ArrayArray { get; set; }
}