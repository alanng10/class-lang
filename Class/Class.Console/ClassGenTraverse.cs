namespace Class.Console;

public class ClassGenTraverse : Traverse
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        this.InternVarPrefix = "__V_";
        this.InternModuleInfoClass = "__C_ModuleInfo";
        this.Int60Mask = "0xf000000000000000UL";
        this.SignIntShift = "4";
        this.Zero = "0UL";
        this.Indent = new string(' ', 4);
        this.Space = " ";
        this.NewLine = "\n";
        this.KeywordThis = "this";
        this.KeywordBase = "base";
        this.KeywordNull = "null";
        this.KeywordFalse = "false";
        this.KeywordTrue = "true";
        this.KeywordObject = "object";
        this.KeywordULong = "ulong";
        this.KeywordLong = "long";
        this.KeywordUInt = "uint";
        this.KeywordInt = "int";
        this.KeywordUShort = "ushort";
        this.KeywordShort = "short";
        this.KeywordByte = "byte";
        this.KeywordSByte = "sbyte";
        this.KeywordChar = "char";
        this.DelimitDot = ".";
        this.DelimitComma = ",";
        this.DelimitColon = ":";
        this.DelimitSemicolon = ";";
        this.DelimitEqual = "=";
        this.DelimitLess = "<";
        this.DelimitLeftShift = "<<";
        this.DelimitRightShift = ">>";
        this.DelimitComplement = "~";
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
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual Field ThisField { get; set; }
    protected virtual Array SystemTypeIntName { get; set; }
    protected virtual int IndentLevel { get; set; }
    protected virtual string InternVarPrefix { get; set; }
    protected virtual string InternModuleInfoClass { get; set; }
    protected virtual string Int60Mask { get; set; }
    protected virtual string SignIntShift { get; set; }
    protected virtual string Zero { get; set; }
    protected virtual string Indent { get; set; }
    protected virtual string Space { get; set; }
    protected virtual string NewLine { get; set; }
    protected virtual string KeywordThis { get; set; }
    protected virtual string KeywordBase { get; set; }
    protected virtual string KeywordNull { get; set; }
    protected virtual string KeywordFalse { get; set; }
    protected virtual string KeywordTrue { get; set; }
    protected virtual string KeywordObject { get; set; }
    protected virtual string KeywordULong { get; set; }
    protected virtual string KeywordLong { get; set; }
    protected virtual string KeywordUInt { get; set; }
    protected virtual string KeywordInt { get; set; }
    protected virtual string KeywordUShort { get; set; }
    protected virtual string KeywordShort { get; set; }
    protected virtual string KeywordByte { get; set; }
    protected virtual string KeywordSByte { get; set; }
    protected virtual string KeywordChar { get; set; }
    protected virtual string DelimitDot { get; set; }
    protected virtual string DelimitComma { get; set; }
    protected virtual string DelimitColon { get; set; }
    protected virtual string DelimitSemicolon { get; set; }
    protected virtual string DelimitEqual { get; set; }
    protected virtual string DelimitLess { get; set; }
    protected virtual string DelimitLeftShift { get; set; }
    protected virtual string DelimitRightShift { get; set; }
    protected virtual string DelimitComplement { get; set; }
    protected virtual string DelimitAnd { get; set; }
    protected virtual string DelimitOrn { get; set; }
    protected virtual string DelimitNot { get; set; }
    protected virtual string DelimitAdd { get; set; }
    protected virtual string DelimitSub { get; set; }
    protected virtual string DelimitMul { get; set; }
    protected virtual string DelimitDiv { get; set; }
    protected virtual string DelimitLeftBracket { get; set; }
    protected virtual string DelimitRightBracket { get; set; }
    protected virtual Array Array { get; set; }
    protected virtual int ArrayIndex { get; set; }

    protected virtual bool InitSystemTypeIntArray()
    {
        this.SystemTypeIntName = this.ListInfra.ArrayCreate(9);
        
        this.Array = this.SystemTypeIntName;
        this.ArrayIndex = 0;
        this.ArrayAdd(this.KeywordULong);
        this.ArrayAdd(this.KeywordLong);
        this.ArrayAdd(this.KeywordUInt);
        this.ArrayAdd(this.KeywordInt);
        this.ArrayAdd(this.KeywordUShort);
        this.ArrayAdd(this.KeywordShort);
        this.ArrayAdd(this.KeywordByte);
        this.ArrayAdd(this.KeywordSByte);
        this.ArrayAdd(this.KeywordChar);

        this.Array = null;
        return true;
    }

    public override bool ExecuteField(NodeField field)
    {
        this.ThisField = this.Info(field).Field;

        this.ExecuteState(field.Get);
        this.ExecuteState(field.Set);
        
        this.ThisField = null;
        return true;
    }

    public override bool ExecuteAssignExecute(AssignExecute assignExecute)
    {
        int systemInfo;
        systemInfo = 0;
        
        Target target;
        target = assignExecute.Target;
        if (target is SetTarget | target is BaseSetTarget)
        {
            Field field;
            field = this.Info(target).SetField;

            systemInfo = field.SystemInfo.Value;
        }
        if (target is VarTarget)
        {
            Var varVar;
            varVar = this.Info(target).Var;

            if (!(this.ThisField == null))
            {
                if (varVar.Name == "data")
                {
                    systemInfo = this.ThisField.SystemInfo.Value;
                }
            }
        }

        this.TextIndent();
        this.ExecuteTarget(assignExecute.Target);

        this.Text(this.Space);
        this.Text(this.DelimitEqual);
        this.Text(this.Space);

        this.ExecuteSystemTypeInnStart(systemInfo);

        this.ExecuteOperate(assignExecute.Value);

        this.ExecuteSystemTypeInnEnd(systemInfo);

        this.Text(this.DelimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

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
        Field field;
        field = this.Info(getOperate).GetField;

        int u;
        u = field.SystemInfo.Value;

        this.ExecuteSystemTypeResultStart(u);

        this.Text(this.DelimitLeftBracket);

        this.ExecuteOperate(getOperate.This);
        this.Text(this.DelimitDot);
        this.Text(getOperate.Field.Value);
        
        this.Text(this.DelimitRightBracket);

        this.ExecuteSystemTypeResultEnd(u);
        return true;
    }

    public override bool ExecuteBaseGetOperate(BaseGetOperate baseGetOperate)
    {
        Field field;
        field = this.Info(baseGetOperate).GetField;

        int u;
        u = field.SystemInfo.Value;

        this.ExecuteSystemTypeResultStart(u);

        this.Text(this.DelimitLeftBracket);

        this.Text(this.KeywordBase);
        this.Text(this.DelimitDot);
        this.Text(baseGetOperate.Field.Value);

        this.Text(this.DelimitRightBracket);

        this.ExecuteSystemTypeResultEnd(u);
        return true;
    }

    public override bool ExecuteCallOperate(CallOperate callOperate)
    {
        Maide maide;
        maide = this.Info(callOperate).CallMaide;
        
        int u;
        u = maide.SystemInfo.Value;

        this.ExecuteSystemTypeResultStart(u);
        
        bool b;
        b = (maide == this.Gen.ModuleInfoNameMaide | maide == this.Gen.ModuleInfoVersionMaide);
        if (b)
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
        }
        if (!b)
        {
            this.Text(this.DelimitLeftBracket);

            this.ExecuteOperate(callOperate.This);
            this.Text(this.DelimitDot);
            this.Text(callOperate.Maide.Value);
            this.Text(this.DelimitLeftBracket);
            this.ExecuteMaideArgue(maide, callOperate.Argue);
            this.Text(this.DelimitRightBracket);
            
            this.Text(this.DelimitRightBracket);
        }

        this.ExecuteSystemTypeResultEnd(u);
        return true;
    }

    public override bool ExecuteBaseCallOperate(BaseCallOperate baseCallOperate)
    {
        Maide maide;
        maide = this.Info(baseCallOperate).CallMaide;

        int u;
        u = maide.SystemInfo.Value;

        this.ExecuteSystemTypeResultStart(u);

        this.Text(this.DelimitLeftBracket);

        this.Text(this.KeywordBase);
        this.Text(this.DelimitDot);
        this.Text(baseCallOperate.Maide.Value);
        this.Text(this.DelimitLeftBracket);
        this.ExecuteMaideArgue(maide, baseCallOperate.Argue);
        this.Text(this.DelimitRightBracket);

        this.Text(this.DelimitRightBracket);

        this.ExecuteSystemTypeResultEnd(u);
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

    public override bool ExecuteNotOperate(NotOperate notOperate)
    {
        this.ExecuteBoolOneOperand(this.DelimitNot, notOperate.Value);
        return true;
    }

    public override bool ExecuteEqualOperate(EqualOperate equalOperate)
    {
        this.Text(this.DelimitLeftBracket);
        this.ExecuteEqualOperand(equalOperate.Left);

        this.Text(this.Space);
        this.Text(this.DelimitEqual);
        this.Text(this.Space);

        this.ExecuteEqualOperand(equalOperate.Right);
        this.Text(this.DelimitRightBracket);
        return true;
    }

    public override bool ExecuteLessOperate(LessOperate lessOperate)
    {
        this.ExecuteTwoOperand(this.DelimitLess, lessOperate.Left, lessOperate.Right);
        return true;
    }

    public override bool ExecuteSignLessOperate(SignLessOperate signLessOperate)
    {
        this.ExecuteSignIntTwoOperand(this.DelimitLess, signLessOperate.Left, signLessOperate.Right);
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

    public override bool ExecuteSignMulOperate(SignMulOperate signMulOperate)
    {
        this.ExecuteSignIntTwoOperandResultInt(this.DelimitMul, signMulOperate.Left, signMulOperate.Right);
        return true;
    }

    public override bool ExecuteSignDivOperate(SignDivOperate signDivOperate)
    {
        this.ExecuteSignIntTwoOperandResultInt(this.DelimitDiv, signDivOperate.Left, signDivOperate.Right);
        return true;
    }

    public override bool ExecuteBitAndOperate(BitAndOperate bitAndOperate)
    {
        this.ExecuteIntTwoOperand(this.DelimitAnd, bitAndOperate.Left, bitAndOperate.Right);
        return true;
    }

    public override bool ExecuteBitOrnOperate(BitOrnOperate bitOrnOperate)
    {
        this.ExecuteIntTwoOperand(this.DelimitOrn, bitOrnOperate.Left, bitOrnOperate.Right);
        return true;
    }

    public override bool ExecuteBitNotOperate(BitNotOperate bitNotOperate)
    {
        this.ExecuteIntOneOperand(this.DelimitComplement, bitNotOperate.Value);
        return true;
    }

    public override bool ExecuteBitLeftOperate(BitLeftOperate bitLeftOperate)
    {
        this.ExecuteBitShiftTwoOperand(this.DelimitLeftShift, bitLeftOperate.Value, bitLeftOperate.Count);
        return true;
    }

    public override bool ExecuteBitRightOperate(BitRightOperate bitRightOperate)
    {
        this.ExecuteBitShiftTwoOperand(this.DelimitRightShift, bitRightOperate.Value, bitRightOperate.Count);
        return true;
    }

    public override bool ExecuteBitSignRightOperate(BitSignRightOperate bitSignRightOperate)
    {
        this.Text(this.DelimitLeftBracket);

        this.Text(this.DelimitLeftBracket);

        this.ExecuteSignIntOperand(bitSignRightOperate.Value);

        this.Text(this.Space);
        this.Text(this.DelimitRightShift);
        this.Text(this.Space);

        this.ExecuteIntShiftOperand(bitSignRightOperate.Count);

        this.Text(this.DelimitRightBracket);

        this.Text(this.Space);
        this.Text(this.DelimitAnd);
        this.Text(this.Space);

        this.Text(this.Int60Mask);

        this.Text(this.DelimitRightBracket);
        return true;
    }

    protected virtual bool ExecuteNodeVarName(NodeNode node)
    {
        Var varVar;
        varVar = this.Info(node).Var;

        if (this.IsSystemTypeInt(varVar.SystemInfo))
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

    protected virtual bool ExecuteEqualOperand(Operate operand)
    {
        ClassClass a;
        a = this.Info(operand).OperateClass;
        
        bool b;
        b = (a == this.Gen.System.String);
        if (b)
        {
            this.Text(this.DelimitLeftBracket);
            this.Text(this.DelimitLeftBracket);
            this.Text(this.KeywordObject);
            this.Text(this.DelimitRightBracket);
        }
        
        this.ExecuteOperate(operand);

        if (b)
        {
            this.Text(this.DelimitRightBracket);
        }
        return true;
    }

    protected virtual bool ExecuteBoolTwoOperand(string delimit, Operate left, Operate right)
    {
        this.ExecuteTwoOperand(delimit, left, right);
        return true;
    }

    protected virtual bool ExecuteIntTwoOperand(string delimit, Operate left, Operate right)
    {
        this.Text(this.DelimitLeftBracket);
        this.ExecuteTwoOperand(delimit, left, right);

        this.Text(this.Space);
        this.Text(this.DelimitAnd);
        this.Text(this.Space);

        this.Text(this.Int60Mask);

        this.Text(this.DelimitRightBracket);
        return true;
    }

    protected virtual bool ExecuteTwoOperand(string delimit, Operate left, Operate right)
    {
        this.Text(this.DelimitLeftBracket);
        this.ExecuteOperate(left);

        this.Text(this.Space);
        this.Text(delimit);
        this.Text(this.Space);

        this.ExecuteOperate(right);
        this.Text(this.DelimitRightBracket);
        return true;
    }

    protected virtual bool ExecuteBoolOneOperand(string delimit, Operate value)
    {
        this.ExecuteOneOperand(delimit, value, this.Gen.System.Bool);
        return true;
    }

    protected virtual bool ExecuteIntOneOperand(string delimit, Operate value)
    {
        this.Text(this.DelimitLeftBracket);

        this.ExecuteOneOperand(delimit, value, this.Gen.System.Int);

        this.Text(this.Space);
        this.Text(this.DelimitAnd);
        this.Text(this.Space);

        this.Text(this.Int60Mask);

        this.Text(this.DelimitRightBracket);
        return true;
    }

    protected virtual bool ExecuteOneOperand(string delimit, Operate value, ClassClass operandClass)
    {
        this.Text(this.DelimitLeftBracket);

        this.Text(delimit);
        this.Text(this.Space);

        this.ExecuteOperate(value);

        this.Text(this.DelimitRightBracket);
        return true;
    }

    protected virtual bool ExecuteBitShiftTwoOperand(string delimit, Operate value, Operate count)
    {
        this.Text(this.DelimitLeftBracket);

        this.Text(this.DelimitLeftBracket);
        this.ExecuteOperate(value);

        this.Text(this.Space);
        this.Text(delimit);
        this.Text(this.Space);

        this.ExecuteIntShiftOperand(count);
        this.Text(this.DelimitRightBracket);

        this.Text(this.Space);
        this.Text(this.DelimitAnd);
        this.Text(this.Space);

        this.Text(this.Int60Mask);

        this.Text(this.DelimitRightBracket);
        return true;
    }

    protected virtual bool ExecuteSignIntTwoOperandResultInt(string delimit, Operate left, Operate right)
    {
        this.Text(this.DelimitLeftBracket);

        this.Text(this.DelimitLeftBracket);

        this.Text(this.DelimitLeftBracket);
        this.Text(this.KeywordULong);
        this.Text(this.DelimitRightBracket);

        this.ExecuteSignIntTwoOperand(delimit, left, right);

        this.Text(this.DelimitRightBracket);

        this.Text(this.Space);
        this.Text(this.DelimitAnd);
        this.Text(this.Space);

        this.Text(this.Int60Mask);

        this.Text(this.DelimitRightBracket);
        return true;
    }

    protected virtual bool ExecuteSignIntTwoOperand(string delimit, Operate left, Operate right)
    {
        this.Text(this.DelimitLeftBracket);

        this.ExecuteSignIntOperand(left);

        this.Text(this.Space);
        this.Text(delimit);
        this.Text(this.Space);

        this.ExecuteSignIntOperand(right);

        this.Text(this.DelimitRightBracket);
        return true;
    }

    protected virtual bool ExecuteSignIntOperand(Operate operate)
    {
        this.Text(this.DelimitLeftBracket);

        this.Text(this.DelimitLeftBracket);

        this.Text(this.DelimitLeftBracket);

        this.Text(this.DelimitLeftBracket);
        this.Text(this.KeywordLong);
        this.Text(this.DelimitRightBracket);
        this.ExecuteOperate(operate);
        
        this.Text(this.DelimitRightBracket);

        this.Text(this.Space);
        this.Text(this.DelimitLeftShift);
        this.Text(this.Space);
        this.Text(this.SignIntShift);

        this.Text(this.DelimitRightBracket);

        this.Text(this.Space);
        this.Text(this.DelimitRightShift);
        this.Text(this.Space);
        this.Text(this.SignIntShift);

        this.Text(this.DelimitRightBracket);
        return true;
    }

    protected virtual bool ExecuteIntShiftOperand(Operate operate)
    {
        this.Text(this.DelimitLeftBracket);

        this.Text(this.DelimitLeftBracket);
        this.Text(this.KeywordInt);
        this.Text(this.DelimitRightBracket);
        this.ExecuteOperate(operate);

        this.Text(this.DelimitRightBracket);
        return true;
    }

    protected virtual bool ExecuteSystemTypeResultStart(int systemInfo)
    {
        if (systemInfo == 3)
        {
            this.Text(this.DelimitLeftBracket);
        }
        if (systemInfo == 4 | systemInfo == 6 | systemInfo == 8 | systemInfo == 10)
        {
            this.Text(this.DelimitLeftBracket);
            this.Text(this.DelimitLeftBracket);

            this.Text(this.DelimitLeftBracket);
            this.Text(this.KeywordULong);
            this.Text(this.DelimitRightBracket);
        }
        if (systemInfo == 5 | systemInfo == 7 | systemInfo == 9 | systemInfo == 11)
        {
            this.Text(this.DelimitLeftBracket);

            this.Text(this.DelimitLeftBracket);
            this.Text(this.KeywordULong);
            this.Text(this.DelimitRightBracket);
        }
        return true;
    }

    protected virtual bool ExecuteSystemTypeResultEnd(int systemInfo)
    {
        if (systemInfo == 3)
        {
            this.Text(this.Space);
            this.Text(this.DelimitAnd);
            this.Text(this.Space);

            this.Text(this.Int60Mask);
            this.Text(this.DelimitRightBracket);
        }
        if (systemInfo == 4 | systemInfo == 6 | systemInfo == 8 | systemInfo == 10)
        {
            this.Text(this.DelimitRightBracket);

            this.Text(this.Space);
            this.Text(this.DelimitAnd);
            this.Text(this.Space);

            this.Text(this.Int60Mask);
            this.Text(this.DelimitRightBracket);
        }
        if (systemInfo == 5 | systemInfo == 7 | systemInfo == 9 | systemInfo == 11)
        {
            this.Text(this.DelimitRightBracket);
        }
        return true;
    }

    protected virtual bool ExecuteSystemTypeInnStart(int systemInfo)
    {
        if (systemInfo == 4)
        {
            this.Text(this.DelimitLeftBracket);

            this.Text(this.DelimitLeftBracket);

            this.Text(this.DelimitLeftBracket);

            this.Text(this.DelimitLeftBracket);
            this.Text(this.KeywordLong);
            this.Text(this.DelimitRightBracket);
        }
        if (4 < systemInfo & systemInfo < 12)
        {
            int index;
            index = systemInfo - 3;
            string k;
            k = (string)this.SystemTypeIntName.Get(index);
            
            this.Text(this.DelimitLeftBracket);

            this.Text(this.DelimitLeftBracket);
            this.Text(k);
            this.Text(this.DelimitRightBracket);
        }
        return true;
    }

    protected virtual bool ExecuteSystemTypeInnEnd(int systemInfo)
    {
        if (systemInfo == 4)
        {
            this.Text(this.DelimitRightBracket);

            this.Text(this.Space);
            this.Text(this.DelimitLeftShift);
            this.Text(this.Space);
            this.Text(this.SignIntShift);

            this.Text(this.DelimitRightBracket);

            this.Text(this.Space);
            this.Text(this.DelimitRightShift);
            this.Text(this.Space);
            this.Text(this.SignIntShift);

            this.Text(this.DelimitRightBracket);
        }
        if (4 < systemInfo & systemInfo < 12)
        {
            this.Text(this.DelimitRightBracket);
        }
        return true;
    }

    protected virtual bool IsSystemTypeInt(SystemInfo a)
    {
        int n;
        n = a.Value;
        return !(n < 3 | 11 < n);
    }

    protected virtual Info Info(NodeNode node)
    {
        return (Info)node.NodeAny;
    }

    protected virtual bool TextIndent()
    {
        string indent;
        indent = this.Indent;
        int count;
        count = this.IndentLevel;
        int i;
        i = 0;
        while (i < count)
        {
            this.Text(indent);
            i = i + 1;
        }
        return true;
    }

    protected virtual bool Text(string o)
    {
        this.Gen.Operate.ExecuteText(o);
        return true;
    }

    protected virtual bool ArrayAdd(object item)
    {
        int index;
        index = this.ArrayIndex;
        this.Array.Set(index, item);
        index = index + 1;
        this.ArrayIndex = index;
        return true;
    }
}