namespace Avalon.Draw;

public class Draw : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = InternIntern.This;
        this.InternInfra = InternInfra.This;
        this.DrawInfra = Infra.This;
        this.Size = new Size();
        this.Size.Init();
        this.Area = new Rect();
        this.Area.Init();
        this.Area.Pos = new Pos();
        this.Area.Pos.Init();
        this.Area.Size = new Size();
        this.Area.Size.Init();
        this.Pos = new Pos();
        this.Pos.Init();
        this.FillPos = new Pos();
        this.FillPos.Init();
        this.PosA = new Pos();
        this.PosA.Init();
        this.WorldTransform = new Transform();
        this.WorldTransform.Init();

        this.TextCount = 4096;

        int oa;
        oa = this.TextCount * sizeof(char);
        ulong ou;
        ou = (ulong)oa;
        this.InternTextData = Extern.New(ou);

        this.InternText = Extern.String_New();
        Extern.String_Init(this.InternText);
        Extern.String_CountSet(this.InternText, 0);
        Extern.String_DataSet(this.InternText, this.InternTextData);

        this.InternRectA = this.InternInfra.RectCreate();
        this.InternRectB = this.InternInfra.RectCreate();

        this.InternSize = Extern.Size_New();
        Extern.Size_Init(this.InternSize);

        this.InternArea = this.InternInfra.RectCreate();

        this.InternFillPos = Extern.Pos_New();
        Extern.Pos_Init(this.InternFillPos);

        this.Intern = Extern.Draw_New();
        Extern.Draw_Init(this.Intern);
        Extern.Draw_SizeSet(this.Intern, this.InternSize);
        Extern.Draw_AreaSet(this.Intern, this.InternArea);
        Extern.Draw_FillPosSet(this.Intern, this.InternFillPos);
        return true;
    }

    public virtual bool Final()
    {
        Extern.Draw_Final(this.Intern);
        Extern.Draw_Delete(this.Intern);

        Extern.Pos_Final(this.InternFillPos);
        Extern.Pos_Delete(this.InternFillPos);

        this.InternInfra.RectDelete(this.InternArea);

        Extern.Size_Final(this.InternSize);
        Extern.Size_Delete(this.InternSize);

        this.InternInfra.RectDelete(this.InternRectB);

        this.InternInfra.RectDelete(this.InternRectA);

        Extern.String_Final(this.InternText);
        Extern.String_Delete(this.InternText);

        Extern.Delete(this.InternTextData);

        this.WorldTransform.Final();
        return true;
    }

    public virtual ulong Out { get; set; }
    public virtual Size Size { get; set; }
    public virtual Rect Area { get; set; }
    public virtual Pos Pos { get; set; }
    public virtual Pos FillPos { get; set; }

    public virtual Brush Brush
    {
        get
        {
            return this.BrushData;
        }
        set
        {
            this.BrushData = value;

            ulong uu;
            uu = 0;
            if (!(this.BrushData == null))
            {
                uu = this.BrushData.Intern;
            }
            Extern.Draw_BrushSet(this.Intern, uu);
        }
    }

    protected virtual Brush BrushData { get; set; }

    public virtual Pen Pen
    {
        get
        {
            return this.PenData;
        }
        set
        {
            this.PenData = value;

            ulong uu;
            uu = 0;
            if (!(this.PenData == null))
            {
                uu = this.PenData.Intern;
            }
            Extern.Draw_PenSet(this.Intern, uu);
        }
    }

    protected virtual Pen PenData { get; set; }

    public virtual Font Font
    {
        get
        {
            return this.FontData;
        }
        set
        {
            this.FontData = value;

            ulong u;
            u = 0;
            if (!(this.FontData == null))
            {
                u = this.FontData.Intern;
            }
            Extern.Draw_FontSet(this.Intern, u);
        }
    }

    protected virtual Font FontData { get; set; }

    public virtual Composite Composite
    {
        get
        {
            return this.CompositeData;
        }
        set
        {
            this.CompositeData = value;

            ulong uu;
            uu = 0;
            if (!(this.CompositeData == null))
            {
                uu = this.CompositeData.Intern;
            }
            Extern.Draw_CompositeSet(this.Intern, uu);
        }
    }

    protected virtual Composite CompositeData { get; set; }

    public virtual Transform Transform { get; set; }

    protected virtual Transform WorldTransform { get; set; }
    protected virtual Transform TransformA { get; set; }
    protected virtual Pos PosA { get; set; }
    protected virtual int TextCount { get; set; }

    private InternIntern InternIntern { get; set; }
    private InternInfra InternInfra { get; set; }
    protected virtual Infra DrawInfra { get; set; }
    private ulong Intern { get; set; }
    private ulong InternFillPos { get; set; }
    private ulong InternArea { get; set; }
    private ulong InternSize { get; set; }
    private ulong InternRectB { get; set; }
    private ulong InternRectA { get; set; }
    private ulong InternText { get; set; }
    private ulong InternTextData { get; set; }

    public virtual bool Start()
    {
        Extern.Draw_OutSet(this.Intern, this.Out);
        Extern.Draw_Start(this.Intern);

        Rect area;
        area = this.Area;
        area.Pos.Left = 0;
        area.Pos.Up = 0;
        area.Size.Width = this.Size.Width;
        area.Size.Height = this.Size.Height;
        this.AreaSet();

        Pos pos;
        pos = this.Pos;
        pos.Left = 0;
        pos.Up = 0;
        this.SetPos();

        this.Brush = null;
        this.Pen = null;
        this.Composite = null;
        this.FillPos.Left = 0;
        this.FillPos.Up = 0;
        this.SetFillPos();
        this.Transform = null;
        this.SetTransform();
        return true;
    }

    public virtual bool End()
    {
        Extern.Draw_End(this.Intern);
        return true;
    }

    public virtual bool SizeSet()
    {
        ulong w;
        ulong h;
        w = (ulong)(this.Size.Width);
        h = (ulong)(this.Size.Height);
        Extern.Size_WidthSet(this.InternSize, w);
        Extern.Size_HeightSet(this.InternSize, h);
        return true;
    }

    public virtual bool AreaSet()
    {
        this.SetInternRectFromRect(this.InternArea, this.Area);
        Extern.Draw_AreaThisSet(this.Intern);
        return true;
    }

    public virtual bool SetFillPos()
    {
        int left;
        int up;
        left = this.FillPos.Left;
        up = this.FillPos.Up;
        this.InternInfra.SetPos(this.InternFillPos, left, up);

        Extern.Draw_FillPosThisSet(this.Intern);
        return true;
    }

    public virtual bool SetPos()
    {
        this.PosA.Left = this.Pos.Left;
        this.PosA.Up = this.Pos.Up;
        this.SetDrawTransform();
        return true;
    }

    public virtual bool SetTransform()
    {
        this.TransformA = this.Transform;
        this.SetDrawTransform();
        return true;
    }

    protected virtual bool SetDrawTransform()
    {
        this.WorldTransform.Reset();

        this.SetWorldTransformPosOffset(this.PosA);

        if (!(this.TransformA == null))
        {
            this.WorldTransform.Multiply(this.TransformA);
        }

        Extern.Draw_TransformSet(this.Intern, this.WorldTransform.Intern);
        return true;
    }

    protected virtual bool SetWorldTransformPosOffset(Pos pos)
    {
        long scaleFactor;
        scaleFactor = this.DrawInfra.ScaleFactor;

        long leftL;
        long upL;
        leftL = pos.Left;
        upL = pos.Up;

        long offsetLeft;
        long offsetUp;
        offsetLeft = leftL * scaleFactor;
        offsetUp = upL * scaleFactor;

        this.WorldTransform.Offset(offsetLeft, offsetUp);
        return true;
    }
    
    public virtual bool Clear(Color color)
    {
        ulong colorU;
        colorU = this.DrawInfra.InternColor(color);

        Extern.Draw_Clear(this.Intern, colorU);
        return true;
    }

    public virtual bool ExecuteRect(Rect rect)
    {
        this.SetInternRectFromRect(this.InternRectA, rect);

        Extern.Draw_ExecuteRect(this.Intern, this.InternRectA);
        return true;
    }

    public virtual bool ExecuteRoundRect(Rect rect, long horizRadius, long vertRadius)
    {
        this.SetInternRectFromRect(this.InternRectA, rect);

        ulong hr;
        ulong vr;
        hr = (ulong)horizRadius;
        vr = (ulong)vertRadius;
        Extern.Draw_ExecuteRoundRect(this.Intern, this.InternRectA, hr, vr);
        return true;
    }

    public virtual bool ExecuteEllipse(Rect rect)
    {
        this.SetInternRectFromRect(this.InternRectA, rect);
        Extern.Draw_ExecuteEllipse(this.Intern, this.InternRectA);
        return true;
    }

    public virtual bool ExecuteImage(Image image, Rect destRect, Rect sourceRect)
    {
        this.SetInternRectFromRect(this.InternRectA, destRect);
        this.SetInternRectFromRect(this.InternRectB, sourceRect);

        Extern.Draw_ExecuteImage(this.Intern, image.Video.Ident, this.InternRectA, this.InternRectB);
        return true;
    }

    public virtual bool ExecuteText(TextText text, RectLong destRect, TextAlign align, bool wordWarp)
    {
        int count;
        count = text.Range.Count;
        if (this.TextCount < count)
        {
            return true;
        }
        ulong countU;
        countU = (ulong)count;

        ulong indexU;
        indexU = (ulong)(text.Range.Index);

        this.InternIntern.CopyText(this.InternTextData, text.Data.Value, indexU, countU);

        Extern.String_CountSet(this.InternText, countU);

        this.SetInternRectFromRectLong(this.InternRectA, destRect);

        ulong o;
        o = align.Intern;
        if (wordWarp)
        {
            o = o | this.DrawInfra.InternWordWrap;
        }

        Extern.Draw_ExecuteText(this.Intern, this.InternRectA, o, this.InternText, this.InternRectB);
        return true;
    }

    private bool SetInternRectFromRectLong(ulong internRect, RectLong rect)
    {
        PosLong pos;
        SizeLong size;
        pos = rect.Pos;
        size = rect.Size;
        this.InternInfra.SetRectFromRectValue(internRect, pos.Left, pos.Up, size.Width, size.Height);
        return true;
    }

    private bool SetInternRectFromRect(ulong internRect, Rect rect)
    {
        Pos pos;
        Size size;
        pos = rect.Pos;
        size = rect.Size;
        this.InternInfra.SetRectFromRectValue(internRect, pos.Left, pos.Up, size.Width, size.Height);
        return true;
    }
}