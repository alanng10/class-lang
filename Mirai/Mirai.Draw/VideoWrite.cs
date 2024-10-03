namespace Mirai.Draw;

public class VideoWrite : Any
{
    public override bool Init()
    {
        base.Init();
        this.Intern = Extern.ImageWrite_New();
        Extern.ImageWrite_Init(this.Intern);
        return true;
    }

    public virtual bool Final()
    {
        Extern.ImageWrite_Final(this.Intern);
        Extern.ImageWrite_Delete(this.Intern);
        return true;
    }

    public virtual Stream Stream { get; set; }
    public virtual Video Video { get; set; }
    public virtual VideoBinary Binary { get; set; }

    private ulong Intern { get; set; }

    public virtual bool Execute()
    {
        Extern.ImageWrite_StreamSet(this.Intern, this.Stream.Ident);
        Extern.ImageWrite_BinarySet(this.Intern, this.Binary.Intern);
        Extern.ImageWrite_ImageSet(this.Intern, this.Video.Ident);

        ulong u;
        u = Extern.ImageWrite_Execute(this.Intern);

        Extern.ImageWrite_ImageSet(this.Intern, 0);
        Extern.ImageWrite_BinarySet(this.Intern, 0);
        Extern.ImageWrite_StreamSet(this.Intern, 0);

        bool a;
        a = (!(u == 0));
        return a;
    }
}