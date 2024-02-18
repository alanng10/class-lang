namespace Class.Library;




public class Create : Any
{
    public override bool Init()
    {
        base.Init();


        
        this.InfraStat = InfraStat.This;
        
        
        this.RangeInfra = RangeInfra.This;

        
        this.TextStat = TextStat.This;
        

        this.TextInfra = TextInfra.This;
        
        
        this.Stat = Stat.This;
        
        
        this.RefKind = RefKindList.This;


        this.StateKind = StateKindList.This;


        this.OperateKind = OperateKindList.This;
        


        
        this.OperandA = new Operand();

        this.OperandA.Init();
        
        
        
        this.OperandB = new Operand();

        this.OperandB.Init();



        this.Offset = new Offset();

        this.Offset.Init();
        
        

        
        this.Int64Bit = new Int64Bit();

        this.Int64Bit.Init();



        this.LabelA = new Label();

        this.LabelA.Init();



        this.LabelB = new Label();

        this.LabelB.Init();



        
        this.MacroNull = "null";


        
        this.MacroRefAddressMask = "D_RefAddressMask";
        
        
        this.MacroRefBaseMask = "D_RefBaseMask";


        this.MacroRefBaseShift = "D_RefBaseShift";


        this.MacroRefBaseClearMask = "D_RefBaseClearMask";


        this.MacroRefKindClearMask = "D_RefKindClearMask";

        
        this.MacroInt60BitMask = "D_Int60BitMask";


        this.MacroBool1BitMask = "D_Bool1BitMask";
        
        
        this.MacroRefKindBoolMask = "D_RefKindBoolMask";
        
        this.MacroRefKindIntMask = "D_RefKindIntMask";


        this.MacroEvaluateStackOverflowExitCode = "D_EStackOverflowExitCode";


        this.MacroEvaluateNullDerefExitCode = "D_ENullDerefExitCode";

        
        this.MacroMemoryAccessInvalidExitCode = "D_MemoryAccessInvalidExitCode";

        

        
        this.ShareVarEvaluateStackCheckAddressInt = "V_SSAddress";


        
        this.MethodCastInt = "CastInt";


        this.MethodCastPointer = "CastPointer";
        
        
        this.MethodCastIntPointer = "CastIntPointer";
        
        
        this.MethodNewAny = "NewAny";
        
        
        this.MethodShareAny = "ShareAny";
        



        this.WordTrue = "true";


        this.WordFalse = "false";

        
        
        
        this.LocalVarA = "va";
        
        
        this.LocalVarB = "vb";
        
        
        this.LocalVarC = "vc";


        this.LocalVarD = "vd";


        this.LocalVarPointer = "vp";
        
        

        this.DelimitEqual = "==";
        
        this.DelimitLess = "<";
        
        this.DelimitAdd = "+";
        
        this.DelimitSubtract = "-";
        
        this.DelimitAsterisk = "*";
        
        this.DelimitAnd = "&";
        
        this.DelimitOrn = "|";
        
        this.DelimitNot = "!";
        
        this.DelimitShiftLeft = "<<";
        
        this.DelimitShiftRight = ">>";
        



        this.Combine = "_";
        

        
        this.Int60BitMask = this.InfraStat.IntCapValue - 1;
        
        
        

        this.StateIndent = 1;


        this.SpaceString = " ";


        
        string u;

        u = this.SpaceString;
        
        
        this.IndentString = new string(u[0], 4);

        
        

        return true;
    }
    
    
    
    
    public virtual ModuleRef Ref { get; set; }
    
    
    protected virtual Module Module { get; set; }
    
    
    public virtual char[] Array { get; set; }
    
    
    public virtual int Index { get; set; }

    
    
    protected virtual WriteOperate WriteOperate { get; set; }

    
    
    public virtual RangeInfra RangeInfra { get; set; }
    
    
    public virtual InfraStat InfraStat { get; set; }
    
    
    public virtual TextStat TextStat { get; set; }
    
    
    public virtual TextInfra TextInfra { get; set; }

    
    public virtual RefKindList RefKind { get; set; }
    
    
    public virtual StateKindList StateKind { get; set; }
    
    
    public virtual OperateKindList OperateKind { get; set; }
    
    
    
    protected virtual Stat Stat { get; set; }
    
    
    
    protected virtual Operand OperandA { get; set; }
    
    
    protected virtual Operand OperandB { get; set; }
    
    
    
    protected virtual Offset Offset { get; set; }
    
    
    
    protected virtual Int64Bit Int64Bit { get; set; }
    


    protected virtual Label LabelA { get; set; }


    protected virtual Label LabelB { get; set; }


    
    protected virtual string MacroNull { get; set; }
    
    
    
    protected virtual string MacroRefAddressMask { get; set; }

    
    protected virtual string MacroRefBaseMask { get; set; }


    protected virtual string MacroRefBaseShift { get; set; }


    protected virtual string MacroRefBaseClearMask { get; set; }


    protected virtual string MacroRefKindClearMask { get; set; }
    
    
    protected virtual string MacroInt60BitMask { get; set; }


    protected virtual string MacroBool1BitMask { get; set; }
    
    
    
    protected virtual string MacroRefKindBoolMask { get; set; }
    
    
    protected virtual string MacroRefKindIntMask { get; set; }
    
    
    
    protected virtual string MacroEvaluateStackOverflowExitCode { get; set; }


    protected virtual string MacroEvaluateNullDerefExitCode { get; set; }
    
    
    protected virtual string MacroMemoryAccessInvalidExitCode { get; set; }
    
    
    
    protected virtual string ShareVarEvaluateStackCheckAddressInt { get; set; }
    
    
    
    protected virtual string MethodCastInt { get; set; }


    protected virtual string MethodCastPointer { get; set; }
    
    
    protected virtual string MethodCastIntPointer { get; set; }
    
    
    
    protected virtual string MethodNewAny { get; set; }
    
    
    protected virtual string MethodShareAny { get; set; }
    


    protected virtual string WordTrue { get; set; }


    protected virtual string WordFalse { get; set; }


    
    protected virtual string LocalVarA { get; set; }
    
    
    protected virtual string LocalVarB { get; set; }
    
    
    protected virtual string LocalVarC { get; set; }


    protected virtual string LocalVarD { get; set; }


    protected virtual string LocalVarPointer { get; set; }
    
    
    
    protected virtual long MemberIndex { get; set; }
    
    
    
    protected virtual int StateKindIndex { get; set; }
    
    
    
    protected virtual State State { get; set; }
    
    
    
    protected virtual int StateEvaluateStackCount { get; set; }
    
    
    
    public virtual int StateParamVarCount { get; set; }
    
    
    public virtual int StateLocalVarCount { get; set; }
    
    
    
    
    protected virtual int FieldIdent { get; set; }
    
    
    
    protected virtual bool SetAssign { get; set; }
    
    
    protected virtual int VarTargetVarIndex { get; set; }
    
    
    protected virtual int SetTargetMemberIdent { get; set; }
    
    
    
    protected virtual int ArgueItemCount { get; set; }



    protected virtual Array BlockStack { get; set; }



    protected virtual int BlockStackIndex { get; set; }

    
    
    protected virtual VarOperate VarOperate { get; set; }
    
    
    protected virtual FieldGetVarOperate FieldGetVarOperate { get; set; }
    
    
    protected virtual FieldSetVarOperate FieldSetVarOperate { get; set; }

    
    protected virtual MethodCallVarOperate MethodCallVarOperate { get; set; }

    
    
    protected virtual string DelimitEqual { get; set; }
    
    
    protected virtual string DelimitLess { get; set; }
    
    
    protected virtual string DelimitAdd { get; set; }

    
    protected virtual string DelimitSubtract { get; set; }
    
    
    protected virtual string DelimitAsterisk { get; set; }


    protected virtual string DelimitSlash { get; set; }
    
    
    protected virtual string DelimitAnd { get; set; }
    
    
    protected virtual string DelimitOrn { get; set; }
    
    
    protected virtual string DelimitNot { get; set; }
    
    
    protected virtual string DelimitShiftLeft { get; set; }
    
    
    protected virtual string DelimitShiftRight { get; set; }
    

    
    
    protected virtual string Combine { get; set; }
    
    
    
    protected virtual long Int60BitMask { get; set; }
    
    
    
    protected virtual int StateIndent { get; set; }
    
    
    
    protected virtual string IndentString { get; set; }
    
    
    protected virtual string SpaceString { get; set; }
    
    
    
    
    public virtual bool Execute()
    {
        return true;
    }




    
    protected virtual bool ExecuteState()
    {
        this.ExecuteStateStart();

        
        
        this.ExecuteStateEvaluateStackCheck();


        this.ExecuteNewLine();



        this.ExecuteStateFunctionLocalVar();


        this.ExecuteNewLine();

        
        
        this.ExecuteStateLocalVar();

        
        this.ExecuteNewLine();
        

        
        this.ExecuteStateOperateList(this.State);
        
        
        this.ExecuteNewLine();



        this.ExecuteStateReturnDefault();



        this.ExecuteStateReturnLabelLine();


        
        this.ExecuteStateEvaluateStackFinish();



        this.ExecuteNewLine();



        this.ExecuteStateFunctionReturn();



        this.ExecuteStateEnd();



        return true;
    }
    
    



    protected virtual bool ExecuteStateStart()
    {
        this.ExecuteIntTypeName();


        this.ExecuteSpace();


        this.ExecuteStateName(this.Ref, this.MemberIndex, this.StateKindIndex);


        this.ExecuteBracketLeftDelimit();


        this.ExecuteEvaluateTypeName();


        this.ExecuteDelimit(this.DelimitAsterisk);


        this.ExecuteSpace();


        this.ExecuteEvaluateVarName();


        this.ExecuteBracketRightDelimit();


        
        this.ExecuteNewLine();



        this.ExecuteBraceLeftDelimit();
        
        
        this.ExecuteNewLine();
        


        return true;
    }




    protected virtual bool ExecuteStateEnd()
    {
        this.ExecuteBraceRightDelimit();
        
        
        this.ExecuteNewLine();


        return true;
    }



    
    protected virtual bool ExecuteStateLocalVar()
    {
        this.SetOperandMacro(this.OperandA, this.MacroNull);


        int count;

        count = this.StateLocalVarCount;

        
        int i;

        i = 0;

        
        while (i < count)
        {
            this.SetOffset(this.Offset, false, i);

            
            this.ExecuteAssignEvaluateValueOperand(this.Offset, this.OperandA);
            

            i = i + 1;
        }
        

        
        this.SetOffset(this.Offset, false, count);

        
        this.ExecuteAssignEvaluateStackPointerOffset(this.Offset);
        
        

        return true;
    }




    protected virtual bool ExecuteStateEvaluateStackFinish()
    {
        int k;
        
        
        k = this.StateParamVarCount + this.StateLocalVarCount;


        k = k - 1;

        
        
        this.SetOffset(this.Offset, true, k);


        this.ExecuteAssignEvaluateStackPointerOffset(this.Offset);



        return true;
    }




    protected virtual bool ExecuteStateFunctionLocalVar()
    {
        this.ExecuteDeclareVar(this.LocalVarA);


        this.ExecuteDeclareVar(this.LocalVarB);


        this.ExecuteDeclareVar(this.LocalVarC);


        this.ExecuteDeclareVar(this.LocalVarD);



        this.SetOperandMacro(this.OperandA, this.MacroNull);



        this.ExecuteAssignVarOperand(this.LocalVarA, this.OperandA);


        this.ExecuteAssignVarOperand(this.LocalVarB, this.OperandA);


        this.ExecuteAssignVarOperand(this.LocalVarC, this.OperandA);


        this.ExecuteAssignVarOperand(this.LocalVarD, this.OperandA);



        return true;
    }





    protected virtual bool ExecuteStateOperateList(State state)
    {
        int count;

        count = state.Operate.Count;


        int i;

        i = 0;


        while (i < count)
        {
            Operate operate;

            operate = (Operate)state.Operate.Get(i);


            
            this.ExecuteStateOperate(operate);
            
            
            
            i = i + 1;
        }
        

        return true;
    }
    



    protected virtual bool ExecuteStateOperate(Operate operate)
    {
        return true;
    }
    
    



    protected virtual bool ExecuteStateName(ModuleRef module, long memberIndex, int stateKind)
    {
        this.ExecuteString("S");


        this.ExecuteCombine();
        

        this.ExecuteIntValueHex(module.Int.Group);

        
        this.ExecuteCombine();
        
        
        this.ExecuteIntValueHex(module.Int.Value);
        
        
        this.ExecuteCombine();
        
        
        this.ExecuteIntValueHex(module.Ver);
        
        
        this.ExecuteCombine();
        
        
        this.ExecuteIntValueHex(memberIndex);
        
        
        this.ExecuteCombine();
        
        
        this.ExecuteString(this.StateKind.Get(stateKind).Text);
        
        

        return true;
    }
    
    


    protected virtual bool ExecuteStateEvaluateStackCheck()
    {
        this.SetOperandMacro(this.OperandA, this.MacroEvaluateStackOverflowExitCode);

        
        this.ExecuteAssignEvaluateExitCodeOperand(this.OperandA);


        
        this.ExecuteAssignStateEvaluateStackCheckCmov(this.StateEvaluateStackCount);
        


        this.SetOperandMacro(this.OperandA, this.MacroMemoryAccessInvalidExitCode);

        
        this.ExecuteAssignEvaluateExitCodeOperand(this.OperandA);


        return true;
    }





    protected virtual bool ExecuteStateReturnDefault()
    {
        this.SetParamVarStateEvaluateOffset(this.Offset, 0);




        this.SetOperandMacro(this.OperandA, this.MacroNull);


        this.ExecuteAssignStateEvaluateValueOperand(this.Offset, this.OperandA);




        return true;
    }





    protected virtual bool ExecuteStateReturnLabelLine()
    {
        this.SetLabelReturn(this.LabelA);


        this.ExecuteLabelLine(this.LabelA);



        return true;
    }





    protected virtual bool ExecuteStateFunctionReturn()
    {
        this.ExecuteIndent(this.StateIndent);



        this.ExecuteReturnWord();


        this.ExecuteSpace();
        

        this.ExecuteWord(this.WordTrue);



        this.ExecuteSemicolonDelimit();


        this.ExecuteNewLine();
        



        return true;
    }





    protected virtual bool ExecuteOperateAssign(Operate operate)
    {
        bool b;

        b = this.SetAssign;


        if (b)
        {
            this.ExecuteEvaluateState(this.SetTargetMemberIdent, this.StateKind.Set.Index);
        }


        if (!b)
        {
            this.ExecuteVarSet(this.VarTargetVarIndex);
        }
        
        
        
        return true;
    }
    



    
    protected virtual bool ExecuteOperateSetTarget(Operate operate)
    {
        long arg;

        arg = operate.Arg;


        int memberIdent;

        memberIdent = this.GetArgIdent(arg);
        



        this.SetAssign = true;


        this.VarTargetVarIndex = -1;


        this.SetTargetMemberIdent = memberIdent;



        return true;
    }
    
    
    
    
    protected virtual bool ExecuteOperateVarTarget(Operate operate)
    {
        long arg;

        arg = operate.Arg;


        int varIndex;

        varIndex = this.GetArgVar(arg);
        



        this.SetAssign = false;
        
        
        this.VarTargetVarIndex = varIndex;


        this.SetTargetMemberIdent = -1;



        return true;
    }
    

    
    
    protected virtual bool ExecuteOperateCall(Operate operate)
    {
        long arg;

        arg = operate.Arg;


        int memberIdent;

        memberIdent = this.GetArgIdent(arg);



        this.ExecuteEvaluateState(memberIdent, this.StateKind.Call.Index);
        
        
        
        
        return true;
    }


    
    
    protected virtual bool ExecuteOperateGet(Operate operate)
    {
        long arg;

        arg = operate.Arg;


        int memberIdent;

        memberIdent = this.GetArgIdent(arg);



        this.ExecuteEvaluateState(memberIdent, this.StateKind.ItemGet.Index);
        
        
        
        
        return true;
    }

    
    
    
    protected virtual bool ExecuteEvaluateState(int memberIdent, int stateKind)
    {
        this.SetOffset(this.Offset, true, 1);
        
        this.ExecuteAssignVarEvaluateValue(this.LocalVarA, this.Offset);
        
        
        
        
        this.SetOperandVar(this.OperandA, this.LocalVarA);
        
        
        this.SetOperandMacro(this.OperandB, this.MacroRefAddressMask);

        
        this.ExecuteAssignVarTwoOperandOp(this.LocalVarB, this.DelimitAnd, this.OperandA, this.OperandB);





        this.SetOperandVar(this.OperandA, this.LocalVarA);
        

        this.SetOperandMacro(this.OperandB, this.MacroRefBaseShift);
        
        
        this.ExecuteAssignVarTwoOperandOp(this.LocalVarC, this.DelimitShiftRight, this.OperandA, this.OperandB);
        
        
        
        
        this.SetOperandVar(this.OperandA, this.LocalVarC);
        
        
        this.SetOperandMacro(this.OperandB, this.MacroRefBaseMask);
        
        
        this.ExecuteAssignVarTwoOperandOp(this.LocalVarC, this.DelimitAnd, this.OperandA, this.OperandB);




        this.SetOperandVar(this.OperandA, this.LocalVarB);


        this.SetInt64Bit(this.Int64Bit, 0, 1);

        
        this.SetOperandInt64Bit(this.OperandB, this.Int64Bit);


        this.ExecuteAssignVarIntPointerOffsetAddress(this.LocalVarD, this.OperandA, this.OperandB);





        this.SetOperandMacro(this.OperandA, this.MacroEvaluateNullDerefExitCode);


        this.ExecuteAssignEvaluateExitCodeOperand(this.OperandA);



        this.SetOperandVar(this.OperandA, this.LocalVarB);


        this.ExecuteAssignVarIntValueAt(this.LocalVarB, this.OperandA);



        this.SetOperandMacro(this.OperandA, this.MacroMemoryAccessInvalidExitCode);


        this.ExecuteAssignEvaluateExitCodeOperand(this.OperandA);





        this.SetOperandVar(this.OperandA, this.LocalVarD);


        this.ExecuteAssignVarIntValueAt(this.LocalVarD, this.OperandA);





        this.SetOperandVar(this.OperandA, this.LocalVarA);


        this.SetOperandMacro(this.OperandB, this.MacroRefBaseClearMask);


        this.ExecuteAssignVarTwoOperandOp(this.LocalVarA, this.DelimitAnd, this.OperandA, this.OperandB);




        this.SetOperandVar(this.OperandB, this.LocalVarD);


        this.ExecuteAssignVarTwoOperandOp(this.LocalVarA, this.DelimitOrn, this.OperandA, this.OperandB);




        this.SetOffset(this.Offset, true, 1);


        this.SetOperandVar(this.OperandA, this.LocalVarA);


        this.ExecuteAssignEvaluateValueOperand(this.Offset, this.OperandA);





        this.SetOperandVar(this.OperandA, this.LocalVarB);
        

        this.ExecuteAssignVarIntValueAt(this.LocalVarB, this.OperandA);



        this.SetOperandVar(this.OperandB, this.LocalVarC);


        this.ExecuteAssignVarIntPointerOffsetAddress(this.LocalVarB, this.OperandA, this.OperandB);
        
        
        
        
        this.ExecuteAssignVarIntValueAt(this.LocalVarB, this.OperandA);



        
        this.SetInt64Bit(this.Int64Bit, 0, stateKind);


        this.SetOperandInt64Bit(this.OperandB, this.Int64Bit);
        
        
        this.ExecuteAssignVarIntPointerOffsetAddress(this.LocalVarB, this.OperandA, this.OperandB);
        
        

        
        this.ExecuteAssignVarIntValueAt(this.LocalVarB, this.OperandA);

        
        
        
        
        this.SetInt64Bit(this.Int64Bit, 0, memberIdent);

        
        
        this.ExecuteAssignVarIntPointerOffsetAddress(this.LocalVarB, this.OperandA, this.OperandB);


        
        
        this.ExecuteAssignVarIntValueAt(this.LocalVarA, this.OperandA);


        
        
        this.ExecuteCallStateMethod(this.LocalVarA);

        
        
        
        return true;
    }




    
    protected virtual bool ExecuteOperateVar(Operate operate)
    {
        long arg;

        arg = operate.Arg;


        int varIndex;

        varIndex = this.GetArgVar(arg);



        this.ExecuteVarGet(varIndex);
        
        
        
        return true;
    }



    
    protected virtual bool ExecuteVarGet(int varIndex)
    {
        this.VarOperate.ExecuteGet(varIndex);


        return true;
    }
    
    
    
    
    protected virtual bool ExecuteVarSet(int varIndex)
    {
        this.VarOperate.ExecuteSet(varIndex);


        return true;
    }
    



    public virtual bool ExecuteOperateVarLocalVar(int localVarIndex)
    {
        this.SetLocalVarStateEvaluateOffset(this.Offset, localVarIndex);
        

        
        this.ExecuteOperateVarStateEvaluateOffset(this.Offset);
        


        return true;
    }



    
    
    public virtual bool ExecuteOperateVarParamVar(int paramVarIndex)
    {
        this.SetParamVarStateEvaluateOffset(this.Offset, paramVarIndex);
        

        
        this.ExecuteOperateVarStateEvaluateOffset(this.Offset);



        return true;
    }



    
    protected virtual bool ExecuteOperateVarStateEvaluateOffset(Offset offset)
    {
        this.ExecuteAssignVarStateEvaluateValue(this.LocalVarA, offset);

        
        
        
        this.SetOffset(this.Offset, false, 0);


        this.SetOperandVar(this.OperandA, this.LocalVarA);
        
        
        this.ExecuteAssignEvaluateValueOperand(this.Offset, this.OperandA);

        
        
        
        this.SetOffset(this.Offset, false, 1);
        
        this.ExecuteAssignEvaluateStackPointerOffset(this.Offset);


        
        return true;
    }
    
    
    

    public virtual bool ExecuteOperateVarThisFieldData()
    {
        this.ExecuteThisFieldAddress(this.FieldIdent);


        
        
        this.SetOffset(this.Offset, false, 0);


        this.SetOperandVar(this.OperandA, this.LocalVarA);
        
        
        this.ExecuteAssignEvaluateValueOperand(this.Offset, this.OperandA);

        
        
        
        this.SetOffset(this.Offset, false, 1);
        
        this.ExecuteAssignEvaluateStackPointerOffset(this.Offset);
        
        
        

        return true;
    }
    
    
    
    
    public virtual bool ExecuteOperateAssignVarLocalVar(int localVarIndex)
    {
        this.SetOffset(this.Offset, true, 1);

        this.ExecuteAssignVarEvaluateValue(this.LocalVarA, this.Offset);
        
        
        
        
        this.SetLocalVarStateEvaluateOffset(this.Offset, localVarIndex);
        

        
        this.ExecuteOperateAssignVarStateEvaluateOffset(this.Offset);



        return true;
    }

    
    
    
    public virtual bool ExecuteOperateAssignVarParamVar(int paramVarIndex)
    {
        this.SetOffset(this.Offset, true, 1);

        this.ExecuteAssignVarEvaluateValue(this.LocalVarA, this.Offset);



        
        this.SetParamVarStateEvaluateOffset(this.Offset, paramVarIndex);


        
        this.ExecuteOperateAssignVarStateEvaluateOffset(this.Offset);
        
        

        return true;
    }





    protected virtual bool ExecuteOperateAssignVarStateEvaluateOffset(Offset offset)
    {
        this.SetOperandVar(this.OperandA, this.LocalVarA);


        this.ExecuteAssignStateEvaluateValueOperand(offset, this.OperandA);
        
        
        
        
        this.SetOffset(this.Offset, true, 1);
        
        this.ExecuteAssignEvaluateStackPointerOffset(this.Offset);


        
        return true;
    }



    
    
    public virtual bool ExecuteOperateAssignVarThisFieldData()
    {
        this.ExecuteThisFieldAddress(this.FieldIdent);


        
        
        this.SetOffset(this.Offset, true, 1);

        this.ExecuteAssignVarEvaluateValue(this.LocalVarB, this.Offset);


        

        this.SetOperandVar(this.OperandA, this.LocalVarA);


        this.SetOperandVar(this.OperandB, this.LocalVarB);


        this.ExecuteAssignIntValueAtOperand(this.OperandA, this.OperandB);
        
        
        
        
        this.SetOffset(this.Offset, true, 1);
        
        this.ExecuteAssignEvaluateStackPointerOffset(this.Offset);

        


        return true;
    }
    
    
    

    
    protected virtual bool SetLocalVarStateEvaluateOffset(Offset offset, int localVarIndex)
    {
        this.SetOffset(offset, false, localVarIndex);
        
        
        return true;
    }
    
    
    
    protected virtual bool SetParamVarStateEvaluateOffset(Offset offset, int paramVarIndex)
    {
        int k;

        k = this.StateParamVarCount - paramVarIndex;
        
        
        
        this.SetOffset(offset, true, k);
        
        
        
        return true;
    }
    
    
    



    protected virtual bool ExecuteThisFieldAddress(int fieldIdent)
    {
        this.SetOffset(this.Offset, true, 1);
        
        this.ExecuteAssignVarEvaluateValue(this.LocalVarA, this.Offset);
        
        
        
        
        this.SetOperandVar(this.OperandA, this.LocalVarA);
        
        
        this.SetOperandMacro(this.OperandB, this.MacroRefAddressMask);

        
        this.ExecuteAssignVarTwoOperandOp(this.LocalVarB, this.DelimitAnd, this.OperandA, this.OperandB);


        
        
        this.SetOperandVar(this.OperandA, this.LocalVarB);


        int k;

        k = fieldIdent + 1;

        
        this.SetInt64Bit(this.Int64Bit, 0, k);
        


        this.SetOperandInt64Bit(this.OperandB, this.Int64Bit);
        
        
        this.ExecuteAssignVarIntPointerOffsetAddress(this.LocalVarB, this.OperandA, this.OperandB);

        
        
        
        this.ExecuteAssignVarIntValueAt(this.LocalVarA, this.OperandA);

        
        

        return true;
    }
    
    
    
    
    protected virtual int GetArgClass(long a)
    {
        return (int)a;
    }



    protected virtual int GetArgIdent(long a)
    {
        return (int)a;
    }
    
    
    
    protected virtual int GetArgVar(long a)
    {
        return (int)a;
    }



    protected virtual bool ExecuteOperateArgue(Operate operate)
    {
        long arg;

        arg = operate.Arg;


        int a;

        a = (int)arg;


        
        this.ArgueItemCount = a;
        
        
        

        return true;
    }




    
    protected virtual bool ExecuteCallStateMethod(string addressVar)
    {
        this.ExecuteIndent(this.StateIndent);

        
        
        
        this.ExecuteBracketLeftDelimit();

        
        
        this.ExecuteBracketLeftDelimit();

        
        this.ExecuteStateMethodTypeName();
        
        
        this.ExecuteBracketRightDelimit();

        
        
        this.ExecuteBracketLeftDelimit();
        

        this.ExecuteVarName(addressVar);


        this.ExecuteBracketRightDelimit();
        
        
        
        this.ExecuteBracketRightDelimit();

        
        
        this.ExecuteBracketLeftDelimit();


        this.ExecuteEvaluateVarName();


        this.ExecuteCommaDelimit();


        this.ExecuteSpace();


        this.ExecuteEvaluateStackPointer();
        
        
        this.ExecuteBracketRightDelimit();
        
        
        
        this.ExecuteSemicolonDelimit();


        
        this.ExecuteNewLine();
        
        
            

        return true;
    }
    
    
    
    
    protected virtual bool ExecuteStateMethodTypeName()
    {
        return this.ExecuteTypeName("State_Method");
    }





    protected virtual bool ExecuteOperateIf(Operate operate)
    {
        int index;

        index = this.BlockStackIndex;



        Block block;

        block = this.GetBlock(index);



        block.HasStartLabel = false;



        return true;
    }





    protected virtual bool ExecuteOperateWhile(Operate operate)
    {
        int index;

        index = this.BlockStackIndex;



        Block block;

        block = this.GetBlock(index);



        block.HasStartLabel = true;



        this.SetLabelBlock(this.LabelA, true, false, false, index);


        this.ExecuteLabelLine(this.LabelA);



        return true;
    }




    protected virtual bool ExecuteOperateBlockStart(Operate operate)
    {
        int index;

        index = this.BlockStackIndex;




        this.SetOffset(this.Offset, true, 1);

        this.ExecuteAssignVarEvaluateValue(this.LocalVarA, this.Offset);




        this.SetOperandVar(this.OperandA, this.LocalVarA);


        this.SetOperandMacro(this.OperandB, this.MacroBool1BitMask);


        this.ExecuteAssignVarTwoOperandOp(this.LocalVarA, this.DelimitAnd, this.OperandA, this.OperandB);




        this.SetOffset(this.Offset, true, 1);

        this.ExecuteAssignEvaluateStackPointerOffset(this.Offset);





        this.SetLabelBlock(this.LabelA, false, true, false, index);


        this.SetLabelBlock(this.LabelB, false, false, true, index);




        this.ExecuteAssignVarCmovLabel(this.LocalVarA, this.LocalVarA, this.LabelA, this.LabelB);




        this.ExecuteAssignPointerVarVar(this.LocalVarPointer, this.LocalVarA);




        this.ExecuteGotoVar(this.LocalVarPointer);




        this.ExecuteLabelLine(this.LabelA);



        index = index + 1;



        this.BlockStackIndex = index;



        return true;
    }





    protected virtual bool ExecuteOperateBlockEnd(Operate operate)
    {
        int index;

        index = this.BlockStackIndex;


        index = index - 1;



        Block block;

        block = this.GetBlock(index);



        if (block.HasStartLabel)
        {
            this.SetLabelBlock(this.LabelA, true, false, false, index);



            this.ExecuteGotoLabel(this.LabelA);
        }




        this.SetLabelBlock(this.LabelA, false, false, true, index);



        this.ExecuteLabelLine(this.LabelA);




        this.BlockStackIndex = index;




        return true;
    }





    protected virtual bool ExecuteAssignVarCmovLabel(string destVar, string condVar, Label labelA, Label labelB)
    {
        this.ExecuteExecuteStart();




        this.ExecuteVarName(destVar);


        this.ExecuteSpace();


        this.ExecuteAssignDelimit();


        this.ExecuteSpace();




        this.ExecuteBracketLeftDelimit();



        this.ExecuteMethodName(this.MethodCastInt);


        this.ExecuteBracketLeftDelimit();


        this.ExecuteLabelPointer(labelA);


        this.ExecuteBracketRightDelimit();


        this.ExecuteSpace();


        this.ExecuteDelimit(this.DelimitAsterisk);


        this.ExecuteSpace();


        this.ExecuteVarName(condVar);



        this.ExecuteBracketRightDelimit();




        this.ExecuteSpace();


        this.ExecuteDelimit(this.DelimitAdd);


        this.ExecuteSpace();





        this.ExecuteBracketLeftDelimit();



        this.ExecuteMethodName(this.MethodCastInt);


        this.ExecuteBracketLeftDelimit();


        this.ExecuteLabelPointer(labelB);


        this.ExecuteBracketRightDelimit();


        this.ExecuteSpace();


        this.ExecuteDelimit(this.DelimitAsterisk);


        this.ExecuteSpace();



        this.ExecuteBracketLeftDelimit();


        this.ExecuteDelimit(this.DelimitNot);
        

        this.ExecuteVarName(condVar);


        this.ExecuteBracketRightDelimit();



        this.ExecuteBracketRightDelimit();




        this.ExecuteExecuteEnd();




        return true;
    }




    protected virtual Block GetBlock(int index)
    {
        return (Block)this.BlockStack.Get(index);
    }




    protected virtual bool ExecuteOperateEnd(Operate operate)
    {
        this.SetOffset(this.Offset, true, 1);

        this.ExecuteAssignEvaluateStackPointerOffset(this.Offset);



        return true;
    }





    protected virtual bool ExecuteOperateReturn(Operate operate)
    {
        this.SetOffset(this.Offset, true, 1);

        this.ExecuteAssignVarEvaluateValue(this.LocalVarA, this.Offset);




        this.SetParamVarStateEvaluateOffset(this.Offset, 0);




        this.SetOperandVar(this.OperandA, this.LocalVarA);


        this.ExecuteAssignStateEvaluateValueOperand(this.Offset, this.OperandA);




        this.SetOffset(this.Offset, true, 1);

        this.ExecuteAssignEvaluateStackPointerOffset(this.Offset);




        this.SetLabelReturn(this.LabelA);


        this.ExecuteGotoLabel(this.LabelA);




        return true;
    }




    
    protected virtual bool ExecuteOperateThis(Operate operate)
    {
        this.SetOffset(this.Offset, true, 1);
        
        
        this.ExecuteAssignVarStateEvaluateValue(this.LocalVarA, this.Offset);
        
        
        
        
        this.SetOffset(this.Offset, false, 0);


        this.SetOperandVar(this.OperandA, this.LocalVarA);
        
        
        this.ExecuteAssignEvaluateValueOperand(this.Offset, this.OperandA);

        
        
        
        this.SetOffset(this.Offset, false, 1);
        
        this.ExecuteAssignEvaluateStackPointerOffset(this.Offset);
        
        
        
        
        return true;
    }
    
    
    
    
    
    protected virtual bool ExecuteOperateNull(Operate operate)
    {
        this.SetOffset(this.Offset, false, 0);


        this.SetOperandMacro(this.OperandA, this.MacroNull);
        
        
        this.ExecuteAssignEvaluateValueOperand(this.Offset, this.OperandA);

        
        
        
        this.SetOffset(this.Offset, false, 1);
        
        this.ExecuteAssignEvaluateStackPointerOffset(this.Offset);
        
        
        
        
        return true;
    }




    protected virtual bool ExecuteOperateNew(Operate operate)
    {
        long arg;

        arg = operate.Arg;


        int varClass;

        varClass = this.GetArgClass(arg);

        
        
        
        
        this.SetOffset(this.Offset, false, 0);


        this.SetOperandMacro(this.OperandA, this.MacroNull);
        
        
        this.ExecuteAssignEvaluateValueOperand(this.Offset, this.OperandA);

        
        
        
        this.SetOffset(this.Offset, false, 1);
        
        this.ExecuteAssignEvaluateStackPointerOffset(this.Offset);




        this.ExecuteCallMethodNewAny(varClass);
        
        
        


        return true;
    }
    
    
    
    
    
    protected virtual bool ExecuteOperateShare(Operate operate)
    {
        long arg;

        arg = operate.Arg;


        int varClass;

        varClass = this.GetArgClass(arg);

        
        
        
        
        this.SetOffset(this.Offset, false, 0);


        this.SetOperandMacro(this.OperandA, this.MacroNull);
        
        
        this.ExecuteAssignEvaluateValueOperand(this.Offset, this.OperandA);

        
        
        
        this.SetOffset(this.Offset, false, 1);
        
        this.ExecuteAssignEvaluateStackPointerOffset(this.Offset);




        this.ExecuteCallMethodShareAny(varClass);
        
        
        


        return true;
    }
    



    
    protected virtual bool ExecuteCallMethodNewAny(int varClass)
    {
        this.ExecuteIndent(this.StateIndent);
        
        
        
        
        
        this.ExecuteMethodName(this.MethodNewAny);


        
        this.ExecuteBracketLeftDelimit();



        this.ExecuteEvaluateVarName();



        this.ExecuteCommaDelimit();



        this.ExecuteSpace();

        

        long k;

        k = varClass;


        this.ExecuteIntValueHex(k);
        
        
        
        this.ExecuteBracketRightDelimit();

        
        
        
        this.ExecuteSemicolonDelimit();


        
        this.ExecuteNewLine();




        return true;
    }
    
    
    
    
    protected virtual bool ExecuteCallMethodShareAny(int varClass)
    {
        this.ExecuteIndent(this.StateIndent);
        
        
        
        
        
        this.ExecuteMethodName(this.MethodShareAny);


        
        this.ExecuteBracketLeftDelimit();



        this.ExecuteEvaluateVarName();



        this.ExecuteCommaDelimit();



        this.ExecuteSpace();


        
        long k;

        k = varClass;


        this.ExecuteIntValueHex(k);
        
        
        
        this.ExecuteBracketRightDelimit();

        
        
        
        this.ExecuteSemicolonDelimit();


        
        this.ExecuteNewLine();




        return true;
    }
    



    protected virtual bool ExecuteOperateEqual(Operate operate)
    {
        this.SetOffset(this.Offset, true, 2);
        
        this.ExecuteAssignVarEvaluateValue(this.LocalVarA, this.Offset);
        
        
        this.SetOffset(this.Offset, true, 1);

        this.ExecuteAssignVarEvaluateValue(this.LocalVarB, this.Offset);


        
        
        this.SetOperandVar(this.OperandA, this.LocalVarA);
        
        
        this.SetOperandVar(this.OperandB, this.LocalVarB);


        this.ExecuteAssignVarTwoOperandOp(this.LocalVarA, this.DelimitEqual, this.OperandA, this.OperandB);
        
        
        
        
        this.SetOperandMacro(this.OperandB, this.MacroRefKindBoolMask);        
        
        
        this.ExecuteAssignVarTwoOperandOp(this.LocalVarA, this.DelimitOrn, this.OperandA, this.OperandB);



        this.SetOffset(this.Offset, true, 2);
        
        this.ExecuteAssignEvaluateValueOperand(this.Offset, this.OperandA);

        
        
        this.SetOffset(this.Offset, true, 1);
        
        this.ExecuteAssignEvaluateStackPointerOffset(this.Offset);
        
        

        return true;
    }
    



    protected virtual bool ExecuteOperateAdd(Operate operate)
    {
        return this.ExecuteOperateIntTwoOperandOp(this.DelimitAdd);
    }




    protected virtual bool ExecuteOperateSub(Operate operate)
    {
        return this.ExecuteOperateIntTwoOperandOp(this.DelimitSubtract);
    }


    
    
    protected virtual bool ExecuteOperateMul(Operate operate)
    {
        return this.ExecuteOperateIntTwoOperandOp(this.DelimitAsterisk);
    }




    protected virtual bool ExecuteOperateDiv(Operate operate)
    {
        return this.ExecuteOperateIntTwoOperandOp(this.DelimitSlash);
    }


    
    
    
    
    
    protected virtual bool ExecuteOperateBitAnd(Operate operate)
    {
        return this.ExecuteOperateBitIntTwoOperandOp(this.DelimitAnd);
    }
    

    protected virtual bool ExecuteOperateBitOrn(Operate operate)
    {
        return this.ExecuteOperateBitIntTwoOperandOp(this.DelimitOrn);
    }
    


    
    protected virtual bool ExecuteOperateIntTwoOperandOp(string opDelimit)
    {
        this.SetOffset(this.Offset, true, 2);
        
        this.ExecuteAssignVarEvaluateValue(this.LocalVarA, this.Offset);
        
        
        this.SetOffset(this.Offset, true, 1);

        this.ExecuteAssignVarEvaluateValue(this.LocalVarB, this.Offset);



        
        this.SetOperandMacro(this.OperandB, this.MacroRefKindClearMask);
        


        this.SetOperandVar(this.OperandA, this.LocalVarA);
        

        this.ExecuteAssignVarTwoOperandOp(this.LocalVarA, this.DelimitAnd, this.OperandA, this.OperandB);
        
        
        
        this.SetOperandVar(this.OperandA, this.LocalVarB);
        
        
        this.ExecuteAssignVarTwoOperandOp(this.LocalVarB, this.DelimitAnd, this.OperandA, this.OperandB);



        
        this.SetOperandVar(this.OperandA, this.LocalVarA);
        
        this.SetOperandVar(this.OperandB, this.LocalVarB);
        
        
        this.ExecuteAssignVarTwoOperandOp(this.LocalVarA, opDelimit, this.OperandA, this.OperandB);
        
        

        
        this.SetOperandMacro(this.OperandB, this.MacroRefKindClearMask);
        
        
        this.ExecuteAssignVarTwoOperandOp(this.LocalVarA, this.DelimitAnd, this.OperandA, this.OperandB);


        
        this.SetOperandMacro(this.OperandB, this.MacroRefKindIntMask);        
        
        
        this.ExecuteAssignVarTwoOperandOp(this.LocalVarA, this.DelimitOrn, this.OperandA, this.OperandB);




        this.SetOffset(this.Offset, true, 2);
        
        this.ExecuteAssignEvaluateValueOperand(this.Offset, this.OperandA);

        
        
        this.SetOffset(this.Offset, true, 1);
        
        this.ExecuteAssignEvaluateStackPointerOffset(this.Offset);
        
        


        return true;
    }
    
    
    
    
    
    
    protected virtual bool ExecuteOperateBitIntTwoOperandOp(string opDelimit)
    {
        this.SetOffset(this.Offset, true, 2);
        
        this.ExecuteAssignVarEvaluateValue(this.LocalVarA, this.Offset);
        
        
        this.SetOffset(this.Offset, true, 1);
        
        this.ExecuteAssignVarEvaluateValue(this.LocalVarB, this.Offset);



        
        this.SetOperandVar(this.OperandA, this.LocalVarA);
        
        this.SetOperandVar(this.OperandB, this.LocalVarB);
        
        
        this.ExecuteAssignVarTwoOperandOp(this.LocalVarA, opDelimit, this.OperandA, this.OperandB);

        
        
        
        this.SetOperandMacro(this.OperandB, this.MacroRefKindIntMask);
     
        
        this.ExecuteAssignVarTwoOperandOp(this.LocalVarA, this.DelimitOrn, this.OperandA, this.OperandB);


        
        this.SetOffset(this.Offset, true, 2);

        this.ExecuteAssignEvaluateValueOperand(this.Offset, this.OperandA);


        
        this.SetOffset(this.Offset, true, 1);

        this.ExecuteAssignEvaluateStackPointerOffset(this.Offset);
        
        


        return true;
    }




    protected virtual bool ExecuteAssignStateEvaluateStackCheckCmov(int stateEvaluateStackCount)
    {
        this.ExecuteIndent(this.StateIndent);


        

        
        this.ExecuteDelimit(this.DelimitAsterisk);

        
        
        this.ExecuteBracketLeftDelimit();



        this.ExecuteMethodName(this.MethodCastIntPointer);
        
        
        
        this.ExecuteBracketLeftDelimit();
        
        
        this.ExecuteVarName(this.ShareVarEvaluateStackCheckAddressInt);

        
        this.ExecuteSpace();

        
        this.ExecuteDelimit(this.DelimitAsterisk);
        
        
        this.ExecuteSpace();


        
        this.ExecuteDelimit(this.DelimitNot);
        
        
        
        this.ExecuteBracketLeftDelimit();
        
        
            
        this.ExecuteEvaluateStackEndAddress();
        
        
        
        this.ExecuteSpace();


        this.ExecuteDelimit(this.DelimitLess);
        
        
        this.ExecuteSpace();
        
        
        this.ExecuteBracketLeftDelimit();
            
            

        this.ExecuteMethodName(this.MethodCastInt);
        

        this.ExecuteBracketLeftDelimit();

        
        this.ExecuteEvaluateStackPointer();
        
        
        this.ExecuteBracketRightDelimit();

        
        this.ExecuteSpace();


        this.ExecuteDelimit(this.DelimitAdd);
        
        
        this.ExecuteSpace();


        this.ExecuteIntValueHex(stateEvaluateStackCount);
        
        
        
        this.ExecuteBracketRightDelimit();
        
        
        
        this.ExecuteBracketRightDelimit();
        
        
        
        this.ExecuteBracketRightDelimit();
        
        
        
        this.ExecuteBracketRightDelimit();
        
        
        
        
        this.ExecuteSpace();
        
        
        this.ExecuteAssignDelimit();
        

        this.ExecuteSpace();

        

        this.ExecuteIntValueHex(1);
        
        
        
        
        this.ExecuteSemicolonDelimit();


        
        this.ExecuteNewLine();
        
        
        

        return true;
    }
    



    
    protected virtual bool ExecuteAssignVarIntPointerOffsetAddress(string destVar, Operand operandAddress, Operand operandOffset)
    {
        this.ExecuteIndent(this.StateIndent);



        
        this.ExecuteVarName(destVar);
        
        
        this.ExecuteSpace();
        
        
        this.ExecuteAssignDelimit();
        

        this.ExecuteSpace();
        
        
        
        
        this.ExecuteMethodName(this.MethodCastInt);

        
        
        this.ExecuteBracketLeftDelimit();
        
        
        

        this.ExecuteMethodName(this.MethodCastIntPointer);
        
        
        
        this.ExecuteBracketLeftDelimit();



        this.ExecuteOperand(operandAddress);
        
        
        
        this.ExecuteBracketRightDelimit();


        
        this.ExecuteSpace();

        

        this.ExecuteDelimit(this.DelimitAdd);

        

        this.ExecuteSpace();
        


        this.ExecuteOperand(operandOffset);

        
        
        
        
        this.ExecuteBracketRightDelimit();
        
        
        
        
        this.ExecuteSemicolonDelimit();


        
        this.ExecuteNewLine();
        
        
        
        
        return true;
    }


    
    
    protected virtual bool ExecuteAssignVarIntValueAt(string destVar, Operand operand)
    {
        this.ExecuteIndent(this.StateIndent);



        
        this.ExecuteVarName(destVar);
        
        
        this.ExecuteSpace();
        
        
        this.ExecuteAssignDelimit();
        

        this.ExecuteSpace();


        

        
        
        this.ExecuteDelimit(this.DelimitAsterisk);
        
        

        this.ExecuteMethodName(this.MethodCastIntPointer);
        
        
        
        this.ExecuteBracketLeftDelimit();



        this.ExecuteOperand(operand);
        
        
        
        this.ExecuteBracketRightDelimit();
        
        
        
        
        
        this.ExecuteSemicolonDelimit();


        
        this.ExecuteNewLine();
        
        
        
        
        
        
        return true;
    }




    
    protected virtual bool ExecuteAssignIntValueAtOperand(Operand operandAddress, Operand operandValue)
    {
        this.ExecuteIndent(this.StateIndent);





        this.ExecuteBracketLeftDelimit();
        

        
        this.ExecuteDelimit(this.DelimitAsterisk);
        
        

        this.ExecuteMethodName(this.MethodCastIntPointer);
        
        
        
        this.ExecuteBracketLeftDelimit();



        this.ExecuteOperand(operandAddress);
        
        
        
        this.ExecuteBracketRightDelimit();
        
        
        
        this.ExecuteBracketRightDelimit();
        
        
        
        
        this.ExecuteSpace();
        
        
        
        this.ExecuteAssignDelimit();
        
        

        this.ExecuteSpace();


        
        
        this.ExecuteOperand(operandValue);
        
        
        
        
        this.ExecuteSemicolonDelimit();


        
        this.ExecuteNewLine();
        
        
        
        
        
        return true;
    }
    
    



    protected virtual bool ExecuteAssignVarCmovSub(string destVar, string varLeft, string varRight)
    {
        this.ExecuteIndent(this.StateIndent);



        this.ExecuteVarName(destVar);
        
        
        this.ExecuteSpace();
        
        
        this.ExecuteAssignDelimit();
        

        this.ExecuteSpace();


        
        
        this.ExecuteBracketLeftDelimit();


        
        this.ExecuteBracketLeftDelimit();

        
        
        this.ExecuteDelimit(this.DelimitNot);
        
        
        this.ExecuteBracketLeftDelimit();


        this.ExecuteVarName(varLeft);


        this.ExecuteSpace();


        this.ExecuteDelimit(this.DelimitLess);
        
        
        this.ExecuteSpace();
        

        this.ExecuteVarName(varRight);
        
        
        this.ExecuteBracketRightDelimit();

        
        
        this.ExecuteBracketRightDelimit();

        
        this.ExecuteSpace();

        
        this.ExecuteDelimit(this.DelimitAsterisk);
        
        
        this.ExecuteSpace();
        
        
        this.ExecuteBracketLeftDelimit();
        
        
        
        this.ExecuteVarName(varLeft);
        
        
        this.ExecuteSpace();


        this.ExecuteDelimit(this.DelimitSubtract);
        
        
        this.ExecuteSpace();
        

        this.ExecuteVarName(varRight);
        
        
        
        this.ExecuteBracketRightDelimit();
        
        
        
        this.ExecuteBracketRightDelimit();
        
        
        
        
        this.ExecuteSemicolonDelimit();


        
        this.ExecuteNewLine();
        

        
        return true;
    }
    
    
    
    
    
    protected virtual bool ExecuteAssignStateEvaluateValueOperand(Offset offset, Operand operand)
    {
        this.ExecuteIndent(this.StateIndent);

        
        
        this.ExecuteStateEvaluateValueAt(offset);
        
        
        this.ExecuteSpace();
        
        
        this.ExecuteAssignDelimit();
        

        this.ExecuteSpace();
        
        
        this.ExecuteOperand(operand);


        
        this.ExecuteSemicolonDelimit();


        
        this.ExecuteNewLine();
        

        
        return true;
    }

    
    
    
    protected virtual bool ExecuteAssignVarStateEvaluateValue(string destVar, Offset offset)
    {
        this.ExecuteIndent(this.StateIndent);



        this.ExecuteVarName(destVar);
        
        
        this.ExecuteSpace();
        
        
        this.ExecuteAssignDelimit();
        

        this.ExecuteSpace();
        
        
        this.ExecuteStateEvaluateValueAt(offset);


        
        this.ExecuteSemicolonDelimit();


        
        this.ExecuteNewLine();
        

        
        return true;
    }
    
    

    
    protected virtual bool ExecuteAssignEvaluateValueOperand(Offset offset, Operand operand)
    {
        this.ExecuteIndent(this.StateIndent);

        
        
        this.ExecuteEvaluateValueAt(offset);
        
        
        this.ExecuteSpace();
        
        
        this.ExecuteAssignDelimit();
        

        this.ExecuteSpace();
        
        
        this.ExecuteOperand(operand);


        
        this.ExecuteSemicolonDelimit();


        
        this.ExecuteNewLine();
        

        
        return true;
    }
    
    
    
    
    
    protected virtual bool ExecuteAssignEvaluateExitCodeOperand(Operand operand)
    {
        this.ExecuteIndent(this.StateIndent);

        
        
        this.ExecuteEvaluateExitCode();
        
        
        this.ExecuteSpace();
        
        
        this.ExecuteAssignDelimit();
        

        this.ExecuteSpace();
        
        
        this.ExecuteOperand(operand);


        
        this.ExecuteSemicolonDelimit();


        
        this.ExecuteNewLine();
        

        
        return true;
    }


    
    
    
    protected virtual bool ExecuteAssignEvaluateStackPointerOffset(Offset offset)
    {
        this.ExecuteIndent(this.StateIndent);


        
        this.ExecuteEvaluateStackPointer();


        this.ExecuteSpace();


        this.ExecuteAssignDelimit();
        
        
        this.ExecuteSpace();


        this.ExecuteEvaluateStackPointerOffset(offset);

        
        
        this.ExecuteSemicolonDelimit();


        
        this.ExecuteNewLine();
        

        
        return true;
    }
    
    
    
    

    protected virtual bool ExecuteAssignVarEvaluateValue(string destVar, Offset offset)
    {
        this.ExecuteIndent(this.StateIndent);



        this.ExecuteVarName(destVar);
        
        
        this.ExecuteSpace();
        
        
        this.ExecuteAssignDelimit();
        

        this.ExecuteSpace();
        
        
        this.ExecuteEvaluateValueAt(offset);


        
        this.ExecuteSemicolonDelimit();


        
        this.ExecuteNewLine();
        

        
        return true;
    }
    
    
    
    
    protected virtual bool ExecuteAssignVarTwoOperandOp(string destVar, string opDelimit, Operand left, Operand right)
    {
        this.ExecuteIndent(this.StateIndent);
        
        
        
        this.ExecuteVarName(destVar);
        
        
        this.ExecuteSpace();
        
        
        this.ExecuteAssignDelimit();
        

        this.ExecuteSpace();



        this.ExecuteTwoOperandOpExpression(opDelimit, left, right);
        
        
        
        this.ExecuteSemicolonDelimit();
        

        
        this.ExecuteNewLine();
        
        
        

        return true;
    }
    



    
    protected virtual bool ExecuteTwoOperandOpExpression(string opDelimit, Operand left, Operand right)
    {
        this.ExecuteBracketLeftDelimit();
        
        
        this.ExecuteOperand(left);
        
        
        this.ExecuteSpace();


        this.ExecuteDelimit(opDelimit);
        
        
        this.ExecuteSpace();


        this.ExecuteOperand(right);
        
        
        this.ExecuteBracketRightDelimit();
        
        

        return true;
    }





    protected virtual bool ExecuteAssignVarOperand(string destVar, Operand operand)
    {
        this.ExecuteExecuteStart();



        this.ExecuteVarName(destVar);


        this.ExecuteSpace();


        this.ExecuteAssignDelimit();


        this.ExecuteSpace();



        this.ExecuteOperand(operand);



        this.ExecuteExecuteEnd();




        return true;
    }





    protected virtual bool ExecuteAssignPointerVarVar(string destVar, string sourceVar)
    {
        this.ExecuteExecuteStart();



        this.ExecuteVarName(destVar);


        this.ExecuteSpace();


        this.ExecuteAssignDelimit();


        this.ExecuteSpace();



        this.ExecuteMethodName(this.MethodCastPointer);


        this.ExecuteBracketLeftDelimit();


        this.ExecuteVarName(sourceVar);


        this.ExecuteBracketRightDelimit();




        this.ExecuteExecuteEnd();




        return true;
    }





    protected virtual bool ExecuteExecuteStart()
    {
        this.ExecuteIndent(this.StateIndent);


        return true;
    }



    protected virtual bool ExecuteExecuteEnd()
    {
        this.ExecuteSemicolonDelimit();


        this.ExecuteNewLine();



        return true;
    }




    protected virtual bool ExecuteGotoLabel(Label label)
    {
        this.ExecuteExecuteStart();


        
        this.ExecuteGotoWord();


        this.ExecuteSpace();


        this.ExecuteLabel(label);




        this.ExecuteExecuteEnd();




        return true;
    }





    protected virtual bool ExecuteGotoVar(string varVar)
    {
        this.ExecuteExecuteStart();




        this.ExecuteGotoWord();


        this.ExecuteSpace();



        this.ExecuteDelimit(this.DelimitAsterisk);


        this.ExecuteVarName(varVar);




        this.ExecuteExecuteEnd();




        return true;
    }




    protected virtual bool ExecuteLabelPointer(Label label)
    {
        this.ExecuteDelimit(this.DelimitAnd);


        this.ExecuteDelimit(this.DelimitAnd);


        this.ExecuteLabel(label);



        return true;
    }




    protected virtual bool SetLabelReturn(Label label)
    {
        label.Return = true;


        label.BlockStart = false;

        label.BlockCond = false;

        label.BlockEnd = false;


        label.Index = -1;


        return true;
    }




    protected virtual bool SetLabelBlock(Label label, bool start, bool cond, bool end, long index)
    {
        label.Return = false;


        label.BlockStart = start;

        label.BlockCond = cond;

        label.BlockEnd = end;


        label.Index = index;


        return true;
    }




    protected virtual bool ExecuteLabelLine(Label label)
    {
        this.ExecuteLabel(label);



        this.ExecuteColonDelimit();



        this.ExecuteNewLine();




        return true;
    }




    protected virtual bool ExecuteLabel(Label label)
    {
        this.ExecuteString("L");


        this.ExecuteCombine();




        bool b;

        b = label.Return;


        if (b)
        {
            this.ExecuteString("Ret");
        }



        if (!b)
        {
            this.ExecuteString("Block");


            this.ExecuteCombine();


            this.ExecuteIntValueHex(label.Index);


            this.ExecuteCombine();



            string k;

            k = null;



            if (label.BlockStart)
            {
                k = "Start";
            }


            if (label.BlockCond)
            {
                k = "Cond";
            }

            if (label.BlockEnd)
            {
                k = "End";
            }


            this.ExecuteString(k);
        }



        return true;
    }
    




    protected virtual bool ExecuteDeclareVar(string varVar)
    {
        this.ExecuteIndent(this.StateIndent);



        this.ExecuteIntTypeName();


        this.ExecuteSpace();


        this.ExecuteVarName(varVar);



        this.ExecuteSemicolonDelimit();



        this.ExecuteNewLine();





        return true;
    }
    
    
    
    
    
    protected virtual bool ExecuteStateEvaluateValueAt(Offset offset)
    {
        this.ExecuteBracketLeftDelimit();

        
        
        this.ExecuteDelimit(this.DelimitAsterisk);
        
        
        
        this.ExecuteStateEvaluateStackPointerOffset(offset);

        
        
        this.ExecuteBracketRightDelimit();

        

        return true;
    }
    
    
    
    
    protected virtual bool ExecuteStateEvaluateStackPointerOffset(Offset offset)
    {
        this.ExecuteBracketLeftDelimit();
        
        
        
        this.ExecuteStateEvaluateStackPointer();


        this.ExecuteSpace();


        this.ExecuteOffset(offset);
        
        
        
        this.ExecuteBracketRightDelimit();

        

        return true;
    }
    
    
    
    
    protected virtual bool ExecuteStateEvaluateStackPointer()
    {
        this.ExecuteStateEvaluateStackPointerVarName();
        

        return true;
    }
    
    
    
    
    protected virtual bool ExecuteEvaluateValueAt(Offset offset)
    {
        this.ExecuteBracketLeftDelimit();

        
        
        this.ExecuteDelimit(this.DelimitAsterisk);
        
        
        
        this.ExecuteEvaluateStackPointerOffset(offset);

        
        
        this.ExecuteBracketRightDelimit();

        

        return true;
    }
    
    


    
    protected virtual bool ExecuteEvaluateStackPointerOffset(Offset offset)
    {
        this.ExecuteBracketLeftDelimit();
        
        
        
        this.ExecuteEvaluateStackPointer();


        this.ExecuteSpace();


        this.ExecuteOffset(offset);
        
        
        
        this.ExecuteBracketRightDelimit();

        

        return true;
    }
    
    
    
    

    protected virtual bool ExecuteEvaluateStackPointer()
    {
        this.ExecuteEvaluateVarName();


        this.ExecuteMemberDelimit();


        this.ExecuteEvaluateStackPointerFieldName();


        return true;
    }
    
    
    
    
    protected virtual bool ExecuteEvaluateStackEndAddress()
    {
        this.ExecuteEvaluateVarName();


        this.ExecuteMemberDelimit();


        this.ExecuteEvaluateStackEndAddressFieldName();


        return true;
    }
    
    
    
    
    protected virtual bool ExecuteEvaluateExitCode()
    {
        this.ExecuteEvaluateVarName();


        this.ExecuteMemberDelimit();


        this.ExecuteEvaluateExitCodeFieldName();


        return true;
    }
    
    
    
    
    protected virtual bool ExecuteEvaluateTypeName()
    {
        return this.ExecuteTypeName("E");
    }
    
    
    
    protected virtual bool ExecuteEvaluateStackPointerFieldName()
    {
        return this.ExecuteFieldName("P");
    }
    
    
    
    protected virtual bool ExecuteEvaluateStackEndAddressFieldName()
    {
        return this.ExecuteFieldName("PE");
    }
    
    
    
    protected virtual bool ExecuteEvaluateExitCodeFieldName()
    {
        return this.ExecuteFieldName("E");
    }
    

    
    protected virtual bool ExecuteEvaluateVarName()
    {
        return this.ExecuteVarName("a");
    }
    

    
    protected virtual bool ExecuteStateEvaluateStackPointerVarName()
    {
        return this.ExecuteVarName("o");
    }
    
    

    
    protected virtual bool SetOperandVar(Operand operand, string varVar)
    {
        operand.Var = varVar;

        operand.Int64Bit = null;

        operand.Macro = null;


        return true;
    }
    
    
    
    protected virtual bool SetOperandInt64Bit(Operand operand, Int64Bit a)
    {
        operand.Var = null;

        operand.Int64Bit = a;

        operand.Macro = null;


        return true;
    }
    
    
    
    protected virtual bool SetOperandMacro(Operand operand, string macro)
    {
        operand.Var = null;

        operand.Int64Bit = null;

        operand.Macro = macro;


        return true;
    }
    
    
    
    protected virtual bool SetOffset(Offset offset, bool subtract, long count)
    {
        offset.Subtract = subtract;

        offset.Count = count;


        return true;
    }
    
    
    
    
    protected virtual bool SetInt64Bit(Int64Bit o, int upper4Bit, long lower60Bit)
    {
        o.Upper4Bit = upper4Bit;

        o.Lower60Bit = lower60Bit;


        return true;
    }
    
    

    
    protected virtual bool ExecuteIndent(int count)
    {
        int i;

        i = 0;


        while (i < count)
        {
            this.ExecuteString(this.IndentString);
            

            i = i + 1;
        }
        

        return true;
    }




    protected virtual bool ExecuteOffset(Offset offset)
    {
        string k;

        k = null;


        bool b;

        b = offset.Subtract;
        
        
        if (b)
        {
            k = this.DelimitSubtract;
        }

        if (!b)
        {
            k = this.DelimitAdd;
        }
        
        

        this.ExecuteDelimit(k);

        
        this.ExecuteSpace();


        this.ExecuteIntValueHex(offset.Count);
        
        
        

        return true;
    }



    
    protected virtual bool ExecuteOperand(Operand operand)
    {
        bool b;

        b = (operand.Var == null);


        if (b)
        {
            bool ba;

            ba = (operand.Int64Bit == null);


            if (ba)
            {
                this.ExecuteMacroName(operand.Macro);
            }

            if (!ba)
            {
                this.ExecuteIntValue64BitHex(operand.Int64Bit);
            }
        }


        if (!b)
        {
            this.ExecuteVarName(operand.Var);
        }


        return true;
    }

    
    
    
    
    
    protected virtual bool ExecuteMemberDelimit()
    {
        return this.ExecuteDelimit("->");
    }
    
    
    protected virtual bool ExecuteAssignDelimit()
    {
        return this.ExecuteDelimit("=");
    }
    
    
    
    protected virtual bool ExecuteBraceLeftDelimit()
    {
        return this.ExecuteDelimit("{");
    }
    
    
    protected virtual bool ExecuteBraceRightDelimit()
    {
        return this.ExecuteDelimit("}");
    }
    
    
    
    protected virtual bool ExecuteBracketLeftDelimit()
    {
        return this.ExecuteDelimit("(");
    }
    
    
    protected virtual bool ExecuteBracketRightDelimit()
    {
        return this.ExecuteDelimit(")");
    }
    
    
    
    protected virtual bool ExecuteSquareBracketLeftDelimit()
    {
        return this.ExecuteDelimit("[");
    }
    
    
    protected virtual bool ExecuteSquareBracketRightDelimit()
    {
        return this.ExecuteDelimit("]");
    }
    
    
    
    protected virtual bool ExecuteCommaDelimit()
    {
        return this.ExecuteDelimit(",");
    }



    protected virtual bool ExecuteColonDelimit()
    {
        return this.ExecuteDelimit(":");
    }

    
    
    protected virtual bool ExecuteSemicolonDelimit()
    {
        return this.ExecuteDelimit(";");
    }

    

    protected virtual bool ExecuteDelimit(string delimit)
    {
        return this.ExecuteString(delimit);
    }


    
    protected virtual bool ExecuteCombine()
    {
        return this.ExecuteString(this.Combine);
    }
    
    
    
    protected virtual bool ExecuteSpace()
    {
        return this.ExecuteString(this.SpaceString);
    }
    
    
    
    protected virtual bool ExecuteNewLine()
    {
        return this.ExecuteString("\n");
    }
    
    
    
    
    protected virtual bool ExecuteIntTypeName()
    {
        return this.ExecuteTypeName(this.Stat.IntTypeName);
    }
    

    
    protected virtual bool ExecuteBoolTypeName()
    {
        return this.ExecuteTypeName(this.Stat.BoolTypeName);
    }
    

    
    protected virtual bool ExecuteSIntTypeName()
    {
        return this.ExecuteTypeName(this.Stat.SIntTypeName);
    }
    
    
    
    protected virtual bool ExecuteByteTypeName()
    {
        return this.ExecuteTypeName(this.Stat.ByteTypeName);
    }
    
    
    
    protected virtual bool ExecuteCharTypeName()
    {
        return this.ExecuteTypeName(this.Stat.CharTypeName);
    }
    
    
    
    protected virtual bool ExecuteTypeName(string name)
    {
        return this.ExecuteString(name);
    }
    
    
    protected virtual bool ExecuteFieldName(string name)
    {
        return this.ExecuteString(name);
    }
    
    
    
    protected virtual bool ExecuteMethodName(string name)
    {
        return this.ExecuteString(name);
    }
    
    

    protected virtual bool ExecuteVarName(string name)
    {
        return this.ExecuteString(name);
    }
    
    
    protected virtual bool ExecuteMacroName(string name)
    {
        return this.ExecuteString(name);
    }
    


    protected virtual bool ExecuteReturnWord()
    {
        return this.ExecuteWord(this.Stat.ReturnWord);
    }



    protected virtual bool ExecuteGotoWord()
    {
        return this.ExecuteWord(this.Stat.GotoWord);
    }




    protected virtual bool ExecuteWord(string word)
    {
        this.ExecuteString(word);


        return true;
    }
    




    protected virtual bool ExecuteString(string a)
    {
        int count;

        count = a.Length;

        
        int i;

        i = 0;


        while (i < count)
        {
            char oc;

            oc = a[i];


            this.ExecuteChar(oc);
            
            
            i = i + 1;
        }


        return true;
    }
    
    
    
    
    protected virtual bool ExecuteIntValue64BitHex(Int64Bit value)
    {
        this.ExecuteChar('0');
        
        
        this.ExecuteChar('x');



        char oc;

        oc = this.GetDigitHex(value.Upper4Bit);


        
        this.WriteOperate.ExecuteChar(oc);
        
        
        
        this.WriteOperate.ExecuteIntValueHex(value.Lower60Bit);
        
        
        
        return true;
    }


    
    
    protected virtual char GetDigitHex(int a)
    {
        int k;
        
        k = -1;
        
        
        
        bool b;

        b = (a < 10);

        
        if (b)
        {
            k = '0' + a;
        }
        

        if (!b)
        {
            int oo;

            oo = a - 10;


            k = 'a' + oo;
        }


        char oc;

        oc = (char)k;


        return oc;
    }
    
    
    
    

    protected virtual bool ExecuteIntValueHex(long a)
    {
        this.ExecuteChar('0');
        
        
        this.ExecuteChar('x');
        
        
        
        this.WriteOperate.ExecuteIntValueHex(a);
        
        
        
        return true;
    }

    

    protected virtual bool ExecuteChar(char oc)
    {
        this.WriteOperate.ExecuteChar(oc);

        
        return true;
    }
}