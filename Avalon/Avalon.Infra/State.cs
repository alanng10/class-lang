namespace Avalon.Infra;

public class State : Any
{
    public virtual object Arg { get { return __D_Arg; } set { __D_Arg = value; } }
    protected object __D_Arg;
    public virtual object Result { get { return __D_Result; } set { __D_Result = value; } }
    protected object __D_Result;

    public virtual bool Execute()
    {
        return true;
    }
}