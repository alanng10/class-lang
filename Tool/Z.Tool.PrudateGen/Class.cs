namespace Z.Tool.PrudateGen;




public class Class : Any
{
    public virtual string Name { get; set; }



    public virtual bool HasNew { get; set; }



    public virtual Array Field { get; set; }


    public virtual Array Method { get; set; }



    public virtual Array StaticField { get; set; }



    public virtual Array StaticMethod { get; set; }



    public virtual Array Delegate { get; set; }
}