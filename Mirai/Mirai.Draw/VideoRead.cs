namespace Mirai.Draw;

public class VideoRead : Any
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

    public virtual Stream Stream { get; set; }
    public virtual Image Video { get; set; }

    private InternIntern InternIntern { get; set; }
    private ulong Intern { get; set; }

    public virtual bool Execute()
    {
        Extern.ImageRead_StreamSet(this.Intern, this.Stream.Ident);
        Extern.ImageRead_ImageSet(this.Intern, this.Video.Ident);

        ulong u;
        u = Extern.ImageRead_Execute(this.Intern);

        Extern.ImageRead_ImageSet(this.Intern, 0);
        Extern.ImageRead_StreamSet(this.Intern, 0);

        bool a;
        a = (!(u == 0));
        return a;
    }
}