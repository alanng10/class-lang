namespace Z.Tool.ReferBinaryGen;

public class Class : Any
{
    public virtual int Index { get; set; }

    public virtual string Name { get; set; }

    public virtual Class Base { get; set; }

    public virtual Module Module { get; set; }

    public virtual SystemType Type { get; set; }

    public virtual Array Field { get; set; }

    public virtual Array Maide { get; set; }
}