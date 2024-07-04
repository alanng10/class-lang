namespace Z.Tool.Class.NodeList;

public class TraverseClassPathGen : TraverseGen
{
    public override bool Init()
    {
        base.Init();
        
        this.PathOutput = "../../Class/Class.Console/ClassPathTraverse.cs";

        this.PathSource = this.GetPath("ClassPathSource");
        this.PathArray = this.GetPath("ClassPathArray");
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

    protected override string DeclareClassName(string className)
    {
        bool b;
        b = false;
        if (!b)
        {
            if (className == "Class")
            {
                b = true;
            }
        }
        if (!b)
        {
            if (className == "Field")
            {
                b = true;
            }
        }
        if (!b)
        {
            if (className == "Maide")
            {
                b = true;
            }
        }
        if (!b)
        {
            if (className == "Var")
            {
                b = true;
            }
        }

        if (b)
        {
            return "Node" + className;
        }

        return className;
    }

    protected override string Virtual()
    {
        return "override";
    }
}