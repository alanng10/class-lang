namespace Class.Console;

public class ClassGenTraverse : Traverse
{
    public override bool Init()
    {
        base.Init();
        this.InternVarPrefix = "__V_";
        this.InternModuleInfoClass = "__C_ModuleInfo";
        this.RefKindMask = "0x1000000000000000";
        this.RefKindClearMask = "0x0fffffffffffffff";
        this.Space = " ";
        this.KeywordThis = "this";
        this.KeywordBase = "base";
        this.KeywordNull = "null";
        this.DelimitDot = ".";
        this.DelimitComma = ",";
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

    public override bool ExecuteVarTarget(VarTarget varTarget)
    {
        this.ExecuteNodeVarName(varTarget);
        return true;
    }

    public override bool ExecuteSetTarget(SetTarget setTarget)
    {
        this.ExecuteOperate(setTarget.This);
        this.Text(this.DelimitDot);
        this.Text(setTarget.Field.Value);
        return true;
    }

    public override bool ExecuteBaseSetTarget(BaseSetTarget baseSetTarget)
    {
        this.Text(this.KeywordBase);
        this.Text(this.DelimitDot);
        this.Text(baseSetTarget.Field.Value);
        return true;
    }

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
        Maide maide;
        maide = this.Info(callOperate).CallMaide;
        if (maide == this.Gen.ModuleInfoNameMaide | maide == this.Gen.ModuleInfoVersionMaide)
        {
            this.Text(this.DelimitLeftBracket);

            this.ExecuteOperate(callOperate.This);
            this.Text(this.DelimitDot);
            this.Text(callOperate.Maide.Value);
            
            this.Text(this.DelimitLeftBracket);

            this.Text(this.InternModuleInfoClass);
            this.Text(this.DelimitDot);
            this.Text(maide.Name);
    
            this.Text(this.DelimitRightBracket);
            
            this.Text(this.DelimitRightBracket);
            return true;
        }

        this.Text(this.DelimitLeftBracket);
        this.ExecuteOperate(callOperate.This);
        this.Text(this.DelimitDot);
        this.Text(callOperate.Maide.Value);
        this.Text(this.DelimitLeftBracket);
        this.ExecuteMaideArgue(maide, callOperate.Argue);
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

    public override bool ExecuteAndOperate(AndOperate andOperate)
    {
        this.ExecuteBoolTwoOperand(this.DelimitAnd, andOperate.Left, andOperate.Right);
        return true;
    }

    public override bool ExecuteOrnOperate(OrnOperate ornOperate)
    {
        this.ExecuteBoolTwoOperand(this.DelimitOrn, ornOperate.Left, ornOperate.Right);
        return true;
    }

    public override bool ExecuteAddOperate(AddOperate addOperate)
    {
        this.ExecuteIntTwoOperand(this.DelimitAdd, addOperate.Left, addOperate.Right);
        return true;
    }

    public override bool ExecuteSubOperate(SubOperate subOperate)
    {
        this.ExecuteIntTwoOperand(this.DelimitSub, subOperate.Left, subOperate.Right);
        return true;
    }

    public override bool ExecuteMulOperate(MulOperate mulOperate)
    {
        this.ExecuteIntTwoOperand(this.DelimitMul, mulOperate.Left, mulOperate.Right);
        return true;
    }

    public override bool ExecuteDivOperate(DivOperate divOperate)
    {
        this.ExecuteIntTwoOperand(this.DelimitDiv, divOperate.Left, divOperate.Right);
        return true;
    }

    protected virtual bool ExecuteNodeVarName(NodeNode node)
    {
        Var varVar;
        varVar = this.Info(node).Var;

        if (this.IsBuiltinInt(varVar.SystemInfo))
        {
            this.Text(this.InternVarPrefix);
        }
        this.Text(varVar.Name);
        return true;
    }

    protected virtual bool ExecuteMaideArgue(Maide maide, Argue argue)
    {
        return true;
    }

    protected virtual bool ExecuteBoolTwoOperand(string delimit, Operate left, Operate right)
    {
        ClassClass operandClass;
        operandClass = this.Gen.System.Bool;

        this.Text(this.DelimitLeftBracket);

        this.Text(this.DelimitLeftBracket);
        this.ExecuteValueOperand(left, operandClass);

        this.Text(this.Space);
        this.Text(delimit);
        this.Text(this.Space);

        this.ExecuteValueOperand(right, operandClass);
        this.Text(this.DelimitRightBracket);

        this.Text(this.Space);
        this.Text(this.DelimitOrn);
        this.Text(this.Space);

        this.Text(this.RefKindMask);

        this.Text(this.DelimitRightBracket);
        return true;
    }

    protected virtual bool ExecuteIntTwoOperand(string delimit, Operate left, Operate right)
    {
        ClassClass operandClass;
        operandClass = this.Gen.System.Int;

        this.Text(this.DelimitLeftBracket);

        this.Text(this.DelimitLeftBracket);

        this.Text(this.DelimitLeftBracket);
        this.ExecuteValueOperand(left, operandClass);

        this.Text(this.Space);
        this.Text(delimit);
        this.Text(this.Space);
        
        this.ExecuteValueOperand(right, operandClass);
        this.Text(this.DelimitRightBracket);

        this.Text(this.Space);
        this.Text(this.DelimitAnd);
        this.Text(this.Space);

        this.Text(this.RefKindClearMask);

        this.Text(this.DelimitRightBracket);

        this.Text(this.Space);
        this.Text(this.DelimitOrn);
        this.Text(this.Space);

        this.Text(this.RefKindMask);

        this.Text(this.DelimitRightBracket);
        return true;
    }

    protected virtual bool ExecuteValueOperand(Operate operate, ClassClass requiredClass)
    {
        this.Text(this.DelimitLeftBracket);
        this.ExecuteInputOperate(operate, requiredClass);
        this.Text(this.Space);
        this.Text(this.DelimitAnd);
        this.Text(this.Space);
        this.Text(this.RefKindClearMask);
        this.Text(this.DelimitRightBracket);
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
            this.Text(this.DelimitLeftBracket);

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

            this.Text(this.DelimitRightBracket);
        }
        if (!b)
        {
            this.ExecuteOperate(operate);
        }
        return true;
    }

    protected virtual bool IsBuiltinInt(SystemInfo a)
    {
        int n;
        n = a.Value;
        return !(n < 3 | 12 < n);
    }

    protected virtual Info Info(NodeNode node)
    {
        return (Info)node.NodeAny;
    }

    protected virtual string InternVarPrefix { get; set; }
    protected virtual string InternModuleInfoClass { get; set; }
    protected virtual string RefKindMask { get; set; }
    protected virtual string RefKindClearMask { get; set; }
    protected virtual string Space { get; set; }
    protected virtual string KeywordThis { get; set; }
    protected virtual string KeywordBase { get; set; }
    protected virtual string KeywordNull { get; set; }
    protected virtual string DelimitDot { get; set; }
    protected virtual string DelimitComma { get; set; }
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