namespace Z.Tool.PrudateGen;




public class Class : Any
{
    public virtual string Name { get; set; }



    public virtual bool HasNew { get; set; }



    public virtual Array Field { get; set; }


    public virtual Array Maide { get; set; }



    public virtual Array StaticField { get; set; }



    public virtual Array StaticMaide { get; set; }



    public virtual Array Delegate { get; set; }
}