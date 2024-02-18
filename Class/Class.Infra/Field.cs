namespace Class.Infra;



public class Field : Any
{
    public virtual string Name { get; set; }



    public virtual Class Class { get; set; }



    public virtual Access Access { get; set; }



    public virtual Table Get { get; set; }



    public virtual Table Set { get; set; }



    public virtual Class Parent { get; set; }



    public virtual object Node { get; set; }



    public virtual int Ident { get; set; }




    public virtual int Index { get; set; }
}