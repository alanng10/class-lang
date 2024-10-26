namespace Z.Tool.MathGen;

class SystemGen : PartGen
{
    public override bool Init()
    {
        base.Init();
        this.PartFilePath = this.S("ToolData/Math/System.txt");
        this.MaideFilePath = this.S("ToolData/Math/Maide.txt");
        this.MaideTwoFilePath = this.S("ToolData/Math/MaideTwo.txt");
        this.MaideOperateFilePath = this.S("ToolData/Math/MaideTwo.txt");
        this.OutputFilePath = this.S("../../System/System.Math/Math.cla");
        return true;
    }
}