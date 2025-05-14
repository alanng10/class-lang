namespace Saber.Module;

public class InitTravel : Travel
{
    protected override bool ExecuteNode(NodeNode node)
    {
        Info info;
        info = new Info();
        info.Init();

        node.NodeAny = info;
        return true;
    }
}