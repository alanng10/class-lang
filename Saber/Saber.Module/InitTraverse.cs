namespace Saber.Module;

public class InitTraverse : Traverse
{
    protected override bool ExecuteNode(NodeNode node)
    {
        Info info;
        info = this.Create.CreateInfo();

        node.NodeAny = info;
        return true;
    }
}