namespace Class.Node;

public class Create : InfraCreate
{
    public override bool Init()
    {
        base.Init();

        this.InfraInfra = InfraInfra.This;
        this.TextInfra = TextInfra.This;
        this.ListInfra = ListInfra.This;
        this.ClassInfra = ClassInfra.This;
        this.Keyword = this.CreateKeywordList();
        this.Delimit = this.CreateDelimitList();
        this.ErrorKind = this.CreateErrorKindList();
        this.NodeKind = this.CreateNodeKindList();
        this.StringValueWrite = this.StringValueWriteCreate();

        this.CountOperate = this.CreateCountCreateOperate();
        this.KindOperate = this.CreateKindCreateOperate();
        this.SetOperate = this.CreateSetCreateOperate();
        this.OperateArg = this.CreateCreateOperateArg();

        this.RangeA = this.CreateRange();
        this.RangeB = this.CreateRange();
        this.RangeC = this.CreateRange();
        this.RangeD = this.CreateRange();
        this.TokenA = this.CreateToken();
        this.TokenB = this.CreateToken();
        this.TokenC = this.CreateToken();
        this.TokenD = this.CreateToken();
        this.TokenE = this.CreateToken();
        this.TokenF = this.CreateToken();
        this.TokenG = this.CreateToken();
        this.TokenH = this.CreateToken();

        this.Text = this.CreateText();
        this.TextIntParse = this.CreateTextIntParse();

        this.InitListItemState();

        this.InitNodeState();
        return true;
    }

    public virtual Source Source { get; set; }
    public virtual Array CodeArray { get; set; }
    public virtual string Task { get; set; }
    public virtual Result Result { get; set; }

    protected virtual KeywordList Keyword { get; set; }
    protected virtual DelimitList Delimit { get; set; }
    protected virtual ErrorKindList ErrorKind { get; set; }
    protected virtual NodeKindList NodeKind { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }

    public virtual SourceItem SourceItem { get; set; }

    protected virtual Array SourceText { get; set; }
    protected virtual Code Code { get; set; }
    protected virtual Table NodeStateTable { get; set; }
    protected virtual NodeState NodeState { get; set; }

    protected virtual RangeState PartItemRangeState { get; set; }
    protected virtual RangeState StateItemRangeState { get; set; }
    protected virtual RangeState ParamItemRangeState { get; set; }
    protected virtual RangeState ArgueItemRangeState { get; set; }
    protected virtual NodeState PartItemNodeState { get; set; }
    protected virtual NodeState StateItemNodeState { get; set; }
    protected virtual NodeState ParamItemNodeState { get; set; }
    protected virtual NodeState ArgueItemNodeState { get; set; }

    protected virtual Range RangeA { get; set; }
    protected virtual Range RangeB { get; set; }
    protected virtual Range RangeC { get; set; }
    protected virtual Range RangeD { get; set; }
    protected virtual Token TokenA { get; set; }
    protected virtual Token TokenB { get; set; }
    protected virtual Token TokenC { get; set; }
    protected virtual Token TokenD { get; set; }
    protected virtual Token TokenE { get; set; }
    protected virtual Token TokenF { get; set; }
    protected virtual Token TokenG { get; set; }
    protected virtual Token TokenH { get; set; }

    protected virtual Text Text { get; set; }
    protected virtual TextIntParse TextIntParse { get; set; }

    public virtual int NodeIndex { get; set; }
    public virtual Data KindData { get; set; }
    public virtual Array NodeArray { get; set; }
    public virtual int ListIndex { get; set; }
    public virtual Data ListData { get; set; }
    public virtual Array ListArray { get; set; }
    public virtual int ErrorIndex { get; set; }
    public virtual Array ErrorArray { get; set; }
    public virtual int NameValueIndex { get; set; }
    public virtual int NameValueTotalIndex { get; set; }
    public virtual Data NameValueText { get; set; }
    public virtual Data NameValueData { get; set; }
    public virtual Array NameValueArray { get; set; }
    public virtual int StringValueIndex { get; set; }
    public virtual int StringValueTotalIndex { get; set; }
    public virtual Data StringValueText { get; set; }
    public virtual Data StringValueData { get; set; }
    public virtual Array StringValueArray { get; set; }
    
    protected virtual CountCreateOperate CountOperate { get; set; }
    protected virtual KindCreateOperate KindOperate { get; set; }
    protected virtual SetCreateOperate SetOperate { get; set; }

    public virtual StringValueWrite StringValueWrite { get; set; }

    public virtual CreateOperate Operate { get; set; }
    public virtual CreateOperateArg OperateArg { get; set; }

    protected virtual KeywordList CreateKeywordList()
    {
        return KeywordList.This;
    }

    protected virtual DelimitList CreateDelimitList()
    {
        return DelimitList.This;
    }

    protected virtual ErrorKindList CreateErrorKindList()
    {
        return ErrorKindList.This;
    }

    protected virtual NodeKindList CreateNodeKindList()
    {
        return NodeKindList.This;
    }

    protected virtual StringValueWrite StringValueWriteCreate()
    {
        StringValueWrite a;
        a = new StringValueWrite();
        a.Init();
        return a;
    }

    protected virtual CountCreateOperate CreateCountCreateOperate()
    {
        CountCreateOperate a;
        a = new CountCreateOperate();
        a.Create = this;
        a.Init();
        return a;
    }

    protected virtual KindCreateOperate CreateKindCreateOperate()
    {
        KindCreateOperate a;
        a = new KindCreateOperate();
        a.Create = this;
        a.Init();
        return a;
    }

    protected virtual SetCreateOperate CreateSetCreateOperate()
    {
        SetCreateOperate a;
        a = new SetCreateOperate();
        a.Create = this;
        a.Init();
        return a;
    }

    protected virtual CreateOperateArg CreateCreateOperateArg()
    {
        CreateOperateArg a;
        a = new CreateOperateArg();
        a.Init();
        return a;
    }

    protected virtual Range CreateRange()
    {
        Range a;
        a = new Range();
        a.Init();
        return a;
    }

    protected virtual Token CreateToken()
    {
        Token a;
        a = new Token();
        a.Init();
        a.Range = new Range();
        a.Range.Init();
        return a;
    }

    protected virtual Text CreateText()
    {
        Text a;
        a = new Text();
        a.Init();
        a.Range = new InfraRange();
        a.Range.Init();
        return a;
    }

    protected virtual TextIntParse CreateTextIntParse()
    {
        TextIntParse a;
        a = new TextIntParse();
        a.Init();
        return a;
    }

    protected virtual bool InitListItemState()
    {
        this.PartItemRangeState = this.RangeStateSet(new PartItemRangeState());
        this.StateItemRangeState = this.RangeStateSet(new StateItemRangeState());
        this.ParamItemRangeState = this.RangeStateSet(new ParamItemRangeState());
        this.ArgueItemRangeState = this.RangeStateSet(new ArgueItemRangeState());

        this.PartItemNodeState = this.NodeStateSet(new PartItemNodeState());
        this.StateItemNodeState = this.NodeStateSet(new StateItemNodeState());
        this.ParamItemNodeState = this.NodeStateSet(new ParamItemNodeState());
        this.ArgueItemNodeState = this.NodeStateSet(new ArgueItemNodeState());
        return true;
    }

    private RangeState RangeStateSet(RangeState state)
    {
        state.Init();
        state.Create = this;
        state.Arg = new RangeStateArg();
        state.Arg.Init();
        return state;
    }

    private NodeState NodeStateSet(NodeState state)
    {
        state.Init();
        state.Create = this;
        return state;
    }

    protected virtual bool InitNodeState()
    {
        StringCompare compare;
        compare = new StringCompare();
        compare.Init();

        this.NodeStateTable = new Table();
        this.NodeStateTable.Compare = compare;
        this.NodeStateTable.Init();

        int count;
        count = this.NodeKind.Count;
        int i;
        i = 0;
        while (i < count)
        {
            NodeKind kind;
            kind = this.NodeKind.Get(i);
            this.AddNodeState(kind);
            i = i + 1;
        }
        return true;
    }

    protected virtual bool AddNodeState(NodeKind kind)
    {
        NodeState state;
        state = kind.NodeState;
        state.Create = this;

        Entry entry;
        entry = new Entry();
        entry.Init();
        entry.Index = kind.Name;
        entry.Value = state;
        this.NodeStateTable.Add(entry);
        return true;
    }

    public override bool Execute()
    {
        this.Result = new Result();
        this.Result.Init();
        Array rootArray;
        rootArray = new Array();
        rootArray.Count = this.CodeArray.Count;
        rootArray.Init();
        this.Result.Root = rootArray;

        this.NodeState = (NodeState)this.NodeStateTable.Get(this.Task);
        if (this.NodeState == null)
        {
            Array ooo;
            ooo = new Array();
            ooo.Count = 0;
            ooo.Init();
            this.Result.Error = ooo;
            return true;
        }

        this.Operate = this.CountOperate;

        this.NodeIndex = 0;
        this.ListIndex = 0;
        this.NameValueIndex = 0;
        this.NameValueTotalIndex = 0;
        this.StringValueIndex = 0;
        this.StringValueTotalIndex = 0;
        this.ErrorIndex = 0;

        this.ExecuteStage();

        int nodeCount;
        nodeCount = this.NodeIndex;
        int listCount;
        listCount = this.ListIndex;
        int nameValueCount;
        nameValueCount = this.NameValueIndex;
        int nameValueTotalCount;
        nameValueTotalCount = this.NameValueTotalIndex;
        int stringValueCount;
        stringValueCount = this.StringValueIndex;
        int stringValueTotalCount;
        stringValueTotalCount = this.StringValueTotalIndex;
        int errorCount;
        errorCount = this.ErrorIndex;

        this.KindData = new Data();
        this.KindData.Count = nodeCount;
        this.KindData.Init();

        this.ListData = this.CountDataCreate(listCount);
        this.NameValueData = this.CountDataCreate(nameValueCount);
        this.NameValueText = this.TextDataCreate(nameValueTotalCount);
        this.StringValueData = this.CountDataCreate(stringValueCount);
        this.StringValueText = this.TextDataCreate(stringValueTotalCount);
        
        this.Operate = this.KindOperate;

        this.NodeIndex = 0;
        this.ListIndex = 0;
        this.NameValueIndex = 0;
        this.NameValueTotalIndex = 0;
        this.StringValueIndex = 0;
        this.StringValueTotalIndex = 0;
        this.ErrorIndex = 0;

        this.ExecuteStage();

        this.NodeArray = this.ListInfra.ArrayCreate(nodeCount);
        this.ListArray = this.ListInfra.ArrayCreate(listCount);
        this.NameValueArray = this.ListInfra.ArrayCreate(nameValueCount);
        this.StringValueArray = this.ListInfra.ArrayCreate(stringValueCount);
        this.ErrorArray = this.ListInfra.ArrayCreate(errorCount);

        this.ExecuteNodeCreate();
        this.ExecuteListCreate();
        this.ExecuteNameValueCreate();
        this.ExecuteStringValueCreate();
        this.ExecuteErrorCreate();

        this.Operate = this.SetOperate;

        this.NodeIndex = 0;
        this.ListIndex = 0;
        this.NameValueIndex = 0;
        this.StringValueIndex = 0;
        this.StringValueTotalIndex = 0;
        this.ErrorIndex = 0;

        this.ExecuteStage();

        this.Result.Error = this.ErrorArray;

        this.KindData = null;
        this.NodeArray = null;
        this.ListData = null;
        this.ListArray = null;
        this.NameValueData = null;
        this.NameValueText = null;
        this.NameValueArray = null;
        this.StringValueData = null;
        this.StringValueText = null;
        this.StringValueArray = null;
        this.ErrorArray = null;

        this.OperateArgClear();
        return true;
    }

    protected virtual bool OperateArgClear()
    {
        CreateOperateArg a;
        a = this.OperateArg;
        a.Kind = null;
        a.Field00 = null;
        a.Field01 = null;
        a.Field02 = null;
        a.Field03 = null;
        a.Field04 = null;
        a.FieldBool = false;
        a.FieldInt = 0;
        a.Start = 0;
        a.End = 0;
        return true;
    }

    protected virtual Data CountDataCreate(int count)
    {
        int o;
        o = count * sizeof(int);
        Data a;
        a = new Data();
        a.Count = o;
        a.Init();
        return a;
    }

    protected virtual Data TextDataCreate(int count)
    {
        int o;
        o = count * sizeof(short);
        Data a;
        a = new Data();
        a.Count = o;
        a.Init();
        return a;
    }

    protected virtual bool ExecuteNodeCreate()
    {
        int count;
        count = this.NodeArray.Count;
        int i;
        i = 0;
        while (i < count)
        {
            int oa;
            oa = this.KindData.Get(i);
            NodeKind kind;
            kind = this.NodeKind.Get(oa);

            InfraState newState;
            newState = kind.NewState;
            newState.Execute();

            object o;
            o = newState.Result;
            newState.Result = null;

            Node node;
            node = (Node)o;
            node.Init();
            this.NodeArray.Set(i, node);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteListCreate()
    {
        Data data;
        data = this.ListData;

        int count;
        count = this.ListArray.Count;
        int i;
        i = 0;
        while (i < count)
        {
            long index;
            index = i * sizeof(uint);
            uint u;
            u = this.InfraInfra.DataMidGet(data, index);
            int oa;
            oa = (int)u;
            Array array;
            array = new Array();
            array.Count = oa;
            array.Init();
            this.ListArray.Set(i, array);
            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteErrorCreate()
    {
        int count;
        count = this.ErrorArray.Count;
        int i;
        i = 0;
        while (i < count)
        {
            Error error;
            error = new Error();
            error.Init();
            error.Stage = this.Stage;
            Range range;
            range = new Range();
            range.Init();
            error.Range = range;
            this.ErrorArray.Set(i, error);
            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteNameValueCreate()
    {
        Data data;
        data = this.NameValueData;

        Text text;
        text = this.Text;
        text.Data = this.NameValueText;
        text.Range.Index = 0;
        text.Range.Count = 0;
        int total;
        total = 0;

        int count;
        count = this.NameValueArray.Count;
        int i;
        i = 0;
        while (i < count)
        {
            long index;
            index = i * sizeof(uint);
            uint u;
            u = this.InfraInfra.DataMidGet(data, index);
            int oa;
            oa = (int)u;
            text.Range.Index = total;
            text.Range.Count = oa;
            string oo;
            oo = this.TextInfra.StringCreate(text);
            this.NameValueArray.Set(i, oo);
            total = total + oa;
            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteStringValueCreate()
    {
        Data data;
        data = this.StringValueData;

        Text span;
        span = this.Text;
        span.Data = this.StringValueText;
        span.Range.Index = 0;
        span.Range.Count = 0;
        int total;
        total = 0;

        int count;
        count = this.StringValueArray.Count;
        int i;
        i = 0;
        while (i < count)
        {
            long index;
            index = i * sizeof(uint);
            uint u;
            u = this.InfraInfra.DataMidGet(data, index);
            int oa;
            oa = (int)u;
            span.Range.Index = total;
            span.Range.Count = oa;
            string oo;
            oo = this.TextInfra.StringCreate(span);
            this.StringValueArray.Set(i, oo);
            total = total + oa;
            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteStage()
    {
        int count;
        count = this.CodeArray.Count;
        int i;
        i = 0;
        while (i < count)
        {
            this.Code = (Code)this.CodeArray.Get(i);

            this.SourceItem = (SourceItem)this.Source.Item.Get(i);
            this.SourceText = this.SourceItem.Text;

            Node root;
            root = this.ExecuteRoot();
            this.Result.Root.Set(i, root);
            i = i + 1;
        }
        return true;
    }

    protected virtual Node ExecuteCreateOperate()
    {
        Node node;
        node = this.Operate.Execute();
        return node;
    }

    protected virtual Node ExecuteRoot()
    {
        Range range;
        range = this.RangeA;
        int rangeStart;
        rangeStart = 0;
        int rangeEnd;
        rangeEnd = this.Code.Token.Count;
        this.Range(range, rangeStart, rangeEnd);

        this.NodeState.Arg = range;
        this.NodeState.Execute();

        Node node;
        node = this.NodeState.Result;
        this.NodeState.Arg = null;
        this.NodeState.Result = null;
        if (node == null)
        {
            this.Error(this.ErrorKind.Invalid, rangeStart, rangeEnd);
        }
        Node a;
        a = node;
        return a;
    }

    public virtual Node ExecuteClass(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }
        Token classToken;
        classToken = this.Token(this.TokenA, this.Keyword.Class.Text, this.IndexRange(this.RangeA, start));
        if (classToken == null)
        {
            return null;
        }

        Token colon;
        colon = this.TokenForwardNoSkip(this.TokenB, this.Delimit.BaseSign.Text, this.Range(this.RangeA, classToken.Range.End, end));
        if (colon == null)
        {
            return null;
        }

        Token leftBrace;
        leftBrace = this.TokenForwardNoSkip(this.TokenC, this.Delimit.LeftBrace.Text, this.Range(this.RangeA, colon.Range.End, end));
        if (leftBrace == null)
        {
            return null;
        }

        Token rightBrace;
        rightBrace = this.TokenMatchLeftBrace(this.TokenD, this.Range(this.RangeA, leftBrace.Range.End, end));
        if (rightBrace == null)
        {
            return null;
        }

        if (!(rightBrace.Range.End == end))
        {
            return null;
        }

        int nameStart;
        int nameEnd;
        nameStart = classToken.Range.End;
        nameEnd = colon.Range.Start;
        int baseStart;
        int baseEnd;
        baseStart = colon.Range.End;
        baseEnd = leftBrace.Range.Start;
        int memberStart;
        int memberEnd;
        memberStart = leftBrace.Range.End;
        memberEnd = rightBrace.Range.Start;

        Node name;
        name = this.ExecuteName(this.NodeKind.ClassName, this.Range(this.RangeA, nameStart, nameEnd));
        if (name == null)
        {
            this.Error(this.ErrorKind.NameInvalid, nameStart, nameEnd);
        }

        Node varBase;
        varBase = this.ExecuteName(this.NodeKind.ClassName, this.Range(this.RangeA, baseStart, baseEnd));
        if (varBase == null)
        {
            this.Error(this.ErrorKind.BaseInvalid, baseStart, baseEnd);
        }

        Node member;
        member = this.ExecutePart(this.Range(this.RangeA, memberStart, memberEnd));
        if (member == null)
        {
            this.Error(this.ErrorKind.MemberInvalid, memberStart, memberEnd);
        }

        this.OperateArg.Kind = this.NodeKind.Class;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = name;
        this.OperateArg.Field01 = varBase;
        this.OperateArg.Field02 = member;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteField(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        Range countRange;
        countRange = this.ExecuteCountRange(this.RangeB, this.Range(this.RangeA, start, end));
        if (countRange == null)
        {
            return null;
        }

        Token leftBrace;
        leftBrace = this.TokenForwardNoSkip(this.TokenA, this.Delimit.LeftBrace.Text, this.Range(this.RangeA, countRange.End, end));
        if (leftBrace == null)
        {
            return null;
        }

        Token rightBrace;
        rightBrace = this.TokenMatchLeftBrace(this.TokenB, this.Range(this.RangeA, leftBrace.Range.End, end));
        if (rightBrace == null)
        {
            return null;
        }

        if (!(rightBrace.Range.End == end))
        {
            return null;
        }

        int countStart;
        int countEnd;
        countStart = countRange.Start;
        countEnd = countRange.End;
        int classStart;
        int classEnd;
        classStart = countRange.End;
        classEnd = classStart + 1;
        int nameStart;
        int nameEnd;
        nameStart = classEnd;
        nameEnd = leftBrace.Range.Start;
        int oStart;
        int oEnd;
        oStart = leftBrace.Range.End;
        oEnd = rightBrace.Range.Start;

        Node count;
        count = this.ExecuteCount(this.Range(this.RangeA, countStart, countEnd));
        if (count == null)
        {
            this.Error(this.ErrorKind.CountInvalid, countStart, countEnd);
        }

        Node varClass;
        varClass = this.ExecuteName(this.NodeKind.ClassName, this.Range(this.RangeA, classStart, classEnd));
        if (varClass == null)
        {
            this.Error(this.ErrorKind.ClassInvalid, classStart, classEnd);
        }

        Node name;
        name = this.ExecuteName(this.NodeKind.FieldName, this.Range(this.RangeA, nameStart, nameEnd));
        if (name == null)
        {
            this.Error(this.ErrorKind.NameInvalid, nameStart, nameEnd);
        }

        bool b;
        b = false;
        if (!b)
        {
            if (oStart == oEnd)
            {
                b = true;
            }
        }
        Token getToken;
        getToken = null;
        if (!b)
        {
            getToken = this.Token(this.TokenC, this.Keyword.ItemGet.Text, this.IndexRange(this.RangeA, oStart));
            if (getToken == null)
            {
                b = true;
            }
        }

        if (!b)
        {
            if (getToken.Range.End == oEnd)
            {
                b = true;
            }
        }
        Token getLeftBrace;
        getLeftBrace = null;
        if (!b)
        {
            getLeftBrace = this.Token(this.TokenD, this.Delimit.LeftBrace.Text, this.IndexRange(this.RangeA, getToken.Range.End));
            if (getLeftBrace == null)
            {
                b = true;
            }
        }

        Token getRightBrace;
        getRightBrace = null;
        if (!b)
        {
            getRightBrace = this.TokenMatchLeftBrace(this.TokenE, this.Range(this.RangeA, getLeftBrace.Range.End, oEnd));
            if (getRightBrace == null)
            {
                b = true;
            }
        }

        if (!b)
        {
            if (getRightBrace.Range.End == oEnd)
            {
                b = true;
            }
        }
        Token setToken;
        setToken = null;
        if (!b)
        {
            setToken = this.Token(this.TokenF, this.Keyword.Set.Text, this.IndexRange(this.RangeA, getRightBrace.Range.End));
            if (setToken == null)
            {
                b = true;
            }
        }

        if (!b)
        {
            if (setToken.Range.End == oEnd)
            {
                b = true;
            }
        }
        Token setLeftBrace;
        setLeftBrace = null;
        if (!b)
        {
            setLeftBrace = this.Token(this.TokenG, this.Delimit.LeftBrace.Text, this.IndexRange(this.RangeA, setToken.Range.End));
            if (setLeftBrace == null)
            {
                b = true;
            }
        }

        Token setRightBrace;
        setRightBrace = null;
        if (!b)
        {
            setRightBrace = this.TokenMatchLeftBrace(this.TokenH, this.Range(this.RangeA, setLeftBrace.Range.End, oEnd));
            if (setRightBrace == null)
            {
                b = true;
            }
        }

        if (!b)
        {
            if (!(setRightBrace.Range.End == oEnd))
            {
                b = true;
            }
        }

        Node varGet;
        varGet = null;

        Node varSet;
        varSet = null;
        if (!b)
        {
            int getStart;
            int getEnd;
            getStart = getLeftBrace.Range.End;
            getEnd = getRightBrace.Range.Start;
            int setStart;
            int setEnd;
            setStart = setLeftBrace.Range.End;
            setEnd = setRightBrace.Range.Start;
            
            varGet = this.ExecuteState(this.Range(this.RangeA, getStart, getEnd));

            varSet = this.ExecuteState(this.Range(this.RangeA, setStart, setEnd));
        }
        
        if (varGet == null)
        {
            this.Error(this.ErrorKind.GetInvalid, oStart, oEnd);
        }

        if (varSet == null)
        {
            this.Error(this.ErrorKind.SetInvalid, oStart, oEnd);
        }

        this.OperateArg.Kind = this.NodeKind.Field;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = varClass;
        this.OperateArg.Field01 = name;
        this.OperateArg.Field02 = count;
        this.OperateArg.Field03 = varGet;
        this.OperateArg.Field04 = varSet;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteMaide(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        Range countRange;
        countRange = this.ExecuteCountRange(this.RangeB, this.Range(this.RangeA, start, end));
        if (countRange == null)
        {
            return null;
        }

        Token leftBracket;
        leftBracket = this.TokenForwardNoSkip(this.TokenA, this.Delimit.LeftBracket.Text, this.Range(this.RangeA, countRange.End, end));
        if (leftBracket == null)
        {
            return null;
        }

        Token rightBracket;
        rightBracket = this.TokenMatchLeftBracket(this.TokenB, this.Range(this.RangeA, leftBracket.Range.End, end));
        if (rightBracket == null)
        {
            return null;
        }

        if (rightBracket.Range.End == end)
        {
            return null;
        }
        Token leftBrace;
        leftBrace = this.Token(this.TokenC, this.Delimit.LeftBrace.Text, this.IndexRange(this.RangeA, rightBracket.Range.End));
        if (leftBrace == null)
        {
            return null;
        }

        Token rightBrace;
        rightBrace = this.TokenMatchLeftBrace(this.TokenD, this.Range(this.RangeA, leftBrace.Range.End, end));
        if (rightBrace == null)
        {
            return null;
        }

        if (!(rightBrace.Range.End == end))
        {
            return null;
        }

        int countStart;
        int countEnd;
        countStart = countRange.Start;
        countEnd = countRange.End;
        int classStart;
        int classEnd;
        classStart = countEnd;
        classEnd = classStart + 1;
        int nameStart;
        int nameEnd;
        nameStart = classEnd;
        nameEnd = nameStart + 1;
        int paramStart;
        int paramEnd;
        paramStart = leftBracket.Range.End;
        paramEnd = rightBracket.Range.Start;
        int callStart;
        int callEnd;
        callStart = leftBrace.Range.End;
        callEnd = rightBrace.Range.Start;

        Node count;
        count = this.ExecuteCount(this.Range(this.RangeA, countStart, countEnd));
        if (count == null)
        {
            this.Error(this.ErrorKind.CountInvalid, countStart, countEnd);
        }

        Node varClass;
        varClass = this.ExecuteName(this.NodeKind.ClassName, this.Range(this.RangeA, classStart, classEnd));
        if (varClass == null)
        {
            this.Error(this.ErrorKind.ClassInvalid, classStart, classEnd);
        }

        Node name;
        name = this.ExecuteName(this.NodeKind.MaideName, this.Range(this.RangeA, nameStart, nameEnd));
        if (name == null)
        {
            this.Error(this.ErrorKind.NameInvalid, nameStart, nameEnd);
        }

        Node param;
        param = this.ExecuteParam(this.Range(this.RangeA, paramStart, paramEnd));
        if (param == null)
        {
            this.Error(this.ErrorKind.ParamInvalid, paramStart, paramEnd);
        }

        Node call;
        call = this.ExecuteState(this.Range(this.RangeA, callStart, callEnd));
        if (call == null)
        {
            this.Error(this.ErrorKind.CallInvalid, callStart, callEnd);
        }

        this.OperateArg.Kind = this.NodeKind.Maide;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = varClass;
        this.OperateArg.Field01 = name;
        this.OperateArg.Field02 = count;
        this.OperateArg.Field03 = param;
        this.OperateArg.Field04 = call;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteVar(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        Range classRange;
        classRange = this.ExecuteNameRange(this.RangeB, this.Range(this.RangeA, start, end));
        if (classRange == null)
        {
            return null;
        }

        Range nameRange;
        nameRange = this.ExecuteNameRange(this.RangeC, this.Range(this.RangeA, classRange.End, end));
        if (nameRange == null)
        {
            return null;
        }

        if (!(nameRange.End == end))
        {
            return null;
        }

        int classStart;
        int classEnd;
        classStart = classRange.Start;
        classEnd = classRange.End;
        int nameStart;
        int nameEnd;
        nameStart = nameRange.Start;
        nameEnd = nameRange.End;

        Node varClass;
        varClass = this.ExecuteNameNode(this.NodeKind.ClassName, this.Range(this.RangeA, classStart, classEnd));
        if (varClass == null)
        {
            this.Error(this.ErrorKind.ClassInvalid, classStart, classEnd);
        }

        Node name;
        name = this.ExecuteNameNode(this.NodeKind.VarName, this.Range(this.RangeA, nameStart, nameEnd));
        if (name == null)
        {
            this.Error(this.ErrorKind.NameInvalid, nameStart, nameEnd);
        }

        this.OperateArg.Kind = this.NodeKind.Var;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = varClass;
        this.OperateArg.Field01 = name;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteClassName(Range range)
    {
        return this.ExecuteName(this.NodeKind.ClassName, range);
    }

    public virtual Node ExecuteFieldName(Range range)
    {
        return this.ExecuteName(this.NodeKind.FieldName, range);
    }

    public virtual Node ExecuteMaideName(Range range)
    {
        return this.ExecuteName(this.NodeKind.MaideName, range);
    }

    public virtual Node ExecuteVarName(Range range)
    {
        return this.ExecuteName(this.NodeKind.VarName, range);
    }

    public virtual Node ExecutePart(Range range)
    {
        return this.ExecuteList(this.NodeKind.Part, this.PartItemRangeState, this.PartItemNodeState, range);
    }

    public virtual Node ExecuteState(Range range)
    {
        return this.ExecuteList(this.NodeKind.State, this.StateItemRangeState, this.StateItemNodeState, range);
    }

    public virtual Node ExecuteParam(Range range)
    {
        return this.ExecuteListComma(this.NodeKind.Param, this.ParamItemRangeState, this.ParamItemNodeState, range);
    }

    public virtual Node ExecuteArgue(Range range)
    {
        return this.ExecuteListComma(this.NodeKind.Argue, this.ArgueItemRangeState, this.ArgueItemNodeState, range);
    }

    public virtual Node ExecuteComp(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        Node a;
        a = null;
        if (a == null)
        {
            a = this.ExecuteField(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteMaide(this.Range(this.RangeA, start, end));
        }
       return a;
    }

    public virtual Node ExecuteTarget(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        Node a;
        a = null;
        if (a == null)
        {
            a = this.ExecuteVarTarget(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteBaseSetTarget(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteSetTarget(this.Range(this.RangeA, start, end));
        }
        return a;
    }

    public virtual Node ExecuteVarTarget(Range range)
    {
        return this.ExecuteVarNameResult(this.NodeKind.VarTarget, range);
    }

    public virtual Node ExecuteSetTarget(Range range)
    {
        return this.ExecuteDotField(this.NodeKind.SetTarget, range);
    }

    public virtual Node ExecuteBaseSetTarget(Range range)
    {
        return this.ExecuteWordDotField(this.NodeKind.BaseSetTarget, this.Keyword.Base, range);
    }

    public virtual Node ExecuteValue(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        Node a;
        a = null;
        if (a == null)
        {
            a = this.ExecuteBoolValue(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteIntHexSignValue(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteIntHexValue(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteIntSignValue(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteIntValue(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteStringValue(this.Range(this.RangeA, start, end));
        }
        return a;
    }

    public virtual Node ExecuteBoolValue(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (!(start + 1 == end))
        {
            return null;
        }

        TokenToken aa;
        aa = this.TokenToken(start);
        Text text;
        text = this.Text;
        this.TextGet(text, aa);

        bool value;
        value = false;

        bool b;
        b = false;
        if (!b)
        {
            if (this.ClassInfra.Equal(text, this.Keyword.True.Text))
            {
                value = true;


                b = true;
            }
        }
        if (!b)
        {
            if (this.ClassInfra.Equal(text, this.Keyword.False.Text))
            {
                value = false;


                b = true;
            }
        }

        if (!b)
        {
            return null;
        }

        this.OperateArg.Kind = this.NodeKind.BoolValue;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.FieldBool = value;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteIntValue(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (!(start + 1 == end))
        {
            return null;
        }

        TokenToken aa;
        aa = this.TokenToken(start);

        if (!this.IsIntValue(aa))
        {
            return null;
        }

        Text text;
        text = this.Text;
        this.TextGet(text, aa);
        
        long value;
        value = this.TextIntParse.Execute(text, 10, false);
        if (value == -1)
        {
            return null;
        }

        this.OperateArg.Kind = this.NodeKind.IntValue;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.FieldInt = value;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteIntHexValue(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (!(start + 1 == end))
        {
            return null;
        }

        TokenToken aa;
        aa = this.TokenToken(start);

        if (!this.IsIntHexValue(aa))
        {
            return null;
        }

        Text line;
        line = (Text)this.SourceText.Get(aa.Row);
        Text text;
        text = this.Text;
        text.Data = line.Data;
        text.Range.Index = aa.Range.Index + 2;
        text.Range.Count = aa.Range.Count - 2;

        long value;
        value = this.TextIntParse.Execute(text, 16, false);
        if (value == -1)
        {
            return null;
        }

        this.OperateArg.Kind = this.NodeKind.IntHexValue;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.FieldInt = value;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteIntSignValue(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (!(start + 1 == end))
        {
            return null;
        }

        TokenToken aa;
        aa = this.TokenToken(start);
        if (!this.IsIntSignValue(aa))
        {
            return null;
        }

        bool signNegative;
        signNegative = this.IsTokenSignNegative(aa, 2);

        Text line;
        line = (Text)this.SourceText.Get(aa.Row);
        Text text;
        text = this.Text;
        text.Data = line.Data;
        text.Range.Index = aa.Range.Index + 3;
        text.Range.Count = aa.Range.Count - 3;

        long o;
        o = this.TextIntParse.Execute(text, 10, false);

        if (o == -1)
        {
            return null;
        }

        long max;
        max = 0;
        if (!signNegative)
        {
            max = this.ClassInfra.IntSignValuePositiveMax;
        }
        if (signNegative)
        {
            max = this.ClassInfra.IntSignValueNegativeMax;
        }

        if (max < o)
        {
            return null;
        }

        long value;
        value = 0;
        if (!signNegative)
        {
            value = o;
        }
        if (signNegative)
        {
            value = -o;
        }

        this.OperateArg.Kind = this.NodeKind.IntSignValue;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.FieldInt = value;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteIntHexSignValue(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (!(start + 1 == end))
        {
            return null;
        }

        TokenToken aa;
        aa = this.TokenToken(start);
        if (!this.IsIntHexSignValue(aa))
        {
            return null;
        }

        bool signNegative;
        signNegative = this.IsTokenSignNegative(aa, 3);

        Text line;
        line = (Text)this.SourceText.Get(aa.Row);
        Text text;
        text = this.Text;
        text.Data = line.Data;
        text.Range.Index = aa.Range.Index + 4;
        text.Range.Count = aa.Range.Count - 4;

        long o;
        o = this.TextIntParse.Execute(text, 16, false);
        if (o == -1)
        {
            return null;
        }

        long max;
        max = 0;
        if (!signNegative)
        {
            max = this.ClassInfra.IntSignValuePositiveMax;
        }
        if (signNegative)
        {
            max = this.ClassInfra.IntSignValueNegativeMax;
        }

        if (max < o)
        {
            return null;
        }

        long value;
        value = 0;
        if (!signNegative)
        {
            value = o;
        }
        if (signNegative)
        {
            value = -o;
        }

        this.OperateArg.Kind = this.NodeKind.IntHexSignValue;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.FieldInt = value;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteStringValue(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (!(start + 1 == end))
        {
            return null;
        }

        TokenToken aa;
        aa = this.TokenToken(start);
        Text textSpan;
        textSpan = this.Text;
        this.TextGet(textSpan, aa);

        bool b;
        b = this.StringValueWrite.CheckValueString(textSpan);
        if (!b)
        {
            return null;
        }

        string value;
        value = this.Operate.ExecuteStringValue(textSpan);

        this.OperateArg.Kind = this.NodeKind.StringValue;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = value;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteCount(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        Node a;
        a = null;
        if (a == null)
        {
            a = this.ExecutePrudateCount(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteProbateCount(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecutePrecateCount(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecutePrivateCount(this.Range(this.RangeA, start, end));
        }
        return a;
    }

    public virtual Node ExecutePrudateCount(Range range)
    {
        return this.ExecuteOneWord(this.NodeKind.PrudateCount, this.Keyword.Prudate, range);
    }

    public virtual Node ExecuteProbateCount(Range range)
    {
        return this.ExecuteOneWord(this.NodeKind.ProbateCount, this.Keyword.Probate, range);
    }

    public virtual Node ExecutePrecateCount(Range range)
    {
        return this.ExecuteOneWord(this.NodeKind.PrecateCount, this.Keyword.Precate, range);
    }

    public virtual Node ExecutePrivateCount(Range range)
    {
        return this.ExecuteOneWord(this.NodeKind.PrivateCount, this.Keyword.Private, range);
    }

    public virtual Node ExecuteExecute(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        Node a;
        a = null;
        if (a == null)
        {
            a = this.ExecuteReturnExecute(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteInfExecute(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteWhileExecute(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteDeclareExecute(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteAssignExecute(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteOperateExecute(this.Range(this.RangeA, start, end));
        }
        return a;
    }

    public virtual Node ExecuteInfExecute(Range range)
    {
        return this.ExecuteWordBracketBody(this.NodeKind.InfExecute, this.Keyword.Inf, range);
    }

    public virtual Node ExecuteWhileExecute(Range range)
    {
        return this.ExecuteWordBracketBody(this.NodeKind.WhileExecute, this.Keyword.While, range);
    }

    public virtual Node ExecuteReturnExecute(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }
        Token returnToken;
        returnToken = this.Token(this.TokenA, this.Keyword.Return.Text, this.IndexRange(this.RangeA, start));
        if (returnToken == null)
        {
            return null;
        }

        if (returnToken.Range.End == end)
        {
            return null;
        }
        int lastIndex;
        lastIndex = end - 1;
        Token semicolon;
        semicolon = this.Token(this.TokenB, this.Delimit.ExecuteSign.Text, this.IndexRange(this.RangeA, lastIndex));
        if (semicolon == null)
        {
            return null;
        }

        int resultStart;
        int resultEnd;
        resultStart = returnToken.Range.End;
        resultEnd = semicolon.Range.Start;

        Node result;
        result = this.ExecuteOperate(this.Range(this.RangeA, resultStart, resultEnd));
        if (result == null)
        {
            this.Error(this.ErrorKind.ResultInvalid, resultStart, resultEnd);
        }

        this.OperateArg.Kind = this.NodeKind.ReturnExecute;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = result;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteDeclareExecute(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }
        int lastIndex;
        lastIndex = end - 1;
        Token semicolon;
        semicolon = this.Token(this.TokenA, this.Delimit.ExecuteSign.Text, this.IndexRange(this.RangeA, lastIndex));
        if (semicolon == null)
        {
            return null;
        }

        int varStart;
        int varEnd;
        varStart = start;
        varEnd = semicolon.Range.Start;

        Node varVar;
        varVar = this.ExecuteVar(this.Range(this.RangeA, varStart, varEnd));
        if (varVar == null)
        {
            return null;
        }

        this.OperateArg.Kind = this.NodeKind.DeclareExecute;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = varVar;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteAssignExecute(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }
        int lastIndex;
        lastIndex = end - 1;
        Token semicolon;
        semicolon = this.Token(this.TokenA, this.Delimit.ExecuteSign.Text, this.IndexRange(this.RangeA, lastIndex));
        if (semicolon == null)
        {
            return null;
        }

        Token colon;
        colon = this.TokenForward(this.TokenB, this.Delimit.BaseSign.Text, this.Range(this.RangeA, start, semicolon.Range.Start));
        if (colon == null)
        {
            return null;
        }

        int targetStart;
        int targetEnd;
        targetStart = start;
        targetEnd = colon.Range.Start;
        int valueStart;
        int valueEnd;
        valueStart = colon.Range.End;
        valueEnd = semicolon.Range.Start;

        Node target;
        target = this.ExecuteTarget(this.Range(this.RangeA, targetStart, targetEnd));
        if (target == null)
        {
            this.Error(this.ErrorKind.TargetInvalid, targetStart, targetEnd);
        }

        Node value;
        value = this.ExecuteOperate(this.Range(this.RangeA, valueStart, valueEnd));
        if (value == null)
        {
            this.Error(this.ErrorKind.ValueInvalid, valueStart, valueEnd);
        }

        this.OperateArg.Kind = this.NodeKind.AssignExecute;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = target;
        this.OperateArg.Field01 = value;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteOperateExecute(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }
        int lastIndex;
        lastIndex = end - 1;
        Token semicolon;
        semicolon = this.Token(this.TokenA, this.Delimit.ExecuteSign.Text, this.IndexRange(this.RangeA, lastIndex));
        if (semicolon == null)
        {
            return null;
        }

        int operateStart;
        int operateEnd;
        operateStart = start;
        operateEnd = semicolon.Range.Start;

        Node operate;
        operate = this.ExecuteOperate(this.Range(this.RangeA, operateStart, operateEnd));
        if (operate == null)
        {
            this.Error(this.ErrorKind.OperateInvalid, operateStart, operateEnd);
        }

        this.OperateArg.Kind = this.NodeKind.OperateExecute;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = operate;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteOperate(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        Node a;
        a = null;
        if (a == null)
        {
            a = this.ExecuteThisOperate(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteNullOperate(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteNewOperate(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteShareOperate(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteCastOperate(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            if (!(start == end))
            {
                Token wordTokenA;
                wordTokenA = this.Token(this.TokenA, this.Keyword.Sign.Text, this.IndexRange(this.RangeA, start));
                if (!(wordTokenA == null))
                {
                    if (a == null)
                    {
                        a = this.ExecuteSignMulOperate(this.Range(this.RangeA, start, end));
                    }
                    if (a == null)
                    {
                        a = this.ExecuteSignDivOperate(this.Range(this.RangeA, start, end));
                    }
                    if (a == null)
                    {
                        a = this.ExecuteSignLessOperate(this.Range(this.RangeA, start, end));
                    }
                }
            }
        }
        if (a == null)
        {
            if (!(start == end))
            {
                Token wordTokenB;
                wordTokenB = this.Token(this.TokenA, this.Keyword.Bit.Text, this.IndexRange(this.RangeA, start));
                if (!(wordTokenB == null))
                {
                    if (a == null)
                    {
                        a = this.ExecuteBitAndOperate(this.Range(this.RangeA, start, end));
                    }
                    if (a == null)
                    {
                        a = this.ExecuteBitOrnOperate(this.Range(this.RangeA, start, end));
                    }
                    if (a == null)
                    {
                        a = this.ExecuteBitNotOperate(this.Range(this.RangeA, start, end));
                    }
                    if (a == null)
                    {
                        a = this.ExecuteBitLeftOperate(this.Range(this.RangeA, start, end));
                    }
                    if (a == null)
                    {
                        a = this.ExecuteBitRightOperate(this.Range(this.RangeA, start, end));
                    }
                    if (a == null)
                    {
                        a = this.ExecuteBitSignRightOperate(this.Range(this.RangeA, start, end));
                    }
                }
            }
        }
        if (a == null)
        {
            a = this.ExecuteBracketOperate(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteVarOperate(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteValueOperate(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteEqualOperate(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteAndOperate(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteOrnOperate(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteNotOperate(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteLessOperate(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteAddOperate(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteSubOperate(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteMulOperate(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteDivOperate(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteBaseCallOperate(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteCallOperate(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteBaseGetOperate(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteGetOperate(this.Range(this.RangeA, start, end));
        }
        return a;
    }

    public virtual Node ExecuteGetOperate(Range range)
    {
        return this.ExecuteDotField(this.NodeKind.GetOperate, range);
    }

    public virtual Node ExecuteCallOperate(Range range)
    {
        return this.ExecuteDotMaideCall(this.NodeKind.CallOperate, range);
    }

    public virtual Node ExecuteBaseGetOperate(Range range)
    {
        return this.ExecuteWordDotField(this.NodeKind.BaseGetOperate, this.Keyword.Base, range);
    }

    public virtual Node ExecuteBaseCallOperate(Range range)
    {
        return this.ExecuteWordDotMaideCall(this.NodeKind.BaseCallOperate, this.Keyword.Base, range);
    }

    public virtual Node ExecuteThisOperate(Range range)
    {
        return this.ExecuteOneWord(this.NodeKind.ThisOperate, this.Keyword.ItemThis, range);
    }

    public virtual Node ExecuteNullOperate(Range range)
    {
        return this.ExecuteOneWord(this.NodeKind.NullOperate, this.Keyword.Null, range);
    }

    public virtual Node ExecuteNewOperate(Range range)
    {
        return this.ExecuteWordClass(this.NodeKind.NewOperate, this.Keyword.New, range);
    }

    public virtual Node ExecuteShareOperate(Range range)
    {
        return this.ExecuteWordClass(this.NodeKind.ShareOperate, this.Keyword.Share, range);
    }

    public virtual Node ExecuteCastOperate(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }
        Token castToken;
        castToken = this.Token(this.TokenA, this.Keyword.Cast.Text, this.IndexRange(this.RangeA, start));
        if (castToken == null)
        {
            return null;
        }

        Token leftBracket;
        leftBracket = this.TokenForwardNoSkip(this.TokenB, this.Delimit.LeftBracket.Text, this.Range(this.RangeA, castToken.Range.End, end));
        if (leftBracket == null)
        {
            return null;
        }

        Token rightBracket;
        rightBracket = this.TokenMatchLeftBracket(this.TokenC, this.Range(this.RangeA, leftBracket.Range.End, end));
        if (rightBracket == null)
        {
            return null;
        }

        if (!(rightBracket.Range.End == end))
        {
            return null;
        }

        int classStart;
        int classEnd;
        classStart = castToken.Range.End;
        classEnd = leftBracket.Range.Start;
        int anyStart;
        int anyEnd;
        anyStart = leftBracket.Range.End;
        anyEnd = rightBracket.Range.Start;

        Node varClass;
        varClass = this.ExecuteName(this.NodeKind.ClassName, this.Range(this.RangeA, classStart, classEnd));
        if (varClass == null)
        {
            this.Error(this.ErrorKind.ClassInvalid, classStart, classEnd);
        }

        Node any;
        any = this.ExecuteOperate(this.Range(this.RangeA, anyStart, anyEnd));
        if (any == null)
        {
            this.Error(this.ErrorKind.AnyInvalid, anyStart, anyEnd);
        }

        this.OperateArg.Kind = this.NodeKind.CastOperate;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = varClass;
        this.OperateArg.Field01 = any;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteVarOperate(Range range)
    {
        return this.ExecuteVarNameResult(this.NodeKind.VarOperate, range);
    }

    public virtual Node ExecuteValueOperate(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        Node value;
        value = this.ExecuteValue(this.Range(this.RangeA, start, end));
        if (value == null)
        {
            return null;
        }

        this.OperateArg.Kind = this.NodeKind.ValueOperate;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = value;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteBracketOperate(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }
        Token leftBracket;
        leftBracket = this.Token(this.TokenA, this.Delimit.LeftBracket.Text, this.IndexRange(this.RangeA, start));
        if (leftBracket == null)
        {
            return null;
        }

        Token rightBracket;
        rightBracket = this.TokenMatchLeftBracket(this.TokenB, this.Range(this.RangeA, leftBracket.Range.End, end));
        if (rightBracket == null)
        {
            return null;
        }

        if (!(rightBracket.Range.End == end))
        {
            return null;
        }

        int operateStart;
        int operateEnd;
        operateStart = leftBracket.Range.End;
        operateEnd = rightBracket.Range.Start;

        Node operate;
        operate = this.ExecuteOperate(this.Range(this.RangeA, operateStart, operateEnd));
        if (operate == null)
        {
            this.Error(this.ErrorKind.OperateInvalid, operateStart, operateEnd);
        }

        this.OperateArg.Kind = this.NodeKind.BracketOperate;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = operate;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteEqualOperate(Range range)
    {
        return this.ExecuteDelimitTwoOperand(this.NodeKind.EqualOperate, this.Delimit.EqualSign, range);
    }

    public virtual Node ExecuteAndOperate(Range range)
    {
        return this.ExecuteDelimitTwoOperand(this.NodeKind.AndOperate, this.Delimit.AndSign, range);
    }

    public virtual Node ExecuteOrnOperate(Range range)
    {
        return this.ExecuteDelimitTwoOperand(this.NodeKind.OrnOperate, this.Delimit.OrnSign, range);
    }

    public virtual Node ExecuteNotOperate(Range range)
    {
        return this.ExecuteDelimitOneOperand(this.NodeKind.NotOperate, this.Delimit.NotSign, range);
    }

    public virtual Node ExecuteAddOperate(Range range)
    {
        return this.ExecuteDelimitTwoOperand(this.NodeKind.AddOperate, this.Delimit.AddSign, range);
    }

    public virtual Node ExecuteSubOperate(Range range)
    {
        return this.ExecuteDelimitTwoOperand(this.NodeKind.SubOperate, this.Delimit.SubSign, range);
    }

    public virtual Node ExecuteMulOperate(Range range)
    {
        return this.ExecuteDelimitTwoOperand(this.NodeKind.MulOperate, this.Delimit.MulSign, range);
    }

    public virtual Node ExecuteDivOperate(Range range)
    {
        return this.ExecuteDelimitTwoOperand(this.NodeKind.DivOperate, this.Delimit.DivSign, range);
    }

    public virtual Node ExecuteLessOperate(Range range)
    {
        return this.ExecuteDelimitTwoOperand(this.NodeKind.LessOperate, this.Delimit.LessSign, range);
    }

    public virtual Node ExecuteSignMulOperate(Range range)
    {
        return this.ExecuteWordDelimitTwoOperand(this.NodeKind.SignMulOperate, this.Keyword.Sign, this.Delimit.MulSign, range);
    }

    public virtual Node ExecuteSignDivOperate(Range range)
    {
        return this.ExecuteWordDelimitTwoOperand(this.NodeKind.SignDivOperate, this.Keyword.Sign, this.Delimit.DivSign, range);
    }

    public virtual Node ExecuteSignLessOperate(Range range)
    {
        return this.ExecuteWordDelimitTwoOperand(this.NodeKind.SignLessOperate, this.Keyword.Sign, this.Delimit.LessSign, range);
    }

    public virtual Node ExecuteBitAndOperate(Range range)
    {
        return this.ExecuteWordDelimitTwoOperand(this.NodeKind.BitAndOperate, this.Keyword.Bit, this.Delimit.AndSign, range);
    }

    public virtual Node ExecuteBitOrnOperate(Range range)
    {
        return this.ExecuteWordDelimitTwoOperand(this.NodeKind.BitOrnOperate, this.Keyword.Bit, this.Delimit.OrnSign, range);
    }

    public virtual Node ExecuteBitNotOperate(Range range)
    {
        return this.ExecuteWordDelimitOneOperand(this.NodeKind.BitNotOperate, this.Keyword.Bit, this.Delimit.NotSign, range);
    }

    public virtual Node ExecuteBitLeftOperate(Range range)
    {
        return this.ExecuteWordDelimitTwoOperand(this.NodeKind.BitLeftOperate, this.Keyword.Bit, this.Delimit.LessSign, range);
    }

    public virtual Node ExecuteBitRightOperate(Range range)
    {
        return this.ExecuteWordDelimitTwoOperand(this.NodeKind.BitRightOperate, this.Keyword.Bit, this.Delimit.MoreSign, range);
    }

    public virtual Node ExecuteBitSignRightOperate(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }
        Token wordToken;
        wordToken = this.Token(this.TokenA, this.Keyword.Bit.Text, this.IndexRange(this.RangeA, start));
        if (wordToken == null)
        {
            return null;
        }

        if (wordToken.Range.End == end)
        {
            return null;
        }
        Token op;
        op = this.Token(this.TokenB, this.Delimit.MoreSign.Text, this.IndexRange(this.RangeA, wordToken.Range.End));
        if (op == null)
        {
            return null;
        }

        if (op.Range.End == end)
        {
            return null;
        }
        Token opA;
        opA = this.Token(this.TokenC, this.Delimit.MoreSign.Text, this.IndexRange(this.RangeA, op.Range.End));
        if (opA == null)
        {
            return null;
        }

        if (opA.Range.End == end)
        {
            return null;
        }
        Token leftBracket;
        leftBracket = this.Token(this.TokenA, this.Delimit.LeftBracket.Text, this.IndexRange(this.RangeA, opA.Range.End));
        if (leftBracket == null)
        {
            return null;
        }

        Token rightBracket;
        rightBracket = this.TokenMatchLeftBracket(this.TokenB, this.Range(this.RangeA, leftBracket.Range.End, end));
        if (rightBracket == null)
        {
            return null;
        }

        Token comma;
        comma = this.TokenForward(this.TokenC, this.Delimit.PauseSign.Text, this.Range(this.RangeA, leftBracket.Range.End, rightBracket.Range.Start));
        if (comma == null)
        {
            return null;
        }

        if (!(rightBracket.Range.End == end))
        {
            return null;
        }

        int leftStart;
        int leftEnd;
        leftStart = leftBracket.Range.End;
        leftEnd = comma.Range.Start;
        int rightStart;
        int rightEnd;
        rightStart = comma.Range.End;
        rightEnd = rightBracket.Range.Start;

        Node left;
        left = this.ExecuteOperate(this.Range(this.RangeA, leftStart, leftEnd));
        if (left == null)
        {
            this.Error(this.ErrorKind.OperandInvalid, leftStart, leftEnd);
        }

        Node right;
        right = this.ExecuteOperate(this.Range(this.RangeA, rightStart, rightEnd));
        if (right == null)
        {
            this.Error(this.ErrorKind.OperandInvalid, rightStart, rightEnd);
        }

        this.OperateArg.Kind = this.NodeKind.BitSignRightOperate;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = left;
        this.OperateArg.Field01 = right;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    protected virtual Node ExecuteWordBracketBody(NodeKind kind, Keyword word, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }
        Token wordToken;
        wordToken = this.Token(this.TokenA, word.Text, this.IndexRange(this.RangeA, start));
        if (wordToken == null)
        {
            return null;
        }

        if (wordToken.Range.End == end)
        {
            return null;
        }
        Token leftBracket;
        leftBracket = this.Token(this.TokenB, this.Delimit.LeftBracket.Text, this.IndexRange(this.RangeA, wordToken.Range.End));
        if (leftBracket == null)
        {
            return null;
        }

        Token rightBracket;
        rightBracket = this.TokenMatchLeftBracket(this.TokenC, this.Range(this.RangeA, leftBracket.Range.End, end));
        if (rightBracket == null)
        {
            return null;
        }

        if (rightBracket.Range.End == end)
        {
            return null;
        }
        Token leftBrace;
        leftBrace = this.Token(this.TokenD, this.Delimit.LeftBrace.Text, this.IndexRange(this.RangeA, rightBracket.Range.End));
        if (leftBrace == null)
        {
            return null;
        }

        Token rightBrace;
        rightBrace = this.TokenMatchLeftBrace(this.TokenA, this.Range(this.RangeA, leftBrace.Range.End, end));
        if (rightBrace == null)
        {
            return null;
        }

        if (!(rightBrace.Range.End == end))
        {
            return null;
        }

        int condStart;
        int condEnd;
        condStart = leftBracket.Range.End;
        condEnd = rightBracket.Range.Start;
        int bodyStart;
        int bodyEnd;
        bodyStart = leftBrace.Range.End;
        bodyEnd = rightBrace.Range.Start;

        Node cond;
        cond = this.ExecuteOperate(this.Range(this.RangeA, condStart, condEnd));
        if (cond == null)
        {
            this.Error(this.ErrorKind.CondInvalid, condStart, condEnd);
        }

        Node body;
        body = this.ExecuteState(this.Range(this.RangeA, bodyStart, bodyEnd));
        if (body == null)
        {
            this.Error(this.ErrorKind.BodyInvalid, bodyStart, bodyEnd);
        }

        this.OperateArg.Kind = kind;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = cond;
        this.OperateArg.Field01 = body;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    protected virtual Node ExecuteOneWord(NodeKind kind, Keyword word, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        Token wordToken;
        wordToken = this.Token(this.TokenA, word.Text, this.Range(this.RangeA, start, end));
        if (wordToken == null)
        {
            return null;
        }

        this.OperateArg.Kind = kind;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    protected virtual Node ExecuteWordClass(NodeKind kind, Keyword keyword, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }
        Token wordToken;
        wordToken = this.Token(this.TokenA, keyword.Text, this.IndexRange(this.RangeA, start));
        if (wordToken == null)
        {
            return null;
        }

        int classStart;
        int classEnd;
        classStart = wordToken.Range.End;
        classEnd = end;

        Node varClass;
        varClass = this.ExecuteName(this.NodeKind.ClassName, this.Range(this.RangeA, classStart, classEnd));
        if (varClass == null)
        {
            this.Error(this.ErrorKind.ClassInvalid, classStart, classEnd);
        }
        
        this.OperateArg.Kind = kind;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = varClass;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    protected virtual Node ExecuteDotField(NodeKind kind, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        Token dot;
        dot = this.TokenBackwardNoSkip(this.TokenA, this.Delimit.StopSign.Text, this.Range(this.RangeA, start, end));
        if (dot == null)
        {
            return null;
        }

        int thisStart;
        int thisEnd;
        thisStart = start;
        thisEnd = dot.Range.Start;
        int fieldStart;
        int fieldEnd;
        fieldStart = dot.Range.End;
        fieldEnd = end;

        Node varThis;
        varThis = this.ExecuteOperate(this.Range(this.RangeA, thisStart, thisEnd));
        if (varThis == null)
        {
            this.Error(this.ErrorKind.ThisInvalid, thisStart, thisEnd);
        }

        Node field;
        field = this.ExecuteName(this.NodeKind.FieldName, this.Range(this.RangeA, fieldStart, fieldEnd));
        if (field == null)
        {
            this.Error(this.ErrorKind.FieldInvalid, fieldStart, fieldEnd);
        }

        this.OperateArg.Kind = kind;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = varThis;
        this.OperateArg.Field01 = field;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    protected virtual Node ExecuteDotMaideCall(NodeKind kind, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }
        int lastIndex;
        lastIndex = end - 1;
        Token rightBracket;
        rightBracket = this.Token(this.TokenA, this.Delimit.RightBracket.Text, this.IndexRange(this.RangeA, lastIndex));
        if (rightBracket == null)
        {
            return null;
        }

        Token leftBracket;
        leftBracket = this.TokenMatchRightBracket(this.TokenB, this.Range(this.RangeA, start, rightBracket.Range.Start));
        if (leftBracket == null)
        {
            return null;
        }

        Token dot;
        dot = this.TokenBackwardNoSkip(this.TokenC, this.Delimit.StopSign.Text, this.Range(this.RangeA, start, leftBracket.Range.Start));
        if (dot == null)
        {
            return null;
        }

        int thisStart;
        int thisEnd;
        thisStart = start;
        thisEnd = dot.Range.Start;

        int maideStart;
        int maideEnd;
        maideStart = dot.Range.End;
        maideEnd = leftBracket.Range.Start;

        int argueStart;
        int argueEnd;
        argueStart = leftBracket.Range.End;
        argueEnd = rightBracket.Range.Start;

        Node varThis;
        varThis = this.ExecuteOperate(this.Range(this.RangeA, thisStart, thisEnd));
        if (varThis == null)
        {
            this.Error(this.ErrorKind.ThisInvalid, thisStart, thisEnd);
        }

        Node maide;
        maide = this.ExecuteName(this.NodeKind.MaideName, this.Range(this.RangeA, maideStart, maideEnd));
        if (maide == null)
        {
            this.Error(this.ErrorKind.MaideInvalid, maideStart, maideEnd);
        }

        Node argue;
        argue = this.ExecuteArgue(this.Range(this.RangeA, argueStart, argueEnd));
        if (argue == null)
        {
            this.Error(this.ErrorKind.ArgueInvalid, argueStart, argueEnd);
        }

        this.OperateArg.Kind = kind;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = varThis;
        this.OperateArg.Field01 = maide;
        this.OperateArg.Field02 = argue;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    protected virtual Node ExecuteWordDotField(NodeKind kind, Keyword word, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        Token dot;
        dot = this.TokenBackwardNoSkip(this.TokenA, this.Delimit.StopSign.Text, this.Range(this.RangeA, start, end));
        if (dot == null)
        {
            return null;
        }

        if (dot.Range.Start == start)
        {
            return null;
        }
        int wordIndex;
        wordIndex = dot.Range.Start - 1;
        Token wordToken;
        wordToken = this.Token(this.TokenB, word.Text, this.IndexRange(this.RangeA, wordIndex));
        if (wordToken == null)
        {
            return null;
        }

        if (!(wordToken.Range.Start == start))
        {
            return null;
        }

        int fieldStart;
        int fieldEnd;
        fieldStart = dot.Range.End;
        fieldEnd = end;

        Node field;
        field = this.ExecuteName(this.NodeKind.FieldName, this.Range(this.RangeA, fieldStart, fieldEnd));
        if (field == null)
        {
            this.Error(this.ErrorKind.FieldInvalid, fieldStart, fieldEnd);
        }

        this.OperateArg.Kind = kind;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = field;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    protected virtual Node ExecuteWordDotMaideCall(NodeKind kind, Keyword word, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }
        int lastIndex;
        lastIndex = end - 1;
        Token rightBracket;
        rightBracket = this.Token(this.TokenA, this.Delimit.RightBracket.Text, this.IndexRange(this.RangeA, lastIndex));
        if (rightBracket == null)
        {
            return null;
        }

        Token leftBracket;
        leftBracket = this.TokenMatchRightBracket(this.TokenB, this.Range(this.RangeA, start, rightBracket.Range.Start));
        if (leftBracket == null)
        {
            return null;
        }

        Token dot;
        dot = this.TokenBackwardNoSkip(this.TokenC, this.Delimit.StopSign.Text, this.Range(this.RangeA, start, leftBracket.Range.Start));
        if (dot == null)
        {
            return null;
        }

        if (dot.Range.Start == start)
        {
            return null;
        }
        int wordIndex;
        wordIndex = dot.Range.Start - 1;
        Token wordToken;
        wordToken = this.Token(this.TokenD, word.Text, this.IndexRange(this.RangeA, wordIndex));
        if (wordToken == null)
        {
            return null;
        }

        if (!(wordToken.Range.Start == start))
        {
            return null;
        }

        int maideStart;
        int maideEnd;
        maideStart = dot.Range.End;
        maideEnd = leftBracket.Range.Start;

        int argueStart;
        int argueEnd;
        argueStart = leftBracket.Range.End;
        argueEnd = rightBracket.Range.Start;

        Node maide;
        maide = this.ExecuteName(this.NodeKind.MaideName, this.Range(this.RangeA, maideStart, maideEnd));
        if (maide == null)
        {
            this.Error(this.ErrorKind.MaideInvalid, maideStart, maideEnd);
        }

        Node argue;
        argue = this.ExecuteArgue(this.Range(this.RangeA, argueStart, argueEnd));
        if (argue == null)
        {
            this.Error(this.ErrorKind.ArgueInvalid, argueStart, argueEnd);
        }

        this.OperateArg.Kind = kind;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = maide;
        this.OperateArg.Field01 = argue;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    protected virtual Node ExecuteVarNameResult(NodeKind kind, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        Node varVar;
        varVar = this.ExecuteName(this.NodeKind.VarName, this.Range(this.RangeA, start, end));
        if (varVar == null)
        {
            return null;
        }

        this.OperateArg.Kind = kind;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = varVar;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    protected virtual Node ExecuteName(NodeKind kind, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        Node node;
        node = null;
        bool b;
        b = false;
        Range aRange;
        aRange = this.ExecuteNameRange(this.RangeB, this.Range(this.RangeA, start, end));
        if (aRange == null)
        {
            b = true;
        }
        if (!b)
        {
            if (!(aRange.End == end))
            {
                b = true;
            }
        }
        if (!b)
        {
            node = this.ExecuteNameNode(kind, this.Range(this.RangeA, start, end));
        }

        return node;
    }

    protected virtual Node ExecuteNameNode(NodeKind kind, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        string value;
        value = this.ExecuteNameValue(this.Range(this.RangeA, start, end));
        if (value == null)
        {
            return null;
        }

        this.OperateArg.Kind = kind;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = value;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    protected virtual Node ExecuteDelimitTwoOperand(NodeKind kind, Delimit delimit, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        Token op;
        op = this.TokenForward(this.TokenA, delimit.Text, this.Range(this.RangeA, start, end));
        if (op == null)
        {
            return null;
        }

        int leftStart;
        int leftEnd;
        leftStart = start;
        leftEnd = op.Range.Start;
        int rightStart;
        int rightEnd;
        rightStart = op.Range.End;
        rightEnd = end;

        Node left;
        left = this.ExecuteOperate(this.Range(this.RangeA, leftStart, leftEnd));
        if (left == null)
        {
            this.Error(this.ErrorKind.OperandInvalid, leftStart, leftEnd);
        }

        Node right;
        right = this.ExecuteOperate(this.Range(this.RangeA, rightStart, rightEnd));
        if (right == null)
        {
            this.Error(this.ErrorKind.OperandInvalid, rightStart, rightEnd);
        }

        this.OperateArg.Kind = kind;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = left;
        this.OperateArg.Field01 = right;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    protected virtual Node ExecuteDelimitOneOperand(NodeKind kind, Delimit delimit, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }
        Token op;
        op = this.Token(this.TokenA, delimit.Text, this.IndexRange(this.RangeA, start));
        if (op == null)
        {
            return null;
        }

        int valueStart;
        int valueEnd;
        valueStart = op.Range.End;
        valueEnd = end;

        Node value;
        value = this.ExecuteOperate(this.Range(this.RangeA, valueStart, valueEnd));
        if (value == null)
        {
            this.Error(this.ErrorKind.OperandInvalid, valueStart, valueEnd);
        }

        this.OperateArg.Kind = kind;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = value;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    protected virtual Node ExecuteWordDelimitTwoOperand(NodeKind kind, Keyword word, Delimit delimit, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }
        Token wordToken;
        wordToken = this.Token(this.TokenA, word.Text, this.IndexRange(this.RangeA, start));
        if (wordToken == null)
        {
            return null;
        }

        if (wordToken.Range.End == end)
        {
            return null;
        }
        Token op;
        op = this.Token(this.TokenB, delimit.Text, this.IndexRange(this.RangeA, wordToken.Range.End));
        if (op == null)
        {
            return null;
        }

        if (op.Range.End == end)
        {
            return null;
        }
        Token leftBracket;
        leftBracket = this.Token(this.TokenC, this.Delimit.LeftBracket.Text, this.IndexRange(this.RangeA, op.Range.End));
        if (leftBracket == null)
        {
            return null;
        }

        Token rightBracket;
        rightBracket = this.TokenMatchLeftBracket(this.TokenD, this.Range(this.RangeA, leftBracket.Range.End, end));
        if (rightBracket == null)
        {
            return null;
        }

        Token comma;
        comma = this.TokenForward(this.TokenA, this.Delimit.PauseSign.Text, this.Range(this.RangeA, leftBracket.Range.End, rightBracket.Range.Start));
        if (comma == null)
        {
            return null;
        }

        if (!(rightBracket.Range.End == end))
        {
            return null;
        }

        int leftStart;
        int leftEnd;
        leftStart = leftBracket.Range.End;
        leftEnd = comma.Range.Start;
        int rightStart;
        int rightEnd;
        rightStart = comma.Range.End;
        rightEnd = rightBracket.Range.Start;

        Node left;
        left = this.ExecuteOperate(this.Range(this.RangeA, leftStart, leftEnd));
        if (left == null)
        {
            this.Error(this.ErrorKind.OperandInvalid, leftStart, leftEnd);
        }

        Node right;
        right = this.ExecuteOperate(this.Range(this.RangeA, rightStart, rightEnd));
        if (right == null)
        {
            this.Error(this.ErrorKind.OperandInvalid, rightStart, rightEnd);
        }

        this.OperateArg.Kind = kind;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = left;
        this.OperateArg.Field01 = right;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    protected virtual Node ExecuteWordDelimitOneOperand(NodeKind kind, Keyword word, Delimit delimit, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }
        Token wordToken;
        wordToken = this.Token(this.TokenA, word.Text, this.IndexRange(this.RangeA, start));
        if (wordToken == null)
        {
            return null;
        }

        if (wordToken.Range.End == end)
        {
            return null;
        }
        Token op;
        op = this.Token(this.TokenB, delimit.Text, this.IndexRange(this.RangeA, wordToken.Range.End));
        if (op == null)
        {
            return null;
        }

        if (op.Range.End == end)
        {
            return null;
        }
        Token leftBracket;
        leftBracket = this.Token(this.TokenC, this.Delimit.LeftBracket.Text, this.IndexRange(this.RangeA, op.Range.End));
        if (leftBracket == null)
        {
            return null;
        }

        Token rightBracket;
        rightBracket = this.TokenMatchLeftBracket(this.TokenD, this.Range(this.RangeA, leftBracket.Range.End, end));
        if (rightBracket == null)
        {
            return null;
        }

        if (!(rightBracket.Range.End == end))
        {
            return null;
        }

        int valueStart;
        int valueEnd;
        valueStart = leftBracket.Range.End;
        valueEnd = rightBracket.Range.Start;

        Node value;
        value = this.ExecuteOperate(this.Range(this.RangeA, valueStart, valueEnd));
        if (value == null)
        {
            this.Error(this.ErrorKind.OperandInvalid, valueStart, valueEnd);
        }

        this.OperateArg.Kind = kind;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = value;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    protected virtual Node ExecuteList(NodeKind kind, RangeState rangeState, NodeState nodeState, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        Array value;
        value = this.ExecuteListValue(rangeState, nodeState, this.Range(this.RangeA, start, end));
        if (value == null)
        {
            return null;
        }

        this.OperateArg.Kind = kind;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = value;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    protected virtual Node ExecuteListComma(NodeKind kind, RangeState rangeState, NodeState nodeState, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        Array value;
        value = this.ExecuteListValueComma(rangeState, nodeState, this.Range(this.RangeA, start, end));
        if (value == null)
        {
            return null;
        }

        this.OperateArg.Kind = kind;
        this.OperateArg.Start = start;
        this.OperateArg.End = end;
        this.OperateArg.Field00 = value;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    protected virtual Array ExecuteListValue(RangeState rangeState, NodeState nodeState, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        int listIndex;
        listIndex = this.Operate.ExecuteListNew();

        int count;
        count = 0;
        int index;
        index = start;
        while (index < end)
        {
            rangeState.Arg.Result = this.RangeB;
            rangeState.Arg.Range = this.Range(this.RangeA, index, end);
            rangeState.Execute();

            Range itemRange;
            itemRange = rangeState.Result;

            rangeState.Arg.Result = null;
            rangeState.Arg.Range = null;
            rangeState.Result = null;

            bool b;
            b = (itemRange == null);
            if (b)
            {
                int aStart;
                int aEnd;
                aStart = index;
                aEnd = end;
                this.Error(this.ErrorKind.ItemInvalid, aStart, aEnd);

                this.Operate.ExecuteListSetItem(listIndex, count, null);
                count = count + 1;

                index = end;
            }

            if (!b)
            {
                int itemStart;
                int itemEnd;
                itemStart = itemRange.Start;
                itemEnd = itemRange.End;

                index = itemEnd;

                nodeState.Arg = this.Range(this.RangeA, itemStart, itemEnd);
                nodeState.Execute();

                Node item;
                item = nodeState.Result;

                nodeState.Arg = null;
                nodeState.Result = null;

                bool ba;
                ba = (item == null);
                if (ba)
                {
                    this.Error(this.ErrorKind.ItemInvalid, itemStart, itemEnd);
                }

                this.Operate.ExecuteListSetItem(listIndex, count, item);

                count = count + 1;
            }
        }

        this.Operate.ExecuteListCount(listIndex, count);

        Array array;
        array = this.Operate.ExecuteListGet(listIndex);
        return array;
    }

    protected virtual Array ExecuteListValueComma(RangeState rangeState, NodeState nodeState, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        int listIndex;
        listIndex = this.Operate.ExecuteListNew();

        int count;
        count = 0;

        bool hasNextItem;
        hasNextItem = false;

        int index;
        index = start;
        while (index < end)
        {
            rangeState.Arg.Result = this.RangeB;
            rangeState.Arg.Range = this.Range(this.RangeA, index, end);

            rangeState.Execute();

            Range itemRange;
            itemRange = rangeState.Result;

            rangeState.Arg.Result = null;
            rangeState.Arg.Range = null;
            rangeState.Result = null;

            int aStart;
            int aEnd;
            aStart = 0;
            aEnd = 0;

            bool b;
            b = (itemRange == null);
            if (b)
            {
                aStart = index;
                aEnd = end;

                index = aEnd;

                hasNextItem = false;
            }

            if (!b)
            {
                aStart = itemRange.Start;
                aEnd = itemRange.End;

                index = aEnd + 1;

                hasNextItem = true;
            }

            nodeState.Arg = this.Range(this.RangeA, aStart, aEnd);

            nodeState.Execute();

            Node item;
            item = nodeState.Result;

            nodeState.Arg = null;
            nodeState.Result = null;

            bool ba;
            ba = (item == null);

            if (ba)
            {
                this.Error(this.ErrorKind.ItemInvalid, aStart, aEnd);
            }

            this.Operate.ExecuteListSetItem(listIndex, count, item);


            count = count + 1;
        }

        if (hasNextItem)
        {
            this.Error(this.ErrorKind.ItemInvalid, index, index);

            this.Operate.ExecuteListSetItem(listIndex, count, null);

            count = count + 1;
        }

        this.Operate.ExecuteListCount(listIndex, count);

        Array array;
        array = this.Operate.ExecuteListGet(listIndex);
        return array;
    }

    protected virtual Range ExecuteNameRange(Range result, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }

        if (!this.IsName(this.TokenToken(start)))
        {
            return null;
        }
        return this.IndexRange(result, start);
    }

    public virtual Range ExecuteExecuteRange(Range result, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        Range a;
        a = null;
        if (a == null)
        {
            a = this.ExecuteReturnExecuteRange(result, this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteInfExecuteRange(result, this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteWhileExecuteRange(result, this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteDeclareExecuteRange(result, this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteAssignExecuteRange(result, this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteOperateExecuteRange(result, this.Range(this.RangeA, start, end));
        }
        return a;
    }

    protected virtual Range ExecuteReturnExecuteRange(Range result, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }
        Token returnToken;
        returnToken = this.Token(this.TokenA, this.Keyword.Return.Text, this.IndexRange(this.RangeA, start));
        if (returnToken == null)
        {
            return null;
        }

        Token semicolon;
        semicolon = this.TokenForward(this.TokenB, this.Delimit.ExecuteSign.Text, this.Range(this.RangeA, returnToken.Range.End, end));
        if (semicolon == null)
        {
            return null;
        }

        this.Range(result, start, semicolon.Range.End);
        return result;
    }

    protected virtual Range ExecuteInfExecuteRange(Range result, Range range)
    {
        return this.ExecuteWordBracketRange(result, this.Keyword.Inf, range);
    }

    protected virtual Range ExecuteWhileExecuteRange(Range result, Range range)
    {
        return this.ExecuteWordBracketRange(result, this.Keyword.While, range);
    }

    protected virtual Range ExecuteWordBracketRange(Range result, Keyword word, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }
        Token wordToken;
        wordToken = this.Token(this.TokenA, word.Text, this.IndexRange(this.RangeA, start));
        if (wordToken == null)
        {
            return null;
        }

        if (wordToken.Range.End == end)
        {
            return null;
        }
        Token leftBracket;
        leftBracket = this.Token(this.TokenB, this.Delimit.LeftBracket.Text, this.IndexRange(this.RangeA, wordToken.Range.End));
        if (leftBracket == null)
        {
            return null;
        }

        Token rightBracket;
        rightBracket = this.TokenMatchLeftBracket(this.TokenC, this.Range(this.RangeA, leftBracket.Range.End, end));
        if (rightBracket == null)
        {
            return null;
        }

        if (rightBracket.Range.End == end)
        {
            return null;
        }
        Token leftBrace;
        leftBrace = this.Token(this.TokenD, this.Delimit.LeftBrace.Text, this.IndexRange(this.RangeA, rightBracket.Range.End));
        if (leftBrace == null)
        {
            return null;
        }

        Token rightBrace;
        rightBrace = this.TokenMatchLeftBrace(this.TokenA, this.Range(this.RangeA, leftBrace.Range.End, end));
        if (rightBrace == null)
        {
            return null;
        }

        this.Range(result, start, rightBrace.Range.End);
        return result;
    }

    protected virtual Range ExecuteDeclareExecuteRange(Range result, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        Range varRange;
        varRange = this.ExecuteVarRange(this.RangeB, this.Range(this.RangeA, start, end));
        if (varRange == null)
        {
            return null;
        }

        if (varRange.End == end)
        {
            return null;
        }
        Token semicolon;
        semicolon = this.Token(this.TokenA, this.Delimit.ExecuteSign.Text, this.IndexRange(this.RangeA, varRange.End));
        if (semicolon == null)
        {
            return null;
        }

        this.Range(result, start, semicolon.Range.End);
        return result;
    }

    protected virtual Range ExecuteAssignExecuteRange(Range result, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        Token semicolon;
        semicolon = this.TokenForward(this.TokenA, this.Delimit.ExecuteSign.Text, this.Range(this.RangeA, start, end));
        if (semicolon == null)
        {
            return null;
        }

        Token colon;
        colon = this.TokenForward(this.TokenB, this.Delimit.BaseSign.Text, this.Range(this.RangeA, start, semicolon.Range.Start));
        if (colon == null)
        {
            return null;
        }

        this.Range(result, start, semicolon.Range.End);
        return result;
    }

    protected virtual Range ExecuteOperateExecuteRange(Range result, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        Token semicolon;
        semicolon = this.TokenForward(this.TokenA, this.Delimit.ExecuteSign.Text, this.Range(this.RangeA, start, end));
        if (semicolon == null)
        {
            return null;
        }

        this.Range(result, start, semicolon.Range.End);
        return result;
    }

    protected virtual Range ExecuteVarRange(Range result, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        Range classRange;
        classRange = this.ExecuteNameRange(this.RangeB, this.Range(this.RangeA, start, end));
        if (classRange == null)
        {
            return null;
        }

        Range nameRange;
        nameRange = this.ExecuteNameRange(this.RangeC, this.Range(this.RangeA, classRange.End, end));
        if (nameRange == null)
        {
            return null;
        }

        this.Range(result, start, nameRange.End);
        return result;
    }

    public virtual Range ExecuteParamItemRange(Range result, Range range)
    {
        return this.ExecuteEndAtCommaRange(result, range);
    }

    public virtual Range ExecuteArgueItemRange(Range result, Range range)
    {
        return this.ExecuteEndAtCommaRange(result, range);
    }

    protected virtual Range ExecuteEndAtCommaRange(Range result, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        Token comma;
        comma = this.TokenForward(this.TokenA, this.Delimit.PauseSign.Text, this.Range(this.RangeA, start, end));
        if (comma == null)
        {
            return null;
        }
        this.Range(result, start, comma.Range.Start);
        return result;
    }

    protected virtual Range ExecuteCountRange(Range result, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }

        int index;
        index = start;

        bool b;
        b = false;
        if (!b & this.IsText(this.Keyword.Prudate.Text, index))
        {
            b = true;
        }
        if (!b & this.IsText(this.Keyword.Probate.Text, index))
        {
            b = true;
        }
        if (!b & this.IsText(this.Keyword.Precate.Text, index))
        {
            b = true;
        }
        if (!b & this.IsText(this.Keyword.Private.Text, index))
        {
            b = true;
        }

        if (!b)
        {
            return null;
        }
        this.IndexRange(result, index);
        return result;
    }

    public virtual Range ExecuteCompRange(Range result, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        Range a;
        a = null;
        if (a == null)
        {
            a = this.ExecuteFieldRange(result, this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteMaideRange(result, this.Range(this.RangeA, start, end));
        }
        return a;
    }

    protected virtual Range ExecuteFieldRange(Range result, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        Range countRange;
        countRange = this.ExecuteCountRange(this.RangeB, this.Range(this.RangeA, start, end));
        if (countRange == null)
        {
            return null;
        }

        Token leftBrace;
        leftBrace = this.TokenForwardNoSkip(this.TokenA, this.Delimit.LeftBrace.Text, this.Range(this.RangeA, countRange.End, end));
        if (leftBrace == null)
        {
            return null;
        }

        Token rightBrace;
        rightBrace = this.TokenMatchLeftBrace(this.TokenB, this.Range(this.RangeA, leftBrace.Range.End, end));
        if (rightBrace == null)
        {
            return null;
        }

        this.Range(result, start, rightBrace.Range.End);
        return result;
    }

    protected virtual Range ExecuteMaideRange(Range result, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        Range countRange;
        countRange = this.ExecuteCountRange(this.RangeB, this.Range(this.RangeA, start, end));
        if (countRange == null)
        {
            return null;
        }

        Token leftBracket;
        leftBracket = this.TokenForwardNoSkip(this.TokenA, this.Delimit.LeftBracket.Text, this.Range(this.RangeA, countRange.End, end));
        if (leftBracket == null)
        {
            return null;
        }

        Token rightBracket;
        rightBracket = this.TokenMatchLeftBracket(this.TokenB, this.Range(this.RangeA, leftBracket.Range.End, end));
        if (rightBracket == null)
        {
            return null;
        }

        if (rightBracket.Range.End == end)
        {
            return null;
        }
        Token leftBrace;
        leftBrace = this.Token(this.TokenC, this.Delimit.LeftBrace.Text, this.IndexRange(this.RangeA, rightBracket.Range.End));
        if (leftBrace == null)
        {
            return null;
        }

        Token rightBrace;
        rightBrace = this.TokenMatchLeftBrace(this.TokenD, this.Range(this.RangeA, leftBrace.Range.End, end));
        if (rightBrace == null)
        {
            return null;
        }

        this.Range(result, start, rightBrace.Range.End);
        return result;
    }

    protected virtual string ExecuteNameValue(Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (!((start + 1) == end))
        {
            return null;
        }

        TokenToken aa;
        aa = this.TokenToken(start);
        Text textSpan;
        textSpan = this.Text;
        this.TextGet(textSpan, aa);

        string a;
        a = this.Operate.ExecuteNameValue(textSpan);
        return a;
    }

    protected virtual bool IsIntValue(TokenToken aa)
    {
        this.TextGet(this.Text, aa);

        if (!this.IsIntChar(this.Text))
        {
            return false;
        }
        return true;
    }

    protected virtual bool IsIntHexValue(TokenToken aa)
    {
        int count;
        count = aa.Range.Count;

        if (count < 3)
        {
            return false;
        }

        Text line;
        line = (Text)this.SourceText.Get(aa.Row);

        Data data;
        data = line.Data;
        int start;
        start = aa.Range.Index;

        if (!(this.TextInfra.DataCharGet(data, start) == '0'))
        {
            return false;
        }
        if (!(this.TextInfra.DataCharGet(data, start + 1) == 'h'))
        {
            return false;
        }

        int startA;
        startA = start + 2;
        int countA;
        countA = count - 2;
        this.Text.Data = data;
        this.Text.Range.Index = startA;
        this.Text.Range.Count = countA;
        if (!this.IsIntHexChar(this.Text))
        {
            return false;
        }
        return true;
    }

    protected virtual bool IsIntSignValue(TokenToken aa)
    {
        int count;
        count = aa.Range.Count;

        if (count < 4)
        {
            return false;
        }

        Text line;
        line = (Text)this.SourceText.Get(aa.Row);

        Data data;
        data = line.Data;
        int start;
        start = aa.Range.Index;

        if (!(this.TextInfra.DataCharGet(data, start) == '0'))
        {
            return false;
        }
        if (!(this.TextInfra.DataCharGet(data, start + 1) == 's'))
        {
            return false;
        }

        char oa;
        oa = this.TextInfra.DataCharGet(data, start + 2);
        if (!this.IsIntSignChar(oa))
        {
            return false;
        }

        int startA;
        startA = start + 3;
        int countA;
        countA = count - 3;
        this.Text.Data = data;
        this.Text.Range.Index = startA;
        this.Text.Range.Count = countA;
        if (!this.IsIntChar(this.Text))
        {
            return false;
        }
        return true;
    }

    protected virtual bool IsIntHexSignValue(TokenToken aa)
    {
        int count;
        count = aa.Range.Count;

        if (count < 5)
        {
            return false;
        }

        Text line;
        line = (Text)this.SourceText.Get(aa.Row);

        Data data;
        data = line.Data;
        int start;
        start = aa.Range.Index;

        if (!(this.TextInfra.DataCharGet(data, start) == '0'))
        {
            return false;
        }
        if (!(this.TextInfra.DataCharGet(data, start + 1) == 'h'))
        {
            return false;
        }
        if (!(this.TextInfra.DataCharGet(data, start + 2) == 's'))
        {
            return false;
        }

        char oa;
        oa = this.TextInfra.DataCharGet(data, start + 3);
        if (!this.IsIntSignChar(oa))
        {
            return false;
        }

        int startA;
        startA = start + 4;
        int countA;
        countA = count - 4;
        this.Text.Data = data;
        this.Text.Range.Index = startA;
        this.Text.Range.Count = countA;
        if (!this.IsIntHexChar(this.Text))
        {
            return false;
        }
        return true;
    }

    protected virtual bool IsIntChar(Text span)
    {
        Data data;
        data = span.Data;
        int start;
        start = span.Range.Index;
        int count;
        count = span.Range.Count;
        int index;
        char oc;
        int i;
        i = 0;
        while (i < count)
        {
            index = start + i;

            oc = this.TextInfra.DataCharGet(data, index);

            if (!(this.TextInfra.IsDigit(oc)))
            {
                return false;
            }
            i = i + 1;
        }
        return true;
    }

    protected virtual bool IsIntHexChar(Text span)
    {
        Data data;
        data = span.Data;
        int start;
        start = span.Range.Index;
        int count;
        count = span.Range.Count;
        int index;
        char oc;
        int i;
        i = 0;
        while (i < count)
        {
            index = start + i;

            oc = this.TextInfra.DataCharGet(data, index);

            if (!(this.TextInfra.IsDigit(oc) | this.TextInfra.IsHexLetter(oc)))
            {
                return false;
            }
            i = i + 1;
        }
        return true;
    }

    protected virtual bool IsIntSignChar(char oc)
    {
        return (oc == 'p') | (oc == 'n');
    }

    protected virtual bool IsTokenSignNegative(TokenToken o, int index)
    {
        Text line;
        line = (Text)this.SourceText.Get(o.Row);

        Data data;
        data = line.Data;
        int start;
        start = o.Range.Index;

        char oa;
        oa = this.TextInfra.DataCharGet(data, start + index);
        bool a;
        a = (oa == 'n');
        return a;
    }

    protected virtual TokenToken TokenToken(int index)
    {
        TokenToken token;
        token = (TokenToken)this.Code.Token.Get(index);
        return token;
    }

    protected virtual int Count(Range range)
    {
        return this.ClassInfra.Count(range.Start, range.End);
    }

    protected virtual bool TextGet(Text text, TokenToken token)
    {
        Text line;
        line = (Text)this.SourceText.Get(token.Row);
        InfraRange range;
        range = token.Range;
        text.Data = line.Data;
        text.Range.Index = range.Index;
        text.Range.Count = range.Count;
        return true;
    }

    protected virtual bool IsName(TokenToken token)
    {
        if (this.IsKeyword(token))
        {
            return false;
        }

        TextInfra textInfra;
        textInfra = this.TextInfra;

        Text line;
        line = (Text)this.SourceText.Get(token.Row);

        Data data;
        data = line.Data;
        int start;
        start = token.Range.Index;

        int index;
        index = start;
        char oc;
        oc = textInfra.DataCharGet(data, index);
        if (!(textInfra.IsLetter(oc, true) | textInfra.IsLetter(oc, false)))
        {
            return false;
        }

        bool b;
        b = false;

        int count;
        count = token.Range.Count;
        count = count - 1;

        start = start + 1;
        
        int i;
        i = 0;
        while (!b & i < count)
        {
            index = start + i;

            oc = textInfra.DataCharGet(data, index);

            if (!(textInfra.IsLetter(oc, true) | textInfra.IsLetter(oc, false) | textInfra.IsDigit(oc) | oc == '_'))
            {
                b = true;
            }
            i = i + 1;
        }

        bool a;
        a = !b;
        return a;
    }

    protected virtual bool IsKeyword(TokenToken token)
    {
        ClassInfra classInfra;
        classInfra = this.ClassInfra;
        KeywordList keyword;
        keyword = this.Keyword;
        Text text;
        text = this.Text;
        this.TextGet(text, token);
        int count;
        count = keyword.Count;
        int i;
        i = 0;
        while (i < count)
        {
            Keyword a;
            a = keyword.Get(i);
            string o;
            o = a.Text;
            if (classInfra.Equal(text, o))
            {
                return true;
            }
            i = i + 1;
        }
        return false;
    }

    public virtual bool NodeInfo(Node node, int start, int end)
    {
        node.Range = this.CreateRange();
        this.Range(node.Range, start, end);
        return true;
    }

    protected virtual bool IsText(string value, int index)
    {
        TokenToken aa;
        aa = this.TokenToken(index);
        Text text;
        text = this.Text;
        this.TextGet(text, aa);
        bool b;
        b = this.ClassInfra.Equal(text, value);
        bool a;
        a = b;
        return a;
    }

    protected virtual Range Range(Range range, int start, int end)
    {
        range.Start = start;
        range.End = end;
        return range;
    }

    protected virtual Range IndexRange(Range range, int index)
    {
        this.ClassInfra.IndexRange(range, index);
        return range;
    }

    protected virtual bool Error(ErrorKind kind, int start, int end)
    {
        this.Operate.ExecuteError(kind, start, end);
        return true;
    }

    protected virtual Token Token(Token result, string value, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        if (!(start + 1 == end))
        {
            return null;
        }

        if (!this.IsText(value, start))
        {
            return null;
        }

        this.Range(result.Range, start, end);
        return result;
    }

    protected virtual Token TokenForwardNoSkip(Token result, string value, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;
        string leftBracket;
        string rightBracket;
        leftBracket = this.Delimit.LeftBracket.Text;
        rightBracket = this.Delimit.RightBracket.Text;
        string leftBrace;
        string rightBrace;
        leftBrace = this.Delimit.LeftBrace.Text;
        rightBrace = this.Delimit.RightBrace.Text;
        int i;
        i = start;
        int index;
        index = -1;
        bool varContinue;
        varContinue = (i < end);
        while (varContinue)
        {
            bool b;
            b = this.IsText(value, i);
            if (b)
            {
                index = i;
                varContinue = false;
            }
            if (!b)
            {
                bool ba;
                ba = (this.IsText(leftBracket, i) | this.IsText(rightBracket, i) | this.IsText(leftBrace, i) | this.IsText(rightBrace, i));
                if (ba)
                {
                    varContinue = false;
                }
                if (!ba)
                {
                    i = i + 1;
                }
            }
            if (!(i < end))
            {
                varContinue = false;
            }
        }
        if (index == -1)
        {
            return null;
        }

        this.IndexRange(result.Range, index);
        return result;
    }

    protected virtual Token TokenBackwardNoSkip(Token result, string value, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;
        string leftBracket;
        string rightBracket;
        leftBracket = this.Delimit.LeftBracket.Text;
        rightBracket = this.Delimit.RightBracket.Text;
        string leftBrace;
        string rightBrace;
        leftBrace = this.Delimit.LeftBrace.Text;
        rightBrace = this.Delimit.RightBrace.Text;
        int i;
        i = end;
        int index;
        index = -1;
        bool varContinue;
        varContinue = (start < i);
        while (varContinue)
        {
            int j;
            j = i - 1;
            bool b;
            b = this.IsText(value, j);
            if (b)
            {
                index = j;
                varContinue = false;
            }
            if (!b)
            {
                bool ba;
                ba = (this.IsText(leftBracket, j) | this.IsText(rightBracket, j) | this.IsText(leftBrace, j) | this.IsText(rightBrace, j));
                if (ba)
                {
                    varContinue = false;
                }
                if (!ba)
                {
                    i = i - 1;
                }
            }
            if (!(start < i))
            {
                varContinue = false;
            }
        }
        if (index == -1)
        {
            return null;
        }

        this.IndexRange(result.Range, index);
        return result;
    }

    protected virtual Token TokenForward(Token result, string value, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        int i;
        i = start;
        int index;
        index = -1;
        bool varContinue;
        varContinue = (i < end);
        while (varContinue)
        {
            bool b;
            b = this.IsText(value, i);
            if (b)
            {
                index = i;
                varContinue = false;
            }
            if (!b)
            {
                int skipBracketIndex;
                skipBracketIndex = this.ForwardSkipBracket(i, end);
                bool ba;
                ba = (skipBracketIndex == -1);
                if (!ba)
                {
                    i = skipBracketIndex;
                }
                if (ba)
                {
                    i = i + 1;
                }
            }
            if (!(i < end))
            {
                varContinue = false;
            }
        }
        if (index == -1)
        {
            return null;
        }

        this.IndexRange(result.Range, index);
        return result;
    }

    protected virtual Token TokenBackward(Token result, string value, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        int i;
        i = end;
        int index;
        index = -1;
        bool varContinue;
        varContinue = (start < i);
        while (varContinue)
        {
            int j;
            j = i - 1;
            bool b;
            b = this.IsText(value, j);
            if (b)
            {
                index = j;
                varContinue = false;
            }
            if (!b)
            {
                int skipBracketIndex;
                skipBracketIndex = this.BackwardSkipBracket(i, start);
                bool ba;
                ba = (skipBracketIndex == -1);
                if (!ba)
                {
                    i = skipBracketIndex;
                }
                if (ba)
                {
                    i = i - 1;
                }
            }
            if (!(start < i))
            {
                varContinue = false;
            }
        }
        if (index == -1)
        {
            return null;
        }

        this.IndexRange(result.Range, index);
        return result;
    }

    protected virtual int ForwardSkipBracket(int index, int end)
    {
        int ret;
        ret = -1;
        TokenToken aa;
        aa = this.TokenToken(index);
        Text text;
        text = this.Text;
        this.TextGet(text, aa);
        if (this.ClassInfra.Equal(text, this.Delimit.LeftBracket.Text))
        {
            Token rightBracket;
            rightBracket = this.TokenMatchLeftBracket(this.TokenA, this.Range(this.RangeA, index + 1, end));
            if (!(rightBracket == null))
            {
                ret = rightBracket.Range.End;
            }
        }
        if (this.ClassInfra.Equal(text, this.Delimit.LeftBrace.Text))
        {
            Token rightBrace;
            rightBrace = this.TokenMatchLeftBrace(this.TokenA, this.Range(this.RangeA, index + 1, end));
            if (!(rightBrace == null))
            {
                ret = rightBrace.Range.End;
            }
        }
        return ret;
    }

    protected virtual int BackwardSkipBracket(int index, int start)
    {
        int ret;
        ret = -1;
        int t;
        t = index - 1;
        TokenToken aa;
        aa = this.TokenToken(t);
        Text text;
        text = this.Text;
        this.TextGet(text, aa);
        if (this.ClassInfra.Equal(text, this.Delimit.RightBracket.Text))
        {
            Token leftBracket;
            leftBracket = this.TokenMatchRightBracket(this.TokenA, this.Range(this.RangeA, start, t));
            if (!(leftBracket == null))
            {
                ret = leftBracket.Range.Start;
            }
        }
        if (this.ClassInfra.Equal(text, this.Delimit.RightBrace.Text))
        {
            Token leftBrace;
            leftBrace = this.TokenMatchRightBrace(this.TokenA, this.Range(this.RangeA, start, t));
            if (!(leftBrace == null))
            {
                ret = leftBrace.Range.Start;
            }
        }
        return ret;
    }

    protected virtual Token TokenMatchLeftBrace(Token result, Range range)
    {
        return this.TokenMatchLeftToken(result, this.Delimit.LeftBrace.Text, this.Delimit.RightBrace.Text, range);
    }

    protected virtual Token TokenMatchRightBrace(Token result, Range range)
    {
        return this.TokenMatchRightToken(result, this.Delimit.LeftBrace.Text, this.Delimit.RightBrace.Text, range);
    }

    protected virtual Token TokenMatchLeftBracket(Token result, Range range)
    {
        return this.TokenMatchLeftToken(result, this.Delimit.LeftBracket.Text, this.Delimit.RightBracket.Text, range);
    }

    protected virtual Token TokenMatchRightBracket(Token result, Range range)
    {
        return this.TokenMatchRightToken(result, this.Delimit.LeftBracket.Text, this.Delimit.RightBracket.Text, range);
    }

    protected virtual Token TokenMatchLeftToken(Token result, string leftToken, string rightToken, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        Text text;
        text = this.Text;

        int openCount;
        openCount = 1;
        int index;
        index = -1;
        int i;
        i = start;
        bool varContinue;
        varContinue = (i < end);
        while (varContinue)
        {
            TokenToken aa;
            aa = this.TokenToken(i);
            this.TextGet(text, aa);
            if (this.ClassInfra.Equal(text, rightToken))
            {
                openCount = openCount - 1;
                if (openCount == 0)
                {
                    index = i;
                    varContinue = false;
                }
            }
            if (this.ClassInfra.Equal(text, leftToken))
            {
                openCount = openCount + 1;
            }
            if (index == -1)
            {
                i = i + 1;
                if (!(i < end))
                {
                    varContinue = false;
                }
            }
        }
        if (index == -1)
        {
            return null;
        }

        this.IndexRange(result.Range, index);
        return result;
    }

    protected virtual Token TokenMatchRightToken(Token result, string leftToken, string rightToken, Range range)
    {
        int start;
        int end;
        start = range.Start;
        end = range.End;

        Text text;
        text = this.Text;

        int openCount;
        openCount = 1;
        int index;
        index = -1;
        int i;
        i = end;
        bool varContinue;
        varContinue = (i > start);
        while (varContinue)
        {
            int t;
            t = i - 1;
            TokenToken aa;
            aa = this.TokenToken(t);
            this.TextGet(text, aa);
            if (this.ClassInfra.Equal(text, leftToken))
            {
                openCount = openCount - 1;
                if (openCount == 0)
                {
                    index = t;
                    varContinue = false;
                }
            }
            if (this.ClassInfra.Equal(text, rightToken))
            {
                openCount = openCount + 1;
            }
            if (index == -1)
            {
                i = i - 1;
                if (!(i > start))
                {
                    varContinue = false;
                }
            }
        }
        if (index == -1)
        {
            return null;
        }

        this.IndexRange(result.Range, index);
        return result;
    }
}