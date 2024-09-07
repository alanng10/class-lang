namespace Z.Infra.ListSourceGen;

public class AvalonGen : Gen
{
    public override bool Init()
    {
        base.Init();
        this.ClassFileName = this.S("ToolData/Avalon/Class.txt");
        this.InitMethodFileName = this.S("ToolData/Avalon/InitMaide.txt");
        this.AddMethodFileName = this.S("ToolData/Avalon/AddMaide.txt");
        this.ArrayCompListFileName = this.S("ToolData/Avalon/ArrayCompList.txt");
        this.ItemListFileName = this.S("ToolData/Avalon/ItemList.txt");
        return true;
    }

    protected override bool AddInitField(String index, object value)
    {
        this.AddIndent(2);

        this.AddS("this").AddS(".").Add(index).AddS(" ").AddS("=").AddS(" ").AddS("this").AddS(".");

        this.AddInitFieldAddItem(index, value);

        this.AddS(";").AddLine();
        return true;
    }

    protected override bool AddField(String item)
    {
        this.AddIndent(1)
            .AddS("public").AddS(" ").AddS("virtual").AddS(" ")
            .Add(this.ItemClassName).AddS(" ").Add(item).AddS(" ")
            .AddS("{").AddS(" ").AddS("get").AddS(";").AddS(" ").AddS("set").AddS(";").AddS(" ").AddS("}")
            .AddLine();
        return true;
    }
}