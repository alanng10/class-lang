namespace Class.Console;

public class ClassGen : Any
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
        
        this.StringCreate = new StringCreate();
        this.StringCreate.Init();

        this.StateKindGet = 0;
        this.StateKindSet = 1;
        this.StateKindCall = 2;

        this.Space = " ";
        this.NewLine = "\n";
        this.Indent = new string(' ', 4);
        this.Zero = "0";
        string k;
        k = "v";
        this.VarA = k + "A";
        this.VarB = k + "B";
        this.VarC = k + "C";
        this.VarD = k + "D";
        this.VarSA = k + "SA";
        this.VarSB = k + "SB";
        this.Eval = "e";
        this.EvalStackVar = "S";
        this.EvalIndexVar = "N";
        this.EvalFrameVar = "f";
        this.IntValuePre = "0x";
        this.IntValuePost = "ULL";
        this.BaseBitRightCount = "48";
        this.RefKindClearMask = "0xfffffffffffffff";
        this.RefKindBoolMask = "0x2000000000000000";
        this.RefKindIntMask = "0x3000000000000000";
        this.BaseClearMask = "0xf000ffffffffffff";
        this.BaseMask = "0x0fff000000000000";
        this.MemoryIndexMask = "0x0000ffffffffffff";
        this.ClassInt = "Int";
        this.ClassCompState = "CompState";
        this.KeywordReturn = "return";
        this.DelimitDot = ".";
        this.DelimitDotPointer = "->";
        this.DelimitBracketLeft = "(";
        this.DelimitBracketRight = ")";
        this.DelimitSquareLeft = "[";
        this.DelimitSquareRight = "]";
        this.DelimitSemicolon = ";";
        this.DelimitComma = ",";
        this.DelimitAsterisk = "*";
        this.DelimitAre = "=";
        this.DelimitEqual = "==";
        this.DelimitLess = "<";
        this.DelimitAnd = "&";
        this.DelimitOrn = "|";
        this.DelimitNot = "!";
        this.DelimitAdd = "+";
        this.DelimitSub = "-";
        this.DelimitMul = "*";
        this.DelimitDiv = "/";
        this.DelimitBitNot = "~";
        this.DelimitBitLeft = "<<";
        this.DelimitBitRight = ">>";
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
    public virtual string Source { get; set; }
    public virtual ClassInfra ClassInfra { get; set; }
    public virtual CountClassGenOperate CountOperate { get; set; }
    public virtual SetClassGenOperate SetOperate { get; set; }
    public virtual ClassGenTraverse Traverse { get; set; }
    public virtual StringCreate StringCreate { get; set; }
    public virtual int BaseIndex { get; set; }
    public virtual string ClassBaseMask { get; set; }
    public virtual Field ThisField { get; set; }
    public virtual int CompStateKind { get; set; }
    public virtual int ParamCount { get; set; }
    public virtual int LocalVarCount { get; set; }
    public virtual int IndentCount { get; set; }
    public virtual Array BlockStack { get; set; }
    public virtual int StateKindGet { get; set; }
    public virtual int StateKindSet { get; set; }
    public virtual int StateKindCall { get; set; }
    public virtual string Space { get; set; }
    public virtual string NewLine { get; set; }
    public virtual string Indent { get; set; }
    public virtual string Zero { get; set; }
    public virtual string VarA { get; set; }
    public virtual string VarB { get; set; }
    public virtual string VarC { get; set; }
    public virtual string VarD { get; set; }
    public virtual string VarSA { get; set; }
    public virtual string VarSB { get; set; }
    public virtual string Eval { get; set; }
    public virtual string EvalStackVar { get; set; }
    public virtual string EvalIndexVar { get; set; }
    public virtual string EvalFrameVar { get; set; }
    public virtual string IntValuePre { get; set; }
    public virtual string IntValuePost { get; set; }
    public virtual string BaseBitRightCount { get; set; }
    public virtual string RefKindClearMask { get; set; }
    public virtual string RefKindBoolMask { get; set; }
    public virtual string RefKindIntMask { get; set; }
    public virtual string BaseClearMask { get; set; }
    public virtual string BaseMask { get; set; }
    public virtual string MemoryIndexMask { get; set; }
    public virtual string ClassInt { get; set; }
    public virtual string ClassCompState { get; set; }
    public virtual string KeywordReturn { get; set; }
    public virtual string DelimitDot { get; set; }
    public virtual string DelimitDotPointer { get; set; }
    public virtual string DelimitBracketLeft { get; set; }
    public virtual string DelimitBracketRight { get; set; }
    public virtual string DelimitSquareLeft { get; set; }
    public virtual string DelimitSquareRight { get; set; }
    public virtual string DelimitSemicolon { get; set; }
    public virtual string DelimitComma { get; set; }
    public virtual string DelimitAsterisk { get; set; }
    public virtual string DelimitAre { get; set; }
    public virtual string DelimitEqual { get; set; }
    public virtual string DelimitLess { get; set; }
    public virtual string DelimitAnd { get; set; }
    public virtual string DelimitOrn { get; set; }
    public virtual string DelimitNot { get; set; }
    public virtual string DelimitAdd { get; set; }
    public virtual string DelimitSub { get; set; }
    public virtual string DelimitMul { get; set; }
    public virtual string DelimitDiv { get; set; }
    public virtual string DelimitBitNot { get; set; }
    public virtual string DelimitBitLeft { get; set; }
    public virtual string DelimitBitRight { get; set; }

    public virtual bool Execute()
    {
        int k;
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
        nn = nn * sizeof(char);
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

        string o;
        o = this.StringCreate.Data(data, null);

        this.Source = o;
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

    public virtual bool OperateDelimit(string dest, string left, string right, string delimit)
    {
        string space;
        space = this.Space;

        this.TextIndent();

        this.Text(dest);
        
        this.Text(space);
        this.Text(this.DelimitAre);
        this.Text(space);

        this.Text(left);

        this.Text(space);
        this.Text(delimit);
        this.Text(space);

        this.Text(right);

        this.Text(this.DelimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool OperateDelimitOne(string dest, string value, string delimit)
    {
        this.TextIndent();

        this.Text(dest);

        this.Text(this.Space);
        this.Text(this.DelimitAre);
        this.Text(this.Space);

        this.Text(delimit);
        this.Text(this.Space);

        this.Text(value);

        this.Text(this.DelimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool Return()
    {
        this.TextIndent();

        this.Text(this.KeywordReturn);

        this.Text(this.Space);

        this.Text(this.Zero);

        this.Text(this.DelimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool CallCompState(string compState)
    {
        string kk;
        kk = this.Space;

        string ka;
        string kb;
        ka = this.DelimitSquareLeft;
        kb = this.DelimitSquareRight;

        this.TextIndent();

        this.Text(ka);

        this.Text(ka);
        this.Text(this.ClassCompState);
        this.Text(kb);

        this.Text(compState);

        this.Text(kb);

        this.Text(ka);
        this.Text(this.Eval);

        this.Text(this.DelimitComma);
        this.Text(kk);

        this.EvalIndex();
    
        this.Text(kb);

        this.Text(this.DelimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool VarSet(string dest, string value)
    {
        this.TextIndent();

        this.Text(dest);

        this.Text(this.Space);
        this.Text(this.DelimitAre);
        this.Text(this.Space);

        this.Text(value);

        this.Text(this.DelimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool VarSetPos(string dest, string value, int pos)
    {
        string k;
        k = this.Space;

        this.TextIndent();

        this.Text(dest);

        this.Text(k);
        this.Text(this.DelimitAre);
        this.Text(k);

        this.Text(value);

        this.Text(k);

        this.TextPos(pos);

        this.Text(this.DelimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool VarSetDeref(string dest, string value, int pos)
    {
        string kk;
        kk = this.Space;

        string ka;
        string kb;
        ka = this.DelimitSquareLeft;
        kb = this.DelimitSquareRight;

        this.TextIndent();

        this.Text(dest);

        this.Text(kk);
        this.Text(this.DelimitAre);
        this.Text(kk);

        this.Text(this.DelimitAsterisk);

        this.Text(ka);

        this.Text(ka);

        this.Text(ka);
        this.Text(this.ClassInt);
        this.Text(this.DelimitAsterisk);
        this.Text(kb);

        this.Text(value);

        this.Text(kb);

        this.Text(kk);

        this.TextPos(pos);

        this.Text(kb);

        this.Text(this.DelimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool VarSetDerefVar(string dest, string value, string varPos)
    {
        string kk;
        kk = this.Space;

        string ka;
        string kb;
        ka = this.DelimitSquareLeft;
        kb = this.DelimitSquareRight;

        this.TextIndent();

        this.Text(dest);

        this.Text(kk);
        this.Text(this.DelimitAre);
        this.Text(kk);

        this.Text(this.DelimitAsterisk);

        this.Text(ka);

        this.Text(ka);

        this.Text(ka);
        this.Text(this.ClassInt);
        this.Text(this.DelimitAsterisk);
        this.Text(kb);

        this.Text(value);

        this.Text(kb);

        this.Text(kk);
        this.Text(this.DelimitAdd);
        this.Text(kk);

        this.Text(varPos);

        this.Text(kb);

        this.Text(this.DelimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool VarDerefSet(string dest, string value)
    {
        string kk;
        kk = this.Space;

        string ka;
        string kb;
        ka = this.DelimitSquareLeft;
        kb = this.DelimitSquareRight;

        this.TextIndent();

        this.Text(this.DelimitAsterisk);

        this.Text(ka);

        this.Text(ka);
        this.Text(this.ClassInt);
        this.Text(this.DelimitAsterisk);
        this.Text(kb);

        this.Text(dest);

        this.Text(kb);

        this.Text(kk);
        this.Text(this.DelimitAre);
        this.Text(kk);

        this.Text(value);

        this.Text(this.DelimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool ClassFieldStart(ClassClass varClass)
    {
        this.ClassName(varClass);

        this.Text("__");

        this.Text("F");
        return true;
    }

    public virtual bool ClassMaideStart(ClassClass varClass)
    {
        this.ClassName(varClass);

        this.Text("__");

        this.Text("M");
        return true;
    }

    public virtual bool VarMaskClear(string varVar, string mask)
    {
        this.TextIndent();

        this.Text(varVar);

        this.Text(this.Space);
        this.Text(this.DelimitAre);
        this.Text(this.Space);

        this.Text(varVar);

        this.Text(this.Space);
        this.Text(this.DelimitAnd);
        this.Text(this.Space);

        this.Text(mask);

        this.Text(this.DelimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool VarMaskSet(string varVar, string mask)
    {
        this.TextIndent();

        this.Text(varVar);

        this.Text(this.Space);
        this.Text(this.DelimitAre);
        this.Text(this.Space);

        this.Text(varVar);

        this.Text(this.Space);
        this.Text(this.DelimitOrn);
        this.Text(this.Space);

        this.Text(mask);

        this.Text(this.DelimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool EvalValueGet(int index, string varVar)
    {
        this.TextIndent();
        
        this.Text(varVar);

        this.Text(this.Space);
        this.Text(this.DelimitAre);
        this.Text(this.Space);
        
        this.EvalValue(index);
        
        this.Text(this.DelimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool EvalValueSet(int index, string varVar)
    {
        this.TextIndent();

        this.EvalValue(index);

        this.Text(this.Space);
        this.Text(this.DelimitAre);
        this.Text(this.Space);

        this.Text(varVar);

        this.Text(this.DelimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool EvalValue(int index)
    {
        this.EvalStack();
        
        this.Text(this.DelimitSquareLeft);
        
        this.EvalIndex();

        this.Text(this.Space);
        this.Text(this.DelimitSub);
        this.Text(this.Space);
        
        this.TextInt(index);
        
        this.Text(this.DelimitSquareRight);
        return true;
    }

    public virtual bool EvalFrameValueGet(int pos, string arg)
    {
        this.TextIndent();

        this.Text(arg);

        this.Text(this.Space);
        this.Text(this.DelimitAre);
        this.Text(this.Space);

        this.EvalFrameValue(pos);

        this.Text(this.DelimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool EvalFrameValueSet(int pos, string arg)
    {
        this.TextIndent();

        this.EvalFrameValue(pos);

        this.Text(this.Space);
        this.Text(this.DelimitAre);
        this.Text(this.Space);

        this.Text(arg);

        this.Text(this.DelimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool EvalFrameValue(int pos)
    {
        this.EvalStack();

        this.Text(this.DelimitSquareLeft);

        this.Text(this.EvalFrameVar);

        this.Text(this.Space);

        this.TextPos(pos);

        this.Text(this.DelimitSquareRight);
        return true;
    }

    public virtual bool EvalIndexPosSet(int pos)
    {
        this.TextIndent();

        this.EvalIndex();

        this.Text(this.Space);
        this.Text(this.DelimitAre);
        this.Text(this.Space);

        this.EvalIndex();

        this.Text(this.Space);

        this.TextPos(pos);

        this.Text(this.DelimitSemicolon);
        this.Text(this.NewLine);
        return true;
    }

    public virtual bool EvalStack()
    {
        this.Text(this.Eval);
        this.Text(this.DelimitDotPointer);
        this.Text(this.EvalStackVar);
        return true;
    }

    public virtual bool EvalIndex()
    {
        this.Text(this.Eval);
        this.Text(this.DelimitDotPointer);
        this.Text(this.EvalIndexVar);
        return true;
    }

    public virtual bool FieldGetMaideName(Field varField)
    {
        return this.CompStateMaideName(varField.Parent, varField.Name, "G");
    }

    public virtual bool FieldSetMaideName(Field varField)
    {
        return this.CompStateMaideName(varField.Parent, varField.Name, "S");
    }

    public virtual bool MaideCallMaideName(Maide varMaide)
    {
        return this.CompStateMaideName(varMaide.Parent, varMaide.Name, "C");
    }

    public virtual bool CompStateMaideName(ClassClass varClass, string compName, string state)
    {
        this.ClassName(varClass);

        this.Text("_");

        this.Text(compName);

        this.Text("_");

        this.Text(state);
        return true;
    }

    public virtual bool ClassName(ClassClass varClass)
    {
        ModuleRef moduleRef;
        moduleRef = varClass.Module.Ref;

        this.ModuleRef(moduleRef);

        this.Text("__");

        this.Text(varClass.Name);
        return true;
    }

    public virtual bool ModuleRef(ModuleRef moduleRef)
    {
        this.ModuleName(moduleRef.Name);
        
        this.Text("__");

        this.ModuleVer(moduleRef.Version);
        return true;
    }

    public virtual bool ModuleName(string name)
    {
        ClassGenOperate o;
        o = this.Operate;

        int count;
        count = name.Length;
        int i;
        i = 0;
        while (i < count)
        {
            char oc;
            oc = name[i];

            if (oc == '.')
            {
                oc = '_';    
            }

            o.ExecuteChar(oc);

            i = i + 1;
        }

        return true;
    }
    
    public virtual bool ModuleVer(long ver)
    {
        return true;
    }

    public virtual bool TextPos(long n)
    {
        bool b;
        b = (n < 0);

        string ka;
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
        string indent;
        indent = this.Indent;
        int count;
        count = this.IndentCount;
        int i;
        i = 0;
        while (i < count)
        {
            this.Text(indent);
            i = i + 1;
        }
        return true;
    }

    public virtual bool Text(string text)
    {
        ClassGenOperate o;
        o = this.Operate;

        int count;
        count = text.Length;
        int i;
        i = 0;
        while (i < count)
        {
            char oc;
            oc = text[i];

            o.ExecuteChar(oc);

            i = i + 1;
        }
        return true;
    }

    public virtual bool ValidBaseIndex(int index)
    {
        if (index < 0)
        {
            return false;
        }
        
        if (!(index < 0x1000))
        {
            return false;
        }

        return true;
    }

    public virtual string ClassBaseMaskGet(int index)
    {
        int ka;
        ka = index;
        
        if (0 < ka)
        {
            ka = ka - 1;
        }

        ulong k;
        k = (ulong)ka;

        k = k & 0xfff;
        k = k << 48;

        string a;
        a = k.ToString("x16");
        return a;
    }

    public virtual int BaseIndexGet()
    {
        ClassClass anyClass;
        anyClass = this.System.Any;

        ClassClass c;
        c = this.Class;

        int k;
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
}