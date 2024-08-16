namespace Demo;

class ThreadState : State
{
    public override bool Init()
    {
        base.Init();
        this.MathInfra = MathInfra.This;
        this.Math = new MathMath();
        this.Math.Init();
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

        this.Demo.ExecuteDemoThisThread();

        StorageInfra infra;
        infra = StorageInfra.This;

        String a;
        a = infra.TextRead(this.S("DemoData/ThreadRead.txt"));

        String ka;

        ka = this.AddClear().AddS("ThreadRead.txt text: \n").Add(a).AddS("\n").AddResult();

        console.Out.Write(ka);

        string writeFilePath;
        writeFilePath = "DemoData/ThreadWrite.txt";
        File.Delete(writeFilePath);

        String kkka;
        kkka = this.S(writeFilePath);

        bool b;        
        b = infra.TextWrite(kkka, this.S("阿 了 水 GR 8 &\nEu #@ ?\n卡"));
        if (!b)
        {
            console.Out.Write(this.S("ThreadWrite.txt write error\n"));
        }
        if (b)
        {
            a = infra.TextRead(kkka);

            ka = this.AddClear().AddS("ThreadWrite.txt text: \n").Add(a).AddS("\n").AddResult();
        }

        ThreadThis varThis;
        varThis = new ThreadThis();
        varThis.Init();

        console.Out.Write(this.S("ThreadState.Execute ThreadThis Wait START\n"));

        varThis.Wait(2 * 1000);

        console.Out.Write(this.S("ThreadState.Execute ThreadThis Wait END\n"));

        this.Phore.Release();
        
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
        long width;
        long height;
        left = 20;
        up = 20;
        width = this.Image.Size.Width - 50;
        height = this.Image.Size.Height - 50;

        DrawRect rectA;
        rectA = drawInfra.RectCreate(this.MathInt(left), this.MathInt(up), this.MathInt(width), this.MathInt(height));

        DrawDraw draw;
        draw = new DrawDraw();
        draw.Init();
        draw.Out = this.Image.Out;
        draw.Size.Width = this.Image.Size.Width;
        draw.Size.Height = this.Image.Size.Height;
        draw.SizeSet();
        
        draw.Start();
        draw.Stroke = null;
        draw.Fill = brush;
        draw.ExecuteRect(rectA);

        long w;
        w = width;
        w = w - 40;

        long h;
        h = height;
        h = h - 40;

        rectA.Size.Width = this.MathInt(w);
        rectA.Size.Height = this.MathInt(h);

        draw.Fill = brushA;
        draw.Comp = compList.DestinationOut;
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

        MathMath math;
        math = this.Math;

        MathComp mathComp;
        mathComp = this.MathComp;

        long a;
        a = mathInfra.Int(math, mathComp, n);
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