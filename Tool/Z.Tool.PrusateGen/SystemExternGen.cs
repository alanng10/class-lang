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

        this
            .AddS("maide prusate ")
            ;
        return true;
    }
}