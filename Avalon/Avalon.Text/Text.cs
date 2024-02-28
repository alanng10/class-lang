namespace Avalon.Text;

public class Text : Array
{
    public virtual Line GetLine(int index)
    {
        return (Line)this.Get(index);
    }
}