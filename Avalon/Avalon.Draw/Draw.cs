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
        
        this.Math = new MathMath();
        this.Math.Init();
        this.MathComp = new MathComp();
        this.MathComp.Init();

        this.PosA = new Pos();
        this.PosA.Init();
        this.WorldForm = new Form();
        this.WorldForm.Init();

        this.InternRangeA = this.InternInfra.RangeCreate();
        this.InternRectA = this.InternInfra.RectCreate();
        this.InternRectB = this.InternInfra.RectCreate();
        this.InternPosA = this.InternInfra.PosCreate();
        this.InternPosB = this.InternInfra.PosCreate();

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

        this.InternInfra.PosDelete(this.InternPosB);
        this.InternInfra.PosDelete(this.InternPosA);
        this.InternInfra.RectDelete(this.InternRectB);
        this.InternInfra.RectDelete(this.InternRectA);
        this.InternInfra.RangeDelete(this.InternRangeA);

        this.WorldForm.Final();
        return true;
    }

    public virtual ulong Out { get; set; }
    public virtual Size Size { get; set; }

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
    protected virtual Pos PosA { get; set; }
    protected virtual long TextCount { get; set; }
    private ulong Intern { get; set; }
    private ulong InternFillPos { get; set; }
    private ulong InternArea { get; set; }
    private ulong InternSize { get; set; }
    private ulong InternPosB { get; set; }
    private ulong InternPosA { get; set; }
    private ulong InternRectB { get; set; }
    private ulong InternRectA { get; set; }
    private ulong InternRangeA { get; set; }
    private ulong InternText { get; set; }
    private ulong InternTextData { get; set; }

    public virtual bool Start()
    {
        Extern.Draw_OutSet(this.Intern, this.Out);
        Extern.Draw_Start(this.Intern);

        this.Comp = null;
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
        w = (ulong)(this.Size.Wed);
        h = (ulong)(this.Size.Het);
        Extern.Size_WedSet(this.InternSize, w);
        Extern.Size_HetSet(this.InternSize, h);
        return true;
    }

    protected virtual bool FillPosSet(long col, long row)
    {
        this.InternInfra.PosSet(this.InternFillPos, col, row);

        Extern.Draw_FillPosThisSet(this.Intern);
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

        if (!(this.FormA == null))
        {
            this.WorldForm.Mul(this.FormA);
        }

        this.FormA = null;

        Extern.Draw_FormSet(this.Intern, this.WorldForm.Intern);
        return true;
    }

    protected virtual bool WorldFormPosOffsetSet(Pos pos)
    {
        long col;
        long row;
        col = pos.Col;
        row = pos.Row;

        this.WorldForm.Pos(col, row, 0);
        return true;
    }
    
    public virtual bool Clear(Color color)
    {
        ulong colorU;
        colorU = this.DrawInfra.InternColor(color);

        Extern.Draw_Clear(this.Intern, colorU);
        return true;
    }

    public virtual bool ExecuteVideo(VideoVideo image, Rect destRect, Rect sourceRect)
    {
        this.InternRectSetFromRect(this.InternRectA, destRect);
        this.InternRectSetFromRect(this.InternRectB, sourceRect);

        Extern.Draw_ExecuteImage(this.Intern, image.Ident, this.InternRectA, this.InternRectB);
        return true;
    }

    public virtual bool ExecuteQuad(Array quad, Array brush, Range quadRange, long brushIndex)
    {
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

    protected virtual long MathValue(long cand, long expo)
    {
        MathComp mathComp;
        mathComp = this.MathComp;

        mathComp.Cand = cand;
        mathComp.Expo = expo;

        long a;
        a = this.Math.Value(mathComp);
        return a;
    }

    private bool InternRangeSetFromRange(ulong internRange, Range range)
    {
        this.InternInfra.RangeSet(internRange, range.Index, range.Count);
        return true;
    }

    private bool InternPosSetFromPos(ulong internPos, Pos pos)
    {
        this.InternInfra.PosSet(internPos, pos.Col, pos.Row);
        return true;
    }

    private bool InternRectSetFromRect(ulong internRect, Rect rect)
    {
        Pos pos;
        Size size;
        pos = rect.Pos;
        size = rect.Size;
        this.InternInfra.RectSet(internRect, pos.Col, pos.Row, size.Wed, size.Het);
        return true;
    }
}