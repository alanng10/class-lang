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
        console.Out.Write("ThreadState.Execute START\n");

        this.Demo.ExecuteDemoThisThread();

        StorageInfra infra;
        infra = StorageInfra.This;

        string a;
        a = infra.TextRead("DemoData/ThreadRead.txt");
        console.Out.Write("ThreadRead.txt text: \n" + a + "\n");

        string writeFilePath;
        writeFilePath = "DemoData/ThreadWrite.txt";
        File.Delete(writeFilePath);

        bool b;        
        b = infra.TextWrite(writeFilePath, "阿 了 水 GR 8 &\nEu #@ ?\n卡");
        if (!b)
        {
            console.Out.Write("ThreadWrite.txt write error\n");
        }
        if (b)
        {
            a = infra.TextRead(writeFilePath);
            console.Out.Write("ThreadWrite.txt text: \n" + a + "\n");
        }

        ThreadThis varThis;
        varThis = new ThreadThis();
        varThis.Init();

        console.Out.Write("ThreadState.Execute ThreadThis Wait START\n");

        varThis.Wait(2 * 1000);

        console.Out.Write("ThreadState.Execute ThreadThis Wait END\n");

        this.Phore.Release();
        
        this.Draw();

        Value aa;
        aa = new Value();
        aa.Init();
        aa.Mid = 0x10000;

        this.Result = aa;

        console.Out.Write("ThreadState.Execute END\n");
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

        int left;
        int up;
        int width;
        int height;
        left = 20;
        up = 20;
        width = this.Image.Size.Width - 50;
        height = this.Image.Size.Height - 50;

        DrawRectInt rectA;
        rectA = drawInfra.RectIntCreate(this.MathInt(left), this.MathInt(up), this.MathInt(width), this.MathInt(height));

        DrawDraw draw;
        draw = new DrawDraw();
        draw.Init();
        draw.Out = this.Image.Out;
        draw.Size.Width = this.Image.Size.Width;
        draw.Size.Height = this.Image.Size.Height;
        draw.SizeSet();
        
        draw.Start();
        draw.Pen = null;
        draw.Fill = brush;
        draw.ExecuteRect(rectA);

        int w;
        w = width;
        w = w - 40;

        int h;
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
}