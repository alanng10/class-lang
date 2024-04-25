namespace Avalon.View;

public class Infra : Any
{
    public static Infra This { get; } = ShareCreate();

    private static Infra ShareCreate()
    {
        Infra share;
        share = new Infra();
        Any a;
        a = share;
        a.Init();
        return share;
    }

    public override bool Init()
    {
        base.Init();
        this.DrawInfra = DrawInfra.This;

        FrameTypeMaide maideA;
        maideA = new FrameTypeMaide(Frame.InternType);
        this.FrameTypeMaideAddress = new MaideAddress();
        this.FrameTypeMaideAddress.Delegate = maideA;
        this.FrameTypeMaideAddress.Init();
        FrameDrawMaide maideB;
        maideB = new FrameDrawMaide(Frame.InternDraw);
        this.FrameDrawMaideAddress = new MaideAddress();
        this.FrameDrawMaideAddress.Delegate = maideB;
        this.FrameDrawMaideAddress.Init();
        return true;
    }

    protected virtual DrawInfra DrawInfra { get; set; }

    internal virtual MaideAddress FrameTypeMaideAddress { get; set; }
    internal virtual MaideAddress FrameDrawMaideAddress { get; set; }

    internal virtual DrawRect DrawRect(Rect rect)
    {
        DrawRect a;
        a = new DrawRect();
        a.Init();
        a.Pos = new DrawPos();
        a.Pos.Init();
        a.Pos.Left = rect.Pos.Left;
        a.Pos.Up = rect.Pos.Up;
        a.Size = new DrawSize();
        a.Size.Init();
        a.Size.Width = rect.Size.Width;
        a.Size.Height = rect.Size.Height;
        return a;
    }

    public virtual Field FieldCreate(CompComp comp)
    {
        Field a;
        a = new Field();
        a.Init();
        a.Comp = comp;
        a.State = new FieldState();
        a.State.Init();
        a.State.Field = a;
        a.SetChangeArg = new Change();
        a.SetChangeArg.Init();
        return a;
    }

    public virtual bool AssignDrawRectValue(DrawRect dest, DrawRect source)
    {
        this.AssignDrawPosValue(dest.Pos, source.Pos);
        this.AssignDrawSizeValue(dest.Size, source.Size);
        return true;
    }

    public virtual bool AssignDrawPosValue(DrawPos dest, DrawPos source)
    {
        dest.Left = source.Left;
        dest.Up = source.Up;
        return true;
    }

    public virtual bool AssignDrawSizeValue(DrawSize dest, DrawSize source)
    {
        dest.Width = source.Width;
        dest.Height = source.Height;
        return true;
    }

    public virtual bool StackPushChild(DrawDraw draw, DrawRect stackRect, DrawPos stackPos, DrawRect rect, DrawPos pos)
    {
        this.AssignDrawPosValue(pos, rect.Pos);

        this.AssignDrawRectValue(stackRect, draw.Area);

        this.DrawInfra.BoundArea(stackRect, rect);

        this.AssignDrawRectValue(draw.Area, rect);

        draw.SetArea();

        this.AssignDrawPosValue(stackPos, draw.Pos);

        this.AssignDrawPosValue(draw.Pos, pos);

        draw.SetPos();
        return true;
    }

    public virtual bool StackPopChild(DrawDraw draw, DrawRect stackRect, DrawPos stackPos)
    {
        this.AssignDrawPosValue(draw.Pos, stackPos);

        draw.SetPos();

        this.AssignDrawRectValue(draw.Area, stackRect);

        draw.SetArea();
        return true;
    }








    public virtual GridCol GridColCreate(int width)
    {
        GridCol a;

        a = new GridCol();

        a.Init();


        a.Width = width;


        return a;
    }




    public virtual GridRow GridRowCreate(int height)
    {
        GridRow a;

        a = new GridRow();

        a.Init();


        a.Height = height;


        return a;
    }
}