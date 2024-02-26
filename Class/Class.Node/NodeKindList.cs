namespace Class.Node;

public class NodeKindList : Any
{
    public static NodeKindList This { get; } = ShareCreate();

    private static NodeKindList ShareCreate()
    {
        NodeKindList share;
        share = new NodeKindList();
        Any a;
        a = share;
        a.Init();
        return share;
    }

    public override bool Init()
    {
        base.Init();
        this.InitArray();
        this.Count = this.Array.Count;
        this.Index = 0;

        this.Class = this.AddItem("Class", new Class(), new ClassNewState(), new ClassNodeState(), new ClassCreateOperateState());
        this.Part = this.AddItem("Part", new Part(), new PartNewState(), new PartNodeState(), new PartCreateOperateState());
        this.Comp = this.AddItem("Comp", new Comp(), new CompNewState(), new CompNodeState(), new CompCreateOperateState());
        this.Field = this.AddItem("Field", new Field(), new FieldNewState(), new FieldNodeState(), new FieldCreateOperateState());
        this.Maide = this.AddItem("Maide", new Maide(), new MaideNewState(), new MaideNodeState(), new MaideCreateOperateState());
        this.Param = this.AddItem("Param", new Param(), new ParamNewState(), new ParamNodeState(), new ParamCreateOperateState());
        this.Var = this.AddItem("Var", new Var(), new VarNewState(), new VarNodeState(), new VarCreateOperateState());
        this.Emit = this.AddItem("Emit", new Emit(), new EmitNewState(), new EmitNodeState(), new EmitCreateOperateState());
        this.PrudateEmit = this.AddItem("PrudateEmit", new PrudateEmit(), new PrudateEmitNewState(), new PrudateEmitNodeState(), new PrudateEmitCreateOperateState());
        this.ProbateEmit = this.AddItem("ProbateEmit", new ProbateEmit(), new ProbateEmitNewState(), new ProbateEmitNodeState(), new ProbateEmitCreateOperateState());
        this.PrecateEmit = this.AddItem("PrecateEmit", new PrecateEmit(), new PrecateEmitNewState(), new PrecateEmitNodeState(), new PrecateEmitCreateOperateState());
        this.PrivateEmit = this.AddItem("PrivateEmit", new PrivateEmit(), new PrivateEmitNewState(), new PrivateEmitNodeState(), new PrivateEmitCreateOperateState());
        this.State = this.AddItem("State", new State(), new StateNewState(), new StateNodeState(), new StateCreateOperateState());
        this.Execute = this.AddItem("Execute", new Execute(), new ExecuteNewState(), new ExecuteNodeState(), new ExecuteCreateOperateState());
        this.InfExecute = this.AddItem("InfExecute", new InfExecute(), new InfExecuteNewState(), new InfExecuteNodeState(), new InfExecuteCreateOperateState());
        this.WhileExecute = this.AddItem("WhileExecute", new WhileExecute(), new WhileExecuteNewState(), new WhileExecuteNodeState(), new WhileExecuteCreateOperateState());
        this.ReturnExecute = this.AddItem("ReturnExecute", new ReturnExecute(), new ReturnExecuteNewState(), new ReturnExecuteNodeState(), new ReturnExecuteCreateOperateState());
        this.DeclareExecute = this.AddItem("DeclareExecute", new DeclareExecute(), new DeclareExecuteNewState(), new DeclareExecuteNodeState(), new DeclareExecuteCreateOperateState());
        this.AssignExecute = this.AddItem("AssignExecute", new AssignExecute(), new AssignExecuteNewState(), new AssignExecuteNodeState(), new AssignExecuteCreateOperateState());
        this.OperateExecute = this.AddItem("OperateExecute", new OperateExecute(), new OperateExecuteNewState(), new OperateExecuteNodeState(), new OperateExecuteCreateOperateState());
        this.Argue = this.AddItem("Argue", new Argue(), new ArgueNewState(), new ArgueNodeState(), new ArgueCreateOperateState());
        this.Target = this.AddItem("Target", new Target(), new TargetNewState(), new TargetNodeState(), new TargetCreateOperateState());
        this.VarTarget = this.AddItem("VarTarget", new VarTarget(), new VarTargetNewState(), new VarTargetNodeState(), new VarTargetCreateOperateState());
        this.SetTarget = this.AddItem("SetTarget", new SetTarget(), new SetTargetNewState(), new SetTargetNodeState(), new SetTargetCreateOperateState());
        this.Operate = this.AddItem("Operate", new Operate(), new OperateNewState(), new OperateNodeState(), new OperateCreateOperateState());
        this.GetOperate = this.AddItem("GetOperate", new GetOperate(), new GetOperateNewState(), new GetOperateNodeState(), new GetOperateCreateOperateState());
        this.CallOperate = this.AddItem("CallOperate", new CallOperate(), new CallOperateNewState(), new CallOperateNodeState(), new CallOperateCreateOperateState());
        this.ThisOperate = this.AddItem("ThisOperate", new ThisOperate(), new ThisOperateNewState(), new ThisOperateNodeState(), new ThisOperateCreateOperateState());
        this.BaseOperate = this.AddItem("BaseOperate", new BaseOperate(), new BaseOperateNewState(), new BaseOperateNodeState(), new BaseOperateCreateOperateState());
        this.NullOperate = this.AddItem("NullOperate", new NullOperate(), new NullOperateNewState(), new NullOperateNodeState(), new NullOperateCreateOperateState());
        this.NewOperate = this.AddItem("NewOperate", new NewOperate(), new NewOperateNewState(), new NewOperateNodeState(), new NewOperateCreateOperateState());
        this.ShareOperate = this.AddItem("ShareOperate", new ShareOperate(), new ShareOperateNewState(), new ShareOperateNodeState(), new ShareOperateCreateOperateState());
        this.CastOperate = this.AddItem("CastOperate", new CastOperate(), new CastOperateNewState(), new CastOperateNodeState(), new CastOperateCreateOperateState());
        this.VarOperate = this.AddItem("VarOperate", new VarOperate(), new VarOperateNewState(), new VarOperateNodeState(), new VarOperateCreateOperateState());
        this.ValueOperate = this.AddItem("ValueOperate", new ValueOperate(), new ValueOperateNewState(), new ValueOperateNodeState(), new ValueOperateCreateOperateState());
        this.BracketOperate = this.AddItem("BracketOperate", new BracketOperate(), new BracketOperateNewState(), new BracketOperateNodeState(), new BracketOperateCreateOperateState());
        this.Value = this.AddItem("Value", new Value(), new ValueNewState(), new ValueNodeState(), new ValueCreateOperateState());
        this.BoolValue = this.AddItem("BoolValue", new BoolValue(), new BoolValueNewState(), new BoolValueNodeState(), new BoolValueCreateOperateState());
        this.IntValue = this.AddItem("IntValue", new IntValue(), new IntValueNewState(), new IntValueNodeState(), new IntValueCreateOperateState());
        this.IntHexValue = this.AddItem("IntHexValue", new IntHexValue(), new IntHexValueNewState(), new IntHexValueNodeState(), new IntHexValueCreateOperateState());
        this.IntSignValue = this.AddItem("IntSignValue", new IntSignValue(), new IntSignValueNewState(), new IntSignValueNodeState(), new IntSignValueCreateOperateState());
        this.IntSignHexValue = this.AddItem("IntSignHexValue", new IntSignHexValue(), new IntSignHexValueNewState(), new IntSignHexValueNodeState(), new IntSignHexValueCreateOperateState());
        this.StringValue = this.AddItem("StringValue", new StringValue(), new StringValueNewState(), new StringValueNodeState(), new StringValueCreateOperateState());
        this.ClassName = this.AddItem("ClassName", new ClassName(), new ClassNameNewState(), new ClassNameNodeState(), new ClassNameCreateOperateState());
        this.FieldName = this.AddItem("FieldName", new FieldName(), new FieldNameNewState(), new FieldNameNodeState(), new FieldNameCreateOperateState());
        this.MaideName = this.AddItem("MaideName", new MaideName(), new MaideNameNewState(), new MaideNameNodeState(), new MaideNameCreateOperateState());
        this.VarName = this.AddItem("VarName", new VarName(), new VarNameNewState(), new VarNameNodeState(), new VarNameCreateOperateState());
        this.EqualOperate = this.AddItem("EqualOperate", new EqualOperate(), new EqualOperateNewState(), new EqualOperateNodeState(), new EqualOperateCreateOperateState());
        this.AndOperate = this.AddItem("AndOperate", new AndOperate(), new AndOperateNewState(), new AndOperateNodeState(), new AndOperateCreateOperateState());
        this.OrnOperate = this.AddItem("OrnOperate", new OrnOperate(), new OrnOperateNewState(), new OrnOperateNodeState(), new OrnOperateCreateOperateState());
        this.NotOperate = this.AddItem("NotOperate", new NotOperate(), new NotOperateNewState(), new NotOperateNodeState(), new NotOperateCreateOperateState());
        this.AddOperate = this.AddItem("AddOperate", new AddOperate(), new AddOperateNewState(), new AddOperateNodeState(), new AddOperateCreateOperateState());
        this.SubOperate = this.AddItem("SubOperate", new SubOperate(), new SubOperateNewState(), new SubOperateNodeState(), new SubOperateCreateOperateState());
        this.MulOperate = this.AddItem("MulOperate", new MulOperate(), new MulOperateNewState(), new MulOperateNodeState(), new MulOperateCreateOperateState());
        this.DivOperate = this.AddItem("DivOperate", new DivOperate(), new DivOperateNewState(), new DivOperateNodeState(), new DivOperateCreateOperateState());
        this.LessOperate = this.AddItem("LessOperate", new LessOperate(), new LessOperateNewState(), new LessOperateNodeState(), new LessOperateCreateOperateState());
        this.SignMulOperate = this.AddItem("SignMulOperate", new SignMulOperate(), new SignMulOperateNewState(), new SignMulOperateNodeState(), new SignMulOperateCreateOperateState());
        this.SignDivOperate = this.AddItem("SignDivOperate", new SignDivOperate(), new SignDivOperateNewState(), new SignDivOperateNodeState(), new SignDivOperateCreateOperateState());
        this.SignLessOperate = this.AddItem("SignLessOperate", new SignLessOperate(), new SignLessOperateNewState(), new SignLessOperateNodeState(), new SignLessOperateCreateOperateState());
        this.BitAndOperate = this.AddItem("BitAndOperate", new BitAndOperate(), new BitAndOperateNewState(), new BitAndOperateNodeState(), new BitAndOperateCreateOperateState());
        this.BitOrnOperate = this.AddItem("BitOrnOperate", new BitOrnOperate(), new BitOrnOperateNewState(), new BitOrnOperateNodeState(), new BitOrnOperateCreateOperateState());
        this.BitNotOperate = this.AddItem("BitNotOperate", new BitNotOperate(), new BitNotOperateNewState(), new BitNotOperateNodeState(), new BitNotOperateCreateOperateState());
        this.BitLeftOperate = this.AddItem("BitLeftOperate", new BitLeftOperate(), new BitLeftOperateNewState(), new BitLeftOperateNodeState(), new BitLeftOperateCreateOperateState());
        this.BitRightOperate = this.AddItem("BitRightOperate", new BitRightOperate(), new BitRightOperateNewState(), new BitRightOperateNodeState(), new BitRightOperateCreateOperateState());
        this.BitSignRightOperate = this.AddItem("BitSignRightOperate", new BitSignRightOperate(), new BitSignRightOperateNewState(), new BitSignRightOperateNodeState(), new BitSignRightOperateCreateOperateState());
        return true;
    }

    public virtual NodeKind Class { get; set; }
    public virtual NodeKind Part { get; set; }
    public virtual NodeKind Comp { get; set; }
    public virtual NodeKind Field { get; set; }
    public virtual NodeKind Maide { get; set; }
    public virtual NodeKind Param { get; set; }
    public virtual NodeKind Var { get; set; }
    public virtual NodeKind Emit { get; set; }
    public virtual NodeKind PrudateEmit { get; set; }
    public virtual NodeKind ProbateEmit { get; set; }
    public virtual NodeKind PrecateEmit { get; set; }
    public virtual NodeKind PrivateEmit { get; set; }
    public virtual NodeKind State { get; set; }
    public virtual NodeKind Execute { get; set; }
    public virtual NodeKind InfExecute { get; set; }
    public virtual NodeKind WhileExecute { get; set; }
    public virtual NodeKind ReturnExecute { get; set; }
    public virtual NodeKind DeclareExecute { get; set; }
    public virtual NodeKind AssignExecute { get; set; }
    public virtual NodeKind OperateExecute { get; set; }
    public virtual NodeKind Argue { get; set; }
    public virtual NodeKind Target { get; set; }
    public virtual NodeKind VarTarget { get; set; }
    public virtual NodeKind SetTarget { get; set; }
    public virtual NodeKind Operate { get; set; }
    public virtual NodeKind GetOperate { get; set; }
    public virtual NodeKind CallOperate { get; set; }
    public virtual NodeKind ThisOperate { get; set; }
    public virtual NodeKind BaseOperate { get; set; }
    public virtual NodeKind NullOperate { get; set; }
    public virtual NodeKind NewOperate { get; set; }
    public virtual NodeKind ShareOperate { get; set; }
    public virtual NodeKind CastOperate { get; set; }
    public virtual NodeKind VarOperate { get; set; }
    public virtual NodeKind ValueOperate { get; set; }
    public virtual NodeKind BracketOperate { get; set; }
    public virtual NodeKind Value { get; set; }
    public virtual NodeKind BoolValue { get; set; }
    public virtual NodeKind IntValue { get; set; }
    public virtual NodeKind IntHexValue { get; set; }
    public virtual NodeKind IntSignValue { get; set; }
    public virtual NodeKind IntSignHexValue { get; set; }
    public virtual NodeKind StringValue { get; set; }
    public virtual NodeKind ClassName { get; set; }
    public virtual NodeKind FieldName { get; set; }
    public virtual NodeKind MaideName { get; set; }
    public virtual NodeKind VarName { get; set; }
    public virtual NodeKind EqualOperate { get; set; }
    public virtual NodeKind AndOperate { get; set; }
    public virtual NodeKind OrnOperate { get; set; }
    public virtual NodeKind NotOperate { get; set; }
    public virtual NodeKind AddOperate { get; set; }
    public virtual NodeKind SubOperate { get; set; }
    public virtual NodeKind MulOperate { get; set; }
    public virtual NodeKind DivOperate { get; set; }
    public virtual NodeKind LessOperate { get; set; }
    public virtual NodeKind SignMulOperate { get; set; }
    public virtual NodeKind SignDivOperate { get; set; }
    public virtual NodeKind SignLessOperate { get; set; }
    public virtual NodeKind BitAndOperate { get; set; }
    public virtual NodeKind BitOrnOperate { get; set; }
    public virtual NodeKind BitNotOperate { get; set; }
    public virtual NodeKind BitLeftOperate { get; set; }
    public virtual NodeKind BitRightOperate { get; set; }
    public virtual NodeKind BitSignRightOperate { get; set; }

    protected virtual NodeKind AddItem(string name, Node node, InfraState newState, NodeState nodeState, CreateOperateState createOperateState)
    {
        node.Init();
        newState.Init();
        nodeState.Init();
        createOperateState.Init();

        NodeKind item;
        item = new NodeKind();
        item.Init();
        item.Index = this.Index;
        item.Name = name;
        item.Node = node;
        item.NewState = newState;
        item.NodeState = nodeState;
        item.CreateOperateState = createOperateState;
        this.Array.Set(item.Index, item);
        this.Index = this.Index + 1;
        return item;
    }

    protected virtual bool InitArray()
    {
        this.Array = new Array();
        this.Array.Count = this.ArrayCount;
        this.Array.Init();
        return true;
    }

    protected virtual Array Array { get; set; }

    protected virtual int ArrayCount
    { 
        get
        {
            return 65;
        } 
        set
        {
        }
    }

    public virtual int Count { get; set; }

    public virtual NodeKind Get(int index)
    {
        return (NodeKind)this.Array.Get(index);
    }
    
    protected virtual int Index { get; set; }
}