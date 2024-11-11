class StringOut : Out
{
    maide prusate Bool Init()
    {
        base.Init();
        this.TextInfra : share TextInfra;
        this.StringAdd : new StringAdd;
        this.StringAdd.Init();
        return true;
    }

    field precate TextInfra TextInfra { get { return data; } set { data : value; } }
    field private StringAdd StringAdd { get { return data; } set { data : value; } }

    maide prusate Bool Write(var String value)
    {
        this.TextInfra.AddString(this.StringAdd, value);
        return true;
    }

    maide prusate Bool Clear()
    {
        this.StringAdd.Clear();
        return true;
    }

    maide prusate String Result()
    {
        return this.StringAdd.Result();
    }
}