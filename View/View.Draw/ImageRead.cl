class ImageRead : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.Extern : share Extern;

        var Extern extern;
        extern : this.Extern;

        this.Intern : extern.ImageRead_New();
        extern.ImageRead_Init(this.Intern);
        return true;
    }

    maide prusate Bool Final()
    {
        var Extern extern;
        extern : this.Extern;

        extern.ImageRead_Final(this.Intern);
        extern.ImageRead_Delete(this.Intern);
        return true;
    }

    field prusate Stream Stream { get { return data; } set { data : value; } }
    field prusate Image Image { get { return data; } set { data : value; } }
    field private Extern Extern { get { return data; } set { data : value; } }
    field private Int Intern { get { return data; } set { data : value; } }

    maide prusate Bool Execute()
    {
        var Extern extern;
        extern : this.Extern;

        
    }
}