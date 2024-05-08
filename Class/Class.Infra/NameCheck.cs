namespace Class.Infra;

public class NameCheck : Any
{
    public override bool Init()
    {
        base.Init();
        this.TextInfra = TextInfra.This;
        this.Keyword = KeywordList.This;
        return true;
    }

    protected virtual TextInfra TextInfra { get; set; }
    protected virtual KeywordList Keyword { get; set; }

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
            if (textInfra.EqualString(text, o, null))
            {
                return true;
            }
            i = i + 1;
        }
        return false;
    }
}