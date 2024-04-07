namespace Z.Tool.ReferBinaryGen;

public class BuiltInType : Any
{
    public virtual SystemType Type { get; set; }

    public virtual string Name { get; set; }

    public virtual int SystemClass { get; set; }
}