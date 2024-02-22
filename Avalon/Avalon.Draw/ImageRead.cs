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
        Extern.ImageRead_SetStream(this.Intern, this.Stream.Ident);
        Extern.ImageRead_SetImage(this.Intern, this.Image.Video.Ident);

        ulong u;        
        u = Extern.ImageRead_Execute(this.Intern);

        Extern.ImageRead_SetImage(this.Intern, 0);
        Extern.ImageRead_SetStream(this.Intern, 0);
        
        bool b;
        b = (!(u == 0));

        if (b)
        {
            this.SetSize();
        }
        return b;
    }

    private bool SetSize()
    {
        VideoVideo video;
        video = this.Image.Video;
        ulong sizeU;
        sizeU = Extern.Image_GetSize(video.Ident);
        ulong w;
        ulong h;
        w = Extern.Size_GetWidth(sizeU);
        h = Extern.Size_GetHeight(sizeU);
        int width;
        int height;
        width = (int)w;
        height = (int)h;

        VideoSize sizeA;
        sizeA = video.Size;
        sizeA.Width = width;
        sizeA.Height = height;
        this.Image.SetSize();
        return true;
    }
}