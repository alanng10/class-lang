namespace Mirai.Frame;

public class Frame : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = InternIntern.This;
        this.InternInfra = InternInfra.This;
        this.MathInfra = MathInfra.This;
        this.TextInfra = TextInfra.This;
        this.DrawInfra = DrawInfra.This;
        this.FrameInfra = Infra.This;

        this.Math = this.CreateMath();
        this.MathComp = this.CreateMathComp();

        this.InternHandle = new Handle();
        this.InternHandle.Any = this;
        this.InternHandle.Init();

        MaideAddress ua;
        ua = this.FrameInfra.FrameTypeMaideAddress;
        MaideAddress ub;
        ub = this.FrameInfra.FrameDrawMaideAddress;
        ulong arg;
        arg = this.InternHandle.ULong();

        this.InternTypeState = this.InternInfra.StateCreate(ua, arg);
        this.InternDrawState = this.InternInfra.StateCreate(ub, arg);

        this.InternUpdateRect = this.InternInfra.RectCreate();

        this.Intern = Extern.Frame_New();
        Extern.Frame_Init(this.Intern);

        this.Title = this.TextInfra.S("Frame");
        this.TitleSet();

        ulong sizeU;
        sizeU = Extern.Frame_SizeGet(this.Intern);
        ulong w;
        w = Extern.Size_WedGet(sizeU);
        ulong h;
        h = Extern.Size_HetGet(sizeU);
        long wed;
        wed = (long)w;
        long het;
        het = (long)h;
        this.Size = new DrawSize();
        this.Size.Init();
        this.Size.Wed = wed;
        this.Size.Het = het;

        Extern.Frame_TypeStateSet(this.Intern, this.InternTypeState);
        Extern.Frame_DrawStateSet(this.Intern, this.InternDrawState);

        this.DestRect = this.CreateFrameRect();
        this.SourceRect = this.CreateFrameRect();

        ulong kk;
        kk = Extern.Frame_VideoOut(this.Intern);

        DrawImage image;
        image = new DrawImage();
        image.Init();
        image.Size.Wed = wed;
        image.Size.Het = het;
        image.DataCreate();
        this.DrawImage = image;

        DrawDraw frameDraw;
        frameDraw = new DrawDraw();
        frameDraw.Init();
        this.FrameDraw = frameDraw;
        this.DrawSet(frameDraw, kk);

        this.Draw = this.CreateDraw();
        this.DrawSet(this.Draw, image.Out);

        this.DrawClearColor = this.CreateDrawClearColor();
        return true;
    }

    public virtual bool Final()
    {
        this.FinalDraw(this.Draw);

        this.FrameDraw.Final();

        this.DrawImage.Final();

        Extern.Frame_Final(this.Intern);
        Extern.Frame_Delete(this.Intern);

        this.InternInfra.RectDelete(this.InternUpdateRect);

        this.InternInfra.StateDelete(this.InternDrawState);

        this.InternInfra.StateDelete(this.InternTypeState);

        this.InternHandle.Final();
        return true;
    }

    public virtual DrawSize Size { get; set; }
    public virtual String Title { get; set; }
    public virtual TypeType Type { get; set; }
    public virtual DrawImage DrawImage { get; set; }

    private InternIntern InternIntern { get; set; }
    private InternInfra InternInfra { get; set; }
    protected virtual MathInfra MathInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual DrawInfra DrawInfra { get; set; }
    protected virtual MathMath Math { get; set; }
    protected virtual MathComp MathComp { get; set; }
    protected virtual DrawDraw Draw { get; set; }
    protected virtual VideoColor DrawClearColor { get; set; }
    private Infra FrameInfra { get; set; }
    private ulong Intern { get; set; }
    private ulong InternTitle { get; set; }
    private ulong InternUpdateRect { get; set; }
    private ulong InternDrawState { get; set; }
    private ulong InternTypeState { get; set; }
    private Handle InternHandle { get; set; }
    private DrawDraw FrameDraw { get; set; }
    private DrawRect DestRect { get; set; }
    private DrawRect SourceRect { get; set; }

    protected virtual MathMath CreateMath()
    {
        MathMath a;
        a = new MathMath();
        a.Init();
        return a;
    }

    protected virtual MathComp CreateMathComp()
    {
        MathComp a;
        a = new MathComp();
        a.Init();
        return a;
    }

    protected virtual DrawDraw CreateDraw()
    {
        DrawDraw a;
        a = new DrawDraw();
        a.Init();
        return a;
    }

    protected virtual bool FinalDraw(DrawDraw a)
    {
        a.Final();
        return true;
    }

    protected virtual VideoColor CreateDrawClearColor()
    {
        VideoColor a;

        byte ou;
        ou = byte.MaxValue;

        a = this.DrawInfra.ColorCreate(ou, ou, ou, ou);
        return a;
    }

    public virtual bool TitleSet()
    {
        this.InternTitle = this.InternInfra.StringCreate(this.Title.Value);

        Extern.Frame_TitleSet(this.Intern, this.InternTitle);
        Extern.Frame_TitleThisSet(this.Intern);
        Extern.Frame_TitleSet(this.Intern, 0);

        this.InternInfra.StringDelete(this.InternTitle);
        return true;
    }

    internal static ulong InternType(ulong frame, ulong index, ulong value, ulong arg)
    {
        InternIntern internIntern;
        internIntern = InternIntern.This;

        object ao;
        ao = internIntern.HandleTarget(arg);

        Frame a;
        a = (Frame)ao;
        a.TypeChangeHandle(index, value);

        return 1;
    }

    private bool TypeChangeHandle(ulong index, ulong value)
    {
        long indexA;
        indexA = (long)index;
        bool b;
        b = (!(value == 0));

        long indexB;
        indexB = this.InternIntern.TypeIndexFromInternIndex(indexA);

        this.TypeChange(indexB, b);
        return true;
    }

    protected virtual bool TypeChange(long index, bool value)
    {
        if (!(this.Type == null))
        {
            this.Type.Set(index, value);
        }
        return true;
    }

    internal static ulong InternDraw(ulong frame, ulong arg)
    {
        InternIntern internIntern;
        internIntern = InternIntern.This;

        object ao;
        ao = internIntern.HandleTarget(arg);

        Frame a;
        a = (Frame)ao;
        a.ExecuteFrameDraw();
        return 1;
    }

    private bool ExecuteFrameDraw()
    {
        DrawDraw draw;
        draw = this.FrameDraw;

        draw.Start();

        this.ExecuteDraw();

        draw.ExecuteVideo(this.DrawImage, this.DestRect, this.SourceRect);

        draw.End();
        return true;
    }

    protected virtual bool ExecuteDraw()
    {
        DrawDraw draw;
        draw = this.Draw;

        draw.Start();

        draw.Clear(this.DrawClearColor);

        draw.End();
        return true;
    }

    public virtual bool EventDraw(DrawRect rect)
    {
        this.InternInfra.RectSet(this.InternUpdateRect,
            rect.Pos.Col, rect.Pos.Row, rect.Size.Wed, rect.Size.Het
        );

        Extern.Frame_Update(this.Intern, this.InternUpdateRect);
        return true;
    }

    public virtual bool Video
    {
        get
        {
            ulong u;
            u = Extern.Frame_VisibleGet(this.Intern);
            bool a;
            a = (!(u == 0));
            return a;
        }
        set
        {
            ulong u;
            u = (ulong)(value ? 1 : 0);
            Extern.Frame_VisibleSet(this.Intern, u);
        }
    }

    public virtual bool Close()
    {
        Extern.Frame_Close(this.Intern);
        return true;
    }

    protected virtual long MathInt(long n)
    {
        MathInfra mathInfra;
        mathInfra = this.MathInfra;

        MathMath math;
        math = this.Math;

        MathComp mathComp;
        mathComp = this.MathComp;

        long a;
        a = mathInfra.Int(math, mathComp, n);
        return a;
    }

    protected virtual long MathValue(long cand, long expo)
    {
        MathComp mathComp;
        mathComp = this.MathComp;

        mathComp.Cand = cand;
        mathComp.Expo = expo;

        long a;
        a = this.Math.Value(mathComp);
        return a;
    }

    private DrawRect CreateFrameRect()
    {
        DrawSize size;
        size = this.Size;

        DrawRect a;
        a = this.DrawInfra.RectCreate(0, 0, this.MathInt(size.Wed), this.MathInt(size.Het));
        return a;
    }

    private bool DrawSet(DrawDraw draw, ulong videoOut)
    {
        DrawSize size;
        size = this.Size;

        draw.Out = videoOut;
        draw.Size.Wed = size.Wed;
        draw.Size.Het = size.Het;
        draw.SizeSet();

        return true;
    }
}