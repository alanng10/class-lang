namespace Z.Tool.InternGen;

class StateGen : ToolBase
{
    public virtual Table MaideTable { get; set; }

    public virtual bool Execute()
    {
        this.ExecutePrusateRefer();

        this.ExecuteClassMaide();
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

    protected virtual bool ExecuteClassMaide()
    {
        ToolInfra toolInfra;
        toolInfra = this.ToolInfra;

        String textClass;
        textClass = toolInfra.StorageTextRead(this.S("ToolData/Intern/Class.txt"));

        String maideList;
        maideList = this.GetMaideList();

        Text k;
        k = this.TextCreate(textClass);
        k = this.Replace(k, "#MaideList#", maideList);

        String a;
        a = this.StringCreate(k);

        String outputPath;
        outputPath = this.S("../../System/System.Infra/Intern.cla");

        toolInfra.StorageTextWrite(outputPath, a);
        return true;
    }

    protected virtual String GetMaideList()
    {
        this.AddClear();

        Table table;
        table = this.MaideTable;

        Iter iter;
        iter = table.IterCreate();
        table.IterSet(iter);

        bool b;
        b = false;

        while (iter.Next())
        {
            if (b)
            {
                this.AddLine();
            }
            
            Maide maide;
            maide = (Maide)iter.Value;

            this.AddMaide(maide);

            b = true;
        }

        String a;
        a = this.AddResult();

        return a;
    }

    protected virtual bool AddMaide(Maide maide)
    {
        this.AddIndent(1).AddS("maide prusate ").Add(maide.Class).AddS(" ").Add(maide.Name).AddS("(");

        bool b;
        b = false;

        Iter iter;
        iter = maide.Param.IterCreate();

        maide.Param.IterSet(iter);

        while (iter.Next())
        {
            if (b)
            {
                this.AddS(", ");
            }

            Var ka;
            ka = (Var)iter.Value;

            this.AddS("var").AddS(" ").Add(ka.Class).AddS(" ").Add(ka.Name);

            b = true;
        }


        this.AddS(")").AddS(" { }").AddLine();

        return true;
    }
}