namespace Saber.Test;

class Set : Any
{
    public virtual String Name { get; set; }

    public virtual TaskKind TaskKind { get; set; }

    public virtual bool AddKindAfterTaskArg { get; set; }

    public virtual bool AddPathAfterTaskArg { get; set; }

    public virtual bool SourceFold { get; set; }
}