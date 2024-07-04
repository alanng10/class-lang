namespace Z.Tool.Class.NodeList;

public class TraverseClassPathGen : TraverseGen
{
    public override bool Init()
    {
        base.Init();
        
        this.PathOutput = "../../Class/Class.Console/ClassPathTraverse.cs";

        this.PathSource = this.GetPath("ClassPathSource");
        this.PathArray = this.GetPath("ClassPathArray");
        this.PathExecuteNode = this.GetPath("ClassPathExecuteNode");
        this.PathField = this.GetPath("ClassPathField");
        return true;
    }

    protected override string Node(Class varClass)
    {
        if (this.IsDeriveState(varClass))
        {
            return "";
        }

        return base.Node(varClass);
    }

    protected override string ArrayState(Class varClass, Field field, string varName)
    {
        string itemClassName;
        itemClassName = field.ItemClass;

        string itemDeclareClassName;
        itemDeclareClassName = this.DeclareClassName(itemClassName);

        string k;
        k = this.TextArray;
        k = k.Replace("#VarName#", varName);
        k = k.Replace("#ItemClassName#", itemClassName);
        k = k.Replace("#ItemDeclareClassName#", itemDeclareClassName);

        string a;
        a = k;
        return a;
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
        if (!b)
        {
            if (className == "Count")
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