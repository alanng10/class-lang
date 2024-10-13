namespace Z.Tool.PrusateGen;

class InternStateGen : ExternGen
{
    protected virtual String TextInternState { get; set; }

    public override bool Execute()
    {
        this.TextInternState = this.ToolInfra.StorageTextRead(this.S("ToolData/Prusate/InternExtern.txt"));
        return base.Execute();
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

        this.AddS(")").AddS(";").Add(this.NewLine);
        return true;
    }
}