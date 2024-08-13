namespace Avalon.Infra;

public class String : Any
{
    public virtual object Data
    {
        get
        {
            return this.DataData;
        }
        set
        {
        } 
    }

    internal virtual Data DataData { get; set; }

    internal virtual long CountData { get; set; }
}