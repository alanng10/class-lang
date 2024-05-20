namespace Class.Doc;

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

        this.StorageArrange = StorageArrange.This;

        this.StringJoin = new StringJoin();
        this.StringJoin.Init();

        this.CharCompare = new IntCompare();
        this.CharCompare.Init();
        this.TextCompare = new TextCompare();
        this.TextCompare.CharCompare = this.CharCompare;
        this.TextCompare.Init();

        this.InitTemplate();
        return true;
    }

    public virtual string SourceFoldPath { get; set; }
    public virtual string DestFoldPath { get; set; }
    public virtual bool LinkFileName { get; set; }
    public virtual Table ModuleTable { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual StorageInfra StorageInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual StorageArrange StorageArrange { get; set; }
    protected virtual StringJoin StringJoin { get; set; }
    protected virtual TextCompare TextCompare { get; set; }
    protected virtual IntCompare CharCompare { get; set; }
    protected virtual string Ver { get; set; }
    protected virtual Node Root { get; set; }
    protected virtual string PageTemplate { get; set; }

    protected virtual bool InitTemplate()
    {
        this.PageTemplate = this.StorageInfra.TextRead("Class.Doc.data/a.html");
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

        time.Current();

        Time timeA;
        timeA = new Time();
        timeA.Init();

        long aa;
        aa = timeA.MillisecondTo(time);

        timeA.Final();
        time.Final();

        Format format;
        format = new Format();
        format.Init();

        FormatArg arg;
        arg = new FormatArg();
        arg.Init();
        arg.Kind = 1;
        arg.ValueInt = aa;
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

        string o;
        o = this.TextInfra.StringCreate(a);

        this.Ver = o;
        return true;
    }

    protected virtual bool ExecuteArticle()
    {
        Node root;
        root = this.Root;

        bool b;
        b = this.ExecuteArticleNode(root, 0, ".");
        if (!b)
        {
            return false;
        }
        return true;
    }

    protected virtual bool ExecuteArticleNode(Node node, int level, string path)
    {
        bool b;
        b = this.GenArticle(level, path);
        if (!b)
        {
            return false;
        }

        string combine;
        combine = this.InfraInfra.PathCombine;

        Iter iter;
        iter = node.Child.IterCreate();
        node.Child.IterSet(iter);

        while (iter.Next())
        {
            string name;
            name = (string)iter.Index;

            Node aa;
            aa = (Node)iter.Value;
            
            string ka;
            ka = path + combine + name;

            b = this.ExecuteArticleNode(aa, level + 1, ka);
            if (!b)
            {
                return false;
            }
        }
        return true;
    }

    protected virtual bool GenArticle(int level, string path)
    {
        InfraInfra infraInfra;
        infraInfra = this.InfraInfra;

        string combine;
        combine = infraInfra.PathCombine;

        string newLine;
        newLine = "\n";

        string filePath;
        filePath = this.SourceFoldPath + combine + "Article" + combine + path + combine + "a.md";

        string oo;
        oo = this.StorageInfra.TextRead(filePath);

        if (oo == null)
        {
            return false;
        }

        TextInfra textInfra;
        textInfra = this.TextInfra;

        Text o;
        o = textInfra.TextCreateStringData(oo, null);

        Text oa;
        oa = textInfra.TextCreateStringData(newLine, null);

        int u;
        u = this.TextInfra.Index(o, oa, this.TextCompare);
        if (u < 0)
        {
            return false;
        }

        int kk;
        kk = u;
        int ka;
        ka = 2;
        int count;
        count = kk - ka;
        
        string title;
        title = oo.Substring(ka, count);

        string inner;
        inner = oo.Substring(kk + 1);

        string kb;
        kb = newLine + newLine;

        string kc;
        kc = "<br />";

        string kd;
        kd = kc + kc + newLine;

        inner = inner.Replace(kb, kd);
        
        string pageRootPath;
        pageRootPath = this.PageRootPath(level);
        
        string a;
        a = this.PageTemplate;
        a = a.Replace("#AssetVer#", this.Ver);
        a = a.Replace("#ArticleTitle#", title);
        a = a.Replace("#ArticleInner#", inner);
        a = a.Replace("#PageRootPath#", pageRootPath);

        string foldPath;
        foldPath = this.DestFoldPath + combine + path;

        bool b;

        b = this.StorageArrange.FoldCreate(foldPath);
        if (!b)
        {
            return false;
        }

        string outFilePath;
        outFilePath = foldPath + combine + "index.html";

        b = this.StorageInfra.TextWrite(outFilePath, a);
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

        StringJoin o;
        o = this.StringJoin;
        o.Clear();

        string ka;
        ka = this.BoolValueString(this.LinkFileName);

        o.Append("var LinkFileName;\n");
        o.Append("LinkFileName = " + ka + ";\n");

        string a;
        a = o.Result();

        string combine;
        combine = this.InfraInfra.PathCombine;

        string outFilePath;
        outFilePath = this.DestFoldPath + combine + "var.js";

        bool b;
        b = storageInfra.TextWrite(outFilePath, a);
        if (!b)
        {
            return false;
        }

        o.Clear();
        o.Append("var NaviTree;\n");
        o.Append("NaviTree =\n");

        string newLine;
        newLine = "\n";
        string semicolon;
        semicolon = ";";

        this.ExecuteNaviNode(0, this.Root);
        
        o.Append(semicolon);
        o.Append(newLine);

        a = o.Result();

        outFilePath = this.DestFoldPath + combine + "articlevar.js";

        b = storageInfra.TextWrite(outFilePath, a);
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
        o.Append(leftBrace);
        o.Append(newLine);

        this.AppendIndent(indent + 1);
        o.Append(quote);
        o.Append("Name");
        o.Append(quote);
        o.Append(colon);
        o.Append(space);
        o.Append(quote);
        o.Append(a.Name);
        o.Append(quote);
        o.Append(comma);
        o.Append(newLine);

        this.AppendIndent(indent + 1);
        o.Append(quote);
        o.Append("Child");
        o.Append(quote);
        o.Append(colon);
        o.Append(newLine);

        this.AppendIndent(indent + 1);
        o.Append(leftBrace);
        o.Append(newLine);

        Iter iter;
        iter = a.Child.IterCreate();
        a.Child.IterSet(iter);
        while (iter.Next())
        {
            Node aa;
            aa = (Node)iter.Value;

            this.AppendIndent(indent + 2);
            o.Append(quote);
            o.Append(aa.Name);
            o.Append(quote);
            o.Append(colon);
            o.Append(newLine);

            this.ExecuteNaviNode(level + 1, aa);

            o.Append(comma);
            o.Append(newLine);
        }

        this.AppendIndent(indent + 1);
        o.Append(rightBrace);
        o.Append(newLine);

        this.AppendIndent(indent);
        o.Append(rightBrace);
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
        aa = "Class.Doc.data" + combine + fileName;

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

    protected virtual string PageRootPath(int level)
    {
        StringJoin o;
        o = this.StringJoin;
        o.Clear();

        o.Append(".");

        int count;
        count = level;
        int i;
        i = 0;
        while (i < count)
        {
            o.Append("/..");

            i = i + 1;
        }

        string a;
        a = o.Result();
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
        table = this.ClassInfra.TableCreateStringCompare();

        Array array;
        array = this.FoldList(foldPath);

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            string name;
            name = (string)array.Get(i);

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
                    o.Append("\\\\");
                    b = true;
                }
            }
            if (!b)
            {
                if (oc == '\"')
                {
                    o.Append("\\\"");
                    b = true;
                }
            }
            if (!b)
            {
                if (oc == '\'')
                {
                    o.Append("\\\'");
                    b = true;
                }
            }
            if (!b)
            {
                o.AppendChar(oc);
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
        StringJoin o;
        o = this.StringJoin;

        int i;
        i = 0;
        while (i < count)
        {
            o.Append("    ");
            i = i + 1;
        }
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

            array.Set(i, k);
            i = i + 1;
        }

        Range range;
        range = new Range();
        range.Init();
        range.Count = count;

        StringCompare compare;
        compare = new StringCompare();
        compare.Init();

        array.Sort(range, compare);

        return array;
    }
}