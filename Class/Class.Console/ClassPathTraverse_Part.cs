namespace Class.Console;

partial class ClassPathTraverse
{
    public override bool ExecuteClass(NodeClass varClass)
    {
        if (varClass == null)
        {
            return true;
        }
        this.ExecuteNode(varClass);

        if (this.HasResult())
        {
            return true;
        }

        if (this.FieldEqual("Name"))
        {
            this.ExecuteClassName(varClass.Name);
            return true;
        }
        if (this.FieldEqual("Base"))
        {
            this.ExecuteClassName(varClass.Base);
            return true;
        }
        if (this.FieldEqual("Part"))
        {
            this.ExecutePart(varClass.Part);
            return true;
        }
        return true;
    }

    public override bool ExecutePart(Part part)
    {
        if (part == null)
        {
            return true;
        }

        int k;
        k = this.Index;

        Array array;
        array = part.Value;
        if (!(this.InfraInfra.ValidIndex(array.Count, k)))
        {
            return true;
        }

        Comp item;
        item = (Comp)array.GetAt(k);
        this.ExecuteComp(item);
        return true;
    }

    public override bool ExecuteField(NodeField varField)
    {
        if (varField == null)
        {
            return true;
        }
        this.ExecuteNode(varField);

        if (this.HasResult())
        {
            return true;
        }

        if (this.FieldEqual("Class"))
        {
            this.ExecuteClassName(varField.Class);
            return true;
        }
        if (this.FieldEqual("Name"))
        {
            this.ExecuteFieldName(varField.Name);
            return true;
        }
        if (this.FieldEqual("Count"))
        {
            this.ExecuteCount(varField.Count);
            return true;
        }
        if (this.FieldEqual("Get"))
        {
            this.ExecuteState(varField.Get);
            return true;
        }
        if (this.FieldEqual("Set"))
        {
            this.ExecuteState(varField.Set);
            return true;
        }
        return true;
    }

    public override bool ExecuteMaide(NodeMaide varMaide)
    {
        if (varMaide == null)
        {
            return true;
        }
        this.ExecuteNode(varMaide);

        if (this.HasResult())
        {
            return true;
        }

        if (this.FieldEqual("Class"))
        {
            this.ExecuteClassName(varMaide.Class);
            return true;
        }
        if (this.FieldEqual("Name"))
        {
            this.ExecuteMaideName(varMaide.Name);
            return true;
        }
        if (this.FieldEqual("Count"))
        {
            this.ExecuteCount(varMaide.Count);
            return true;
        }
        if (this.FieldEqual("Param"))
        {
            this.ExecuteParam(varMaide.Param);
            return true;
        }
        if (this.FieldEqual("Call"))
        {
            this.ExecuteState(varMaide.Call);
            return true;
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
        if (!(this.InfraInfra.ValidIndex(array.Count, k)))
        {
            return true;
        }

        NodeVar item;
        item = (NodeVar)array.GetAt(k);
        this.ExecuteVar(item);
        return true;
    }

    public override bool ExecuteVar(NodeVar varVar)
    {
        if (varVar == null)
        {
            return true;
        }
        this.ExecuteNode(varVar);

        if (this.HasResult())
        {
            return true;
        }

        if (this.FieldEqual("Class"))
        {
            this.ExecuteClassName(varVar.Class);
            return true;
        }
        if (this.FieldEqual("Name"))
        {
            this.ExecuteVarName(varVar.Name);
            return true;
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

        if (this.HasResult())
        {
            return true;
        }
        return true;
    }

    public override bool ExecuteProbateCount(ProbateCount probateCount)
    {
        if (probateCount == null)
        {
            return true;
        }
        this.ExecuteNode(probateCount);

        if (this.HasResult())
        {
            return true;
        }
        return true;
    }

    public override bool ExecutePrecateCount(PrecateCount precateCount)
    {
        if (precateCount == null)
        {
            return true;
        }
        this.ExecuteNode(precateCount);

        if (this.HasResult())
        {
            return true;
        }
        return true;
    }

    public override bool ExecutePrivateCount(PrivateCount privateCount)
    {
        if (privateCount == null)
        {
            return true;
        }
        this.ExecuteNode(privateCount);

        if (this.HasResult())
        {
            return true;
        }
        return true;
    }

    public override bool ExecuteState(State state)
    {
        if (state == null)
        {
            return true;
        }

        int k;
        k = this.Index;

        Array array;
        array = state.Value;
        if (!(this.InfraInfra.ValidIndex(array.Count, k)))
        {
            return true;
        }

        Execute item;
        item = (Execute)array.GetAt(k);
        this.ExecuteExecute(item);
        return true;
    }

    public override bool ExecuteInfExecute(InfExecute infExecute)
    {
        if (infExecute == null)
        {
            return true;
        }
        this.ExecuteNode(infExecute);

        if (this.HasResult())
        {
            return true;
        }

        if (this.FieldEqual("Cond"))
        {
            this.ExecuteOperate(infExecute.Cond);
            return true;
        }
        if (this.FieldEqual("Then"))
        {
            this.ExecuteState(infExecute.Then);
            return true;
        }
        return true;
    }

    public override bool ExecuteWhileExecute(WhileExecute whileExecute)
    {
        if (whileExecute == null)
        {
            return true;
        }
        this.ExecuteNode(whileExecute);

        if (this.HasResult())
        {
            return true;
        }

        if (this.FieldEqual("Cond"))
        {
            this.ExecuteOperate(whileExecute.Cond);
            return true;
        }
        if (this.FieldEqual("Loop"))
        {
            this.ExecuteState(whileExecute.Loop);
            return true;
        }
        return true;
    }

    public override bool ExecuteReturnExecute(ReturnExecute returnExecute)
    {
        if (returnExecute == null)
        {
            return true;
        }
        this.ExecuteNode(returnExecute);

        if (this.HasResult())
        {
            return true;
        }

        if (this.FieldEqual("Result"))
        {
            this.ExecuteOperate(returnExecute.Result);
            return true;
        }
        return true;
    }

    public override bool ExecuteReferExecute(ReferExecute referExecute)
    {
        if (referExecute == null)
        {
            return true;
        }
        this.ExecuteNode(referExecute);

        if (this.HasResult())
        {
            return true;
        }

        if (this.FieldEqual("Var"))
        {
            this.ExecuteVar(referExecute.Var);
            return true;
        }
        return true;
    }

    public override bool ExecuteAreExecute(AreExecute areExecute)
    {
        if (areExecute == null)
        {
            return true;
        }
        this.ExecuteNode(areExecute);

        if (this.HasResult())
        {
            return true;
        }

        if (this.FieldEqual("Target"))
        {
            this.ExecuteTarget(areExecute.Target);
            return true;
        }
        if (this.FieldEqual("Value"))
        {
            this.ExecuteOperate(areExecute.Value);
            return true;
        }
        return true;
    }

    public override bool ExecuteOperateExecute(OperateExecute operateExecute)
    {
        if (operateExecute == null)
        {
            return true;
        }
        this.ExecuteNode(operateExecute);

        if (this.HasResult())
        {
            return true;
        }

        if (this.FieldEqual("Any"))
        {
            this.ExecuteOperate(operateExecute.Any);
            return true;
        }
        return true;
    }

    public override bool ExecuteArgue(Argue argue)
    {
        if (argue == null)
        {
            return true;
        }

        int k;
        k = this.Index;

        Array array;
        array = argue.Value;
        if (!(this.InfraInfra.ValidIndex(array.Count, k)))
        {
            return true;
        }

        Operate item;
        item = (Operate)array.GetAt(k);
        this.ExecuteOperate(item);
        return true;
    }

    public override bool ExecuteVarTarget(VarTarget varTarget)
    {
        if (varTarget == null)
        {
            return true;
        }
        this.ExecuteNode(varTarget);

        if (this.HasResult())
        {
            return true;
        }

        if (this.FieldEqual("Var"))
        {
            this.ExecuteVarName(varTarget.Var);
            return true;
        }
        return true;
    }

    public override bool ExecuteSetTarget(SetTarget setTarget)
    {
        if (setTarget == null)
        {
            return true;
        }
        this.ExecuteNode(setTarget);

        if (this.HasResult())
        {
            return true;
        }

        if (this.FieldEqual("This"))
        {
            this.ExecuteOperate(setTarget.This);
            return true;
        }
        if (this.FieldEqual("Field"))
        {
            this.ExecuteFieldName(setTarget.Field);
            return true;
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

        if (this.HasResult())
        {
            return true;
        }

        if (this.FieldEqual("This"))
        {
            this.ExecuteOperate(getOperate.This);
            return true;
        }
        if (this.FieldEqual("Field"))
        {
            this.ExecuteFieldName(getOperate.Field);
            return true;
        }
        return true;
    }

    public override bool ExecuteCallOperate(CallOperate callOperate)
    {
        if (callOperate == null)
        {
            return true;
        }
        this.ExecuteNode(callOperate);

        if (this.HasResult())
        {
            return true;
        }

        if (this.FieldEqual("This"))
        {
            this.ExecuteOperate(callOperate.This);
            return true;
        }
        if (this.FieldEqual("Maide"))
        {
            this.ExecuteMaideName(callOperate.Maide);
            return true;
        }
        if (this.FieldEqual("Argue"))
        {
            this.ExecuteArgue(callOperate.Argue);
            return true;
        }
        return true;
    }

    public override bool ExecuteThisOperate(ThisOperate thisOperate)
    {
        if (thisOperate == null)
        {
            return true;
        }
        this.ExecuteNode(thisOperate);

        if (this.HasResult())
        {
            return true;
        }
        return true;
    }

    public override bool ExecuteBaseOperate(BaseOperate baseOperate)
    {
        if (baseOperate == null)
        {
            return true;
        }
        this.ExecuteNode(baseOperate);

        if (this.HasResult())
        {
            return true;
        }
        return true;
    }

    public override bool ExecuteNullOperate(NullOperate nullOperate)
    {
        if (nullOperate == null)
        {
            return true;
        }
        this.ExecuteNode(nullOperate);

        if (this.HasResult())
        {
            return true;
        }
        return true;
    }

    public override bool ExecuteNewOperate(NewOperate newOperate)
    {
        if (newOperate == null)
        {
            return true;
        }
        this.ExecuteNode(newOperate);

        if (this.HasResult())
        {
            return true;
        }

        if (this.FieldEqual("Class"))
        {
            this.ExecuteClassName(newOperate.Class);
            return true;
        }
        return true;
    }

    public override bool ExecuteShareOperate(ShareOperate shareOperate)
    {
        if (shareOperate == null)
        {
            return true;
        }
        this.ExecuteNode(shareOperate);

        if (this.HasResult())
        {
            return true;
        }

        if (this.FieldEqual("Class"))
        {
            this.ExecuteClassName(shareOperate.Class);
            return true;
        }
        return true;
    }

    public override bool ExecuteCastOperate(CastOperate castOperate)
    {
        if (castOperate == null)
        {
            return true;
        }
        this.ExecuteNode(castOperate);

        if (this.HasResult())
        {
            return true;
        }

        if (this.FieldEqual("Class"))
        {
            this.ExecuteClassName(castOperate.Class);
            return true;
        }
        if (this.FieldEqual("Any"))
        {
            this.ExecuteOperate(castOperate.Any);
            return true;
        }
        return true;
    }

    public override bool ExecuteVarOperate(VarOperate varOperate)
    {
        if (varOperate == null)
        {
            return true;
        }
        this.ExecuteNode(varOperate);

        if (this.HasResult())
        {
            return true;
        }

        if (this.FieldEqual("Var"))
        {
            this.ExecuteVarName(varOperate.Var);
            return true;
        }
        return true;
    }

    public override bool ExecuteValueOperate(ValueOperate valueOperate)
    {
        if (valueOperate == null)
        {
            return true;
        }
        this.ExecuteNode(valueOperate);

        if (this.HasResult())
        {
            return true;
        }

        if (this.FieldEqual("Value"))
        {
            this.ExecuteValue(valueOperate.Value);
            return true;
        }
        return true;
    }

    public override bool ExecuteBracketOperate(BracketOperate bracketOperate)
    {
        if (bracketOperate == null)
        {
            return true;
        }
        this.ExecuteNode(bracketOperate);

        if (this.HasResult())
        {
            return true;
        }

        if (this.FieldEqual("Any"))
        {
            this.ExecuteOperate(bracketOperate.Any);
            return true;
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

        if (this.HasResult())
        {
            return true;
        }
        return true;
    }

    public override bool ExecuteIntValue(IntValue intValue)
    {
        if (intValue == null)
        {
            return true;
        }
        this.ExecuteNode(intValue);

        if (this.HasResult())
        {
            return true;
        }
        return true;
    }

    public override bool ExecuteIntHexValue(IntHexValue intHexValue)
    {
        if (intHexValue == null)
        {
            return true;
        }
        this.ExecuteNode(intHexValue);

        if (this.HasResult())
        {
            return true;
        }
        return true;
    }

    public override bool ExecuteIntSignValue(IntSignValue intSignValue)
    {
        if (intSignValue == null)
        {
            return true;
        }
        this.ExecuteNode(intSignValue);

        if (this.HasResult())
        {
            return true;
        }
        return true;
    }

    public override bool ExecuteIntHexSignValue(IntHexSignValue intHexSignValue)
    {
        if (intHexSignValue == null)
        {
            return true;
        }
        this.ExecuteNode(intHexSignValue);

        if (this.HasResult())
        {
            return true;
        }
        return true;
    }

    public override bool ExecuteStringValue(StringValue stringValue)
    {
        if (stringValue == null)
        {
            return true;
        }
        this.ExecuteNode(stringValue);

        if (this.HasResult())
        {
            return true;
        }
        return true;
    }

    public override bool ExecuteClassName(ClassName className)
    {
        if (className == null)
        {
            return true;
        }
        this.ExecuteNode(className);

        if (this.HasResult())
        {
            return true;
        }
        return true;
    }

    public override bool ExecuteFieldName(FieldName fieldName)
    {
        if (fieldName == null)
        {
            return true;
        }
        this.ExecuteNode(fieldName);

        if (this.HasResult())
        {
            return true;
        }
        return true;
    }

    public override bool ExecuteMaideName(MaideName maideName)
    {
        if (maideName == null)
        {
            return true;
        }
        this.ExecuteNode(maideName);

        if (this.HasResult())
        {
            return true;
        }
        return true;
    }

    public override bool ExecuteVarName(VarName varName)
    {
        if (varName == null)
        {
            return true;
        }
        this.ExecuteNode(varName);

        if (this.HasResult())
        {
            return true;
        }
        return true;
    }

    public override bool ExecuteEqualOperate(EqualOperate equalOperate)
    {
        if (equalOperate == null)
        {
            return true;
        }
        this.ExecuteNode(equalOperate);

        if (this.HasResult())
        {
            return true;
        }

        if (this.FieldEqual("Left"))
        {
            this.ExecuteOperate(equalOperate.Left);
            return true;
        }
        if (this.FieldEqual("Right"))
        {
            this.ExecuteOperate(equalOperate.Right);
            return true;
        }
        return true;
    }

    public override bool ExecuteAndOperate(AndOperate andOperate)
    {
        if (andOperate == null)
        {
            return true;
        }
        this.ExecuteNode(andOperate);

        if (this.HasResult())
        {
            return true;
        }

        if (this.FieldEqual("Left"))
        {
            this.ExecuteOperate(andOperate.Left);
            return true;
        }
        if (this.FieldEqual("Right"))
        {
            this.ExecuteOperate(andOperate.Right);
            return true;
        }
        return true;
    }

    public override bool ExecuteOrnOperate(OrnOperate ornOperate)
    {
        if (ornOperate == null)
        {
            return true;
        }
        this.ExecuteNode(ornOperate);

        if (this.HasResult())
        {
            return true;
        }

        if (this.FieldEqual("Left"))
        {
            this.ExecuteOperate(ornOperate.Left);
            return true;
        }
        if (this.FieldEqual("Right"))
        {
            this.ExecuteOperate(ornOperate.Right);
            return true;
        }
        return true;
    }

    public override bool ExecuteNotOperate(NotOperate notOperate)
    {
        if (notOperate == null)
        {
            return true;
        }
        this.ExecuteNode(notOperate);

        if (this.HasResult())
        {
            return true;
        }

        if (this.FieldEqual("Value"))
        {
            this.ExecuteOperate(notOperate.Value);
            return true;
        }
        return true;
    }

    public override bool ExecuteAddOperate(AddOperate addOperate)
    {
        if (addOperate == null)
        {
            return true;
        }
        this.ExecuteNode(addOperate);

        if (this.HasResult())
        {
            return true;
        }

        if (this.FieldEqual("Left"))
        {
            this.ExecuteOperate(addOperate.Left);
            return true;
        }
        if (this.FieldEqual("Right"))
        {
            this.ExecuteOperate(addOperate.Right);
            return true;
        }
        return true;
    }

    public override bool ExecuteSubOperate(SubOperate subOperate)
    {
        if (subOperate == null)
        {
            return true;
        }
        this.ExecuteNode(subOperate);

        if (this.HasResult())
        {
            return true;
        }

        if (this.FieldEqual("Left"))
        {
            this.ExecuteOperate(subOperate.Left);
            return true;
        }
        if (this.FieldEqual("Right"))
        {
            this.ExecuteOperate(subOperate.Right);
            return true;
        }
        return true;
    }

    public override bool ExecuteMulOperate(MulOperate mulOperate)
    {
        if (mulOperate == null)
        {
            return true;
        }
        this.ExecuteNode(mulOperate);

        if (this.HasResult())
        {
            return true;
        }

        if (this.FieldEqual("Left"))
        {
            this.ExecuteOperate(mulOperate.Left);
            return true;
        }
        if (this.FieldEqual("Right"))
        {
            this.ExecuteOperate(mulOperate.Right);
            return true;
        }
        return true;
    }

    public override bool ExecuteDivOperate(DivOperate divOperate)
    {
        if (divOperate == null)
        {
            return true;
        }
        this.ExecuteNode(divOperate);

        if (this.HasResult())
        {
            return true;
        }

        if (this.FieldEqual("Left"))
        {
            this.ExecuteOperate(divOperate.Left);
            return true;
        }
        if (this.FieldEqual("Right"))
        {
            this.ExecuteOperate(divOperate.Right);
            return true;
        }
        return true;
    }

    public override bool ExecuteLessOperate(LessOperate lessOperate)
    {
        if (lessOperate == null)
        {
            return true;
        }
        this.ExecuteNode(lessOperate);

        if (this.HasResult())
        {
            return true;
        }

        if (this.FieldEqual("Left"))
        {
            this.ExecuteOperate(lessOperate.Left);
            return true;
        }
        if (this.FieldEqual("Right"))
        {
            this.ExecuteOperate(lessOperate.Right);
            return true;
        }
        return true;
    }

    public override bool ExecuteSignMulOperate(SignMulOperate signMulOperate)
    {
        if (signMulOperate == null)
        {
            return true;
        }
        this.ExecuteNode(signMulOperate);

        if (this.HasResult())
        {
            return true;
        }

        if (this.FieldEqual("Left"))
        {
            this.ExecuteOperate(signMulOperate.Left);
            return true;
        }
        if (this.FieldEqual("Right"))
        {
            this.ExecuteOperate(signMulOperate.Right);
            return true;
        }
        return true;
    }

    public override bool ExecuteSignDivOperate(SignDivOperate signDivOperate)
    {
        if (signDivOperate == null)
        {
            return true;
        }
        this.ExecuteNode(signDivOperate);

        if (this.HasResult())
        {
            return true;
        }

        if (this.FieldEqual("Left"))
        {
            this.ExecuteOperate(signDivOperate.Left);
            return true;
        }
        if (this.FieldEqual("Right"))
        {
            this.ExecuteOperate(signDivOperate.Right);
            return true;
        }
        return true;
    }

    public override bool ExecuteSignLessOperate(SignLessOperate signLessOperate)
    {
        if (signLessOperate == null)
        {
            return true;
        }
        this.ExecuteNode(signLessOperate);

        if (this.HasResult())
        {
            return true;
        }

        if (this.FieldEqual("Left"))
        {
            this.ExecuteOperate(signLessOperate.Left);
            return true;
        }
        if (this.FieldEqual("Right"))
        {
            this.ExecuteOperate(signLessOperate.Right);
            return true;
        }
        return true;
    }

    public override bool ExecuteBitAndOperate(BitAndOperate bitAndOperate)
    {
        if (bitAndOperate == null)
        {
            return true;
        }
        this.ExecuteNode(bitAndOperate);

        if (this.HasResult())
        {
            return true;
        }

        if (this.FieldEqual("Left"))
        {
            this.ExecuteOperate(bitAndOperate.Left);
            return true;
        }
        if (this.FieldEqual("Right"))
        {
            this.ExecuteOperate(bitAndOperate.Right);
            return true;
        }
        return true;
    }

    public override bool ExecuteBitOrnOperate(BitOrnOperate bitOrnOperate)
    {
        if (bitOrnOperate == null)
        {
            return true;
        }
        this.ExecuteNode(bitOrnOperate);

        if (this.HasResult())
        {
            return true;
        }

        if (this.FieldEqual("Left"))
        {
            this.ExecuteOperate(bitOrnOperate.Left);
            return true;
        }
        if (this.FieldEqual("Right"))
        {
            this.ExecuteOperate(bitOrnOperate.Right);
            return true;
        }
        return true;
    }

    public override bool ExecuteBitNotOperate(BitNotOperate bitNotOperate)
    {
        if (bitNotOperate == null)
        {
            return true;
        }
        this.ExecuteNode(bitNotOperate);

        if (this.HasResult())
        {
            return true;
        }

        if (this.FieldEqual("Value"))
        {
            this.ExecuteOperate(bitNotOperate.Value);
            return true;
        }
        return true;
    }

    public override bool ExecuteBitLeftOperate(BitLeftOperate bitLeftOperate)
    {
        if (bitLeftOperate == null)
        {
            return true;
        }
        this.ExecuteNode(bitLeftOperate);

        if (this.HasResult())
        {
            return true;
        }

        if (this.FieldEqual("Value"))
        {
            this.ExecuteOperate(bitLeftOperate.Value);
            return true;
        }
        if (this.FieldEqual("Count"))
        {
            this.ExecuteOperate(bitLeftOperate.Count);
            return true;
        }
        return true;
    }

    public override bool ExecuteBitRightOperate(BitRightOperate bitRightOperate)
    {
        if (bitRightOperate == null)
        {
            return true;
        }
        this.ExecuteNode(bitRightOperate);

        if (this.HasResult())
        {
            return true;
        }

        if (this.FieldEqual("Value"))
        {
            this.ExecuteOperate(bitRightOperate.Value);
            return true;
        }
        if (this.FieldEqual("Count"))
        {
            this.ExecuteOperate(bitRightOperate.Count);
            return true;
        }
        return true;
    }

    public override bool ExecuteBitSignRightOperate(BitSignRightOperate bitSignRightOperate)
    {
        if (bitSignRightOperate == null)
        {
            return true;
        }
        this.ExecuteNode(bitSignRightOperate);

        if (this.HasResult())
        {
            return true;
        }

        if (this.FieldEqual("Value"))
        {
            this.ExecuteOperate(bitSignRightOperate.Value);
            return true;
        }
        if (this.FieldEqual("Count"))
        {
            this.ExecuteOperate(bitSignRightOperate.Count);
            return true;
        }
        return true;
    }

}