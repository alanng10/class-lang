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
        this.ItemCount = this.AddItem("Count", new Count(), new CountNewState(), new CountNodeState(), new CountCreateOperateState());
        this.PrudateCount = this.AddItem("PrudateCount", new PrudateCount(), new PrudateCountNewState(), new PrudateCountNodeState(), new PrudateCountCreateOperateState());
        this.ProbateCount = this.AddItem("ProbateCount", new ProbateCount(), new ProbateCountNewState(), new ProbateCountNodeState(), new ProbateCountCreateOperateState());
        this.PrecateCount = this.AddItem("PrecateCount", new PrecateCount(), new PrecateCountNewState(), new PrecateCountNodeState(), new PrecateCountCreateOperateState());
        this.PrivateCount = this.AddItem("PrivateCount", new PrivateCount(), new PrivateCountNewState(), new PrivateCountNodeState(), new PrivateCountCreateOperateState());
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
        this.BaseSetTarget = this.AddItem("BaseSetTarget", new BaseSetTarget(), new BaseSetTargetNewState(), new BaseSetTargetNodeState(), new BaseSetTargetCreateOperateState());
        this.Operate = this.AddItem("Operate", new Operate(), new OperateNewState(), new OperateNodeState(), new OperateCreateOperateState());
        this.GetOperate = this.AddItem("GetOperate", new GetOperate(), new GetOperateNewState(), new GetOperateNodeState(), new GetOperateCreateOperateState());
        this.CallOperate = this.AddItem("CallOperate", new CallOperate(), new CallOperateNewState(), new CallOperateNodeState(), new CallOperateCreateOperateState());
        this.BaseGetOperate = this.AddItem("BaseGetOperate", new BaseGetOperate(), new BaseGetOperateNewState(), new BaseGetOperateNodeState(), new BaseGetOperateCreateOperateState());
        this.BaseCallOperate = this.AddItem("BaseCallOperate", new BaseCallOperate(), new BaseCallOperateNewState(), new BaseCallOperateNodeState(), new BaseCallOperateCreateOperateState());
        this.ThisOperate = this.AddItem("ThisOperate", new ThisOperate(), new ThisOperateNewState(), new ThisOperateNodeState(), new ThisOperateCreateOperateState());
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
        this.IntHexSignValue = this.AddItem("IntHexSignValue", new IntHexSignValue(), new IntHexSignValueNewState(), new IntHexSignValueNodeState(), new IntHexSignValueCreateOperateState());
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

    public virtual NodeKind Class { get { return __D_Class; } set { __D_Class = value; } }
    protected NodeKind __D_Class;
    public virtual NodeKind Part { get { return __D_Part; } set { __D_Part = value; } }
    protected NodeKind __D_Part;
    public virtual NodeKind Comp { get { return __D_Comp; } set { __D_Comp = value; } }
    protected NodeKind __D_Comp;
    public virtual NodeKind Field { get { return __D_Field; } set { __D_Field = value; } }
    protected NodeKind __D_Field;
    public virtual NodeKind Maide { get { return __D_Maide; } set { __D_Maide = value; } }
    protected NodeKind __D_Maide;
    public virtual NodeKind Param { get { return __D_Param; } set { __D_Param = value; } }
    protected NodeKind __D_Param;
    public virtual NodeKind Var { get { return __D_Var; } set { __D_Var = value; } }
    protected NodeKind __D_Var;
    public virtual NodeKind ItemCount { get { return __D_ItemCount; } set { __D_ItemCount = value; } }
    protected NodeKind __D_ItemCount;
    public virtual NodeKind PrudateCount { get { return __D_PrudateCount; } set { __D_PrudateCount = value; } }
    protected NodeKind __D_PrudateCount;
    public virtual NodeKind ProbateCount { get { return __D_ProbateCount; } set { __D_ProbateCount = value; } }
    protected NodeKind __D_ProbateCount;
    public virtual NodeKind PrecateCount { get { return __D_PrecateCount; } set { __D_PrecateCount = value; } }
    protected NodeKind __D_PrecateCount;
    public virtual NodeKind PrivateCount { get { return __D_PrivateCount; } set { __D_PrivateCount = value; } }
    protected NodeKind __D_PrivateCount;
    public virtual NodeKind State { get { return __D_State; } set { __D_State = value; } }
    protected NodeKind __D_State;
    public virtual NodeKind Execute { get { return __D_Execute; } set { __D_Execute = value; } }
    protected NodeKind __D_Execute;
    public virtual NodeKind InfExecute { get { return __D_InfExecute; } set { __D_InfExecute = value; } }
    protected NodeKind __D_InfExecute;
    public virtual NodeKind WhileExecute { get { return __D_WhileExecute; } set { __D_WhileExecute = value; } }
    protected NodeKind __D_WhileExecute;
    public virtual NodeKind ReturnExecute { get { return __D_ReturnExecute; } set { __D_ReturnExecute = value; } }
    protected NodeKind __D_ReturnExecute;
    public virtual NodeKind DeclareExecute { get { return __D_DeclareExecute; } set { __D_DeclareExecute = value; } }
    protected NodeKind __D_DeclareExecute;
    public virtual NodeKind AssignExecute { get { return __D_AssignExecute; } set { __D_AssignExecute = value; } }
    protected NodeKind __D_AssignExecute;
    public virtual NodeKind OperateExecute { get { return __D_OperateExecute; } set { __D_OperateExecute = value; } }
    protected NodeKind __D_OperateExecute;
    public virtual NodeKind Argue { get { return __D_Argue; } set { __D_Argue = value; } }
    protected NodeKind __D_Argue;
    public virtual NodeKind Target { get { return __D_Target; } set { __D_Target = value; } }
    protected NodeKind __D_Target;
    public virtual NodeKind VarTarget { get { return __D_VarTarget; } set { __D_VarTarget = value; } }
    protected NodeKind __D_VarTarget;
    public virtual NodeKind SetTarget { get { return __D_SetTarget; } set { __D_SetTarget = value; } }
    protected NodeKind __D_SetTarget;
    public virtual NodeKind BaseSetTarget { get { return __D_BaseSetTarget; } set { __D_BaseSetTarget = value; } }
    protected NodeKind __D_BaseSetTarget;
    public virtual NodeKind Operate { get { return __D_Operate; } set { __D_Operate = value; } }
    protected NodeKind __D_Operate;
    public virtual NodeKind GetOperate { get { return __D_GetOperate; } set { __D_GetOperate = value; } }
    protected NodeKind __D_GetOperate;
    public virtual NodeKind CallOperate { get { return __D_CallOperate; } set { __D_CallOperate = value; } }
    protected NodeKind __D_CallOperate;
    public virtual NodeKind BaseGetOperate { get { return __D_BaseGetOperate; } set { __D_BaseGetOperate = value; } }
    protected NodeKind __D_BaseGetOperate;
    public virtual NodeKind BaseCallOperate { get { return __D_BaseCallOperate; } set { __D_BaseCallOperate = value; } }
    protected NodeKind __D_BaseCallOperate;
    public virtual NodeKind ThisOperate { get { return __D_ThisOperate; } set { __D_ThisOperate = value; } }
    protected NodeKind __D_ThisOperate;
    public virtual NodeKind NullOperate { get { return __D_NullOperate; } set { __D_NullOperate = value; } }
    protected NodeKind __D_NullOperate;
    public virtual NodeKind NewOperate { get { return __D_NewOperate; } set { __D_NewOperate = value; } }
    protected NodeKind __D_NewOperate;
    public virtual NodeKind ShareOperate { get { return __D_ShareOperate; } set { __D_ShareOperate = value; } }
    protected NodeKind __D_ShareOperate;
    public virtual NodeKind CastOperate { get { return __D_CastOperate; } set { __D_CastOperate = value; } }
    protected NodeKind __D_CastOperate;
    public virtual NodeKind VarOperate { get { return __D_VarOperate; } set { __D_VarOperate = value; } }
    protected NodeKind __D_VarOperate;
    public virtual NodeKind ValueOperate { get { return __D_ValueOperate; } set { __D_ValueOperate = value; } }
    protected NodeKind __D_ValueOperate;
    public virtual NodeKind BracketOperate { get { return __D_BracketOperate; } set { __D_BracketOperate = value; } }
    protected NodeKind __D_BracketOperate;
    public virtual NodeKind Value { get { return __D_Value; } set { __D_Value = value; } }
    protected NodeKind __D_Value;
    public virtual NodeKind BoolValue { get { return __D_BoolValue; } set { __D_BoolValue = value; } }
    protected NodeKind __D_BoolValue;
    public virtual NodeKind IntValue { get { return __D_IntValue; } set { __D_IntValue = value; } }
    protected NodeKind __D_IntValue;
    public virtual NodeKind IntHexValue { get { return __D_IntHexValue; } set { __D_IntHexValue = value; } }
    protected NodeKind __D_IntHexValue;
    public virtual NodeKind IntSignValue { get { return __D_IntSignValue; } set { __D_IntSignValue = value; } }
    protected NodeKind __D_IntSignValue;
    public virtual NodeKind IntHexSignValue { get { return __D_IntHexSignValue; } set { __D_IntHexSignValue = value; } }
    protected NodeKind __D_IntHexSignValue;
    public virtual NodeKind StringValue { get { return __D_StringValue; } set { __D_StringValue = value; } }
    protected NodeKind __D_StringValue;
    public virtual NodeKind ClassName { get { return __D_ClassName; } set { __D_ClassName = value; } }
    protected NodeKind __D_ClassName;
    public virtual NodeKind FieldName { get { return __D_FieldName; } set { __D_FieldName = value; } }
    protected NodeKind __D_FieldName;
    public virtual NodeKind MaideName { get { return __D_MaideName; } set { __D_MaideName = value; } }
    protected NodeKind __D_MaideName;
    public virtual NodeKind VarName { get { return __D_VarName; } set { __D_VarName = value; } }
    protected NodeKind __D_VarName;
    public virtual NodeKind EqualOperate { get { return __D_EqualOperate; } set { __D_EqualOperate = value; } }
    protected NodeKind __D_EqualOperate;
    public virtual NodeKind AndOperate { get { return __D_AndOperate; } set { __D_AndOperate = value; } }
    protected NodeKind __D_AndOperate;
    public virtual NodeKind OrnOperate { get { return __D_OrnOperate; } set { __D_OrnOperate = value; } }
    protected NodeKind __D_OrnOperate;
    public virtual NodeKind NotOperate { get { return __D_NotOperate; } set { __D_NotOperate = value; } }
    protected NodeKind __D_NotOperate;
    public virtual NodeKind AddOperate { get { return __D_AddOperate; } set { __D_AddOperate = value; } }
    protected NodeKind __D_AddOperate;
    public virtual NodeKind SubOperate { get { return __D_SubOperate; } set { __D_SubOperate = value; } }
    protected NodeKind __D_SubOperate;
    public virtual NodeKind MulOperate { get { return __D_MulOperate; } set { __D_MulOperate = value; } }
    protected NodeKind __D_MulOperate;
    public virtual NodeKind DivOperate { get { return __D_DivOperate; } set { __D_DivOperate = value; } }
    protected NodeKind __D_DivOperate;
    public virtual NodeKind LessOperate { get { return __D_LessOperate; } set { __D_LessOperate = value; } }
    protected NodeKind __D_LessOperate;
    public virtual NodeKind SignMulOperate { get { return __D_SignMulOperate; } set { __D_SignMulOperate = value; } }
    protected NodeKind __D_SignMulOperate;
    public virtual NodeKind SignDivOperate { get { return __D_SignDivOperate; } set { __D_SignDivOperate = value; } }
    protected NodeKind __D_SignDivOperate;
    public virtual NodeKind SignLessOperate { get { return __D_SignLessOperate; } set { __D_SignLessOperate = value; } }
    protected NodeKind __D_SignLessOperate;
    public virtual NodeKind BitAndOperate { get { return __D_BitAndOperate; } set { __D_BitAndOperate = value; } }
    protected NodeKind __D_BitAndOperate;
    public virtual NodeKind BitOrnOperate { get { return __D_BitOrnOperate; } set { __D_BitOrnOperate = value; } }
    protected NodeKind __D_BitOrnOperate;
    public virtual NodeKind BitNotOperate { get { return __D_BitNotOperate; } set { __D_BitNotOperate = value; } }
    protected NodeKind __D_BitNotOperate;
    public virtual NodeKind BitLeftOperate { get { return __D_BitLeftOperate; } set { __D_BitLeftOperate = value; } }
    protected NodeKind __D_BitLeftOperate;
    public virtual NodeKind BitRightOperate { get { return __D_BitRightOperate; } set { __D_BitRightOperate = value; } }
    protected NodeKind __D_BitRightOperate;
    public virtual NodeKind BitSignRightOperate { get { return __D_BitSignRightOperate; } set { __D_BitSignRightOperate = value; } }
    protected NodeKind __D_BitSignRightOperate;

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
            return 67;
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