namespace Z.Tool.MathGen;

class AvalonPartGen : PartGen
{
    public override bool Init()
    {
        base.Init();
        this.PartFilePath = this.S("ToolData/Math/Part.txt");
        this.MaideFilePath = this.S("ToolData/Math/Maide.txt");
        this.MaideTwoFilePath = this.S("ToolData/Math/MaideTwo.txt");
        this.MaideOperateFilePath = this.S("ToolData/Math/MaideTwo.txt");
        this.OutputFilePath = this.S("../../Avalon/Avalon.Math/Math_Part.cs");
        return true;
    }
}