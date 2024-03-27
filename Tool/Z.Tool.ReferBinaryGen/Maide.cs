namespace Z.Tool.ReferBinaryGen;

class Maide : Any
{
    public virtual string Name { get; set; }

    public virtual Class Class { get; set; }

    public virtual int Count { get; set; }

    public virtual Array Param { get; set; }

    public virtual MethodInfo Method { get; set; }
}