namespace Saber.Console;

public partial class ClassGen : TextAdd
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.OperateKindList = BinaryOperateKindList.This;

        this.CountOperate = this.CreateCountOperate();
        this.SetOperate = this.CreateSetOperate();
        this.ClassIter = this.CreateClassIter();
        this.TableIter = this.CreateTableIter();

        this.StateKindGet = 1;
        this.StateKindSet = 2;
        this.StateKindCall = 3;

        this.Space = this.S(" ");
        this.NewLine = this.TextInfra.NewLine;
        this.Zero = this.S("0");
        this.One = this.S("1");
        this.VarA = this.InitVar("A");
        this.VarB = this.InitVar("B");
        this.VarC = this.InitVar("C");
        this.VarD = this.InitVar("D");
        this.VarSA = this.InitVar("SA");
        this.VarSB = this.InitVar("SB");
        this.VarSC = this.InitVar("SC");
        this.EvalVar = this.S("e");
        this.EvalStackVar = this.S("S");
        this.EvalIndexVar = this.S("N");
        this.EvalFrameVar = this.S("f");
        this.IntValueHexPre = this.S("0x");
        this.BaseBitRiteCount = this.S("52");
        this.RefKindBitRiteCount = this.S("60");
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
        this.ClassSInt = this.S("SInt");
        this.ClassInt32 = this.S("Int32");
        this.ClassEval = this.S("Eval");
        this.ClassCompState = this.S("Intern_State");
        this.InternNewMaide = this.S("Intern_New");
        this.InternShareMaide = this.S("Intern_Share");
        this.InternValueRef = this.S("Intern_Value_Ref");
        this.InternValueClass = this.S("Intern_Value_Class");
        this.InternValueBool = this.S("Intern_Value_Bool");
        this.InternValueInt = this.S("Intern_Value_Int");
        this.InternValueString = this.S("Intern_Value_String");
        this.InternClassStruct = this.S("Intern_Class");
        this.InternModuleStruct = this.S("Intern_Module");
        this.InternBaseSet = this.S("Intern_Base_Set");
        this.InternModuleSet = this.S("Intern_Module_Set");
        this.RefKindIntMacro = this.S("RefKindInt");
        this.RefKindStringValueMacro = this.S("RefKindStringValue");
        this.RefKindStringValueDataMacro = this.S("RefKindStringValueData");
        this.StateGet = this.S("G");
        this.StateSet = this.S("S");
        this.StateCall = this.S("C");
        this.NameCombine = this.S("_");
        this.NamePre = this.S("C");
        this.ClassWord = this.S("Class");
        this.ModuleWord = this.S("Module");
        this.ListWord = this.S("List");
        this.BaseWord = this.S("Base");
        this.ItemWord = this.S("Item");
        this.AnyWord = this.S("Any");
        this.InitWord = this.S("Init");
        this.CountWord = this.S("Count");
        this.VarWord = this.S("Var");
        this.ImportWord = this.S("Import");
        this.ExportWord = this.S("Export");
        this.ApiWord = this.S("Api");
        this.InternWord = this.S("Intern");
        this.ExternWord = this.S("Extern");
        this.StringWord = this.S("String");
        this.DataWord = this.S("Data");
        this.EntryWord = this.S("Entry");
        this.VarOWord = this.S("o");
        this.VarKWord = this.S("k");
        this.VarMWord = this.S("m");
        this.VarNWord = this.S("n");
        this.CastInt = this.S("CastInt");
        this.WhileLabelPre = this.S("W_");
        this.DirectiveInclude = this.S("#include");
        this.IncludeValueInfra = this.S("<Infra/Prusate.h>");
        this.IncludeValueInfraIntern = this.S("<InfraIntern/Prusate.h>");
        this.IncludeValueInfraInternIntern = this.S("<InfraIntern/Prusate_Intern.h>");
        this.IncludeValueInfraInternExtern = this.S("<InfraIntern/Prusate_Extern.h>");
        this.IndexExtern = this.S("extern");
        this.IndexStatic = this.S("static");
        this.IndexReturn = this.S("return");
        this.IndexInf = this.S("if");
        this.IndexGoto = this.S("goto");
        this.LimitDot = this.S(".");
        this.LimitDotPointer = this.S("->");
        this.LimitBraceRoundLite = this.S("(");
        this.LimitBraceRoundRite = this.S(")");
        this.LimitBraceRightLite = this.S("[");
        this.LimitBraceRightRite = this.S("]");
        this.LimitBraceCurveLite = this.S("{");
        this.LimitBraceCurveRite = this.S("}");
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

    public virtual ClassGenCountOperate CreateCountOperate()
    {
        ClassGenCountOperate a;
        a = new ClassGenCountOperate();
        a.Gen = this;
        a.Init();
        return a;
    }

    public virtual ClassGenSetOperate CreateSetOperate()
    {
        ClassGenSetOperate a;
        a = new ClassGenSetOperate();
        a.Gen = this;
        a.Init();
        return a;
    }

    public virtual TableIter CreateClassIter()
    {
        return this.CreateTableIter();
    }

    public virtual TableIter CreateTableIter()
    {
        TableIter a;
        a = new TableIter();
        a.Init();
        return a;
    }

    public virtual String InitVar(string name)
    {
        return this.AddClear().AddS("v").AddS(name).AddResult();
    }

    public virtual ClassGenOperateState InitOperateState(ClassGenOperateState state)
    {
        state.Gen = this;
        state.Init();
        return state;
    }

    public virtual ClassModule Module { get; set; }
    public virtual BinaryBinary Binary { get; set; }
    public virtual long ModuleCount { get; set; }
    public virtual Array InitArray { get; set; }
    public virtual Array BaseArray { get; set; }
    public virtual Array CompArray { get; set; }
    public virtual Array StringArray { get; set; }
    public virtual String Result { get; set; }
    public virtual ClassClass Class { get; set; }
    public virtual SystemClass System { get; set; }
    public virtual bool SystemInfraModule { get; set; }
    public virtual ClassClass InternClass { get; set; }
    public virtual ClassClass ExternClass { get; set; }
    public virtual Array Base { get; set; }
    public virtual ClassComp Comp { get; set; }
    public virtual Array String { get; set; }
    public virtual ClassGenArg Arg { get; set; }
    public virtual ClassGenOperate Operate { get; set; }
    public virtual ClassGenCountOperate CountOperate { get; set; }
    public virtual ClassGenSetOperate SetOperate { get; set; }
    public virtual long StringValueIndex { get; set; }
    public virtual Field ThisField { get; set; }
    public virtual Iter ClassIter { get; set; }
    public virtual Iter TableIter { get; set; }
    public virtual long CompStateKind { get; set; }
    public virtual long ParamCount { get; set; }
    public virtual long LocalVarCount { get; set; }
    public virtual long IndentCount { get; set; }
    public virtual long WhileIndex { get; set; }
    public virtual long StateKindGet { get; set; }
    public virtual long StateKindSet { get; set; }
    public virtual long StateKindCall { get; set; }
    public virtual long StateDataIndex { get; set; }
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
    public virtual String IntValueHexPre { get; set; }
    public virtual String BaseBitRiteCount { get; set; }
    public virtual String RefKindBitRiteCount { get; set; }
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
    public virtual String ClassSInt { get; set; }
    public virtual String ClassInt32 { get; set; }
    public virtual String ClassEval { get; set; }
    public virtual String ClassCompState { get; set; }
    public virtual String InternNewMaide { get; set; }
    public virtual String InternShareMaide { get; set; }
    public virtual String InternValueRef { get; set; }
    public virtual String InternValueClass { get; set; }
    public virtual String InternValueBool { get; set; }
    public virtual String InternValueInt { get; set; }
    public virtual String InternValueString { get; set; }
    public virtual String InternClassStruct { get; set; }
    public virtual String InternModuleStruct { get; set; }
    public virtual String InternBaseSet { get; set; }
    public virtual String InternModuleSet { get; set; }
    public virtual String RefKindIntMacro { get; set; }
    public virtual String RefKindStringValueMacro { get; set; }
    public virtual String RefKindStringValueDataMacro { get; set; }
    public virtual String StateGet { get; set; }
    public virtual String StateSet { get; set; }
    public virtual String StateCall { get; set; }
    public virtual String NameCombine { get; set; }
    public virtual String NamePre { get; set; }
    public virtual String ClassWord { get; set; }
    public virtual String ModuleWord { get; set; }
    public virtual String ListWord { get; set; }
    public virtual String BaseWord { get; set; }
    public virtual String ItemWord { get; set; }
    public virtual String AnyWord { get; set; }
    public virtual String InitWord { get; set; }
    public virtual String CountWord { get; set; }
    public virtual String VarWord { get; set; }
    public virtual String ImportWord { get; set; }
    public virtual String ExportWord { get; set; }
    public virtual String ApiWord { get; set; }
    public virtual String InternWord { get; set; }
    public virtual String ExternWord { get; set; }
    public virtual String StringWord { get; set; }
    public virtual String DataWord { get; set; }
    public virtual String EntryWord { get; set; }
    public virtual String VarOWord { get; set; }
    public virtual String VarKWord { get; set; }
    public virtual String VarMWord { get; set; }
    public virtual String VarNWord { get; set; }
    public virtual String CastInt { get; set; }
    public virtual String WhileLabelPre { get; set; }
    public virtual String DirectiveInclude { get; set; }
    public virtual String IncludeValueInfra { get; set; }
    public virtual String IncludeValueInfraIntern { get; set; }
    public virtual String IncludeValueInfraInternIntern { get; set; }
    public virtual String IncludeValueInfraInternExtern { get; set; }
    public virtual String IndexExtern { get; set; }
    public virtual String IndexStatic { get; set; }
    public virtual String IndexReturn { get; set; }
    public virtual String IndexInf { get; set; }
    public virtual String IndexGoto { get; set; }
    public virtual String LimitDot { get; set; }
    public virtual String LimitDotPointer { get; set; }
    public virtual String LimitBraceRoundLite { get; set; }
    public virtual String LimitBraceRoundRite { get; set; }
    public virtual String LimitBraceRightLite { get; set; }
    public virtual String LimitBraceRightRite { get; set; }
    public virtual String LimitBraceCurveLite { get; set; }
    public virtual String LimitBraceCurveRite { get; set; }
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
    public virtual InfraInfra InfraInfra { get; set; }
    public virtual BinaryOperateKindList OperateKindList { get; set; }

    public virtual String RefKindMask(String kindHexDigit)
    {
        return this.AddClear().Add(this.IntValueHexPre).Add(kindHexDigit).AddS("000000000000000").AddResult();
    }

    public virtual bool Execute()
    {
        this.Arg = new ClassGenArg();
        this.Arg.Init();

        this.Operate = this.CountOperate;

        this.ResetStage();
        this.ExecuteStage();

        long count;
        count = this.Arg.Index;
        count = count * sizeof(int);
        this.Arg.Data = new Data();
        this.Arg.Data.Count = count;
        this.Arg.Data.Init();

        this.Operate = this.SetOperate;

        this.ResetStage();
        this.ExecuteStage();

        String k;
        k = this.StringComp.CreateData(this.Arg.Data, null);
        this.Result = k;

        this.Operate = null;
        this.Arg = null;
        return true;
    }

    public virtual bool ResetStage()
    {
        this.Arg.Index = 0;
        return true;
    }

    public virtual bool ExecuteStage()
    {
        this.ExecuteModule();

        this.ExecuteRefer();

        this.ExecuteState();
        return true;
    }

    public virtual bool ExecuteRefer()
    {
        long count;
        count = this.Module.Class.Count;

        Iter iter;
        iter = this.ClassIter;
        this.Module.Class.IterSet(iter);

        long i;
        i = 0;
        while (i < count)
        {
            iter.Next();

            ClassClass k;
            k = iter.Value as ClassClass;

            this.Class = k;

            this.Base = this.BaseArray.GetAt(i) as Array;
            this.Comp = this.CompArray.GetAt(i) as ClassComp;
            this.String = this.StringArray.GetAt(i) as Array;

            this.ExecuteReferClass();

            this.String = null;
            this.Comp = null;
            this.Base = null;

            this.Class = null;

            i = i + 1;
        }

        iter.Clear();
        return true;
    }

    public virtual bool ExecuteModule()
    {
        this.ExecuteExtern();

        this.ExecuteModuleStruct();
        this.Text(this.NewLine);

        this.ExecuteModuleVar();
        this.Text(this.NewLine);

        this.ExecuteModuleEntry();
        this.Text(this.NewLine);

        this.ExecuteModuleCount();
        this.Text(this.NewLine);

        this.ExecuteClassList();
        this.Text(this.NewLine);

        this.ExecuteModuleInit();
        return true;
    }

    public virtual bool ExecuteExtern()
    {
        this.Include(this.IncludeValueInfra);
        this.Include(this.IncludeValueInfraIntern);
        this.Text(this.NewLine);

        if (this.SystemInfraModule)
        {
            this.Include(this.IncludeValueInfraInternIntern);
            this.Include(this.IncludeValueInfraInternExtern);
            this.Text(this.NewLine);
        }

        this.ExecuteExternModuleStruct();
        this.Text(this.NewLine);

        this.ExecuteExternModuleInit();
        this.Text(this.NewLine);

        this.ExecuteExternModuleVar();
        this.Text(this.NewLine);

        this.ExecuteExternModuleEntry();
        this.Text(this.NewLine);

        this.ExecuteExternModuleCount();
        this.Text(this.NewLine);

        this.ExecuteExternImportModuleStruct();
        this.Text(this.NewLine);

        this.ExecuteExternImportModuleInit();
        this.Text(this.NewLine);

        this.ExecuteExternClassInit();
        return true;
    }

    public virtual bool ExecuteExternModuleStruct()
    {
        this.Text(this.ExportWord);
        this.Text(this.ApiWord);
        this.Text(this.Space);

        this.Text(this.IndexExtern);
        this.Text(this.Space);

        this.Text(this.InternModuleStruct);
        this.Text(this.Space);

        this.ModuleStructName(this.Module.Ref);

        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool ExecuteExternImportModuleStruct()
    {
        Iter iter;
        iter = this.TableIter;

        this.Module.Import.IterSet(iter);

        while (iter.Next())
        {
            ModuleRef module;
            module = iter.Index as ModuleRef;

            this.Text(this.ImportWord);
            this.Text(this.ApiWord);
            this.Text(this.Space);

            this.Text(this.IndexExtern);
            this.Text(this.Space);

            this.Text(this.InternModuleStruct);
            this.Text(this.Space);

            this.ModuleStructName(module);

            this.Text(this.LimitSemicolon);
            this.Text(this.NewLine);
        }

        iter.Clear();
        return true;
    }

    public virtual bool ExecuteExternModuleInit()
    {
        this.Text(this.ExportWord);
        this.Text(this.ApiWord);
        this.Text(this.Space);

        this.Text(this.ClassInt);
        this.Text(this.Space);

        this.ModuleInitName(this.Module.Ref);
        this.Text(this.LimitBraceRoundLite);
        this.Text(this.LimitBraceRoundRite);
        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool ExecuteExternModuleVar()
    {
        this.Text(this.ExportWord);
        this.Text(this.ApiWord);
        this.Text(this.Space);

        this.Text(this.ClassInt);
        this.Text(this.Space);

        this.ModuleVarName(this.Module.Ref);
        this.Text(this.LimitBraceRoundLite);
        this.Text(this.LimitBraceRoundRite);
        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool ExecuteExternModuleEntry()
    {
        this.Text(this.ExportWord);
        this.Text(this.ApiWord);
        this.Text(this.Space);

        this.Text(this.ClassInt);
        this.Text(this.Space);

        this.ModuleEntryName(this.Module.Ref);
        this.Text(this.LimitBraceRoundLite);
        this.Text(this.LimitBraceRoundRite);
        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool ExecuteExternModuleCount()
    {
        this.Text(this.ExportWord);
        this.Text(this.ApiWord);
        this.Text(this.Space);

        this.Text(this.ClassInt);
        this.Text(this.Space);

        this.ModuleCountName(this.Module.Ref);
        this.Text(this.LimitBraceRoundLite);
        this.Text(this.LimitBraceRoundRite);
        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool ExecuteExternImportModuleInit()
    {
        Iter iter;
        iter = this.TableIter;

        this.Module.Import.IterSet(iter);

        while (iter.Next())
        {
            ModuleRef module;
            module = iter.Index as ModuleRef;

            this.Text(this.ImportWord);
            this.Text(this.ApiWord);
            this.Text(this.Space);

            this.Text(this.ClassInt);
            this.Text(this.Space);

            this.ModuleInitName(module);
            this.Text(this.LimitBraceRoundLite);
            this.Text(this.LimitBraceRoundRite);
            this.Text(this.LimitSemicolon);
            this.Text(this.NewLine);
        }

        iter.Clear();
        return true;
    }

    public virtual bool ExecuteExternClassInit()
    {
        Iter iter;
        iter = this.TableIter;

        this.Module.Class.IterSet(iter);

        while (iter.Next())
        {
            ClassClass varClass;
            varClass = iter.Value as ClassClass;

            this.Text(this.ClassInt);
            this.Text(this.Space);

            this.ClassInitName(varClass);
            this.Text(this.LimitBraceRoundLite);
            this.Text(this.LimitBraceRoundRite);
            this.Text(this.LimitSemicolon);
            this.Text(this.NewLine);
        }

        iter.Clear();
        return true;
    }

    public virtual bool ExecuteModuleStruct()
    {
        this.Text(this.InternModuleStruct);
        this.Text(this.Space);

        this.ModuleStructName(this.Module.Ref);

        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool ExecuteModuleVar()
    {
        this.Text(this.ClassInt);
        this.Text(this.Space);

        this.ModuleVarName(this.Module.Ref);
        this.Text(this.LimitBraceRoundLite);
        this.Text(this.LimitBraceRoundRite);
        this.Text(this.NewLine);

        this.Text(this.LimitBraceCurveLite);
        this.Text(this.NewLine);

        this.IndentCount = this.IndentCount + 1;

        this.TextIndent();
        this.Text(this.IndexReturn);
        this.Text(this.Space);

        this.Text(this.CastInt);
        this.Text(this.LimitBraceRoundLite);
        this.Text(this.LimitAnd);
        this.ModuleStructName(this.Module.Ref);
        this.Text(this.LimitBraceRoundRite);

        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);

        this.IndentCount = this.IndentCount - 1;

        this.Text(this.LimitBraceCurveRite);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool ExecuteModuleEntry()
    {
        this.Text(this.ClassInt);
        this.Text(this.Space);

        this.ModuleEntryName(this.Module.Ref);
        this.Text(this.LimitBraceRoundLite);
        this.Text(this.LimitBraceRoundRite);
        this.Text(this.NewLine);

        this.Text(this.LimitBraceCurveLite);
        this.Text(this.NewLine);

        this.IndentCount = this.IndentCount + 1;

        this.TextIndent();
        this.Text(this.IndexReturn);
        this.Text(this.Space);

        bool b;
        b = (this.Module.Entry == null);
        if (b)
        {
            this.Text(this.LimitBraceRoundLite);
            this.Text(this.LimitBraceRoundLite);
            this.Text(this.ClassInt);
            this.Text(this.LimitBraceRoundRite);
            this.Text(this.LimitBraceRoundLite);
            this.Text(this.LimitBraceRoundLite);
            this.Text(this.ClassSInt);
            this.Text(this.LimitBraceRoundRite);
            this.Text(this.LimitSub);
            this.Text(this.One);
            this.Text(this.LimitBraceRoundRite);
            this.Text(this.LimitBraceRoundRite);
        }
        if (!b)
        {
            ClassClass varClass;
            varClass = this.Module.Class.Get(this.Module.Entry) as ClassClass;

            this.TextInt(varClass.Index);
        }

        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);

        this.IndentCount = this.IndentCount - 1;

        this.Text(this.LimitBraceCurveRite);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool ExecuteModuleCount()
    {
        long count;
        count = this.ModuleCount + 1;

        this.Text(this.ClassInt);
        this.Text(this.Space);

        this.ModuleCountName(this.Module.Ref);
        this.Text(this.LimitBraceRoundLite);
        this.Text(this.LimitBraceRoundRite);
        this.Text(this.NewLine);

        this.Text(this.LimitBraceCurveLite);
        this.Text(this.NewLine);

        this.IndentCount = this.IndentCount + 1;

        this.TextIndent();
        this.Text(this.IndexReturn);
        this.Text(this.Space);

        this.TextInt(count);

        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);

        this.IndentCount = this.IndentCount - 1;

        this.Text(this.LimitBraceCurveRite);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool ExecuteClassList()
    {
        this.Text(this.IndexStatic);
        this.Text(this.Space);

        this.Text(this.InternClassStruct);
        this.Text(this.Space);

        this.Text(this.ClassWord);
        this.Text(this.ListWord);
        this.Text(this.LimitBraceRightLite);
        this.TextInt(this.Module.Class.Count);
        this.Text(this.LimitBraceRightRite);

        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool ExecuteModuleInit()
    {
        this.Text(this.ClassInt);
        this.Text(this.Space);

        this.ModuleInitName(this.Module.Ref);
        this.Text(this.LimitBraceRoundLite);
        this.Text(this.LimitBraceRoundRite);
        this.Text(this.NewLine);

        this.Text(this.LimitBraceCurveLite);
        this.Text(this.NewLine);

        this.IndentCount = this.IndentCount + 1;

        this.TextIndent();
        this.Text(this.InternModuleStruct);
        this.Text(this.LimitAsterisk);
        this.Text(this.Space);
        this.Text(this.VarOWord);
        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);

        this.TextIndent();
        this.Text(this.VarOWord);
        this.Text(this.Space);
        this.Text(this.LimitAre);
        this.Text(this.Space);
        this.Text(this.LimitAnd);
        this.ModuleStructName(this.Module.Ref);
        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);

        this.TextIndent();
        this.Text(this.IndexInf);
        this.Text(this.Space);
        this.Text(this.LimitBraceRoundLite);
        this.Text(this.VarOWord);
        this.Text(this.LimitDotPointer);
        this.Text(this.InitWord);
        this.Text(this.LimitBraceRoundRite);
        this.Text(this.NewLine);

        this.TextIndent();
        this.Text(this.LimitBraceCurveLite);
        this.Text(this.NewLine);

        this.IndentCount = this.IndentCount + 1;

        this.TextIndent();
        this.Text(this.IndexReturn);
        this.Text(this.Space);
        this.Text(this.Zero);
        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);

        this.IndentCount = this.IndentCount - 1;

        this.TextIndent();
        this.Text(this.LimitBraceCurveRite);
        this.Text(this.NewLine);

        this.TextIndent();
        this.Text(this.VarOWord);
        this.Text(this.LimitDotPointer);
        this.Text(this.InitWord);
        this.Text(this.Space);
        this.Text(this.LimitAre);
        this.Text(this.Space);
        this.Text(this.One);
        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);

        this.ExecuteModuleInitImport();

        this.TextIndent();
        this.Text(this.InternModuleSet);
        this.Text(this.LimitBraceRoundLite);
        this.Text(this.VarOWord);
        this.Text(this.LimitBraceRoundRite);
        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);

        this.TextIndent();
        this.Text(this.VarOWord);
        this.Text(this.LimitDotPointer);
        this.Text(this.ClassWord);
        this.Text(this.Space);
        this.Text(this.LimitAre);
        this.Text(this.Space);
        this.Text(this.ClassWord);
        this.Text(this.ListWord);
        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);

        this.TextIndent();
        this.Text(this.VarOWord);
        this.Text(this.LimitDotPointer);
        this.Text(this.CountWord);
        this.Text(this.Space);
        this.Text(this.LimitAre);
        this.Text(this.Space);
        this.TextInt(this.Module.Class.Count);
        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);

        this.ExecuteModuleInitClass();

        this.TextIndent();
        this.Text(this.IndexReturn);
        this.Text(this.Space);
        this.Text(this.Zero);
        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);

        this.IndentCount = this.IndentCount - 1;

        this.Text(this.LimitBraceCurveRite);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool ExecuteModuleInitImport()
    {
        Iter iter;
        iter = this.TableIter;

        this.Module.Import.IterSet(iter);

        while (iter.Next())
        {
            ModuleRef moduleRef;
            moduleRef = iter.Index as ModuleRef;

            this.TextIndent();
            this.ModuleInitName(moduleRef);
            this.Text(this.LimitBraceRoundLite);
            this.Text(this.LimitBraceRoundRite);
            this.Text(this.LimitSemicolon);
            this.Text(this.NewLine);
        }

        iter.Clear();
        return true;
    }

    public virtual bool ExecuteModuleInitClass()
    {
        long count;
        count = this.InitArray.Count;
        long i;
        i = 0;
        while (i < count)
        {
            ClassClass varClass;
            varClass = this.InitArray.GetAt(i) as ClassClass;

            this.TextIndent();
            this.ClassInitName(varClass);
            this.Text(this.LimitBraceRoundLite);
            this.Text(this.LimitBraceRoundRite);
            this.Text(this.LimitSemicolon);
            this.Text(this.NewLine);

            i = i + 1;
        }

        return true;
    }

    public virtual bool ExecuteReferClass()
    {
        this.StringValueIndex = 0;

        this.WhileIndex = 0;

        this.ExecuteCompList(this.Comp.Field, this.StateGet);
        this.Text(this.NewLine);
        this.ExecuteCompList(this.Comp.Field, this.StateSet);
        this.Text(this.NewLine);
        this.ExecuteCompList(this.Comp.Maide, this.StateCall);
        this.Text(this.NewLine);

        this.ExecuteBase();
        this.Text(this.NewLine);

        this.ExecuteExternCompState();
        this.Text(this.NewLine);

        this.ExecuteClassInit();

        if (this.Class == this.InternClass | this.Class == this.ExternClass)
        {
            return true;
        }

        this.ExecuteString();
        return true;
    }

    public virtual bool ExecuteCompList(Array array, String stateKind)
    {
        long count;
        count = array.Count;

        this.Text(this.IndexStatic);
        this.Text(this.Space);

        this.Text(this.ClassInt);
        this.Text(this.Space);

        this.CompListName(this.Class, stateKind);
        this.Text(this.LimitBraceRightLite);
        this.TextInt(count);
        this.Text(this.LimitBraceRightRite);

        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool ExecuteBase()
    {
        long count;
        count = this.Base.Count;

        this.Text(this.IndexStatic);
        this.Text(this.Space);

        this.Text(this.ClassInt);
        this.Text(this.Space);

        this.BaseName(this.Class);
        this.Text(this.LimitBraceRightLite);
        this.TextInt(count);
        this.Text(this.LimitBraceRightRite);

        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool ExecuteExternCompState()
    {
        if (this.Class == this.InternClass | this.Class == this.ExternClass)
        {
            return true;
        }

        Iter iter;
        iter = this.TableIter;

        this.Class.Field.IterSet(iter);

        while (iter.Next())
        {
            object ka;
            ka = iter.Value;

            this.CompStateHead(this.Class, ka, this.StateKindGet);
            this.Text(this.LimitSemicolon);
            this.Text(this.NewLine);

            this.CompStateHead(this.Class, ka, this.StateKindSet);
            this.Text(this.LimitSemicolon);
            this.Text(this.NewLine);
        }

        this.Class.Maide.IterSet(iter);

        while (iter.Next())
        {
            object kb;
            kb = iter.Value;

            this.CompStateHead(this.Class, kb, this.StateKindCall);
            this.Text(this.LimitSemicolon);
            this.Text(this.NewLine);
        }

        iter.Clear();
        return true;
    }

    public virtual bool ExecuteClassInit()
    {
        long baseIndex;
        baseIndex = this.Base.Count - 1;

        long baseMask;
        baseMask = baseIndex << 52;

        long fieldCount;
        fieldCount = this.Class.FieldStart + this.Class.Field.Count;

        this.Text(this.ClassInt);
        this.Text(this.Space);

        this.ClassInitName(this.Class);
        this.Text(this.LimitBraceRoundLite);
        this.Text(this.LimitBraceRoundRite);
        this.Text(this.NewLine);

        this.Text(this.LimitBraceCurveLite);
        this.Text(this.NewLine);

        this.IndentCount = this.IndentCount + 1;

        this.TextIndent();
        this.Text(this.InternModuleStruct);
        this.Text(this.LimitAsterisk);
        this.Text(this.Space);
        this.Text(this.VarOWord);
        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);

        this.TextIndent();
        this.Text(this.VarOWord);
        this.Text(this.Space);
        this.Text(this.LimitAre);
        this.Text(this.Space);
        this.Text(this.LimitAnd);
        this.ModuleStructName(this.Class.Module.Ref);
        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);

        this.TextIndent();
        this.Text(this.InternClassStruct);
        this.Text(this.LimitAsterisk);
        this.Text(this.Space);
        this.Text(this.VarKWord);
        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);

        this.TextIndent();
        this.Text(this.VarKWord);
        this.Text(this.Space);
        this.Text(this.LimitAre);
        this.Text(this.Space);
        this.Text(this.LimitAnd);
        this.ModuleClass(this.Class);
        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);

        this.TextIndent();
        this.Text(this.VarKWord);
        this.Text(this.LimitDotPointer);
        this.Text(this.VarWord);
        this.Text(this.Space);
        this.Text(this.LimitAre);
        this.Text(this.Space);
        this.Text(this.CastInt);
        this.Text(this.LimitBraceRoundLite);
        this.Text(this.VarKWord);
        this.Text(this.LimitDotPointer);
        this.Text(this.DataWord);
        this.Text(this.LimitBraceRoundRite);
        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);

        this.TextIndent();
        this.Text(this.VarKWord);
        this.Text(this.LimitDotPointer);
        this.Text(this.DataWord);
        this.Text(this.LimitBraceRightLite);
        this.TextInt(0);
        this.Text(this.LimitBraceRightRite);
        this.Text(this.Space);
        this.Text(this.LimitAre);
        this.Text(this.Space);
        this.Text(this.CastInt);
        this.Text(this.LimitBraceRoundLite);
        this.BaseName(this.Class);
        this.Text(this.LimitBraceRoundRite);
        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);

        this.TextIndent();
        this.Text(this.VarKWord);
        this.Text(this.LimitDotPointer);
        this.Text(this.DataWord);
        this.Text(this.LimitBraceRightLite);
        this.TextInt(1);
        this.Text(this.LimitBraceRightRite);
        this.Text(this.Space);
        this.Text(this.LimitAre);
        this.Text(this.Space);
        this.TextIntHex(baseMask);
        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);

        this.TextIndent();
        this.Text(this.VarKWord);
        this.Text(this.LimitDotPointer);
        this.Text(this.DataWord);
        this.Text(this.LimitBraceRightLite);
        this.TextInt(2);
        this.Text(this.LimitBraceRightRite);
        this.Text(this.Space);
        this.Text(this.LimitAre);
        this.Text(this.Space);
        this.TextInt(fieldCount);
        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);

        this.ExecuteBaseArraySet();

        this.ExecuteBaseItemSet();

        this.ExecuteCompListSet();

        this.TextIndent();
        this.Text(this.IndexReturn);
        this.Text(this.Space);
        this.Text(this.Zero);
        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);

        this.IndentCount = this.IndentCount - 1;

        this.Text(this.LimitBraceCurveRite);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool ExecuteBaseArraySet()
    {
        long count;
        count = this.Base.Count;
        count = count - 1;

        this.TextIndent();
        this.Text(this.InternBaseSet);
        this.Text(this.LimitBraceRoundLite);
        this.Text(this.VarKWord);
        this.Text(this.LimitComma);
        this.Text(this.Space);

        this.Text(this.LimitAnd);
        this.ModuleClass(this.Class.Base);
        this.Text(this.LimitComma);
        this.Text(this.Space);

        this.TextInt(count);

        this.Text(this.LimitBraceRoundRite);

        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool ExecuteBaseItemSet()
    {
        this.TextIndent();
        this.Text(this.VarKWord);
        this.Text(this.LimitDotPointer);
        this.Text(this.BaseWord);
        this.Text(this.ItemWord);
        this.Text(this.LimitBraceRightLite);
        this.TextInt(0);
        this.Text(this.LimitBraceRightRite);

        this.Text(this.Space);
        this.Text(this.LimitAre);
        this.Text(this.Space);

        this.Text(this.VarKWord);
        this.Text(this.LimitDotPointer);
        this.Text(this.VarWord);

        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);

        this.ExecuteBaseItemSetCompList(this.StateKindGet, this.StateGet);
        this.ExecuteBaseItemSetCompList(this.StateKindSet, this.StateSet);
        this.ExecuteBaseItemSetCompList(this.StateKindCall, this.StateCall);
        return true;
    }

    public virtual bool ExecuteBaseItemSetCompList(long index, String stateKind)
    {
        this.TextIndent();
        this.Text(this.VarKWord);
        this.Text(this.LimitDotPointer);
        this.Text(this.BaseWord);
        this.Text(this.ItemWord);
        this.Text(this.LimitBraceRightLite);
        this.TextInt(index);
        this.Text(this.LimitBraceRightRite);

        this.Text(this.Space);
        this.Text(this.LimitAre);
        this.Text(this.Space);

        this.Text(this.CastInt);
        this.Text(this.LimitBraceRoundLite);
        this.CompListName(this.Class, stateKind);
        this.Text(this.LimitBraceRoundRite);

        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool ExecuteCompListSet()
    {
        this.TextIndent();
        this.Text(this.ClassInt);
        this.Text(this.LimitAsterisk);
        this.Text(this.Space);
        this.Text(this.VarMWord);
        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);

        this.TextIndent();
        this.Text(this.ClassInt);
        this.Text(this.LimitAsterisk);
        this.Text(this.Space);
        this.Text(this.VarNWord);
        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);

        this.ExecuteCompListSetKind(this.Comp.Field, this.StateKindGet);
        this.ExecuteCompListSetKind(this.Comp.Field, this.StateKindSet);
        this.ExecuteCompListSetKind(this.Comp.Maide, this.StateKindCall);
        return true;
    }

    public virtual bool ExecuteCompListSetKind(Array array, long stateKind)
    {
        this.TextIndent();
        this.Text(this.VarNWord);
        this.Text(this.Space);
        this.Text(this.LimitAre);
        this.Text(this.Space);

        this.Text(this.LimitBraceRoundLite);
        this.Text(this.ClassInt);
        this.Text(this.LimitAsterisk);
        this.Text(this.LimitBraceRoundRite);

        this.Text(this.LimitBraceRoundLite);

        this.Text(this.VarKWord);
        this.Text(this.LimitDotPointer);
        this.Text(this.BaseWord);
        this.Text(this.ItemWord);
        this.Text(this.LimitBraceRightLite);
        this.TextInt(stateKind);
        this.Text(this.LimitBraceRightRite);

        this.Text(this.LimitBraceRoundRite);

        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);

        this.TextIndent();
        this.Text(this.VarMWord);
        this.Text(this.Space);
        this.Text(this.LimitAre);
        this.Text(this.Space);

        this.Text(this.LimitBraceRoundLite);
        this.Text(this.ClassInt);
        this.Text(this.LimitAsterisk);
        this.Text(this.LimitBraceRoundRite);

        this.Text(this.LimitBraceRoundLite);

        this.ModuleClass(this.Class.Base);
        this.Text(this.LimitDot);
        this.Text(this.BaseWord);
        this.Text(this.ItemWord);
        this.Text(this.LimitBraceRightLite);
        this.TextInt(stateKind);
        this.Text(this.LimitBraceRightRite);

        this.Text(this.LimitBraceRoundRite);

        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);

        bool b;
        b = (stateKind == this.StateKindCall);

        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            object k;
            k = array.GetAt(i);

            bool baa;
            baa = (k == null);

            ClassClass ka;
            ka = null;

            if (!baa)
            {
                if (!b)
                {
                    Field field;
                    field = k as Field;
                    ka = field.Parent;
                }
                if (b)
                {
                    Maide maide;
                    maide = k as Maide;
                    ka = maide.Parent;
                }

                bool ba;
                ba = (ka == this.Class);

                if (ba)
                {
                    this.ExecuteCompListSetStateThisClass(i, k, stateKind);
                }
                if (!ba)
                {
                    this.ExecuteCompListSetStateBaseClass(i);
                }
            }

            i = i + 1;
        }
        return true;
    }

    public virtual bool ExecuteCompListSetStateThisClass(long index, object comp, long stateKind)
    {
        this.TextIndent();

        this.Text(this.VarNWord);
        this.Text(this.LimitBraceRightLite);
        this.TextInt(index);
        this.Text(this.LimitBraceRightRite);

        this.Text(this.Space);
        this.Text(this.LimitAre);
        this.Text(this.Space);

        this.Text(this.CastInt);
        this.Text(this.LimitBraceRoundLite);
        this.CompStateName(this.Class, comp, stateKind);
        this.Text(this.LimitBraceRoundRite);

        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool ExecuteCompListSetStateBaseClass(long index)
    {
        this.TextIndent();

        this.Text(this.VarNWord);
        this.Text(this.LimitBraceRightLite);
        this.TextInt(index);
        this.Text(this.LimitBraceRightRite);

        this.Text(this.Space);
        this.Text(this.LimitAre);
        this.Text(this.Space);

        this.Text(this.VarMWord);
        this.Text(this.LimitBraceRightLite);
        this.TextInt(index);
        this.Text(this.LimitBraceRightRite);

        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool ExecuteState()
    {
        this.StateDataIndex = 0;

        long stateCount;
        stateCount = this.StateInt();

        Iter iter;
        iter = this.ClassIter;

        this.Module.Class.IterSet(iter);

        while (iter.Next())
        {
            ClassClass k;
            k = iter.Value as ClassClass;

            this.Class = k;

            this.ExecuteStateClass();

            this.Class = null;
        }

        iter.Clear();
        return true;
    }

    public virtual bool ExecuteStateClass()
    {
        this.StringValueIndex = 0;

        this.WhileIndex = 0;

        Iter iter;
        iter = this.TableIter;

        this.Class.Field.IterSet(iter);

        while (iter.Next())
        {
            Field varField;
            varField = iter.Value as Field;

            this.ExecuteStateFieldGet(varField);

            this.ExecuteStateFieldSet(varField);
        }

        this.Class.Maide.IterSet(iter);

        while (iter.Next())
        {
            Maide varMaide;
            varMaide = iter.Value as Maide;

            this.ExecuteStateMaideCall(varMaide);
        }

        iter.Clear();
        return true;
    }

    public virtual bool ExecuteStateFieldGet(Field varField)
    {
        return true;
    }

    public virtual bool ExecuteStateFieldSet(Field varField)
    {
        return true;
    }

    public virtual bool ExecuteStateMaideCall(Maide varMaide)
    {
        return true;
    }

    public virtual bool ExecuteCompState()
    {
        long varCount;
        varCount = this.StateInt();

        this.ExecuteOperateList();
        return true;
    }

    public virtual bool ExecuteOperateList()
    {
        long count;
        count = this.StateInt();

        long i;
        i = 0;
        while (i < count)
        {
            this.ExecuteOperate();

            i = i + 1;
        }
        return true;
    }

    public virtual bool ExecuteOperate()
    {
        long kindIndex;
        kindIndex = this.OperateKind();

        BinaryOperateKind kind;
        kind = this.OperateKindList.Get(kindIndex);

        ClassGenOperateState state;
        state = kind.Any as ClassGenOperateState;

        state.Execute();
        return true;
    }

    public virtual bool ExecuteOperateEnd()
    {
        this.EvalIndexPosSet(-1);
        return true;
    }

    public virtual bool ExecuteOperateRet()
    {
        String varA;
        varA = this.VarA;

        long k;
        k = this.ParamCount;

        this.EvalValueGet(1, varA);

        this.EvalFrameValueSet(-(k + 1), varA);

        this.EvalIndexFramePosSet(-k);

        this.Return();
        return true;
    }

    public virtual bool ExecuteOperateGet()
    {
        long kk;
        kk = this.OperateArgInt();

        long k;
        k = 1;

        this.ExecuteVirtualCall(k, this.StateKindGet, kk);

        return true;
    }

    public virtual bool ExecuteOperateCall()
    {
        long kk;
        kk = this.OperateArgInt();

        long k;
        k = this.OperateArgInt();
        k = k + 1;

        if (kk == 0)
        {
            this.ExecuteVirtualCallThisCond(k);
        }

        this.ExecuteVirtualCall(k, this.StateKindCall, kk);

        return true;
    }

    public virtual bool ExecuteOperateThis()
    {
        String varA;
        varA = this.VarA;

        long k;
        k = this.ParamCount;

        this.EvalFrameValueGet(-(k + 1), varA);

        this.EvalValueSet(0, varA);

        this.EvalIndexPosSet(1);
        return true;
    }

    public virtual bool ExecuteOperateBase()
    {
        String varA;
        varA = this.VarA;

        long k;
        k = this.ParamCount;

        long kk;
        kk = this.ClassBaseMask(this.Class.BaseCount);

        this.EvalFrameValueGet(-(k + 1), varA);

        this.VarMaskClear(varA, this.BaseClearMask);

        this.VarMaskSetInt(varA, kk);

        this.EvalValueSet(0, varA);

        this.EvalIndexPosSet(1);
        return true;
    }

    public virtual bool ExecuteOperateNull()
    {
        String varA;
        varA = this.VarA;

        this.VarSet(varA, this.Zero);

        this.EvalValueSet(0, varA);

        this.EvalIndexPosSet(1);
        return true;
    }

    public virtual long OperateKind()
    {
        return this.StateByte();
    }

    public virtual long OperateArgInt()
    {
        return this.StateInt();
    }

    public virtual long StateInt()
    {
        return this.StateIntCount(sizeof(long));
    }

    public virtual long StateIntCount(long count)
    {
        long k;
        k = 0;

        long i;
        i = 0;
        while (i < count)
        {
            long ka;
            ka = this.StateByte();

            int shift;
            shift = (int)(i * 8);

            ka = ka << shift;

            k = k | ka;

            i = i + 1;
        }

        k = k & (this.InfraInfra.IntCapValue - 1);

        long a;
        a = k;
        return a;
    }

    public virtual long StateByte()
    {
        long k;
        k = this.Binary.State.Get(this.StateDataIndex);

        this.StateDataIndex = this.StateDataIndex + 1;

        long a;
        a = k;
        return a;
    }

    public virtual bool ExecuteString()
    {
        this.ExecuteStringData();
        this.Text(this.NewLine);
        this.ExecuteStringAny();
        this.Text(this.NewLine);
        this.ExecuteStringList();
        return true;
    }

    public virtual bool ExecuteStringData()
    {
        long count;
        count = this.String.Count;
        long i;
        i = 0;
        while (i < count)
        {
            String a;
            a = this.String.GetAt(i) as String;

            long countA;
            countA = this.StringCount(a);

            this.Text(this.IndexStatic);
            this.Text(this.Space);

            this.Text(this.ClassInt32);
            this.Text(this.Space);

            this.StringDataName(this.Class, i);

            this.Text(this.LimitBraceRightLite);

            this.TextInt(countA);

            this.Text(this.LimitBraceRightRite);

            this.Text(this.Space);

            this.Text(this.LimitAre);

            this.Text(this.NewLine);

            this.Text(this.LimitBraceCurveLite);

            this.IndentCount = this.IndentCount + 1;

            long iA;
            iA = 0;
            while (iA < countA)
            {
                long kea;
                kea = (iA / 8) * 8;
                long kka;
                kka = iA - kea;

                if (kka == 0)
                {
                    this.Text(this.NewLine);

                    this.TextIndent();
                }

                this.Text(this.IntValueHexPre);

                long n;
                n = this.StringChar(a, iA);

                long countB;
                countB = 8;
                long iB;
                iB = 0;
                while (iB < countB)
                {
                    long kaa;
                    kaa = countB - 1 - iB;

                    int shiftCount;
                    shiftCount = (int)(kaa * 4);

                    long ka;
                    ka = n >> shiftCount;
                    ka = ka & 0xf;

                    long na;
                    na = this.TextInfra.DigitChar(ka, 'a');

                    this.ExecuteChar(na);

                    iB = iB + 1;
                }

                this.Text(this.LimitComma);
                this.Text(this.Space);

                iA = iA + 1;
            }

            this.IndentCount = this.IndentCount - 1;

            this.Text(this.NewLine);
            this.Text(this.LimitBraceCurveRite);
            this.Text(this.LimitSemicolon);
            this.Text(this.NewLine);

            i = i + 1;
        }
        return true;
    }

    public virtual bool ExecuteStringAny()
    {
        long count;
        count = this.String.Count;
        long i;
        i = 0;
        while (i < count)
        {
            String a;
            a = this.String.GetAt(i) as String;

            long ka;
            ka = this.StringCount(a);

            this.Text(this.IndexStatic);
            this.Text(this.Space);

            this.Text(this.ClassInt);
            this.Text(this.Space);

            this.StringAnyName(this.Class, i);

            this.Text(this.LimitBraceRightLite);

            this.TextInt(2);

            this.Text(this.LimitBraceRightRite);

            this.Text(this.Space);

            this.Text(this.LimitAre);

            this.Text(this.NewLine);

            this.Text(this.LimitBraceCurveLite);

            this.Text(this.NewLine);

            this.IndentCount = this.IndentCount + 1;

            this.TextIndent();

            this.Text(this.CastInt);
            this.Text(this.LimitBraceRoundLite);
            this.StringDataName(this.Class, i);
            this.Text(this.LimitBraceRoundRite);

            this.Text(this.Space);
            this.Text(this.LimitAdd);
            this.Text(this.Space);

            this.Text(this.LimitBraceRoundLite);
            this.Text(this.RefKindStringValueDataMacro);
            this.Text(this.Space);
            this.Text(this.LimitBitLite);
            this.Text(this.Space);
            this.TextInt(60);
            this.Text(this.LimitBraceRoundRite);

            this.Text(this.LimitComma);
            this.Text(this.NewLine);

            this.TextIndent();

            this.TextInt(ka);
            this.Text(this.Space);
            this.Text(this.LimitAdd);
            this.Text(this.Space);

            this.Text(this.LimitBraceRoundLite);
            this.Text(this.RefKindIntMacro);
            this.Text(this.Space);
            this.Text(this.LimitBitLite);
            this.Text(this.Space);
            this.TextInt(60);
            this.Text(this.LimitBraceRoundRite);

            this.Text(this.NewLine);

            this.IndentCount = this.IndentCount - 1;

            this.Text(this.LimitBraceCurveRite);

            this.Text(this.LimitSemicolon);

            this.Text(this.NewLine);

            i = i + 1;
        }
        return true;
    }

    public virtual bool ExecuteStringList()
    {
        long count;
        count = this.String.Count;

        this.Text(this.IndexStatic);
        this.Text(this.Space);

        this.Text(this.ClassInt);
        this.Text(this.Space);

        this.StringListName(this.Class);

        this.Text(this.LimitBraceRightLite);
        this.TextInt(count);
        this.Text(this.LimitBraceRightRite);

        this.Text(this.Space);
        this.Text(this.LimitAre);
        this.Text(this.NewLine);

        this.Text(this.LimitBraceCurveLite);
        this.Text(this.NewLine);

        this.IndentCount = this.IndentCount + 1;

        long i;
        i = 0;
        while (i < count)
        {
            this.TextIndent();

            this.Text(this.CastInt);
            this.Text(this.LimitBraceRoundLite);
            this.StringAnyName(this.Class, i);
            this.Text(this.LimitBraceRoundRite);

            this.Text(this.Space);
            this.Text(this.LimitAdd);
            this.Text(this.Space);

            this.Text(this.LimitBraceRoundLite);
            this.Text(this.RefKindStringValueMacro);
            this.Text(this.Space);
            this.Text(this.LimitBitLite);
            this.Text(this.Space);
            this.TextInt(60);
            this.Text(this.LimitBraceRoundRite);

            this.Text(this.LimitComma);
            this.Text(this.NewLine);

            i = i + 1;
        }

        this.IndentCount = this.IndentCount - 1;

        this.Text(this.LimitBraceCurveRite);
        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool ModuleStructName(ModuleRef moduleRef)
    {
        this.ModuleRef(moduleRef);
        return true;
    }

    public virtual bool ModuleVarName(ModuleRef module)
    {
        this.ModuleStructName(module);
        this.Text(this.NameCombine);
        this.Text(this.VarWord);
        return true;
    }

    public virtual bool ModuleEntryName(ModuleRef module)
    {
        this.ModuleStructName(module);
        this.Text(this.NameCombine);
        this.Text(this.EntryWord);
        return true;
    }

    public virtual bool ModuleCountName(ModuleRef module)
    {
        this.ModuleStructName(module);
        this.Text(this.NameCombine);
        this.Text(this.CountWord);
        return true;
    }

    public virtual bool ModuleInitName(ModuleRef module)
    {
        this.ModuleRef(module);
        this.Text(this.NameCombine);
        this.Text(this.InitWord);
        return true;
    }

    public virtual bool ModuleClass(ClassClass varClass)
    {
        this.ModuleStructName(varClass.Module.Ref);
        this.Text(this.LimitDot);
        this.Text(this.ClassWord);
        this.Text(this.LimitBraceRightLite);
        this.TextInt(varClass.Index);
        this.Text(this.LimitBraceRightRite);
        return true;
    }

    public virtual bool ClassVar(ClassClass varClass)
    {
        this.Text(this.LimitBraceRoundLite);
        this.ModuleClass(varClass);
        this.Text(this.LimitDot);
        this.Text(this.VarWord);
        this.Text(this.LimitBraceRoundRite);
        return true;
    }

    public virtual bool BaseName(ClassClass varClass)
    {
        this.ClassName(varClass);
        this.Text(this.NameCombine);
        this.Text(this.BaseWord);
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

    public virtual bool CompListName(ClassClass varClass, String stateKind)
    {
        this.ClassName(varClass);
        this.Text(this.NameCombine);
        this.Text(stateKind);
        this.Text(this.NameCombine);
        this.Text(this.ListWord);
        return true;
    }

    public virtual bool StringDataName(ClassClass varClass, long index)
    {
        this.ClassName(varClass);
        this.Text(this.NameCombine);
        this.TextIntHex(index);
        this.Text(this.NameCombine);
        this.Text(this.StringWord);
        this.Text(this.DataWord);
        return true;
    }

    public virtual bool StringAnyName(ClassClass varClass, long index)
    {
        this.ClassName(varClass);
        this.Text(this.NameCombine);
        this.TextIntHex(index);
        this.Text(this.NameCombine);
        this.Text(this.StringWord);
        return true;
    }

    public virtual bool StringListName(ClassClass varClass)
    {
        this.ClassName(varClass);
        this.Text(this.NameCombine);
        this.Text(this.StringWord);
        this.Text(this.ListWord);
        return true;
    }

    public virtual bool Include(String value)
    {
        this.Text(this.DirectiveInclude);

        this.Text(this.Space);

        this.Text(value);

        this.Text(this.NewLine);
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
            bool bb;
            bb = (kk == 0);
            bool bc;
            bc = (kk == 1);

            if (bb)
            {
                this.ExecuteThisFieldData();

                this.VarSetDeref(varA, varA, 0);
            }

            if (bc)
            {
                long posB;
                posB = -1;

                this.EvalFrameValueGet(posB, varA);
            }

            if (!(bb | bc))
            {
                long posC;
                posC = kk - 2;

                this.EvalFrameValueGet(posC, varA);
            }
        }

        if (stateKind == this.StateKindCall)
        {
            long posD;
            posD = kk - k;

            this.EvalFrameValueGet(posD, varA);
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
            bool bb;
            bb = (kk == 0);
            bool bc;
            bc = (kk == 1);

            if (bb)
            {
                this.ExecuteThisFieldData();

                this.VarDerefSet(varA, varB);
            }

            if (bc)
            {
                long posB;
                posB = -1;

                this.EvalFrameValueSet(posB, varB);
            }

            if (!(bb | bc))
            {
                long posC;
                posC = kk - 2;

                this.EvalFrameValueSet(posC, varB);
            }
        }

        if (stateKind == this.StateKindCall)
        {
            long posD;
            posD = kk - k;

            this.EvalFrameValueSet(posD, varB);
        }

        return true;
    }

    public virtual bool ExecuteThisFieldData()
    {
        String varA;
        varA = this.VarA;

        Field varField;
        varField = this.ThisField;

        if (!(varField.Virtual == null))
        {
            varField = varField.Virtual;
        }

        ClassClass varClass;
        varClass = varField.Parent;

        long k;
        k = this.ParamCount;

        long kk;
        kk = varClass.FieldStart;
        kk = kk + varField.Index;

        this.EvalFrameValueGet(-(k + 1), varA);

        this.ExecuteFieldData(varA, kk);

        return true;
    }

    public virtual bool ExecuteFieldData(String varVar, long fieldIndex)
    {
        long kk;
        kk = fieldIndex;
        kk = kk + 1;

        long pos;
        pos = kk;

        this.VarMaskClear(varVar, this.MemoryIndexMask);

        this.VarSetPos(varVar, varVar, pos);
        return true;
    }

    public virtual bool CompStateHead(ClassClass varClass, object comp, long stateKind)
    {
        this.Text(this.IndexStatic);

        this.Text(this.Space);

        this.Text(this.ClassInt);

        this.Text(this.Space);

        this.CompStateName(varClass, comp, stateKind);

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
        return true;
    }

    public virtual bool CompStateStart(ClassClass varClass, object comp, long stateKind)
    {
        this.CompStateHead(varClass, comp, stateKind);

        this.Text(this.NewLine);

        this.Text(this.LimitBraceCurveLite);
        this.Text(this.NewLine);

        this.IndentCount = this.IndentCount + 1;

        this.DeclareVar(this.ClassInt, this.VarA);
        this.DeclareVar(this.ClassInt, this.VarB);
        this.DeclareVar(this.ClassInt, this.VarC);
        this.DeclareVar(this.ClassInt, this.VarD);
        this.DeclareVar(this.ClassSInt, this.VarSA);
        this.DeclareVar(this.ClassSInt, this.VarSB);
        this.DeclareVar(this.ClassSInt, this.VarSC);
        this.VarSet(this.VarA, this.Zero);
        this.VarSet(this.VarB, this.Zero);
        this.VarSet(this.VarC, this.Zero);
        this.VarSet(this.VarD, this.Zero);
        this.VarSet(this.VarSA, this.Zero);
        this.VarSet(this.VarSB, this.Zero);
        this.VarSet(this.VarSC, this.Zero);
        return true;
    }

    public virtual bool CompStateEnd()
    {
        long k;
        k = this.ParamCount;

        this.EvalFrameValueSet(-(k + 1), this.Zero);

        this.EvalIndexFramePosSet(-k);

        this.Return();

        this.IndentCount = this.IndentCount - 1;

        this.Text(this.LimitBraceCurveRite);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool CompStateName(ClassClass varClass, object comp, long stateKind)
    {
        if (varClass == this.InternClass | varClass == this.ExternClass)
        {
            this.Text(this.InternWord);

            this.Text(this.NameCombine);

            String kaa;
            kaa = this.InternWord;

            if (varClass == this.ExternClass)
            {
                kaa = this.ExternWord;
            }

            this.Text(kaa);

            this.Text(this.NameCombine);

            Maide maideA;
            maideA = comp as Maide;

            String name;
            name = maideA.Name;

            this.Text(name);

            return true;
        }

        long ka;
        ka = 0;

        long kk;
        kk = 0;

        String kb;
        kb = null;

        if (stateKind == this.StateKindGet | stateKind == this.StateKindSet)
        {
            ka = varClass.FieldStart;

            Field varField;
            varField = comp as Field;

            kk = varField.Index;

            bool ba;
            ba = (stateKind == this.StateKindGet);

            if (ba)
            {
                kb = this.StateGet;
            }
            if (!ba)
            {
                kb = this.StateSet;
            }
        }

        if (stateKind == this.StateKindCall)
        {
            ka = varClass.MaideStart;

            Maide varMaide;
            varMaide = comp as Maide;

            kk = varMaide.Index;

            kb = this.StateCall;
        }

        long ke;
        ke = ka + kk;

        this.ClassName(varClass);

        this.Text(this.NameCombine);

        this.CompIndex(ke);

        this.Text(this.NameCombine);

        this.Text(kb);
        return true;
    }

    public virtual long ClassBaseMask(long baseCount)
    {
        long ka;
        ka = baseCount - 1;

        if (0 < ka)
        {
            ka = ka - 1;
        }

        long k;
        k = ka;
        k = k & 0xff;
        k = k << 52;
        return k;
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

        this.OperateLimitSame(varC, varB, this.Zero);

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

        this.OperateLimitSame(varSC, varSB, this.Zero);

        this.OperateLimit(varSB, varSB, varSC, this.LimitAdd);

        this.OperateLimit(varSA, varSA, varSB, limit);

        this.CondSet(varSA, varSC, this.Zero, varSA);

        this.VarSet(varA, varSA);

        this.VarMaskClear(varA, this.RefKindClearMask);

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

        this.EvalValueGet(2, varA);
        this.EvalValueGet(1, varB);

        this.VarMaskClear(varA, this.RefKindClearMask);
        this.VarMaskClear(varB, this.RefKindClearMask);

        this.OperateLimit(varA, varA, varB, limit);

        this.VarMaskClear(varA, this.RefKindClearMask);

        this.VarMaskSet(varA, this.RefKindIntMask);

        this.EvalValueSet(2, varA);

        this.EvalIndexPosSet(-1);

        return true;
    }

    public virtual bool ExecuteOperateLimitAB(String limit)
    {
        String varA;
        String varB;
        String varSA;
        varA = this.VarA;
        varB = this.VarB;
        varSA = this.VarSA;

        this.EvalValueGet(2, varA);
        this.EvalValueGet(1, varB);

        this.VarSet(varSA, varA);

        this.SignExtend(varSA);

        this.VarMaskClear(varB, this.RefKindClearMask);

        this.OperateLimit(varSA, varSA, varB, limit);

        this.VarSet(varA, varSA);

        this.VarMaskClear(varA, this.RefKindClearMask);

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

        this.VarMaskClear(varA, this.RefKindClearMask);
        this.VarMaskClear(varB, this.RefKindClearMask);

        this.OperateLimit(varA, varA, varB, limit);

        this.VarMaskClear(varA, this.RefKindClearMask);

        this.VarMaskSet(varA, this.RefKindBoolMask);

        this.EvalValueSet(2, varA);

        this.EvalIndexPosSet(-1);

        return true;
    }

    public virtual bool ExecuteOperateLimitBoolOne(String limit)
    {
        String varA;
        varA = this.VarA;

        this.EvalValueGet(1, varA);

        this.VarMaskClear(varA, this.RefKindClearMask);

        this.OperateLimitOne(varA, varA, limit);

        this.VarMaskClear(varA, this.RefKindClearMask);

        this.VarMaskSet(varA, this.RefKindBoolMask);

        this.EvalValueSet(1, varA);

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

    public virtual bool InternShare(ClassClass varClass)
    {
        this.TextIndent();

        this.Text(this.InternShareMaide);
        this.Text(this.LimitBraceRoundLite);

        this.ClassVar(varClass);

        this.Text(this.LimitComma);
        this.Text(this.Space);

        this.Text(this.EvalVar);

        this.Text(this.LimitBraceRoundRite);

        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool ExecuteInternValue(ClassClass varClass)
    {
        String varA;
        varA = this.VarA;

        this.InternValue(varA, varClass);

        this.EvalValueSet(0, varA);

        this.EvalIndexPosSet(1);
        return true;
    }

    public virtual bool InternValue(String dest, ClassClass varClass)
    {
        String k;
        k = null;

        if (varClass == this.System.Bool)
        {
            k = this.InternValueBool;
        }
        if (varClass == this.System.Int)
        {
            k = this.InternValueInt;
        }
        if (varClass == this.System.String)
        {
            k = this.InternValueString;
        }

        this.TextIndent();
        this.Text(dest);

        this.Text(this.Space);
        this.Text(this.LimitAre);
        this.Text(this.Space);

        this.Text(k);
        this.Text(this.LimitBraceRoundLite);
        this.Text(this.LimitBraceRoundRite);
        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool ExecuteVirtualCallThisCond(long thisEvalIndex)
    {
        String varA;
        String varB;
        String varC;
        varA = this.VarA;
        varB = this.VarB;
        varC = this.VarC;

        this.EvalValueGet(thisEvalIndex, varC);

        this.OperateLimit(varA, varC, this.RefKindBitRiteCount, this.LimitBitRite);

        this.OperateLimitSame(varB, varA, this.RefKindAny);

        this.OperateLimitSame(varA, varA, this.Zero);

        this.OperateLimit(varA, varA, varB, this.LimitOrn);

        this.CondSet(varC, varA, varC, this.InternValueRef);

        this.EvalValueSet(thisEvalIndex, varC);

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

        this.OperateLimit(varD, varD, this.BaseBitRiteCount, this.LimitBitRite);

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

    public virtual bool CallCompState(String compState)
    {
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
        this.Text(this.Space);

        this.EvalIndex();

        this.Text(kb);

        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool ExecuteCast(ClassClass varClass)
    {
        long baseIndex;
        baseIndex = varClass.BaseCount - 1;

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

        this.OperateLimit(varB, varB, this.RefKindBitRiteCount, this.LimitBitRite);

        this.OperateLimitSame(varB, varB, this.RefKindAny);

        this.CondSet(varC, varB, varA, this.InternValueRef);

        this.VarMaskClear(varC, this.MemoryIndexMask);

        this.VarSetDeref(varC, varC, 0);

        this.VarSet(varB, varC);

        this.VarSetDeref(varC, varC, 1);

        this.OperateLimit(varC, varC, this.BaseBitRiteCount, this.LimitBitRite);

        this.VarSetPre(varD);
        this.TextIntHex(baseIndex);
        this.VarSetPost();

        this.OperateLimit(varC, varC, varD, this.LimitLess);

        this.CondSet(varD, varC, this.Zero, varD);

        this.CondSet(varB, varC, this.InternValueClass, varB);

        this.VarSetDeref(varC, varB, 0);

        this.VarSetDerefVar(varC, varC, varD);

        this.VarSetDeref(varC, varC, 0);

        this.OperateLimitSameClass(varC, varC, varClass);

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

        this.OperateLimit(varB, varB, this.RefKindBitRiteCount, this.LimitBitRite);

        this.OperateLimitSame(varB, varB, refKind);

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

        this.OperateLimit(varB, varB, this.RefKindBitRiteCount, this.LimitBitRite);

        this.OperateLimitSame(varC, varB, refKindA);

        this.OperateLimitSame(varB, varB, refKindB);

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

        this.Text(this.LimitBraceCurveLite);

        this.Text(this.NewLine);
        return true;
    }

    public virtual bool BlockEnd()
    {
        this.TextIndent();

        this.Text(this.LimitBraceCurveRite);

        this.Text(this.NewLine);
        return true;
    }

    public virtual bool WhileLabel(long whileIndex)
    {
        this.Text(this.WhileLabelPre);

        this.ClassIndex(this.Class.Index);

        this.Text(this.NameCombine);

        this.Operate.ExecuteTextIntHex(whileIndex);
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

    public virtual bool SignExtend(String varVar)
    {
        this.OperateLimit(varVar, varVar, this.RefBitCount, this.LimitBitLite);

        this.OperateLimit(varVar, varVar, this.RefBitCount, this.LimitBitRite);
        return true;
    }

    public virtual bool OperateLimit(String dest, String lite, String rite, String limit)
    {
        this.TextIndent();

        this.Text(dest);

        this.Text(this.Space);
        this.Text(this.LimitAre);
        this.Text(this.Space);

        this.Text(lite);

        this.Text(this.Space);
        this.Text(limit);
        this.Text(this.Space);

        this.Text(rite);

        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool OperateLimitSame(String dest, String lite, String rite)
    {
        this.TextIndent();

        this.Text(dest);

        this.Text(this.Space);
        this.Text(this.LimitAre);
        this.Text(this.Space);

        this.Text(this.LimitBraceRoundLite);
        this.Text(lite);

        this.Text(this.Space);
        this.Text(this.LimitSame);
        this.Text(this.Space);

        this.Text(rite);
        this.Text(this.LimitBraceRoundRite);

        this.Text(this.LimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool OperateLimitSameClass(String dest, String lite, ClassClass varClass)
    {
        this.TextIndent();

        this.Text(dest);

        this.Text(this.Space);
        this.Text(this.LimitAre);
        this.Text(this.Space);

        this.Text(this.LimitBraceRoundLite);
        this.Text(lite);

        this.Text(this.Space);
        this.Text(this.LimitSame);
        this.Text(this.Space);

        this.ClassVar(varClass);
        this.Text(this.LimitBraceRoundRite);

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

    public virtual bool DeclareVar(String varClass, String varVar)
    {
        this.TextIndent();

        this.Text(varClass);

        this.Text(this.Space);

        this.Text(varVar);

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

        this.Text(this.CastInt);
        this.Text(this.LimitBraceRoundLite);

        this.Text(this.LimitBraceRoundLite);

        this.Text(this.LimitBraceRoundLite);
        this.Text(this.ClassInt);
        this.Text(this.LimitAsterisk);
        this.Text(this.LimitBraceRoundRite);

        this.Text(value);

        this.Text(this.LimitBraceRoundRite);

        this.Text(this.Space);

        this.TextPos(pos);

        this.Text(this.LimitBraceRoundRite);

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

    public virtual bool VarMaskSetInt(String varVar, long mask)
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

        this.TextIntHex(mask);

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

        this.Text(this.LimitBraceRightLite);

        this.EvalIndex();

        this.Text(this.Space);
        this.Text(this.LimitSub);
        this.Text(this.Space);

        this.TextInt(index);

        this.Text(this.LimitBraceRightRite);
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

        this.Text(this.LimitBraceRightLite);

        this.Text(this.EvalFrameVar);

        this.Text(this.Space);

        this.TextPos(pos);

        this.Text(this.LimitBraceRightRite);
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

    public virtual bool EvalIndexFramePosSet(long pos)
    {
        this.TextIndent();

        this.EvalIndex();

        this.Text(this.Space);
        this.Text(this.LimitAre);
        this.Text(this.Space);

        this.Text(this.EvalFrameVar);

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

    public virtual bool ClassName(ClassClass varClass)
    {
        this.Text(this.NamePre);

        this.Text(this.NameCombine);

        this.ClassIndex(varClass.Index);
        return true;
    }

    public virtual bool ClassIndex(long index)
    {
        this.Operate.ExecuteTextIntHex(index);
        return true;
    }

    public virtual bool CompIndex(long index)
    {
        this.Operate.ExecuteTextIntHex(index);
        return true;
    }

    public virtual bool ModuleRef(ModuleRef moduleRef)
    {
        this.Text(this.NamePre);

        this.Text(this.NameCombine);

        this.NameSymbolString(moduleRef.Name);

        this.Text(this.NameCombine);

        this.ModuleVer(moduleRef.Ver);
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
        this.Operate.ExecuteTextIntHex(ver);
        return true;
    }

    public virtual bool BoolValueRef(bool value)
    {
        this.Text(this.IntValueHexPre);

        this.Text(this.RefKindBool);

        long k;
        k = 0;
        if (value)
        {
            k = 1;
        }

        this.Operate.ExecuteTextIntHex(k);
        return true;
    }

    public virtual bool IntValueRef(long value)
    {
        this.Text(this.IntValueHexPre);

        this.Text(this.RefKindInt);

        this.Operate.ExecuteTextIntHex(value);
        return true;
    }

    public virtual bool StringValueRef(long index)
    {
        this.StringListName(this.Class);

        this.Text(this.LimitBraceRightLite);

        this.TextIntHex(index);

        this.Text(this.LimitBraceRightRite);
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
        this.Operate.ExecuteTextInt(n);
        return true;
    }

    public virtual bool TextIntHex(long n)
    {
        this.Text(this.IntValueHexPre);

        this.Operate.ExecuteTextIntHex(n);
        return true;
    }

    public virtual bool TextIndent()
    {
        String indent;
        indent = this.SIndent;
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
}