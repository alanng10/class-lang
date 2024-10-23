namespace Z.Tool.PrusateGen;

class InternExternGen : ExternGen
{
    public override bool Init()
    {
        base.Init();

        this.PrusateFileName = this.S("ToolData/Prusate/InternExternPrusate.txt");

        this.OutputFilePath = this.S("../../Infra/InfraIntern/Prusate_Extern.h");

        this.IntTypeName = this.S("Int");
        return true;
    }

    protected override bool AddFunctionHeader()
    {
        this.AddS("Intern_Api Int Intern_Extern_");
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

        functionOperate.ExecuteName();

        this.AddS("(Eval* e, Int f)");

        this.AddS(";").Add(this.NewLine);
        return true;
    }
}