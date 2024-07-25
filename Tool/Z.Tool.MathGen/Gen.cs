namespace Z.Tool.MathGen;

public class Gen : Any
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        this.ToolInfra = ToolInfra.This;
        return true;
    }

    protected virtual ListInfra ListInfra { get; set; }
    protected virtual ToolInfra ToolInfra { get; set; }
    protected virtual string TextPart { get; set; }
    protected virtual string TextMaide { get; set; }
    protected virtual string TextTrigo { get; set; }
    protected virtual Table TrigoTable { get; set; }

    public virtual int Execute()
    {
        ToolInfra toolInfra;
        toolInfra = this.ToolInfra;

        this.TextPart = toolInfra.StorageTextRead("ToolData/Math/Part.txt");
        this.TextMaide = toolInfra.StorageTextRead("ToolData/Math/Maide.txt");
        this.TextTrigo = toolInfra.StorageTextRead("ToolData/Math/TrigoList.txt");

        bool b;
        b = this.SetTrigoTable();
        if (!b)
        {
            return 500;
        }

        List list;
        list = new List();
        list.Init();

        this.ExecuteTrigoMaideList(list, "", "");

        this.ExecuteTrigoMaideList(list, "A", "");

        this.ExecuteTrigoMaideList(list, "", "H");

        this.ExecuteTrigoMaideList(list, "A", "H");

        string newLine;
        newLine = toolInfra.NewLine;

        StringJoin h;
        h = new StringJoin();
        h.Init();

        bool ba;
        ba = false;

        Iter iter;
        iter = list.IterCreate();
        list.IterSet(iter);

        while (iter.Next())
        {
            if (ba)
            {
                h.Append(newLine);
            }

            string aa;
            aa = (string)iter.Value;

            h.Append(aa);

            ba = true;
        }

        string k;
        k = h.Result();

        string ka;
        ka = this.TextPart;
        ka = ka.Replace("#Part#", k);

        string outputPath;
        outputPath = "../../Avalon/Avalon.Math/MathPart.cs";

        toolInfra.StorageTextWrite(outputPath, ka);
        return 0;
    }

    protected virtual bool ExecuteTrigoMaideList(List list, string pre, string post)
    {
        Iter iter;
        iter = this.TrigoTable.IterCreate();
        this.TrigoTable.IterSet(iter);

        while (iter.Next())
        {
            string name;
            name = (string)iter.Value;

            string k;
            k = pre + name + post;

            string a;
            a = this.Maide(k);

            list.Add(a);
        }
        return true;
    }

    protected virtual string Maide(string name)
    {
        string k;
        k = this.TextMaide;

        k = k.Replace("#Name#", name);

        return k;
    }

    protected virtual bool SetTrigoTable()
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;
        ToolInfra toolInfra;
        toolInfra = this.ToolInfra;

        Array k;
        k = toolInfra.SplitLineList(this.TextTrigo);
        
        IntCompare kaa;
        kaa = new IntCompare();
        kaa.Init();

        StringCompare compare;
        compare = new StringCompare();
        compare.CharCompare = kaa;
        compare.Init();

        Table table;
        table = new Table();
        table.Compare = compare;
        table.Init();

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