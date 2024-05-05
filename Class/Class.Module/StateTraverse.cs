namespace Class.Module;

public class StateTraverse : Traverse
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        this.TextInfra = TextInfra.This;
        this.ClassInfra = ClassInfra.This;

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
        return true;
    }

    protected virtual ListInfra ListInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual SystemClass System { get; set; }
    protected virtual ClassClass NullClass { get; set; }
    protected virtual ClassClass ThisClass { get; set; }
    protected virtual ClassClass ThisResultClass { get; set; }
    protected virtual Table StateVar { get; set; }
    protected virtual Stack VarStack { get; set; }
    protected virtual Iter VarStackIter { get; set; }
    protected virtual Iter ParamIter { get; set; }
    protected virtual Iter ArgueIter { get; set; }

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

    protected virtual bool FieldGet(Field field, State nodeGet)
    {
        if (nodeGet == null)
        {
            return true;
        }

        this.ThisResultClass = field.Class;

        this.StateVar = field.Get;

        Var dataVar;
        dataVar = new Var();
        dataVar.Init();
        dataVar.Name = "data";
        dataVar.Class = field.Class;
        dataVar.SystemInfo = this.CreateSystemInfo();

        Table o;
        o = this.ClassInfra.TableCreateStringCompare();

        this.ListInfra.TableAdd(this.StateVar, dataVar.Name, dataVar);
        this.ListInfra.TableAdd(o, dataVar.Name, dataVar);

        this.VarStack.Push(o);

        this.ExecuteState(nodeGet);

        this.VarStack.Pop();

        this.StateVar = null;
        this.ThisResultClass = null;
        return true;
    }

    protected virtual bool FieldSet(Field field, State nodeSet)
    {
        if (nodeSet == null)
        {
            return true;
        }

        this.ThisResultClass = this.System.Bool;

        this.StateVar = field.Set;

        Var dataVar;
        dataVar = new Var();
        dataVar.Init();
        dataVar.Name = "data";
        dataVar.Class = field.Class;
        dataVar.SystemInfo = this.CreateSystemInfo();

        Var valueVar;
        valueVar = new Var();
        valueVar.Init();
        valueVar.Name = "value";
        valueVar.Class = field.Class;
        valueVar.SystemInfo = this.CreateSystemInfo();
        valueVar.SystemInfo.Value = field.SystemInfo.Value;
        
        Table o;
        o = this.ClassInfra.TableCreateStringCompare();

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

        Table o;
        o = this.ClassInfra.TableCreateStringCompare();

        this.VarTableAdd(o, maide.Param);

        this.StateVar = o;

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

        string varName;
        varName = name.Value;
        string className;
        className = nodeClass.Value;

        if (this.StateVar.Contain(varName))
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
        a.Any = nodeVar;
        a.SystemInfo = this.CreateSystemInfo();

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
        h = this.ClassInfra.TableCreateStringCompare();

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
            if (!this.CheckClass(resultClass, this.ThisResultClass))
            {
                this.Error(this.ErrorKind.ResultUnassignable, returnExecute);
            }
        }
        return true;
    }

    public override bool ExecuteAssignExecute(AssignExecute assignExecute)
    {
        if (assignExecute == null)
        {
            return true;
        }

        Target target;            
        target = assignExecute.Target;
        Operate value;
        value = assignExecute.Value;

        base.ExecuteAssignExecute(assignExecute);

        ClassClass targetClass;
        targetClass = null;
        if (!(target == null))
        {
            targetClass = this.Info(target).TargetClass;
            if (targetClass == null)
            {
                this.Error(this.ErrorKind.TargetUndefined, assignExecute);
            }
        }

        ClassClass valueClass;
        valueClass = null;
        if (!(value == null))
        {
            valueClass = this.Info(value).OperateClass;
            if (valueClass == null)
            {
                this.Error(this.ErrorKind.ValueUndefined, assignExecute);
            }
        }

        if (!(targetClass == null) & !(valueClass == null))
        {
            if (!this.CheckClass(valueClass, targetClass))
            {
                this.Error(this.ErrorKind.ValueUnassignable, assignExecute);
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

    public override bool ExecuteBaseSetTarget(BaseSetTarget baseSetTarget)
    {
        if (baseSetTarget == null)
        {
            return true;
        }

        FieldName nodeField;
        nodeField = baseSetTarget.Field;

        base.ExecuteBaseSetTarget(baseSetTarget);

        Field field;
        field = this.ExecuteBaseFieldNode(baseSetTarget, nodeField);

        ClassClass fieldClass;
        fieldClass = null;
        if (!(field == null))
        {
            fieldClass = field.Class;
        }

        this.Info(baseSetTarget).SetField = field;
        this.Info(baseSetTarget).TargetClass = fieldClass;
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

    public override bool ExecuteBaseGetOperate(BaseGetOperate baseGetOperate)
    {
        if (baseGetOperate == null)
        {
            return true;
        }

        FieldName nodeField;
        nodeField = baseGetOperate.Field;

        base.ExecuteBaseGetOperate(baseGetOperate);

        Field field;
        field = this.ExecuteBaseFieldNode(baseGetOperate, nodeField);

        ClassClass fieldClass;
        fieldClass = null;
        if (!(field == null))
        {
            fieldClass = field.Class;
        }

        this.Info(baseGetOperate).GetField = field;
        this.Info(baseGetOperate).OperateClass = fieldClass;
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

        string maideName;
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
                maide = this.Maide(thisClass, maideName, false);
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

    public override bool ExecuteBaseCallOperate(BaseCallOperate baseCallOperate)
    {
        if (baseCallOperate == null)
        {
            return true;
        }

        MaideName nodeMaide;
        nodeMaide = baseCallOperate.Maide;
        Argue argue;
        argue = baseCallOperate.Argue;

        base.ExecuteBaseCallOperate(baseCallOperate);

        ClassClass baseClass;
        baseClass = this.ThisClass.Base;

        string maideName;
        maideName = null;
        if (!(nodeMaide == null))
        {
            maideName = nodeMaide.Value;
        }

        Maide maide;
        maide = null;

        if (!(maideName == null))
        {
            maide = this.Maide(baseClass, maideName, true);
            if (maide == null)
            {
                this.Error(this.ErrorKind.MaideUndefined, baseCallOperate);
            }
        }

        if (!(maide == null))
        {
            if (!this.ArgueMatch(maide, argue))
            {
                this.Error(this.ErrorKind.ArgueUnassignable, baseCallOperate);
            }
        }

        ClassClass operateClass;
        operateClass = null;
        if (!(maide == null))
        {
            operateClass = maide.Class;
        }

        this.Info(baseCallOperate).CallMaide = maide;
        this.Info(baseCallOperate).OperateClass = operateClass;
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
                this.Error(this.ErrorKind.ClassUndefined, castOperate);
            }
        }

        if (!(anyClass == null))
        {
            if (!(varClass == null))
            {
                if (!this.CheckClass(anyClass, varClass))
                {
                    if (!this.CheckClass(varClass, anyClass))
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

    public override bool ExecuteBracketOperate(BracketOperate bracketOperate)
    {
        if (bracketOperate == null)
        {
            return true;
        }

        Operate any;
        any = bracketOperate.Any;

        base.ExecuteBracketOperate(bracketOperate);

        ClassClass anyClass;
        anyClass = null;
        if (!(any == null))
        {
            anyClass = this.Info(any).OperateClass;
            if (anyClass == null)
            {
                this.Error(this.ErrorKind.AnyUndefined, bracketOperate);
            }
        }

        this.Info(bracketOperate).OperateClass = anyClass;
        return true;
    }

    public override bool ExecuteEqualOperate(EqualOperate equalOperate)
    {
        if (equalOperate == null)
        {
            return true;
        }

        Operate left;
        left = equalOperate.Left;
        Operate right;
        right = equalOperate.Right;

        base.ExecuteEqualOperate(equalOperate);

        bool hasOperandUndefined;
        hasOperandUndefined = false;

        ClassClass leftClass;
        leftClass = null;
        if (!(left == null))
        {
            leftClass = this.Info(left).OperateClass;
            if (leftClass == null)
            {
                hasOperandUndefined = this.UniqueError(this.ErrorKind.OperandUndefined, equalOperate, hasOperandUndefined);
            }
        }

        ClassClass rightClass;
        rightClass = null;
        if (!(right == null))
        {
            rightClass = this.Info(right).OperateClass;
            if (rightClass == null)
            {
                hasOperandUndefined = this.UniqueError(this.ErrorKind.OperandUndefined, equalOperate, hasOperandUndefined);
            }
        }

        bool b;
        b = false;
        if (!(leftClass == null) & !(rightClass == null))
        {
            if (!b)
            {
                int boolCount;
                boolCount = this.ClassEqualCount(leftClass, rightClass, this.System.Bool);
                if (0 < boolCount)
                {
                    b = true;
                    if (boolCount == 1)
                    {
                        this.Error(this.ErrorKind.EqualUnachievable, equalOperate);
                    }
                }
            }
            if (!b)
            {
                int intCount;
                intCount = this.ClassEqualCount(leftClass, rightClass, this.System.Int);
                if (0 < intCount)
                {
                    b = true;
                    if (intCount == 1)
                    {
                        this.Error(this.ErrorKind.EqualUnachievable, equalOperate);
                    }
                }
            }
        }

        this.Info(equalOperate).OperateClass = this.System.Bool;
        return true;
    }

    public override bool ExecuteAndOperate(AndOperate andOperate)
    {
        if (andOperate == null)
        {
            return true;
        }

        Operate left;
        left = andOperate.Left;
        Operate right;
        right = andOperate.Right;

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
        left = ornOperate.Left;
        Operate right;
        right = ornOperate.Right;

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
        left = lessOperate.Left;
        Operate right;
        right = lessOperate.Right;

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
        left = addOperate.Left;
        Operate right;
        right = addOperate.Right;

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
        left = subOperate.Left;
        Operate right;
        right = subOperate.Right;

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
        left = mulOperate.Left;
        Operate right;
        right = mulOperate.Right;

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
        left = divOperate.Left;
        Operate right;
        right = divOperate.Right;

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
        left = signLessOperate.Left;
        Operate right;
        right = signLessOperate.Right;

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
        left = signMulOperate.Left;
        Operate right;
        right = signMulOperate.Right;

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
        left = signDivOperate.Left;
        Operate right;
        right = signDivOperate.Right;

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
        left = bitAndOperate.Left;
        Operate right;
        right = bitAndOperate.Right;

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
        left = bitOrnOperate.Left;
        Operate right;
        right = bitOrnOperate.Right;

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

    public override bool ExecuteBitLeftOperate(BitLeftOperate bitLeftOperate)
    {
        if (bitLeftOperate == null)
        {
            return true;
        }

        Operate value;
        value = bitLeftOperate.Value;
        Operate count;
        count = bitLeftOperate.Count;

        base.ExecuteBitLeftOperate(bitLeftOperate);

        this.ExecuteTwoOperandOperate(bitLeftOperate, value, count, this.System.Int, this.System.Int);
        return true;
    }

    public override bool ExecuteBitRightOperate(BitRightOperate bitRightOperate)
    {
        if (bitRightOperate == null)
        {
            return true;
        }

        Operate value;
        value = bitRightOperate.Value;
        Operate count;
        count = bitRightOperate.Count;

        base.ExecuteBitRightOperate(bitRightOperate);

        this.ExecuteTwoOperandOperate(bitRightOperate, value, count, this.System.Int, this.System.Int);
        return true;
    }

    public override bool ExecuteBitSignRightOperate(BitSignRightOperate bitSignRightOperate)
    {
        if (bitSignRightOperate == null)
        {
            return true;
        }

        Operate value;
        value = bitSignRightOperate.Value;
        Operate count;
        count = bitSignRightOperate.Count;

        base.ExecuteBitSignRightOperate(bitSignRightOperate);

        this.ExecuteTwoOperandOperate(bitSignRightOperate, value, count, this.System.Int, this.System.Int);
        return true;
    }

    protected virtual int ClassEqualCount(ClassClass left, ClassClass right, ClassClass equalClass)
    {
        int a;
        a = 0;
        if (left == equalClass)
        {
            a = a + 1;
        }
        if (right == equalClass)
        {
            a = a + 1;
        }
        return a;
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
            if (!this.CheckClass(valueClass, operandClass))
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
            if (!this.CheckClass(leftClass, operandClass))
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
            if (!this.CheckClass(rightClass, operandClass))
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
            if (!this.CheckClass(condClass, this.System.Bool))
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
                field = this.Field(thisClass, fieldName, false);
                if (field == null)
                {
                    this.Error(this.ErrorKind.FieldUndefined, node);
                }
            }
        }
        return field;
    }

    protected virtual Field ExecuteBaseFieldNode(NodeNode node, FieldName nodeField)
    {
        ClassClass baseClass;
        baseClass = this.ThisClass.Base;

        string fieldName;
        fieldName = null;
        if (!(nodeField == null))
        {
            fieldName = nodeField.Value;
        }

        Field field;
        field = null;
        if (!(fieldName == null))
        {
            field = this.Field(baseClass, fieldName, true);
            if (field == null)
            {
                this.Error(this.ErrorKind.FieldUndefined, node);
            }
        }
        return field;
    }

    protected virtual bool CheckClass(ClassClass varClass, ClassClass requiredClass)
    {
        return this.Create.CheckClass(varClass, requiredClass);
    }

    protected virtual Field Field(ClassClass varClass, string name, bool baseTrigger)
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

            if (!b & thisClass.Maide.Contain(name))
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

        if (!this.CheckCount(varClass, d.Parent, d.Count, baseTrigger))
        {
            return null;
        }

        return d;
    }

    protected virtual Maide Maide(ClassClass varClass, string name, bool baseTrigger)
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

            if (!b & thisClass.Field.Contain(name))
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

        if (!this.CheckCount(varClass, d.Parent, d.Count, baseTrigger))
        {
            return null;
        }

        return d;
    }

    protected virtual bool CheckCount(ClassClass triggerClass, ClassClass varClass, Count count, bool baseTrigger)
    {
        if (count == this.Count.Prudate)
        {
            return true;
        }

        if (count == this.Count.Probate)
        {
            if (this.Module == varClass.Module)
            {
                return true;
            }
            return false;
        }

        if (count == this.Count.Precate)
        {
            if (baseTrigger)
            {
                return true;
            }
            if (this.ThisClass == triggerClass)
            {
                return true;
            }
            return false;
        }

        if (count == this.Count.Private)
        {
            if (triggerClass == varClass)
            {
                if (this.ThisClass == triggerClass)
                {
                    return true;
                }
            }
            return false;
        }
        return true;
    }

    protected virtual bool ArgueMatch(Maide maide, Argue argue)
    {
        int count;
        count = maide.Param.Count;

        bool countEqual;
        countEqual = (count == argue.Value.Count);
        if (!countEqual)
        {
            return false;
        }

        Iter paramIter;
        paramIter = this.ParamIter;
        maide.Param.IterSet(paramIter);

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

            if (!this.CheckClass(operateClass, varClass))
            {
                return false;
            }
            i = i + 1;
        }
        return true;
    }

    protected virtual bool VarTableAdd(Table varTable, Table other)
    {
        Iter iter;
        iter = other.IterCreate();
        other.IterSet(iter);
        while (iter.Next())
        {
            Var a;
            a = (Var)iter.Value;

            this.ListInfra.TableAdd(varTable, a.Name, a);
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

    protected virtual SystemInfo CreateSystemInfo()
    {
        SystemInfo a;
        a = new SystemInfo();
        a.Init();
        return a;
    }
}