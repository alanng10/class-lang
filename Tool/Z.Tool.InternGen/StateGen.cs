namespace Z.Tool.InternGen;

class StateGen : ToolBase
{
    public virtual Table MaideTable { get; set; }

    public virtual bool Execute()
    {
        this.ExecutePrusateRefer();
        return true;
    }

    protected virtual bool ExecutePrusateRefer()
    {
        ToolInfra toolInfra;
        toolInfra = this.ToolInfra;

        String textPronate;
        textPronate = toolInfra.StorageTextRead(this.S("ToolData/Intern/Prusate.txt"));

        String referList;
        referList = this.GetReferList();

        Text k;
        k = this.TextCreate(textPronate);
        k = this.Replace(k, "#ReferList#", referList);

        String a;
        a = this.StringCreate(k);

        String outputPath;
        outputPath = this.S("../../Infra/InfraIntern/Prusate_Part.h");

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

            this.AddS("Intern_Api Int Intern_Intern_");
            this.Add(maide.Name);
            this.AddS("(Eval* eval, Int frame);");
            this.AddLine();
        }

        String a;
        a = this.AddResult();

        return a;
    }
}