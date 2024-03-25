namespace Z.Tool.ReferBinaryGen;

class DotNetType : Any
{
    public virtual SystemType Type { get; set; }

    public virtual Array Property { get; set; }

    public virtual Array Method { get; set; }
}