namespace Z.Tool.PrusateGen;

class SystemExternGen : ExternGen
{
    public override bool Init()
    {
        this.PrusateFileName = this.S("ToolData/Prusate/SystemExtern.txt");

        this.OutputFilePath = this.S("../../System/System.Infra/Extern.cla");

        this.IntTypeName = this.S("Int");

        this.InitClassNewMethodArray();
        return true;
    }
}