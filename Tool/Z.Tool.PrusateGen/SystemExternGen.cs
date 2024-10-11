namespace Z.Tool.PrusateGen;

class SystemExternGen : ExternGen
{
    public override bool Init()
    {
        base.Init();

        this.PrusateFileName = this.S("ToolData/Prusate/SystemExtern.txt");

        this.OutputFilePath = this.S("../../System/System.Infra/Extern.cla");

        this.IntTypeName = this.S("Int");
        return true;
    }

    protected override bool AddFunctionHeader()
    {
        this.AddIndent(1);

        this.AddS("maide prusate ");
        return true;
    }

    protected override bool AddClass(Class varClass)
    {
        if (varClass.HasNew)
        {
            this.AddClassNew(varClass);
        }

        this.AddFieldArray(varClass, varClass.Field);

        this.AddNewLineIfNotEmpty(varClass.Field);

        this.AddMaideArray(varClass, varClass.Maide);

        this.AddNewLineIfNotEmpty(varClass.Maide);

        this.AddFieldArray(varClass, varClass.StaticField);

        this.AddNewLineIfNotEmpty(varClass.StaticField);

        this.AddMaideArray(varClass, varClass.StaticMaide);

        this.AddNewLineIfNotEmpty(varClass.StaticMaide);
        return true;
    }

    protected override bool AddFunction(FunctionOperate functionOperate)
    {
        this.AddFunctionHeader();

        this.Add(this.IntTypeName).AddS(" ");

        functionOperate.ExecuteName();

        this.AddS("(");

        functionOperate.ExecuteParam();

        this.AddS(")").AddS(" { }").Add(this.NewLine);
        return true;
    }

    public override bool AddVarDeclare(String varName)
    {
        this.AddS("var ").Add(this.IntTypeName).AddS(" ").Add(varName);
        return true;
    }
}