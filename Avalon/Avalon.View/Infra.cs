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
        a.Pos.Col = rect.Pos.Col;
        a.Pos.Row = rect.Pos.Row;
        a.Size = new DrawSize();
        a.Size.Init();
        a.Size.Wed = rect.Size.Wed;
        a.Size.Het = rect.Size.Het;
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
        dest.Col = source.Col;
        dest.Row = source.Row;
        return true;
    }

    public virtual bool AssignDrawSizeValue(DrawSize dest, DrawSize source)
    {
        dest.Wed = source.Wed;
        dest.Het = source.Het;
        return true;
    }

    public virtual bool StackPushChild(DrawDraw draw, DrawRect stackRect, DrawPos stackPos, DrawRect rect, DrawPos pos)
    {
        this.AssignDrawPosValue(pos, rect.Pos);

        this.AssignDrawRectValue(stackRect, draw.Area);

        this.DrawInfra.BoundArea(stackRect, rect);

        this.AssignDrawRectValue(draw.Area, rect);

        draw.AreaSet();

        this.AssignDrawPosValue(stackPos, draw.Pos);

        this.AssignDrawPosValue(draw.Pos, pos);

        draw.PosSet();
        return true;
    }

    public virtual bool StackPopChild(DrawDraw draw, DrawRect stackRect, DrawPos stackPos)
    {
        this.AssignDrawPosValue(draw.Pos, stackPos);

        draw.PosSet();

        this.AssignDrawRectValue(draw.Area, stackRect);

        draw.AreaSet();
        return true;
    }

    public virtual Count CountCreate(long value)
    {
        Count a;
        a = new Count();
        a.Init();
        a.Value = value;
        return a;
    }
}