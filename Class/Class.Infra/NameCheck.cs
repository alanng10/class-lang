namespace Class.Infra;

public class NameCheck : Any
{
    public override bool Init()
    {
        base.Init();
        this.TextInfra = TextInfra.This;
        this.Keyword = KeywordList.This;

        this.CharCompare = new IntCompare();
        this.CharCompare.Init();

        this.TextCompare = new TextCompare();
        this.TextCompare.CharCompare = this.CharCompare;
        this.TextCompare.Init();

        this.StringData = new StringData();
        this.StringData.Init();

        Text text;
        text = new Text();
        text.Init();
        text.Range = new InfraRange();
        text.Range.Init();
        this.Text = text;
        return true;
    }

    protected virtual TextInfra TextInfra { get; set; }
    protected virtual KeywordList Keyword { get; set; }
    protected virtual TextCompare TextCompare { get; set; }
    protected virtual IntCompare CharCompare { get; set; }
    protected virtual StringData StringData { get; set; }
    protected virtual Text Text { get; set; }

    public virtual bool IsName(Text text)
    {
        if (this.IsKeyword(text))
        {
            return false;
        }

        TextInfra textInfra;
        textInfra = this.TextInfra;

        Data data;
        data = text.Data;
        int start;
        start = text.Range.Index;

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
        count = text.Range.Count;
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

    public virtual bool IsKeyword(Text text)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;
        KeywordList keyword;
        keyword = this.Keyword;

        TextCompare compare;
        compare = this.TextCompare;

        Text oo;
        oo = this.Text;
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

            this.TextStringGet(oo, o);

            if (textInfra.Equal(text, oo, compare))
            {
                return true;
            }
            i = i + 1;
        }
        return false;
    }

    protected virtual bool TextStringGet(Text text, string o)
    {
        StringData d;
        d = this.StringData;
        d.Value = o;

        text.Data = d;
        text.Range.Index = 0;
        text.Range.Count = o.Length;
        return true;
    }
}