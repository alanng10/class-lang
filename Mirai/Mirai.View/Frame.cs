namespace Mirai.View;

public class Frame : FrameFrame
{
    public override bool Init()
    {
        base.Init();
        this.ViewInfra = ViewInfra.This;
        return true;
    }

    protected virtual ViewInfra ViewInfra { get; set; }

    public virtual View View { get; set; }

    protected override bool ExecuteDraw()
    {
        DrawDraw draw;
        draw = this.Draw;

        draw.Start();

        draw.Clear(this.DrawClearColor);

        if (this.ValidDrawView())
        {
            this.ExecuteDrawView(draw);
        }

        draw.End();
        return true;
    }

    protected virtual bool ValidDrawView()
    {
        return !(this.View == null);
    }

    protected virtual bool ExecuteDrawView(DrawDraw draw)
    {
        this.View.ExecuteDraw(draw);
        return true;
    }
}