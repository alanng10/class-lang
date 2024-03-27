namespace Z.Tool.ReferBinaryGen;

class Var : Any
{
    public virtual string Name { get; set; }

    public virtual Class Class { get; set; }

    public virtual ParameterInfo Parameter { get; set; }
}