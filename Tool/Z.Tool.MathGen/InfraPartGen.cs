
namespace Z.Tool.MathGen;

class InfraPartGen : PartGen
{
    public override bool Init()
    {
        base.Init();
        this.PartFilePath = "ToolData/Math/InfraPart.txt";
        this.MaideFilePath = "ToolData/Math/InfraMaide.txt";
        this.MaideTwoFilePath = "ToolData/Math/InfraMaideTwo.txt";
        this.OutputFilePath = "../../Infra/Infra/MathPart.cpp";
        return true;
    }

    protected override bool AppendNewLine(StringJoin h)
    {
        return true;
    }
}