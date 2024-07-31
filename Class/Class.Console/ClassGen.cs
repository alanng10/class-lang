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

        this.Space = " ";
        this.Indent = new string(' ', 4);
        this.VarPrefix = "var";
        this.VarArgA = "ArgA";
        this.VarArgB = "ArgB";
        this.Eval = "e";
        this.EvalStackVar = "S";
        this.EvalIndexVar = "N";
        this.IntValuePre = "0x";
        this.IntValuePost = "ULL";
        this.RefKindClearMask = "0xfffffffffffffff";
        this.DelimitDot = ".";
        this.DelimitDotPointer = "->";
        this.DelimitSquareLeft = "[";
        this.DelimitSquareRight = "]";
        this.DelimitSemicolon = ";";
        this.DelimitAre = "=";
        this.DelimitAnd = "&";
        this.DelimitAdd = "+";
        this.DelimitSub = "-";
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
    public virtual Maide AnyInitMaide { get; set; }
    public virtual Maide ModuleInfoNameMaide { get; set; }
    public virtual Maide ModuleInfoVersionMaide { get; set; }
    public virtual string Source { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual CountClassGenOperate CountOperate { get; set; }
    protected virtual SetClassGenOperate SetOperate { get; set; }
    protected virtual ClassGenTraverse Traverse { get; set; }
    protected virtual StringCreate StringCreate { get; set; }
    protected virtual int IndentCount { get; set; }
    protected virtual string Space { get; set; }
    protected virtual string Indent { get; set; }
    protected virtual string VarPrefix { get; set; }
    public virtual string VarArgA { get; set; }
    public virtual string VarArgB { get; set; }
    protected virtual string Eval { get; set; }
    protected virtual string EvalStackVar { get; set; }
    protected virtual string EvalIndexVar { get; set; }
    protected virtual string IntValuePre { get; set; }
    protected virtual string IntValuePost { get; set; }
    protected virtual string RefKindClearMask { get; set; }
    protected virtual string DelimitDot { get; set; }
    protected virtual string DelimitDotPointer { get; set; }
    protected virtual string DelimitSquareLeft { get; set; }
    protected virtual string DelimitSquareRight { get; set; }
    protected virtual string DelimitSemicolon { get; set; }
    protected virtual string DelimitAre { get; set; }
    protected virtual string DelimitAnd { get; set; }
    protected virtual string DelimitAdd { get; set; }
    protected virtual string DelimitSub { get; set; }

    public virtual bool Execute()
    {
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

    public virtual bool Add(string destArg, string left, string right)
    {
        this.TextIndent();

        this.VarArg(destArg);
        
        this.Text(this.Space);
        this.Text(this.DelimitAre);
        this.Text(this.Space);

        this.VarArg(left);

        this.Text(this.Space);
        this.Text(this.DelimitAdd);
        this.Text(this.Space);

        this.VarArg(right);

        this.Text(this.DelimitSemicolon);
        return true;
    }

    public virtual bool ClearRefKind(string arg)
    {
        this.TextIndent();

        this.VarArg(arg);

        this.Text(this.Space);
        this.Text(this.DelimitAre);
        this.Text(this.Space);

        this.VarArg(arg);

        this.Text(this.Space);
        this.Text(this.DelimitAnd);
        this.Text(this.Space);

        this.Text(this.RefKindClearMask);

        this.Text(this.DelimitSemicolon);
        return true;
    }

    public virtual bool GetEvalValue(int index, string arg)
    {
        this.TextIndent();
        
        this.VarArg(arg);

        this.Text(this.Space);
        this.Text(this.DelimitAre);
        this.Text(this.Space);
        
        this.EvalValue(index);
        
        this.Text(this.DelimitSemicolon);
        return true;
    }

    public virtual bool SetEvalValue(int index, string arg)
    {
        this.TextIndent();

        this.EvalValue(index);

        this.Text(this.Space);
        this.Text(this.DelimitAre);
        this.Text(this.Space);

        this.VarArg(arg);

        this.Text(this.DelimitSemicolon);
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

    public virtual bool VarArg(string arg)
    {
        this.Text(this.VarPrefix);
        this.Text(arg);
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
}