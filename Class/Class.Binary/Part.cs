namespace Class.Binary;

public class Part : Any
{
    public virtual int FieldStart { get; set; }

    public virtual int MaideStart { get; set; }

    public virtual Array Field { get; set; }

    public virtual Array Maide { get; set; }
}