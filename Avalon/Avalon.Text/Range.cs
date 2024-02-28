namespace Avalon.Text;

public class Range : Any
{
    public virtual int Row { get; set; }
    public virtual InfraRange Col { get; set; }
}