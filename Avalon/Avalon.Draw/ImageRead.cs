namespace Avalon.Draw;

public class ImageRead : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = InternIntern.This;
        this.Intern = Extern.ImageRead_New();
        Extern.ImageRead_Init(this.Intern);
        return true;
    }

    public virtual bool Final()
    {
        Extern.ImageRead_Final(this.Intern);
        Extern.ImageRead_Delete(this.Intern);
        return true;
    }

    public virtual StreamStream Stream { get; set; }
    public virtual Image Image { get; set; }

    private InternIntern InternIntern { get; set; }
    private ulong Intern { get; set; }

    public virtual bool Execute()
    {
        Extern.ImageRead_StreamSet(this.Intern, this.Stream.Ident);
        Extern.ImageRead_ImageSet(this.Intern, this.Image.Ident);

        ulong u;        
        u = Extern.ImageRead_Execute(this.Intern);

        Extern.ImageRead_ImageSet(this.Intern, 0);
        Extern.ImageRead_StreamSet(this.Intern, 0);
        
        bool a;
        a = (!(u == 0));
        return a;
    }
}