namespace Saber.Node;

public class AndOperate : Operate
{
    public virtual Operate Lite { get; set; }
    public virtual Operate Rite { get; set; }
}