namespace Class.Node;

public class IntHexSignValueNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new IntHexSignValue();
        return true;
    }
}