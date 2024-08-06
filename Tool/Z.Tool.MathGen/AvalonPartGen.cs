namespace Z.Tool.MathGen;

class AvalonPartGen : PartGen
{
    public override bool Init()
    {
        base.Init();
        this.PartFilePath = "ToolData/Math/Part.txt";
        this.MaideFilePath = "ToolData/Math/Maide.txt";
        this.MaideTwoFilePath = "ToolData/Math/MaideTwo.txt";
        this.MaideOperateFilePath = "ToolData/Math/MaideTwo.txt";
        this.OutputFilePath = "../../Avalon/Avalon.Math/Math_Part.cs";
        return true;
    }
}