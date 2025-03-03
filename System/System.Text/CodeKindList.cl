class CodeKindList : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.InitArray();
        this.Count : this.Array.Count;
        this.Index : 0;

        var Extern extern;
        extern : share Extern;

        var Int varShare;
        varShare : extern.Infra_Share();
        var Int stat;
        stat : extern.Share_Stat(varShare);

        this.Utf8 : this.AddItem(extern.Stat_TextCodeKindUtf8(stat));
        this.Utf16 : this.AddItem(extern.Stat_TextCodeKindUtf16(stat));
        this.Utf32 : this.AddItem(extern.Stat_TextCodeKindUtf32(stat));
        return true;
    }

    field prusate CodeKind Utf8 { get { return data; } set { data : value; } }
    field prusate CodeKind Utf16 { get { return data; } set { data : value; } }
    field prusate CodeKind Utf32 { get { return data; } set { data : value; } }

    maide precate CodeKind AddItem(var Int o)
    {
        var CodeKind item;
        item : new CodeKind;
        item.Init();
        item.Index : this.Index;
        item.Intern : o;
        this.Array.Set(item.Index, item);
        this.Index : this.Index + 1;
        return item;
    }

    maide precate Bool InitArray()
    {
        this.Array : new Array;
        this.Array.Count : this.ArrayCount;
        this.Array.Init();
        return true;
    }

    field precate Array Array { get { return data; } set { data : value; } }

    field precate Int ArrayCount { get { return 3; } set { } }

    field prusate Int Count { get { return data; } set { data : value; } }

    field precate Int Index { get { return data; } set { data : value; } }

    maide prusate CodeKind Get(var Int index)
    {
        return cast CodeKind(this.Array.Get(index));
    }
}