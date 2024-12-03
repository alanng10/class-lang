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
}