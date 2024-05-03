namespace Z.Infra.StatSourceGen;

public class Gen : Any
{
    public override bool Init()
    {
        base.Init();
        this.ToolInfra = ToolInfra.This;
        this.SourceFileName = "ToolData/Source.txt";
        this.MethodFileName = "ToolData/Method.txt";
        this.ShareVarFileName = "ToolData/ShareVar.txt";
        this.ItemListFileName = "ToolData/ItemList.txt";

        this.ClassName = "";
        this.ScopeName = "Qt";
        this.ScopeSeparator = "::";
        this.ValuePrefix = "";
        this.ValuePostfix = "";
        this.ValueOffset = "";
        this.NamePrefix = "";
        this.NamePostfix = "";
        return true;
    }

    public virtual string ClassName { get; set; }
    public virtual string ScopeName { get; set; }
    public virtual string ScopeSeparator { get; set; }
    public virtual string ValuePrefix { get; set; }
    public virtual string ValuePostfix { get; set; }
    public virtual string ValueOffset { get; set; }
    public virtual string NamePrefix { get; set; }
    public virtual string NamePostfix { get; set; }
    public virtual string SourceFileName { get; set; }
    public virtual string MethodFileName { get; set; }
    public virtual string ShareVarFileName { get; set; }
    public virtual string ItemListFileName { get; set; }
    public virtual string OutputFilePath { get; set; }
    protected virtual ToolInfra ToolInfra { get; set; }
    protected virtual Array LineArray { get; set; }
    protected virtual Table ItemTable { get; set; }

    public virtual int Execute()
    {
        this.ExecuteItemList();

        string sourceText;
        sourceText = this.ToolInfra.StorageTextRead(this.SourceFileName);

        StringBuilder sa;
        sa = new StringBuilder(sourceText);

        string methodList;
        methodList = this.GetMethodList();

        string shareVarList;
        shareVarList = this.GetShareVarList();

        sa.Replace("#ShareVarList#", shareVarList);
        sa.Replace("#MethodList#", methodList);

        string kk;
        kk = sa.ToString();

        this.OutputFilePath = this.GetOutputFilePath();

        this.ToolInfra.StorageTextWrite(this.OutputFilePath, kk);
        return 0;
    }

    protected virtual bool ExecuteItemList()
    {
        string a;
        a = this.ToolInfra.StorageTextRead(this.ItemListFileName);

        this.LineArray = this.ToolInfra.SplitLineList(a);

        StringCompare compare;
        compare = new StringCompare();
        compare.Init();
        this.ItemTable = new Table();
        this.ItemTable.Compare = compare;
        this.ItemTable.Init();

        Iter iter;
        iter = this.LineArray.IterCreate();
        this.LineArray.IterSet(iter);
        while (iter.Next())
        {
            string line;
            line = (string)iter.Value;

            Entry entry;
            entry = this.GetItemEntry(line);

            this.ItemTable.Add(entry);
        }
        return true;
    }

    protected virtual Entry GetItemEntry(string line)
    {
        Entry a;
        a = new Entry();
        a.Init();
        a.Index = line;
        a.Value = line;
        return a;
    }

    protected virtual string GetMethodList()
    {
        string methodText;
        methodText = this.ToolInfra.StorageTextRead(this.MethodFileName);

        StringBuilder sa;
        sa = new StringBuilder(methodText);
        sa.Replace("#ClassName#", this.ClassName);
        sa.Replace("#NamePrefix#", this.NamePrefix);
        sa.Replace("#NamePostfix#", this.NamePostfix);
        sa.Replace("#ScopeName#", this.ScopeName);
        sa.Replace("#ScopeSeparator#", this.ScopeSeparator);
        sa.Replace("#ValuePrefix#", this.ValuePrefix);
        sa.Replace("#ValuePostfix#", this.ValuePostfix);
        sa.Replace("#ValueOffset#", this.ValueOffset);

        string oo;
        oo = sa.ToString();

        StringBuilder sb;
        sb = new StringBuilder();

        Iter iter;
        iter = this.ItemTable.IterCreate();
        this.ItemTable.IterSet(iter);

        int i;
        i = 0;
        while (iter.Next())
        {
            string k;
            k = this.GetItemMethod(oo, iter, i);
            
            sb.Append(k);

            i = i + 1;
        }

        string ka;
        ka = sb.ToString();
        return ka;
    }






    protected virtual string GetShareVarList()
    {
        string shareVarText;

        shareVarText = this.ToolInfra.StorageTextRead(this.ShareVarFileName);



        StringBuilder sa;

        sa = new StringBuilder(shareVarText);



        sa.Replace("#ClassName#", this.ClassName);


        sa.Replace("#NamePrefix#", this.NamePrefix);


        sa.Replace("#NamePostfix#", this.NamePostfix);



        sa.Replace("#ScopeName#", this.ScopeName);


        sa.Replace("#ScopeSeparator#", this.ScopeSeparator);


        sa.Replace("#ValuePrefix#", this.ValuePrefix);


        sa.Replace("#ValuePostfix#", this.ValuePostfix);


        sa.Replace("#ValueOffset#", this.ValueOffset);





        string oo;

        oo = sa.ToString();





        StringBuilder sb;


        sb = new StringBuilder();




        Iter iter;

        iter = this.ItemTable.IterCreate();


        this.ItemTable.IterSet(iter);



        int i;

        i = 0;



        while (iter.Next())
        {
            string k;


            k = this.GetItemShareVar(oo, iter, i);



            sb.Append(k);




            i = i + 1;
        }




        string ka;

        ka = sb.ToString();



        return ka;
    }






    protected virtual string GetItemShareVar(string shareVar, Iter iter, int index)
    {
        string a;


        a = (string)iter.Index;



        string ka;

        ka = (string)iter.Value;




        string kb;


        kb = index.ToString();




        string k;


        k = shareVar;


        k = k.Replace("#ItemName#", a);


        k = k.Replace("#ItemValue#", ka);


        k = k.Replace("#ItemIndex#", kb);



        return k;
    }






    protected virtual string GetItemMethod(string method, Iter iter, int index)
    {
        string a;
            

        a = (string)iter.Index;



        string ka;

        ka = (string)iter.Value;

        


        string kb;


        kb = index.ToString();




        string k;


        k = method;


        k = k.Replace("#ItemName#", a);


        k = k.Replace("#ItemValue#", ka);


        k = k.Replace("#ItemIndex#", kb);



        return k;
    }





    protected virtual string GetOutputFilePath()
    {
        return "../../Infra/Infra/Stat_" + this.ClassName + ".cpp";
    }




    protected virtual bool GetBool(string a)
    {
        bool b;


        b = false;



        if (!(a == "false"))
        {
            b = true;
        }



        return b;
    }






    protected virtual string GetBoolString(bool a)
    {
        string u;


        u = "false";




        if (a)
        {
            u = "true";
        }




        return u;
    }





    protected virtual bool AppendIndent(StringBuilder sb, int indent)
    {
        int count;

        count = indent;



        int i;

        i = 0;


        while (i < count)
        {
            sb.Append("    ");



            i = i + 1;
        }
        

        return true;
    }
}