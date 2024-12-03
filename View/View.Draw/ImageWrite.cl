class ImageWrite : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.Extern : share Extern;

        var Extern extern;
        extern : this.Extern;

        this.Intern : extern.ImageWrite_New();
        extern.ImageWrite_Init(this.Intern);
        return true;
    }

    maide prusate Bool Final()
    {
        var Extern extern;
        extern : this.Extern;

        extern.ImageWrite_Final(this.Intern);
        extern.ImageWrite_Delete(this.Intern);
        return true;
    }


    field prusate Stream Stream { get { return data; } set { data : value; } }
    field prusate Image Image { get { return data; } set { data : value; } }
    field prusate ImageFormat Format { get { return data; } set { data : value; } }
    field private Extern Extern { get { return data; } set { data : value; } }
    field private Int Intern { get { return data; } set { data : value; } }

    maide prusate Bool Execute()
    {
        var Int streamK;
        streamK : cast Int(this.Stream.Ident);

        var Extern extern;
        extern : this.Extern;

        extern.ImageWrite.StreamSet(this.Intern, streamK);
        extern.ImageWrite.ImageSet(this.Intern, this.Image.Intern);
        extern.ImageWrite.FormatSet(this.Intern, this.Format.Intern);

        var Int k;
        k : extern.ImageWrite_Execute(this.Intern);

        extern.ImageWrite.FormatSet(this.Intern, 0);
        extern.ImageWrite_ImageSet(this.Intern, 0);
        extern.ImageWrite_StreamSet(this.Intern, 0);

        var Bool a;
        a : ~(k = 0);
        return a;
    }
}