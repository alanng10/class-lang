namespace Z.Tool.ReferBinaryGen;

class Info : Any
{
    public virtual PropertyInfo Property { get; set; }

    public virtual MethodInfo Method { get; set; }

    public virtual ParameterInfo Parameter { get; set; }
}