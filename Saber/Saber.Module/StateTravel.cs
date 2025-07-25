namespace Saber.Module;

public class StateTravel : Travel
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        this.ClassInfra = ClassInfra.This;

        this.System = this.Create.System;
        this.NullClass = this.Create.NullClass;

        this.VarStack = this.CreateVarStack();
        this.VarStackIter = this.CreateVarStackIter();
        this.ParamIter = this.CreateParamIter();
        this.ArgueIter = this.CreateArgueIter();

        this.SData = this.S("data");
        this.SValue = this.S("value");
        return true;
    }

    protected virtual Stack CreateVarStack()
    {
        Stack a;
        a = new Stack();
        a.Init();
        return a;
    }

    protected virtual Iter CreateVarStackIter()
    {
        Iter a;
        a = new Iter();
        a.Init();
        return a;
    }

    protected virtual TableIter CreateParamIter()
    {
        TableIter a;
        a = new TableIter();
        a.Init();
        return a;
    }

    protected virtual ArrayIter CreateArgueIter()
    {
        ArrayIter a;
        a = new ArrayIter();
        a.Init();
        return a;
    }

    protected virtual ListInfra ListInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual System System { get; set; }
    protected virtual Class NullClass { get; set; }
    protected virtual Class ThisClass { get; set; }
    protected virtual Class ThisResultClass { get; set; }
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

        this.ThisClass = null;

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

        Field varField;
        varField = this.Info(nodeField).Field;
        if (varField == null)
        {
            return true;
        }

        this.FieldGet(varField, nodeGet);
        this.FieldSet(varField, nodeSet);
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

        this.ListInfra.TableAdd(this.StateVar, dataVar.Name, dataVar);

        Table k;
        k = this.ClassInfra.TableCreateStringLess();

        this.ListInfra.TableAdd(k, dataVar.Name, dataVar);

        this.VarStack.Push(k);

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

        this.ListInfra.TableAdd(this.StateVar, dataVar.Name, dataVar);

        Var valueVar;
        valueVar = new Var();
        valueVar.Init();
        valueVar.Name = this.SValue;
        valueVar.Class = varField.Class;
        valueVar.Index = this.StateVar.Count;

        this.ListInfra.TableAdd(this.StateVar, valueVar.Name, valueVar);

        Table k;
        k = this.ClassInfra.TableCreateStringLess();

        this.ListInfra.TableAdd(k, dataVar.Name, dataVar);
        this.ListInfra.TableAdd(k, valueVar.Name, valueVar);

        this.VarStack.Push(k);

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

        Maide varMaide;
        varMaide = this.Info(nodeMaide).Maide;
        if (varMaide == null)
        {
            return true;
        }

        this.ThisResultClass = varMaide.Class;

        this.StateVar = varMaide.Call;

        this.VarTableAdd(this.StateVar, varMaide.Param);

        this.VarStack.Push(varMaide.Param);

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
        varName = null;
        if (!(name == null))
        {
            varName = name.Value;
        }

        String className;
        className = null;
        if (!(nodeClass == null))
        {
            className = nodeClass.Value;
        }

        if (!(varName == null))
        {
            if (this.StateVar.Valid(varName))
            {
                this.Error(this.ErrorKind.NameUnavail, nodeVar);
                return true;
            }
        }

        Class varClass;
        varClass = null;

        if (!(className == null))
        {
            varClass = this.Class(className);
            if (varClass == null)
            {
                this.Error(this.ErrorKind.ClassUndefine, nodeVar);
                return true;
            }
        }

        Var a;
        a = new Var();
        a.Init();
        a.Name = varName;
        a.Class = varClass;
        a.Index = this.StateVar.Count;
        a.Any = nodeVar;

        Table k;
        k = this.VarStack.Top as Table;

        this.ListInfra.TableAdd(k, a.Name, a);
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

        Table k;
        k = this.ClassInfra.TableCreateStringLess();

        this.VarStack.Push(k);

        base.ExecuteState(state);

        this.VarStack.Pop();

        this.Info(state).StateVar = k;

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

        Class resultClass;
        resultClass = null;
        if (!(result == null))
        {
            resultClass = this.Info(result).OperateClass;
            if (resultClass == null)
            {
                this.Error(this.ErrorKind.ResultUndefine, returnExecute);
            }
        }

        if (!(resultClass == null))
        {
            if (!this.ValidClass(resultClass, this.ThisResultClass))
            {
                this.Error(this.ErrorKind.ResultUnassign, returnExecute);
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

        Mark mark;
        mark = areExecute.Mark;
        Operate value;
        value = areExecute.Value;

        base.ExecuteAreExecute(areExecute);

        Class markClass;
        markClass = null;
        if (!(mark == null))
        {
            markClass = this.Info(mark).MarkClass;
            if (markClass == null)
            {
                this.Error(this.ErrorKind.MarkUndefine, areExecute);
            }
        }

        Class valueClass;
        valueClass = null;
        if (!(value == null))
        {
            valueClass = this.Info(value).OperateClass;
            if (valueClass == null)
            {
                this.Error(this.ErrorKind.ValueUndefine, areExecute);
            }
        }

        if (!(markClass == null) & !(valueClass == null))
        {
            if (!this.ValidClass(valueClass, markClass))
            {
                this.Error(this.ErrorKind.ValueUnassign, areExecute);
            }
        }
        return true;
    }

    public override bool ExecuteVarMark(VarMark varMark)
    {
        if (varMark == null)
        {
            return true;
        }

        VarName name;
        name = varMark.Var;

        Class varClass;
        varClass = this.ExecuteVarNameNode(varMark, name);

        this.Info(varMark).MarkClass = varClass;
        return true;
    }

    public override bool ExecuteSetMark(SetMark setMark)
    {
        if (setMark == null)
        {
            return true;
        }

        Operate varThis;
        varThis = setMark.This;
        FieldName nodeField;
        nodeField = setMark.Field;

        base.ExecuteSetMark(setMark);

        Field varField;
        varField = this.ExecuteThisFieldNode(setMark, varThis, nodeField);

        Class fieldClass;
        fieldClass = null;
        if (!(varField == null))
        {
            fieldClass = varField.Class;
        }

        this.Info(setMark).SetField = varField;
        this.Info(setMark).MarkClass = fieldClass;
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

        Field varField;
        varField = this.ExecuteThisFieldNode(getOperate, varThis, nodeField);

        Class fieldClass;
        fieldClass = null;
        if (!(varField == null))
        {
            fieldClass = varField.Class;
        }

        this.Info(getOperate).GetField = varField;
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

        Class thisClass;
        thisClass = null;
        if (!(varThis == null))
        {
            thisClass = this.Info(varThis).OperateClass;
            if (thisClass == null)
            {
                this.Error(this.ErrorKind.ThisUndefine, callOperate);
            }
        }

        String maideName;
        maideName = null;
        if (!(nodeMaide == null))
        {
            maideName = nodeMaide.Value;
        }

        Maide varMaide;
        varMaide = null;

        if (!(thisClass == null))
        {
            if (!(maideName == null))
            {
                varMaide = this.Maide(thisClass, maideName);
                if (varMaide == null)
                {
                    this.Error(this.ErrorKind.MaideUndefine, callOperate);
                }
            }
        }

        if (!(varMaide == null))
        {
            if (!this.ValidArgue(varMaide, argue))
            {
                this.Error(this.ErrorKind.ArgueUnassign, callOperate);
            }
        }

        Class operateClass;
        operateClass = null;
        if (!(varMaide == null))
        {
            operateClass = varMaide.Class;
        }

        this.Info(callOperate).CallMaide = varMaide;
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

        this.ExecuteWordClassOperate(newOperate, nodeClass);
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

        this.ExecuteWordClassOperate(shareOperate, nodeClass);
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

        Class anyClass;
        anyClass = null;
        if (!(any == null))
        {
            anyClass = this.Info(any).OperateClass;
            if (anyClass == null)
            {
                this.Error(this.ErrorKind.AnyUndefine, castOperate);
            }
        }

        String className;
        className = null;
        if (!(nodeClass == null))
        {
            className = nodeClass.Value;
        }

        Class varClass;
        varClass = null;
        if (!(className == null))
        {
            varClass = this.Class(className);
            if (varClass == null)
            {
                this.Error(this.ErrorKind.ClassUndefine, castOperate);
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
                        this.Error(this.ErrorKind.CastUnachieve, castOperate);
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

        Class varClass;
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

        Class valueClass;
        valueClass = null;

        if (!((value as BoolValue) == null))
        {
            valueClass = this.System.Bool;
        }
        if (!((value as IntValue) == null) | !((value as IntSignValue) == null) | !((value as IntHexValue) == null) | !((value as IntHexSignValue) == null))
        {
            valueClass = this.System.Int;
        }
        if (!((value as StringValue) == null))
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

        Class anyClass;
        anyClass = null;
        if (!(any == null))
        {
            anyClass = this.Info(any).OperateClass;
            if (anyClass == null)
            {
                this.Error(this.ErrorKind.AnyUndefine, braceOperate);
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

        Operate lite;
        lite = andOperate.Lite;
        Operate rite;
        rite = andOperate.Rite;

        base.ExecuteAndOperate(andOperate);

        this.ExecuteTwoOperandOperate(andOperate, lite, rite, this.System.Bool, this.System.Bool);
        return true;
    }

    public override bool ExecuteOrnOperate(OrnOperate ornOperate)
    {
        if (ornOperate == null)
        {
            return true;
        }

        Operate lite;
        lite = ornOperate.Lite;
        Operate rite;
        rite = ornOperate.Rite;

        base.ExecuteOrnOperate(ornOperate);

        this.ExecuteTwoOperandOperate(ornOperate, lite, rite, this.System.Bool, this.System.Bool);
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

        Operate lite;
        lite = lessOperate.Lite;
        Operate rite;
        rite = lessOperate.Rite;

        base.ExecuteLessOperate(lessOperate);

        this.ExecuteTwoOperandOperate(lessOperate, lite, rite, this.System.Bool, this.System.Int);
        return true;
    }

    public override bool ExecuteAddOperate(AddOperate addOperate)
    {
        if (addOperate == null)
        {
            return true;
        }

        Operate lite;
        lite = addOperate.Lite;
        Operate rite;
        rite = addOperate.Rite;

        base.ExecuteAddOperate(addOperate);

        this.ExecuteTwoOperandOperate(addOperate, lite, rite, this.System.Int, this.System.Int);
        return true;
    }

    public override bool ExecuteSubOperate(SubOperate subOperate)
    {
        if (subOperate == null)
        {
            return true;
        }

        Operate lite;
        lite = subOperate.Lite;
        Operate rite;
        rite = subOperate.Rite;

        base.ExecuteSubOperate(subOperate);

        this.ExecuteTwoOperandOperate(subOperate, lite, rite, this.System.Int, this.System.Int);
        return true;
    }

    public override bool ExecuteMulOperate(MulOperate mulOperate)
    {
        if (mulOperate == null)
        {
            return true;
        }

        Operate lite;
        lite = mulOperate.Lite;
        Operate rite;
        rite = mulOperate.Rite;

        base.ExecuteMulOperate(mulOperate);

        this.ExecuteTwoOperandOperate(mulOperate, lite, rite, this.System.Int, this.System.Int);
        return true;
    }

    public override bool ExecuteDivOperate(DivOperate divOperate)
    {
        if (divOperate == null)
        {
            return true;
        }

        Operate lite;
        lite = divOperate.Lite;
        Operate rite;
        rite = divOperate.Rite;

        base.ExecuteDivOperate(divOperate);

        this.ExecuteTwoOperandOperate(divOperate, lite, rite, this.System.Int, this.System.Int);
        return true;
    }

    public override bool ExecuteSignLessOperate(SignLessOperate signLessOperate)
    {
        if (signLessOperate == null)
        {
            return true;
        }

        Operate lite;
        lite = signLessOperate.Lite;
        Operate rite;
        rite = signLessOperate.Rite;

        base.ExecuteSignLessOperate(signLessOperate);

        this.ExecuteTwoOperandOperate(signLessOperate, lite, rite, this.System.Bool, this.System.Int);
        return true;
    }

    public override bool ExecuteSignMulOperate(SignMulOperate signMulOperate)
    {
        if (signMulOperate == null)
        {
            return true;
        }

        Operate lite;
        lite = signMulOperate.Lite;
        Operate rite;
        rite = signMulOperate.Rite;

        base.ExecuteSignMulOperate(signMulOperate);

        this.ExecuteTwoOperandOperate(signMulOperate, lite, rite, this.System.Int, this.System.Int);
        return true;
    }

    public override bool ExecuteSignDivOperate(SignDivOperate signDivOperate)
    {
        if (signDivOperate == null)
        {
            return true;
        }

        Operate lite;
        lite = signDivOperate.Lite;
        Operate rite;
        rite = signDivOperate.Rite;

        base.ExecuteSignDivOperate(signDivOperate);

        this.ExecuteTwoOperandOperate(signDivOperate, lite, rite, this.System.Int, this.System.Int);
        return true;
    }

    public override bool ExecuteBitAndOperate(BitAndOperate bitAndOperate)
    {
        if (bitAndOperate == null)
        {
            return true;
        }

        Operate lite;
        lite = bitAndOperate.Lite;
        Operate rite;
        rite = bitAndOperate.Rite;

        base.ExecuteBitAndOperate(bitAndOperate);

        this.ExecuteTwoOperandOperate(bitAndOperate, lite, rite, this.System.Int, this.System.Int);
        return true;
    }

    public override bool ExecuteBitOrnOperate(BitOrnOperate bitOrnOperate)
    {
        if (bitOrnOperate == null)
        {
            return true;
        }

        Operate lite;
        lite = bitOrnOperate.Lite;
        Operate rite;
        rite = bitOrnOperate.Rite;

        base.ExecuteBitOrnOperate(bitOrnOperate);

        this.ExecuteTwoOperandOperate(bitOrnOperate, lite, rite, this.System.Int, this.System.Int);
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

    protected virtual bool ExecuteOneOperandOperate(Operate operate, Operate value, Class resultClass, Class operandClass)
    {
        Class valueClass;
        valueClass = null;
        if (!(value == null))
        {
            valueClass = this.Info(value).OperateClass;
            if (valueClass == null)
            {
                this.Error(this.ErrorKind.OperandUndefine, operate);
            }
        }

        if (!(valueClass == null))
        {
            if (!this.ValidClass(valueClass, operandClass))
            {
                this.Error(this.ErrorKind.OperandUnassign, operate);
            }
        }

        this.Info(operate).OperateClass = resultClass;
        return true;
    }

    protected virtual bool ExecuteTwoOperandOperate(Operate operate, Operate lite, Operate rite, Class resultClass, Class operandClass)
    {
        bool operandUndefine;
        operandUndefine = false;

        bool operandUnassign;
        operandUnassign = false;

        Class liteClass;
        liteClass = null;
        if (!(lite == null))
        {
            liteClass = this.Info(lite).OperateClass;
            if (liteClass == null)
            {
                operandUndefine = this.ErrorUnique(this.ErrorKind.OperandUndefine, operate, operandUndefine);
            }
        }

        if (!(liteClass == null))
        {
            if (!this.ValidClass(liteClass, operandClass))
            {
                operandUnassign = this.ErrorUnique(this.ErrorKind.OperandUnassign, operate, operandUnassign);
            }
        }

        Class riteClass;
        riteClass = null;
        if (!(rite == null))
        {
            riteClass = this.Info(rite).OperateClass;
            if (riteClass == null)
            {
                operandUndefine = this.ErrorUnique(this.ErrorKind.OperandUndefine, operate, operandUndefine);
            }
        }

        if (!(riteClass == null))
        {
            if (!this.ValidClass(riteClass, operandClass))
            {
                operandUnassign = this.ErrorUnique(this.ErrorKind.OperandUnassign, operate, operandUnassign);
            }
        }

        this.Info(operate).OperateClass = resultClass;
        return true;
    }

    protected virtual bool ExecuteCondBodyExecute(Execute execute, Operate cond)
    {
        Class condClass;
        condClass = null;
        if (!(cond == null))
        {
            condClass = this.Info(cond).OperateClass;
            if (condClass == null)
            {
                this.Error(this.ErrorKind.CondUndefine, execute);
            }
        }

        if (!(condClass == null))
        {
            if (!this.ValidClass(condClass, this.System.Bool))
            {
                this.Error(this.ErrorKind.CondUnassign, execute);
            }
        }
        return true;
    }

    protected virtual bool ExecuteWordClassOperate(Operate operate, ClassName nodeClass)
    {
        String className;
        className = null;
        if (!(nodeClass == null))
        {
            className = nodeClass.Value;
        }

        Class varClass;
        varClass = null;
        if (!(className == null))
        {
            varClass = this.Class(className);
            if (varClass == null)
            {
                this.Error(this.ErrorKind.ClassUndefine, operate);
            }
        }

        this.Info(operate).OperateClass = varClass;
        return true;
    }

    protected virtual Class ExecuteVarNameNode(NodeNode node, VarName name)
    {
        String varName;
        varName = name.Value;

        Var varVar;
        varVar = this.VarStackVar(varName);
        if (varVar == null)
        {
            this.Error(this.ErrorKind.VarUndefine, node);
        }

        Class a;
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
        Class thisClass;
        thisClass = null;
        if (!(varThis == null))
        {
            thisClass = this.Info(varThis).OperateClass;
            if (thisClass == null)
            {
                this.Error(this.ErrorKind.ThisUndefine, node);
            }
        }

        String fieldName;
        fieldName = null;
        if (!(nodeField == null))
        {
            fieldName = nodeField.Value;
        }

        Field varField;
        varField = null;
        if (!(thisClass == null))
        {
            if (!(fieldName == null))
            {
                varField = this.Field(thisClass, fieldName);
                if (varField == null)
                {
                    this.Error(this.ErrorKind.FieldUndefine, node);
                }
            }
        }
        return varField;
    }

    protected virtual Field Field(Class varClass, String name)
    {
        return this.ClassInfra.FieldTrigg(varClass, name, this.ThisClass, this.System.Any, this.NullClass);
    }

    protected virtual Maide Maide(Class varClass, String name)
    {
        return this.ClassInfra.MaideTrigg(varClass, name, this.ThisClass, this.System.Any, this.NullClass);
    }

    protected virtual bool ValidClass(Class varClass, Class requireClass)
    {
        return this.ClassInfra.ValidClass(varClass, requireClass, this.System.Any, this.NullClass);
    }

    protected virtual bool ValidArgue(Maide varMaide, Argue argue)
    {
        long count;
        count = varMaide.Param.Count;

        bool countSame;
        countSame = (count == argue.Value.Count);
        if (!countSame)
        {
            return false;
        }

        Iter paramIter;
        paramIter = this.ParamIter;
        varMaide.Param.IterSet(paramIter);

        Iter argueIter;
        argueIter = this.ArgueIter;
        argue.Value.IterSet(argueIter);

        bool b;
        b = false;

        long i;
        i = 0;
        while (!b & i < count)
        {
            paramIter.Next();
            argueIter.Next();

            Var varVar;
            varVar = null;
            Operate operate;
            operate = null;

            if (!b)
            {
                varVar = paramIter.Value as Var;

                operate = argueIter.Value as Operate;
                if (operate == null)
                {
                    b = true;
                }
            }

            Class varClass;
            varClass = null;
            Class operateClass;
            operateClass = null;

            if (!b)
            {
                varClass = varVar.Class;

                operateClass = this.Info(operate).OperateClass;
                if (operateClass == null)
                {
                    b = true;
                }
            }

            if (!b)
            {
                if (!this.ValidClass(operateClass, varClass))
                {
                    b = true;
                }
            }
            i = i + 1;
        }

        paramIter.Clear();

        argueIter.Clear();

        bool ret;
        ret = !b;
        return ret;
    }

    protected virtual bool VarTableAdd(Table varTable, Table other)
    {
        Iter iter;
        iter = other.IterCreate();
        other.IterSet(iter);
        while (iter.Next())
        {
            Var a;
            a = iter.Value as Var;

            this.ListInfra.TableAdd(varTable, a.Name, a);
        }
        return true;
    }

    protected virtual Var VarStackVar(String name)
    {
        Iter iter;
        iter = this.VarStackIter;
        this.VarStack.IterSet(iter);

        Var ret;
        ret = null;

        bool b;
        b = false;

        while (!b & iter.Next())
        {
            Table varTable;
            varTable = iter.Value as Table;

            Var varVar;
            varVar = varTable.Get(name) as Var;
            if (!(varVar == null))
            {
                ret = varVar;
                b = true;
            }
        }

        iter.Clear();

        return ret;
    }
}