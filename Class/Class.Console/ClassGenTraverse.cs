namespace Class.Console;

public class ClassGenTraverse : Traverse
{
    public override bool Init()
    {
        base.Init();
        this.DelimitDot = ".";
        this.DelimitLeftBracket = "(";
        this.DelimitRightBracket = ")";
        return true;
    }



    public virtual ClassGen Gen { get; set; }

    public override bool ExecuteGetOperate(GetOperate getOperate)
    {
        this.Text(this.DelimitLeftBracket);
        this.ExecuteOperate(getOperate.This);
        this.Text(this.DelimitDot);
        this.Text(getOperate.Field.Value);
        this.Text(this.DelimitRightBracket);
        return true;
    }

    public override bool ExecuteCallOperate(CallOperate callOperate)
    {
        this.Text(this.DelimitLeftBracket);
        this.ExecuteOperate(callOperate.This);
        this.Text(this.DelimitDot);
        this.Text(callOperate.Maide.Value);
        this.Text(this.DelimitLeftBracket);
        this.ExecuteArgue(callOperate.Argue);
        this.Text(this.DelimitRightBracket);
        this.Text(this.DelimitRightBracket);
        return true;
    }

    protected virtual string DelimitDot { get; set; }
    protected virtual string DelimitLeftBracket { get; set; }
    protected virtual string DelimitRightBracket { get; set; }

    protected virtual bool Text(string o)
    {
        this.Gen.Operate.ExecuteText(o);
        return true;
    }
}