namespace Demo;

class ThreadState : State
{
    public override bool Init()
    {
        base.Init();
        this.MathInfra = MathInfra.This;
        this.Math = MathMath.This;
        this.MathComp = new MathComp();
        this.MathComp.Init();
        return true;
    }

    public Demo Demo { get; set; }
    public DrawImage Image { get; set; }
    public ThreadPhore Phore { get; set; }
    protected virtual MathInfra MathInfra { get; set; }
    protected virtual MathMath Math { get; set; }
    protected virtual MathComp MathComp { get; set; }

    public override bool Execute()
    {
        Console console;
        console = Console.This;
        console.Out.Write(this.S("ThreadState.Execute START\n"));

        ThreadThis varThis;
        varThis = new ThreadThis();
        varThis.Init();

        console.Out.Write(this.S("ThreadState.Execute ThreadThis Wait START\n"));

        varThis.Wait(2 * 1000);

        console.Out.Write(this.S("ThreadState.Execute ThreadThis Wait END\n"));

        this.Phore.Close();
        
        this.Draw();

        Value aa;
        aa = new Value();
        aa.Init();
        aa.Int = 0x10000;

        this.Result = aa;

        console.Out.Write(this.S("ThreadState.Execute END\n"));
        return true;
    }

    private bool Draw()
    {
        DrawBrushKindList brushKindList;
        brushKindList = DrawBrushKindList.This;
        DrawCompList compList;
        compList = DrawCompList.This;
        DrawInfra drawInfra;
        drawInfra = DrawInfra.This;

        DrawBrush brush;
        brush = new DrawBrush();
        brush.Kind = brushKindList.Color;
        brush.Color = drawInfra.ColorCreate(0xff, 0xff, 0xff, 0);
        brush.Init();

        DrawBrush brushA;
        brushA = new DrawBrush();
        brushA.Kind = brushKindList.Color;
        brushA.Color = drawInfra.ColorCreate(0xff, 0, 0, 0);
        brushA.Init();

        long left;
        long up;
        long wed;
        long het;
        left = 20;
        up = 20;
        wed = this.Image.Size.Wed - 50;
        het = this.Image.Size.Het - 50;

        DrawRect rectA;
        rectA = drawInfra.RectCreate(this.MathInt(left), this.MathInt(up), this.MathInt(wed), this.MathInt(het));

        DrawDraw draw;
        draw = new DrawDraw();
        draw.Init();
        draw.Out = this.Image.Out;
        draw.Size.Wed = this.Image.Size.Wed;
        draw.Size.Het = this.Image.Size.Het;
        draw.SizeSet();
        
        draw.Start();
        draw.Line = null;
        draw.Fill = brush;
        draw.ExecuteRect(rectA);

        draw.Fill = null;

        long w;
        w = wed;
        w = w - 40;

        long h;
        h = het;
        h = h - 40;

        rectA.Size.Wed = this.MathInt(w);
        rectA.Size.Het = this.MathInt(h);

        Text text;
        text = this.Demo.TextInfra.TextCreateStringData(this.S("C hr"), null);

        DrawTextAlign textAlign;
        textAlign = new DrawTextAlign();
        textAlign.Init();
        textAlign.Horiz = 1;
        textAlign.Vert = 1;

        DrawSlash slash;
        slash = new DrawSlash();
        slash.Brush = brushA;
        slash.Line = this.Demo.SlashLineList.DashDotDot;
        slash.Cap = this.Demo.SlashCapList.Round;
        slash.Join = this.Demo.SlashJoinList.Miter;
        slash.Wed = this.MathInt(5);
        slash.Init();

        DrawFace face;
        face = new DrawFace();
        face.Name = this.Demo.DrawInfra.Font.Name;
        face.Size = 38;
        face.Weight = 700;
        face.Italic = false;
        face.Overline = false;
        face.Underline = false;
        face.Strikeout = false;
        face.Init();

        draw.Face = face;
        draw.Line = slash;
        draw.Comp = compList.DestOut;
        draw.ExecuteText(text, textAlign, false, rectA);

        draw.End();

        draw.Final();

        face.Final();

        slash.Final();

        brushA.Final();

        brush.Final();
        return true;
    }

    protected virtual long MathInt(long n)
    {
        MathInfra mathInfra;
        mathInfra = this.MathInfra;

        MathComp mathComp;
        mathComp = this.MathComp;

        long a;
        a = mathInfra.Int(mathComp, n);
        return a;
    }

    public virtual ThreadState Add(String a)
    {
        this.Demo.Add(a);
        return this;
    }

    public virtual ThreadState AddS(string o)
    {
        this.Demo.AddS(o);
        return this;
    }

    public virtual ThreadState AddClear()
    {
        this.Demo.AddClear();
        return this;
    }

    public virtual String AddResult()
    {
        return this.Demo.AddResult();
    }

    protected virtual String S(string o)
    {
        return this.Demo.S(o);
    }
}