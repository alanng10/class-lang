namespace Demo;

class Demo : Any
{
    public Frame Frame { get; set; }
    public View View { get; set; }
    public ViewA ViewA { get; set; }
    public ViewC ViewC { get; set; }
    public DrawRect UpdateRect { get; set; }
    public DrawImage ThreadDrawImage { get; set; }
    public Play Play { get; set; }
    public DrawImage PlayImage { get; set; }

    public virtual InfraInfra InfraInfra { get; set; }
    public virtual ListInfra ListInfra { get; set; }
    public virtual MathInfra MathInfra { get; set; }
    public virtual TextInfra TextInfra { get; set; }
    public virtual DrawInfra DrawInfra { get; set; }
    public virtual StringComp StringComp { get; set; }
    public virtual MathMath Math { get; set; }
    public virtual TextCodeKindList TextCodeKindList { get; set; }
    public virtual StorageStatusList StorageStatusList { get; set; }
    public virtual StorageComp StorageComp { get; set; }
    public virtual DrawBrushKindList BrushKindList { get; set; }
    public virtual DrawBrushLineList BrushLineList { get; set; }
    public virtual DrawBrushCapList BrushCapList { get; set; }
    public virtual DrawBrushJoinList BrushJoinList { get; set; }
    public virtual Console Console { get; set; }

    protected virtual MathComp MathComp { get; set; }
    private StringAdd StringAdd { get; set; }
    private TextWrite TextWrite { get; set; }
    private TextWriteArg TextWriteArg { get; set; }

    public bool Execute()
    {
        this.InfraInfra = InfraInfra.This;
        this.ListInfra = ListInfra.This;
        this.TextInfra = TextInfra.This;
        this.MathInfra = MathInfra.This;
        this.DrawInfra = DrawInfra.This;
        this.StringComp = StringComp.This;
        this.Math = MathMath.This;
        this.TextCodeKindList = TextCodeKindList.This;
        this.StorageStatusList = StorageStatusList.This;
        this.StorageComp = StorageComp.This;
        this.BrushKindList = DrawBrushKindList.This;
        this.BrushLineList = DrawBrushLineList.This;
        this.BrushCapList = DrawBrushCapList.This;
        this.BrushJoinList = DrawBrushJoinList.This;
        this.Console = Console.This;

        this.StringAdd = new StringAdd();
        this.StringAdd.Init();

        ThreadThis varThis;
        varThis = new ThreadThis();
        varThis.Init();
        
        this.MathComp = new MathComp();
        this.MathComp.Init();

        this.ThreadDrawImage = this.ThreadDrawImageCreate();

        this.ExecuteDemoThread();

        this.Frame = new Frame();
        this.Frame.Init();
        this.Frame.Title = this.S("Mirai Demo");
        this.Frame.TitleSet();

        this.UpdateRect = new DrawRect();
        this.UpdateRect.Init();
        this.UpdateRect.Pos = new DrawPos();
        this.UpdateRect.Pos.Init();
        this.UpdateRect.Size = new DrawSize();
        this.UpdateRect.Size.Init();
        this.UpdateRect.Size.Wed = this.Frame.Size.Wed;
        this.UpdateRect.Size.Het = this.Frame.Size.Het;

        Type type;
        type = Type.This;
        TypeState state;
        state = new TypeState();
        state.Init();
        state.Demo = this;
        type.Mod.State.AddState(state);
        this.Frame.Type = type;

        DrawBrush brush;
        brush = new DrawBrush();
        brush.Kind = this.BrushKindList.Color;
        brush.Color = this.DrawInfra.ColorCreate(0xff, 0, 0xff, 0);
        brush.Init();

        View view;
        view = new View();
        view.Init();
        view.Pos.Col = 100;
        view.Pos.Row = 100;
        view.Size.Wed = 1600;
        view.Size.Het = 900;
        view.Back = brush;

        DrawBrush brushA;
        brushA = new DrawBrush();
        brushA.Kind = this.BrushKindList.Color;
        brushA.Color = this.DrawInfra.ColorCreate(0xff, 0, 0, 0xff);
        brushA.Init();

        DrawBrush penBrush;
        penBrush = new DrawBrush();
        penBrush.Kind = this.BrushKindList.Color;
        penBrush.Color = this.DrawInfra.ColorCreate(0xff, 0xff, 0, 0xff);
        penBrush.Line = this.BrushLineList.DashDotDot;
        penBrush.Wed = this.MathInt(11);
        penBrush.Cap = this.BrushCapList.Round;
        penBrush.Join = this.BrushJoinList.Bevel;
        penBrush.Init();

        ViewC viewC;
        viewC = this.ViewCCreate();

        DrawForm viewAForm;
        viewAForm = new DrawForm();
        viewAForm.Init();

        ViewA viewA;
        viewA = new ViewA();
        viewA.Init();
        viewA.Pos.Col = 0;
        viewA.Pos.Row = 0;
        viewA.Size.Wed = 600;
        viewA.Size.Het = 400;
        viewA.Back = brushA;
        viewA.DrawPen = penBrush;
        viewA.Form = viewAForm;
        viewA.Demo = this;

        DrawBrush gridBrush;
        gridBrush = new DrawBrush();
        gridBrush.Kind = this.BrushKindList.Color;
        gridBrush.Color = this.DrawInfra.ColorCreate(0x80, 0, 0, 0);
        gridBrush.Init();

        Grid grid;
        grid = new Grid();
        grid.Init();

        grid.Back = gridBrush;

        ViewCount colA;
        colA = new ViewCount();
        colA.Init();
        colA.Value = 600;
        ViewCount colB;
        colB = new ViewCount();
        colB.Init();
        colB.Value = 600;
        ViewCount rowA;
        rowA = new ViewCount();
        rowA.Init();
        rowA.Value = 600;
        GridChild childA;
        childA = new GridChild();
        childA.Init();
        childA.View = viewA;
        childA.Rect.Size.Wed = 1;
        childA.Rect.Size.Het = 1;
        GridChild childB;
        childB = new GridChild();
        childB.Init();
        childB.View = viewC;
        childB.Rect.Pos.Col = 1;
        childB.Rect.Size.Wed = 1;
        childB.Rect.Size.Het = 1;

        grid.Pos.Col = 50;
        grid.Pos.Row = 50;
        grid.Size.Wed = 1500;
        grid.Size.Het = 800;
        grid.Dest.Pos.Col = 0;
        grid.Dest.Pos.Row = 0;
        grid.Dest.Size.Wed = 1500;
        grid.Dest.Size.Het = 800;
        grid.Row.Add(rowA);
        grid.Col.Add(colA);
        grid.Col.Add(colB);
        grid.ChildList.Add(childA);
        grid.ChildList.Add(childB);

        view.Child = grid;

        DrawImage image;
        image = this.ImageCreate();

        long wedA;
        long hetA;
        wedA = 400;
        hetA = 200;
        DrawRect sourceRect;
        sourceRect = this.DrawInfra.RectCreate(this.MathInt(1880), this.MathInt(910), this.MathInt(wedA), this.MathInt(hetA));

        DrawForm formA;
        formA = new DrawForm();
        formA.Init();

        DrawRect destRectA;
        destRectA = this.DrawInfra.RectCreate(0, 0, this.MathInt(200), this.MathInt(200));

        DrawRect sourceRectA;
        sourceRectA = this.DrawInfra.RectCreate(0, 0, this.MathInt(200), this.MathInt(200));

        ViewB viewB;
        viewB = new ViewB();
        viewB.Init();
        viewB.Pos.Col = 60;
        viewB.Pos.Row = 40;
        viewB.Size.Wed = wedA;
        viewB.Size.Het = hetA;
        viewB.DrawImage = image;
        viewB.SourceRect = sourceRect;
        viewB.Form = formA;
        viewB.ThreadDrawImage = this.ThreadDrawImage;
        viewB.DestRectA = destRectA;
        viewB.SourceRectA = sourceRectA;

        viewA.Child = viewB;

        this.PlayImage = this.PlayImageCreate();

        this.Play = this.PlayCreate();

        this.ViewA = viewA;
        this.View = view;
        this.ViewC = viewC;

        this.Frame.View = this.View;
        this.Frame.Visible = true;

        ThreadThread thread;
        thread = varThis.Thread;
        
        thread.ExecuteMain();

        this.PlayFinal(this.Play);

        this.PlayImageFinal(this.PlayImage);

        formA.Final();

        this.ImageFinal(image);

        gridBrush.Final();

        viewAForm.Final();

        this.ViewCFinal(viewC);

        penBrush.Final();

        brushA.Final();

        brush.Final();

        this.Frame.Final();

        this.ThreadDrawImageFinal(this.ThreadDrawImage);
        return true;
    }

    private DrawImage ImageCreate()
    {
        DrawImage image;
        image = this.DrawInfra.ImageCreateStorage(this.S("MiraiDemoData/image.jpg"));
        return image;
    }

    private bool ImageFinal(DrawImage image)
    {
        image.Final();
        return true;
    }

    private DrawImage ThreadDrawImageCreate()
    {
        DrawImage a;
        a = this.DrawInfra.ImageCreateSize(this.DrawInfra.SizeCreate(250, 200));
        return a;
    }

    private bool ThreadDrawImageFinal(DrawImage a)
    {
        a.Final();
        return true;
    }

    private bool ExecuteDemoThread()
    {
        ThreadPhore phore;
        phore = new ThreadPhore();
        phore.InitCount = 1;
        phore.Init();
        phore.Open();

        ThreadState state;
        state = new ThreadState();
        state.Init();
        state.Demo = this;
        state.Image = this.ThreadDrawImage;
        state.Phore = phore;

        ThreadThread thread;
        thread = new ThreadThread();
        thread.Init();
        thread.ExecuteState = state;
        thread.Execute();

        phore.Open();

        this.Console.Out.Write(this.S("Demo.ExecuteDemoThread phore Acquire Success\n"));

        thread.Wait();

        long aa;
        aa = thread.Status;
        this.Console.Out.Write(this.S("Demo.ExecuteDemoThread Thread Status: 0h" + aa.ToString("x8") + "\n"));

        thread.Final();

        phore.Final();
        return true;
    }

    internal bool ExecuteDemoThisThread()
    {
        ThreadThis varThis;
        varThis = new ThreadThis();
        varThis.Init();

        ThreadThread thread;
        thread = varThis.Thread;

        bool isMainThread;
        isMainThread = thread.Main;

        this.Console.Out.Write(this.S("This Thread is Main Thread: " + isMainThread.ToString() + "\n"));
        return true;
    }

    private DrawBrush EllipseBrushCreate()
    {
        DrawBrush a;
        a = new DrawBrush();
        a.Kind = this.BrushKindList.Color;
        a.Color = this.DrawInfra.ColorCreate(0xff, 0, 0xff, 0xff);
        a.Init();
        return a;
    }

    private bool EllipseBrushFinal(DrawBrush a)
    {
        a.Final();
        return true;
    }

    private DrawFace FaceCreate()
    {
        DrawFace a;
        a = new DrawFace();
        a.Name = this.S("Source Code Pro");
        a.Size = 20;
        a.Weight = 400;
        a.Italic = true;
        a.Underline = true;
        a.Overline = true;
        a.Strikeout = true;
        a.Init();
        return a;
    }

    private bool FaceFinal(DrawFace a)
    {
        a.Final();
        return true;
    }

    private ViewC ViewCCreate()
    {
        DrawGradientKindList gradientKindList;
        gradientKindList = DrawGradientKindList.This;

        DrawGradientLinear gradientLinear;
        gradientLinear = new DrawGradientLinear();
        gradientLinear.StartPos = this.DrawInfra.PosCreate(this.MathInt(300), 0);
        gradientLinear.EndPos = this.DrawInfra.PosCreate(this.MathInt(300), this.MathInt(400));
        gradientLinear.Init();

        DrawGradientStop gradientStop;
        gradientStop = new DrawGradientStop();
        gradientStop.Count = 3;
        gradientStop.Init();

        DrawGradientStopPoint aa;
        aa = new DrawGradientStopPoint();
        aa.Init();

        this.GradientStopSetPoint(gradientStop, aa, 0, 0, this.DrawInfra.ColorCreate(0xff, 0xff, 0, 0));
        this.GradientStopSetPoint(gradientStop, aa, 1, this.MathValue(1, -1), this.DrawInfra.ColorCreate(0xff, 0, 0xff, 0));
        this.GradientStopSetPoint(gradientStop, aa, 2, this.MathInt(1), this.DrawInfra.ColorCreate(0xff, 0, 0, 0xff));

        DrawGradientSpreadList spreadList;
        spreadList = DrawGradientSpreadList.This;

        DrawGradient gradient;
        gradient = new DrawGradient();
        gradient.Kind = gradientKindList.Linear;
        gradient.Linear = gradientLinear;
        gradient.Stop = gradientStop;
        gradient.Spread = spreadList.Pad;
        gradient.Init();

        DrawBrush brush;
        brush = new DrawBrush();
        brush.Kind = this.BrushKindList.Polate;
        brush.Polate = gradient;
        brush.Init();

        DrawBrush ellipseBrush;
        ellipseBrush = this.EllipseBrushCreate();

        DrawFace face;
        face = this.FaceCreate();

        DrawBrush textPen;
        textPen = this.TextPenCreate();

        DrawTextAlign align;
        align = new DrawTextAlign();
        align.Init();
        align.Horiz = 2;
        align.Vert = 1;

        String oa;
        oa = this.S("G L 的哈gd@行 o #");

        Text text;
        text = this.TextInfra.TextCreateStringData(oa, null);

        ViewC viewC;
        viewC = new ViewC();
        viewC.Init();
        viewC.Pos.Col = -300;
        viewC.Pos.Row = 0;
        viewC.Size.Wed = 500;
        viewC.Size.Het = 400;
        viewC.Back = brush;
        viewC.EllipseBrush = ellipseBrush;
        viewC.EllipseRect = this.DrawInfra.RectCreate(0, 0, this.MathInt(100), this.MathInt(50));
        viewC.Face = face;
        viewC.Text = text;
        viewC.TextAlign = align;
        viewC.TextPen = textPen;
        return viewC;
    }

    private bool ViewCFinal(ViewC a)
    {
        DrawBrush textPen;
        textPen = a.TextPen;
        DrawBrush ellipseBrush;
        ellipseBrush = a.EllipseBrush;
        DrawBrush brush;
        brush = a.Back;
        DrawGradient gradient;
        gradient = brush.Polate;
        DrawGradientStop gradientStop;
        gradientStop = gradient.Stop;
        DrawGradientLinear gradientLinear;
        gradientLinear = gradient.Linear;

        DrawFace font;
        font = a.Face;

        this.TextPenFinal(textPen);

        this.FaceFinal(font);

        this.EllipseBrushFinal(ellipseBrush);

        brush.Final();

        gradient.Final();

        gradientStop.Final();

        gradientLinear.Final();
        return true;
    }

    private bool GradientStopSetPoint(DrawGradientStop stop, DrawGradientStopPoint aa, long index, long pos, DrawColor color)
    {
        aa.Pos = pos;
        aa.Color = color;
        stop.PointSet(index, aa);
        return true;
    }

    private DrawBrush TextPenCreate()
    {
        DrawBrush a;
        a = new DrawBrush();
        a.Kind = this.BrushKindList.Color;
        a.Color = this.DrawInfra.ColorCreate(0xff, 0, 0, 0xff);
        a.Line = this.BrushLineList.DashDotDot;
        a.Wed = this.MathInt(14);
        a.Cap = this.BrushCapList.Round;
        a.Join = this.BrushJoinList.Bevel;
        a.Init();
        return a;
    }

    private bool TextPenFinal(DrawBrush a)
    {
        a.Final();
        return true;
    }

    private Play PlayCreate()
    {
        VideoFrameState frameState;
        frameState = new VideoFrameState();
        frameState.Init();
        frameState.Demo = this;

        VideoOut videoOut;
        videoOut = new VideoOut();
        videoOut.Init();
        videoOut.FrameState = frameState;

        long scaleFactor;        
        scaleFactor = 1 << 20;

        long volume;
        volume = this.MathValue(scaleFactor / 8, -20);

        AudioOut audioOut;
        audioOut = new AudioOut();
        audioOut.Init();
        audioOut.Volume = volume;

        Play a;
        a = new Play();
        a.Init();
        a.Source = this.S("MiraiDemoData/Video.mp4");
        a.SourceSet();
        a.VideoOut = videoOut;
        a.AudioOut = audioOut;
        a.VideoOutSet();
        a.AudioOutSet();
        return a;
    }

    private bool PlayFinal(Play a)
    {
        VideoOut videoOut;
        videoOut = a.VideoOut;

        AudioOut audioOut;
        audioOut = a.AudioOut;

        a.Final();

        audioOut.Final();

        videoOut.Final();
        return true;
    }

    private DrawImage PlayImageCreate()
    {
        DrawImage a;
        a = new DrawImage();
        a.Init();
        return a;
    }

    private bool PlayImageFinal(DrawImage a)
    {
        a.Final();
        return true;
    }

    public virtual Demo Add(String a)
    {
        this.InfraInfra.AddString(this.StringAdd, a);
        return this;
    }

    public virtual Demo AddLine()
    {
        return this.Add(this.TextInfra.NewLine);
    }

    public virtual Demo AddS(string o)
    {
        this.Add(this.S(o));
        return this;
    }

    public virtual Demo AddClear()
    {
        this.StringAdd.Clear();
        return this;
    }

    public virtual String AddResult()
    {
        return this.StringAdd.Result();
    }

    public virtual String S(string o)
    {
        return this.TextInfra.S(o);
    }

    public virtual long MathInt(long n)
    {
        MathInfra mathInfra;
        mathInfra = this.MathInfra;

        MathComp mathComp;
        mathComp = this.MathComp;

        long a;
        a = mathInfra.Int(mathComp, n);
        return a;
    }

    public virtual long MathValue(long cand, long expo)
    {
        MathComp mathComp;
        mathComp = this.MathComp;

        mathComp.Cand = cand;
        mathComp.Expo = expo;

        long a;
        a = this.Math.Value(mathComp);
        return a;
    }
}