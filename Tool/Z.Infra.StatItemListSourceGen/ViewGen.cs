namespace Z.Infra.StatItemListSourceGen;

public class ViewGen : Gen
{
    protected override String GetOutputFilePath()
    {
        return this.AddClear().AddS("../../View/").Add(this.Module).Add(this.TextInfra.PathCombine).Add(this.ClassName).AddS(".cl").AddResult();
    } 
}