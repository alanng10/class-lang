namespace Z.Tool.MathGen;

public class Read : Any
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        this.ToolInfra = ToolInfra.This;
        return true;
    }

    public virtual Table MaideTable { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual ToolInfra ToolInfra { get; set; }
    protected virtual string TextTrigoList { get; set; }
    protected virtual string TextList { get; set; }
    protected virtual Table TrigoTable { get; set; }
    protected virtual Array LineList { get; set; }
    protected virtual Array TrigoLineList { get; set; }

    public virtual int Execute()
    {
        ToolInfra toolInfra;
        toolInfra = this.ToolInfra;

        this.TextList = toolInfra.StorageTextRead("ToolData/Math/List.txt");
        this.TextTrigoList = toolInfra.StorageTextRead("ToolData/Math/TrigoList.txt");

        this.LineList = toolInfra.SplitLineList(this.TextList);
        this.TrigoLineList = toolInfra.SplitLineList(this.TextTrigoList);

        bool b;
        b = this.SetTrigoTable();
        if (!b)
        {
            return 500;
        }

        this.MaideTable = toolInfra.TableCreateStringCompare();

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

        b = this.ExecuteMaideList();
        if (!b)
        {
            return 510;
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

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            string a;
            a = (string)array.GetAt(i);

            int uu;
            uu = a.IndexOf(' ');

            if (uu < 0)
            {
                return false;
            }

            string name;
            name = a.Substring(0, uu);

            string kk;
            kk = a.Substring(uu + 1);

            bool ba;
            ba = toolInfra.GetBool(kk);

            Maide maide;
            maide = this.CreateMaide(name, ba);

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

        Iter iter;
        iter = this.TrigoTable.IterCreate();
        this.TrigoTable.IterSet(iter);

        while (iter.Next())
        {
            string k;
            k = (string)iter.Value;

            string name;
            name = pre + k + post;

            Maide maide;
            maide = this.CreateMaide(name, false);

            if (table.Valid(name))
            {
                return false;
            }

            listInfra.TableAdd(table, name, maide);
        }
        return true;
    }

    protected virtual Maide CreateMaide(string name, bool operandTwo)
    {
        Maide a;
        a = new Maide();
        a.Init();
        a.Name = name;
        a.OperandTwo = operandTwo;
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
        table = toolInfra.TableCreateStringCompare();

        int count;
        count = k.Count;
        int i;
        i = 0;
        while (i < count)
        {
            string aa;
            aa = (string)k.GetAt(i);

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