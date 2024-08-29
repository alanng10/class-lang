namespace Class.Info;

public class Gen : Any
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.ListInfra = ListInfra.This;
        this.TextInfra = TextInfra.This;
        this.StorageInfra = StorageInfra.This;
        this.ClassInfra = ClassInfra.This;
        this.StringComp = StringComp.This;
        this.TextStringValue = TextStringValue.This;

        this.StorageArrange = StorageArrange.This;

        this.StringJoin = new StringJoin();
        this.StringJoin.Init();

        this.CharLess = new LessInt();
        this.CharLess.Init();
        this.CharForm = new CharForm();
        this.CharForm.Init();
        this.TextLess = new TextLess();
        this.TextLess.CharLess = this.CharLess;
        this.TextLess.LiteCharForm = this.CharForm;
        this.TextLess.RiteCharForm = this.CharForm;
        this.TextLess.Init();

        this.Range = new Range();
        this.Range.Init();
        return true;
    }

    public virtual String SourceFoldPath { get; set; }
    public virtual String DestFoldPath { get; set; }
    public virtual bool LinkFileName { get; set; }
    public virtual Table ModuleTable { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual StorageInfra StorageInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual StringComp StringComp { get; set; }
    protected virtual TextStringValue TextStringValue { get; set; }
    protected virtual StringJoin StringJoin { get; set; }
    protected virtual TextLess TextLess { get; set; }
    protected virtual LessInt CharLess { get; set; }
    protected virtual CharForm CharForm { get; set; }
    protected virtual Range Range { get; set; }
    protected virtual String Ver { get; set; }
    protected virtual Node Root { get; set; }
    protected virtual String PageTemplate { get; set; }
    private StorageArrange StorageArrange { get; set; }

    public virtual bool Load()
    {
        String k;
        k = this.StorageInfra.TextReadAny(this.S("Class.Info.data/a.html"), true);

        if (k == null)
        {
            return false;
        }

        this.PageTemplate = k;
        return true;
    }

    public virtual bool Execute()
    {
        bool b;

        b = this.ExecuteVer();
        if (!b)
        {
            return false;
        }

        b = this.ExecuteNode();
        if (!b)
        {
            return false;
        }

        b = this.ExecuteVar();
        if (!b)
        {
            return false;
        }

        b = this.ExecuteArticle();
        if (!b)
        {
            return false;
        }

        b = this.ExecuteAsset();
        if (!b)
        {
            return false;
        }

        return true;
    }

    protected virtual bool ExecuteVer()
    {
        Time time;
        time = new Time();
        time.Init();

        time.This();

        long aa;
        aa = time.TotalMillisec;

        time.Final();

        CharForm charForm;
        charForm = new CharForm();
        charForm.Init();

        Format format;
        format = new Format();
        format.Init();
        format.CharForm = charForm;

        FormatArg arg;
        arg = new FormatArg();
        arg.Init();
        arg.Kind = 1;
        arg.Value.Int = aa;
        arg.Base = 16;
        arg.Case = 0;
        arg.AlignLeft = false;
        arg.FieldWidth = 15;
        arg.MaxWidth = 15;
        arg.FillChar = '0';

        format.ExecuteArgCount(arg);

        Text a;
        a = this.TextInfra.TextCreate(arg.Count);

        format.ExecuteArgResult(arg, a);

        String o;
        o = this.TextInfra.StringCreate(a);

        this.Ver = o;
        return true;
    }

    protected virtual bool ExecuteArticle()
    {
        Node root;
        root = this.Root;

        bool b;
        b = this.ExecuteArticleNode(root, 0, this.S("."), this.S("."));
        if (!b)
        {
            return false;
        }
        return true;
    }

    protected virtual bool ExecuteArticleNode(Node node, long level, String path, String pagePath)
    {
        bool b;
        b = this.GenArticle(level, path, pagePath);
        if (!b)
        {
            return false;
        }

        String combine;
        combine = this.TextInfra.PathCombine;

        Iter iter;
        iter = node.Child.IterCreate();
        node.Child.IterSet(iter);

        while (iter.Next())
        {
            Node aa;
            aa = (Node)iter.Value;
            
            String ka;
            ka = this.AddClear().Add(path).Add(combine).Add(aa.Name).AddResult();
            
            String kk;
            kk = this.AddClear().Add(pagePath).Add(combine).Add(aa.NameString).AddResult();

            b = this.ExecuteArticleNode(aa, level + 1, ka, kk);
            if (!b)
            {
                return false;
            }
        }
        return true;
    }

    protected virtual bool GenArticle(long level, String path, String pagePath)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;

        String combine;
        combine = textInfra.PathCombine;

        String newLine;
        newLine = this.S("\n");

        String filePath;
        filePath = this.AddClear().Add(this.SourceFoldPath).Add(combine).Add(path).Add(combine).AddS("a.md").AddResult();

        String oo;
        oo = this.StorageInfra.TextReadAny(filePath, true);

        if (oo == null)
        {
            return false;
        }

        Text o;
        o = textInfra.TextCreateStringData(oo, null);

        Text oa;
        oa = textInfra.TextCreateStringData(newLine, null);

        long u;
        u = this.TextInfra.Index(o, oa, this.TextLess);
        if (u < 0)
        {
            return false;
        }

        long kk;
        kk = u;
        long ka;
        ka = 2;
        long count;
        count = kk - ka;
        
        String title;
        title = this.StringCreateRange(oo, ka, count);

        String inner;
        inner = this.StringCreateIndex(oo, kk + 1);

        String kb;
        kb = this.AddClear().Add(newLine).Add(newLine).AddResult();

        String kc;
        kc = this.S("<br />");

        String kd;
        kd = this.AddClear().Add(kc).Add(kc).Add(newLine).AddResult();

        Text limit;
        limit = this.TextCreate(kb);

        Text join;
        join = this.TextCreate(kd);

        Text aa;
        aa = this.TextCreate(inner);

        aa = this.TextReplace(aa, limit, join);
        
        String pageRootPath;
        pageRootPath = this.PageRootPath(level);
        
        Text a;
        a = this.TextCreate(this.PageTemplate);
        a = this.Replace(a, "#AssetVer#", this.Ver);
        a = this.Replace(a, "#ArticleTitle#", title);
        a = this.Replace(a, "#ArticleInner#", inner);
        a = this.Replace(a, "#PageRootPath#", pageRootPath);
        a = this.Replace(a, "#PagePath#", pagePath);

        string pathKk;
        pathKk = path.ToLower();

        string foldPath;
        foldPath = this.DestFoldPath + combine + pathKk;

        bool b;

        b = this.StorageArrange.FoldCreate(foldPath);
        if (!b)
        {
            return false;
        }

        string outFilePath;
        outFilePath = foldPath + combine + "index.html";

        b = this.StorageInfra.TextWriteAny(outFilePath, a, true);
        if (!b)
        {
            return false;
        }

        return true;
    }

    protected virtual bool ExecuteVar()
    {
        StorageInfra storageInfra;
        storageInfra = this.StorageInfra;

        string newLine;
        newLine = "\n";
        string semicolon;
        semicolon = ";";

        StringJoin o;
        o = this.StringJoin;
        o.Clear();

        string ka;
        ka = this.BoolValueString(this.LinkFileName);

        this.Append("var LinkFileName;\n");
        this.Append("LinkFileName = ");
        this.Append(ka);
        this.Append(semicolon);
        this.Append(newLine);

        string a;
        a = o.Result();

        string combine;
        combine = this.InfraInfra.PathCombine;

        string outFilePath;
        outFilePath = this.DestFoldPath + combine + "var.js";

        bool b;
        b = storageInfra.TextWriteAny(outFilePath, a, true);
        if (!b)
        {
            return false;
        }

        o.Clear();
        this.Append("var NaviTree;\n");
        this.Append("NaviTree =\n");

        this.ExecuteNaviNode(0, this.Root);

        this.Append(semicolon);
        this.Append(newLine);

        a = o.Result();

        outFilePath = this.DestFoldPath + combine + "articlevar.js";

        b = storageInfra.TextWriteAny(outFilePath, a, true);
        if (!b)
        {
            return false;
        }

        return true;
    }

    protected virtual bool ExecuteNaviNode(int level, Node a)
    {
        string newLine;
        newLine = "\n";
        string colon;
        colon = ":";
        string comma;
        comma = ",";
        string leftBrace;
        leftBrace = "{";
        string rightBrace;
        rightBrace = "}";
        string space;
        space = " ";
        string quote;
        quote = "\"";

        StringJoin o;
        o = this.StringJoin;

        int indent;
        indent = level * 2;

        this.AppendIndent(indent);
        this.Append(leftBrace);
        this.Append(newLine);

        this.AppendIndent(indent + 1);
        this.Append(quote);
        this.Append("Name");
        this.Append(quote);
        this.Append(colon);
        this.Append(space);
        this.Append(quote);
        this.Append(a.NameString);
        this.Append(quote);
        this.Append(comma);
        this.Append(newLine);

        this.AppendIndent(indent + 1);
        this.Append(quote);
        this.Append("Child");
        this.Append(quote);
        this.Append(colon);
        this.Append(newLine);

        this.AppendIndent(indent + 1);
        this.Append(leftBrace);
        this.Append(newLine);

        Iter iter;
        iter = a.Child.IterCreate();
        a.Child.IterSet(iter);
        while (iter.Next())
        {
            Node aa;
            aa = (Node)iter.Value;

            this.AppendIndent(indent + 2);
            this.Append(quote);
            this.Append(aa.NameString);
            this.Append(quote);
            this.Append(colon);
            this.Append(newLine);

            this.ExecuteNaviNode(level + 1, aa);

            this.Append(comma);
            this.Append(newLine);
        }

        this.AppendIndent(indent + 1);
        this.Append(rightBrace);
        this.Append(newLine);

        this.AppendIndent(indent);
        this.Append(rightBrace);
        return true;
    }

    protected virtual bool ExecuteAsset()
    {
        bool b;
        b = this.CopyAsset("style.css");
        if (!b)
        {
            return false;
        }
        b = this.CopyAsset("script.js");
        if (!b)
        {
            return false;
        }
        return true;
    }

    protected virtual bool CopyAsset(string fileName)
    {
        string combine;
        combine = this.InfraInfra.PathCombine;

        string aa;
        aa = "Class.Info.data" + combine + fileName;

        string ab;
        ab = this.DestFoldPath + combine + fileName;

        bool b;
        b = this.StorageArrange.FileCopy(aa, ab);
        if (!b)
        {
            return false;
        }
        return true;
    }

    protected virtual String PageRootPath(long level)
    {
        this.AddClear();

        this.AddS(".");

        long count;
        count = level;
        long i;
        i = 0;
        while (i < count)
        {
            this.AddS("/..");

            i = i + 1;
        }

        String a;
        a = this.AddResult();
        return a;
    }

    protected virtual bool ExecuteNode()
    {
        string nodePath;
        nodePath = this.SourceFoldPath;

        Node a;
        a = new Node();
        a.Init();
        a.Name = "";
        a.NameString = "";

        a.Child = this.CreateChild(nodePath);

        this.Root = a;
        return true;
    }

    protected virtual Node CreateNode(string foldPath, string name)
    {
        Node a;
        a = new Node();
        a.Init();
        a.Name = name;
        
        StringJoin o;
        o = this.StringJoin;
        
        o.Clear();
        this.AppendNodeNameValue(name);
        
        string aa;
        aa = o.Result();

        a.NameString = aa;

        string nodePath;
        nodePath = foldPath + this.InfraInfra.PathCombine + name;

        a.Child = this.CreateChild(nodePath);

        return a;
    }

    protected virtual Table CreateChild(string nodePath)
    {
        Table child;
        child = this.ChildTable(nodePath);

        Iter iter;
        iter = child.IterCreate();
        child.IterSet(iter);

        while (iter.Next())
        {
            string kk;
            kk = (string)iter.Index;

            Node aa;
            aa = this.CreateNode(nodePath, kk);

            child.Set(kk, aa);
        }

        return child;
    }

    protected virtual Table ChildTable(string foldPath)
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;

        Table table;
        table = this.ClassInfra.TableCreateStringLess();

        Array array;
        array = this.FoldList(foldPath);

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            string name;
            name = (string)array.GetAt(i);

            listInfra.TableAdd(table, name, null);

            i = i + 1;
        }
        return table;
    }

    protected virtual bool AppendNodeNameValue(string name)
    {
        StringJoin o;
        o = this.StringJoin;

        int count;
        count = name.Length;
        int i;
        i = 0;
        while (i < count)
        {
            char oc;
            oc = name[i];

            bool b;
            b = false;
            if (!b)
            {
                if (oc == '\\')
                {
                    this.Append("\\\\");
                    b = true;
                }
            }
            if (!b)
            {
                if (oc == '\"')
                {
                    this.Append("\\\"");
                    b = true;
                }
            }
            if (!b)
            {
                if (oc == '\'')
                {
                    this.Append("\\\'");
                    b = true;
                }
            }
            if (!b)
            {
                o.Execute(oc);
            }

            i = i + 1;
        }
        return true;
    }

    protected virtual string BoolValueString(bool o)
    {
        string k;
        k = null;
        if (o)
        {
            k = "true";
        }
        if (!o)
        {
            k = "false";
        }
        return k;
    }

    protected virtual bool AppendIndent(int count)
    {
        int i;
        i = 0;
        while (i < count)
        {
            this.Append("    ");
            i = i + 1;
        }
        return true;
    }

    protected virtual bool Append(string text)
    {
        this.InfraInfra.StringJoinString(this.StringJoin, text);
        return true;
    }

    protected virtual Array FoldList(string foldPath)
    {
        string[] u;
        u = Directory.GetDirectories(foldPath);

        int count;
        count = u.Length;
        int i;
        i = 0;
        while (i < count)
        {
            string path;
            path = u[i];

            string name;
            name = Path.GetFileName(path);

            u[i] = name;
            i = i + 1;
        }

        Array array;
        array = this.ListInfra.ArrayCreate(count);

        i = 0;
        while (i < count)
        {
            string k;
            k = u[i];

            array.SetAt(i, k);
            i = i + 1;
        }

        Range range;
        range = new Range();
        range.Init();
        range.Count = count;

        StringLess less;
        less = this.InfraInfra.StringLessCreate();

        array.Sort(range, less);

        return array;
    }

    protected virtual Text Replace(Text text, string limit, String join)
    {
        return this.TextReplace(text, this.TextCreate(this.S(limit)), this.TextCreate(join));
    }

    protected virtual Text TextCreate(String o)
    {
        return this.TextInfra.TextCreateStringData(o, null);
    }

    protected virtual Text TextReplace(Text text, Text limit, Text join)
    {
        return this.TextInfra.Replace(text, limit, join, this.TextLess);
    }

    protected virtual long StringCount(String o)
    {
        return this.StringComp.Count(o);
    }

    protected virtual String StringCreateRange(String o, long index, long count)
    {
        this.Range.Index = index;
        this.Range.Count = count;

        return this.StringComp.CreateString(o, this.Range);
    }

    protected virtual String StringCreateIndex(String o, long index)
    {
        long count;
        count = this.StringCount(o) - index;

        return this.StringCreateRange(o, index, count);
    }

    protected virtual Gen Add(String a)
    {
        this.InfraInfra.AddString(this.StringJoin, a);
        return this;
    }

    protected virtual Gen AddS(string o)
    {
        return this.Add(this.S(o));
    }

    protected virtual Gen AddClear()
    {
        this.StringJoin.Clear();
        return this;
    }

    protected virtual String AddResult()
    {
        return this.StringJoin.Result();
    }

    protected virtual String S(string o)
    {
        return this.TextStringValue.Execute(o);
    }
}