namespace Z.Tool.PrusateGen;

class InternStateGen : ExternGen
{
    public override bool Init()
    {
        base.Init();

        this.PrusateFileName = this.S("ToolData/Prusate/InternExtern.txt");

        this.OutputFilePath = this.S("../../Infra/InfraIntern/Extern.c");

        this.IntTypeName = this.S("Int");
        return true;
    }

    protected virtual String TextInternState { get; set; }

    protected virtual bool AddNewLine { get; set; }

    public override bool Execute()
    {
        this.TextInternState = this.ToolInfra.StorageTextRead(this.S("ToolData/Prusate/InternExternState.txt"));
        return base.Execute();
    }

    protected override bool AddClass(Class varClass)
    {
        if (varClass.HasNew)
        {
            this.AddClassNew(varClass);
        }

        this.AddFieldArray(varClass, varClass.Field);

        this.AddMaideArray(varClass, varClass.Maide);

        this.AddFieldArray(varClass, varClass.StaticField);

        this.AddMaideArray(varClass, varClass.StaticMaide);
        return true;
    }

    protected override bool AddFunction(FunctionOperate functionOperate)
    {
        StringAdd kk;
        kk = new StringAdd();
        kk.Init();

        StringAdd ke;
        ke = this.ToolInfra.StringAdd;

        this.ToolInfra.StringAdd = kk;

        this.AddClear();
        
        functionOperate.ExecuteName();
        
        String name;
        name = this.AddResult();


        long paramCount;
        paramCount = functionOperate.ParamCount();

        bool ba;
        ba = functionOperate.Static();
        
        if (!ba)
        {
            paramCount = paramCount + 1;
        }

        String paramCountString;
        paramCountString = this.StringInt(paramCount);

        this.AddClear();

        long count;
        count = paramCount;
        long i;
        i = 0;
        while (i < count)
        {
            String kaa;
            kaa = this.StringInt(i);

            if (0 < i)
            {
                this.AddLine();
            }

            this.AddIndent(1).AddS("Param(").Add(kaa).AddS(");");

            i = i + 1;
        }

        if (0 < count)
        {
            this.AddLine().AddLine();
        }

        String paramString;
        paramString = this.AddResult();

        this.AddClear();

        i = 0;
        while (i < count)
        {
            String kab;
            kab = this.StringInt(i);

            if (0 < i)
            {
                this.AddS(", ");
            }

            this.AddS("a").Add(kab);

            i = i + 1;
        }

        String argueString;
        argueString = this.AddResult();

        Text k;
        k = this.TextCreate(this.TextInternState);
        k = this.Place(k, "#Name#", name);
        k = this.Place(k, "#ParamCount#", paramCountString);
        k = this.Place(k, "#Param#", paramString);
        k = this.Place(k, "#Argue#", argueString);

        String a;
        a = this.StringCreate(k);

        this.ToolInfra.StringAdd = ke;

        this.Add(a);

        if (this.AddNewLine)
        {
            this.AddLine();
        }

        this.AddNewLine = true;
        return true;
    }
}