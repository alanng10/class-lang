namespace Saber.Binary;

public class Field : Any
{
    public virtual long Class { get; set; }
    public virtual long Count { get; set; }
    public virtual String Name { get; set; }
    public virtual State Get { get; set; }
    public virtual State Set { get; set; }
}