namespace Saber.Module;

public class InitTravel : Travel
{
    protected override bool ExecuteNode(NodeNode node)
    {
        Info info;
        info = this.Create.CreateInfo();

        node.NodeAny = info;
        return true;
    }
}