namespace Z.Tool.ReferBinaryGen;

class Field : Any
{
    public virtual string Name { get; set; }

    public virtual Class Class { get; set; }

    public virtual int Count { get; set; }

    public virtual PropertyInfo Property { get; set; }
}