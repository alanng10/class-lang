class ImageFormatList : Any
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

        this.Bmp : this.AddItem(extern.Stat_ImageFormatBmp(stat));
        this.Jpg : this.AddItem(extern.Stat_ImageFormatJpg(stat));
        this.Png : this.AddItem(extern.Stat_ImageFormatPng(stat));
        return true;
    }

    field prusate ImageFormat Bmp { get { return data; } set { data : value; } }
    field prusate ImageFormat Jpg { get { return data; } set { data : value; } }
    field prusate ImageFormat Png { get { return data; } set { data : value; } }

    maide precate ImageFormat AddItem(var Int o)
    {
        var ImageFormat item;
        item : new ImageFormat;
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

    maide prusate ImageFormat Get(var Int index)
    {
        return cast ImageFormat(this.Array.Get(index));
    }
}