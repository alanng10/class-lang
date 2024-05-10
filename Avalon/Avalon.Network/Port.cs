namespace Avalon.Network;

public class Port : Any
{
    public virtual PortKind Kind { get; set; }
    public virtual long ValueA { get; set; }
    public virtual long ValueB { get; set; }
    public virtual long ValueC { get; set; }
    public virtual int Server { get; set; }
}