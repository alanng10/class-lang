class Image : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.Extern : share Extern;
        this.InternInfra : share InternInfra;
        this.InfraInfra : share InfraInfra;
        this.DrawInfra : share Infra;

        this.Size : new Size;
        this.Size.Init();

        var Extern extern;
        extern : this.Extern;

        this.InternData : extern.Data_New();
        extern.Data_Init(this.InternData);

        this.InternSize : extern.Size_New();
        extern.Size_Init(this.InternSize);

        this.Intern : extern.Image_New();
        extern.Image_DataSet(this.Intern, this.InternData);
        extern.Image_SizeSet(this.Intern, this.InternSize);
        extern.Image_Init(this.Intern);
        this.Ident : this.Intern;
        return true;
    }

    maide prusate Bool Final()
    {
        var Extern extern;
        extern : this.Extern;

        extern.Image_Final(this.Intern);
        extern.Image_Delete(this.Intern);

        extern.Size_Final(this.Intern);
        extern.Size_Delete(this.Intern);

        extern.Data_Final(this.Intern);
        extern.Data_Delete(this.Intern);
        return true;
    }

    field prusate Size Size { get { return data; } set { data : value; } }

    field prusate Any Out
    {
        get
        {
            return this.Extern.Image_VideoOut(this.Intern);
        }
        set
        {
        }
    }

    field prusate Any Ident { get { return data; } set { data : value; } }
    field private Extern Extern { get { return data; } set { data : value; } }
    field private InternInfra InternInfra { get { return data; } set { data : value; } } 
    field precate InfraInfra InfraInfra { get { return data; } set { data : value; } }
    field precate Infra DrawInfra { get { return data; } set { data : value; } }
    field pronate Int Intern { get { return data; } set { data : value; } }
    field private Int InternSize { get { return data; } set { data : value; } }
    field private Int InternData { get { return data; } set { data : value; } }
    
    maide prusate Bool DataCreate()
    {
        var Int wed;
        var Int het;
        wed : this.Size.Wed;
        het : this.Size.Het;
        
        var Extern extern;
        extern : this.Extern;

        extern.Size_WedSet(this.InternSize, wed);
        extern.Size_HetSet(this.InternSize, het);
        
        extern.Image_DataCreate(this.Intern);
        return true;
    }

    maide prusate Bool DataGet(var Data data, var Int index)
    {
        var Int w;
        var Int h;
        w : this.Size.Wed;
        h : this.Size.Het;
        var Int ka;
        ka : this.DrawInfra.PixelByteCount;

        var Int kh;
        kh : w;
        kh : kh * h;
        kh : kh * ka;

        var Int count;
        count : kh;

        inf (~this.InfraInfra.ValidRange(data.Count, index, count))
        {
            return false;
        }

        var Int a;
        a : this.Extern.Data_ValueGet(this.InternData);

        this.InternInfra.CopyToByteArray(a, data.Value, index, count);
        return true;
    }

    maide prusate Bool DataSet(var Data data, var Int index)
    {
        var Int w;
        var Int h;
        w : this.Size.Wed;
        h : this.Size.Het;
        var Int ka;
        ka : this.DrawInfra.PixelByteCount;

        var Int kh;
        kh : w;
        kh : kh * h;
        kh : kh * ka;

        var Int count;
        count : kh;

        inf (~this.InfraInfra.ValidRange(data.Count, index, count))
        {
            return false;
        }

        var Int a;
        a : this.Extern.Data_ValueGet(this.InternData);

        this.InternInfra.CopyFromByteArray(a, data.Value, index, count);
        return true;
    }
}