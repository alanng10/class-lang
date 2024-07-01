namespace Class.Console;

public class ModuleStringTraverse : Traverse
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.TextInfra = TextInfra.This;

        this.TextA = this.CreateText();
        this.TextB = this.CreateText();

        this.StringDataA = new StringData();
        this.StringDataA.Init();
        this.StringDataB = new StringData();
        this.StringDataB.Init();

        IntCompare charCompare;
        charCompare = new IntCompare();
        charCompare.Init();
        this.TextCompare = new TextCompare();
        this.TextCompare.CharCompare = charCompare;
        this.TextCompare.Init();
        return true;
    }

    public virtual NodeNode Result { get; set; }
    public virtual Text Path { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual InfraRange Field { get; set; }
    protected virtual InfraRange FieldName { get; set; }
    protected virtual int Index { get; set; }
    protected virtual int CurrentIndex { get; set; }
    protected virtual Text TextA { get; set; }
    protected virtual Text TextB { get; set; }
    protected virtual StringData StringDataA { get; set; }
    protected virtual StringData StringDataB { get; set; }
    protected virtual TextCompare TextCompare { get; set; }

    private Text CreateText()
    {
        Text a;
        a = new Text();
        a.Init();
        a.Range = new InfraRange();
        a.Range.Init();
        return a;
    }

    public override bool ExecuteClass(NodeClass varClass)
    {
        if (varClass == null)
        {
            return true;
        }
        this.ExecuteNode(varClass);

        if (!(this.Result == null))
        {
            return true;
        }

        InfraRange k;
        k = this.FieldName;

        if (k == "Name")
        {
            this.ExecuteClassName(varClass.Name);
        }
        if (k == "Base")
        {
            this.ExecuteClassName(varClass.Base);
        }
        if (k == "Member")
        {
            this.ExecutePart(varClass.Member);
        }
        return true;
    }

    public override bool ExecutePart(Part part)
    {
        if (part == null)
        {
            return true;
        }
        this.ExecuteNode(part);

        Iter iter;
        iter = this.Iter;
        part.Value.IterSet(iter);
        while (iter.Next())
        {
            Comp comp;
            comp = (Comp)iter.Value;
            this.ExecuteComp(comp);
        }
        return true;
    }

    public override bool ExecuteComp(Comp comp)
    {
        if (comp == null)
        {
            return true;
        }

        if (comp is NodeField)
        {
            this.ExecuteField((NodeField)comp);
        }
        if (comp is NodeMaide)
        {
            this.ExecuteMaide((NodeMaide)comp);
        }
        return true;
    }

    public override bool ExecuteField(NodeField field)
    {
        if (field == null)
        {
            return true;
        }
        this.ExecuteNode(field);

        this.ExecuteClassName(field.Class);
        this.ExecuteFieldName(field.Name);
        this.ExecuteCount(field.Count);
        this.ExecuteState(field.Get);
        this.ExecuteState(field.Set);
        return true;
    }

    public override bool ExecuteMaide(NodeMaide maide)
    {
        if (maide == null)
        {
            return true;
        }
        this.ExecuteNode(maide);

        this.ExecuteClassName(maide.Class);
        this.ExecuteMaideName(maide.Name);
        this.ExecuteCount(maide.Count);
        this.ExecuteParam(maide.Param);
        this.ExecuteState(maide.Call);
        return true;
    }

    public override bool ExecuteVar(NodeVar varVar)
    {
        if (varVar == null)
        {
            return true;
        }
        this.ExecuteNode(varVar);

        if (!(this.Result == null))
        {
            return true;
        }

        string k;
        k = this.FieldName;

        if (k == "Class")
        {
            this.ExecuteClassName(varVar.Class);
        }
        if (k == "Name")
        {
            this.ExecuteVarName(varVar.Name);
        }
        return true;
    }

    public override bool ExecuteParam(Param param)
    {
        if (param == null)
        {
            return true;
        }

        int k;
        k = this.Index;

        Array array;
        array = param.Value;
        if (!(this.InfraInfra.CheckIndex(array.Count, k)))
        {
            return true;
        }

        NodeVar varVar;
        varVar = (NodeVar)array.Get(k);
        this.ExecuteVar(varVar);
        return true;
    }

    public override bool ExecuteArgue(Argue argue)
    {
        if (argue == null)
        {
            return true;
        }
        this.ExecuteNode(argue);

        Iter iter;
        iter = this.Iter;
        argue.Value.IterSet(iter);
        while (iter.Next())
        {
            Operate operate;
            operate = (Operate)iter.Value;
            this.ExecuteOperate(operate);
        }
        return true;
    }

    public override bool ExecuteTarget(Target target)
    {
        if (target == null)
        {
            return true;
        }

        if (target is VarTarget)
        {
            this.ExecuteVarTarget((VarTarget)target);
        }
        if (target is SetTarget)
        {
            this.ExecuteSetTarget((SetTarget)target);
        }
        if (target is BaseSetTarget)
        {
            this.ExecuteBaseSetTarget((BaseSetTarget)target);
        }
        return true;
    }

    public override bool ExecuteVarTarget(VarTarget varTarget)
    {
        if (varTarget == null)
        {
            return true;
        }
        this.ExecuteNode(varTarget);

        this.ExecuteVarName(varTarget.Var);
        return true;
    }

    public override bool ExecuteSetTarget(SetTarget setTarget)
    {
        if (setTarget == null)
        {
            return true;
        }
        this.ExecuteNode(setTarget);

        this.ExecuteOperate(setTarget.This);
        this.ExecuteFieldName(setTarget.Field);
        return true;
    }

    public override bool ExecuteBaseSetTarget(BaseSetTarget baseSetTarget)
    {
        if (baseSetTarget == null)
        {
            return true;
        }
        this.ExecuteNode(baseSetTarget);

        this.ExecuteFieldName(baseSetTarget.Field);
        return true;
    }

    public override bool ExecuteValue(Value value)
    {
        if (value == null)
        {
            return true;
        }

        if (value is BoolValue)
        {
            this.ExecuteBoolValue((BoolValue)value);
        }
        if (value is IntValue)
        {
            this.ExecuteIntValue((IntValue)value);
        }
        if (value is IntSignValue)
        {
            this.ExecuteIntSignValue((IntSignValue)value);
        }
        if (value is IntHexValue)
        {
            this.ExecuteIntHexValue((IntHexValue)value);
        }
        if (value is IntHexSignValue)
        {
            this.ExecuteIntHexSignValue((IntHexSignValue)value);
        }
        if (value is StringValue)
        {
            this.ExecuteStringValue((StringValue)value);
        }
        return true;
    }

    public override bool ExecuteBoolValue(BoolValue boolValue)
    {
        if (boolValue == null)
        {
            return true;
        }
        this.ExecuteNode(boolValue);
        return true;
    }

    public override bool ExecuteIntValue(IntValue intValue)
    {
        if (intValue == null)
        {
            return true;
        }
        this.ExecuteNode(intValue);
        return true;
    }

    public override bool ExecuteIntHexValue(IntHexValue intHexValue)
    {
        if (intHexValue == null)
        {
            return true;
        }
        this.ExecuteNode(intHexValue);
        return true;
    }

    public override bool ExecuteIntSignValue(IntSignValue intSignValue)
    {
        if (intSignValue == null)
        {
            return true;
        }
        this.ExecuteNode(intSignValue);
        return true;
    }

    public override bool ExecuteIntHexSignValue(IntHexSignValue intHexSignValue)
    {
        if (intHexSignValue == null)
        {
            return true;
        }
        this.ExecuteNode(intHexSignValue);
        return true;
    }

    public override bool ExecuteStringValue(StringValue stringValue)
    {
        if (stringValue == null)
        {
            return true;
        }
        this.ExecuteNode(stringValue);
        return true;
    }

    public override bool ExecuteCount(NodeCount count)
    {
        if (count == null)
        {
            return true;
        }

        if (count is PrudateCount)
        {
            this.ExecutePrudateCount((PrudateCount)count);
        }
        if (count is ProbateCount)
        {
            this.ExecuteProbateCount((ProbateCount)count);
        }
        if (count is PrecateCount)
        {
            this.ExecutePrecateCount((PrecateCount)count);
        }
        if (count is PrivateCount)
        {
            this.ExecutePrivateCount((PrivateCount)count);
        }
        return true;
    }

    public override bool ExecutePrudateCount(PrudateCount prudateCount)
    {
        if (prudateCount == null)
        {
            return true;
        }
        this.ExecuteNode(prudateCount);
        return true;
    }

    public override bool ExecuteProbateCount(ProbateCount probateCount)
    {
        if (probateCount == null)
        {
            return true;
        }
        this.ExecuteNode(probateCount);
        return true;
    }

    public override bool ExecutePrecateCount(PrecateCount precateCount)
    {
        if (precateCount == null)
        {
            return true;
        }
        this.ExecuteNode(precateCount);
        return true;
    }

    public override bool ExecutePrivateCount(PrivateCount privateCount)
    {
        if (privateCount == null)
        {
            return true;
        }
        this.ExecuteNode(privateCount);
        return true;
    }

    public override bool ExecuteClassName(ClassName className)
    {
        if (className == null)
        {
            return true;
        }
        this.ExecuteNode(className);
        return true;
    }

    public override bool ExecuteFieldName(FieldName fieldName)
    {
        if (fieldName == null)
        {
            return true;
        }
        this.ExecuteNode(fieldName);
        return true;
    }

    public override bool ExecuteMaideName(MaideName maideName)
    {
        if (maideName == null)
        {
            return true;
        }
        this.ExecuteNode(maideName);
        return true;
    }

    public override bool ExecuteVarName(VarName varName)
    {
        if (varName == null)
        {
            return true;
        }
        this.ExecuteNode(varName);
        return true;
    }

    public override bool ExecuteState(State state)
    {
        if (state == null)
        {
            return true;
        }
        this.ExecuteNode(state);

        Iter iter;
        iter = this.Iter;
        state.Value.IterSet(iter);
        while (iter.Next())
        {
            Execute execute;
            execute = (Execute)iter.Value;
            this.ExecuteExecute(execute);
        }
        return true;
    }

    public override bool ExecuteExecute(Execute execute)
    {
        if (execute == null)
        {
            return true;
        }

        if (execute is ReturnExecute)
        {
            this.ExecuteReturnExecute((ReturnExecute)execute);
        }
        if (execute is InfExecute)
        {
            this.ExecuteInfExecute((InfExecute)execute);
        }
        if (execute is WhileExecute)
        {
            this.ExecuteWhileExecute((WhileExecute)execute);
        }
        if (execute is DeclareExecute)
        {
            this.ExecuteDeclareExecute((DeclareExecute)execute);
        }
        if (execute is AssignExecute)
        {
            this.ExecuteAssignExecute((AssignExecute)execute);
        }
        if (execute is OperateExecute)
        {
            this.ExecuteOperateExecute((OperateExecute)execute);
        }
        return true;
    }

    public override bool ExecuteInfExecute(InfExecute infExecute)
    {
        if (infExecute == null)
        {
            return true;
        }
        this.ExecuteNode(infExecute);

        this.ExecuteOperate(infExecute.Cond);
        this.ExecuteState(infExecute.Then);
        return true;
    }

    public override bool ExecuteWhileExecute(WhileExecute whileExecute)
    {
        if (whileExecute == null)
        {
            return true;
        }
        this.ExecuteNode(whileExecute);

        this.ExecuteOperate(whileExecute.Cond);
        this.ExecuteState(whileExecute.Loop);
        return true;
    }

    public override bool ExecuteReturnExecute(ReturnExecute returnExecute)
    {
        if (returnExecute == null)
        {
            return true;
        }
        this.ExecuteNode(returnExecute);

        this.ExecuteOperate(returnExecute.Result);
        return true;
    }

    public override bool ExecuteDeclareExecute(DeclareExecute declareExecute)
    {
        if (declareExecute == null)
        {
            return true;
        }
        this.ExecuteNode(declareExecute);

        this.ExecuteVar(declareExecute.Var);
        return true;
    }

    public override bool ExecuteAssignExecute(AssignExecute assignExecute)
    {
        if (assignExecute == null)
        {
            return true;
        }
        this.ExecuteNode(assignExecute);

        this.ExecuteTarget(assignExecute.Target);
        this.ExecuteOperate(assignExecute.Value);
        return true;
    }

    public override bool ExecuteOperateExecute(OperateExecute operateExecute)
    {
        if (operateExecute == null)
        {
            return true;
        }
        this.ExecuteNode(operateExecute);

        this.ExecuteOperate(operateExecute.Any);
        return true;
    }

    public override bool ExecuteOperate(Operate operate)
    {
        if (operate == null)
        {
            return true;
        }

        if (operate is GetOperate)
        {
            this.ExecuteGetOperate((GetOperate)operate);
        }
        if (operate is CallOperate)
        {
            this.ExecuteCallOperate((CallOperate)operate);
        }
        if (operate is BaseGetOperate)
        {
            this.ExecuteBaseGetOperate((BaseGetOperate)operate);
        }
        if (operate is BaseCallOperate)
        {
            this.ExecuteBaseCallOperate((BaseCallOperate)operate);
        }
        if (operate is VarOperate)
        {
            this.ExecuteVarOperate((VarOperate)operate);
        }
        if (operate is ValueOperate)
        {
            this.ExecuteValueOperate((ValueOperate)operate);
        }
        if (operate is ThisOperate)
        {
            this.ExecuteThisOperate((ThisOperate)operate);
        }
        if (operate is NullOperate)
        {
            this.ExecuteNullOperate((NullOperate)operate);
        }
        if (operate is NewOperate)
        {
            this.ExecuteNewOperate((NewOperate)operate);
        }
        if (operate is ShareOperate)
        {
            this.ExecuteShareOperate((ShareOperate)operate);
        }
        if (operate is CastOperate)
        {
            this.ExecuteCastOperate((CastOperate)operate);
        }
        if (operate is BracketOperate)
        {
            this.ExecuteBracketOperate((BracketOperate)operate);
        }
        if (operate is EqualOperate)
        {
            this.ExecuteEqualOperate((EqualOperate)operate);
        }
        if (operate is AndOperate)
        {
            this.ExecuteAndOperate((AndOperate)operate);
        }
        if (operate is OrnOperate)
        {
            this.ExecuteOrnOperate((OrnOperate)operate);
        }
        if (operate is NotOperate)
        {
            this.ExecuteNotOperate((NotOperate)operate);
        }
        if (operate is LessOperate)
        {
            this.ExecuteLessOperate((LessOperate)operate);
        }
        if (operate is AddOperate)
        {
            this.ExecuteAddOperate((AddOperate)operate);
        }
        if (operate is SubOperate)
        {
            this.ExecuteSubOperate((SubOperate)operate);
        }
        if (operate is MulOperate)
        {
            this.ExecuteMulOperate((MulOperate)operate);
        }
        if (operate is DivOperate)
        {
            this.ExecuteDivOperate((DivOperate)operate);
        }
        if (operate is SignLessOperate)
        {
            this.ExecuteSignLessOperate((SignLessOperate)operate);
        }
        if (operate is SignMulOperate)
        {
            this.ExecuteSignMulOperate((SignMulOperate)operate);
        }
        if (operate is SignDivOperate)
        {
            this.ExecuteSignDivOperate((SignDivOperate)operate);
        }
        if (operate is BitAndOperate)
        {
            this.ExecuteBitAndOperate((BitAndOperate)operate);
        }
        if (operate is BitOrnOperate)
        {
            this.ExecuteBitOrnOperate((BitOrnOperate)operate);
        }
        if (operate is BitNotOperate)
        {
            this.ExecuteBitNotOperate((BitNotOperate)operate);
        }
        if (operate is BitLeftOperate)
        {
            this.ExecuteBitLeftOperate((BitLeftOperate)operate);
        }
        if (operate is BitRightOperate)
        {
            this.ExecuteBitRightOperate((BitRightOperate)operate);
        }
        if (operate is BitSignRightOperate)
        {
            this.ExecuteBitSignRightOperate((BitSignRightOperate)operate);
        }
        return true;
    }

    public override bool ExecuteGetOperate(GetOperate getOperate)
    {
        if (getOperate == null)
        {
            return true;
        }
        this.ExecuteNode(getOperate);

        this.ExecuteOperate(getOperate.This);
        this.ExecuteFieldName(getOperate.Field);
        return true;
    }

    public override bool ExecuteCallOperate(CallOperate callOperate)
    {
        if (callOperate == null)
        {
            return true;
        }
        this.ExecuteNode(callOperate);

        this.ExecuteOperate(callOperate.This);
        this.ExecuteMaideName(callOperate.Maide);
        this.ExecuteArgue(callOperate.Argue);
        return true;
    }

    public override bool ExecuteBaseGetOperate(BaseGetOperate baseGetOperate)
    {
        if (baseGetOperate == null)
        {
            return true;
        }
        this.ExecuteNode(baseGetOperate);

        this.ExecuteFieldName(baseGetOperate.Field);
        return true;
    }

    public override bool ExecuteBaseCallOperate(BaseCallOperate baseCallOperate)
    {
        if (baseCallOperate == null)
        {
            return true;
        }
        this.ExecuteNode(baseCallOperate);

        this.ExecuteMaideName(baseCallOperate.Maide);
        this.ExecuteArgue(baseCallOperate.Argue);
        return true;
    }

    public override bool ExecuteThisOperate(ThisOperate thisOperate)
    {
        if (thisOperate == null)
        {
            return true;
        }
        this.ExecuteNode(thisOperate);
        return true;
    }

    public override bool ExecuteNullOperate(NullOperate nullOperate)
    {
        if (nullOperate == null)
        {
            return true;
        }
        this.ExecuteNode(nullOperate);
        return true;
    }

    public override bool ExecuteVarOperate(VarOperate varOperate)
    {
        if (varOperate == null)
        {
            return true;
        }
        this.ExecuteNode(varOperate);

        this.ExecuteVarName(varOperate.Var);
        return true;
    }

    public override bool ExecuteValueOperate(ValueOperate valueOperate)
    {
        if (valueOperate == null)
        {
            return true;
        }
        this.ExecuteNode(valueOperate);

        this.ExecuteValue(valueOperate.Value);
        return true;
    }

    public override bool ExecuteNewOperate(NewOperate newOperate)
    {
        if (newOperate == null)
        {
            return true;
        }
        this.ExecuteNode(newOperate);

        this.ExecuteClassName(newOperate.Class);
        return true;
    }

    public override bool ExecuteShareOperate(ShareOperate shareOperate)
    {
        if (shareOperate == null)
        {
            return true;
        }
        this.ExecuteNode(shareOperate);

        this.ExecuteClassName(shareOperate.Class);
        return true;
    }

    public override bool ExecuteCastOperate(CastOperate castOperate)
    {
        if (castOperate == null)
        {
            return true;
        }
        this.ExecuteNode(castOperate);

        this.ExecuteClassName(castOperate.Class);
        this.ExecuteOperate(castOperate.Any);
        return true;
    }

    public override bool ExecuteBracketOperate(BracketOperate bracketOperate)
    {
        if (bracketOperate == null)
        {
            return true;
        }
        this.ExecuteNode(bracketOperate);

        this.ExecuteOperate(bracketOperate.Any);
        return true;
    }

    public override bool ExecuteEqualOperate(EqualOperate equalOperate)
    {
        if (equalOperate == null)
        {
            return true;
        }
        this.ExecuteNode(equalOperate);

        this.ExecuteOperate(equalOperate.Left);
        this.ExecuteOperate(equalOperate.Right);
        return true;
    }

    public override bool ExecuteAndOperate(AndOperate andOperate)
    {
        if (andOperate == null)
        {
            return true;
        }
        this.ExecuteNode(andOperate);

        this.ExecuteOperate(andOperate.Left);
        this.ExecuteOperate(andOperate.Right);
        return true;
    }

    public override bool ExecuteOrnOperate(OrnOperate ornOperate)
    {
        if (ornOperate == null)
        {
            return true;
        }
        this.ExecuteNode(ornOperate);

        this.ExecuteOperate(ornOperate.Left);
        this.ExecuteOperate(ornOperate.Right);
        return true;
    }

    public override bool ExecuteNotOperate(NotOperate notOperate)
    {
        if (notOperate == null)
        {
            return true;
        }
        this.ExecuteNode(notOperate);

        this.ExecuteOperate(notOperate.Value);
        return true;
    }

    public override bool ExecuteAddOperate(AddOperate addOperate)
    {
        if (addOperate == null)
        {
            return true;
        }
        this.ExecuteNode(addOperate);

        this.ExecuteOperate(addOperate.Left);
        this.ExecuteOperate(addOperate.Right);
        return true;
    }

    public override bool ExecuteSubOperate(SubOperate subOperate)
    {
        if (subOperate == null)
        {
            return true;
        }
        this.ExecuteNode(subOperate);

        this.ExecuteOperate(subOperate.Left);
        this.ExecuteOperate(subOperate.Right);
        return true;
    }

    public override bool ExecuteMulOperate(MulOperate mulOperate)
    {
        if (mulOperate == null)
        {
            return true;
        }
        this.ExecuteNode(mulOperate);

        this.ExecuteOperate(mulOperate.Left);
        this.ExecuteOperate(mulOperate.Right);
        return true;
    }

    public override bool ExecuteDivOperate(DivOperate divOperate)
    {
        if (divOperate == null)
        {
            return true;
        }
        this.ExecuteNode(divOperate);

        this.ExecuteOperate(divOperate.Left);
        this.ExecuteOperate(divOperate.Right);
        return true;
    }

    public override bool ExecuteLessOperate(LessOperate lessOperate)
    {
        if (lessOperate == null)
        {
            return true;
        }
        this.ExecuteNode(lessOperate);

        this.ExecuteOperate(lessOperate.Left);
        this.ExecuteOperate(lessOperate.Right);
        return true;
    }

    public override bool ExecuteSignMulOperate(SignMulOperate signMulOperate)
    {
        if (signMulOperate == null)
        {
            return true;
        }
        this.ExecuteNode(signMulOperate);

        this.ExecuteOperate(signMulOperate.Left);
        this.ExecuteOperate(signMulOperate.Right);
        return true;
    }

    public override bool ExecuteSignDivOperate(SignDivOperate signDivOperate)
    {
        if (signDivOperate == null)
        {
            return true;
        }
        this.ExecuteNode(signDivOperate);

        this.ExecuteOperate(signDivOperate.Left);
        this.ExecuteOperate(signDivOperate.Right);
        return true;
    }

    public override bool ExecuteSignLessOperate(SignLessOperate signLessOperate)
    {
        if (signLessOperate == null)
        {
            return true;
        }
        this.ExecuteNode(signLessOperate);

        this.ExecuteOperate(signLessOperate.Left);
        this.ExecuteOperate(signLessOperate.Right);
        return true;
    }

    public override bool ExecuteBitAndOperate(BitAndOperate bitAndOperate)
    {
        if (bitAndOperate == null)
        {
            return true;
        }
        this.ExecuteNode(bitAndOperate);

        this.ExecuteOperate(bitAndOperate.Left);
        this.ExecuteOperate(bitAndOperate.Right);
        return true;
    }

    public override bool ExecuteBitOrnOperate(BitOrnOperate bitOrnOperate)
    {
        if (bitOrnOperate == null)
        {
            return true;
        }
        this.ExecuteNode(bitOrnOperate);

        this.ExecuteOperate(bitOrnOperate.Left);
        this.ExecuteOperate(bitOrnOperate.Right);
        return true;
    }

    public override bool ExecuteBitNotOperate(BitNotOperate bitNotOperate)
    {
        if (bitNotOperate == null)
        {
            return true;
        }
        this.ExecuteNode(bitNotOperate);

        this.ExecuteOperate(bitNotOperate.Value);
        return true;
    }

    public override bool ExecuteBitLeftOperate(BitLeftOperate bitLeftOperate)
    {
        if (bitLeftOperate == null)
        {
            return true;
        }
        this.ExecuteNode(bitLeftOperate);

        this.ExecuteOperate(bitLeftOperate.Value);
        this.ExecuteOperate(bitLeftOperate.Count);
        return true;
    }

    public override bool ExecuteBitRightOperate(BitRightOperate bitRightOperate)
    {
        if (bitRightOperate == null)
        {
            return true;
        }
        this.ExecuteNode(bitRightOperate);

        this.ExecuteOperate(bitRightOperate.Value);
        this.ExecuteOperate(bitRightOperate.Count);
        return true;
    }

    public override bool ExecuteBitSignRightOperate(BitSignRightOperate bitSignRightOperate)
    {
        if (bitSignRightOperate == null)
        {
            return true;
        }
        this.ExecuteNode(bitSignRightOperate);

        this.ExecuteOperate(bitSignRightOperate.Value);
        this.ExecuteOperate(bitSignRightOperate.Count);
        return true;
    }

    protected override bool ExecuteNode(NodeNode node)
    {
        if (!(this.CurrentIndex < this.Path.Length))
        {
            this.Result = node;
            return true;
        }

        this.SetField();

        this.SetFieldNameIndex();

        this.CurrentIndex = this.CurrentIndex + this.Field.Length + 1;
        return true;
    }

    protected virtual bool SetField()
    {
        int start;
        start = this.CurrentIndex;

        int end;
        end = 0;

        int u;
        u = this.Path.IndexOf('.', start);

        bool b;
        b = (u < 0);
        if (b)
        {
            end = this.Path.Length;
        }
        if (!b)
        {
            end = u;
        }

        int count;
        count = end - start;

        string a;
        a = this.Path.Substring(start, count);

        this.Field = a;
        return true;
    }

    protected virtual bool SetFieldNameIndex()
    {
        int u;
        u = this.LeftSquareIndex(this.Field);

        bool b;
        b = u < 0;

        if (!b)
        {
            int leftSquareIndex;
            leftSquareIndex = u;

            this.Index = this.GetIndex(this.Field, leftSquareIndex);

            this.FieldName = this.Field.Substring(0, leftSquareIndex);
        }

        if (b)
        {
            this.Index = -1;

            this.FieldName = this.Field;
        }
        return true;
    }

    protected virtual int LeftSquareIndex(string field)
    {
        int a;
        a = field.IndexOf('[');

        return a;
    }

    protected virtual int GetIndex(string field, int leftSquareIndex)
    {
        if (field.Length < 1)
        {
            return -1;
        }

        int lastIndex;
        lastIndex = field.Length - 1;

        char lastChar;
        lastChar = field[lastIndex];

        bool b;
        b = (lastChar == ']');

        if (!b)
        {
            return -1;
        }

        int t;
        t = leftSquareIndex + 1;

        int count;
        count = lastIndex - t;

        string s;
        s = field.Substring(t, count);

        bool parse;
        int n;
        parse = int.TryParse(s, out n);

        if (!parse)
        {
            return -1;
        }

        return n;
    }

    protected virtual bool FieldEqual(string right)
    {
        Text path;
        path = this.Path;

        Text textA;
        Text textB;
        textA = this.TextA;
        textB = this.TextB;

        InfraRange fieldName;
        fieldName = this.FieldName;

        InfraRange ka;
        ka = textA.Range;
        ka.Index = path.Range.Index + fieldName.Index;
        ka.Count = fieldName.Count;

        textA.Data = path.Data;

        this.TextStringGet(textB, this.StringDataB, right);

        bool a;
        a = this.TextInfra.Equal(textA, textB, this.TextCompare);
        return a;
    }

    protected virtual bool TextStringGet(Text text, StringData data, string o)
    {
        data.Value = o;

        text.Data = data;
        text.Range.Index = 0;
        text.Range.Count = o.Length;
        return true;
    }
}