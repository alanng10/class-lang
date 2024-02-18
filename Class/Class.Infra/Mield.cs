namespace Class.Infra;



public class Mield : Any
{
    public virtual string Name { get; set; }



    public virtual Class Class { get; set; }



    public virtual Access Access { get; set; }



    public virtual Table Param { get; set; }



    public virtual Table Call { get; set; }



    public virtual Class Parent { get; set; }



    public virtual object Node { get; set; }



    public virtual int Ident { get; set; }




    public virtual int Index { get; set; }
}