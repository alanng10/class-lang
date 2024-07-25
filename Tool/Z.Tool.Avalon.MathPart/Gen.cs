namespace Z.Tool.Avalon.MathPart;

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
    protected virtual string MaideText { get; set; }
    protected virtual string TrigoText { get; set; }
    protected virtual Table TrigoTable { get; set; }

    public virtual int Execute()
    {
        ToolInfra toolInfra;
        toolInfra = this.ToolInfra;

        this.MaideText = toolInfra.StorageTextRead("ToolData/MathMaide.txt");
        this.TrigoText = toolInfra.StorageTextRead("ToolData/TrigoList.txt");

        this.SetTrigoTable();

        


        return 0;
    }

    protected virtual bool SetTrigoTable()
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;
        ToolInfra toolInfra;
        toolInfra = this.ToolInfra;

        Array k;
        k = toolInfra.SplitLineList(this.TrigoText);
        
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
        return true;
    }
}