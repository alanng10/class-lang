namespace Saber.Node;

public class Travel : TextAdd
{
    public virtual bool ExecuteClass(Class varClass)
    {
        if (varClass == null)
        {
            return true;
        }
        this.ExecuteNode(varClass);

        this.ExecuteClassName(varClass.Name);
        this.ExecuteClassName(varClass.Base);
        this.ExecutePart(varClass.Part);
        return true;
    }

    public virtual bool ExecutePart(Part part)
    {
        if (part == null)
        {
            return true;
        }
        this.ExecuteNode(part);

        long count;
        count = part.Value.Count;
        long i;
        i = 0;
        while (i < count)
        {
            Comp item;
            item = part.Value.GetAt(i) as Comp;
            this.ExecuteComp(item);

            i = i + 1;
        }
        return true;
    }

    public virtual bool ExecuteComp(Comp comp)
    {
        if (comp == null)
        {
            return true;
        }

        if (comp is Field)
        {
            this.ExecuteField((Field)comp);
        }
        if (comp is Maide)
        {
            this.ExecuteMaide((Maide)comp);
        }
        return true;
    }

    public virtual bool ExecuteField(Field varField)
    {
        if (varField == null)
        {
            return true;
        }
        this.ExecuteNode(varField);

        this.ExecuteClassName(varField.Class);
        this.ExecuteFieldName(varField.Name);
        this.ExecuteCount(varField.Count);
        this.ExecuteState(varField.Get);
        this.ExecuteState(varField.Set);
        return true;
    }

    public virtual bool ExecuteMaide(Maide varMaide)
    {
        if (varMaide == null)
        {
            return true;
        }
        this.ExecuteNode(varMaide);

        this.ExecuteClassName(varMaide.Class);
        this.ExecuteMaideName(varMaide.Name);
        this.ExecuteCount(varMaide.Count);
        this.ExecuteParam(varMaide.Param);
        this.ExecuteState(varMaide.Call);
        return true;
    }

    public virtual bool ExecuteParam(Param param)
    {
        if (param == null)
        {
            return true;
        }
        this.ExecuteNode(param);

        long count;
        count = param.Value.Count;
        long i;
        i = 0;
        while (i < count)
        {
            Var item;
            item = param.Value.GetAt(i) as Var;
            this.ExecuteVar(item);

            i = i + 1;
        }
        return true;
    }

    public virtual bool ExecuteVar(Var varVar)
    {
        if (varVar == null)
        {
            return true;
        }
        this.ExecuteNode(varVar);

        this.ExecuteClassName(varVar.Class);
        this.ExecuteVarName(varVar.Name);
        return true;
    }

    public virtual bool ExecuteCount(Count count)
    {
        if (count == null)
        {
            return true;
        }

        if (count is PrusateCount)
        {
            this.ExecutePrusateCount((PrusateCount)count);
        }
        if (count is PrecateCount)
        {
            this.ExecutePrecateCount((PrecateCount)count);
        }
        if (count is PronateCount)
        {
            this.ExecutePronateCount((PronateCount)count);
        }
        if (count is PrivateCount)
        {
            this.ExecutePrivateCount((PrivateCount)count);
        }
        return true;
    }

    public virtual bool ExecutePrusateCount(PrusateCount prusateCount)
    {
        if (prusateCount == null)
        {
            return true;
        }
        this.ExecuteNode(prusateCount);
        return true;
    }

    public virtual bool ExecutePrecateCount(PrecateCount precateCount)
    {
        if (precateCount == null)
        {
            return true;
        }
        this.ExecuteNode(precateCount);
        return true;
    }

    public virtual bool ExecutePronateCount(PronateCount pronateCount)
    {
        if (pronateCount == null)
        {
            return true;
        }
        this.ExecuteNode(pronateCount);
        return true;
    }

    public virtual bool ExecutePrivateCount(PrivateCount privateCount)
    {
        if (privateCount == null)
        {
            return true;
        }
        this.ExecuteNode(privateCount);
        return true;
    }

    public virtual bool ExecuteState(State state)
    {
        if (state == null)
        {
            return true;
        }
        this.ExecuteNode(state);

        long count;
        count = state.Value.Count;
        long i;
        i = 0;
        while (i < count)
        {
            Execute item;
            item = state.Value.GetAt(i) as Execute;
            this.ExecuteExecute(item);

            i = i + 1;
        }
        return true;
    }

    public virtual bool ExecuteExecute(Execute execute)
    {
        if (execute == null)
        {
            return true;
        }

        if (execute is InfExecute)
        {
            this.ExecuteInfExecute((InfExecute)execute);
        }
        if (execute is WhileExecute)
        {
            this.ExecuteWhileExecute((WhileExecute)execute);
        }
        if (execute is ReturnExecute)
        {
            this.ExecuteReturnExecute((ReturnExecute)execute);
        }
        if (execute is ReferExecute)
        {
            this.ExecuteReferExecute((ReferExecute)execute);
        }
        if (execute is AreExecute)
        {
            this.ExecuteAreExecute((AreExecute)execute);
        }
        if (execute is OperateExecute)
        {
            this.ExecuteOperateExecute((OperateExecute)execute);
        }
        return true;
    }

    public virtual bool ExecuteInfExecute(InfExecute infExecute)
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

    public virtual bool ExecuteWhileExecute(WhileExecute whileExecute)
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

    public virtual bool ExecuteReturnExecute(ReturnExecute returnExecute)
    {
        if (returnExecute == null)
        {
            return true;
        }
        this.ExecuteNode(returnExecute);

        this.ExecuteOperate(returnExecute.Result);
        return true;
    }

    public virtual bool ExecuteReferExecute(ReferExecute referExecute)
    {
        if (referExecute == null)
        {
            return true;
        }
        this.ExecuteNode(referExecute);

        this.ExecuteVar(referExecute.Var);
        return true;
    }

    public virtual bool ExecuteAreExecute(AreExecute areExecute)
    {
        if (areExecute == null)
        {
            return true;
        }
        this.ExecuteNode(areExecute);

        this.ExecuteMark(areExecute.Mark);
        this.ExecuteOperate(areExecute.Value);
        return true;
    }

    public virtual bool ExecuteOperateExecute(OperateExecute operateExecute)
    {
        if (operateExecute == null)
        {
            return true;
        }
        this.ExecuteNode(operateExecute);

        this.ExecuteOperate(operateExecute.Any);
        return true;
    }

    public virtual bool ExecuteArgue(Argue argue)
    {
        if (argue == null)
        {
            return true;
        }
        this.ExecuteNode(argue);

        long count;
        count = argue.Value.Count;
        long i;
        i = 0;
        while (i < count)
        {
            Operate item;
            item = argue.Value.GetAt(i) as Operate;
            this.ExecuteOperate(item);

            i = i + 1;
        }
        return true;
    }

    public virtual bool ExecuteMark(Mark mark)
    {
        if (mark == null)
        {
            return true;
        }

        if (mark is VarMark)
        {
            this.ExecuteVarMark((VarMark)mark);
        }
        if (mark is SetMark)
        {
            this.ExecuteSetMark((SetMark)mark);
        }
        return true;
    }

    public virtual bool ExecuteVarMark(VarMark varMark)
    {
        if (varMark == null)
        {
            return true;
        }
        this.ExecuteNode(varMark);

        this.ExecuteVarName(varMark.Var);
        return true;
    }

    public virtual bool ExecuteSetMark(SetMark setMark)
    {
        if (setMark == null)
        {
            return true;
        }
        this.ExecuteNode(setMark);

        this.ExecuteOperate(setMark.This);
        this.ExecuteFieldName(setMark.Field);
        return true;
    }

    public virtual bool ExecuteOperate(Operate operate)
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
        if (operate is ThisOperate)
        {
            this.ExecuteThisOperate((ThisOperate)operate);
        }
        if (operate is BaseOperate)
        {
            this.ExecuteBaseOperate((BaseOperate)operate);
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
        if (operate is VarOperate)
        {
            this.ExecuteVarOperate((VarOperate)operate);
        }
        if (operate is ValueOperate)
        {
            this.ExecuteValueOperate((ValueOperate)operate);
        }
        if (operate is BraceOperate)
        {
            this.ExecuteBraceOperate((BraceOperate)operate);
        }
        if (operate is SameOperate)
        {
            this.ExecuteSameOperate((SameOperate)operate);
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
        if (operate is SignMulOperate)
        {
            this.ExecuteSignMulOperate((SignMulOperate)operate);
        }
        if (operate is SignDivOperate)
        {
            this.ExecuteSignDivOperate((SignDivOperate)operate);
        }
        if (operate is SignLessOperate)
        {
            this.ExecuteSignLessOperate((SignLessOperate)operate);
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
        if (operate is BitLiteOperate)
        {
            this.ExecuteBitLiteOperate((BitLiteOperate)operate);
        }
        if (operate is BitRiteOperate)
        {
            this.ExecuteBitRiteOperate((BitRiteOperate)operate);
        }
        if (operate is BitSignRiteOperate)
        {
            this.ExecuteBitSignRiteOperate((BitSignRiteOperate)operate);
        }
        return true;
    }

    public virtual bool ExecuteGetOperate(GetOperate getOperate)
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

    public virtual bool ExecuteCallOperate(CallOperate callOperate)
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

    public virtual bool ExecuteThisOperate(ThisOperate thisOperate)
    {
        if (thisOperate == null)
        {
            return true;
        }
        this.ExecuteNode(thisOperate);
        return true;
    }

    public virtual bool ExecuteBaseOperate(BaseOperate baseOperate)
    {
        if (baseOperate == null)
        {
            return true;
        }
        this.ExecuteNode(baseOperate);
        return true;
    }

    public virtual bool ExecuteNullOperate(NullOperate nullOperate)
    {
        if (nullOperate == null)
        {
            return true;
        }
        this.ExecuteNode(nullOperate);
        return true;
    }

    public virtual bool ExecuteNewOperate(NewOperate newOperate)
    {
        if (newOperate == null)
        {
            return true;
        }
        this.ExecuteNode(newOperate);

        this.ExecuteClassName(newOperate.Class);
        return true;
    }

    public virtual bool ExecuteShareOperate(ShareOperate shareOperate)
    {
        if (shareOperate == null)
        {
            return true;
        }
        this.ExecuteNode(shareOperate);

        this.ExecuteClassName(shareOperate.Class);
        return true;
    }

    public virtual bool ExecuteCastOperate(CastOperate castOperate)
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

    public virtual bool ExecuteVarOperate(VarOperate varOperate)
    {
        if (varOperate == null)
        {
            return true;
        }
        this.ExecuteNode(varOperate);

        this.ExecuteVarName(varOperate.Var);
        return true;
    }

    public virtual bool ExecuteValueOperate(ValueOperate valueOperate)
    {
        if (valueOperate == null)
        {
            return true;
        }
        this.ExecuteNode(valueOperate);

        this.ExecuteValue(valueOperate.Value);
        return true;
    }

    public virtual bool ExecuteBraceOperate(BraceOperate braceOperate)
    {
        if (braceOperate == null)
        {
            return true;
        }
        this.ExecuteNode(braceOperate);

        this.ExecuteOperate(braceOperate.Any);
        return true;
    }

    public virtual bool ExecuteValue(Value value)
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

    public virtual bool ExecuteBoolValue(BoolValue boolValue)
    {
        if (boolValue == null)
        {
            return true;
        }
        this.ExecuteNode(boolValue);
        return true;
    }

    public virtual bool ExecuteIntValue(IntValue intValue)
    {
        if (intValue == null)
        {
            return true;
        }
        this.ExecuteNode(intValue);
        return true;
    }

    public virtual bool ExecuteIntSignValue(IntSignValue intSignValue)
    {
        if (intSignValue == null)
        {
            return true;
        }
        this.ExecuteNode(intSignValue);
        return true;
    }

    public virtual bool ExecuteIntHexValue(IntHexValue intHexValue)
    {
        if (intHexValue == null)
        {
            return true;
        }
        this.ExecuteNode(intHexValue);
        return true;
    }

    public virtual bool ExecuteIntHexSignValue(IntHexSignValue intHexSignValue)
    {
        if (intHexSignValue == null)
        {
            return true;
        }
        this.ExecuteNode(intHexSignValue);
        return true;
    }

    public virtual bool ExecuteStringValue(StringValue stringValue)
    {
        if (stringValue == null)
        {
            return true;
        }
        this.ExecuteNode(stringValue);
        return true;
    }

    public virtual bool ExecuteClassName(ClassName className)
    {
        if (className == null)
        {
            return true;
        }
        this.ExecuteNode(className);
        return true;
    }

    public virtual bool ExecuteFieldName(FieldName fieldName)
    {
        if (fieldName == null)
        {
            return true;
        }
        this.ExecuteNode(fieldName);
        return true;
    }

    public virtual bool ExecuteMaideName(MaideName maideName)
    {
        if (maideName == null)
        {
            return true;
        }
        this.ExecuteNode(maideName);
        return true;
    }

    public virtual bool ExecuteVarName(VarName varName)
    {
        if (varName == null)
        {
            return true;
        }
        this.ExecuteNode(varName);
        return true;
    }

    public virtual bool ExecuteSameOperate(SameOperate sameOperate)
    {
        if (sameOperate == null)
        {
            return true;
        }
        this.ExecuteNode(sameOperate);

        this.ExecuteOperate(sameOperate.Lite);
        this.ExecuteOperate(sameOperate.Rite);
        return true;
    }

    public virtual bool ExecuteAndOperate(AndOperate andOperate)
    {
        if (andOperate == null)
        {
            return true;
        }
        this.ExecuteNode(andOperate);

        this.ExecuteOperate(andOperate.Lite);
        this.ExecuteOperate(andOperate.Rite);
        return true;
    }

    public virtual bool ExecuteOrnOperate(OrnOperate ornOperate)
    {
        if (ornOperate == null)
        {
            return true;
        }
        this.ExecuteNode(ornOperate);

        this.ExecuteOperate(ornOperate.Lite);
        this.ExecuteOperate(ornOperate.Rite);
        return true;
    }

    public virtual bool ExecuteNotOperate(NotOperate notOperate)
    {
        if (notOperate == null)
        {
            return true;
        }
        this.ExecuteNode(notOperate);

        this.ExecuteOperate(notOperate.Value);
        return true;
    }

    public virtual bool ExecuteLessOperate(LessOperate lessOperate)
    {
        if (lessOperate == null)
        {
            return true;
        }
        this.ExecuteNode(lessOperate);

        this.ExecuteOperate(lessOperate.Lite);
        this.ExecuteOperate(lessOperate.Rite);
        return true;
    }

    public virtual bool ExecuteAddOperate(AddOperate addOperate)
    {
        if (addOperate == null)
        {
            return true;
        }
        this.ExecuteNode(addOperate);

        this.ExecuteOperate(addOperate.Lite);
        this.ExecuteOperate(addOperate.Rite);
        return true;
    }

    public virtual bool ExecuteSubOperate(SubOperate subOperate)
    {
        if (subOperate == null)
        {
            return true;
        }
        this.ExecuteNode(subOperate);

        this.ExecuteOperate(subOperate.Lite);
        this.ExecuteOperate(subOperate.Rite);
        return true;
    }

    public virtual bool ExecuteMulOperate(MulOperate mulOperate)
    {
        if (mulOperate == null)
        {
            return true;
        }
        this.ExecuteNode(mulOperate);

        this.ExecuteOperate(mulOperate.Lite);
        this.ExecuteOperate(mulOperate.Rite);
        return true;
    }

    public virtual bool ExecuteDivOperate(DivOperate divOperate)
    {
        if (divOperate == null)
        {
            return true;
        }
        this.ExecuteNode(divOperate);

        this.ExecuteOperate(divOperate.Lite);
        this.ExecuteOperate(divOperate.Rite);
        return true;
    }

    public virtual bool ExecuteSignMulOperate(SignMulOperate signMulOperate)
    {
        if (signMulOperate == null)
        {
            return true;
        }
        this.ExecuteNode(signMulOperate);

        this.ExecuteOperate(signMulOperate.Lite);
        this.ExecuteOperate(signMulOperate.Rite);
        return true;
    }

    public virtual bool ExecuteSignDivOperate(SignDivOperate signDivOperate)
    {
        if (signDivOperate == null)
        {
            return true;
        }
        this.ExecuteNode(signDivOperate);

        this.ExecuteOperate(signDivOperate.Lite);
        this.ExecuteOperate(signDivOperate.Rite);
        return true;
    }

    public virtual bool ExecuteSignLessOperate(SignLessOperate signLessOperate)
    {
        if (signLessOperate == null)
        {
            return true;
        }
        this.ExecuteNode(signLessOperate);

        this.ExecuteOperate(signLessOperate.Lite);
        this.ExecuteOperate(signLessOperate.Rite);
        return true;
    }

    public virtual bool ExecuteBitAndOperate(BitAndOperate bitAndOperate)
    {
        if (bitAndOperate == null)
        {
            return true;
        }
        this.ExecuteNode(bitAndOperate);

        this.ExecuteOperate(bitAndOperate.Lite);
        this.ExecuteOperate(bitAndOperate.Rite);
        return true;
    }

    public virtual bool ExecuteBitOrnOperate(BitOrnOperate bitOrnOperate)
    {
        if (bitOrnOperate == null)
        {
            return true;
        }
        this.ExecuteNode(bitOrnOperate);

        this.ExecuteOperate(bitOrnOperate.Lite);
        this.ExecuteOperate(bitOrnOperate.Rite);
        return true;
    }

    public virtual bool ExecuteBitNotOperate(BitNotOperate bitNotOperate)
    {
        if (bitNotOperate == null)
        {
            return true;
        }
        this.ExecuteNode(bitNotOperate);

        this.ExecuteOperate(bitNotOperate.Value);
        return true;
    }

    public virtual bool ExecuteBitLiteOperate(BitLiteOperate bitLiteOperate)
    {
        if (bitLiteOperate == null)
        {
            return true;
        }
        this.ExecuteNode(bitLiteOperate);

        this.ExecuteOperate(bitLiteOperate.Value);
        this.ExecuteOperate(bitLiteOperate.Count);
        return true;
    }

    public virtual bool ExecuteBitRiteOperate(BitRiteOperate bitRiteOperate)
    {
        if (bitRiteOperate == null)
        {
            return true;
        }
        this.ExecuteNode(bitRiteOperate);

        this.ExecuteOperate(bitRiteOperate.Value);
        this.ExecuteOperate(bitRiteOperate.Count);
        return true;
    }

    public virtual bool ExecuteBitSignRiteOperate(BitSignRiteOperate bitSignRiteOperate)
    {
        if (bitSignRiteOperate == null)
        {
            return true;
        }
        this.ExecuteNode(bitSignRiteOperate);

        this.ExecuteOperate(bitSignRiteOperate.Value);
        this.ExecuteOperate(bitSignRiteOperate.Count);
        return true;
    }

    protected virtual bool ExecuteNode(Node node)
    {
        return true;
    }
}