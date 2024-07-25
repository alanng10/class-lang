namespace Z.Tool.PrudateGen;

public class MathAdd : Any
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        this.ToolInfra = ToolInfra.This;
        return true;
    }

    public virtual ReadResult ReadResult { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual ToolInfra ToolInfra { get; set; }
    protected virtual List List { get; set; }
    protected virtual Array TrigoList { get; set; }
    protected virtual Array LineList { get; set; }

    public virtual bool Execute()
    {
        ToolInfra toolInfra;
        toolInfra = this.ToolInfra;

        string ka;
        ka = toolInfra.StorageTextRead("ToolData/Math/TrigoList.txt");

        string textList;
        textList = toolInfra.StorageTextRead("ToolData/Math/List.txt");

        this.TrigoList = toolInfra.SplitLineList(ka);

        this.LineList = toolInfra.SplitLineList(textList);

        this.List = new List();
        this.List.Init();

        this.AddTrigoMaideList("", "");
        this.AddTrigoMaideList("A", "");
        this.AddTrigoMaideList("", "H");
        this.AddTrigoMaideList("A", "H");

        bool b;

        b = this.AddMaideList();
        if (!b)
        {
            return false;
        }

        

        return true;
    }

    protected virtual bool SetMathClass()
    {
        return true;
    }

    protected virtual bool AddMaideList()
    {
        ToolInfra toolInfra;
        toolInfra = this.ToolInfra;

        Array array;
        array = this.LineList;

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            string a;
            a = (string)array.GetAt(i);

            int uu;
            uu = a.IndexOf(' ');

            if (uu < 0)
            {
                return false;
            }

            string name;
            name = a.Substring(0, uu);
            
            string kk;
            kk = a.Substring(uu + 1);

            bool ba;
            ba = toolInfra.GetBool(kk);

            Maide maide;
            maide = this.CreateMaide(name, ba);

            this.List.Add(maide);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool AddTrigoMaideList(string pre, string post)
    {
        Array array;
        array = this.TrigoList;

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            string k;
            k = (string)array.GetAt(i);

            string ka;
            ka = pre + k + post;

            Maide a;
            a = this.CreateMaide(ka, false);

            this.List.Add(a);

            i = i + 1;
        }
        return true;
    }

    protected virtual Maide CreateMaide(string name, bool operandTwo)
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;

        Array param;
        param = this.CreateParam(operandTwo);

        Maide maide;
        maide = new Maide();
        maide.Init();
        maide.Name = name;
        maide.Param = param;

        return maide;
    }

    protected virtual Array CreateParam(bool operandTwo)
    {
        int count;
        count = 1;

        if (operandTwo)
        {
            count = 2;
        }

        Array param;
        param = this.ListInfra.ArrayCreate(count);

        int i;
        i = 0;
        while (i < count)
        {
            string k;
            k = "arg" + i.ToString();

            param.SetAt(i, k);

            i = i + 1;
        }

        return param;
    }
}