
namespace Z.Tool.MathGen;

class InfraPartGen : PartGen
{
    public override bool Init()
    {
        base.Init();
        this.PartFilePath = "ToolData/Math/InfraPart.txt";
        this.MaideFilePath = "ToolData/Math/InfraMaide.txt";
        this.MaideTwoFilePath = "ToolData/Math/InfraMaideTwo.txt";
        this.MaideOperateFilePath = "ToolData/Math/InfraMaideOperate.txt";
        this.OutputFilePath = "../../Infra/Infra/Math_Part.cpp";
        return true;
    }

    protected override string FuncLibName(string name)
    {
        string k;
        k = name.ToLower();

        return "std::" + k;
    }

    protected override bool AppendNewLine(StringJoin h)
    {
        return true;
    }
}