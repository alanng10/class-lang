namespace Z.Tool.Saber.NodeList;

public class TravelInfoGen : TravelGen
{
    public override bool Init()
    {
        base.Init();
        this.PathOutput = this.S("../../Module/Class.Console/InfoTravel.cl");
        this.PathSource = this.GetPathName(this.S("InfoSource.cl"));
        this.PathNode = this.GetPath(this.S("InfoNode"));
        this.PathDerive = this.GetPath(this.S("InfoDerive"));
        this.PathExecuteNode = this.GetPath(this.S("InfoExecuteNode"));
        this.PathArray = this.GetPath(this.S("InfoArray"));
        this.PathField = this.GetPath(this.S("InfoField"));
        this.PathExecute = this.GetPath(this.S("InfoExecute"));
        return true;
    }

    protected virtual String PathExecute { get; set; }
    protected virtual String TextExecute { get; set; }

    public override bool Execute()
    {
        this.TextSource = this.StorageTextRead(this.PathSource);
        this.TextNode = this.StorageTextRead(this.PathNode);
        this.TextDerive = this.StorageTextRead(this.PathDerive);
        this.TextExecuteNode = this.StorageTextRead(this.PathExecuteNode);
        this.TextArray = this.StorageTextRead(this.PathArray);
        this.TextField = this.StorageTextRead(this.PathField);
        this.TextExecute = this.StorageTextRead(this.PathExecute);

        this.TextVirtual = this.Virtual();

        String executeList;
        executeList = this.ExecuteList();

        String nodeList;
        nodeList = this.NodeList();

        Text k;
        k = this.TextCreate(this.TextSource);
        k = this.Place(k, "#NodeList#", nodeList);
        k = this.Place(k, "#ExecuteList#", executeList);

        String a;
        a = this.StringCreate(k);

        this.StorageTextWrite(this.PathOutput, a);
        return true;
    }

    protected virtual String ExecuteList()
    {
        StringAdd h;
        h = new StringAdd();
        h.Init();

        StringAdd hh;
        hh = this.StringAdd;

        this.StringAdd = h;

        Table table;
        table = this.ClassTable;

        Iter iter;
        iter = table.IterCreate();
        table.IterSet(iter);

        while (iter.Next())
        {
            GenClass varClass;
            varClass = iter.Value as GenClass;

            String ka;
            ka = this.ExecuteOne(varClass);

            this.Add(ka);
        }

        String a;
        a = this.AddResult();

        this.StringAdd = hh;

        return a;
    }

    protected virtual String ExecuteOne(GenClass varClass)
    {
        if (varClass.AnyInt == 1)
        {
            return this.TextInfra.Zero;
        }

        String className;
        className = varClass.Name;

        String declareClassName;
        declareClassName = this.DeclareClassName(className);

        Text k;
        k = this.TextCreate(this.TextExecute);
        k = this.Place(k, "#ClassName#", className);
        k = this.Place(k, "#DeclareClassName#", declareClassName);

        String a;
        a = this.StringCreate(k);
        return a;
    }

    protected override String DeriveState(GenClass varClass, String varName)
    {
        StringAdd h;
        h = new StringAdd();
        h.Init();

        StringAdd hh;
        hh = this.StringAdd;

        this.StringAdd = h;

        this.AddClear();

        this.AddLine();

        Text k;
        k = this.TextCreate(this.TextDerive);
        k = this.Place(k, "#VarName#", varName);
        k = this.Place(k, "#ClassName#", varClass.Name);

        String ka;
        ka = this.StringCreate(k);

        this.Add(ka);

        String a;
        a = this.AddResult();

        this.StringAdd = hh;

        return a;
    }

    protected override String ArrayState(GenClass varClass, String varName)
    {
        StringAdd h;
        h = new StringAdd();
        h.Init();

        StringAdd hh;
        hh = this.StringAdd;

        this.StringAdd = h;

        this.AddClear();

        Iter iter;
        iter = varClass.Field.IterCreate();
        varClass.Field.IterSet(iter);

        iter.Next();

        Field field;
        field = iter.Value as Field;

        String itemClassName;
        itemClassName = field.ItemClass;

        String itemDeclareClassName;
        itemDeclareClassName = this.DeclareClassName(itemClassName);

        String ka;
        ka = this.ExecuteNode(varName);

        Text k;
        k = this.TextCreate(this.TextArray);
        k = this.Place(k, "#VarName#", varName);
        k = this.Place(k, "#ClassName#", varClass.Name);
        k = this.Place(k, "#ItemClassName#", itemClassName);
        k = this.Place(k, "#ItemDeclareClassName#", itemDeclareClassName);

        String ke;
        ke = this.StringCreate(k);

        this.Add(ka);
        this.AddLine();
        this.Add(ke);

        String a;
        a = this.AddResult();

        this.StringAdd = hh;

        return a;
    }

    protected override String FieldState(GenClass varClass, String varName)
    {
        StringAdd h;
        h = new StringAdd();
        h.Init();

        StringAdd hh;
        hh = this.StringAdd;

        this.StringAdd = h;

        this.AddClear();

        String ka;
        ka = this.ExecuteNode(varName);

        this.Add(ka);

        this.AddLine();
        this.AddIndent(2).AddS("this.Start(\"").Add(varClass.Name).AddS("\");").AddLine();

        bool ba;
        ba = false;

        Table table;
        table = varClass.Field;

        Iter iter;
        iter = table.IterCreate();
        table.IterSet(iter);

        while (iter.Next())
        {
            Field kb;
            kb = iter.Value as Field;

            if (!kb.AnyBool)
            {
                String k;
                k = this.Field(kb, varName);

                if (!ba)
                {
                    this.AddLine();
                    ba = true;
                }

                this.Add(k);
            }

            if (kb.AnyBool)
            {
                if (!ba)
                {
                    this.AddLine();
                    ba = true;
                }

                this.AddIndent(2).AddS("this.FieldStart(\"").Add(kb.Name).AddS("\");").AddLine();

                this.AddIndent(2).AddS("this.Execute").Add(kb.Class).AddS("(").Add(varName).AddS(".").Add(kb.Name).AddS(");").AddLine();

                this.AddIndent(2).AddS("this.FieldEnd(\"").Add(kb.Name).AddS("\");").AddLine();
            }
        }

        this.AddLine();
        this.AddIndent(2).AddS("this.End();").AddLine();

        String a;
        a = this.AddResult();

        this.StringAdd = hh;

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
            if (this.TextSame(k, this.TA(this.SClass)))
            {
                b = true;
            }
        }
        if (!b)
        {
            if (this.TextSame(k, this.TA(this.SField)))
            {
                b = true;
            }
        }
        if (!b)
        {
            if (this.TextSame(k, this.TA(this.SMaide)))
            {
                b = true;
            }
        }
        if (!b)
        {
            if (this.TextSame(k, this.TA(this.SVar)))
            {
                b = true;
            }
        }
        if (!b)
        {
            if (this.TextSame(k, this.TA(this.SCount)))
            {
                b = true;
            }
        }

        if (b)
        {
            StringAdd h;
            h = new StringAdd();
            h.Init();

            StringAdd hh;
            hh = this.StringAdd;

            this.StringAdd = h;

            this.AddClear().AddS("Node").Add(className);

            String a;
            a = this.AddResult();

            this.StringAdd = hh;

            return a;

        }

        return className;
    }
}