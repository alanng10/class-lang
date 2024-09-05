namespace Class.Console;

public class ClassGen : ClassInfraGen
{
    public override bool Init()
    {
        base.Init();
        this.ClassInfra = ClassInfra.This;

        this.CountOperate = new CountClassGenOperate();
        this.CountOperate.Gen = this;
        this.CountOperate.Init();
        this.SetOperate = new SetClassGenOperate();
        this.SetOperate.Gen = this;
        this.SetOperate.Init();

        this.Traverse = new ClassGenTraverse();
        this.Traverse.Gen = this;
        this.Traverse.Init();

        this.StateKindGet = 0;
        this.StateKindSet = 1;
        this.StateKindCall = 2;

        this.Space = this.S(" ");
        this.NewLine = this.S("\n");
        this.Zero = this.S("0");
        String k;
        k = this.S("v");
        this.VarA = this.InitVar(k, "A");
        this.VarB = this.InitVar(k, "B");
        this.VarC = this.InitVar(k, "C");
        this.VarD = this.InitVar(k, "D");
        this.VarSA = this.InitVar(k, "SA");
        this.VarSB = this.InitVar(k, "SB");
        this.Eval = this.S("e");
        this.EvalStackVar = this.S("S");
        this.EvalIndexVar = this.S("N");
        this.EvalFrameVar = this.S("f");
        this.IntValuePre = this.S("0x");
        this.IntValuePost = this.S("ULL");
        this.BaseBitRightCount = this.S("52");
        this.RefKindClearMask = this.S("0x0fffffffffffffff");
        this.RefKindBoolMask = this.S("0x2000000000000000");
        this.RefKindIntMask = this.S("0x3000000000000000");
        this.BaseClearMask = this.S("0xf00fffffffffffff");
        this.BaseMask = this.S("0x0ff0000000000000");
        this.MemoryIndexMask = this.S("0x000fffffffffffff");
        this.ClassInt = this.S("Int");
        this.ClassCompState = this.S("CompState");
        this.StateGet = this.S("G");
        this.StateSet = this.S("S");
        this.StateCall = this.S("C");
        this.NameCombine = this.S("_");
        this.KeywordReturn = this.S("return");
        this.LimitDot = this.S(".");
        this.LimitDotPointer = this.S("->");
        this.LimitBraceLite = this.S("{");
        this.LimitBraceRite = this.S("}");
        this.LimitBraceRoundLite = this.S("(");
        this.LimitBraceRoundRite = this.S(")");
        this.LimitBraceSquareLite = this.S("[");
        this.LimitBraceSquareRite = this.S("]");
        this.LimitSemicolon = this.S(";");
        this.LimitComma = this.S(",");
        this.LimitAsterisk = this.S("*");
        this.LimitAre = this.S("=");
        this.LimitSame = this.S("==");
        this.LimitLess = this.S("<");
        this.DelimitAnd = this.S("&");
        this.DelimitOrn = this.S("|");
        this.DelimitNot = this.S("!");
        this.DelimitAdd = this.S("+");
        this.DelimitSub = this.S("-");
        this.DelimitMul = this.S("*");
        this.DelimitDiv = this.S("/");
        this.DelimitBitNot = this.S("~");
        this.DelimitBitLeft = this.S("<<");
        this.DelimitBitRight = this.S(">>");
        return true;
    }

    public virtual ClassClass Class { get; set; }
    public virtual Table ModuleTable { get; set; }
    public virtual bool Export { get; set; }
    public virtual Table ClassImportName { get; set; }
    public virtual Table ClassShare { get; set; }
    public virtual ClassClass NullClass { get; set; }
    public virtual BuiltinClass System { get; set; }
    public virtual GenArg Arg { get; set; }
    public virtual ClassGenOperate Operate { get; set; }
    public virtual String Result { get; set; }
    public virtual ClassInfra ClassInfra { get; set; }
    public virtual CountClassGenOperate CountOperate { get; set; }
    public virtual SetClassGenOperate SetOperate { get; set; }
    public virtual ClassGenTraverse Traverse { get; set; }
    public virtual long BaseIndex { get; set; }
    public virtual String ClassBaseMask { get; set; }
    public virtual Field ThisField { get; set; }
    public virtual long CompStateKind { get; set; }
    public virtual long ParamCount { get; set; }
    public virtual long LocalVarCount { get; set; }
    public virtual long IndentCount { get; set; }
    public virtual Data BlockStack { get; set; }
    public virtual long BlockStackIndex { get; set; }
    public virtual long StateKindGet { get; set; }
    public virtual long StateKindSet { get; set; }
    public virtual long StateKindCall { get; set; }
    public virtual String Space { get; set; }
    public virtual String NewLine { get; set; }
    public virtual String Zero { get; set; }
    public virtual String VarA { get; set; }
    public virtual String VarB { get; set; }
    public virtual String VarC { get; set; }
    public virtual String VarD { get; set; }
    public virtual String VarSA { get; set; }
    public virtual String VarSB { get; set; }
    public virtual String Eval { get; set; }
    public virtual String EvalStackVar { get; set; }
    public virtual String EvalIndexVar { get; set; }
    public virtual String EvalFrameVar { get; set; }
    public virtual String IntValuePre { get; set; }
    public virtual String IntValuePost { get; set; }
    public virtual String BaseBitRightCount { get; set; }
    public virtual String RefKindClearMask { get; set; }
    public virtual String RefKindBoolMask { get; set; }
    public virtual String RefKindIntMask { get; set; }
    public virtual String BaseClearMask { get; set; }
    public virtual String BaseMask { get; set; }
    public virtual String MemoryIndexMask { get; set; }
    public virtual String ClassInt { get; set; }
    public virtual String ClassCompState { get; set; }
    public virtual String StateGet { get; set; }
    public virtual String StateSet { get; set; }
    public virtual String StateCall { get; set; }
    public virtual String NameCombine { get; set; }
    public virtual String KeywordReturn { get; set; }
    public virtual String LimitDot { get; set; }
    public virtual String LimitDotPointer { get; set; }
    public virtual String LimitBraceLite { get; set; }
    public virtual String LimitBraceRite { get; set; }
    public virtual String LimitBraceRoundLite { get; set; }
    public virtual String LimitBraceRoundRite { get; set; }
    public virtual String LimitBraceSquareLite { get; set; }
    public virtual String LimitBraceSquareRite { get; set; }
    public virtual String LimitSemicolon { get; set; }
    public virtual String LimitComma { get; set; }
    public virtual String LimitAsterisk { get; set; }
    public virtual String LimitAre { get; set; }
    public virtual String LimitSame { get; set; }
    public virtual String LimitLess { get; set; }
    public virtual String DelimitAnd { get; set; }
    public virtual String DelimitOrn { get; set; }
    public virtual String DelimitNot { get; set; }
    public virtual String DelimitAdd { get; set; }
    public virtual String DelimitSub { get; set; }
    public virtual String DelimitMul { get; set; }
    public virtual String DelimitDiv { get; set; }
    public virtual String DelimitBitNot { get; set; }
    public virtual String DelimitBitLeft { get; set; }
    public virtual String DelimitBitRight { get; set; }

    public virtual bool Execute()
    {
        long k;
        k = this.BaseIndexGet();
        
        if (!this.ValidBaseIndex(k))
        {
            return false;
        }

        this.BaseIndex = k;

        this.ClassBaseMask = this.ClassBaseMaskGet(k);

        this.Arg = new GenArg();
        this.Arg.Init();

        this.Operate = this.CountOperate;

        this.ResetStageIndex();
        this.ExecuteStage();

        long nn;
        nn = this.Arg.Index;
        nn = nn * sizeof(uint);
        Data data;
        data = new Data();
        data.Count = nn;
        data.Init();
        this.Arg.Data = data;

        this.Operate = this.SetOperate;

        this.ResetStageIndex();
        this.ExecuteStage();

        this.Operate = null;
        this.Arg = null;

        String o;
        o = this.StringComp.CreateData(data, null);

        this.Result = o;
        return true;
    }

    public virtual bool ResetStageIndex()
    {
        this.Arg.Index = 0;
        return true;
    }

    public virtual bool ExecuteStage()
    {
        NodeClass nodeClass;
        nodeClass = (NodeClass)this.Class.Any;

        this.Traverse.ExecuteClass(nodeClass);
        return true;
    }

    public virtual bool ExecuteVirtualCall(long thisEvalIndex, long stateKind, long stateIndex)
    {
        String varA;
        String varB;
        String varC;
        String varD;
        varA = this.VarA;
        varB = this.VarB;
        varC = this.VarC;
        varD = this.VarD;

        this.EvalValueGet(thisEvalIndex, varA);

        this.VarSet(varB, varA);

        this.VarMaskClear(varA, this.MemoryIndexMask);

        this.VarSetDeref(varA, varA, 0);

        this.VarSetDeref(varC, varA, 0);

        this.VarSet(varD, varB);

        this.VarMaskClear(varD, this.BaseMask);

        this.OperateDelimit(varD, varD, this.BaseBitRightCount, this.DelimitBitRight);

        this.VarSetDerefVar(varC, varC, varD);

        this.VarSetDeref(varC, varC, stateKind);

        this.VarSetDeref(varC, varC, stateIndex);

        this.VarSetDeref(varD, varA, 1);

        this.VarMaskClear(varB, this.BaseClearMask);

        this.VarMaskSet(varB, varD);

        this.EvalValueSet(thisEvalIndex, varB);

        this.CallCompState(varC);
        return true;
    }

    public virtual bool ExecuteVarGet(Var varVar)
    {
        String varA;
        varA = this.VarA;

        long stateKind;
        stateKind = this.CompStateKind;

        long k;
        k = this.ParamCount;

        long kk;
        kk = varVar.Index;

        if (stateKind == this.StateKindGet)
        {
            bool ba;
            ba = (kk == 0);

            if (ba)
            {
                this.ExecuteThisFieldData();

                this.VarSetDeref(varA, varA, 0);
            }

            if (!ba)
            {
                long posA;
                posA = kk - 1;

                this.EvalFrameValueGet(posA, varA);
            }
        }

        if (stateKind == this.StateKindSet)
        {
            bool bc;
            bc = (kk == 0);
            bool bd;
            bd = (kk == 1);

            if (bc)
            {
                this.ExecuteThisFieldData();

                this.VarSetDeref(varA, varA, 0);
            }

            if (bd)
            {
                long posB;
                posB = -1;

                this.EvalFrameValueGet(posB, varA);
            }

            if (!(bc | bd))
            {
                long posC;
                posC = kk - 2;

                this.EvalFrameValueGet(posC, varA);
            }
        }

        if (stateKind == this.StateKindCall)
        {
            long ka;
            ka = k - 1;

            bool b;
            b = (kk < ka);
            if (b)
            {
                long kkk;
                kkk = ka - kk;
                kkk = -kkk;

                long posD;
                posD = kkk;

                this.EvalFrameValueGet(posD, varA);
            }

            if (!b)
            {
                long posE;
                posE = kk - ka;

                this.EvalFrameValueGet(posE, varA);
            }
        }

        this.EvalValueSet(0, varA);

        this.EvalIndexPosSet(1);

        return true;
    }

    public virtual bool ExecuteVarSet(Var varVar)
    {
        String varA;
        String varB;
        varA = this.VarA;
        varB = this.VarB;

        long stateKind;
        stateKind = this.CompStateKind;

        long k;
        k = this.ParamCount;

        long kk;
        kk = varVar.Index;

        this.EvalValueSet(1, varB);

        if (stateKind == this.StateKindGet)
        {
            bool ba;
            ba = (kk == 0);

            if (ba)
            {
                this.ExecuteThisFieldData();

                this.VarDerefSet(varA, varB);
            }

            if (!ba)
            {
                long posA;
                posA = kk - 1;

                this.EvalFrameValueSet(posA, varB);
            }
        }

        if (stateKind == this.StateKindSet)
        {
            bool bc;
            bc = (kk == 0);
            bool bd;
            bd = (kk == 1);

            if (bc)
            {
                this.ExecuteThisFieldData();

                this.VarDerefSet(varA, varB);
            }

            if (bd)
            {
                long posB;
                posB = -1;

                this.EvalFrameValueSet(posB, varB);
            }

            if (!(bc | bd))
            {
                long posC;
                posC = kk - 2;

                this.EvalFrameValueSet(posC, varB);
            }
        }

        if (stateKind == this.StateKindCall)
        {
            long ka;
            ka = k - 1;

            bool b;
            b = (kk < ka);
            if (b)
            {
                long kkk;
                kkk = ka - kk;
                kkk = -kkk;

                long posD;
                posD = kkk;

                this.EvalFrameValueSet(posD, varB);
            }

            if (!b)
            {
                long posE;
                posE = kk - ka;

                this.EvalFrameValueSet(posE, varB);
            }
        }

        this.EvalIndexPosSet(-1);

        return true;
    }

    public virtual bool ExecuteThisFieldData()
    {
        String varA;
        varA = this.VarA;

        Field varField;
        varField = this.ThisField;

        ClassClass varClass;
        varClass = this.Class;

        long k;
        k = this.ParamCount;
        k = -k;

        long kk;
        kk = varClass.FieldRange.Index;
        kk = kk + varField.BinaryIndex;

        this.EvalFrameValueGet(k, varA);

        this.ExecuteFieldData(varA, kk);

        return true;
    }

    public virtual bool ExecuteFieldData(String varVar, long fieldIndex)
    {
        long kk;
        kk = fieldIndex;
        kk = kk + 1;

        long pos;
        pos = kk * sizeof(ulong);

        this.VarMaskClear(varVar, this.MemoryIndexMask);

        this.VarSetPos(varVar, varVar, pos);
        return true;
    }

    public virtual bool ExecuteOperateDelimit(String delimit)
    {
        String varA;
        String varB;
        varA = this.VarA;
        varB = this.VarB;

        String ka;
        ka = this.RefKindClearMask;

        this.EvalValueGet(2, varA);
        this.EvalValueGet(1, varB);

        this.VarMaskClear(varA, ka);
        this.VarMaskClear(varB, ka);

        this.OperateDelimit(varA, varA, varB, delimit);

        this.VarMaskClear(varA, ka);

        this.VarMaskSet(varA, this.RefKindIntMask);

        this.EvalValueSet(2, varA);

        this.EvalIndexPosSet(-1);

        return true;
    }

    public virtual bool ExecuteOperateDelimitAA(String delimit)
    {
        String varA;
        String varB;
        varA = this.VarA;
        varB = this.VarB;

        String ka;
        ka = this.RefKindClearMask;

        this.EvalValueGet(2, varA);
        this.EvalValueGet(1, varB);

        this.VarMaskClear(varB, ka);

        this.OperateDelimit(varA, varA, varB, delimit);

        this.VarMaskClear(varA, ka);

        this.VarMaskSet(varA, this.RefKindIntMask);

        this.EvalValueSet(2, varA);

        this.EvalIndexPosSet(-1);

        return true;
    }

    public virtual bool ExecuteOperateDelimitAB(String delimit)
    {
        String varA;
        String varB;
        varA = this.VarA;
        varB = this.VarB;

        String ka;
        ka = this.RefKindClearMask;

        this.EvalValueGet(2, varA);
        this.EvalValueGet(1, varB);

        this.VarMaskClear(varA, ka);
        this.VarMaskClear(varB, ka);

        this.OperateDelimit(varA, varA, varB, delimit);

        this.VarMaskSet(varA, this.RefKindIntMask);

        this.EvalValueSet(2, varA);

        this.EvalIndexPosSet(-1);

        return true;
    }

    public virtual bool ExecuteOperateDelimitA(String delimit)
    {
        String varA;
        String varB;
        varA = this.VarA;
        varB = this.VarB;

        this.EvalValueGet(2, varA);
        this.EvalValueGet(1, varB);

        this.OperateDelimit(varA, varA, varB, delimit);

        this.VarMaskSet(varA, this.RefKindIntMask);

        this.EvalValueSet(2, varA);

        this.EvalIndexPosSet(-1);

        return true;
    }

    public virtual bool ExecuteOperateDelimitBool(String delimit)
    {
        String varA;
        String varB;
        varA = this.VarA;
        varB = this.VarB;

        this.EvalValueGet(2, varA);
        this.EvalValueGet(1, varB);

        this.OperateDelimit(varA, varA, varB, delimit);

        this.VarMaskSet(varA, this.RefKindBoolMask);

        this.EvalValueSet(2, varA);

        this.EvalIndexPosSet(-1);

        return true;
    }

    public virtual bool ExecuteOperateDelimitBoolOne(String delimit)
    {
        String varA;
        varA = this.VarA;

        String ka;
        ka = this.RefKindClearMask;

        this.EvalValueGet(1, varA);

        this.VarMaskClear(varA, ka);

        this.OperateDelimitOne(varA, varA, delimit);

        this.VarMaskSet(varA, this.RefKindBoolMask);

        this.EvalValueSet(1, varA);

        return true;
    }

    public virtual bool OperateDelimit(String dest, String left, String right, String delimit)
    {
        String space;
        space = this.Space;

        this.TextIndent();

        this.Text(dest);
        
        this.Text(space);
        this.Text(this.LimitAre);
        this.Text(space);

        this.Text(left);

        this.Text(space);
        this.Text(delimit);
        this.Text(space);

        this.Text(right);

        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool OperateDelimitOne(String dest, String value, String delimit)
    {
        this.TextIndent();

        this.Text(dest);

        this.Text(this.Space);
        this.Text(this.LimitAre);
        this.Text(this.Space);

        this.Text(delimit);
        this.Text(this.Space);

        this.Text(value);

        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool Return()
    {
        this.TextIndent();

        this.Text(this.KeywordReturn);

        this.Text(this.Space);

        this.Text(this.Zero);

        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool CallCompState(String compState)
    {
        String kk;
        kk = this.Space;

        String ka;
        String kb;
        ka = this.LimitBraceRoundLite;
        kb = this.LimitBraceRoundRite;

        this.TextIndent();

        this.Text(ka);

        this.Text(ka);
        this.Text(this.ClassCompState);
        this.Text(kb);

        this.Text(compState);

        this.Text(kb);

        this.Text(ka);
        this.Text(this.Eval);

        this.Text(this.LimitComma);
        this.Text(kk);

        this.EvalIndex();
    
        this.Text(kb);

        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool VarSet(String dest, String value)
    {
        this.TextIndent();

        this.Text(dest);

        this.Text(this.Space);
        this.Text(this.LimitAre);
        this.Text(this.Space);

        this.Text(value);

        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool VarSetPos(String dest, String value, long pos)
    {
        this.TextIndent();

        this.Text(dest);

        this.Text(this.Space);
        this.Text(this.LimitAre);
        this.Text(this.Space);

        this.Text(value);

        this.Text(this.Space);

        this.TextPos(pos);

        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool VarSetDeref(String dest, String value, long pos)
    {
        String ka;
        String kb;
        ka = this.LimitBraceRoundLite;
        kb = this.LimitBraceRoundRite;

        this.TextIndent();

        this.Text(dest);

        this.Text(this.Space);
        this.Text(this.LimitAre);
        this.Text(this.Space);

        this.Text(this.LimitAsterisk);

        this.Text(ka);

        this.Text(ka);

        this.Text(ka);
        this.Text(this.ClassInt);
        this.Text(this.LimitAsterisk);
        this.Text(kb);

        this.Text(value);

        this.Text(kb);

        this.Text(this.Space);

        this.TextPos(pos);

        this.Text(kb);

        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool VarSetDerefVar(String dest, String value, String varPos)
    {
        String ka;
        String kb;
        ka = this.LimitBraceRoundLite;
        kb = this.LimitBraceRoundRite;

        this.TextIndent();

        this.Text(dest);

        this.Text(this.Space);
        this.Text(this.LimitAre);
        this.Text(this.Space);

        this.Text(this.LimitAsterisk);

        this.Text(ka);

        this.Text(ka);

        this.Text(ka);
        this.Text(this.ClassInt);
        this.Text(this.LimitAsterisk);
        this.Text(kb);

        this.Text(value);

        this.Text(kb);

        this.Text(this.Space);
        this.Text(this.DelimitAdd);
        this.Text(this.Space);

        this.Text(varPos);

        this.Text(kb);

        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool VarDerefSet(String dest, String value)
    {
        String ka;
        String kb;
        ka = this.LimitBraceRoundLite;
        kb = this.LimitBraceRoundRite;

        this.TextIndent();

        this.Text(this.LimitAsterisk);

        this.Text(ka);

        this.Text(ka);
        this.Text(this.ClassInt);
        this.Text(this.LimitAsterisk);
        this.Text(kb);

        this.Text(dest);

        this.Text(kb);

        this.Text(this.Space);
        this.Text(this.LimitAre);
        this.Text(this.Space);

        this.Text(value);

        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool VarMaskClear(String varVar, String mask)
    {
        this.TextIndent();

        this.Text(varVar);

        this.Text(this.Space);
        this.Text(this.LimitAre);
        this.Text(this.Space);

        this.Text(varVar);

        this.Text(this.Space);
        this.Text(this.DelimitAnd);
        this.Text(this.Space);

        this.Text(mask);

        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool VarMaskSet(String varVar, String mask)
    {
        this.TextIndent();

        this.Text(varVar);

        this.Text(this.Space);
        this.Text(this.LimitAre);
        this.Text(this.Space);

        this.Text(varVar);

        this.Text(this.Space);
        this.Text(this.DelimitOrn);
        this.Text(this.Space);

        this.Text(mask);

        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool EvalValueGet(long index, String varVar)
    {
        this.TextIndent();
        
        this.Text(varVar);

        this.Text(this.Space);
        this.Text(this.LimitAre);
        this.Text(this.Space);
        
        this.EvalValue(index);
        
        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool EvalValueSet(long index, String varVar)
    {
        this.TextIndent();

        this.EvalValue(index);

        this.Text(this.Space);
        this.Text(this.LimitAre);
        this.Text(this.Space);

        this.Text(varVar);

        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool EvalValue(long index)
    {
        this.EvalStack();
        
        this.Text(this.LimitBraceSquareLite);
        
        this.EvalIndex();

        this.Text(this.Space);
        this.Text(this.DelimitSub);
        this.Text(this.Space);
        
        this.TextInt(index);
        
        this.Text(this.LimitBraceSquareRite);
        return true;
    }

    public virtual bool EvalFrameValueGet(long pos, String arg)
    {
        this.TextIndent();

        this.Text(arg);

        this.Text(this.Space);
        this.Text(this.LimitAre);
        this.Text(this.Space);

        this.EvalFrameValue(pos);

        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool EvalFrameValueSet(long pos, String arg)
    {
        this.TextIndent();

        this.EvalFrameValue(pos);

        this.Text(this.Space);
        this.Text(this.LimitAre);
        this.Text(this.Space);

        this.Text(arg);

        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool EvalFrameValue(long pos)
    {
        this.EvalStack();

        this.Text(this.LimitBraceSquareLite);

        this.Text(this.EvalFrameVar);

        this.Text(this.Space);

        this.TextPos(pos);

        this.Text(this.LimitBraceSquareRite);
        return true;
    }

    public virtual bool EvalIndexPosSet(long pos)
    {
        this.TextIndent();

        this.EvalIndex();

        this.Text(this.Space);
        this.Text(this.LimitAre);
        this.Text(this.Space);

        this.EvalIndex();

        this.Text(this.Space);

        this.TextPos(pos);

        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool EvalStack()
    {
        this.Text(this.Eval);
        this.Text(this.LimitDotPointer);
        this.Text(this.EvalStackVar);
        return true;
    }

    public virtual bool EvalIndex()
    {
        this.Text(this.Eval);
        this.Text(this.LimitDotPointer);
        this.Text(this.EvalIndexVar);
        return true;
    }

    public virtual bool FieldGetMaideName(Field varField)
    {
        return this.CompStateMaideName(varField.Parent, varField.Name, this.StateGet);
    }

    public virtual bool FieldSetMaideName(Field varField)
    {
        return this.CompStateMaideName(varField.Parent, varField.Name, this.StateSet);
    }

    public virtual bool MaideCallMaideName(Maide varMaide)
    {
        return this.CompStateMaideName(varMaide.Parent, varMaide.Name, this.StateCall);
    }

    public virtual bool CompStateMaideName(ClassClass varClass, String compName, String state)
    {
        this.ClassName(varClass);

        this.Text(this.NameCombine);

        this.NameSymbolString(compName);

        this.Text(this.NameCombine);

        this.Text(state);
        return true;
    }

    public virtual bool ClassName(ClassClass varClass)
    {
        this.ModuleRef(varClass.Module.Ref);

        this.Text(this.NameCombine);

        this.NameSymbolString(varClass.Name);
        return true;
    }

    public virtual bool ModuleRef(ModuleRef moduleRef)
    {
        this.NameSymbolString(moduleRef.Name);
        
        this.Text(this.NameCombine);

        this.TextInt(moduleRef.Version);
        return true;
    }

    public virtual bool NameSymbolString(String name)
    {
        long letterStart;
        letterStart = 'a';

        long count;
        count = this.StringCount(name);
        long i;
        i = 0;
        while (i < count)
        {
            long oc;
            oc = this.StringChar(name, i);

            long k;
            k = oc & 0xff;

            long lowerHex;
            lowerHex = k & 0xf;

            long upperHex;
            upperHex = k >> 4;

            long ka;
            long kb;
            ka = this.TextInfra.DigitChar(upperHex, letterStart);
            kb = this.TextInfra.DigitChar(lowerHex, letterStart);

            this.ExecuteChar(ka);
            this.ExecuteChar(kb);

            i = i + 1;
        }

        return true;
    }
    
    public virtual bool ModuleVer(long ver)
    {
        this.Operate.ExecuteIntFormat(ver);
        return true;
    }

    public virtual bool TextPos(long n)
    {
        bool b;
        b = (n < 0);

        String ka;
        ka = this.DelimitAdd;

        long k;
        k = n;
        
        if (b)
        {
            k = -k;

            ka = this.DelimitSub;
        }

        this.Text(ka);
        this.Text(this.Space);
        this.TextInt(k);
        return true;
    }

    public virtual bool TextInt(long n)
    {
        this.Text(this.IntValuePre);
        
        this.Operate.ExecuteIntFormat(n);

        this.Text(this.IntValuePost);
        return true;
    }

    public virtual bool TextIndent()
    {
        String indent;
        indent = this.Indent;
        long count;
        count = this.IndentCount;
        long i;
        i = 0;
        while (i < count)
        {
            this.Text(indent);
            i = i + 1;
        }
        return true;
    }

    public virtual bool Text(String text)
    {
        long count;
        count = this.StringCount(text);
        long i;
        i = 0;
        while (i < count)
        {
            long oc;
            oc = this.StringChar(text, i);

            this.ExecuteChar(oc);

            i = i + 1;
        }
        return true;
    }

    public virtual bool ExecuteChar(long n)
    {
        return this.Operate.ExecuteChar(n);
    }

    public virtual bool ValidBaseIndex(long index)
    {
        if (index < 0)
        {
            return false;
        }
        
        if (!(index < 0x100))
        {
            return false;
        }

        return true;
    }

    public virtual String ClassBaseMaskGet(long index)
    {
        long ka;
        ka = index;

        if (0 < ka)
        {
            ka = ka - 1;
        }

        long k;
        k = ka;
        k = k & 0xff;
        k = k << 52;

        String a;
        a = this.IntStringHex(k);
        return a;
    }

    public virtual long BaseIndexGet()
    {
        ClassClass anyClass;
        anyClass = this.System.Any;

        ClassClass c;
        c = this.Class;

        long k;
        k = 0;

        ClassClass ka;
        ka = null;
        if (!(c == anyClass))
        {
            ka = c.Base;
        }
        c = ka;

        while (!(c == null))
        {
            k = k + 1;

            ka = null;
            if (!(c == anyClass))
            {
                ka = c.Base;
            }
            c = ka;
        }

        return k;
    }

    protected virtual String InitVar(String prefix, string name)
    {
        return this.AddClear().Add(prefix).AddS(name).AddResult();
    }
}