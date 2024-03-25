namespace Z.Tool.ReferBinaryGen;

class DotNetType : Any
{
    public virtual SystemType Type { get; set; }

    public virtual PropertyInfo[] Property { get; set; }

    public virtual MethodInfo[] Method { get; set; }
}