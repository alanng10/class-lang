namespace Class.Module;

public class StateTraverse : Traverse
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        this.TextInfra = TextInfra.This;
        this.ClassInfra = ClassInfra.This;
        this.TextStringValue = TextStringValue.This;

        this.System = this.Create.SystemClass;
        this.NullClass = this.Create.NullClass;

        this.VarStack = new Stack();
        this.VarStack.Init();
        
        this.VarStackIter = new Iter();
        this.VarStackIter.Init();
        this.ParamIter = new TableIter();
        this.ParamIter.Init();
        this.ArgueIter = new ArrayIter();
        this.ArgueIter.Init();

        this.SData = this.S("data");
        this.SValue = this.S("value");
        return true;
    }

    protected virtual ListInfra ListInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual TextStringValue TextStringValue { get; set; }
    protected virtual SystemClass System { get; set; }
    protected virtual ClassClass NullClass { get; set; }
    protected virtual ClassClass ThisClass { get; set; }
    protected virtual ClassClass ThisResultClass { get; set; }
    protected virtual Table StateVar { get; set; }
    protected virtual Stack VarStack { get; set; }
    protected virtual Iter VarStackIter { get; set; }
    protected virtual Iter ParamIter { get; set; }
    protected virtual Iter ArgueIter { get; set; }
    protected virtual String SData { get; set; }
    protected virtual String SValue { get; set; }

    public override bool ExecuteClass(NodeClass varClass)
    {
        if (varClass == null)
        {
            return true;
        }

        this.ThisClass = this.Info(varClass).Class;

        base.ExecuteClass(varClass);
        return true;
    }

    public override bool ExecuteField(NodeField nodeField)
    {
        if (nodeField == null)
        {
            return true;
        }

        State nodeGet;
        nodeGet = nodeField.Get;
        State nodeSet;
        nodeSet = nodeField.Set;

        Field field;
        field = this.Info(nodeField).Field;
        if (field == null)
        {
            return true;
        }

        this.FieldGet(field, nodeGet);
        this.FieldSet(field, nodeSet);
        return true;
    }

    protected virtual bool FieldGet(Field varField, State nodeGet)
    {
        if (nodeGet == null)
        {
            return true;
        }

        this.ThisResultClass = varField.Class;

        this.StateVar = varField.Get;

        Var dataVar;
        dataVar = new Var();
        dataVar.Init();
        dataVar.Name = this.SData;
        dataVar.Class = varField.Class;
        dataVar.Index = this.StateVar.Count;

        Table o;
        o = this.ClassInfra.TableCreateStringLess();

        this.ListInfra.TableAdd(this.StateVar, dataVar.Name, dataVar);
        this.ListInfra.TableAdd(o, dataVar.Name, dataVar);

        this.VarStack.Push(o);

        this.ExecuteState(nodeGet);

        this.VarStack.Pop();

        this.StateVar = null;
        this.ThisResultClass = null;
        return true;
    }

    protected virtual bool FieldSet(Field varField, State nodeSet)
    {
        if (nodeSet == null)
        {
            return true;
        }

        this.ThisResultClass = this.System.Bool;

        this.StateVar = varField.Set;

        Var dataVar;
        dataVar = new Var();
        dataVar.Init();
        dataVar.Name = this.SData;
        dataVar.Class = varField.Class;
        dataVar.Index = this.StateVar.Count;

        Var valueVar;
        valueVar = new Var();
        valueVar.Init();
        valueVar.Name = this.SValue;
        valueVar.Class = varField.Class;
        valueVar.Index = this.StateVar.Count;
        
        Table o;
        o = this.ClassInfra.TableCreateStringLess();

        this.ListInfra.TableAdd(this.StateVar, dataVar.Name, dataVar);
        this.ListInfra.TableAdd(this.StateVar, valueVar.Name, valueVar);
        this.ListInfra.TableAdd(o, dataVar.Name, dataVar);
        this.ListInfra.TableAdd(o, valueVar.Name, valueVar);

        this.VarStack.Push(o);

        this.ExecuteState(nodeSet);

        this.VarStack.Pop();

        this.StateVar = null;
        this.ThisResultClass = null;
        return true;
    }

    public override bool ExecuteMaide(NodeMaide nodeMaide)
    {
        if (nodeMaide == null)
        {
            return true;
        }

        Param param;
        param = nodeMaide.Param;
        State call;
        call = nodeMaide.Call;

        Maide maide;
        maide = this.Info(nodeMaide).Maide;
        if (maide == null)
        {
            return true;
        }

        this.ThisResultClass = maide.Class;

        this.StateVar = maide.Call;

        this.VarTableAdd(this.StateVar, maide.Param);

        this.VarStack.Push(maide.Param);

        this.ExecuteState(call);

        this.VarStack.Pop();

        this.StateVar = null;
        this.ThisResultClass = null;
        return true;
    }

    public override bool ExecuteVar(NodeVar nodeVar)
    {
        if (nodeVar == null)
        {
            return true;
        }

        VarName name;
        name = nodeVar.Name;
        ClassName nodeClass;
        nodeClass = nodeVar.Class;

        String varName;
        varName = name.Value;
        String className;
        className = nodeClass.Value;

        if (this.StateVar.Valid(varName))
        {
            this.Error(this.ErrorKind.NameUnavailable, nodeVar);
            return true;
        }

        ClassClass varClass;
        varClass = this.Class(className);
        if (varClass == null)
        {
            this.Error(this.ErrorKind.ClassUndefined, nodeVar);
            return true;
        }

        Var a;
        a = new Var();
        a.Init();
        a.Name = varName;
        a.Class = varClass;
        a.Index = this.StateVar.Count;
        a.Any = nodeVar;

        Table oo;
        oo = (Table)this.VarStack.Top;

        this.ListInfra.TableAdd(oo, a.Name, a);
        this.ListInfra.TableAdd(this.StateVar, a.Name, a);

        this.Info(nodeVar).Var = a;
        return true;
    }

    public override bool ExecuteState(State state)
    {
        if (state == null)
        {
            return true;
        }

        Table h;
        h = this.ClassInfra.TableCreateStringLess();

        this.VarStack.Push(h);

        base.ExecuteState(state);

        this.VarStack.Pop();
        return true;
    }

    public override bool ExecuteInfExecute(InfExecute infExecute)
    {
        if (infExecute == null)
        {
            return true;
        }

        Operate cond;
        cond = infExecute.Cond;
        State then;
        then = infExecute.Then;

        base.ExecuteInfExecute(infExecute);

        this.ExecuteCondBodyExecute(infExecute, cond);
        return true;
    }

    public override bool ExecuteWhileExecute(WhileExecute whileExecute)
    {
        if (whileExecute == null)
        {
            return true;
        }

        Operate cond;
        cond = whileExecute.Cond;
        State loop;
        loop = whileExecute.Loop;

        base.ExecuteWhileExecute(whileExecute);

        this.ExecuteCondBodyExecute(whileExecute, cond);
        return true;
    }

    public override bool ExecuteReturnExecute(ReturnExecute returnExecute)
    {
        if (returnExecute == null)
        {
            return true;
        }

        Operate result;
        result = returnExecute.Result;

        base.ExecuteReturnExecute(returnExecute);

        ClassClass resultClass;
        resultClass = null;
        if (!(result == null))
        {
            resultClass = this.Info(result).OperateClass;
            if (resultClass == null)
            {
                this.Error(this.ErrorKind.ResultUndefined, returnExecute);
            }
        }

        if (!(resultClass == null))
        {
            if (!this.ValidClass(resultClass, this.ThisResultClass))
            {
                this.Error(this.ErrorKind.ResultUnassignable, returnExecute);
            }
        }
        return true;
    }

    public override bool ExecuteAreExecute(AreExecute areExecute)
    {
        if (areExecute == null)
        {
            return true;
        }

        Target target;            
        target = areExecute.Target;
        Operate value;
        value = areExecute.Value;

        base.ExecuteAreExecute(areExecute);

        ClassClass targetClass;
        targetClass = null;
        if (!(target == null))
        {
            targetClass = this.Info(target).TargetClass;
            if (targetClass == null)
            {
                this.Error(this.ErrorKind.TargetUndefined, areExecute);
            }
        }

        ClassClass valueClass;
        valueClass = null;
        if (!(value == null))
        {
            valueClass = this.Info(value).OperateClass;
            if (valueClass == null)
            {
                this.Error(this.ErrorKind.ValueUndefined, areExecute);
            }
        }

        if (!(targetClass == null) & !(valueClass == null))
        {
            if (!this.ValidClass(valueClass, targetClass))
            {
                this.Error(this.ErrorKind.ValueUnassignable, areExecute);
            }
        }
        return true;
    }

    public override bool ExecuteVarTarget(VarTarget varTarget)
    {
        if (varTarget == null)
        {
            return true;
        }

        VarName name;
        name = varTarget.Var;

        ClassClass varClass;
        varClass = this.ExecuteVarNameNode(varTarget, name);

        this.Info(varTarget).TargetClass = varClass;
        return true;
    }

    public override bool ExecuteSetTarget(SetTarget setTarget)
    {
        if (setTarget == null)
        {
            return true;
        }

        Operate varThis;
        varThis = setTarget.This;
        FieldName nodeField;
        nodeField = setTarget.Field;

        base.ExecuteSetTarget(setTarget);

        Field field;
        field = this.ExecuteThisFieldNode(setTarget, varThis, nodeField);

        ClassClass fieldClass;
        fieldClass = null;
        if (!(field == null))
        {
            fieldClass = field.Class;
        }

        this.Info(setTarget).SetField = field;
        this.Info(setTarget).TargetClass = fieldClass;
        return true;
    }

    public override bool ExecuteGetOperate(GetOperate getOperate)
    {
        if (getOperate == null)
        {
            return true;
        }

        Operate varThis;
        varThis = getOperate.This;
        FieldName nodeField;
        nodeField = getOperate.Field;

        base.ExecuteGetOperate(getOperate);

        Field field;
        field = this.ExecuteThisFieldNode(getOperate, varThis, nodeField);

        ClassClass fieldClass;
        fieldClass = null;
        if (!(field == null))
        {
            fieldClass = field.Class;
        }

        this.Info(getOperate).GetField = field;
        this.Info(getOperate).OperateClass = fieldClass;
        return true;
    }

    public override bool ExecuteCallOperate(CallOperate callOperate)
    {
        if (callOperate == null)
        {
            return true;
        }

        Operate varThis;
        varThis = callOperate.This;
        MaideName nodeMaide;
        nodeMaide = callOperate.Maide;
        Argue argue;
        argue = callOperate.Argue;

        base.ExecuteCallOperate(callOperate);

        ClassClass thisClass;
        thisClass = null;
        if (!(varThis == null))
        {
            thisClass = this.Info(varThis).OperateClass;
            if (thisClass == null)
            {
                this.Error(this.ErrorKind.ThisUndefined, callOperate);
            }
        }

        String maideName;
        maideName = null;
        if (!(nodeMaide == null))
        {
            maideName = nodeMaide.Value;
        }

        Maide maide;
        maide = null;

        if (!(thisClass == null))
        {
            if (!(maideName == null))
            {
                maide = this.Maide(thisClass, maideName);
                if (maide == null)
                {
                    this.Error(this.ErrorKind.MaideUndefined, callOperate);
                }
            }
        }

        if (!(maide == null))
        {
            if (!this.ArgueMatch(maide, argue))
            {
                this.Error(this.ErrorKind.ArgueUnassignable, callOperate);
            }
        }

        ClassClass operateClass;
        operateClass = null;
        if (!(maide == null))
        {
            operateClass = maide.Class;
        }

        this.Info(callOperate).CallMaide = maide;
        this.Info(callOperate).OperateClass = operateClass;
        return true;
    }

    public override bool ExecuteThisOperate(ThisOperate thisOperate)
    {
        if (thisOperate == null)
        {
            return true;
        }

        this.Info(thisOperate).OperateClass = this.ThisClass;
        return true;
    }

    public override bool ExecuteBaseOperate(BaseOperate baseOperate)
    {
        if (baseOperate == null)
        {
            return true;
        }

        this.Info(baseOperate).OperateClass = this.ThisClass.Base;
        return true;
    }

    public override bool ExecuteNullOperate(NullOperate nullOperate)
    {
        if (nullOperate == null)
        {
            return true;
        }

        this.Info(nullOperate).OperateClass = this.NullClass;
        return true;
    }


    public override bool ExecuteNewOperate(NewOperate newOperate)
    {
        if (newOperate == null)
        {
            return true;
        }

        ClassName nodeClass;
        nodeClass = newOperate.Class;

        this.WordClassOperate(newOperate, nodeClass);
        return true;
    }

    public override bool ExecuteShareOperate(ShareOperate shareOperate)
    {
        if (shareOperate == null)
        {
            return true;
        }

        ClassName nodeClass;
        nodeClass = shareOperate.Class;

        this.WordClassOperate(shareOperate, nodeClass);
        return true;
    }

    public override bool ExecuteCastOperate(CastOperate castOperate)
    {
        if (castOperate == null)
        {
            return true;
        }

        ClassName nodeClass;
        nodeClass = castOperate.Class;
        Operate any;
        any = castOperate.Any;

        base.ExecuteCastOperate(castOperate);

        ClassClass anyClass;
        anyClass = null;
        if (!(any == null))
        {
            anyClass = this.Info(any).OperateClass;
            if (anyClass == null)
            {
                this.Error(this.ErrorKind.AnyUndefined, castOperate);
            }
        }

        String className;
        className = null;
        if (!(nodeClass == null))
        {
            className = nodeClass.Value;
        }

        ClassClass varClass;
        varClass = null;
        if (!(className == null))
        {
            varClass = this.Class(className);
            if (varClass == null)
            {
                this.Error(this.ErrorKind.ClassUndefined, castOperate);
            }
        }

        if (!(anyClass == null))
        {
            if (!(varClass == null))
            {
                if (!this.ValidClass(anyClass, varClass))
                {
                    if (!this.ValidClass(varClass, anyClass))
                    {
                        this.Error(this.ErrorKind.CastUnachievable, castOperate);
                    }
                }
            }
        }

        this.Info(castOperate).OperateClass = varClass;
        return true;
    }

    public override bool ExecuteVarOperate(VarOperate varOperate)
    {
        if (varOperate == null)
        {
            return true;
        }

        VarName name;
        name = varOperate.Var;

        ClassClass varClass;
        varClass = this.ExecuteVarNameNode(varOperate, name);

        this.Info(varOperate).OperateClass = varClass;
        return true;
    }

    public override bool ExecuteValueOperate(ValueOperate valueOperate)
    {
        if (valueOperate == null)
        {
            return true;
        }

        Value value;
        value = valueOperate.Value;

        base.ExecuteValueOperate(valueOperate);

        ClassClass valueClass;
        valueClass = null;

        if (value is BoolValue)
        {
            valueClass = this.System.Bool;
        }
        if (value is IntValue | value is IntHexValue | value is IntSignValue | value is IntHexSignValue)
        {
            valueClass = this.System.Int;
        }
        if (value is StringValue)
        {
            valueClass = this.System.String;
        }

        this.Info(valueOperate).OperateClass = valueClass;
        return true;
    }

    public override bool ExecuteBraceOperate(BraceOperate braceOperate)
    {
        if (braceOperate == null)
        {
            return true;
        }

        Operate any;
        any = braceOperate.Any;

        base.ExecuteBraceOperate(braceOperate);

        ClassClass anyClass;
        anyClass = null;
        if (!(any == null))
        {
            anyClass = this.Info(any).OperateClass;
            if (anyClass == null)
            {
                this.Error(this.ErrorKind.AnyUndefined, braceOperate);
            }
        }

        this.Info(braceOperate).OperateClass = anyClass;
        return true;
    }

    public override bool ExecuteSameOperate(SameOperate sameOperate)
    {
        if (sameOperate == null)
        {
            return true;
        }

        base.ExecuteSameOperate(sameOperate);

        this.Info(sameOperate).OperateClass = this.System.Bool;
        return true;
    }

    public override bool ExecuteAndOperate(AndOperate andOperate)
    {
        if (andOperate == null)
        {
            return true;
        }

        Operate left;
        left = andOperate.Lite;
        Operate right;
        right = andOperate.Rite;

        base.ExecuteAndOperate(andOperate);

        this.ExecuteTwoOperandOperate(andOperate, left, right, this.System.Bool, this.System.Bool);
        return true;
    }

    public override bool ExecuteOrnOperate(OrnOperate ornOperate)
    {
        if (ornOperate == null)
        {
            return true;
        }

        Operate left;
        left = ornOperate.Lite;
        Operate right;
        right = ornOperate.Rite;

        base.ExecuteOrnOperate(ornOperate);

        this.ExecuteTwoOperandOperate(ornOperate, left, right, this.System.Bool, this.System.Bool);
        return true;
    }

    public override bool ExecuteNotOperate(NotOperate notOperate)
    {
        if (notOperate == null)
        {
            return true;
        }

        Operate value;
        value = notOperate.Value;

        base.ExecuteNotOperate(notOperate);

        this.ExecuteOneOperandOperate(notOperate, value, this.System.Bool, this.System.Bool);
        return true;
    }

    public override bool ExecuteLessOperate(LessOperate lessOperate)
    {
        if (lessOperate == null)
        {
            return true;
        }

        Operate left;
        left = lessOperate.Lite;
        Operate right;
        right = lessOperate.Rite;

        base.ExecuteLessOperate(lessOperate);

        this.ExecuteTwoOperandOperate(lessOperate, left, right, this.System.Bool, this.System.Int);
        return true;
    }

    public override bool ExecuteAddOperate(AddOperate addOperate)
    {
        if (addOperate == null)
        {
            return true;
        }

        Operate left;
        left = addOperate.Lite;
        Operate right;
        right = addOperate.Rite;

        base.ExecuteAddOperate(addOperate);

        this.ExecuteTwoOperandOperate(addOperate, left, right, this.System.Int, this.System.Int);
        return true;
    }

    public override bool ExecuteSubOperate(SubOperate subOperate)
    {
        if (subOperate == null)
        {
            return true;
        }

        Operate left;
        left = subOperate.Lite;
        Operate right;
        right = subOperate.Rite;

        base.ExecuteSubOperate(subOperate);

        this.ExecuteTwoOperandOperate(subOperate, left, right, this.System.Int, this.System.Int);
        return true;
    }

    public override bool ExecuteMulOperate(MulOperate mulOperate)
    {
        if (mulOperate == null)
        {
            return true;
        }

        Operate left;
        left = mulOperate.Lite;
        Operate right;
        right = mulOperate.Rite;

        base.ExecuteMulOperate(mulOperate);

        this.ExecuteTwoOperandOperate(mulOperate, left, right, this.System.Int, this.System.Int);
        return true;
    }

    public override bool ExecuteDivOperate(DivOperate divOperate)
    {
        if (divOperate == null)
        {
            return true;
        }

        Operate left;
        left = divOperate.Lite;
        Operate right;
        right = divOperate.Rite;

        base.ExecuteDivOperate(divOperate);
    
        this.ExecuteTwoOperandOperate(divOperate, left, right, this.System.Int, this.System.Int);
        return true;
    }

    public override bool ExecuteSignLessOperate(SignLessOperate signLessOperate)
    {
        if (signLessOperate == null)
        {
            return true;
        }

        Operate left;
        left = signLessOperate.Lite;
        Operate right;
        right = signLessOperate.Rite;

        base.ExecuteSignLessOperate(signLessOperate);

        this.ExecuteTwoOperandOperate(signLessOperate, left, right, this.System.Bool, this.System.Int);
        return true;
    }

    public override bool ExecuteSignMulOperate(SignMulOperate signMulOperate)
    {
        if (signMulOperate == null)
        {
            return true;
        }

        Operate left;
        left = signMulOperate.Lite;
        Operate right;
        right = signMulOperate.Rite;

        base.ExecuteSignMulOperate(signMulOperate);

        this.ExecuteTwoOperandOperate(signMulOperate, left, right, this.System.Int, this.System.Int);
        return true;
    }

    public override bool ExecuteSignDivOperate(SignDivOperate signDivOperate)
    {
        if (signDivOperate == null)
        {
            return true;
        }

        Operate left;
        left = signDivOperate.Lite;
        Operate right;
        right = signDivOperate.Rite;

        base.ExecuteSignDivOperate(signDivOperate);

        this.ExecuteTwoOperandOperate(signDivOperate, left, right, this.System.Int, this.System.Int);
        return true;
    }

    public override bool ExecuteBitAndOperate(BitAndOperate bitAndOperate)
    {
        if (bitAndOperate == null)
        {
            return true;
        }

        Operate left;
        left = bitAndOperate.Lite;
        Operate right;
        right = bitAndOperate.Rite;

        base.ExecuteBitAndOperate(bitAndOperate);

        this.ExecuteTwoOperandOperate(bitAndOperate, left, right, this.System.Int, this.System.Int);
        return true;
    }

    public override bool ExecuteBitOrnOperate(BitOrnOperate bitOrnOperate)
    {
        if (bitOrnOperate == null)
        {
            return true;
        }

        Operate left;
        left = bitOrnOperate.Lite;
        Operate right;
        right = bitOrnOperate.Rite;

        base.ExecuteBitOrnOperate(bitOrnOperate);

        this.ExecuteTwoOperandOperate(bitOrnOperate, left, right, this.System.Int, this.System.Int);
        return true;
    }

    public override bool ExecuteBitNotOperate(BitNotOperate bitNotOperate)
    {
        if (bitNotOperate == null)
        {
            return true;
        }

        Operate value;
        value = bitNotOperate.Value;

        base.ExecuteBitNotOperate(bitNotOperate);

        this.ExecuteOneOperandOperate(bitNotOperate, value, this.System.Int, this.System.Int);
        return true;
    }

    public override bool ExecuteBitLiteOperate(BitLiteOperate bitLiteOperate)
    {
        if (bitLiteOperate == null)
        {
            return true;
        }

        Operate value;
        value = bitLiteOperate.Value;
        Operate count;
        count = bitLiteOperate.Count;

        base.ExecuteBitLiteOperate(bitLiteOperate);

        this.ExecuteTwoOperandOperate(bitLiteOperate, value, count, this.System.Int, this.System.Int);
        return true;
    }

    public override bool ExecuteBitRiteOperate(BitRiteOperate bitRiteOperate)
    {
        if (bitRiteOperate == null)
        {
            return true;
        }

        Operate value;
        value = bitRiteOperate.Value;
        Operate count;
        count = bitRiteOperate.Count;

        base.ExecuteBitRiteOperate(bitRiteOperate);

        this.ExecuteTwoOperandOperate(bitRiteOperate, value, count, this.System.Int, this.System.Int);
        return true;
    }

    public override bool ExecuteBitSignRiteOperate(BitSignRiteOperate bitSignRiteOperate)
    {
        if (bitSignRiteOperate == null)
        {
            return true;
        }

        Operate value;
        value = bitSignRiteOperate.Value;
        Operate count;
        count = bitSignRiteOperate.Count;

        base.ExecuteBitSignRiteOperate(bitSignRiteOperate);

        this.ExecuteTwoOperandOperate(bitSignRiteOperate, value, count, this.System.Int, this.System.Int);
        return true;
    }

    protected virtual bool ExecuteOneOperandOperate(Operate operate, Operate value, ClassClass resultClass, ClassClass operandClass)
    {
        ClassClass valueClass;
        valueClass = null;
        if (!(value == null))
        {
            valueClass = this.Info(value).OperateClass;
            if (valueClass == null)
            {
                this.Error(this.ErrorKind.OperandUndefined, operate);
            }
        }

        if (!(valueClass == null))
        {
            if (!this.ValidClass(valueClass, operandClass))
            {
                this.Error(this.ErrorKind.OperandUnassignable, operate);
            }
        }

        this.Info(operate).OperateClass = resultClass;
        return true;
    }

    protected virtual bool ExecuteTwoOperandOperate(Operate operate, Operate left, Operate right, ClassClass resultClass, ClassClass operandClass)
    {
        bool hasOperandUndefined;
        hasOperandUndefined = false;

        bool hasOperandUnassignable;
        hasOperandUnassignable = false;

        ClassClass leftClass;
        leftClass = null;
        if (!(left == null))
        {
            leftClass = this.Info(left).OperateClass;
            if (leftClass == null)
            {
                hasOperandUndefined = this.UniqueError(this.ErrorKind.OperandUndefined, operate, hasOperandUndefined);
            }
        }

        if (!(leftClass == null))
        {
            if (!this.ValidClass(leftClass, operandClass))
            {
                hasOperandUnassignable = this.UniqueError(this.ErrorKind.OperandUnassignable, operate, hasOperandUnassignable);
            }
        }

        ClassClass rightClass;
        rightClass = null;
        if (!(right == null))
        {
            rightClass = this.Info(right).OperateClass;
            if (rightClass == null)
            {
                hasOperandUndefined = this.UniqueError(this.ErrorKind.OperandUndefined, operate, hasOperandUndefined);
            }
        }

        if (!(rightClass == null))
        {
            if (!this.ValidClass(rightClass, operandClass))
            {
                hasOperandUnassignable = this.UniqueError(this.ErrorKind.OperandUnassignable, operate, hasOperandUnassignable);
            }
        }

        this.Info(operate).OperateClass = resultClass;
        return true;
    }

    protected virtual bool ExecuteCondBodyExecute(Execute execute, Operate cond)
    {
        ClassClass condClass;
        condClass = null;

        if (!(cond == null))
        {
            condClass = this.Info(cond).OperateClass;
            if (condClass == null)
            {
                this.Error(this.ErrorKind.CondUndefined, execute);
            }
        }

        if (!(condClass == null))
        {
            if (!this.ValidClass(condClass, this.System.Bool))
            {
                this.Error(this.ErrorKind.CondUnassignable, execute);
            }
        }
        return true;
    }

    protected virtual bool WordClassOperate(Operate operate, ClassName nodeClass)
    {
        string className;
        className = null;
        if (!(nodeClass == null))
        {
            className = nodeClass.Value;
        }

        ClassClass varClass;
        varClass = null;
        if (!(className == null))
        {
            varClass = this.Class(className);
            if (varClass == null)
            {
                this.Error(this.ErrorKind.ClassUndefined, operate);
            }
        }

        this.Info(operate).OperateClass = varClass;
        return true;
    }

    protected virtual ClassClass ExecuteVarNameNode(NodeNode node, VarName name)
    {
        string varName;
        varName = name.Value;
        
        Var varVar;
        varVar = this.VarStackVar(varName);
        if (varVar == null)
        {
            this.Error(this.ErrorKind.VarUndefined, node);
        }

        ClassClass a;
        a = null;
        if (!(varVar == null))
        {
            a = varVar.Class;
        }

        this.Info(node).Var = varVar;

        return a;
    }

    protected virtual Field ExecuteThisFieldNode(NodeNode node, Operate varThis, FieldName nodeField)
    {
        ClassClass thisClass;
        thisClass = null;
        if (!(varThis == null))
        {
            thisClass = this.Info(varThis).OperateClass;
            if (thisClass == null)
            {
                this.Error(this.ErrorKind.ThisUndefined, node);
            }
        }

        string fieldName;
        fieldName = null;
        if (!(nodeField == null))
        {
            fieldName = nodeField.Value;
        }

        Field field;
        field = null;
        if (!(thisClass == null))
        {
            if (!(fieldName == null))
            {
                field = this.Field(thisClass, fieldName);
                if (field == null)
                {
                    this.Error(this.ErrorKind.FieldUndefined, node);
                }
            }
        }
        return field;
    }

    protected virtual bool ValidClass(ClassClass varClass, ClassClass requiredClass)
    {
        return this.ClassInfra.ValidClass(varClass, requiredClass, this.System.Any, this.NullClass);
    }

    protected virtual Field Field(ClassClass varClass, String name)
    {
        if (varClass == this.NullClass)
        {
            return null;
        }
        
        ClassClass anyClass;
        anyClass = this.System.Any;

        ClassClass thisClass;
        thisClass = varClass;

        Field d;
        d = null;

        bool b;
        b = false;
        while (!b & !(thisClass == null))
        {
            if (!b)
            {
                Field a;
                a = (Field)thisClass.Field.Get(name);
                if (!(a == null))
                {
                    d = a;
                    b = true;
                }
            }

            if (!b & thisClass.Maide.Valid(name))
            {
                b = true;
            }

            if (!b)
            {
                ClassClass aa;
                aa = null;
                if (!(thisClass == anyClass))
                {
                    aa = thisClass.Base;
                }
                thisClass = aa;
            }
        }

        if (d == null)
        {
            return null;
        }

        if (!this.ValidCount(varClass, d.Parent, d.Count))
        {
            return null;
        }

        return d;
    }

    protected virtual Maide Maide(ClassClass varClass, String name)
    {
        if (varClass == this.NullClass)
        {
            return null;
        }

        ClassClass anyClass;
        anyClass = this.System.Any;

        ClassClass thisClass;
        thisClass = varClass;

        Maide d;
        d = null;

        bool b;
        b = false;
        while (!b & !(thisClass == null))
        {
            if (!b)
            {
                Maide a;
                a = (Maide)thisClass.Maide.Get(name);
                if (!(a == null))
                {
                    d = a;
                    b = true;
                }
            }

            if (!b & thisClass.Field.Valid(name))
            {
                b = true;
            }

            if (!b)
            {
                ClassClass aa;
                aa = null;
                if (!(thisClass == anyClass))
                {
                    aa = thisClass.Base;
                }
                thisClass = aa;
            }
        }

        if (d == null)
        {
            return null;
        }

        if (!this.ValidCount(varClass, d.Parent, d.Count))
        {
            return null;
        }

        return d;
    }

    protected virtual bool ValidCount(ClassClass triggerClass, ClassClass varClass, Count count)
    {
        return this.ClassInfra.ValidCount(this.ThisClass, triggerClass, varClass, count, this.System.Any, this.NullClass);
    }

    protected virtual bool ArgueMatch(Maide varMaide, Argue argue)
    {
        int count;
        count = varMaide.Param.Count;

        bool countEqual;
        countEqual = (count == argue.Value.Count);
        if (!countEqual)
        {
            return false;
        }

        Iter paramIter;
        paramIter = this.ParamIter;
        varMaide.Param.IterSet(paramIter);

        Iter argueIter;
        argueIter = this.ArgueIter;
        argue.Value.IterSet(argueIter);

        int i;
        i = 0;
        while (i < count)
        {
            paramIter.Next();
            argueIter.Next();

            Var varVar;
            varVar = (Var)paramIter.Value;

            Operate operate;
            operate = (Operate)argueIter.Value;
            if (operate == null)
            {
                return false;
            }

            ClassClass varClass;
            varClass = varVar.Class;

            ClassClass operateClass;
            operateClass = this.Info(operate).OperateClass;
            if (operateClass == null)
            {
                return false;
            }

            if (!this.ValidClass(operateClass, varClass))
            {
                return false;
            }
            i = i + 1;
        }
        return true;
    }

    protected virtual bool VarTableAdd(Table varTable, Table other)
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;

        Iter iter;
        iter = other.IterCreate();
        other.IterSet(iter);
        while (iter.Next())
        {
            Var a;
            a = (Var)iter.Value;

            listInfra.TableAdd(varTable, a.Name, a);
        }
        return true;
    }

    protected virtual Var VarStackVar(string name)
    {
        Iter iter;
        iter = this.VarStackIter;
        this.VarStack.IterSet(iter);

        while (iter.Next())
        {
            Table varTable;
            varTable = (Table)iter.Value;

            Var varVar;
            varVar = (Var)varTable.Get(name);
            if (!(varVar == null))
            {
                return varVar;
            }
        }
        return null;
    }

    private String S(string o)
    {
        return this.TextStringValue.Execute(o);
    }
}