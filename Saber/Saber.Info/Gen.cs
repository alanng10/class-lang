namespace Saber.Info;

public class Gen : ClassBase
{
    public override bool Init()
    {
        base.Init();
        this.StorageInfra = StorageInfra.This;

        this.StorageComp = StorageComp.This;
        return true;
    }

    public virtual String SourceFoldPath { get; set; }
    public virtual String DestFoldPath { get; set; }
    public virtual bool LinkFileName { get; set; }
    public virtual Table ModuleTable { get; set; }
    protected virtual StorageInfra StorageInfra { get; set; }
    protected virtual String Ver { get; set; }
    protected virtual Node Root { get; set; }
    protected virtual String PageTemplate { get; set; }
    private StorageComp StorageComp { get; set; }

    public virtual bool Load()
    {
        String k;
        k = this.StorageInfra.TextRead(this.S("Class.Info.data/a.html"));

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
        aa = time.TotalTick;

        time.Final();

        String o;
        o = this.StringIntHex(aa);

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
        oo = this.StorageInfra.TextRead(filePath);

        if (oo == null)
        {
            return false;
        }

        Text o;
        o = textInfra.TextCreateStringData(oo, null);

        Text oa;
        oa = textInfra.TextCreateStringData(newLine, null);

        long u;
        u = this.TextIndex(o, oa);
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

        Text kka;
        kka = this.TextCreate(inner);

        kka = this.TextPlace(kka, limit, join);
        
        String innerK;
        innerK = this.StringCreate(kka);

        String pageRootPath;
        pageRootPath = this.PageRootPath(level);
        
        Text k;
        k = this.TextCreate(this.PageTemplate);
        k = this.Place(k, "#AssetVer#", this.Ver);
        k = this.Place(k, "#ArticleTitle#", title);
        k = this.Place(k, "#ArticleInner#", innerK);
        k = this.Place(k, "#PageRootPath#", pageRootPath);
        k = this.Place(k, "#PagePath#", pagePath);

        String a;
        a = this.StringCreate(k);

        Text kaa;
        kaa = this.TextCreate(path);
        kaa = this.TextAlphaSite(kaa);

        String pathKk;
        pathKk = this.StringCreate(kaa);

        String foldPath;
        foldPath = this.AddClear().Add(this.DestFoldPath).Add(combine).Add(pathKk).AddResult();

        bool b;

        b = this.StorageComp.FoldCreate(foldPath);
        if (!b)
        {
            return false;
        }

        String outFilePath;
        outFilePath = this.AddClear().Add(foldPath).Add(combine).AddS("index.html").AddResult();

        b = this.StorageInfra.TextWrite(outFilePath, a);
        if (!b)
        {
            return false;
        }

        return true;
    }

    protected virtual bool ExecuteVar()
    {
        String newLine;
        newLine = this.S("\n");
        String semicolon;
        semicolon = this.S(";");

        this.AddClear();

        String ka;
        ka = this.BoolValueString(this.LinkFileName);

        this.AddS("var LinkFileName;\n");
        this.AddS("LinkFileName = ");
        this.Add(ka);
        this.Add(semicolon);
        this.Add(newLine);

        String a;
        a = this.AddResult();

        String combine;
        combine = this.TextInfra.PathCombine;

        String outFilePath;
        outFilePath = this.AddClear().Add(this.DestFoldPath).Add(combine).AddS("var.js").AddResult();

        bool b;
        b = this.StorageInfra.TextWrite(outFilePath, a);
        if (!b)
        {
            return false;
        }

        this.AddClear();
        this.AddS("var NaviTree;\n");
        this.AddS("NaviTree =\n");

        this.ExecuteNaviNode(0, this.Root);

        this.Add(semicolon);
        this.Add(newLine);

        a = this.AddResult();

        outFilePath = this.AddClear().Add(this.DestFoldPath).Add(combine).AddS("articlevar.js").AddResult();

        b = this.StorageInfra.TextWrite(outFilePath, a);
        if (!b)
        {
            return false;
        }

        return true;
    }

    protected virtual bool ExecuteNaviNode(int level, Node a)
    {
        String newLine;
        newLine = this.S("\n");
        String colon;
        colon = this.S(":");
        String comma;
        comma = this.S(",");
        String leftBrace;
        leftBrace = this.S("{");
        String rightBrace;
        rightBrace = this.S("}");
        String space;
        space = this.S(" ");
        String quote;
        quote = this.S("\"");

        long indent;
        indent = level * 2;

        this.AddIndent(indent);
        this.Add(leftBrace);
        this.Add(newLine);

        this.AddIndent(indent + 1);
        this.Add(quote);
        this.AddS("Name");
        this.Add(quote);
        this.Add(colon);
        this.Add(space);
        this.Add(quote);
        this.Add(a.NameString);
        this.Add(quote);
        this.Add(comma);
        this.Add(newLine);

        this.AddIndent(indent + 1);
        this.Add(quote);
        this.AddS("Child");
        this.Add(quote);
        this.Add(colon);
        this.Add(newLine);

        this.AddIndent(indent + 1);
        this.Add(leftBrace);
        this.Add(newLine);

        Iter iter;
        iter = a.Child.IterCreate();
        a.Child.IterSet(iter);
        while (iter.Next())
        {
            Node aa;
            aa = (Node)iter.Value;

            this.AddIndent(indent + 2);
            this.Add(quote);
            this.Add(aa.NameString);
            this.Add(quote);
            this.Add(colon);
            this.Add(newLine);

            this.ExecuteNaviNode(level + 1, aa);

            this.Add(comma);
            this.Add(newLine);
        }

        this.AddIndent(indent + 1);
        this.Add(rightBrace);
        this.Add(newLine);

        this.AddIndent(indent);
        this.Add(rightBrace);
        return true;
    }

    protected virtual bool ExecuteAsset()
    {
        bool b;
        b = this.CopyAsset(this.S("style.css"));
        if (!b)
        {
            return false;
        }
        b = this.CopyAsset(this.S("script.js"));
        if (!b)
        {
            return false;
        }
        return true;
    }

    protected virtual bool CopyAsset(String fileName)
    {
        String combine;
        combine = this.TextInfra.PathCombine;

        String aa;
        aa = this.AddClear().AddS("Class.Info.data").Add(combine).Add(fileName).AddResult();

        String ab;
        ab = this.AddClear().Add(this.DestFoldPath).Add(combine).Add(fileName).AddResult();

        bool b;
        b = this.StorageComp.FileCopy(aa, ab);
        if (!b)
        {
            return false;
        }
        return true;
    }

    protected virtual String PageRootPath(long level)
    {
        String ka;
        ka = this.S("/..");

        this.AddClear();

        this.AddS(".");

        long count;
        count = level;
        long i;
        i = 0;
        while (i < count)
        {
            this.Add(ka);

            i = i + 1;
        }

        String a;
        a = this.AddResult();
        return a;
    }

    protected virtual bool ExecuteNode()
    {
        String nodePath;
        nodePath = this.SourceFoldPath;

        Node a;
        a = new Node();
        a.Init();
        a.Name = this.TextInfra.Zero;
        a.NameString = this.TextInfra.Zero;

        a.Child = this.CreateChild(nodePath);

        this.Root = a;
        return true;
    }

    protected virtual Node CreateNode(String foldPath, String name)
    {
        Node a;
        a = new Node();
        a.Init();
        a.Name = name;
        
        this.AddClear();

        this.AddNodeNameValue(name);
        
        String aa;
        aa = this.AddResult();

        a.NameString = aa;

        String nodePath;
        nodePath = this.AddClear().Add(foldPath).Add(this.TextInfra.PathCombine).Add(name).AddResult();

        a.Child = this.CreateChild(nodePath);

        return a;
    }

    protected virtual Table CreateChild(String nodePath)
    {
        Table child;
        child = this.ChildTable(nodePath);

        Iter iter;
        iter = child.IterCreate();
        child.IterSet(iter);

        while (iter.Next())
        {
            String kk;
            kk = (String)iter.Index;

            Node aa;
            aa = this.CreateNode(nodePath, kk);

            child.Set(kk, aa);
        }

        return child;
    }

    protected virtual Table ChildTable(String foldPath)
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;

        Table table;
        table = this.ClassInfra.TableCreateStringLess();

        Array array;
        array = this.FoldList(foldPath);

        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            String name;
            name = (String)array.GetAt(i);

            listInfra.TableAdd(table, name, null);

            i = i + 1;
        }
        return table;
    }

    protected virtual bool AddNodeNameValue(String name)
    {
        String escapeBackSlash;
        escapeBackSlash = this.S("\\\\");
        String escapeQuote;
        escapeQuote = this.S("\\\"");
        String escapeSingleQuote;
        escapeSingleQuote = this.S("\\\'");

        long count;
        count = this.StringComp.Count(name);
        long i;
        i = 0;
        while (i < count)
        {
            long oc;
            oc = this.StringComp.Char(name, i);

            bool b;
            b = false;
            if (!b)
            {
                if (oc == '\\')
                {
                    this.Add(escapeBackSlash);
                    b = true;
                }
            }
            if (!b)
            {
                if (oc == '\"')
                {
                    this.Add(escapeQuote);
                    b = true;
                }
            }
            if (!b)
            {
                if (oc == '\'')
                {
                    this.Add(escapeSingleQuote);
                    b = true;
                }
            }
            if (!b)
            {
                this.AddChar(oc);
            }

            i = i + 1;
        }
        return true;
    }

    protected virtual String BoolValueString(bool o)
    {
        String k;
        k = null;
        if (o)
        {
            k = this.TextInfra.BoolTrueString;
        }
        if (!o)
        {
            k = this.TextInfra.BoolFalseString;
        }
        return k;
    }

    protected virtual Array FoldList(String foldPath)
    {
        Array a;
        a = this.StorageComp.FoldList(foldPath);
        return a;
    }
}