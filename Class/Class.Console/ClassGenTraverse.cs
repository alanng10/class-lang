namespace Class.Console;

public class ClassGenTraverse : Traverse
{
    public override bool Init()
    {
        base.Init();
        this.Space = " ";
        this.KeywordThis = "this";
        this.KeywordNull = "null";
        this.DelimitDot = ".";
        this.DelimitAnd = "&";
        this.DelimitOrn = "|";
        this.DelimitNot = "!";
        this.DelimitAdd = "+";
        this.DelimitSub = "-";
        this.DelimitMul = "*";
        this.DelimitDiv = "/";
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

    public override bool ExecuteThisOperate(ThisOperate thisOperate)
    {
        this.Text(this.DelimitLeftBracket);
        this.Text(this.KeywordThis);
        this.Text(this.DelimitRightBracket);
        return true;
    }

    public override bool ExecuteAddOperate(AddOperate addOperate)
    {
        this.Text(this.DelimitLeftBracket);
        
        this.ExecuteInputOperate(addOperate.Left, this.Gen.System.Int);
        this.Text(this.Space);
        this.Text(this.DelimitAdd);
        this.Text(this.Space);
        this.ExecuteInputOperate(addOperate.Right, this.Gen.System.Int);
        this.Text(this.DelimitRightBracket);
        return true;
    }

    public override bool ExecuteSubOperate(SubOperate subOperate)
    {
        this.ExecuteTwoOperand(this.DelimitSub, subOperate.Left, subOperate.Right);
        return true;
    }

    public override bool ExecuteMulOperate(MulOperate mulOperate)
    {
        this.ExecuteTwoOperand(this.DelimitMul, mulOperate.Left, mulOperate.Right);
        return true;
    }

    public override bool ExecuteDivOperate(DivOperate divOperate)
    {
        this.ExecuteTwoOperand(this.DelimitDiv, divOperate.Left, divOperate.Right);
        return true;
    }

    protected virtual bool ExecuteTwoOperand(string delimit, Operate left, Operate right)
    {

        return true;
    }

    protected virtual bool ExecuteInputOperate(Operate operate, ClassClass requiredClass)
    {
        ClassClass a;
        a = this.Info(operate).OperateClass;

        bool b;
        b = (a == this.Gen.NullClass);
        if (b)
        {
            bool ba;
            ba = false;
            if (!ba & requiredClass == this.Gen.System.Bool)
            {
                this.Text("__BoolValue.Null");
                ba = true;
            }
            if (!ba & requiredClass == this.Gen.System.Int)
            {
                this.Text("__IntValue.Null");
                ba = true;
            }
            if (!ba)
            {
                this.Text(this.KeywordNull);
            }
        }
        if (!b)
        {
            this.ExecuteOperate(operate);
        }
        return true;
    }

    protected virtual Info Info(NodeNode node)
    {
        return (Info)node.NodeAny;
    }

    protected virtual string Space { get; set; }
    protected virtual string KeywordThis { get; set; }
    protected virtual string KeywordNull { get; set; }
    protected virtual string DelimitDot { get; set; }
    protected virtual string DelimitAnd { get; set; }
    protected virtual string DelimitOrn { get; set; }
    protected virtual string DelimitNot { get; set; }
    protected virtual string DelimitAdd { get; set; }
    protected virtual string DelimitSub { get; set; }
    protected virtual string DelimitMul { get; set; }
    protected virtual string DelimitDiv { get; set; }
    protected virtual string DelimitLeftBracket { get; set; }
    protected virtual string DelimitRightBracket { get; set; }

    protected virtual bool Text(string o)
    {
        this.Gen.Operate.ExecuteText(o);
        return true;
    }
}