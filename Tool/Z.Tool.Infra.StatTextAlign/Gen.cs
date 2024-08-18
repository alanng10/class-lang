namespace Z.Tool.Infra.StatTextAlign;

class Gen : StatGen
{
    public override long Execute()
    {
        this.ClassName = this.S("TextAlign");
        this.ValuePrefix = this.S("Align");

        return base.Execute();
    }
}