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

        long w;
        w = wed;
        w = w - 40;

        long h;
        h = het;
        h = h - 40;

        rectA.Size.Wed = this.MathInt(w);
        rectA.Size.Het = this.MathInt(h);

        draw.Fill = brushA;
        draw.Comp = compList.DestOut;
        draw.ExecuteRect(rectA);
        draw.Comp = null;
        draw.End();

        draw.Final();

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