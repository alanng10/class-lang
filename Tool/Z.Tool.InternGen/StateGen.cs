namespace Z.Tool.InternGen;

class StateGen : ToolGen
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        return true;
    }

    public virtual Table MaideTable { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }

    public virtual bool Execute()
    {
        this.ExecuteMaideCallArray();

        this.ExecuteProbateRefer();
        return true;
    }

    protected virtual bool ExecuteProbateRefer()
    {
        ToolInfra toolInfra;
        toolInfra = this.ToolInfra;

        String textPronate;
        textPronate = toolInfra.StorageTextRead(this.S("ToolData/Intern/Pronate.txt"));

        String referList;
        referList = this.GetReferList();

        Text k;
        k = this.TextCreate(textPronate);
        k = this.Replace(k, "#ReferList#", referList);

        String a;
        a = this.StringCreate(k);

        String outputPath;
        outputPath = this.S("../../Infra/InfraIntern/Probate_Part.h");

        toolInfra.StorageTextWrite(outputPath, a);
        return true;
    }

    protected virtual bool ExecuteMaideCallArray()
    {
        ToolInfra toolInfra;
        toolInfra = this.ToolInfra;

        String textState;
        textState = toolInfra.StorageTextRead(this.S("ToolData/Intern/State.txt"));

        long kka;
        kka = this.MaideTable.Count;
        kka = kka + 1;

        String ka;
        ka = this.S(kka.ToString());

        String nameList;
        nameList = this.GetNameList();

        Text k;
        k = this.TextCreate(textState);
        k = this.Replace(k, "#Count#", ka);
        k = this.Replace(k, "#NameList#", nameList);

        String a;
        a = this.StringCreate(k);

        String outputPath;
        outputPath = this.S("../../Infra/InfraIntern/Class_Part.c");

        toolInfra.StorageTextWrite(outputPath, a);
        return true;
    }

    protected virtual string GetReferList()
    {
        String newLine;
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

            this.Append(h, "Int Intern_Intern_");
            this.Append(h, maide.Name);
            this.Append(h, "(Eval* eval, Int frame);");
            this.Append(h, newLine);
        }

        string a;
        a = h.Result();

        return a;
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

            this.Append(h, ",");
            this.Append(h, newLine);
            this.Append(h, "    ");
            this.Append(h, "CastInt");
            this.Append(h, "(");
            this.Append(h, "Intern_Intern_");
            this.Append(h, maide.Name);
            this.Append(h, ")");
        }

        string a;
        a = h.Result();

        return a;
    }
}