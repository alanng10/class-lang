namespace Class.Node;





public class RangeState : InfraState
{
    public virtual Create Create { get; set; }



    public new virtual Range Result { get; set; }



    public new virtual RangeStateArg Arg { get; set; }
}