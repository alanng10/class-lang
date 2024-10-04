namespace Saber.Binary;

public class Part : Any
{
    public virtual Range FieldRange { get; set; }

    public virtual Range MaideRange { get; set; }

    public virtual Array Field { get; set; }

    public virtual Array Maide { get; set; }
}