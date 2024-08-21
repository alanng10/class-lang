
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
        Text k;
        k = this.TextCreate(name);
        k = this.TextLower(k);

        String ka;
        ka = this.StringCreate(k);

        StringJoin h;
        h = new StringJoin();
        h.Init();

        StringJoin kk;
        kk = this.ToolInfra.StringJoin;

        this.ToolInfra.StringJoin = h;

        String a;
        a = this.AddClear().AddS("std::").Add(ka).AddResult();

        this.ToolInfra.StringJoin = kk;

        return a;
    }

    protected override bool AddNewLine()
    {
        return true;
    }
}