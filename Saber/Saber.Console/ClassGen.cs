namespace Saber.Console;

public class ClassGen : ClassBase
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

        this.TableIter = new TableIter();
        this.TableIter.Init();

        this.StateKindGet = 1;
        this.StateKindSet = 2;
        this.StateKindCall = 3;

        this.Space = this.S(" ");
        this.NewLine = this.S("\n");
        this.Zero = this.S("0");
        this.One = this.S("1");
        String k;
        k = this.S("v");
        this.VarA = this.InitVar(k, "A");
        this.VarB = this.InitVar(k, "B");
        this.VarC = this.InitVar(k, "C");
        this.VarD = this.InitVar(k, "D");
        this.VarSA = this.InitVar(k, "SA");
        this.VarSB = this.InitVar(k, "SB");
        this.VarSC = this.InitVar(k, "SC");
        this.EvalVar = this.S("e");
        this.EvalStackVar = this.S("S");
        this.EvalIndexVar = this.S("N");
        this.EvalFrameVar = this.S("f");
        this.IntValuePre = this.S("0x");
        this.IntValuePost = this.S("ULL");
        this.BaseBitRightCount = this.S("52");
        this.RefKindBitRightCount = this.S("60");
        this.RefBitCount = this.S("4");
        this.RefKindAny = this.S("1");
        this.RefKindBool = this.S("2");
        this.RefKindInt = this.S("3");
        this.RefKindString = this.S("4");
        this.RefKindStringValue = this.S("5");
        this.RefKindClearMask = this.S("0x0fffffffffffffff");
        this.RefKindBoolMask = this.RefKindMask(this.RefKindBool);
        this.RefKindIntMask = this.RefKindMask(this.RefKindInt);
        this.BaseClearMask = this.S("0xf00fffffffffffff");
        this.BaseMask = this.S("0x0ff0000000000000");
        this.MemoryIndexMask = this.S("0x000fffffffffffff");
        this.ClassInt = this.S("Int");
        this.ClassEval = this.S("Eval");
        this.ClassCompState = this.S("CompState");
        this.InternNewMaide = this.S("Intern_New");
        this.InternValueRef = this.S("Intern_Value_Ref");
        this.InternValueClass = this.S("Intern_Value_Class");
        this.StateGet = this.S("G");
        this.StateSet = this.S("S");
        this.StateCall = this.S("C");
        this.NameCombine = this.S("_");
        this.ClassWord = this.S("Class");
        this.ListWord = this.S("List");
        this.BaseWord = this.S("Base");
        this.ItemWord = this.S("Item");
        this.AnyWord = this.S("Any");
        this.InitWord = this.S("Init");
        this.VarWord = this.S("Var");
        this.ImportWord = this.S("Import");
        this.ExportWord = this.S("Export");
        this.ApiWord = this.S("Api");
        this.InternWord = this.S("Intern");
        this.ExternWord = this.S("Extern");
        this.CastInt = this.S("CastInt");
        this.StringValueArray = this.S("StringValue");
        this.WhileLabelPre = this.S("W_");
        this.IndexExtern = this.S("extern");
        this.IndexReturn = this.S("return");
        this.IndexInf = this.S("if");
        this.IndexGoto = this.S("goto");
        this.LimitDot = this.S(".");
        this.LimitDotPointer = this.S("->");
        this.LimitBraceLite = this.S("{");
        this.LimitBraceRite = this.S("}");
        this.LimitBraceRoundLite = this.S("(");
        this.LimitBraceRoundRite = this.S(")");
        this.LimitBraceSquareLite = this.S("[");
        this.LimitBraceSquareRite = this.S("]");
        this.LimitColon = this.S(":");
        this.LimitSemicolon = this.S(";");
        this.LimitComma = this.S(",");
        this.LimitAsterisk = this.S("*");
        this.LimitAre = this.S("=");
        this.LimitSame = this.S("==");
        this.LimitLess = this.S("<");
        this.LimitAnd = this.S("&");
        this.LimitOrn = this.S("|");
        this.LimitNot = this.S("!");
        this.LimitAdd = this.S("+");
        this.LimitSub = this.S("-");
        this.LimitMul = this.S("*");
        this.LimitDiv = this.S("/");
        this.LimitBitNot = this.S("~");
        this.LimitBitLite = this.S("<<");
        this.LimitBitRite = this.S(">>");
        return true;
    }

    public virtual ClassClass Class { get; set; }
    public virtual ClassComp ClassComp { get; set; }
    public virtual long BaseCount { get; set; }
    public virtual Array BaseArray { get; set; }
    public virtual BuiltinClass System { get; set; }
    public virtual Maide InitMaide { get; set; }
    public virtual ClassClass InternClass { get; set; }
    public virtual ClassClass ExternClass { get; set; }
    public virtual GenArg Arg { get; set; }
    public virtual ClassGenOperate Operate { get; set; }
    public virtual String Result { get; set; }
    public virtual CountClassGenOperate CountOperate { get; set; }
    public virtual SetClassGenOperate SetOperate { get; set; }
    public virtual ClassGenTraverse Traverse { get; set; }
    public virtual Array StringValue { get; set; }
    public virtual long StringValueIndex { get; set; }
    public virtual String ClassBaseMask { get; set; }
    public virtual State CompState { get; set; }
    public virtual Field ThisField { get; set; }
    public virtual Iter TableIter { get; set; }
    public virtual long CompStateKind { get; set; }
    public virtual long ParamCount { get; set; }
    public virtual long LocalVarCount { get; set; }
    public virtual long IndentCount { get; set; }
    public virtual long WhileIndex { get; set; }
    public virtual long StateKindGet { get; set; }
    public virtual long StateKindSet { get; set; }
    public virtual long StateKindCall { get; set; }
    public virtual String Space { get; set; }
    public virtual String NewLine { get; set; }
    public virtual String Zero { get; set; }
    public virtual String One { get; set; }
    public virtual String VarA { get; set; }
    public virtual String VarB { get; set; }
    public virtual String VarC { get; set; }
    public virtual String VarD { get; set; }
    public virtual String VarSA { get; set; }
    public virtual String VarSB { get; set; }
    public virtual String VarSC { get; set; }
    public virtual String EvalVar { get; set; }
    public virtual String EvalStackVar { get; set; }
    public virtual String EvalIndexVar { get; set; }
    public virtual String EvalFrameVar { get; set; }
    public virtual String IntValuePre { get; set; }
    public virtual String IntValuePost { get; set; }
    public virtual String BaseBitRightCount { get; set; }
    public virtual String RefKindBitRightCount { get; set; }
    public virtual String RefBitCount { get; set; }
    public virtual String RefKindAny { get; set; }
    public virtual String RefKindBool { get; set; }
    public virtual String RefKindInt { get; set; }
    public virtual String RefKindString { get; set; }
    public virtual String RefKindStringValue { get; set; }
    public virtual String RefKindClearMask { get; set; }
    public virtual String RefKindBoolMask { get; set; }
    public virtual String RefKindIntMask { get; set; }
    public virtual String BaseClearMask { get; set; }
    public virtual String BaseMask { get; set; }
    public virtual String MemoryIndexMask { get; set; }
    public virtual String ClassInt { get; set; }
    public virtual String ClassEval { get; set; }
    public virtual String ClassCompState { get; set; }
    public virtual String InternNewMaide { get; set; }
    public virtual String InternValueRef { get; set; }
    public virtual String InternValueClass { get; set; }
    public virtual String ClassWord { get; set; }
    public virtual String StateGet { get; set; }
    public virtual String StateSet { get; set; }
    public virtual String StateCall { get; set; }
    public virtual String NameCombine { get; set; }
    public virtual String ListWord { get; set; }
    public virtual String BaseWord { get; set; }
    public virtual String ItemWord { get; set; }
    public virtual String AnyWord { get; set; }
    public virtual String InitWord { get; set; }
    public virtual String VarWord { get; set; }
    public virtual String ImportWord { get; set; }
    public virtual String ExportWord { get; set; }
    public virtual String ApiWord { get; set; }
    public virtual String InternWord { get; set; }
    public virtual String ExternWord { get; set; }
    public virtual String CastInt { get; set; }
    public virtual String StringValueArray { get; set; }
    public virtual String WhileLabelPre { get; set; }
    public virtual String IndexExtern { get; set; }
    public virtual String IndexReturn { get; set; }
    public virtual String IndexInf { get; set; }
    public virtual String IndexGoto { get; set; }
    public virtual String LimitDot { get; set; }
    public virtual String LimitDotPointer { get; set; }
    public virtual String LimitBraceLite { get; set; }
    public virtual String LimitBraceRite { get; set; }
    public virtual String LimitBraceRoundLite { get; set; }
    public virtual String LimitBraceRoundRite { get; set; }
    public virtual String LimitBraceSquareLite { get; set; }
    public virtual String LimitBraceSquareRite { get; set; }
    public virtual String LimitColon { get; set; }
    public virtual String LimitSemicolon { get; set; }
    public virtual String LimitComma { get; set; }
    public virtual String LimitAsterisk { get; set; }
    public virtual String LimitAre { get; set; }
    public virtual String LimitSame { get; set; }
    public virtual String LimitLess { get; set; }
    public virtual String LimitAnd { get; set; }
    public virtual String LimitOrn { get; set; }
    public virtual String LimitNot { get; set; }
    public virtual String LimitAdd { get; set; }
    public virtual String LimitSub { get; set; }
    public virtual String LimitMul { get; set; }
    public virtual String LimitDiv { get; set; }
    public virtual String LimitBitNot { get; set; }
    public virtual String LimitBitLite { get; set; }
    public virtual String LimitBitRite { get; set; }

    protected virtual String RefKindMask(String kindHexDigit)
    {
        return this.AddClear().Add(this.IntValuePre).Add(kindHexDigit).AddS("000000000000000").AddResult();
    }

    public virtual bool Execute()
    {
        this.InitMaide = (Maide)this.System.Any.Maide.Get(this.InitWord);

        this.BaseCount = this.BaseCountGet();
        
        long k;
        k = this.BaseCount - 1;

        if (!this.ValidBaseIndex(k))
        {
            return false;
        }

        this.ClassBaseMask = this.ClassBaseMaskGet(k);

        this.BaseArraySet();

        this.ClassCompSet();

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
        this.StringValueIndex = 0;

        this.WhileIndex = 0;

        this.ExecuteRefer();

        NodeClass nodeClass;
        nodeClass = (NodeClass)this.Class.Any;

        this.Traverse.ExecuteClass(nodeClass);
        return true;
    }

    public virtual bool BaseArraySet()
    {
        long count;
        count = this.BaseCount;

        Array array;
        array = this.ListInfra.ArrayCreate(count);

        this.BaseArray = array;

        ClassClass c;
        c = this.Class;

        long i;
        i = 0;
        while (i < count)
        {
            long index;
            index = count - 1 - i;

            array.SetAt(index, c);

            c = c.Base;

            i = i + 1;
        }

        return true;
    }

    public virtual bool ClassCompSet()
    {
        long fieldCount;
        fieldCount = this.Class.FieldStart + this.Class.Field.Count;
        long maideCount;
        maideCount = this.Class.MaideStart + this.Class.Maide.Count;

        ClassComp k;
        k = new ClassComp();
        k.Init();
        this.ClassComp = k;

        k.Field = this.ListInfra.ArrayCreate(fieldCount);
        k.Maide = this.ListInfra.ArrayCreate(maideCount);

        Array array;
        array = this.BaseArray;

        long count;
        count = array.Count;

        long i;
        i = 0;
        while (i < count)
        {
            ClassClass kk;
            kk = (ClassClass)array.GetAt(i);

            this.ClassCompSetClass(k, kk);

            i = i + 1;
        }

        return true;
    }

    public virtual bool ClassCompSetClass(ClassComp classComp, ClassClass c)
    {
        this.ClassCompSetClassField(classComp.Field, c);

        this.ClassCompSetClassMaide(classComp.Maide, c);
        return true;
    }

    public virtual bool ClassCompSetClassField(Array array, ClassClass c)
    {
        Iter iter;
        iter = this.TableIter;

        c.Field.IterSet(iter);

        while (iter.Next())
        {
            Field field;
            field = (Field)iter.Value;

            Field k;
            k = field;

            if (!(field.Virtual == null))
            {
                k = field.Virtual;    
            }

            ClassClass ka;
            ka = k.Parent;

            long kk;
            kk = ka.FieldStart;
            kk = kk + k.Index;

            array.SetAt(kk, field);
        }

        iter.Clear();

        return true;
    }

    public virtual bool ClassCompSetClassMaide(Array array, ClassClass c)
    {
        Iter iter;
        iter = this.TableIter;

        c.Maide.IterSet(iter);

        while (iter.Next())
        {
            Maide maide;
            maide = (Maide)iter.Value;

            Maide k;
            k = maide;

            if (!(maide.Virtual == null))
            {
                k = maide.Virtual;
            }

            ClassClass ka;
            ka = k.Parent;

            long kk;
            kk = ka.MaideStart;
            kk = kk + k.Index;

            array.SetAt(kk, maide);
        }

        iter.Clear();

        return true;
    }

    public virtual bool ExecuteRefer()
    {
        this.ExecuteExternCompList(this.ClassComp.Field, true, this.StateGet);
        this.Text(this.NewLine);

        this.ExecuteExternCompList(this.ClassComp.Field, true, this.StateSet);
        this.Text(this.NewLine);

        this.ExecuteExternCompList(this.ClassComp.Maide, false, this.StateCall);
        this.Text(this.NewLine);

        this.ExecuteCompList(this.ClassComp.Field, true, this.StateGet);

        this.ExecuteCompList(this.ClassComp.Field, true, this.StateSet);

        this.ExecuteCompList(this.ClassComp.Maide, false, this.StateCall);

        this.ExecuteExternClassAny();
        this.Text(this.NewLine);

        this.ExecuteExternBaseItemList();
        this.Text(this.NewLine);

        this.ExecuteBaseItem();
        
        this.ExecuteBase();

        this.ExecuteClassAny();

        this.ExecuteClassInt();
        return true;
    }

    public virtual bool ExecuteBase()
    {
        long count;
        count = this.BaseArray.Count;

        this.Text(this.ClassInt);
        this.Text(this.Space);

        this.BaseName(this.Class);
        this.Text(this.LimitBraceSquareLite);
        this.TextInt(count);
        this.Text(this.LimitBraceSquareRite);

        this.Text(this.Space);
        this.Text(this.LimitAre);
        this.Text(this.NewLine);

        this.Text(this.LimitBraceLite);
        this.Text(this.NewLine);

        this.IndentCount = this.IndentCount + 1;

        long i;
        i = 0;
        while (i < count)
        {
            ClassClass varClass;
            varClass = (ClassClass)this.BaseArray.GetAt(i);

            this.TextIndent();
            this.Text(this.CastInt);
            this.Text(this.LimitBraceRoundLite);
            this.BaseItemName(varClass);
            this.Text(this.LimitBraceRoundRite);
            this.Text(this.LimitComma);
            this.Text(this.NewLine);

            i = i + 1;
        }

        this.IndentCount = this.IndentCount - 1;

        this.Text(this.LimitBraceRite);
        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);
        this.Text(this.NewLine);

        return true;
    }

    public virtual bool ExecuteBaseItem()
    {
        this.Text(this.ClassInt);
        this.Text(this.Space);

        this.BaseItemName(this.Class);
        this.Text(this.LimitBraceSquareLite);
        this.TextInt(4);
        this.Text(this.LimitBraceSquareRite);

        this.Text(this.Space);
        this.Text(this.LimitAre);
        this.Text(this.NewLine);

        this.Text(this.LimitBraceLite);
        this.Text(this.NewLine);

        this.IndentCount = this.IndentCount + 1;

        this.TextIndent();
        this.Text(this.CastInt);
        this.Text(this.LimitBraceRoundLite);
        this.ClassAnyName(this.Class);
        this.Text(this.LimitBraceRoundRite);
        this.Text(this.LimitComma);
        this.Text(this.NewLine);

        this.BaseItemCompList(this.Class, this.StateGet);

        this.BaseItemCompList(this.Class, this.StateSet);

        this.BaseItemCompList(this.Class, this.StateCall);

        this.IndentCount = this.IndentCount - 1;

        this.Text(this.LimitBraceRite);
        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);
        this.Text(this.NewLine);

        return true;
    }

    public virtual bool ExecuteExternBaseItemList()
    {
        long count;
        count = this.BaseArray.Count;

        long i;
        i = 0;
        while (i < count)
        {
            ClassClass varClass;
            varClass = (ClassClass)this.BaseArray.GetAt(i);

            bool export;
            export = (varClass.Module == this.Class.Module);

            String kka;
            kka = null;

            if (!export)
            {
                kka = this.ImportWord;
            }

            if (export)
            {
                kka = this.ExportWord;
            }

            this.Text(kka);
            this.Text(this.ApiWord);

            this.Text(this.Space);

            this.Text(this.ClassInt);

            this.Text(this.Space);

            this.BaseItemName(varClass);

            this.Text(this.LimitBraceSquareLite);
            this.TextInt(4);
            this.Text(this.LimitBraceSquareRite);

            this.Text(this.LimitSemicolon);
            this.Text(this.NewLine);

            i = i + 1;
        }

        return true;
    }

    public virtual bool ExecuteClassAny()
    {
        long baseIndex;
        baseIndex = this.BaseCount - 1;

        long fieldCount;
        fieldCount = this.Class.FieldStart + this.Class.Field.Count;

        this.Text(this.ClassInt);
        this.Text(this.Space);

        this.ClassAnyName(this.Class);
        this.Text(this.LimitBraceSquareLite);
        this.TextInt(5);
        this.Text(this.LimitBraceSquareRite);

        this.Text(this.Space);
        this.Text(this.LimitAre);
        this.Text(this.NewLine);

        this.Text(this.LimitBraceLite);
        this.Text(this.NewLine);

        this.IndentCount = this.IndentCount + 1;

        this.TextIndent();

        this.Text(this.CastInt);
        this.Text(this.LimitBraceRoundLite);
        this.ClassAnyName(this.Class);
        this.Text(this.LimitBraceRoundRite);
        this.Text(this.LimitComma);
        this.Text(this.Space);

        this.TextInt(baseIndex);
        this.Text(this.LimitComma);
        this.Text(this.Space);

        this.TextInt(fieldCount);
        this.Text(this.LimitComma);
        this.Text(this.Space);

        this.Text(this.Zero);
        this.Text(this.LimitComma);
        this.Text(this.Space);

        this.Text(this.Zero);

        this.Text(this.NewLine);

        this.IndentCount = this.IndentCount - 1;

        this.Text(this.LimitBraceRite);
        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool ExecuteExternClassAny()
    {
        this.Text(this.IndexExtern);
        this.Text(this.Space);

        this.Text(this.ClassInt);
        this.Text(this.Space);

        this.ClassAnyName(this.Class);
        this.Text(this.LimitBraceSquareLite);
        this.TextInt(5);
        this.Text(this.LimitBraceSquareRite);

        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool ExecuteClassInt()
    {
        this.Text(this.ClassInt);
        this.Text(this.Space);

        this.ClassVar(this.Class);

        this.Text(this.Space);
        this.Text(this.LimitAre);
        this.Text(this.Space);

        this.Text(this.CastInt);
        this.Text(this.LimitBraceRoundLite);
        this.ClassAnyName(this.Class);
        this.Text(this.LimitBraceRoundRite);

        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool BaseItemCompList(ClassClass varClass, String stateKind)
    {
        this.TextIndent();
        this.Text(this.CastInt);
        this.Text(this.LimitBraceRoundLite);
        this.CompListName(varClass, stateKind);
        this.Text(this.LimitBraceRoundRite);
        this.Text(this.LimitComma);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool ExecuteExternCompList(Array array, bool field, String stateKind)
    {
        bool b;
        b = field;

        long count;
        count = array.Count;

        long i;
        i = 0;
        while (i < count)
        {
            object k;
            k = array.GetAt(i);

            bool ba;
            ba = (k == null);

            if (!ba)
            {
                ClassClass varClass;
                String name;
                varClass = null;
                name = null;

                if (b)
                {
                    Field ka;
                    ka = (Field)k;
                    name = ka.Name;
                    varClass = ka.Parent;
                }
                if (!b)
                {
                    Maide kb;
                    kb = (Maide)k;
                    name = kb.Name;
                    varClass = kb.Parent;
                }

                bool export;
                export = (varClass.Module == this.Class.Module);
                
                String kka;
                kka = null;

                if (!export)
                {
                    kka = this.ImportWord;
                }

                if (export)
                {
                    kka = this.ExportWord;
                }

                this.Text(kka);
                this.Text(this.ApiWord);

                this.Text(this.Space);

                this.Text(this.ClassInt);

                this.Text(this.Space);

                this.CompStateMaideName(varClass, name, stateKind);

                this.Text(this.LimitBraceRoundLite);

                this.Text(this.ClassEval);
                this.Text(this.LimitAsterisk);
                this.Text(this.Space);
                this.Text(this.EvalVar);

                this.Text(this.LimitComma);
                this.Text(this.Space);

                this.Text(this.ClassInt);
                this.Text(this.Space);
                this.Text(this.EvalFrameVar);

                this.Text(this.LimitBraceRoundRite);

                this.Text(this.LimitSemicolon);
                this.Text(this.NewLine);
            }

            i = i + 1;
        }

        return true;
    }

    public virtual bool ExecuteCompList(Array array, bool field, String stateKind)
    {
        long count;
        count = array.Count;

        this.Text(this.ClassInt);
        this.Text(this.Space);

        this.CompListName(this.Class, stateKind);
        this.Text(this.LimitBraceSquareLite);
        this.TextInt(count);
        this.Text(this.LimitBraceSquareRite);

        this.Text(this.Space);
        this.Text(this.LimitAre);
        this.Text(this.NewLine);

        this.Text(this.LimitBraceLite);
        this.Text(this.NewLine);

        this.IndentCount = this.IndentCount + 1;

        bool b;
        b = field;

        long i;
        i = 0;
        while (i < count)
        {
            object k;
            k = array.GetAt(i);

            bool ba;
            ba = (k == null);

            this.TextIndent();

            if (ba)
            {
                this.Text(this.Zero);
            }
            if (!ba)
            {
                ClassClass varClass;
                String name;
                varClass = null;
                name = null;

                if (b)
                {
                    Field ka;
                    ka = (Field)k;
                    name = ka.Name;
                    varClass = ka.Parent;
                }
                if (!b)
                {
                    Maide kb;
                    kb = (Maide)k;
                    name = kb.Name;
                    varClass = kb.Parent;
                }

                this.Text(this.CastInt);
                this.Text(this.LimitBraceRoundLite);
                this.CompStateMaideName(varClass, name, stateKind);
                this.Text(this.LimitBraceRoundRite);
            }
            this.Text(this.LimitComma);
            this.Text(this.NewLine);

            i = i + 1;
        }

        this.IndentCount = this.IndentCount - 1;

        this.Text(this.LimitBraceRite);
        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);
        this.Text(this.NewLine);

        return true;
    }

    public virtual bool ClassInitName(ClassClass varClass)
    {
        this.ClassName(varClass);
        this.Text(this.NameCombine);
        this.Text(this.ClassWord);
        this.Text(this.InitWord);
        return true;
    }

    public virtual bool ClassInitVarName(ClassClass varClass)
    {
        this.ClassName(varClass);
        this.Text(this.NameCombine);
        this.Text(this.ClassWord);
        this.Text(this.InitWord);
        this.Text(this.VarWord);
        return true;
    }

    public virtual bool ClassAnyName(ClassClass varClass)
    {
        this.ClassName(varClass);
        this.Text(this.NameCombine);
        this.Text(this.ClassWord);
        this.Text(this.AnyWord);
        return true;
    }

    public virtual bool BaseName(ClassClass varClass)
    {
        this.ClassName(varClass);
        this.Text(this.NameCombine);
        this.Text(this.BaseWord);
        return true;
    }

    public virtual bool BaseItemName(ClassClass varClass)
    {
        this.ClassName(varClass);
        this.Text(this.NameCombine);
        this.Text(this.BaseWord);
        this.Text(this.ItemWord);
        return true;
    }

    public virtual bool CompListName(ClassClass varClass, String stateKind)
    {
        this.ClassName(varClass);
        this.Text(this.NameCombine);
        this.Text(stateKind);
        this.Text(this.NameCombine);
        this.Text(this.ListWord);
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

        this.OperateLimit(varD, varD, this.BaseBitRightCount, this.LimitBitRite);

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

        this.EvalValueGet(1, varB);

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
        kk = varClass.FieldStart;
        kk = kk + varField.Index;

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

    public virtual long LocalVarFrameValueIndex(long varIndex)
    {
        long stateKind;
        stateKind = this.CompStateKind;

        long k;
        k = this.ParamCount - 1;

        long ka;
        ka = 0;

        if (stateKind == this.StateKindGet)
        {
            ka = varIndex - 1;
        }

        if (stateKind == this.StateKindSet)
        {
            ka = varIndex - 2;
        }

        if (stateKind == this.StateKindCall)
        {
            ka = varIndex - k;
        }

        return ka;
    }

    public virtual bool TableVarLocalVarSetNull(Table table)
    {
        Iter iter;
        iter = this.TableIter;

        table.IterSet(iter);

        while (iter.Next())
        {
            Var kk;
            kk = (Var)iter.Value;

            long ka;
            ka = this.LocalVarFrameValueIndex(kk.Index);

            this.EvalFrameValueSet(ka, this.Zero);
        }

        iter.Clear();

        return true;
    }

    public virtual bool ExecuteOperateLimit(String limit)
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

        this.OperateLimit(varA, varA, varB, limit);

        this.VarMaskClear(varA, ka);

        this.VarMaskSet(varA, this.RefKindIntMask);

        this.EvalValueSet(2, varA);

        this.EvalIndexPosSet(-1);

        return true;
    }

    public virtual bool ExecuteOperateLimitCond(String limit)
    {
        String varA;
        String varB;
        String varC;
        varA = this.VarA;
        varB = this.VarB;
        varC = this.VarC;

        this.EvalValueGet(2, varA);
        this.EvalValueGet(1, varB);

        this.VarMaskClear(varA, this.RefKindClearMask);
        this.VarMaskClear(varB, this.RefKindClearMask);

        this.OperateLimit(varC, varB, this.Zero, this.LimitSame);

        this.OperateLimit(varB, varB, varC, this.LimitAdd);

        this.OperateLimit(varA, varA, varB, limit);

        this.CondSet(varA, varC, this.Zero, varA);

        this.VarMaskSet(varA, this.RefKindIntMask);

        this.EvalValueSet(2, varA);

        this.EvalIndexPosSet(-1);

        return true;
    }

    public virtual bool ExecuteOperateLimitSign(String limit)
    {
        String varA;
        String varB;
        varA = this.VarA;
        varB = this.VarB;

        String varSA;
        String varSB;
        varSA = this.VarSA;
        varSB = this.VarSB;

        this.EvalValueGet(2, varA);
        this.EvalValueGet(1, varB);

        this.VarSet(varSA, varA);
        this.VarSet(varSB, varB);

        this.SignExtend(varSA);
        this.SignExtend(varSB);

        this.OperateLimit(varSA, varSA, varSB, limit);

        this.SignExtend(varSA);

        this.VarSet(varA, varSA);

        this.VarMaskClear(varA, this.RefKindClearMask);

        this.VarMaskSet(varA, this.RefKindIntMask);

        this.EvalValueSet(2, varA);

        this.EvalIndexPosSet(-1);

        return true;
    }

    public virtual bool ExecuteOperateLimitSignCond(String limit)
    {
        String varA;
        String varB;
        varA = this.VarA;
        varB = this.VarB;

        String varSA;
        String varSB;
        String varSC;
        varSA = this.VarSA;
        varSB = this.VarSB;
        varSC = this.VarSC;

        this.EvalValueGet(2, varA);
        this.EvalValueGet(1, varB);

        this.VarSet(varSA, varA);
        this.VarSet(varSB, varB);

        this.SignExtend(varSA);
        this.SignExtend(varSB);

        this.OperateLimit(varSC, varSB, this.Zero, this.LimitSame);

        this.OperateLimit(varSB, varSB, varSC, this.LimitAdd);

        this.OperateLimit(varSA, varSA, varSB, limit);

        this.CondSet(varSA, varSC, this.Zero, varSA);

        this.SignExtend(varSA);

        this.VarSet(varA, varSA);

        this.VarMaskClear(varA, this.RefKindClearMask);

        this.VarMaskSet(varA, this.RefKindIntMask);

        this.EvalValueSet(2, varA);

        this.EvalIndexPosSet(-1);

        return true;
    }

    public virtual bool ExecuteOperateLimitAA(String limit)
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

        this.OperateLimit(varA, varA, varB, limit);

        this.VarMaskClear(varA, ka);

        this.VarMaskSet(varA, this.RefKindIntMask);

        this.EvalValueSet(2, varA);

        this.EvalIndexPosSet(-1);

        return true;
    }

    public virtual bool ExecuteOperateLimitAB(String limit)
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

        this.OperateLimit(varA, varA, varB, limit);

        this.VarMaskSet(varA, this.RefKindIntMask);

        this.EvalValueSet(2, varA);

        this.EvalIndexPosSet(-1);

        return true;
    }

    public virtual bool ExecuteOperateLimitA(String limit)
    {
        String varA;
        String varB;
        varA = this.VarA;
        varB = this.VarB;

        this.EvalValueGet(2, varA);
        this.EvalValueGet(1, varB);

        this.OperateLimit(varA, varA, varB, limit);

        this.VarMaskSet(varA, this.RefKindIntMask);

        this.EvalValueSet(2, varA);

        this.EvalIndexPosSet(-1);

        return true;
    }

    public virtual bool ExecuteOperateLimitBool(String limit)
    {
        String varA;
        String varB;
        varA = this.VarA;
        varB = this.VarB;

        this.EvalValueGet(2, varA);
        this.EvalValueGet(1, varB);

        this.OperateLimit(varA, varA, varB, limit);

        this.VarMaskSet(varA, this.RefKindBoolMask);

        this.EvalValueSet(2, varA);

        this.EvalIndexPosSet(-1);

        return true;
    }

    public virtual bool ExecuteOperateLimitBoolOne(String limit)
    {
        String varA;
        varA = this.VarA;

        String ka;
        ka = this.RefKindClearMask;

        this.EvalValueGet(1, varA);

        this.VarMaskClear(varA, ka);

        this.OperateLimitOne(varA, varA, limit);

        this.VarMaskSet(varA, this.RefKindBoolMask);

        this.EvalValueSet(1, varA);

        return true;
    }

    public virtual bool OperateLimit(String dest, String lite, String rite, String limit)
    {
        String space;
        space = this.Space;

        this.TextIndent();

        this.Text(dest);
        
        this.Text(space);
        this.Text(this.LimitAre);
        this.Text(space);

        this.Text(lite);

        this.Text(space);
        this.Text(limit);
        this.Text(space);

        this.Text(rite);

        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool OperateLimitOne(String dest, String value, String limit)
    {
        this.TextIndent();

        this.Text(dest);

        this.Text(this.Space);
        this.Text(this.LimitAre);
        this.Text(this.Space);

        this.Text(limit);
        this.Text(this.Space);

        this.Text(value);

        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool OperateLimitClass(String dest, String lite, ClassClass varClass, String limit)
    {
        String space;
        space = this.Space;

        this.TextIndent();

        this.Text(dest);

        this.Text(space);
        this.Text(this.LimitAre);
        this.Text(space);

        this.Text(lite);

        this.Text(space);
        this.Text(limit);
        this.Text(space);

        this.ClassVar(varClass);

        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool SignExtend(String varVar)
    {
        this.OperateLimit(varVar, varVar, this.RefBitCount, this.LimitBitLite);

        this.OperateLimit(varVar, varVar, this.RefBitCount, this.LimitBitRite);
        return true;
    }

    public virtual bool Return()
    {
        this.TextIndent();

        this.Text(this.IndexReturn);

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
        this.Text(this.EvalVar);

        this.Text(this.LimitComma);
        this.Text(kk);

        this.EvalIndex();
    
        this.Text(kb);

        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool InternNew(ClassClass varClass)
    {
        this.TextIndent();

        this.Text(this.InternNewMaide);
        this.Text(this.LimitBraceRoundLite);

        this.Text(this.One);

        this.Text(this.LimitComma);
        this.Text(this.Space);

        this.ClassVar(varClass);

        this.Text(this.LimitComma);
        this.Text(this.Space);

        this.Text(this.EvalVar);

        this.Text(this.LimitBraceRoundRite);

        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool ExecuteValueMaideCallThisCond(String refKind, long thisEvalIndex)
    {
        String varA;
        String varB;
        String varC;
        varA = this.VarA;
        varB = this.VarB;
        varC = this.VarC;

        this.EvalValueGet(thisEvalIndex, varC);

        this.OperateLimit(varA, varC, this.RefKindBitRightCount, this.LimitBitRite);

        this.OperateLimit(varB, varA, refKind, this.LimitSame);

        this.OperateLimit(varA, varA, this.Zero, this.LimitSame);

        this.OperateLimit(varA, varA, varB, this.LimitOrn);

        this.CondSet(varC, varA, varC, this.InternValueRef);

        this.EvalValueSet(thisEvalIndex, varC);

        return true;
    }

    public virtual bool ExecuteValueMaideCallThisCondA(long thisEvalIndex)
    {
        String varA;
        String varB;
        varA = this.VarA;
        varB = this.VarB;

        this.EvalValueGet(thisEvalIndex, varB);

        this.OperateLimit(varA, varB, this.Zero, this.LimitSame);

        this.CondSet(varB, varA, varB, this.InternValueRef);

        this.EvalValueSet(thisEvalIndex, varB);

        return true;
    }

    public virtual bool ExecuteCast(ClassClass varClass)
    {
        String varA;
        String varB;
        String varC;
        String varD;
        varA = this.VarA;
        varB = this.VarB;
        varC = this.VarC;
        varD = this.VarD;

        this.EvalValueGet(1, varA);

        this.VarSet(varB, varA);

        this.OperateLimit(varB, varB, this.RefKindBitRightCount, this.LimitBitRite);

        this.OperateLimit(varB, varB, this.RefKindAny, this.LimitSame);

        this.CondSet(varC, varB, varA, this.InternValueRef);

        this.VarMaskClear(varC, this.MemoryIndexMask);

        this.VarSetDeref(varC, varC, 0);

        this.VarSet(varB, varC);

        this.VarSetDeref(varC, varC, 1);

        this.VarSetPre(varD);
        this.TextInt(varClass.BaseIndex);
        this.VarSetPost();

        this.OperateLimit(varC, varC, varD, this.LimitLess);

        this.CondSet(varD, varC, this.Zero, varD);

        this.CondSet(varB, varC, this.InternValueClass, varB);

        this.VarSetDeref(varC, varB, 0);

        this.VarSetDerefVar(varC, varC, varD);

        this.VarSetDeref(varC, varC, 0);

        this.OperateLimitClass(varC, varC, varClass, this.LimitSame);

        this.CondSet(varA, varC, varA, this.Zero);

        this.EvalValueSet(1, varA);

        return true;
    }

    public virtual bool ExecuteCondRefKind(String refKind)
    {
        String varA;
        String varB;
        varA = this.VarA;
        varB = this.VarB;

        this.EvalValueGet(1, varA);

        this.VarSet(varB, varA);

        this.OperateLimit(varB, varB, this.RefKindBitRightCount, this.LimitBitRite);

        this.OperateLimit(varB, varB, refKind, this.LimitSame);

        this.CondSet(varA, varB, varA, this.Zero);

        this.EvalValueSet(1, varA);

        return true;
    }

    public virtual bool ExecuteCondRefKindA(String refKindA, String refKindB)
    {
        String varA;
        String varB;
        String varC;
        varA = this.VarA;
        varB = this.VarB;
        varC = this.VarC;

        this.EvalValueGet(1, varA);

        this.VarSet(varB, varA);

        this.OperateLimit(varB, varB, this.RefKindBitRightCount, this.LimitBitRite);

        this.OperateLimit(varC, varB, refKindA, this.LimitSame);

        this.OperateLimit(varB, varB, refKindB, this.LimitSame);

        this.OperateLimit(varB, varB, varC, this.LimitOrn);

        this.CondSet(varA, varB, varA, this.Zero);

        this.EvalValueSet(1, varA);

        return true;
    }

    public virtual bool CondSet(String dest, String cond, String trueValue, String falseValue)
    {
        this.TextIndent();

        this.Text(dest);

        this.Text(this.Space);
        this.Text(this.LimitAre);
        this.Text(this.Space);

        this.Text(this.LimitBraceRoundLite);

        this.Text(cond);

        this.Text(this.Space);
        this.Text(this.LimitMul);
        this.Text(this.Space);

        this.Text(trueValue);

        this.Text(this.LimitBraceRoundRite);

        this.Text(this.Space);
        this.Text(this.LimitAdd);
        this.Text(this.Space);

        this.Text(this.LimitBraceRoundLite);

        this.Text(this.LimitBraceRoundLite);

        this.Text(this.LimitNot);
        this.Text(cond);

        this.Text(this.LimitBraceRoundRite);

        this.Text(this.Space);
        this.Text(this.LimitMul);
        this.Text(this.Space);

        this.Text(falseValue);

        this.Text(this.LimitBraceRoundRite);

        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool InfStart(String cond)
    {
        this.TextIndent();

        this.Text(this.IndexInf);
        this.Text(this.Space);

        this.Text(this.LimitBraceRoundLite);

        this.Text(cond);

        this.Text(this.LimitBraceRoundRite);

        this.Text(this.NewLine);

        return true;
    }

    public virtual bool BlockStart()
    {
        this.TextIndent();

        this.Text(this.LimitBraceLite);

        this.Text(this.NewLine);
        return true;
    }

    public virtual bool BlockEnd()
    {
        this.TextIndent();

        this.Text(this.LimitBraceRite);

        this.Text(this.NewLine);
        return true;
    }

    public virtual bool WhileLabel(long whileIndex)
    {
        this.Text(this.WhileLabelPre);

        this.Operate.ExecuteIntText(whileIndex);
        return true;
    }

    public virtual bool WhileLabelLine(long whileIndex)
    {
        this.TextIndent();

        this.WhileLabel(whileIndex);

        this.Text(this.LimitColon);

        this.Text(this.NewLine);
        return true;
    }

    public virtual bool GotoWhileLabel(long whileIndex)
    {
        this.TextIndent();

        this.Text(this.IndexGoto);

        this.Text(this.Space);

        this.WhileLabel(whileIndex);

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

    public virtual bool VarSetPre(String dest)
    {
        this.TextIndent();

        this.Text(dest);

        this.Text(this.Space);
        this.Text(this.LimitAre);
        this.Text(this.Space);
        return true;
    }

    public virtual bool VarSetPost()
    {
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
        this.Text(this.LimitAdd);
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
        this.Text(this.LimitAnd);
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
        this.Text(this.LimitOrn);
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
        this.Text(this.LimitSub);
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
        this.Text(this.EvalVar);
        this.Text(this.LimitDotPointer);
        this.Text(this.EvalStackVar);
        return true;
    }

    public virtual bool EvalIndex()
    {
        this.Text(this.EvalVar);
        this.Text(this.LimitDotPointer);
        this.Text(this.EvalIndexVar);
        return true;
    }

    public virtual bool FieldGetMaideName(ClassClass varClass, String compName)
    {
        return this.CompStateMaideName(varClass, compName, this.StateGet);
    }

    public virtual bool FieldSetMaideName(ClassClass varClass, String compName)
    {
        return this.CompStateMaideName(varClass, compName, this.StateSet);
    }

    public virtual bool MaideCallMaideName(ClassClass varClass, String compName)
    {
        return this.CompStateMaideName(varClass, compName, this.StateCall);
    }

    public virtual bool CompStateMaideName(ClassClass varClass, String compName, String state)
    {
        if (varClass == this.InternClass | varClass == this.ExternClass)
        {
            this.Text(this.InternWord);

            this.Text(this.NameCombine);

            String k;
            k = this.InternWord;

            if (varClass == this.ExternClass)
            {
                k = this.ExternWord;
            }

            this.Text(k);

            this.Text(this.NameCombine);

            this.Text(compName);

            return true;
        }


        this.ClassName(varClass);

        this.Text(this.NameCombine);

        this.NameSymbolString(compName);

        this.Text(this.NameCombine);

        this.Text(state);
        return true;
    }

    public virtual bool ClassVar(ClassClass varClass)
    {
        this.ClassName(varClass);

        this.Text(this.NameCombine);

        this.Text(this.ClassWord);

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

        this.TextInt(moduleRef.Ver);
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
        this.Operate.ExecuteIntText(ver);
        return true;
    }

    public virtual bool BoolValueRef(bool value)
    {
        this.Text(this.IntValuePre);

        this.Text(this.RefKindBool);

        long k;
        k = 0;
        if (value)
        {
            k = 1;
        }

        this.Operate.ExecuteIntText(k);

        this.Text(this.IntValuePost);
        return true;
    }

    public virtual bool IntValueRef(long value)
    {
        this.Text(this.IntValuePre);

        this.Text(this.RefKindInt);

        this.Operate.ExecuteIntText(value);

        this.Text(this.IntValuePost);
        return true;
    }

    public virtual bool StringValueRef(long index)
    {
        this.Text(this.StringValueArray);

        this.Text(this.LimitBraceSquareLite);

        this.TextInt(index);

        this.Text(this.LimitBraceSquareRite);
        return true;
    }

    public virtual bool TextPos(long n)
    {
        bool b;
        b = (n < 0);

        String ka;
        ka = this.LimitAdd;

        long k;
        k = n;
        
        if (b)
        {
            k = -k;

            ka = this.LimitSub;
        }

        this.Text(ka);
        this.Text(this.Space);
        this.TextInt(k);
        return true;
    }

    public virtual bool TextInt(long n)
    {
        this.Text(this.IntValuePre);
        
        this.Operate.ExecuteIntText(n);

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
        a = this.AddClear().Add(this.IntValuePre).Add(this.StringIntHex(k)).Add(this.IntValuePost).AddResult();
        
        return a;
    }

    public virtual long BaseCountGet()
    {
        ClassClass anyClass;
        anyClass = this.System.Any;

        ClassClass c;
        c = this.Class;

        long k;
        k = 0;

        while (!(c == null))
        {
            k = k + 1;

            ClassClass ka;
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