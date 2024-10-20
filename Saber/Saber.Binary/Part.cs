namespace Saber.Binary;

public class Part : Any
{
    public virtual long FieldStart { get; set; }

    public virtual long MaideStart { get; set; }

    public virtual Array Field { get; set; }

    public virtual Array Maide { get; set; }
}