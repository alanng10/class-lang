namespace Avalon.Draw;

public class Draw : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = InternIntern.This;
        this.InternInfra = InternInfra.This;
        this.MathInfra = MathInfra.This;
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
        this.FillPos = new PosInt();
        this.FillPos.Init();
        
        this.Math = new MathMath();
        this.Math.Init();
        this.MathComp = new MathComp();
        this.MathComp.Init();

        this.PosA = new PosInt();
        this.PosA.Init();
        this.WorldForm = new Form();
        this.WorldForm.Init();

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

        this.WorldForm.Final();
        return true;
    }

    public virtual ulong Out { get; set; }
    public virtual Size Size { get; set; }
    public virtual Rect Area { get; set; }
    public virtual Pos Pos { get; set; }
    public virtual PosInt FillPos { get; set; }

    public virtual Brush Fill
    {
        get
        {
            return this.FillData;
        }
        set
        {
            this.FillData = value;

            ulong uu;
            uu = 0;
            if (!(this.FillData == null))
            {
                uu = this.FillData.Intern;
            }
            Extern.Draw_FillSet(this.Intern, uu);
        }
    }

    protected virtual Brush FillData { get; set; }

    public virtual Brush Stroke
    {
        get
        {
            return this.StrokeData;
        }
        set
        {
            this.StrokeData = value;

            ulong uu;
            uu = 0;
            if (!(this.StrokeData == null))
            {
                uu = this.StrokeData.Intern;
            }
            Extern.Draw_StrokeSet(this.Intern, uu);
        }
    }

    protected virtual Brush StrokeData { get; set; }

    public virtual Face Face
    {
        get
        {
            return this.FaceData;
        }
        set
        {
            this.FaceData = value;

            ulong u;
            u = 0;
            if (!(this.FaceData == null))
            {
                u = this.FaceData.Intern;
            }
            Extern.Draw_FaceSet(this.Intern, u);
        }
    }

    protected virtual Face FaceData { get; set; }

    public virtual Comp Comp
    {
        get
        {
            return this.CompData;
        }
        set
        {
            this.CompData = value;

            ulong uu;
            uu = 0;
            if (!(this.CompData == null))
            {
                uu = this.CompData.Intern;
            }
            Extern.Draw_CompSet(this.Intern, uu);
        }
    }

    protected virtual Comp CompData { get; set; }

    public virtual Form Form { get; set; }

    private InternIntern InternIntern { get; set; }
    private InternInfra InternInfra { get; set; }
    protected virtual MathInfra MathInfra { get; set; }
    protected virtual Infra DrawInfra { get; set; }
    protected virtual MathMath Math { get; set; }
    protected virtual MathComp MathComp { get; set; }
    protected virtual Form WorldForm { get; set; }
    protected virtual Form FormA { get; set; }
    protected virtual PosInt PosA { get; set; }
    protected virtual int TextCount { get; set; }
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
        this.PosSet();

        this.Fill = null;
        this.Stroke = null;
        this.Comp = null;
        this.FillPos.Left = 0;
        this.FillPos.Up = 0;
        this.FillPosSet();
        this.Form = null;
        this.FormSet();
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
        this.InternRectSetFromRect(this.InternArea, this.Area);
        Extern.Draw_AreaThisSet(this.Intern);
        return true;
    }

    public virtual bool FillPosSet()
    {
        PosInt k;
        k = this.FillPos;

        long left;
        long up;
        left = k.Left;
        up = k.Up;
        this.InternInfra.PosSet(this.InternFillPos, left, up);

        Extern.Draw_FillPosThisSet(this.Intern);
        return true;
    }

    public virtual bool PosSet()
    {
        Pos k;
        k = this.Pos;

        this.PosA.Left = this.MathInt(k.Left);
        this.PosA.Up = this.MathInt(k.Up);
        this.DrawFormSet();
        return true;
    }

    public virtual bool FormSet()
    {
        this.FormA = this.Form;
        this.DrawFormSet();
        return true;
    }

    protected virtual bool DrawFormSet()
    {
        this.WorldForm.Reset();

        this.WorldFormPosOffsetSet(this.PosA);

        if (!(this.FormA == null))
        {
            this.WorldForm.Multiply(this.FormA);
        }

        Extern.Draw_FormSet(this.Intern, this.WorldForm.Intern);
        return true;
    }

    protected virtual bool WorldFormPosOffsetSet(PosInt pos)
    {
        long left;
        long up;
        left = pos.Left;
        up = pos.Up;

        this.WorldForm.Offset(left, up);
        return true;
    }
    
    public virtual bool Clear(Color color)
    {
        ulong colorU;
        colorU = this.DrawInfra.InternColor(color);

        Extern.Draw_Clear(this.Intern, colorU);
        return true;
    }

    public virtual bool ExecuteRect(RectInt rect)
    {
        this.InternRectSetFromRectInt(this.InternRectA, rect);

        Extern.Draw_ExecuteRect(this.Intern, this.InternRectA);
        return true;
    }

    public virtual bool ExecuteRoundRect(RectInt rect, long horizRadius, long vertRadius)
    {
        this.InternRectSetFromRectInt(this.InternRectA, rect);

        ulong hr;
        ulong vr;
        hr = (ulong)horizRadius;
        vr = (ulong)vertRadius;
        Extern.Draw_ExecuteRoundRect(this.Intern, this.InternRectA, hr, vr);
        return true;
    }

    public virtual bool ExecuteEllipse(RectInt rect)
    {
        this.InternRectSetFromRectInt(this.InternRectA, rect);
        Extern.Draw_ExecuteEllipse(this.Intern, this.InternRectA);
        return true;
    }

    public virtual bool ExecuteImage(Image image, RectInt destRect, RectInt sourceRect)
    {
        this.InternRectSetFromRectInt(this.InternRectA, destRect);
        this.InternRectSetFromRectInt(this.InternRectB, sourceRect);

        Extern.Draw_ExecuteImage(this.Intern, image.Ident, this.InternRectA, this.InternRectB);
        return true;
    }

    public virtual bool ExecuteText(TextText text, RectInt destRect, TextAlign align, bool wordWarp)
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

        this.InternRectSetFromRectInt(this.InternRectA, destRect);

        ulong o;
        o = align.Intern;
        if (wordWarp)
        {
            o = o | this.DrawInfra.InternWordWrap;
        }

        Extern.Draw_ExecuteText(this.Intern, this.InternRectA, o, this.InternText, this.InternRectB);
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

    protected virtual long MathValue(long significand, long exponent)
    {
        MathComp mathComp;
        mathComp = this.MathComp;

        mathComp.Significand = significand;
        mathComp.Exponent = exponent;

        long a;
        a = this.Math.Value(mathComp);
        return a;
    }

    private bool InternRectSetFromRectInt(ulong internRect, RectInt rect)
    {
        PosInt pos;
        SizeInt size;
        pos = rect.Pos;
        size = rect.Size;
        this.InternInfra.RectSetFromRectValue(internRect, pos.Left, pos.Up, size.Width, size.Height);
        return true;
    }

    private bool InternRectSetFromRect(ulong internRect, Rect rect)
    {
        Pos pos;
        Size size;
        pos = rect.Pos;
        size = rect.Size;
        this.InternInfra.RectSetFromRectValue(internRect, pos.Left, pos.Up, size.Width, size.Height);
        return true;
    }
}