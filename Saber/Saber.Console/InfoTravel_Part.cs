namespace Saber.Console;

partial class InfoTravel
{
    public virtual bool InitString()
    {
        this.SFieldName = this.S("Name");
        this.SFieldBase = this.S("Base");
        this.SFieldPart = this.S("Part");
        this.SFieldValue = this.S("Value");
        this.SFieldClass = this.S("Class");
        this.SFieldCount = this.S("Count");
        this.SFieldGet = this.S("Get");
        this.SFieldSet = this.S("Set");
        this.SFieldParam = this.S("Param");
        this.SFieldCall = this.S("Call");
        this.SFieldCond = this.S("Cond");
        this.SFieldThen = this.S("Then");
        this.SFieldLoop = this.S("Loop");
        this.SFieldResult = this.S("Result");
        this.SFieldVar = this.S("Var");
        this.SFieldMark = this.S("Mark");
        this.SFieldAny = this.S("Any");
        this.SFieldThis = this.S("This");
        this.SFieldField = this.S("Field");
        this.SFieldMaide = this.S("Maide");
        this.SFieldArgue = this.S("Argue");
        this.SFieldLite = this.S("Lite");
        this.SFieldRite = this.S("Rite");
        return true;
    }

    protected virtual String SFieldName { get; set; }
    protected virtual String SFieldBase { get; set; }
    protected virtual String SFieldPart { get; set; }
    protected virtual String SFieldValue { get; set; }
    protected virtual String SFieldClass { get; set; }
    protected virtual String SFieldCount { get; set; }
    protected virtual String SFieldGet { get; set; }
    protected virtual String SFieldSet { get; set; }
    protected virtual String SFieldParam { get; set; }
    protected virtual String SFieldCall { get; set; }
    protected virtual String SFieldCond { get; set; }
    protected virtual String SFieldThen { get; set; }
    protected virtual String SFieldLoop { get; set; }
    protected virtual String SFieldResult { get; set; }
    protected virtual String SFieldVar { get; set; }
    protected virtual String SFieldMark { get; set; }
    protected virtual String SFieldAny { get; set; }
    protected virtual String SFieldThis { get; set; }
    protected virtual String SFieldField { get; set; }
    protected virtual String SFieldMaide { get; set; }
    protected virtual String SFieldArgue { get; set; }
    protected virtual String SFieldLite { get; set; }
    protected virtual String SFieldRite { get; set; }

    public virtual String Execute(NodeNode node)
    {
        this.AddClear();

        if (node == null)
        {
            this.Null();
            return this.AddResult();
        }

        bool b;
        b = false;

        if (!b)
        {
            if (!((node as NodeClass) == null))
            {
                this.ExecuteClass(node as NodeClass);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as Part) == null))
            {
                this.ExecutePart(node as Part);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as NodeField) == null))
            {
                this.ExecuteField(node as NodeField);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as NodeMaide) == null))
            {
                this.ExecuteMaide(node as NodeMaide);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as Param) == null))
            {
                this.ExecuteParam(node as Param);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as NodeVar) == null))
            {
                this.ExecuteVar(node as NodeVar);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as PrusateCount) == null))
            {
                this.ExecutePrusateCount(node as PrusateCount);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as PrecateCount) == null))
            {
                this.ExecutePrecateCount(node as PrecateCount);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as PronateCount) == null))
            {
                this.ExecutePronateCount(node as PronateCount);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as PrivateCount) == null))
            {
                this.ExecutePrivateCount(node as PrivateCount);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as State) == null))
            {
                this.ExecuteState(node as State);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as InfExecute) == null))
            {
                this.ExecuteInfExecute(node as InfExecute);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as WhileExecute) == null))
            {
                this.ExecuteWhileExecute(node as WhileExecute);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as ReturnExecute) == null))
            {
                this.ExecuteReturnExecute(node as ReturnExecute);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as ReferExecute) == null))
            {
                this.ExecuteReferExecute(node as ReferExecute);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as AreExecute) == null))
            {
                this.ExecuteAreExecute(node as AreExecute);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as OperateExecute) == null))
            {
                this.ExecuteOperateExecute(node as OperateExecute);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as Argue) == null))
            {
                this.ExecuteArgue(node as Argue);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as VarMark) == null))
            {
                this.ExecuteVarMark(node as VarMark);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as SetMark) == null))
            {
                this.ExecuteSetMark(node as SetMark);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as GetOperate) == null))
            {
                this.ExecuteGetOperate(node as GetOperate);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as CallOperate) == null))
            {
                this.ExecuteCallOperate(node as CallOperate);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as ThisOperate) == null))
            {
                this.ExecuteThisOperate(node as ThisOperate);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as BaseOperate) == null))
            {
                this.ExecuteBaseOperate(node as BaseOperate);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as NullOperate) == null))
            {
                this.ExecuteNullOperate(node as NullOperate);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as NewOperate) == null))
            {
                this.ExecuteNewOperate(node as NewOperate);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as ShareOperate) == null))
            {
                this.ExecuteShareOperate(node as ShareOperate);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as CastOperate) == null))
            {
                this.ExecuteCastOperate(node as CastOperate);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as VarOperate) == null))
            {
                this.ExecuteVarOperate(node as VarOperate);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as ValueOperate) == null))
            {
                this.ExecuteValueOperate(node as ValueOperate);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as BraceOperate) == null))
            {
                this.ExecuteBraceOperate(node as BraceOperate);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as BoolValue) == null))
            {
                this.ExecuteBoolValue(node as BoolValue);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as IntValue) == null))
            {
                this.ExecuteIntValue(node as IntValue);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as IntSignValue) == null))
            {
                this.ExecuteIntSignValue(node as IntSignValue);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as IntHexValue) == null))
            {
                this.ExecuteIntHexValue(node as IntHexValue);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as IntHexSignValue) == null))
            {
                this.ExecuteIntHexSignValue(node as IntHexSignValue);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as StringValue) == null))
            {
                this.ExecuteStringValue(node as StringValue);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as ClassName) == null))
            {
                this.ExecuteClassName(node as ClassName);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as FieldName) == null))
            {
                this.ExecuteFieldName(node as FieldName);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as MaideName) == null))
            {
                this.ExecuteMaideName(node as MaideName);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as VarName) == null))
            {
                this.ExecuteVarName(node as VarName);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as SameOperate) == null))
            {
                this.ExecuteSameOperate(node as SameOperate);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as AndOperate) == null))
            {
                this.ExecuteAndOperate(node as AndOperate);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as OrnOperate) == null))
            {
                this.ExecuteOrnOperate(node as OrnOperate);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as NotOperate) == null))
            {
                this.ExecuteNotOperate(node as NotOperate);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as LessOperate) == null))
            {
                this.ExecuteLessOperate(node as LessOperate);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as AddOperate) == null))
            {
                this.ExecuteAddOperate(node as AddOperate);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as SubOperate) == null))
            {
                this.ExecuteSubOperate(node as SubOperate);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as MulOperate) == null))
            {
                this.ExecuteMulOperate(node as MulOperate);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as DivOperate) == null))
            {
                this.ExecuteDivOperate(node as DivOperate);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as SignMulOperate) == null))
            {
                this.ExecuteSignMulOperate(node as SignMulOperate);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as SignDivOperate) == null))
            {
                this.ExecuteSignDivOperate(node as SignDivOperate);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as SignLessOperate) == null))
            {
                this.ExecuteSignLessOperate(node as SignLessOperate);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as BitAndOperate) == null))
            {
                this.ExecuteBitAndOperate(node as BitAndOperate);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as BitOrnOperate) == null))
            {
                this.ExecuteBitOrnOperate(node as BitOrnOperate);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as BitNotOperate) == null))
            {
                this.ExecuteBitNotOperate(node as BitNotOperate);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as BitLiteOperate) == null))
            {
                this.ExecuteBitLiteOperate(node as BitLiteOperate);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as BitRiteOperate) == null))
            {
                this.ExecuteBitRiteOperate(node as BitRiteOperate);
                b = true;
            }
        }
        if (!b)
        {
            if (!((node as BitSignRiteOperate) == null))
            {
                this.ExecuteBitSignRiteOperate(node as BitSignRiteOperate);
                b = true;
            }
        }

        String a;
        a = this.AddResult();
        return a;
    }

    public override bool ExecuteClass(NodeClass varClass)
    {
        if (varClass == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(varClass);

        this.Start("Class");

        this.FieldStart(this.SFieldName);
        this.ExecuteClassName(varClass.Name);
        this.FieldEnd(this.SFieldName);
        this.FieldStart(this.SFieldBase);
        this.ExecuteClassName(varClass.Base);
        this.FieldEnd(this.SFieldBase);
        this.FieldStart(this.SFieldPart);
        this.ExecutePart(varClass.Part);
        this.FieldEnd(this.SFieldPart);

        this.End();
        return true;
    }

    public override bool ExecutePart(Part part)
    {
        if (part == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(part);

        this.Start(Part);

        this.FieldStart(this.SValue);
        
        this.StartArray();

        long count;
        count = part.Value.Count;
        long i;
        i = 0;
        while (i < count)
        {
            this.AddSpace();

            Comp item;
            item = part.Value.GetAt(i) as Comp;
            this.ExecuteComp(item);

            i = i + 1;
        }

        this.EndArray();

        this.FieldEnd(this.SValue);

        this.End();
        return true;
    }

    public override bool ExecuteComp(Comp comp)
    {
        if (comp == null)
        {
            this.Null();
            return true;
        }

        base.ExecuteComp(comp);
        return true;
    }

    public override bool ExecuteField(NodeField varField)
    {
        if (varField == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(varField);

        this.Start("Field");

        this.FieldStart(this.SFieldClass);
        this.ExecuteClassName(varField.Class);
        this.FieldEnd(this.SFieldClass);
        this.FieldStart(this.SFieldName);
        this.ExecuteFieldName(varField.Name);
        this.FieldEnd(this.SFieldName);
        this.FieldStart(this.SFieldCount);
        this.ExecuteCount(varField.Count);
        this.FieldEnd(this.SFieldCount);
        this.FieldStart(this.SFieldGet);
        this.ExecuteState(varField.Get);
        this.FieldEnd(this.SFieldGet);
        this.FieldStart(this.SFieldSet);
        this.ExecuteState(varField.Set);
        this.FieldEnd(this.SFieldSet);

        this.End();
        return true;
    }

    public override bool ExecuteMaide(NodeMaide varMaide)
    {
        if (varMaide == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(varMaide);

        this.Start("Maide");

        this.FieldStart(this.SFieldClass);
        this.ExecuteClassName(varMaide.Class);
        this.FieldEnd(this.SFieldClass);
        this.FieldStart(this.SFieldName);
        this.ExecuteMaideName(varMaide.Name);
        this.FieldEnd(this.SFieldName);
        this.FieldStart(this.SFieldCount);
        this.ExecuteCount(varMaide.Count);
        this.FieldEnd(this.SFieldCount);
        this.FieldStart(this.SFieldParam);
        this.ExecuteParam(varMaide.Param);
        this.FieldEnd(this.SFieldParam);
        this.FieldStart(this.SFieldCall);
        this.ExecuteState(varMaide.Call);
        this.FieldEnd(this.SFieldCall);

        this.End();
        return true;
    }

    public override bool ExecuteParam(Param param)
    {
        if (param == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(param);

        this.Start(Param);

        this.FieldStart(this.SValue);
        
        this.StartArray();

        long count;
        count = param.Value.Count;
        long i;
        i = 0;
        while (i < count)
        {
            this.AddSpace();

            NodeVar item;
            item = param.Value.GetAt(i) as NodeVar;
            this.ExecuteVar(item);

            i = i + 1;
        }

        this.EndArray();

        this.FieldEnd(this.SValue);

        this.End();
        return true;
    }

    public override bool ExecuteVar(NodeVar varVar)
    {
        if (varVar == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(varVar);

        this.Start("Var");

        this.FieldStart(this.SFieldClass);
        this.ExecuteClassName(varVar.Class);
        this.FieldEnd(this.SFieldClass);
        this.FieldStart(this.SFieldName);
        this.ExecuteVarName(varVar.Name);
        this.FieldEnd(this.SFieldName);

        this.End();
        return true;
    }

    public override bool ExecuteCount(NodeCount count)
    {
        if (count == null)
        {
            this.Null();
            return true;
        }

        base.ExecuteCount(count);
        return true;
    }

    public override bool ExecutePrusateCount(PrusateCount prusateCount)
    {
        if (prusateCount == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(prusateCount);

        this.Start("PrusateCount");

        this.End();
        return true;
    }

    public override bool ExecutePrecateCount(PrecateCount precateCount)
    {
        if (precateCount == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(precateCount);

        this.Start("PrecateCount");

        this.End();
        return true;
    }

    public override bool ExecutePronateCount(PronateCount pronateCount)
    {
        if (pronateCount == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(pronateCount);

        this.Start("PronateCount");

        this.End();
        return true;
    }

    public override bool ExecutePrivateCount(PrivateCount privateCount)
    {
        if (privateCount == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(privateCount);

        this.Start("PrivateCount");

        this.End();
        return true;
    }

    public override bool ExecuteState(State state)
    {
        if (state == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(state);

        this.Start(State);

        this.FieldStart(this.SValue);
        
        this.StartArray();

        long count;
        count = state.Value.Count;
        long i;
        i = 0;
        while (i < count)
        {
            this.AddSpace();

            Execute item;
            item = state.Value.GetAt(i) as Execute;
            this.ExecuteExecute(item);

            i = i + 1;
        }

        this.EndArray();

        this.FieldEnd(this.SValue);

        this.End();
        return true;
    }

    public override bool ExecuteExecute(Execute execute)
    {
        if (execute == null)
        {
            this.Null();
            return true;
        }

        base.ExecuteExecute(execute);
        return true;
    }

    public override bool ExecuteInfExecute(InfExecute infExecute)
    {
        if (infExecute == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(infExecute);

        this.Start("InfExecute");

        this.FieldStart(this.SFieldCond);
        this.ExecuteOperate(infExecute.Cond);
        this.FieldEnd(this.SFieldCond);
        this.FieldStart(this.SFieldThen);
        this.ExecuteState(infExecute.Then);
        this.FieldEnd(this.SFieldThen);

        this.End();
        return true;
    }

    public override bool ExecuteWhileExecute(WhileExecute whileExecute)
    {
        if (whileExecute == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(whileExecute);

        this.Start("WhileExecute");

        this.FieldStart(this.SFieldCond);
        this.ExecuteOperate(whileExecute.Cond);
        this.FieldEnd(this.SFieldCond);
        this.FieldStart(this.SFieldLoop);
        this.ExecuteState(whileExecute.Loop);
        this.FieldEnd(this.SFieldLoop);

        this.End();
        return true;
    }

    public override bool ExecuteReturnExecute(ReturnExecute returnExecute)
    {
        if (returnExecute == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(returnExecute);

        this.Start("ReturnExecute");

        this.FieldStart(this.SFieldResult);
        this.ExecuteOperate(returnExecute.Result);
        this.FieldEnd(this.SFieldResult);

        this.End();
        return true;
    }

    public override bool ExecuteReferExecute(ReferExecute referExecute)
    {
        if (referExecute == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(referExecute);

        this.Start("ReferExecute");

        this.FieldStart(this.SFieldVar);
        this.ExecuteVar(referExecute.Var);
        this.FieldEnd(this.SFieldVar);

        this.End();
        return true;
    }

    public override bool ExecuteAreExecute(AreExecute areExecute)
    {
        if (areExecute == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(areExecute);

        this.Start("AreExecute");

        this.FieldStart(this.SFieldMark);
        this.ExecuteMark(areExecute.Mark);
        this.FieldEnd(this.SFieldMark);
        this.FieldStart(this.SFieldValue);
        this.ExecuteOperate(areExecute.Value);
        this.FieldEnd(this.SFieldValue);

        this.End();
        return true;
    }

    public override bool ExecuteOperateExecute(OperateExecute operateExecute)
    {
        if (operateExecute == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(operateExecute);

        this.Start("OperateExecute");

        this.FieldStart(this.SFieldAny);
        this.ExecuteOperate(operateExecute.Any);
        this.FieldEnd(this.SFieldAny);

        this.End();
        return true;
    }

    public override bool ExecuteArgue(Argue argue)
    {
        if (argue == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(argue);

        this.Start(Argue);

        this.FieldStart(this.SValue);
        
        this.StartArray();

        long count;
        count = argue.Value.Count;
        long i;
        i = 0;
        while (i < count)
        {
            this.AddSpace();

            Operate item;
            item = argue.Value.GetAt(i) as Operate;
            this.ExecuteOperate(item);

            i = i + 1;
        }

        this.EndArray();

        this.FieldEnd(this.SValue);

        this.End();
        return true;
    }

    public override bool ExecuteMark(Mark mark)
    {
        if (mark == null)
        {
            this.Null();
            return true;
        }

        base.ExecuteMark(mark);
        return true;
    }

    public override bool ExecuteVarMark(VarMark varMark)
    {
        if (varMark == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(varMark);

        this.Start("VarMark");

        this.FieldStart(this.SFieldVar);
        this.ExecuteVarName(varMark.Var);
        this.FieldEnd(this.SFieldVar);

        this.End();
        return true;
    }

    public override bool ExecuteSetMark(SetMark setMark)
    {
        if (setMark == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(setMark);

        this.Start("SetMark");

        this.FieldStart(this.SFieldThis);
        this.ExecuteOperate(setMark.This);
        this.FieldEnd(this.SFieldThis);
        this.FieldStart(this.SFieldField);
        this.ExecuteFieldName(setMark.Field);
        this.FieldEnd(this.SFieldField);

        this.End();
        return true;
    }

    public override bool ExecuteOperate(Operate operate)
    {
        if (operate == null)
        {
            this.Null();
            return true;
        }

        base.ExecuteOperate(operate);
        return true;
    }

    public override bool ExecuteGetOperate(GetOperate getOperate)
    {
        if (getOperate == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(getOperate);

        this.Start("GetOperate");

        this.FieldStart(this.SFieldThis);
        this.ExecuteOperate(getOperate.This);
        this.FieldEnd(this.SFieldThis);
        this.FieldStart(this.SFieldField);
        this.ExecuteFieldName(getOperate.Field);
        this.FieldEnd(this.SFieldField);

        this.End();
        return true;
    }

    public override bool ExecuteCallOperate(CallOperate callOperate)
    {
        if (callOperate == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(callOperate);

        this.Start("CallOperate");

        this.FieldStart(this.SFieldThis);
        this.ExecuteOperate(callOperate.This);
        this.FieldEnd(this.SFieldThis);
        this.FieldStart(this.SFieldMaide);
        this.ExecuteMaideName(callOperate.Maide);
        this.FieldEnd(this.SFieldMaide);
        this.FieldStart(this.SFieldArgue);
        this.ExecuteArgue(callOperate.Argue);
        this.FieldEnd(this.SFieldArgue);

        this.End();
        return true;
    }

    public override bool ExecuteThisOperate(ThisOperate thisOperate)
    {
        if (thisOperate == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(thisOperate);

        this.Start("ThisOperate");

        this.End();
        return true;
    }

    public override bool ExecuteBaseOperate(BaseOperate baseOperate)
    {
        if (baseOperate == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(baseOperate);

        this.Start("BaseOperate");

        this.End();
        return true;
    }

    public override bool ExecuteNullOperate(NullOperate nullOperate)
    {
        if (nullOperate == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(nullOperate);

        this.Start("NullOperate");

        this.End();
        return true;
    }

    public override bool ExecuteNewOperate(NewOperate newOperate)
    {
        if (newOperate == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(newOperate);

        this.Start("NewOperate");

        this.FieldStart(this.SFieldClass);
        this.ExecuteClassName(newOperate.Class);
        this.FieldEnd(this.SFieldClass);

        this.End();
        return true;
    }

    public override bool ExecuteShareOperate(ShareOperate shareOperate)
    {
        if (shareOperate == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(shareOperate);

        this.Start("ShareOperate");

        this.FieldStart(this.SFieldClass);
        this.ExecuteClassName(shareOperate.Class);
        this.FieldEnd(this.SFieldClass);

        this.End();
        return true;
    }

    public override bool ExecuteCastOperate(CastOperate castOperate)
    {
        if (castOperate == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(castOperate);

        this.Start("CastOperate");

        this.FieldStart(this.SFieldClass);
        this.ExecuteClassName(castOperate.Class);
        this.FieldEnd(this.SFieldClass);
        this.FieldStart(this.SFieldAny);
        this.ExecuteOperate(castOperate.Any);
        this.FieldEnd(this.SFieldAny);

        this.End();
        return true;
    }

    public override bool ExecuteVarOperate(VarOperate varOperate)
    {
        if (varOperate == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(varOperate);

        this.Start("VarOperate");

        this.FieldStart(this.SFieldVar);
        this.ExecuteVarName(varOperate.Var);
        this.FieldEnd(this.SFieldVar);

        this.End();
        return true;
    }

    public override bool ExecuteValueOperate(ValueOperate valueOperate)
    {
        if (valueOperate == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(valueOperate);

        this.Start("ValueOperate");

        this.FieldStart(this.SFieldValue);
        this.ExecuteValue(valueOperate.Value);
        this.FieldEnd(this.SFieldValue);

        this.End();
        return true;
    }

    public override bool ExecuteBraceOperate(BraceOperate braceOperate)
    {
        if (braceOperate == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(braceOperate);

        this.Start("BraceOperate");

        this.FieldStart(this.SFieldAny);
        this.ExecuteOperate(braceOperate.Any);
        this.FieldEnd(this.SFieldAny);

        this.End();
        return true;
    }

    public override bool ExecuteValue(Value value)
    {
        if (value == null)
        {
            this.Null();
            return true;
        }

        base.ExecuteValue(value);
        return true;
    }

    public override bool ExecuteBoolValue(BoolValue boolValue)
    {
        if (boolValue == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(boolValue);

        this.Start("BoolValue");

        this.FieldStart("Value");
        this.ExecuteBool(boolValue.Value);
        this.FieldEnd("Value");

        this.End();
        return true;
    }

    public override bool ExecuteIntValue(IntValue intValue)
    {
        if (intValue == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(intValue);

        this.Start("IntValue");

        this.FieldStart("Value");
        this.ExecuteInt(intValue.Value);
        this.FieldEnd("Value");

        this.End();
        return true;
    }

    public override bool ExecuteIntSignValue(IntSignValue intSignValue)
    {
        if (intSignValue == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(intSignValue);

        this.Start("IntSignValue");

        this.FieldStart("Value");
        this.ExecuteInt(intSignValue.Value);
        this.FieldEnd("Value");

        this.End();
        return true;
    }

    public override bool ExecuteIntHexValue(IntHexValue intHexValue)
    {
        if (intHexValue == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(intHexValue);

        this.Start("IntHexValue");

        this.FieldStart("Value");
        this.ExecuteInt(intHexValue.Value);
        this.FieldEnd("Value");

        this.End();
        return true;
    }

    public override bool ExecuteIntHexSignValue(IntHexSignValue intHexSignValue)
    {
        if (intHexSignValue == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(intHexSignValue);

        this.Start("IntHexSignValue");

        this.FieldStart("Value");
        this.ExecuteInt(intHexSignValue.Value);
        this.FieldEnd("Value");

        this.End();
        return true;
    }

    public override bool ExecuteStringValue(StringValue stringValue)
    {
        if (stringValue == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(stringValue);

        this.Start("StringValue");

        this.FieldStart("Value");
        this.ExecuteString(stringValue.Value);
        this.FieldEnd("Value");

        this.End();
        return true;
    }

    public override bool ExecuteClassName(ClassName className)
    {
        if (className == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(className);

        this.Start("ClassName");

        this.FieldStart("Value");
        this.ExecuteString(className.Value);
        this.FieldEnd("Value");

        this.End();
        return true;
    }

    public override bool ExecuteFieldName(FieldName fieldName)
    {
        if (fieldName == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(fieldName);

        this.Start("FieldName");

        this.FieldStart("Value");
        this.ExecuteString(fieldName.Value);
        this.FieldEnd("Value");

        this.End();
        return true;
    }

    public override bool ExecuteMaideName(MaideName maideName)
    {
        if (maideName == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(maideName);

        this.Start("MaideName");

        this.FieldStart("Value");
        this.ExecuteString(maideName.Value);
        this.FieldEnd("Value");

        this.End();
        return true;
    }

    public override bool ExecuteVarName(VarName varName)
    {
        if (varName == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(varName);

        this.Start("VarName");

        this.FieldStart("Value");
        this.ExecuteString(varName.Value);
        this.FieldEnd("Value");

        this.End();
        return true;
    }

    public override bool ExecuteSameOperate(SameOperate sameOperate)
    {
        if (sameOperate == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(sameOperate);

        this.Start("SameOperate");

        this.FieldStart(this.SFieldLite);
        this.ExecuteOperate(sameOperate.Lite);
        this.FieldEnd(this.SFieldLite);
        this.FieldStart(this.SFieldRite);
        this.ExecuteOperate(sameOperate.Rite);
        this.FieldEnd(this.SFieldRite);

        this.End();
        return true;
    }

    public override bool ExecuteAndOperate(AndOperate andOperate)
    {
        if (andOperate == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(andOperate);

        this.Start("AndOperate");

        this.FieldStart(this.SFieldLite);
        this.ExecuteOperate(andOperate.Lite);
        this.FieldEnd(this.SFieldLite);
        this.FieldStart(this.SFieldRite);
        this.ExecuteOperate(andOperate.Rite);
        this.FieldEnd(this.SFieldRite);

        this.End();
        return true;
    }

    public override bool ExecuteOrnOperate(OrnOperate ornOperate)
    {
        if (ornOperate == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(ornOperate);

        this.Start("OrnOperate");

        this.FieldStart(this.SFieldLite);
        this.ExecuteOperate(ornOperate.Lite);
        this.FieldEnd(this.SFieldLite);
        this.FieldStart(this.SFieldRite);
        this.ExecuteOperate(ornOperate.Rite);
        this.FieldEnd(this.SFieldRite);

        this.End();
        return true;
    }

    public override bool ExecuteNotOperate(NotOperate notOperate)
    {
        if (notOperate == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(notOperate);

        this.Start("NotOperate");

        this.FieldStart(this.SFieldValue);
        this.ExecuteOperate(notOperate.Value);
        this.FieldEnd(this.SFieldValue);

        this.End();
        return true;
    }

    public override bool ExecuteLessOperate(LessOperate lessOperate)
    {
        if (lessOperate == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(lessOperate);

        this.Start("LessOperate");

        this.FieldStart(this.SFieldLite);
        this.ExecuteOperate(lessOperate.Lite);
        this.FieldEnd(this.SFieldLite);
        this.FieldStart(this.SFieldRite);
        this.ExecuteOperate(lessOperate.Rite);
        this.FieldEnd(this.SFieldRite);

        this.End();
        return true;
    }

    public override bool ExecuteAddOperate(AddOperate addOperate)
    {
        if (addOperate == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(addOperate);

        this.Start("AddOperate");

        this.FieldStart(this.SFieldLite);
        this.ExecuteOperate(addOperate.Lite);
        this.FieldEnd(this.SFieldLite);
        this.FieldStart(this.SFieldRite);
        this.ExecuteOperate(addOperate.Rite);
        this.FieldEnd(this.SFieldRite);

        this.End();
        return true;
    }

    public override bool ExecuteSubOperate(SubOperate subOperate)
    {
        if (subOperate == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(subOperate);

        this.Start("SubOperate");

        this.FieldStart(this.SFieldLite);
        this.ExecuteOperate(subOperate.Lite);
        this.FieldEnd(this.SFieldLite);
        this.FieldStart(this.SFieldRite);
        this.ExecuteOperate(subOperate.Rite);
        this.FieldEnd(this.SFieldRite);

        this.End();
        return true;
    }

    public override bool ExecuteMulOperate(MulOperate mulOperate)
    {
        if (mulOperate == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(mulOperate);

        this.Start("MulOperate");

        this.FieldStart(this.SFieldLite);
        this.ExecuteOperate(mulOperate.Lite);
        this.FieldEnd(this.SFieldLite);
        this.FieldStart(this.SFieldRite);
        this.ExecuteOperate(mulOperate.Rite);
        this.FieldEnd(this.SFieldRite);

        this.End();
        return true;
    }

    public override bool ExecuteDivOperate(DivOperate divOperate)
    {
        if (divOperate == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(divOperate);

        this.Start("DivOperate");

        this.FieldStart(this.SFieldLite);
        this.ExecuteOperate(divOperate.Lite);
        this.FieldEnd(this.SFieldLite);
        this.FieldStart(this.SFieldRite);
        this.ExecuteOperate(divOperate.Rite);
        this.FieldEnd(this.SFieldRite);

        this.End();
        return true;
    }

    public override bool ExecuteSignMulOperate(SignMulOperate signMulOperate)
    {
        if (signMulOperate == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(signMulOperate);

        this.Start("SignMulOperate");

        this.FieldStart(this.SFieldLite);
        this.ExecuteOperate(signMulOperate.Lite);
        this.FieldEnd(this.SFieldLite);
        this.FieldStart(this.SFieldRite);
        this.ExecuteOperate(signMulOperate.Rite);
        this.FieldEnd(this.SFieldRite);

        this.End();
        return true;
    }

    public override bool ExecuteSignDivOperate(SignDivOperate signDivOperate)
    {
        if (signDivOperate == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(signDivOperate);

        this.Start("SignDivOperate");

        this.FieldStart(this.SFieldLite);
        this.ExecuteOperate(signDivOperate.Lite);
        this.FieldEnd(this.SFieldLite);
        this.FieldStart(this.SFieldRite);
        this.ExecuteOperate(signDivOperate.Rite);
        this.FieldEnd(this.SFieldRite);

        this.End();
        return true;
    }

    public override bool ExecuteSignLessOperate(SignLessOperate signLessOperate)
    {
        if (signLessOperate == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(signLessOperate);

        this.Start("SignLessOperate");

        this.FieldStart(this.SFieldLite);
        this.ExecuteOperate(signLessOperate.Lite);
        this.FieldEnd(this.SFieldLite);
        this.FieldStart(this.SFieldRite);
        this.ExecuteOperate(signLessOperate.Rite);
        this.FieldEnd(this.SFieldRite);

        this.End();
        return true;
    }

    public override bool ExecuteBitAndOperate(BitAndOperate bitAndOperate)
    {
        if (bitAndOperate == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(bitAndOperate);

        this.Start("BitAndOperate");

        this.FieldStart(this.SFieldLite);
        this.ExecuteOperate(bitAndOperate.Lite);
        this.FieldEnd(this.SFieldLite);
        this.FieldStart(this.SFieldRite);
        this.ExecuteOperate(bitAndOperate.Rite);
        this.FieldEnd(this.SFieldRite);

        this.End();
        return true;
    }

    public override bool ExecuteBitOrnOperate(BitOrnOperate bitOrnOperate)
    {
        if (bitOrnOperate == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(bitOrnOperate);

        this.Start("BitOrnOperate");

        this.FieldStart(this.SFieldLite);
        this.ExecuteOperate(bitOrnOperate.Lite);
        this.FieldEnd(this.SFieldLite);
        this.FieldStart(this.SFieldRite);
        this.ExecuteOperate(bitOrnOperate.Rite);
        this.FieldEnd(this.SFieldRite);

        this.End();
        return true;
    }

    public override bool ExecuteBitNotOperate(BitNotOperate bitNotOperate)
    {
        if (bitNotOperate == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(bitNotOperate);

        this.Start("BitNotOperate");

        this.FieldStart(this.SFieldValue);
        this.ExecuteOperate(bitNotOperate.Value);
        this.FieldEnd(this.SFieldValue);

        this.End();
        return true;
    }

    public override bool ExecuteBitLiteOperate(BitLiteOperate bitLiteOperate)
    {
        if (bitLiteOperate == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(bitLiteOperate);

        this.Start("BitLiteOperate");

        this.FieldStart(this.SFieldValue);
        this.ExecuteOperate(bitLiteOperate.Value);
        this.FieldEnd(this.SFieldValue);
        this.FieldStart(this.SFieldCount);
        this.ExecuteOperate(bitLiteOperate.Count);
        this.FieldEnd(this.SFieldCount);

        this.End();
        return true;
    }

    public override bool ExecuteBitRiteOperate(BitRiteOperate bitRiteOperate)
    {
        if (bitRiteOperate == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(bitRiteOperate);

        this.Start("BitRiteOperate");

        this.FieldStart(this.SFieldValue);
        this.ExecuteOperate(bitRiteOperate.Value);
        this.FieldEnd(this.SFieldValue);
        this.FieldStart(this.SFieldCount);
        this.ExecuteOperate(bitRiteOperate.Count);
        this.FieldEnd(this.SFieldCount);

        this.End();
        return true;
    }

    public override bool ExecuteBitSignRiteOperate(BitSignRiteOperate bitSignRiteOperate)
    {
        if (bitSignRiteOperate == null)
        {
            this.Null();
            return true;
        }
        this.ExecuteNode(bitSignRiteOperate);

        this.Start("BitSignRiteOperate");

        this.FieldStart(this.SFieldValue);
        this.ExecuteOperate(bitSignRiteOperate.Value);
        this.FieldEnd(this.SFieldValue);
        this.FieldStart(this.SFieldCount);
        this.ExecuteOperate(bitSignRiteOperate.Count);
        this.FieldEnd(this.SFieldCount);

        this.End();
        return true;
    }


}