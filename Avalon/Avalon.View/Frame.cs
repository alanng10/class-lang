namespace Avalon.View;

public class Frame : Comp
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = InternIntern.This;
        this.InternInfra = InternInfra.This;
        this.KeyCodeList = KeyCodeList.This;
        this.DrawInfra = DrawInfra.This;

        this.ViewField = this.CreateViewField();

        this.InternHandle = new Handle();        
        this.InternHandle.Any = this;
        this.InternHandle.Init();

        MaideAddress ua;
        ua = this.ViewInfra.FrameTypeMaideAddress;
        MaideAddress ub;
        ub = this.ViewInfra.FrameDrawMaideAddress;
        ulong arg;
        arg = this.InternHandle.ULong();

        this.InternTypeState = this.InternInfra.StateCreate(ua, arg);
        this.InternDrawState = this.InternInfra.StateCreate(ub, arg);

        this.InternUpdateRect = this.InternInfra.RectCreate();

        this.Title = "Frame";

        this.Intern = Extern.Frame_New();
        Extern.Frame_Init(this.Intern);

        this.SetTitle();

        ulong sizeU;
        sizeU = Extern.Frame_SizeGet(this.Intern);
        ulong w;
        w = Extern.Size_WidthGet(sizeU);
        ulong h;
        h = Extern.Size_HeightGet(sizeU);
        int width;
        width = (int)w;
        int height;
        height = (int)h;
        this.Size = new DrawSize();
        this.Size.Init();
        this.Size.Width = width;
        this.Size.Height = height;

        Extern.Frame_TypeStateSet(this.Intern, this.InternTypeState);
        Extern.Frame_DrawStateSet(this.Intern, this.InternDrawState);

        ulong ouu;
        ouu = Extern.Frame_VideoOut(this.Intern);

        this.Draw = new DrawDraw();
        this.Draw.Init();
        this.Draw.Out = ouu;
        this.Draw.Size.Width = this.Size.Width;
        this.Draw.Size.Height = this.Size.Height;
        this.Draw.SetSize();
        return true;
    }

    public virtual bool Final()
    {
        this.Draw.Final();

        Extern.Frame_Final(this.Intern);
        Extern.Frame_Delete(this.Intern);

        this.InternInfra.RectDelete(this.InternUpdateRect);

        this.InternInfra.StateDelete(this.InternDrawState);

        this.InternInfra.StateDelete(this.InternTypeState);

        this.InternHandle.Final();
        return true;
    }

    public virtual DrawSize Size { get; set; }
    public virtual string Title { get; set; }
    public virtual TypeType Type { get; set; }

    private InternIntern InternIntern { get; set; }
    private InternInfra InternInfra { get; set; }
    private KeyCodeList KeyCodeList { get; set; }
    protected virtual DrawInfra DrawInfra { get; set; }
    protected virtual DrawDraw Draw { get; set; }
    private ulong Intern { get; set; }
    private ulong InternTitle { get; set; }
    private ulong InternUpdateRect { get; set; }
    private ulong InternDrawState { get; set; }
    private ulong InternTypeState { get; set; }
    private Handle InternHandle { get; set; }

    protected virtual Field CreateViewField()
    {
        return this.ViewInfra.FieldCreate(this);
    }

    public virtual bool SetTitle()
    {
        this.InternTitle = this.InternInfra.StringCreate(this.Title);

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
        int indexA;
        indexA = (int)index;
        bool b;
        b = (!(value == 0));

        int indexB;
        indexB = this.KeyCodeList.IndexFromInternIndex(indexA);
        indexB = this.KeyCodeList.Get(indexB);
        if (indexB < 0)
        {
            return true;
        }

        this.TypeChange(indexB, b);
        return true;
    }

    protected virtual bool TypeChange(int index, bool value)
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
        a.ExecuteDraw();
        return 1;
    }

    protected virtual bool ExecuteDraw()
    {
        DrawDraw draw;
        draw = this.Draw;

        this.ExecuteDrawStart(draw);

        this.ExecuteDrawBefore(draw);

        if (this.CheckDrawView())
        {
            this.ExecuteDrawView(draw);
        }

        this.ExecuteDrawAfter(draw);

        this.ExecuteDrawEnd(draw);
        return true;
    }

    protected virtual bool CheckDrawView()
    {
        return !(this.View == null);
    }

    protected virtual bool ExecuteDrawView(DrawDraw draw)
    {
        this.View.ExecuteDraw(draw);
        return true;
    }

    protected virtual bool ExecuteDrawBefore(DrawDraw draw)
    {
        draw.Clear(this.DrawInfra.WhiteColor);
        return true;
    }

    protected virtual bool ExecuteDrawAfter(DrawDraw draw)
    {
        return true;
    }

    protected virtual bool ExecuteDrawStart(DrawDraw draw)
    {
        draw.Start();
        return true;
    }

    protected virtual bool ExecuteDrawEnd(DrawDraw draw)
    {
        draw.End();
        return true;
    }

    public virtual bool Update(DrawRect rect)
    {
        this.InternInfra.SetRectFromRectValue(this.InternUpdateRect, 
            rect.Pos.Left, rect.Pos.Up, rect.Size.Width, rect.Size.Height
        );

        Extern.Frame_Update(this.Intern, this.InternUpdateRect);
        return true;
    }

    public virtual bool Visible
    {
        get
        {
            return this.GetVisible();
        }
        set
        {
            this.SetVisible(value);
        }
    }

    private bool GetVisible()
    {
        ulong u;
        u = Extern.Frame_VisibleGet(this.Intern);
        bool a;
        a = (!(u == 0));
        return a;
    }

    private bool SetVisible(bool value)
    {
        ulong u;
        u = (ulong)(value ? 1 : 0);
        Extern.Frame_VisibleSet(this.Intern, u);
        return true;
    }

    public virtual bool Close()
    {
        Extern.Frame_Close(this.Intern);
        return true;
    }

    public virtual Field ViewField { get; set; }

    public virtual View View
    {
        get
        {
            return (View)this.ViewField.Get();
        }

        set
        {
            this.ViewField.Set(value);
        }
    }

    protected virtual bool ChangeView(Change change)
    {
        this.Trigger(this.ViewField);
        return true;
    }

    public override bool Change(Field field, Change change)
    {
        if (this.ViewField == field)
        {
            this.ChangeView(change);
        }
        return true;
    }
}