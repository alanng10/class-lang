namespace Z.Tool.ReferBinaryGen;

public class Class : Any
{
    public virtual SystemType Type { get; set; }

    public virtual Array Property { get; set; }

    public virtual Array Method { get; set; }
}