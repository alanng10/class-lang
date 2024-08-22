namespace Z.Tool.NodeListGen;

public class TraverseClassPathGen : TraverseGen
{
    public override bool Init()
    {
        base.Init();
        
        this.PathOutput = this.S("../../Class/Class.Console/ClassPathTraverse_Part.cs");

        this.PathSource = this.GetPath(this.S("ClassPathSource"));
        this.PathArray = this.GetPath(this.S("ClassPathArray"));
        this.PathExecuteNode = this.GetPath(this.S("ClassPathExecuteNode"));
        this.PathField = this.GetPath(this.S("ClassPathField"));
        return true;
    }

    protected override String Node(Class varClass)
    {
        if (this.IsDeriveState(varClass))
        {
            return this.S("");
        }

        return base.Node(varClass);
    }

    protected override String ArrayState(Class varClass, Field field, String varName)
    {
        String itemClassName;
        itemClassName = field.ItemClass;

        String itemDeclareClassName;
        itemDeclareClassName = this.DeclareClassName(itemClassName);

        Text k;
        k = this.TextCreate(this.TextArray);
        k = this.Replace(k, "#VarName#", varName);
        k = this.Replace(k, "#ItemClassName#", itemClassName);
        k = this.Replace(k, "#ItemDeclareClassName#", itemDeclareClassName);

        String a;
        a = this.StringCreate(k);
        return a;
    }

    protected override String DeclareClassName(String className)
    {
        Text k;
        k = this.TextCreate(className);

        bool b;
        b = false;
        if (!b)
        {
            if (this.TextSame(k, this.TextCreate(this.S("Class"))))
            {
                b = true;
            }
        }
        if (!b)
        {
            if (this.TextSame(k, this.TextCreate(this.S("Field"))))
            {
                b = true;
            }
        }
        if (!b)
        {
            if (this.TextSame(k, this.TextCreate(this.S("Maide"))))
            {
                b = true;
            }
        }
        if (!b)
        {
            if (this.TextSame(k, this.TextCreate(this.S("Var"))))
            {
                b = true;
            }
        }
        if (!b)
        {
            if (this.TextSame(k, this.TextCreate(this.S("Count"))))
            {
                b = true;
            }
        }

        if (b)
        {
            StringJoin h;
            h = new StringJoin();
            h.Init();

            StringJoin hh;
            hh = this.ToolInfra.StringJoin;

            this.ToolInfra.StringJoin = h;

            this.AddClear().AddS("Node").Add(className);

            String a;
            a = this.AddResult();

            this.ToolInfra.StringJoin = hh;

            return a;
            
        }

        return className;
    }

    protected override String Virtual()
    {
        return this.S("override");
    }
}