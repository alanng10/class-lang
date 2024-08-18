
namespace Z.Tool.MathGen;

class InfraPartGen : PartGen
{
    public override bool Init()
    {
        base.Init();
        this.PartFilePath = this.S("ToolData/Math/InfraPart.txt");
        this.MaideFilePath = this.S("ToolData/Math/InfraMaide.txt");
        this.MaideTwoFilePath = this.S("ToolData/Math/InfraMaideTwo.txt");
        this.MaideOperateFilePath = this.S("ToolData/Math/InfraMaideOperate.txt");
        this.OutputFilePath = this.S("../../Infra/Infra/Math_Part.cpp");
        return true;
    }

    protected override String FuncLibName(String name)
    {
        string k;
        k = name.ToLower();

        return "std::" + k;
    }

    protected override bool AddNewLine()
    {
        return true;
    }
}