namespace Avalon.Infra;





public class Data : Any
{
    public virtual long Count
    {
        get
        {
            return this.Value.LongLength;
        }
        set
        {
        }
    }





    public virtual byte[] Value { get; set; }
}