namespace Demo;

class ThreadState : ThreadExecuteState
{
    public Demo Demo { get; set; }
    public DrawImage Image { get; set; }
    public ThreadPhore Phore { get; set; }

    public override bool Execute()
    {
        Console console;
        console = Console.This;
        console.Write("ThreadState.Execute START\n");

        this.Demo.ExecuteDemoCurrentThread();

        StorageInfra infra;
        infra = StorageInfra.This;

        string a;
        a = infra.TextRead("DemoData/ThreadRead.txt");
        console.Write("ThreadRead.txt text: \n" + a + "\n");

        string writeFilePath;
        writeFilePath = "DemoData/ThreadWrite.txt";
        File.Delete(writeFilePath);

        bool b;        
        b = infra.TextWrite(writeFilePath, "阿 了 水 GR 8 &\nEu #@ ?\n卡");
        if (!b)
        {
            console.Write("ThreadWrite.txt write error\n");
        }
        if (b)
        {
            a = infra.TextRead(writeFilePath);
            console.Write("ThreadWrite.txt text: \n" + a + "\n");
        }

        ThreadCurrent current;
        current = new ThreadCurrent();
        current.Init();

        console.Write("ThreadState.Execute ThreadCurrent Wait START\n");

        current.Wait(2 * 1000);

        console.Write("ThreadState.Execute ThreadCurrent Wait END\n");

        this.Phore.Release();
        
        this.Draw();

        this.Result = 0x10000;

        console.Write("ThreadState.Execute END\n");
        return true;
    }

    private bool Draw()
    {
        DrawBrushKindList brushKindList;
        brushKindList = DrawBrushKindList.This;
        DrawCompositeList compositeList;
        compositeList = DrawCompositeList.This;
        DrawInfra drawInfra;
        drawInfra = DrawInfra.This;

        DrawBrush brush;
        brush = new DrawBrush();
        brush.Kind = brushKindList.Solid;
        brush.Color = drawInfra.ColorCreate(0xff, 0xff, 0xff, 0);
        brush.Init();

        DrawBrush brushA;
        brushA = new DrawBrush();
        brushA.Kind = brushKindList.Cross;
        brushA.Color = drawInfra.ColorCreate(0xff, 0, 0, 0);
        brushA.Init();

        DrawRect rect;
        rect = drawInfra.RectCreate(20, 20, this.Image.Size.Width - 50, this.Image.Size.Height - 50);

        DrawDraw draw;
        draw = new DrawDraw();
        draw.Init();
        draw.Out = this.Image.Video.Out;
        draw.Size.Width = this.Image.Size.Width;
        draw.Size.Height = this.Image.Size.Height;
        draw.SetSize();
        
        draw.Start();
        draw.Pen = null;
        draw.Brush = brush;
        draw.ExecuteRect(rect);
        draw.Brush = brushA;
        draw.Composite = compositeList.DestinationOut;
        draw.ExecuteRect(rect);
        draw.Composite = null;
        draw.End();

        draw.Final();

        brushA.Final();

        brush.Final();
        return true;
    }
}