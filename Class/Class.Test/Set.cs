namespace Class.Test;

class Set
{
    public virtual string Name { get; set; }

    public virtual TaskKind Kind { get; set; }

    public virtual bool AddKindAfterTaskArg { get; set; }

    public virtual bool AddPathAfterTaskArg { get; set; }

    public virtual bool SourceFold { get; set; }
}