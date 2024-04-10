namespace Class.Check;




public class Check : Any
{
    public virtual InfraClass Class { get; set; }



    public virtual Field Field { get; set; }



    public virtual Maide Maide { get; set; }



    public virtual Var Var { get; set; }



    public virtual InfraClass OperateClass { get; set; }



    public virtual InfraClass NewClass { get; set; }



    public virtual InfraClass TargetClass { get; set; }



    public virtual InfraClass CastClass { get; set; }



    public virtual InfraClass ShareClass { get; set; }



    public virtual Field GetField { get; set; }



    public virtual Field SetField { get; set; }



    public virtual Maide CallMaide { get; set; }
}