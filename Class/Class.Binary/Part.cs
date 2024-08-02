namespace Class.Binary;

public class Part : Any
{
    public virtual int FieldIndex { get; set; }
    public virtual int FieldCount { get; set; }

    public virtual int MaideIndex { get; set; }
    public virtual int MaideCount { get; set; }

    public virtual Array Field { get; set; }

    public virtual Array Maide { get; set; }
}