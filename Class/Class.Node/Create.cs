namespace Class.Node;

public class Create : InfraCreate
{
    public override bool Init()
    {
        base.Init();

        this.Index = IndexList.This;
        this.Limit = LimitList.This;
        this.ErrorKind = ErrorKindList.This;
        this.NodeKind = NodeKindList.This;

        this.CountOperate = this.CreateCountCreateOperate();
        this.KindOperate = this.CreateKindCreateOperate();
        this.SetOperate = this.CreateSetCreateOperate();
        this.SetArg = this.CreateCreateSetArg();

        this.NameCheck = this.CreateNameCheck();
        this.StringValueWrite = this.CreateStringValueWrite();
        this.TextIntParse = this.CreateTextIntParse();

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
        this.TokenI = this.CreateToken();

        this.InitListItemState();

        this.InitNodeState();
        return true;
    }

    public virtual Array Source { get; set; }
    public virtual Array Code { get; set; }
    public virtual String Task { get; set; }
    public virtual Result Result { get; set; }
    public virtual Source SourceItem { get; set; }
    public virtual CreateOperate Operate { get; set; }
    public virtual CreateArg Arg { get; set; }
    public virtual CreateSetArg SetArg { get; set; }

    protected virtual IndexList Index { get; set; }
    protected virtual LimitList Limit { get; set; }
    protected virtual ErrorKindList ErrorKind { get; set; }
    protected virtual NodeKindList NodeKind { get; set; }

    protected virtual Array SourceText { get; set; }
    protected virtual Code CodeItem { get; set; }
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
    protected virtual Token TokenI { get; set; }

    protected virtual TextIntParse TextIntParse { get; set; }

    protected virtual CountCreateOperate CountOperate { get; set; }
    protected virtual KindCreateOperate KindOperate { get; set; }
    protected virtual SetCreateOperate SetOperate { get; set; }

    protected virtual NameCheck NameCheck { get; set; }
    public virtual StringValueWrite StringValueWrite { get; set; }

    protected virtual NameCheck CreateNameCheck()
    {
        NameCheck a;
        a = new NameCheck();
        a.Init();
        a.TextLess = this.TLess;
        a.CharLess = this.CharLess;
        a.CharForm = this.TForm;
        return a;
    }

    protected virtual StringValueWrite CreateStringValueWrite()
    {
        StringValueWrite a;
        a = new StringValueWrite();
        a.Init();
        return a;
    }

    protected virtual TextIntParse CreateTextIntParse()
    {
        TextIntParse a;
        a = new TextIntParse();
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

    protected virtual CreateSetArg CreateCreateSetArg()
    {
        CreateSetArg a;
        a = new CreateSetArg();
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

        RangeStateArg k;
        k = new RangeStateArg();
        k.Init();

        state.Arg = k;
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
        this.NodeStateTable = this.ClassInfra.TableCreateStringLess();

        NodeKindList nodeKind;
        nodeKind = this.NodeKind;

        long count;
        count = nodeKind.Count;
        int i;
        i = 0;
        while (i < count)
        {
            NodeKind kind;
            kind = nodeKind.Get(i);
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

        this.ListInfra.TableAdd(this.NodeStateTable, kind.Name, state);
        return true;
    }

    public override bool Execute()
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;

        this.Result = new Result();
        this.Result.Init();
        Array rootArray;
        rootArray = new Array();
        rootArray.Count = this.Code.Count;
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

        CreateArg arg;
        arg = new CreateArg();
        arg.Init();
        this.Arg = arg;

        this.Operate = this.CountOperate;

        this.ExecuteStage();
        this.SetArgClear();

        Data nodeData;
        nodeData = new Data();
        nodeData.Count = arg.NodeIndex;
        nodeData.Init();
        arg.NodeData = nodeData;

        arg.ListData = this.CountDataCreate(arg.ListIndex);
        arg.NameValueCountData = this.CountDataCreate(arg.NameValueIndex);
        arg.NameValueTextData = this.TextDataCreate(arg.NameValueTextIndex);
        arg.StringValueCountData = this.CountDataCreate(arg.StringValueIndex);
        arg.StringValueTextData = this.TextDataCreate(arg.StringValueTextIndex);
        
        this.Operate = this.KindOperate;

        this.ArgClearIndex();
        this.ExecuteStage();
        this.SetArgClear();

        arg.NodeArray = listInfra.ArrayCreate(arg.NodeIndex);
        arg.ListArray = listInfra.ArrayCreate(arg.ListIndex);
        arg.NameValueArray = listInfra.ArrayCreate(arg.NameValueIndex);
        arg.StringValueArray = listInfra.ArrayCreate(arg.StringValueIndex);
        arg.ErrorArray = listInfra.ArrayCreate(arg.ErrorIndex);

        this.ExecuteCreateNode();
        this.ExecuteCreateList();
        this.ExecuteCreateNameValue();
        this.ExecuteCreateStringValue();
        this.ExecuteCreateError();

        this.Operate = this.SetOperate;

        this.ArgClearIndex();
        this.ExecuteStage();
        this.SetArgClear();

        this.Result.Error = arg.ErrorArray;

        this.Arg = null;
        return true;
    }
    
    protected virtual bool ArgClearIndex()
    {
        CreateArg arg;
        arg = this.Arg;

        arg.NodeIndex = 0;
        arg.ListIndex = 0;
        arg.NameValueIndex = 0;
        arg.NameValueTextIndex = 0;
        arg.StringValueIndex = 0;
        arg.StringValueTextIndex = 0;
        arg.ErrorIndex = 0;
        return true;
    }

    protected virtual bool SetArgClear()
    {
        CreateSetArg a;
        a = this.SetArg;
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

    protected virtual Data CountDataCreate(long count)
    {
        long o;
        o = count;
        o = o * sizeof(ulong);
        Data a;
        a = new Data();
        a.Count = o;
        a.Init();
        return a;
    }

    protected virtual Data TextDataCreate(long count)
    {
        long o;
        o = count;
        o = o * sizeof(uint);
        Data a;
        a = new Data();
        a.Count = o;
        a.Init();
        return a;
    }

    protected virtual bool ExecuteCreateNode()
    {
        CreateArg arg;
        arg = this.Arg;

        Array array;
        array = arg.NodeArray;

        Data data;
        data = arg.NodeData;

        NodeKindList nodeKind;
        nodeKind = this.NodeKind;

        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            long oa;
            oa = data.Get(i);
            NodeKind kind;
            kind = nodeKind.Get(oa);

            InfraState newState;
            newState = kind.NewState;
            newState.Execute();

            object o;
            o = newState.Result;
            newState.Result = null;

            Node node;
            node = (Node)o;
            node.Init();
            node.Range = this.CreateRange();
            array.SetAt(i, node);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteCreateList()
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;

        CreateArg arg;
        arg = this.Arg;
        
        Data data;
        data = arg.ListData;

        Array array;
        array = arg.ListArray;

        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            long index;
            index = i;
            index = index * sizeof(ulong);
            ulong u;
            u = this.InfraInfra.DataIntGet(data, index);
            long oa;
            oa = (long)u;

            Array a;
            a = listInfra.ArrayCreate(oa);

            array.SetAt(i, a);
            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteCreateError()
    {
        Array array;
        array = this.Arg.ErrorArray;

        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            Error error;
            error = new Error();
            error.Init();
            error.Stage = this.Stage;
            error.Range = this.CreateRange();

            array.SetAt(i, error);
            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteCreateNameValue()
    {
        InfraInfra infraInfra;
        infraInfra = this.InfraInfra;
        TextInfra textInfra;
        textInfra = this.TextInfra;

        CreateArg arg;
        arg = this.Arg;

        Array array;
        array = arg.NameValueArray;

        Data data;
        data = arg.NameValueCountData;

        Text text;
        text = this.TextA;
        text.Data = arg.NameValueTextData;
        InfraRange range;
        range = text.Range;
        range.Index = 0;
        range.Count = 0;

        long total;
        total = 0;

        long count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            long index;
            index = i;
            index = index * sizeof(ulong);

            ulong u;
            u = infraInfra.DataIntGet(data, index);
            long oa;
            oa = (long)u;

            range.Index = total;
            range.Count = oa;

            String a;
            a = textInfra.StringCreate(text);

            array.SetAt(i, a);

            total = total + oa;

            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteCreateStringValue()
    {
        InfraInfra infraInfra;
        infraInfra = this.InfraInfra;
        TextInfra textInfra;
        textInfra = this.TextInfra;

        CreateArg arg;
        arg = this.Arg;

        Array array;
        array = arg.StringValueArray;

        Data data;
        data = arg.StringValueCountData;

        Text text;
        text = this.TextA;
        text.Data = arg.StringValueTextData;
        InfraRange range;
        range = text.Range;
        range.Index = 0;
        range.Count = 0;

        long total;
        total = 0;

        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            long index;
            index = i;
            index = index * sizeof(ulong);
            
            ulong u;
            u = infraInfra.DataIntGet(data, index);
            long oa;
            oa = (long)u;
            
            range.Index = total;
            range.Count = oa;
            
            String a;
            a = textInfra.StringCreate(text);
            
            array.SetAt(i, a);
            
            total = total + oa;
            
            i = i + 1;
        }
        return true;
    }

    public virtual bool ExecuteStage()
    {
        long count;
        count = this.Code.Count;
        long i;
        i = 0;
        while (i < count)
        {
            this.CodeItem = (Code)this.Code.GetAt(i);

            this.SourceItem = (Source)this.Source.GetAt(i);
            this.SourceText = this.SourceItem.Text;

            Node root;
            root = this.ExecuteRoot();
            this.Result.Root.SetAt(i, root);
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
        long rangeStart;
        rangeStart = 0;
        long rangeEnd;
        rangeEnd = this.CodeItem.Token.Count;
        this.Range(range, rangeStart, rangeEnd);

        this.NodeState.Arg = range;
        this.NodeState.Execute();

        Node node;
        node = (Node)this.NodeState.Result;

        this.NodeState.Result = null;
        this.NodeState.Arg = null;

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
        long start;
        long end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }
        Token classToken;
        classToken = this.Token(this.TokenA, this.Index.Class.Text, this.IndexRange(this.RangeA, start));
        if (classToken == null)
        {
            return null;
        }

        Token colon;
        colon = this.TokenForwardNoSkip(this.TokenB, this.Limit.AreSign.Text, this.Range(this.RangeA, classToken.Range.End, end));
        if (colon == null)
        {
            return null;
        }

        Token leftBrace;
        leftBrace = this.TokenForwardNoSkip(this.TokenC, this.Limit.BraceLite.Text, this.Range(this.RangeA, colon.Range.End, end));
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

        long nameStart;
        long nameEnd;
        nameStart = classToken.Range.End;
        nameEnd = colon.Range.Start;
        long baseStart;
        long baseEnd;
        baseStart = colon.Range.End;
        baseEnd = leftBrace.Range.Start;
        long partStart;
        long partEnd;
        partStart = leftBrace.Range.End;
        partEnd = rightBrace.Range.Start;

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

        Node part;
        part = this.ExecutePart(this.Range(this.RangeA, partStart, partEnd));
        if (part == null)
        {
            this.Error(this.ErrorKind.PartInvalid, partStart, partEnd);
        }

        this.SetArg.Kind = this.NodeKind.Class;
        this.SetArg.Start = start;
        this.SetArg.End = end;
        this.SetArg.Field00 = name;
        this.SetArg.Field01 = varBase;
        this.SetArg.Field02 = part;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteField(Range range)
    {
        long start;
        long end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }

        Token fieldToken;
        fieldToken = this.Token(this.TokenA, this.Index.Field.Text, this.IndexRange(this.RangeA, start));
        if (fieldToken == null)
        {
            return null;
        }

        Token leftBrace;
        leftBrace = this.TokenForwardNoSkip(this.TokenB, this.Limit.BraceLite.Text, this.Range(this.RangeA, fieldToken.Range.End, end));
        if (leftBrace == null)
        {
            return null;
        }

        Token rightBrace;
        rightBrace = this.TokenMatchLeftBrace(this.TokenC, this.Range(this.RangeA, leftBrace.Range.End, end));
        if (rightBrace == null)
        {
            return null;
        }

        if (!(rightBrace.Range.End == end))
        {
            return null;
        }

        long countStart;
        long countEnd;
        countStart = fieldToken.Range.End;
        countEnd = countStart + 1;

        long ke;
        ke = leftBrace.Range.Start;

        if (ke < countEnd)
        {
            countEnd = ke;
        }

        long classStart;
        long classEnd;
        classStart = countEnd;
        classEnd = classStart + 1;

        if (ke < classEnd)
        {
            classEnd = ke;
        }

        long nameStart;
        long nameEnd;
        nameStart = classEnd;
        nameEnd = ke;
        
        long oStart;
        long oEnd;
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
            getToken = this.Token(this.TokenD, this.Index.ItemGet.Text, this.IndexRange(this.RangeA, oStart));
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
            getLeftBrace = this.Token(this.TokenE, this.Limit.BraceLite.Text, this.IndexRange(this.RangeA, getToken.Range.End));
            if (getLeftBrace == null)
            {
                b = true;
            }
        }

        Token getRightBrace;
        getRightBrace = null;
        if (!b)
        {
            getRightBrace = this.TokenMatchLeftBrace(this.TokenF, this.Range(this.RangeA, getLeftBrace.Range.End, oEnd));
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
            setToken = this.Token(this.TokenG, this.Index.Set.Text, this.IndexRange(this.RangeA, getRightBrace.Range.End));
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
            setLeftBrace = this.Token(this.TokenH, this.Limit.BraceLite.Text, this.IndexRange(this.RangeA, setToken.Range.End));
            if (setLeftBrace == null)
            {
                b = true;
            }
        }

        Token setRightBrace;
        setRightBrace = null;
        if (!b)
        {
            setRightBrace = this.TokenMatchLeftBrace(this.TokenI, this.Range(this.RangeA, setLeftBrace.Range.End, oEnd));
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
            long getStart;
            long getEnd;
            getStart = getLeftBrace.Range.End;
            getEnd = getRightBrace.Range.Start;
            long setStart;
            long setEnd;
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

        this.SetArg.Kind = this.NodeKind.Field;
        this.SetArg.Start = start;
        this.SetArg.End = end;
        this.SetArg.Field00 = varClass;
        this.SetArg.Field01 = name;
        this.SetArg.Field02 = count;
        this.SetArg.Field03 = varGet;
        this.SetArg.Field04 = varSet;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteMaide(Range range)
    {
        long start;
        long end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }

        Token maideToken;
        maideToken = this.Token(this.TokenA, this.Index.Maide.Text, this.IndexRange(this.RangeA, start));
        if (maideToken == null)
        {
            return null;
        }

        Token leftBracket;
        leftBracket = this.TokenForwardNoSkip(this.TokenB, this.Limit.BraceRoundLite.Text, this.Range(this.RangeA, maideToken.Range.End, end));
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
        leftBrace = this.Token(this.TokenD, this.Limit.BraceLite.Text, this.IndexRange(this.RangeA, rightBracket.Range.End));
        if (leftBrace == null)
        {
            return null;
        }

        Token rightBrace;
        rightBrace = this.TokenMatchLeftBrace(this.TokenE, this.Range(this.RangeA, leftBrace.Range.End, end));
        if (rightBrace == null)
        {
            return null;
        }

        if (!(rightBrace.Range.End == end))
        {
            return null;
        }

        long countStart;
        long countEnd;
        countStart = maideToken.Range.End;
        countEnd = countStart + 1;

        long ke;
        ke = leftBracket.Range.Start;

        if (ke < countEnd)
        {
            countEnd = ke;
        }

        long classStart;
        long classEnd;
        classStart = countEnd;
        classEnd = classStart + 1;

        if (ke < classEnd)
        {
            classEnd = ke;
        }

        long nameStart;
        long nameEnd;
        nameStart = classEnd;
        nameEnd = ke;
        
        long paramStart;
        long paramEnd;
        paramStart = leftBracket.Range.End;
        paramEnd = rightBracket.Range.Start;
        long callStart;
        long callEnd;
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

        this.SetArg.Kind = this.NodeKind.Maide;
        this.SetArg.Start = start;
        this.SetArg.End = end;
        this.SetArg.Field00 = varClass;
        this.SetArg.Field01 = name;
        this.SetArg.Field02 = count;
        this.SetArg.Field03 = param;
        this.SetArg.Field04 = call;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteVar(Range range)
    {
        long start;
        long end;
        start = range.Start;
        end = range.End;

        long count;
        count = this.Count(start, end);

        if (count < 1 | 3 < count)
        {
            return null;
        }

        Token varToken;
        varToken = this.Token(this.TokenA, this.Index.Var.Text, this.IndexRange(this.RangeA, start));
        if (varToken == null)
        {
            return null;
        }

        long classStart;
        long classEnd;
        classStart = varToken.Range.End;
        classEnd = classStart + 1;

        if (end < classEnd)
        {
            classEnd = end;
        }
        
        long nameStart;
        long nameEnd;
        nameStart = classEnd;
        nameEnd = end;

        Node varClass;
        varClass = this.ExecuteName(this.NodeKind.ClassName, this.Range(this.RangeA, classStart, classEnd));
        if (varClass == null)
        {
            this.Error(this.ErrorKind.ClassInvalid, classStart, classEnd);
        }

        Node name;
        name = this.ExecuteName(this.NodeKind.VarName, this.Range(this.RangeA, nameStart, nameEnd));
        if (name == null)
        {
            this.Error(this.ErrorKind.NameInvalid, nameStart, nameEnd);
        }

        this.SetArg.Kind = this.NodeKind.Var;
        this.SetArg.Start = start;
        this.SetArg.End = end;
        this.SetArg.Field00 = varClass;
        this.SetArg.Field01 = name;
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
        long start;
        long end;
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
        long start;
        long end;
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

    public virtual Node ExecuteValue(Range range)
    {
        long start;
        long end;
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
        long start;
        long end;
        start = range.Start;
        end = range.End;

        if (!(start + 1 == end))
        {
            return null;
        }

        TextInfra textInfra;
        textInfra = this.TextInfra;

        TextLess less;
        less = this.TextLess;
        TokenToken aa;
        aa = this.TokenToken(start);
        Text text;
        text = this.TextA;
        this.TextGet(text, aa);
        Text textB;
        textB = this.TextB;

        bool value;
        value = false;

        bool b;
        b = false;
        if (!b)
        {
            this.TextStringGet(textB, this.Index.True.Text);
            if (textInfra.Same(text, textB, less))
            {
                value = true;
                b = true;
            }
        }
        if (!b)
        {
            this.TextStringGet(textB, this.Index.False.Text);
            if (textInfra.Same(text, textB, less))
            {
                value = false;
                b = true;
            }
        }

        if (!b)
        {
            return null;
        }

        this.SetArg.Kind = this.NodeKind.BoolValue;
        this.SetArg.Start = start;
        this.SetArg.End = end;
        this.SetArg.FieldBool = value;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteIntValue(Range range)
    {
        long start;
        long end;
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
        text = this.TextA;
        this.TextGet(text, aa);
        
        long value;
        value = this.TextIntParse.Execute(text, 10, false, null);
        if (value == -1)
        {
            return null;
        }

        this.SetArg.Kind = this.NodeKind.IntValue;
        this.SetArg.Start = start;
        this.SetArg.End = end;
        this.SetArg.FieldInt = value;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteIntHexValue(Range range)
    {
        long start;
        long end;
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
        line = (Text)this.SourceText.GetAt(aa.Row);
        Text text;
        text = this.TextA;
        text.Data = line.Data;
        text.Range.Index = line.Range.Index + aa.Range.Index + 2;
        text.Range.Count = aa.Range.Count - 2;

        long value;
        value = this.TextIntParse.Execute(text, 16, false, null);
        if (value == -1)
        {
            return null;
        }

        this.SetArg.Kind = this.NodeKind.IntHexValue;
        this.SetArg.Start = start;
        this.SetArg.End = end;
        this.SetArg.FieldInt = value;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteIntSignValue(Range range)
    {
        long start;
        long end;
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
        line = (Text)this.SourceText.GetAt(aa.Row);
        Text text;
        text = this.TextA;
        text.Data = line.Data;
        text.Range.Index = line.Range.Index + aa.Range.Index + 3;
        text.Range.Count = aa.Range.Count - 3;

        long o;
        o = this.TextIntParse.Execute(text, 10, false, null);

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

        this.SetArg.Kind = this.NodeKind.IntSignValue;
        this.SetArg.Start = start;
        this.SetArg.End = end;
        this.SetArg.FieldInt = value;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteIntHexSignValue(Range range)
    {
        long start;
        long end;
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
        line = (Text)this.SourceText.GetAt(aa.Row);
        Text text;
        text = this.TextA;
        text.Data = line.Data;
        text.Range.Index = line.Range.Index + aa.Range.Index + 4;
        text.Range.Count = aa.Range.Count - 4;

        long o;
        o = this.TextIntParse.Execute(text, 16, false, null);
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

        this.SetArg.Kind = this.NodeKind.IntHexSignValue;
        this.SetArg.Start = start;
        this.SetArg.End = end;
        this.SetArg.FieldInt = value;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteStringValue(Range range)
    {
        long start;
        long end;
        start = range.Start;
        end = range.End;

        if (!(start + 1 == end))
        {
            return null;
        }

        TokenToken aa;
        aa = this.TokenToken(start);
        Text text;
        text = this.TextA;
        this.TextGet(text, aa);

        bool b;
        b = this.StringValueWrite.CheckValueString(text);
        if (!b)
        {
            return null;
        }

        String value;
        value = this.Operate.ExecuteStringValue(text);

        this.SetArg.Kind = this.NodeKind.StringValue;
        this.SetArg.Start = start;
        this.SetArg.End = end;
        this.SetArg.Field00 = value;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteCount(Range range)
    {
        long start;
        long end;
        start = range.Start;
        end = range.End;

        Node a;
        a = null;
        if (a == null)
        {
            a = this.ExecutePrusateCount(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecutePrecateCount(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecutePronateCount(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecutePrivateCount(this.Range(this.RangeA, start, end));
        }
        return a;
    }

    public virtual Node ExecutePrusateCount(Range range)
    {
        return this.ExecuteOneWord(this.NodeKind.PrusateCount, this.Index.Prusate, range);
    }

    public virtual Node ExecutePrecateCount(Range range)
    {
        return this.ExecuteOneWord(this.NodeKind.PrecateCount, this.Index.Precate, range);
    }

    public virtual Node ExecutePronateCount(Range range)
    {
        return this.ExecuteOneWord(this.NodeKind.PronateCount, this.Index.Pronate, range);
    }

    public virtual Node ExecutePrivateCount(Range range)
    {
        return this.ExecuteOneWord(this.NodeKind.PrivateCount, this.Index.Private, range);
    }

    public virtual Node ExecuteExecute(Range range)
    {
        long start;
        long end;
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
            a = this.ExecuteReferExecute(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteAreExecute(this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteOperateExecute(this.Range(this.RangeA, start, end));
        }
        return a;
    }

    public virtual Node ExecuteInfExecute(Range range)
    {
        return this.ExecuteWordBracketBody(this.NodeKind.InfExecute, this.Index.Inf, range);
    }

    public virtual Node ExecuteWhileExecute(Range range)
    {
        return this.ExecuteWordBracketBody(this.NodeKind.WhileExecute, this.Index.While, range);
    }

    public virtual Node ExecuteReturnExecute(Range range)
    {
        long start;
        long end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }
        Token returnToken;
        returnToken = this.Token(this.TokenA, this.Index.Return.Text, this.IndexRange(this.RangeA, start));
        if (returnToken == null)
        {
            return null;
        }

        if (returnToken.Range.End == end)
        {
            return null;
        }
        long lastIndex;
        lastIndex = end - 1;
        Token semicolon;
        semicolon = this.Token(this.TokenB, this.Limit.ExecuteSign.Text, this.IndexRange(this.RangeA, lastIndex));
        if (semicolon == null)
        {
            return null;
        }

        long resultStart;
        long resultEnd;
        resultStart = returnToken.Range.End;
        resultEnd = semicolon.Range.Start;

        Node result;
        result = this.ExecuteOperate(this.Range(this.RangeA, resultStart, resultEnd));
        if (result == null)
        {
            this.Error(this.ErrorKind.ResultInvalid, resultStart, resultEnd);
        }

        this.SetArg.Kind = this.NodeKind.ReturnExecute;
        this.SetArg.Start = start;
        this.SetArg.End = end;
        this.SetArg.Field00 = result;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteReferExecute(Range range)
    {
        long start;
        long end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }

        Token varToken;
        varToken = this.Token(this.TokenA, this.Index.Var.Text, this.IndexRange(this.RangeA, start));
        if (varToken == null)
        {
            return null;
        }

        if (varToken.Range.End == end)
        {
            return null;
        }

        long lastIndex;
        lastIndex = end - 1;
        Token semicolon;
        semicolon = this.Token(this.TokenB, this.Limit.ExecuteSign.Text, this.IndexRange(this.RangeA, lastIndex));
        if (semicolon == null)
        {
            return null;
        }

        long varStart;
        long varEnd;
        varStart = start;
        varEnd = semicolon.Range.Start;

        Node varVar;
        varVar = this.ExecuteVar(this.Range(this.RangeA, varStart, varEnd));
        if (varVar == null)
        {
            this.Error(this.ErrorKind.VarInvalid, varStart, varEnd);
        }

        this.SetArg.Kind = this.NodeKind.ReferExecute;
        this.SetArg.Start = start;
        this.SetArg.End = end;
        this.SetArg.Field00 = varVar;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteAreExecute(Range range)
    {
        long start;
        long end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }

        long lastIndex;
        lastIndex = end - 1;
        Token semicolon;
        semicolon = this.Token(this.TokenA, this.Limit.ExecuteSign.Text, this.IndexRange(this.RangeA, lastIndex));
        if (semicolon == null)
        {
            return null;
        }

        Token colon;
        colon = this.TokenForward(this.TokenB, this.Limit.AreSign.Text, this.Range(this.RangeA, start, semicolon.Range.Start));
        if (colon == null)
        {
            return null;
        }

        long targetStart;
        long targetEnd;
        targetStart = start;
        targetEnd = colon.Range.Start;
        long valueStart;
        long valueEnd;
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

        this.SetArg.Kind = this.NodeKind.AreExecute;
        this.SetArg.Start = start;
        this.SetArg.End = end;
        this.SetArg.Field00 = target;
        this.SetArg.Field01 = value;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteOperateExecute(Range range)
    {
        long start;
        long end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }
        long lastIndex;
        lastIndex = end - 1;
        Token semicolon;
        semicolon = this.Token(this.TokenA, this.Limit.ExecuteSign.Text, this.IndexRange(this.RangeA, lastIndex));
        if (semicolon == null)
        {
            return null;
        }

        long anyStart;
        long anyEnd;
        anyStart = start;
        anyEnd = semicolon.Range.Start;

        Node any;
        any = this.ExecuteOperate(this.Range(this.RangeA, anyStart, anyEnd));
        if (any == null)
        {
            this.Error(this.ErrorKind.AnyInvalid, anyStart, anyEnd);
        }

        this.SetArg.Kind = this.NodeKind.OperateExecute;
        this.SetArg.Start = start;
        this.SetArg.End = end;
        this.SetArg.Field00 = any;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteOperate(Range range)
    {
        long start;
        long end;
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
            a = this.ExecuteBaseOperate(this.Range(this.RangeA, start, end));
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
                wordTokenA = this.Token(this.TokenA, this.Index.Sign.Text, this.IndexRange(this.RangeA, start));
                if (!(wordTokenA == null))
                {
                    if (a == null)
                    {
                        a = this.ExecuteSignLessOperate(this.Range(this.RangeA, start, end));
                    }
                    if (a == null)
                    {
                        a = this.ExecuteSignMulOperate(this.Range(this.RangeA, start, end));
                    }
                    if (a == null)
                    {
                        a = this.ExecuteSignDivOperate(this.Range(this.RangeA, start, end));
                    }
                }
            }
        }
        if (a == null)
        {
            if (!(start == end))
            {
                Token wordTokenB;
                wordTokenB = this.Token(this.TokenA, this.Index.Bit.Text, this.IndexRange(this.RangeA, start));
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
                        a = this.ExecuteBitLiteOperate(this.Range(this.RangeA, start, end));
                    }
                    if (a == null)
                    {
                        a = this.ExecuteBitRiteOperate(this.Range(this.RangeA, start, end));
                    }
                    if (a == null)
                    {
                        a = this.ExecuteBitSignRiteOperate(this.Range(this.RangeA, start, end));
                    }
                }
            }
        }
        if (a == null)
        {
            a = this.ExecuteBraceOperate(this.Range(this.RangeA, start, end));
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
            a = this.ExecuteSameOperate(this.Range(this.RangeA, start, end));
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
            a = this.ExecuteCallOperate(this.Range(this.RangeA, start, end));
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

    public virtual Node ExecuteThisOperate(Range range)
    {
        return this.ExecuteOneWord(this.NodeKind.ThisOperate, this.Index.ItemThis, range);
    }

    public virtual Node ExecuteBaseOperate(Range range)
    {
        return this.ExecuteOneWord(this.NodeKind.BaseOperate, this.Index.Base, range);
    }

    public virtual Node ExecuteNullOperate(Range range)
    {
        return this.ExecuteOneWord(this.NodeKind.NullOperate, this.Index.Null, range);
    }

    public virtual Node ExecuteNewOperate(Range range)
    {
        return this.ExecuteWordClass(this.NodeKind.NewOperate, this.Index.New, range);
    }

    public virtual Node ExecuteShareOperate(Range range)
    {
        return this.ExecuteWordClass(this.NodeKind.ShareOperate, this.Index.Share, range);
    }

    public virtual Node ExecuteCastOperate(Range range)
    {
        long start;
        long end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }
        Token castToken;
        castToken = this.Token(this.TokenA, this.Index.Cast.Text, this.IndexRange(this.RangeA, start));
        if (castToken == null)
        {
            return null;
        }

        Token leftBracket;
        leftBracket = this.TokenForwardNoSkip(this.TokenB, this.Limit.BraceRoundLite.Text, this.Range(this.RangeA, castToken.Range.End, end));
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

        long classStart;
        long classEnd;
        classStart = castToken.Range.End;
        classEnd = leftBracket.Range.Start;
        long anyStart;
        long anyEnd;
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

        this.SetArg.Kind = this.NodeKind.CastOperate;
        this.SetArg.Start = start;
        this.SetArg.End = end;
        this.SetArg.Field00 = varClass;
        this.SetArg.Field01 = any;
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
        long start;
        long end;
        start = range.Start;
        end = range.End;

        Node value;
        value = this.ExecuteValue(this.Range(this.RangeA, start, end));
        if (value == null)
        {
            return null;
        }

        this.SetArg.Kind = this.NodeKind.ValueOperate;
        this.SetArg.Start = start;
        this.SetArg.End = end;
        this.SetArg.Field00 = value;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteBraceOperate(Range range)
    {
        long start;
        long end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }
        Token leftBracket;
        leftBracket = this.Token(this.TokenA, this.Limit.BraceRoundLite.Text, this.IndexRange(this.RangeA, start));
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

        long anyStart;
        long anyEnd;
        anyStart = leftBracket.Range.End;
        anyEnd = rightBracket.Range.Start;

        Node any;
        any = this.ExecuteOperate(this.Range(this.RangeA, anyStart, anyEnd));
        if (any == null)
        {
            this.Error(this.ErrorKind.AnyInvalid, anyStart, anyEnd);
        }

        this.SetArg.Kind = this.NodeKind.BraceOperate;
        this.SetArg.Start = start;
        this.SetArg.End = end;
        this.SetArg.Field00 = any;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    public virtual Node ExecuteSameOperate(Range range)
    {
        return this.ExecuteLimitTwoOperand(this.NodeKind.SameOperate, this.Limit.SameSign, range);
    }

    public virtual Node ExecuteAndOperate(Range range)
    {
        return this.ExecuteLimitTwoOperand(this.NodeKind.AndOperate, this.Limit.AndSign, range);
    }

    public virtual Node ExecuteOrnOperate(Range range)
    {
        return this.ExecuteLimitTwoOperand(this.NodeKind.OrnOperate, this.Limit.OrnSign, range);
    }

    public virtual Node ExecuteNotOperate(Range range)
    {
        return this.ExecuteLimitOneOperand(this.NodeKind.NotOperate, this.Limit.NotSign, range);
    }

    public virtual Node ExecuteAddOperate(Range range)
    {
        return this.ExecuteLimitTwoOperand(this.NodeKind.AddOperate, this.Limit.AddSign, range);
    }

    public virtual Node ExecuteSubOperate(Range range)
    {
        return this.ExecuteLimitTwoOperand(this.NodeKind.SubOperate, this.Limit.SubSign, range);
    }

    public virtual Node ExecuteMulOperate(Range range)
    {
        return this.ExecuteLimitTwoOperand(this.NodeKind.MulOperate, this.Limit.MulSign, range);
    }

    public virtual Node ExecuteDivOperate(Range range)
    {
        return this.ExecuteLimitTwoOperand(this.NodeKind.DivOperate, this.Limit.DivSign, range);
    }

    public virtual Node ExecuteLessOperate(Range range)
    {
        return this.ExecuteLimitTwoOperand(this.NodeKind.LessOperate, this.Limit.LessSign, range);
    }

    public virtual Node ExecuteSignMulOperate(Range range)
    {
        return this.ExecuteWordLimitTwoOperand(this.NodeKind.SignMulOperate, this.Index.Sign, this.Limit.MulSign, range);
    }

    public virtual Node ExecuteSignDivOperate(Range range)
    {
        return this.ExecuteWordLimitTwoOperand(this.NodeKind.SignDivOperate, this.Index.Sign, this.Limit.DivSign, range);
    }

    public virtual Node ExecuteSignLessOperate(Range range)
    {
        return this.ExecuteWordLimitTwoOperand(this.NodeKind.SignLessOperate, this.Index.Sign, this.Limit.LessSign, range);
    }

    public virtual Node ExecuteBitAndOperate(Range range)
    {
        return this.ExecuteWordLimitTwoOperand(this.NodeKind.BitAndOperate, this.Index.Bit, this.Limit.AndSign, range);
    }

    public virtual Node ExecuteBitOrnOperate(Range range)
    {
        return this.ExecuteWordLimitTwoOperand(this.NodeKind.BitOrnOperate, this.Index.Bit, this.Limit.OrnSign, range);
    }

    public virtual Node ExecuteBitNotOperate(Range range)
    {
        return this.ExecuteWordLimitOneOperand(this.NodeKind.BitNotOperate, this.Index.Bit, this.Limit.NotSign, range);
    }

    public virtual Node ExecuteBitLiteOperate(Range range)
    {
        return this.ExecuteWordLimitTwoOperand(this.NodeKind.BitLiteOperate, this.Index.Bit, this.Limit.LessSign, range);
    }

    public virtual Node ExecuteBitRiteOperate(Range range)
    {
        return this.ExecuteWordLimitTwoOperand(this.NodeKind.BitRiteOperate, this.Index.Bit, this.Limit.MoreSign, range);
    }

    public virtual Node ExecuteBitSignRiteOperate(Range range)
    {
        long start;
        long end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }
        Token wordToken;
        wordToken = this.Token(this.TokenA, this.Index.Bit.Text, this.IndexRange(this.RangeA, start));
        if (wordToken == null)
        {
            return null;
        }

        if (wordToken.Range.End == end)
        {
            return null;
        }
        Token op;
        op = this.Token(this.TokenB, this.Limit.MoreSign.Text, this.IndexRange(this.RangeA, wordToken.Range.End));
        if (op == null)
        {
            return null;
        }

        if (op.Range.End == end)
        {
            return null;
        }
        Token opA;
        opA = this.Token(this.TokenC, this.Limit.MoreSign.Text, this.IndexRange(this.RangeA, op.Range.End));
        if (opA == null)
        {
            return null;
        }

        if (opA.Range.End == end)
        {
            return null;
        }
        Token leftBracket;
        leftBracket = this.Token(this.TokenA, this.Limit.BraceRoundLite.Text, this.IndexRange(this.RangeA, opA.Range.End));
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
        comma = this.TokenForward(this.TokenC, this.Limit.PauseSign.Text, this.Range(this.RangeA, leftBracket.Range.End, rightBracket.Range.Start));
        if (comma == null)
        {
            return null;
        }

        if (!(rightBracket.Range.End == end))
        {
            return null;
        }

        long leftStart;
        long leftEnd;
        leftStart = leftBracket.Range.End;
        leftEnd = comma.Range.Start;
        long rightStart;
        long rightEnd;
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

        this.SetArg.Kind = this.NodeKind.BitSignRiteOperate;
        this.SetArg.Start = start;
        this.SetArg.End = end;
        this.SetArg.Field00 = left;
        this.SetArg.Field01 = right;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    protected virtual Node ExecuteWordBracketBody(NodeKind kind, Index word, Range range)
    {
        long start;
        long end;
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
        leftBracket = this.Token(this.TokenB, this.Limit.BraceRoundLite.Text, this.IndexRange(this.RangeA, wordToken.Range.End));
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
        leftBrace = this.Token(this.TokenD, this.Limit.BraceLite.Text, this.IndexRange(this.RangeA, rightBracket.Range.End));
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

        long condStart;
        long condEnd;
        condStart = leftBracket.Range.End;
        condEnd = rightBracket.Range.Start;
        long bodyStart;
        long bodyEnd;
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

        this.SetArg.Kind = kind;
        this.SetArg.Start = start;
        this.SetArg.End = end;
        this.SetArg.Field00 = cond;
        this.SetArg.Field01 = body;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    protected virtual Node ExecuteOneWord(NodeKind kind, Index word, Range range)
    {
        long start;
        long end;
        start = range.Start;
        end = range.End;

        Token wordToken;
        wordToken = this.Token(this.TokenA, word.Text, this.Range(this.RangeA, start, end));
        if (wordToken == null)
        {
            return null;
        }

        this.SetArg.Kind = kind;
        this.SetArg.Start = start;
        this.SetArg.End = end;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    protected virtual Node ExecuteWordClass(NodeKind kind, Index keyword, Range range)
    {
        long start;
        long end;
        start = range.Start;
        end = range.End;

        long count;
        count = this.Count(start, end);

        if (count < 1 | 2 < count)
        {
            return null;
        }

        Token wordToken;
        wordToken = this.Token(this.TokenA, keyword.Text, this.IndexRange(this.RangeA, start));
        if (wordToken == null)
        {
            return null;
        }

        long classStart;
        long classEnd;
        classStart = wordToken.Range.End;
        classEnd = end;

        Node varClass;
        varClass = this.ExecuteName(this.NodeKind.ClassName, this.Range(this.RangeA, classStart, classEnd));
        if (varClass == null)
        {
            this.Error(this.ErrorKind.ClassInvalid, classStart, classEnd);
        }
        
        this.SetArg.Kind = kind;
        this.SetArg.Start = start;
        this.SetArg.End = end;
        this.SetArg.Field00 = varClass;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    protected virtual Node ExecuteDotField(NodeKind kind, Range range)
    {
        long start;
        long end;
        start = range.Start;
        end = range.End;

        Token dot;
        dot = this.TokenBackwardNoSkip(this.TokenA, this.Limit.StopSign.Text, this.Range(this.RangeA, start, end));
        if (dot == null)
        {
            return null;
        }

        long thisStart;
        long thisEnd;
        thisStart = start;
        thisEnd = dot.Range.Start;
        long fieldStart;
        long fieldEnd;
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

        this.SetArg.Kind = kind;
        this.SetArg.Start = start;
        this.SetArg.End = end;
        this.SetArg.Field00 = varThis;
        this.SetArg.Field01 = field;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    protected virtual Node ExecuteDotMaideCall(NodeKind kind, Range range)
    {
        long start;
        long end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }
        long lastIndex;
        lastIndex = end - 1;
        Token rightBracket;
        rightBracket = this.Token(this.TokenA, this.Limit.BraceRoundRite.Text, this.IndexRange(this.RangeA, lastIndex));
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
        dot = this.TokenBackwardNoSkip(this.TokenC, this.Limit.StopSign.Text, this.Range(this.RangeA, start, leftBracket.Range.Start));
        if (dot == null)
        {
            return null;
        }

        long thisStart;
        long thisEnd;
        thisStart = start;
        thisEnd = dot.Range.Start;

        long maideStart;
        long maideEnd;
        maideStart = dot.Range.End;
        maideEnd = leftBracket.Range.Start;

        long argueStart;
        long argueEnd;
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

        this.SetArg.Kind = kind;
        this.SetArg.Start = start;
        this.SetArg.End = end;
        this.SetArg.Field00 = varThis;
        this.SetArg.Field01 = maide;
        this.SetArg.Field02 = argue;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    protected virtual Node ExecuteVarNameResult(NodeKind kind, Range range)
    {
        long start;
        long end;
        start = range.Start;
        end = range.End;

        Node varVar;
        varVar = this.ExecuteName(this.NodeKind.VarName, this.Range(this.RangeA, start, end));
        if (varVar == null)
        {
            return null;
        }

        this.SetArg.Kind = kind;
        this.SetArg.Start = start;
        this.SetArg.End = end;
        this.SetArg.Field00 = varVar;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    protected virtual Node ExecuteName(NodeKind kind, Range range)
    {
        long start;
        long end;
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
        long start;
        long end;
        start = range.Start;
        end = range.End;

        String value;
        value = this.ExecuteNameValue(this.Range(this.RangeA, start, end));
        if (value == null)
        {
            return null;
        }

        this.SetArg.Kind = kind;
        this.SetArg.Start = start;
        this.SetArg.End = end;
        this.SetArg.Field00 = value;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    protected virtual Node ExecuteLimitTwoOperand(NodeKind kind, Limit limit, Range range)
    {
        long start;
        long end;
        start = range.Start;
        end = range.End;

        Token op;
        op = this.TokenForward(this.TokenA, limit.Text, this.Range(this.RangeA, start, end));
        if (op == null)
        {
            return null;
        }

        long leftStart;
        long leftEnd;
        leftStart = start;
        leftEnd = op.Range.Start;
        long rightStart;
        long rightEnd;
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

        this.SetArg.Kind = kind;
        this.SetArg.Start = start;
        this.SetArg.End = end;
        this.SetArg.Field00 = left;
        this.SetArg.Field01 = right;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    protected virtual Node ExecuteLimitOneOperand(NodeKind kind, Limit limit, Range range)
    {
        long start;
        long end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }
        Token op;
        op = this.Token(this.TokenA, limit.Text, this.IndexRange(this.RangeA, start));
        if (op == null)
        {
            return null;
        }

        long valueStart;
        long valueEnd;
        valueStart = op.Range.End;
        valueEnd = end;

        Node value;
        value = this.ExecuteOperate(this.Range(this.RangeA, valueStart, valueEnd));
        if (value == null)
        {
            this.Error(this.ErrorKind.OperandInvalid, valueStart, valueEnd);
        }

        this.SetArg.Kind = kind;
        this.SetArg.Start = start;
        this.SetArg.End = end;
        this.SetArg.Field00 = value;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    protected virtual Node ExecuteWordLimitTwoOperand(NodeKind kind, Index word, Limit limit, Range range)
    {
        long start;
        long end;
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
        op = this.Token(this.TokenB, limit.Text, this.IndexRange(this.RangeA, wordToken.Range.End));
        if (op == null)
        {
            return null;
        }

        if (op.Range.End == end)
        {
            return null;
        }
        Token leftBracket;
        leftBracket = this.Token(this.TokenC, this.Limit.BraceRoundLite.Text, this.IndexRange(this.RangeA, op.Range.End));
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
        comma = this.TokenForward(this.TokenA, this.Limit.PauseSign.Text, this.Range(this.RangeA, leftBracket.Range.End, rightBracket.Range.Start));
        if (comma == null)
        {
            return null;
        }

        if (!(rightBracket.Range.End == end))
        {
            return null;
        }

        long leftStart;
        long leftEnd;
        leftStart = leftBracket.Range.End;
        leftEnd = comma.Range.Start;
        long rightStart;
        long rightEnd;
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

        this.SetArg.Kind = kind;
        this.SetArg.Start = start;
        this.SetArg.End = end;
        this.SetArg.Field00 = left;
        this.SetArg.Field01 = right;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    protected virtual Node ExecuteWordLimitOneOperand(NodeKind kind, Index word, Limit limit, Range range)
    {
        long start;
        long end;
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
        op = this.Token(this.TokenB, limit.Text, this.IndexRange(this.RangeA, wordToken.Range.End));
        if (op == null)
        {
            return null;
        }

        if (op.Range.End == end)
        {
            return null;
        }
        Token leftBracket;
        leftBracket = this.Token(this.TokenC, this.Limit.BraceRoundLite.Text, this.IndexRange(this.RangeA, op.Range.End));
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

        long valueStart;
        long valueEnd;
        valueStart = leftBracket.Range.End;
        valueEnd = rightBracket.Range.Start;

        Node value;
        value = this.ExecuteOperate(this.Range(this.RangeA, valueStart, valueEnd));
        if (value == null)
        {
            this.Error(this.ErrorKind.OperandInvalid, valueStart, valueEnd);
        }

        this.SetArg.Kind = kind;
        this.SetArg.Start = start;
        this.SetArg.End = end;
        this.SetArg.Field00 = value;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    protected virtual Node ExecuteList(NodeKind kind, RangeState rangeState, NodeState nodeState, Range range)
    {
        long start;
        long end;
        start = range.Start;
        end = range.End;

        Array value;
        value = this.ExecuteListValue(rangeState, nodeState, this.Range(this.RangeA, start, end));
        if (value == null)
        {
            return null;
        }

        this.SetArg.Kind = kind;
        this.SetArg.Start = start;
        this.SetArg.End = end;
        this.SetArg.Field00 = value;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    protected virtual Node ExecuteListComma(NodeKind kind, RangeState rangeState, NodeState nodeState, Range range)
    {
        long start;
        long end;
        start = range.Start;
        end = range.End;

        Array value;
        value = this.ExecuteListValueComma(rangeState, nodeState, this.Range(this.RangeA, start, end));
        if (value == null)
        {
            return null;
        }

        this.SetArg.Kind = kind;
        this.SetArg.Start = start;
        this.SetArg.End = end;
        this.SetArg.Field00 = value;
        Node ret;
        ret = this.ExecuteCreateOperate();
        return ret;
    }

    protected virtual Array ExecuteListValue(RangeState rangeState, NodeState nodeState, Range range)
    {
        long start;
        long end;
        start = range.Start;
        end = range.End;

        long listIndex;
        listIndex = this.Operate.ExecuteListNew();

        long count;
        count = 0;
        long index;
        index = start;
        while (index < end)
        {
            RangeStateArg arg;
            arg = (RangeStateArg)rangeState.Arg;

            arg.Result = this.RangeB;
            arg.Range = this.Range(this.RangeA, index, end);
            rangeState.Execute();

            Range itemRange;
            itemRange = (Range)rangeState.Result;
            
            rangeState.Result = null;
            arg.Result = null;
            arg.Range = null;

            bool b;
            b = (itemRange == null);
            if (b)
            {
                long aStart;
                long aEnd;
                aStart = index;
                aEnd = end;
                this.Error(this.ErrorKind.ItemInvalid, aStart, aEnd);

                this.Operate.ExecuteListSetItem(listIndex, count, null);
                count = count + 1;

                index = end;
            }

            if (!b)
            {
                long itemStart;
                long itemEnd;
                itemStart = itemRange.Start;
                itemEnd = itemRange.End;

                index = itemEnd;

                nodeState.Arg = this.Range(this.RangeA, itemStart, itemEnd);
                nodeState.Execute();

                Node item;
                item = (Node)nodeState.Result;

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
        long start;
        long end;
        start = range.Start;
        end = range.End;

        long listIndex;
        listIndex = this.Operate.ExecuteListNew();

        long count;
        count = 0;

        bool hasNextItem;
        hasNextItem = false;

        long index;
        index = start;
        while (index < end)
        {
            RangeStateArg arg;
            arg = (RangeStateArg)rangeState.Arg;

            arg.Result = this.RangeB;
            arg.Range = this.Range(this.RangeA, index, end);

            rangeState.Execute();

            Range itemRange;
            itemRange = (Range)rangeState.Result;

            rangeState.Result = null;
            arg.Result = null;
            arg.Range = null;

            long aStart;
            long aEnd;
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
            item = (Node)nodeState.Result;

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
        long start;
        long end;
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
        long start;
        long end;
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
            a = this.ExecuteReferExecuteRange(result, this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteAreExecuteRange(result, this.Range(this.RangeA, start, end));
        }
        if (a == null)
        {
            a = this.ExecuteOperateExecuteRange(result, this.Range(this.RangeA, start, end));
        }
        return a;
    }

    protected virtual Range ExecuteReturnExecuteRange(Range result, Range range)
    {
        long start;
        long end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }
        Token returnToken;
        returnToken = this.Token(this.TokenA, this.Index.Return.Text, this.IndexRange(this.RangeA, start));
        if (returnToken == null)
        {
            return null;
        }

        Token semicolon;
        semicolon = this.TokenForward(this.TokenB, this.Limit.ExecuteSign.Text, this.Range(this.RangeA, returnToken.Range.End, end));
        if (semicolon == null)
        {
            return null;
        }

        this.Range(result, start, semicolon.Range.End);
        return result;
    }

    protected virtual Range ExecuteInfExecuteRange(Range result, Range range)
    {
        return this.ExecuteWordBracketRange(result, this.Index.Inf, range);
    }

    protected virtual Range ExecuteWhileExecuteRange(Range result, Range range)
    {
        return this.ExecuteWordBracketRange(result, this.Index.While, range);
    }

    protected virtual Range ExecuteWordBracketRange(Range result, Index word, Range range)
    {
        long start;
        long end;
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
        leftBracket = this.Token(this.TokenB, this.Limit.BraceRoundLite.Text, this.IndexRange(this.RangeA, wordToken.Range.End));
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
        leftBrace = this.Token(this.TokenD, this.Limit.BraceLite.Text, this.IndexRange(this.RangeA, rightBracket.Range.End));
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

    protected virtual Range ExecuteReferExecuteRange(Range result, Range range)
    {
        long start;
        long end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }

        Token varToken;
        varToken = this.Token(this.TokenA, this.Index.Var.Text, this.IndexRange(this.RangeA, start));
        if (varToken == null)
        {
            return null;
        }

        Token semicolon;
        semicolon = this.TokenForward(this.TokenB, this.Limit.ExecuteSign.Text, this.Range(this.RangeA, varToken.Range.End, end));
        if (semicolon == null)
        {
            return null;
        }

        this.Range(result, start, semicolon.Range.End);
        return result;
    }

    protected virtual Range ExecuteAreExecuteRange(Range result, Range range)
    {
        long start;
        long end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }

        Token semicolon;
        semicolon = this.TokenForward(this.TokenA, this.Limit.ExecuteSign.Text, this.Range(this.RangeA, start, end));
        if (semicolon == null)
        {
            return null;
        }

        Token colon;
        colon = this.TokenForward(this.TokenB, this.Limit.AreSign.Text, this.Range(this.RangeA, start, semicolon.Range.Start));
        if (colon == null)
        {
            return null;
        }

        this.Range(result, start, semicolon.Range.End);
        return result;
    }

    protected virtual Range ExecuteOperateExecuteRange(Range result, Range range)
    {
        long start;
        long end;
        start = range.Start;
        end = range.End;

        Token semicolon;
        semicolon = this.TokenForward(this.TokenA, this.Limit.ExecuteSign.Text, this.Range(this.RangeA, start, end));
        if (semicolon == null)
        {
            return null;
        }

        this.Range(result, start, semicolon.Range.End);
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
        long start;
        long end;
        start = range.Start;
        end = range.End;

        Token comma;
        comma = this.TokenForward(this.TokenA, this.Limit.PauseSign.Text, this.Range(this.RangeA, start, end));
        if (comma == null)
        {
            return null;
        }
        this.Range(result, start, comma.Range.Start);
        return result;
    }

    public virtual Range ExecuteCompRange(Range result, Range range)
    {
        long start;
        long end;
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
        long start;
        long end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }

        Token fieldToken;
        fieldToken = this.Token(this.TokenA, this.Index.Field.Text, this.IndexRange(this.RangeA, start));
        if (fieldToken == null)
        {
            return null;
        }

        Token leftBrace;
        leftBrace = this.TokenForwardNoSkip(this.TokenB, this.Limit.BraceLite.Text, this.Range(this.RangeA, fieldToken.Range.End, end));
        if (leftBrace == null)
        {
            return null;
        }

        Token rightBrace;
        rightBrace = this.TokenMatchLeftBrace(this.TokenC, this.Range(this.RangeA, leftBrace.Range.End, end));
        if (rightBrace == null)
        {
            return null;
        }

        this.Range(result, start, rightBrace.Range.End);
        return result;
    }

    protected virtual Range ExecuteMaideRange(Range result, Range range)
    {
        long start;
        long end;
        start = range.Start;
        end = range.End;

        if (start == end)
        {
            return null;
        }

        Token maideToken;
        maideToken = this.Token(this.TokenA, this.Index.Maide.Text, this.IndexRange(this.RangeA, start));
        if (maideToken == null)
        {
            return null;
        }

        Token leftBracket;
        leftBracket = this.TokenForwardNoSkip(this.TokenB, this.Limit.BraceRoundLite.Text, this.Range(this.RangeA, maideToken.Range.End, end));
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
        leftBrace = this.Token(this.TokenD, this.Limit.BraceLite.Text, this.IndexRange(this.RangeA, rightBracket.Range.End));
        if (leftBrace == null)
        {
            return null;
        }

        Token rightBrace;
        rightBrace = this.TokenMatchLeftBrace(this.TokenE, this.Range(this.RangeA, leftBrace.Range.End, end));
        if (rightBrace == null)
        {
            return null;
        }

        this.Range(result, start, rightBrace.Range.End);
        return result;
    }

    protected virtual String ExecuteNameValue(Range range)
    {
        long start;
        long end;
        start = range.Start;
        end = range.End;

        if (!((start + 1) == end))
        {
            return null;
        }

        TokenToken aa;
        aa = this.TokenToken(start);
        Text text;
        text = this.TextA;
        this.TextGet(text, aa);

        String a;
        a = this.Operate.ExecuteNameValue(text);
        return a;
    }

    protected virtual bool IsIntValue(TokenToken aa)
    {
        this.TextGet(this.TextA, aa);

        if (!this.IsIntChar(this.TextA))
        {
            return false;
        }
        return true;
    }

    protected virtual bool IsIntHexValue(TokenToken aa)
    {
        long count;
        count = aa.Range.Count;

        if (count < 3)
        {
            return false;
        }

        Text line;
        line = (Text)this.SourceText.GetAt(aa.Row);

        Data data;
        data = line.Data;
        long start;
        start = line.Range.Index + aa.Range.Index;

        if (!(this.TextInfra.DataCharGet(data, start) == '0'))
        {
            return false;
        }
        if (!(this.TextInfra.DataCharGet(data, start + 1) == 'h'))
        {
            return false;
        }

        long startA;
        startA = start + 2;
        long countA;
        countA = count - 2;
        this.TextA.Data = data;
        this.TextA.Range.Index = startA;
        this.TextA.Range.Count = countA;
        if (!this.IsIntHexChar(this.TextA))
        {
            return false;
        }
        return true;
    }

    protected virtual bool IsIntSignValue(TokenToken aa)
    {
        long count;
        count = aa.Range.Count;

        if (count < 4)
        {
            return false;
        }

        Text line;
        line = (Text)this.SourceText.GetAt(aa.Row);

        Data data;
        data = line.Data;
        long start;
        start = line.Range.Index + aa.Range.Index;

        if (!(this.TextInfra.DataCharGet(data, start) == '0'))
        {
            return false;
        }
        if (!(this.TextInfra.DataCharGet(data, start + 1) == 's'))
        {
            return false;
        }

        uint oa;
        oa = this.TextInfra.DataCharGet(data, start + 2);
        if (!this.IsIntSignChar(oa))
        {
            return false;
        }

        long startA;
        startA = start + 3;
        long countA;
        countA = count - 3;
        this.TextA.Data = data;
        this.TextA.Range.Index = startA;
        this.TextA.Range.Count = countA;
        if (!this.IsIntChar(this.TextA))
        {
            return false;
        }
        return true;
    }

    protected virtual bool IsIntHexSignValue(TokenToken aa)
    {
        long count;
        count = aa.Range.Count;

        if (count < 5)
        {
            return false;
        }

        Text line;
        line = (Text)this.SourceText.GetAt(aa.Row);

        Data data;
        data = line.Data;
        long start;
        start = line.Range.Index + aa.Range.Index;

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

        uint oa;
        oa = this.TextInfra.DataCharGet(data, start + 3);
        if (!this.IsIntSignChar(oa))
        {
            return false;
        }

        long startA;
        startA = start + 4;
        long countA;
        countA = count - 4;
        this.TextA.Data = data;
        this.TextA.Range.Index = startA;
        this.TextA.Range.Count = countA;
        if (!this.IsIntHexChar(this.TextA))
        {
            return false;
        }
        return true;
    }

    protected virtual bool IsIntChar(Text text)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;

        Data data;
        data = text.Data;
        long start;
        start = text.Range.Index;
        long count;
        count = text.Range.Count;
        int i;
        i = 0;
        while (i < count)
        {
            long index;
            index = start + i;

            uint oc;
            oc = textInfra.DataCharGet(data, index);

            if (!(textInfra.Digit(oc)))
            {
                return false;
            }
            i = i + 1;
        }
        return true;
    }

    protected virtual bool IsIntHexChar(Text text)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;

        Data data;
        data = text.Data;
        long start;
        start = text.Range.Index;
        long count;
        count = text.Range.Count;
        long i;
        i = 0;
        while (i < count)
        {
            long index;
            index = start + i;

            uint oc;
            oc = textInfra.DataCharGet(data, index);

            if (!(textInfra.Digit(oc) | textInfra.HexAlpha(oc, false)))
            {
                return false;
            }
            i = i + 1;
        }
        return true;
    }

    protected virtual bool IsIntSignChar(uint oc)
    {
        return (oc == 'p') | (oc == 'n');
    }

    protected virtual bool IsTokenSignNegative(TokenToken o, long index)
    {
        Text line;
        line = (Text)this.SourceText.GetAt(o.Row);

        Data data;
        data = line.Data;
        long start;
        start = line.Range.Index + o.Range.Index;

        uint oa;
        oa = this.TextInfra.DataCharGet(data, start + index);
        bool a;
        a = (oa == 'n');
        return a;
    }

    protected virtual TokenToken TokenToken(long index)
    {
        TokenToken token;
        token = (TokenToken)this.CodeItem.Token.GetAt(index);
        return token;
    }

    protected virtual long Count(long start, long end)
    {
        return this.ClassInfra.Count(start, end);
    }

    protected virtual bool TextGet(Text text, TokenToken token)
    {
        Text line;
        line = (Text)this.SourceText.GetAt(token.Row);
        InfraRange range;
        range = token.Range;
        text.Data = line.Data;
        text.Range.Index = line.Range.Index + range.Index;
        text.Range.Count = range.Count;
        return true;
    }

    protected virtual bool TextStringGet(Text text, String o)
    {
        StringData d;
        d = this.StringData;
        d.ValueString = o;

        text.Data = d;
        text.Range.Index = 0;
        text.Range.Count = this.StringComp.Count(o);
        return true;
    }

    protected virtual bool IsName(TokenToken token)
    {
        this.TextGet(this.TextA, token);

        return this.NameCheck.IsName(this.TextA);
    }

    public virtual bool NodeInfo(Node node, long start, long end)
    {
        this.Range(node.Range, start, end);
        return true;
    }

    protected virtual bool IsText(String value, long index)
    {
        TokenToken aa;
        aa = this.TokenToken(index);
        
        Text text;
        text = this.TextA;
        this.TextGet(text, aa);

        Text textB;
        textB = this.TextB;
        this.TextStringGet(textB, value);

        bool b;
        b = this.TextInfra.Same(text, textB, this.TextLess);
        bool a;
        a = b;
        return a;
    }

    protected virtual Range Range(Range range, long start, long end)
    {
        range.Start = start;
        range.End = end;
        return range;
    }

    protected virtual Range IndexRange(Range range, long index)
    {
        this.ClassInfra.IndexRange(range, index);
        return range;
    }

    protected virtual bool Error(ErrorKind kind, long start, long end)
    {
        this.Operate.ExecuteError(kind, start, end);
        return true;
    }

    protected virtual Token Token(Token result, String value, Range range)
    {
        long start;
        long end;
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

    protected virtual Token TokenForwardNoSkip(Token result, String value, Range range)
    {
        long start;
        long end;
        start = range.Start;
        end = range.End;
        String leftBracket;
        String rightBracket;
        leftBracket = this.Limit.BraceRoundLite.Text;
        rightBracket = this.Limit.BraceRoundRite.Text;
        String leftBrace;
        String rightBrace;
        leftBrace = this.Limit.BraceLite.Text;
        rightBrace = this.Limit.BraceRite.Text;
        long i;
        i = start;
        long index;
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

    protected virtual Token TokenBackwardNoSkip(Token result, String value, Range range)
    {
        long start;
        long end;
        start = range.Start;
        end = range.End;
        String leftBracket;
        String rightBracket;
        leftBracket = this.Limit.BraceRoundLite.Text;
        rightBracket = this.Limit.BraceRoundRite.Text;
        String leftBrace;
        String rightBrace;
        leftBrace = this.Limit.BraceLite.Text;
        rightBrace = this.Limit.BraceRite.Text;
        long i;
        i = end;
        long index;
        index = -1;
        bool varContinue;
        varContinue = (start < i);
        while (varContinue)
        {
            long j;
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

    protected virtual Token TokenForward(Token result, String value, Range range)
    {
        long start;
        long end;
        start = range.Start;
        end = range.End;

        long i;
        i = start;
        long index;
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
                long skipBracketIndex;
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

    protected virtual Token TokenBackward(Token result, String value, Range range)
    {
        long start;
        long end;
        start = range.Start;
        end = range.End;

        long i;
        i = end;
        long index;
        index = -1;
        bool varContinue;
        varContinue = (start < i);
        while (varContinue)
        {
            long j;
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
                long skipBracketIndex;
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

    protected virtual long ForwardSkipBracket(long index, long end)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;
        LimitList limit;
        limit = this.Limit;
        long ret;
        ret = -1;
        TokenToken aa;
        aa = this.TokenToken(index);
        
        TextLess less;
        less = this.TextLess;
        Text text;
        text = this.TextA;
        this.TextGet(text, aa);
        Text textB;
        textB = this.TextB;

        this.TextStringGet(textB, limit.BraceRoundLite.Text);
        if (textInfra.Same(text, textB, less))
        {
            Token rightBracket;
            rightBracket = this.TokenMatchLeftBracket(this.TokenA, this.Range(this.RangeA, index + 1, end));
            if (!(rightBracket == null))
            {
                ret = rightBracket.Range.End;
            }
        }

        this.TextStringGet(textB, limit.BraceLite.Text);
        if (textInfra.Same(text, textB, less))
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

    protected virtual long BackwardSkipBracket(long index, long start)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;
        LimitList limit;
        limit = this.Limit;
        long ret;
        ret = -1;
        long t;
        t = index - 1;
        TokenToken aa;
        aa = this.TokenToken(t);

        TextLess less;
        less = this.TextLess;
        Text text;
        text = this.TextA;
        this.TextGet(text, aa);
        Text textB;
        textB = this.TextB;

        this.TextStringGet(textB, limit.BraceRoundRite.Text);
        if (textInfra.Same(text, textB, less))
        {
            Token leftBracket;
            leftBracket = this.TokenMatchRightBracket(this.TokenA, this.Range(this.RangeA, start, t));
            if (!(leftBracket == null))
            {
                ret = leftBracket.Range.Start;
            }
        }

        this.TextStringGet(textB, limit.BraceRite.Text);
        if (textInfra.Same(text, textB, less))
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
        return this.TokenMatchLeftToken(result, this.Limit.BraceLite.Text, this.Limit.BraceRite.Text, range);
    }

    protected virtual Token TokenMatchRightBrace(Token result, Range range)
    {
        return this.TokenMatchRightToken(result, this.Limit.BraceLite.Text, this.Limit.BraceRite.Text, range);
    }

    protected virtual Token TokenMatchLeftBracket(Token result, Range range)
    {
        return this.TokenMatchLeftToken(result, this.Limit.BraceRoundLite.Text, this.Limit.BraceRoundRite.Text, range);
    }

    protected virtual Token TokenMatchRightBracket(Token result, Range range)
    {
        return this.TokenMatchRightToken(result, this.Limit.BraceRoundLite.Text, this.Limit.BraceRoundRite.Text, range);
    }

    protected virtual Token TokenMatchLeftToken(Token result, String leftToken, String rightToken, Range range)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;
        long start;
        long end;
        start = range.Start;
        end = range.End;

        TextLess less;
        less = this.TextLess;
        Text text;
        text = this.TextA;
        Text textB;
        textB = this.TextB;

        long openCount;
        openCount = 1;
        long index;
        index = -1;
        long i;
        i = start;
        bool varContinue;
        varContinue = (i < end);
        while (varContinue)
        {
            TokenToken aa;
            aa = this.TokenToken(i);
            this.TextGet(text, aa);
            
            this.TextStringGet(textB, rightToken);
            if (textInfra.Same(text, textB, less))
            {
                openCount = openCount - 1;
                if (openCount == 0)
                {
                    index = i;
                    varContinue = false;
                }
            }

            this.TextStringGet(textB, leftToken);
            if (textInfra.Same(text, textB, less))
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

    protected virtual Token TokenMatchRightToken(Token result, String leftToken, String rightToken, Range range)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;
        long start;
        long end;
        start = range.Start;
        end = range.End;

        TextLess less;
        less = this.TextLess;
        Text text;
        text = this.TextA;
        Text textB;
        textB = this.TextB;

        long openCount;
        openCount = 1;
        long index;
        index = -1;
        long i;
        i = end;
        bool varContinue;
        varContinue = (i > start);
        while (varContinue)
        {
            long t;
            t = i - 1;
            TokenToken aa;
            aa = this.TokenToken(t);
            this.TextGet(text, aa);

            this.TextStringGet(textB, leftToken);
            if (textInfra.Same(text, textB, less))
            {
                openCount = openCount - 1;
                if (openCount == 0)
                {
                    index = t;
                    varContinue = false;
                }
            }

            this.TextStringGet(textB, rightToken);
            if (textInfra.Same(text, textB, less))
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