namespace Z.Tool.MathGen;

class SystemGen : PartGen
{
    public override bool Init()
    {
        base.Init();
        this.PartFilePath = this.S("ToolData/Math/System.txt");
        this.MaideFilePath = this.S("ToolData/Math/SystemMaide.txt");
        this.MaideTwoFilePath = this.S("ToolData/Math/SystemMaideTwo.txt");
        this.MaideOperateFilePath = this.S("ToolData/Math/SystemMaideTwo.txt");
        this.OutputFilePath = this.S("../../System/System.Math/Math.cl");
        return true;
    }
}