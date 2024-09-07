namespace Z.Tool.MathGen;

public class Read : ToolBase
{
    public virtual Table MaideTable { get; set; }
    protected virtual String TextTrigoList { get; set; }
    protected virtual String TextList { get; set; }
    protected virtual Table TrigoTable { get; set; }
    protected virtual Array LineList { get; set; }
    protected virtual Array TrigoLineList { get; set; }

    public virtual long Execute()
    {
        ToolInfra toolInfra;
        toolInfra = this.ToolInfra;

        this.TextList = toolInfra.StorageTextRead(this.S("ToolData/Math/List.txt"));
        this.TextTrigoList = toolInfra.StorageTextRead(this.S("ToolData/Math/TrigoList.txt"));

        this.LineList = toolInfra.TextLimitLineString(this.TextList);
        this.TrigoLineList = toolInfra.TextLimitLineString(this.TextTrigoList);

        bool b;
        b = this.SetTrigoTable();
        if (!b)
        {
            return 450;
        }

        this.MaideTable = toolInfra.TableCreateStringLess();

        b = this.ExecuteMaideList();
        if (!b)
        {
            return 500;
        }

        b = this.ExecuteTrigoMaideList("", "");
        if (!b)
        {
            return 501;
        }

        b = this.ExecuteTrigoMaideList("A", "");
        if (!b)
        {
            return 502;
        }

        b = this.ExecuteTrigoMaideList("", "H");
        if (!b)
        {
            return 503;
        }

        b = this.ExecuteTrigoMaideList("A", "H");
        if (!b)
        {
            return 504;
        }

        return 0;
    }

    protected virtual bool ExecuteMaideList()
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;
        ToolInfra toolInfra;
        toolInfra = this.ToolInfra;

        Table table;
        table = this.MaideTable;

        Array array;
        array = this.LineList;

        Text space;
        space = this.TextCreate(this.S(" "));

        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            String a;
            a = (String)array.GetAt(i);

            Text k;
            k = this.TextCreate(a);

            Array uu;
            uu = this.TextLimit(k, space);

            if (!(uu.Count == 4))
            {
                return false;
            }

            Text textName;
            textName = (Text)uu.GetAt(0);

            Text textOperandTwo;
            textOperandTwo = (Text)uu.GetAt(1);

            Text textOperate;
            textOperate = (Text)uu.GetAt(2);

            Text textDelimit;
            textDelimit = (Text)uu.GetAt(3);

            String name;
            name = this.StringCreate(textName);

            String operandTwo;
            operandTwo = this.StringCreate(textOperandTwo);

            String operate;
            operate = this.StringCreate(textOperate);

            String delimit;
            delimit = this.StringCreate(textDelimit);

            bool ba;
            ba = toolInfra.GetBool(operandTwo);

            bool bb;
            bb = toolInfra.GetBool(operate);

            String kc;
            kc = null;
            
            if (bb)
            {
                kc = delimit;
            }

            Maide maide;
            maide = this.CreateMaide(name, ba, kc);

            if (table.Valid(name))
            {
                return false;
            }

            listInfra.TableAdd(table, name, maide);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteTrigoMaideList(string pre, string post)
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;

        Table table;
        table = this.MaideTable;

        String preK;
        String postK;
        preK = this.S(pre);
        postK = this.S(post);

        Iter iter;
        iter = this.TrigoTable.IterCreate();
        this.TrigoTable.IterSet(iter);

        while (iter.Next())
        {
            String k;
            k = (String)iter.Value;

            String name;
            name = this.AddClear().Add(preK).Add(k).Add(postK).AddResult();

            Maide maide;
            maide = this.CreateMaide(name, false, null);

            if (table.Valid(name))
            {
                return false;
            }

            listInfra.TableAdd(table, name, maide);
        }
        return true;
    }

    protected virtual Maide CreateMaide(String name, bool operandTwo, String operateDelimit)
    {
        Maide a;
        a = new Maide();
        a.Init();
        a.Name = name;
        a.OperandTwo = operandTwo;
        a.OperateDelimit = operateDelimit;
        return a;
    }

    protected virtual bool SetTrigoTable()
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;
        ToolInfra toolInfra;
        toolInfra = this.ToolInfra;

        Array k;
        k = this.TrigoLineList;
        
        Table table;
        table = toolInfra.TableCreateStringLess();

        long count;
        count = k.Count;
        int i;
        i = 0;
        while (i < count)
        {
            String aa;
            aa = (String)k.GetAt(i);

            if (table.Valid(aa))
            {
                return false;
            }

            listInfra.TableAdd(table, aa, aa);

            i = i + 1;
        }

        this.TrigoTable = table;
        return true;
    }
}