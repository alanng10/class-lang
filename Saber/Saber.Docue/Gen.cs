namespace Saber.Docue;

public class Gen : TextAdd
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        this.StorageInfra = StorageInfra.This;
        this.ClassInfra = ClassInfra.This;

        this.StorageComp = StorageComp.This;
        
        this.SFlagD = this.S("-d");
        return true;
    }

    public virtual String SourceFoldPath { get; set; }
    public virtual String DestFoldPath { get; set; }
    public virtual bool LinkFileName { get; set; }
    public virtual Table ModuleTable { get; set; }
    public virtual long Status { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual StorageInfra StorageInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual StorageComp StorageComp { get; set; }
    protected virtual String Ver { get; set; }
    protected virtual String ArticleFoldPath { get; set; }
    protected virtual Node ArticleRoot { get; set; }
    protected virtual String HomeTemplate { get; set; }
    protected virtual String ArticleTemplate { get; set; }
    protected virtual String SFlagD { get; set; }
    protected virtual String SBackslash { get; set; }

    public virtual bool Load()
    {
        this.HomeTemplate = this.StorageInfra.TextRead(this.S("Saber.Docue.data/home.html"));

        if (this.HomeTemplate == null)
        {
            return false;
        }

        this.ArticleTemplate = this.StorageInfra.TextRead(this.S("Saber.Docue.data/article.html"));

        if (this.ArticleTemplate == null)
        {
            return false;
        }

        return true;
    }

    public virtual bool ArgSet(Array arg)
    {
        bool baa;
        baa = (1 < arg.Count);
        if (!baa)
        {
            return false;
        }
        String aaa;
        aaa = (String)arg.GetAt(0);
        String aab;
        aab = (String)arg.GetAt(1);

        String aac;
        aac = null;
        if (2 < arg.Count)
        {
            aac = (String)arg.GetAt(2);
        }

        String sourceFold;
        sourceFold = aaa;

        String destFold;
        destFold = aab;

        bool linkFileName;
        linkFileName = true;
        if (!(aac == null))
        {
            if (this.TextSame(this.TA(aac), this.TB(this.SFlagD)))
            {
                linkFileName = false;
            }
        }

        this.SourceFoldPath = sourceFold;
        this.DestFoldPath = destFold;
        this.LinkFileName = linkFileName;
        return true;
    }

    public virtual bool Execute()
    {
        this.Status = 0;

        bool b;

        b = this.ExecuteVer();
        if (!b)
        {
            this.Status = 1000;
            return false;
        }

        b = this.ExecuteNode();
        if (!b)
        {
            this.Status = 2000;
            return false;
        }

        b = this.ExecuteVar();
        if (!b)
        {
            this.Status = 3000;
            return false;
        }

        b = this.ExecuteHome();
        if (!b)
        {
            this.Status = 4000;
            return false;
        }

        b = this.ExecuteArticle();
        if (!b)
        {
            this.Status = 5000;
            return false;
        }

        b = this.ExecuteAsset();
        if (!b)
        {
            this.Status = 6000;
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

    protected virtual bool ExecuteHome()
    {
        String combine;
        combine = this.TextInfra.PathCombine;

        String newLine;
        newLine = this.S("\n");

        String filePath;
        filePath = this.AddClear().Add(this.SourceFoldPath).Add(combine).AddS("a.md").AddResult();

        String oo;
        oo = this.StorageInfra.TextRead(filePath);

        if (oo == null)
        {
            return false;
        }

        long u;
        u = this.TextIndex(this.TA(oo), this.TB(newLine));
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
        pageRootPath = this.PageRootPath(0);

        Text k;
        k = this.TextCreate(this.HomeTemplate);
        k = this.TextPlace(k, this.TA(this.S("#PageRootPath#")), this.TB(pageRootPath));
        k = this.TextPlace(k, this.TA(this.S("#AssetVer#")), this.TB(this.Ver));
        k = this.TextPlace(k, this.TA(this.S("#HomeTitle#")), this.TB(title));
        k = this.TextPlace(k, this.TA(this.S("#HomeInner#")), this.TB(innerK));

        String a;
        a = this.StringCreate(k);

        String foldPath;
        foldPath = this.DestFoldPath;

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

    protected virtual bool ExecuteArticle()
    {
        Node root;
        root = this.ArticleRoot;

        bool b;
        b = this.ExecuteArticleNode(root, 1, this.S("."));
        if (!b)
        {
            return false;
        }
        return true;
    }

    protected virtual bool ExecuteArticleNode(Node node, long level, String path)
    {
        bool b;
        b = this.GenArticle(level, path);
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
            aa = iter.Value as Node;

            String ka;
            ka = this.AddClear().Add(path).Add(combine).Add(aa.Name).AddResult();

            b = this.ExecuteArticleNode(aa, level + 1, ka);
            if (!b)
            {
                return false;
            }
        }
        return true;
    }

    protected virtual bool GenArticle(long level, String path)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;

        String combine;
        combine = textInfra.PathCombine;

        String newLine;
        newLine = this.S("\n");

        String filePath;
        filePath = this.AddClear().Add(this.ArticleFoldPath).Add(combine).Add(path).Add(combine).AddS("a.md").AddResult();

        String oo;
        oo = this.StorageInfra.TextRead(filePath);

        if (oo == null)
        {
            return false;
        }

        long u;
        u = this.TextIndex(this.TA(oo), this.TB(newLine));
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
        k = this.TextCreate(this.ArticleTemplate);
        k = this.TextPlace(k, this.TA(this.S("#PageRootPath#")), this.TB(pageRootPath));
        k = this.TextPlace(k, this.TA(this.S("#AssetVer#")), this.TB(this.Ver));
        k = this.TextPlace(k, this.TA(this.S("#ArticleTitle#")), this.TB(title));
        k = this.TextPlace(k, this.TA(this.S("#ArticleInner#")), this.TB(innerK));
        k = this.TextPlace(k, this.TA(this.S("#ArticlePath#")), this.TB(path));

        String a;
        a = this.StringCreate(k);

        Text kaa;
        kaa = this.TextCreate(path);
        kaa = this.TextAlphaSite(kaa);

        String pathKk;
        pathKk = this.StringCreate(kaa);

        String foldPath;
        foldPath = this.AddClear().Add(this.DestFoldPath).Add(combine).AddS("article").Add(combine).Add(pathKk).AddResult();

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

        this.ExecuteNaviNode(0, this.ArticleRoot);

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
        String braceLite;
        braceLite = this.S("{");
        String braceRite;
        braceRite = this.S("}");
        String space;
        space = this.S(" ");
        String quote;
        quote = this.S("\"");

        long indent;
        indent = level * 2;

        this.AddIndent(indent);
        this.Add(braceLite);
        this.Add(newLine);

        this.AddIndent(indent + 1);
        this.Add(quote);
        this.AddS("Name");
        this.Add(quote);
        this.Add(colon);
        this.Add(space);
        this.Add(quote);
        this.Add(a.Name);
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
        this.Add(braceLite);
        this.Add(newLine);

        Iter iter;
        iter = a.Child.IterCreate();
        a.Child.IterSet(iter);
        while (iter.Next())
        {
            Node aa;
            aa = iter.Value as Node;

            this.AddIndent(indent + 2);
            this.Add(quote);
            this.Add(aa.Name);
            this.Add(quote);
            this.Add(colon);
            this.Add(newLine);

            this.ExecuteNaviNode(level + 1, aa);

            this.Add(comma);
            this.Add(newLine);
        }

        this.AddIndent(indent + 1);
        this.Add(braceRite);
        this.Add(newLine);

        this.AddIndent(indent);
        this.Add(braceRite);
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
        aa = this.AddClear().AddS("Saber.Docue.data").Add(combine).Add(fileName).AddResult();

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
        this.ArticleFoldPath = this.AddClear().Add(this.SourceFoldPath).Add(this.TextInfra.PathCombine).AddS("Article").AddResult();

        this.ArticleRoot = this.CreateNode(this.ArticleFoldPath, this.S("Article"));
        return true;
    }

    protected virtual Node CreateNode(String foldPath, String name)
    {
        if (!(this.TextIndex(this.TA(name), this.TB(this.S("\\"))) == -1))
        {
            return null;
        }
        if (!(this.TextIndex(this.TA(name), this.TB(this.S("\'"))) == -1))
        {
            return null;
        }
        if (!(this.TextIndex(this.TA(name), this.TB(this.S("\""))) == -1))
        {
            return null;
        }

        Node a;
        a = new Node();
        a.Init();
        a.Name = name;

        Table child;
        child = this.ChildTable(foldPath);

        Iter iter;
        iter = child.IterCreate();
        child.IterSet(iter);

        while (iter.Next())
        {
            String kk;
            kk = iter.Index as String;

            String ka;
            ka = this.AddClear().Add(foldPath).Add(this.TextInfra.PathCombine).Add(kk).AddResult();

            Node aa;
            aa = this.CreateNode(ka, kk);

            if (aa == null)
            {
                return null;
            }

            child.Set(kk, aa);
        }

        a.Child = child;

        return a;
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
            StorageEntry fold;
            fold = array.GetAt(i) as StorageEntry;

            String name;
            name = fold.Name;

            listInfra.TableAdd(table, name, name);

            i = i + 1;
        }
        return table;
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
        a = this.StorageComp.EntryList(foldPath, true, false);
        return a;
    }
}