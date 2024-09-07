namespace Z.Tool.InternGen;

class StateGen : ToolBase
{
    public virtual Table MaideTable { get; set; }

    public virtual bool Execute()
    {
        this.ExecuteMaideCallArray();

        this.ExecutePronateRefer();
        return true;
    }

    protected virtual bool ExecutePronateRefer()
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
        outputPath = this.S("../../Infra/InfraIntern/Pronate_Part.h");

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

    protected virtual String GetReferList()
    {
        this.AddClear();

        Table table;
        table = this.MaideTable;

        Iter iter;
        iter = table.IterCreate();
        table.IterSet(iter);

        while (iter.Next())
        {
            Maide maide;
            maide = (Maide)iter.Value;

            this.AddS("Int Intern_Intern_");
            this.Add(maide.Name);
            this.AddS("(Eval* eval, Int frame);");
            this.AddLine();
        }

        String a;
        a = this.AddResult();

        return a;
    }

    protected virtual String GetNameList()
    {
        this.AddClear();

        Table table;
        table = this.MaideTable;

        Iter iter;
        iter = table.IterCreate();
        table.IterSet(iter);

        while (iter.Next())
        {
            Maide maide;
            maide = (Maide)iter.Value;

            this.AddS(",");
            this.AddLine();
            this.AddS("    ");
            this.AddS("CastInt");
            this.AddS("(");
            this.AddS("Intern_Intern_");
            this.Add(maide.Name);
            this.AddS(")");
        }

        String a;
        a = this.AddResult();

        return a;
    }
}