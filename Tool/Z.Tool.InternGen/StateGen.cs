namespace Z.Tool.InternGen;

class StateGen : Any
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.ToolInfra = ToolInfra.This;
        return true;
    }

    public virtual Table MaideTable { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual ToolInfra ToolInfra { get; set; }

    public virtual bool Execute()
    {
        ToolInfra toolInfra;
        toolInfra = this.ToolInfra;

        string textState;
        textState = toolInfra.StorageTextRead("ToolData/Intern/State.txt");

        int kka;
        kka = this.MaideTable.Count;
        kka = kka + 1;

        string ka;
        ka = kka.ToString();

        string nameList;
        nameList = this.GetNameList();

        string k;
        k = textState;
        k = k.Replace("#Count#", ka);
        k = k.Replace("#NameList#", nameList);

        string outputPath;
        outputPath = "../../Infar/InfraIntern/Class_Part.c";
        
        toolInfra.StorageTextWrite(outputPath, k);
        return true;
    }

    protected virtual string GetNameList()
    {
        string newLine;
        newLine = this.ToolInfra.NewLine;

        StringJoin h;
        h = new StringJoin();
        h.Init();

        Table table;
        table = this.MaideTable;

        Iter iter;
        iter = table.IterCreate();
        table.IterSet(iter);

        while (iter.Next())
        {
            Maide maide;
            maide = (Maide)iter.Value;

            this.Append(h, "    , ");
            this.Append(h, "CastInt");
            this.Append(h, "(");
            this.Append(h, "Intern_Intern_");
            this.Append(h, maide.Name);
            this.Append(h, ")");
            this.Append(h, newLine);
        }

        string a;
        a = h.Result();

        return a;
    }

    protected virtual bool Append(StringJoin h, string o)
    {
        this.InfraInfra.StringJoinString(h, o);
        return true;
    }
}