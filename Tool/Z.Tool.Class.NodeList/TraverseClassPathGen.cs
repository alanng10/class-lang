namespace Z.Tool.Class.NodeList;

public class TraverseClassPathGen : TraverseGen
{
    public override bool Init()
    {
        base.Init();
        this.PathSource = "ToolData/TraverseClassPathSource.txt";
        return true;
    }
}