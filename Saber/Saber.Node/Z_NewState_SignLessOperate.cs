namespace Class.Node;

public class SignLessOperateNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new SignLessOperate();
        return true;
    }
}