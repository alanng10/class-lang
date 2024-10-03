namespace Z.Infra.StatItemListSourceGen;

public class MiraiGen : AvalonGen
{
    protected override String GetOutputFilePath()
    {
        return this.AddClear().AddS("../../Mirai/").Add(this.Module).AddS("/").Add(this.ClassName).AddS(".cs").AddResult();
    } 
}