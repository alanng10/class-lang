namespace Class.Infra;




public class Class : Any
{
    public virtual string Name { get; set; }



    public virtual Class Base { get; set; }



    public virtual Table Field { get; set; }



    public virtual Table Mield { get; set; }



    public virtual Module Module { get; set; }




    public virtual SourceItem Source { get; set; }




    public virtual int Ident { get; set; }




    public virtual int Index { get; set; }
}