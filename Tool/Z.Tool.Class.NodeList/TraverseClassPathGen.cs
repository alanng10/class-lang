namespace Z.Tool.Class.NodeList;

public class TraverseClassPathGen : TraverseGen
{
    public override bool Init()
    {
        base.Init();
        this.PathSource = "ToolData/TraverseClassPathSource.txt";
        return true;
    }

    protected override string DeriveState(Class varClass, string varName)
    {
        return "";
    }

    protected override string FieldState(Class varClass, string varName)
    {
        if (varClass.AnyInt == varClass.Field.Count)
        {
            return "";
        }

        return base.FieldState(varClass, varName);
    }

    protected override string Virtual()
    {
        return "override";
    }
}