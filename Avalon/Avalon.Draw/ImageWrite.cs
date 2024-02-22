namespace Avalon.Draw;

public class ImageWrite : Any
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

    public virtual StreamStream Stream { get; set; }
    public virtual Image Image { get; set; }
    public virtual ImageFormat Format { get; set; }

    private ulong Intern { get; set; }

    public virtual bool Execute()
    {
        Extern.ImageWrite_SetStream(this.Intern, this.Stream.Ident);
        Extern.ImageWrite_SetFormat(this.Intern, this.Format.Intern);
        Extern.ImageWrite_SetImage(this.Intern, this.Image.Video.Ident);

        ulong u;
        u = Extern.ImageWrite_Execute(this.Intern);

        Extern.ImageWrite_SetImage(this.Intern, 0);
        Extern.ImageWrite_SetFormat(this.Intern, 0);
        Extern.ImageWrite_SetStream(this.Intern, 0);

        bool b;
        b = (!(u == 0));
        return b;
    }
}