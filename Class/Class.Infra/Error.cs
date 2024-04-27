namespace Class.Infra;






public class Error : Any
{
    public virtual Stage Stage { get; set; }




    public virtual ErrorKind Kind { get; set; }




    public virtual Range Range { get; set; }




    public virtual Source Source { get; set; }
}