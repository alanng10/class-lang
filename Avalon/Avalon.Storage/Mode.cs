namespace Avalon.Storage;

public class Mode : Any
{
    public virtual bool Read { get; set; }    
    public virtual bool Write { get; set; }
    public virtual bool New { get; set; }
    public virtual bool Exist { get; set; }
}