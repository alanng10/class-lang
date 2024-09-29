namespace Avalon.Tune;

public class Tune : Any
{
    public override bool Init()
    {
        base.Init();
        this.MathInfra = MathInfra.This;

        this.Math = new MathMath();
        this.Math.Init();
        this.MathComp = new MathComp();
        this.MathComp.Init();
        // this.Intern = Extern.Tune_New();
        // Extern.Tune_Init(this.Intern);
        return true;
    }

    public virtual bool Final()
    {
        // Extern.Tune_Final(this.Intern);
        // Extern.Tune_Delete(this.Intern);
        return true;
    }

    public virtual ulong Out { get; set; }

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
            // Extern.Tune_CompSet(this.Intern, uu);
        }
    }

    protected virtual Comp CompData { get; set; }

    public virtual Form Form
    {
        get
        {
            return this.FormData;
        }
        set
        {
            this.FormData = value;

            ulong u;
            u = 0;
            if (!(this.FormData == null))
            {
                u = this.FormData.Intern;
            }
            // Extern.Tune_FormSet(this.Intern, u);
        }
    }

    protected virtual Form FormData { get; set; }

    protected virtual MathInfra MathInfra { get; set; }
    protected virtual MathMath Math { get; set; }
    protected virtual MathComp MathComp { get; set; }
    private ulong Intern { get; set; }

    public virtual bool Start()
    {
        // Extern.Tune_Start(this.Intern);
        return true;
    }

    public virtual bool End()
    {
        // Extern.Tune_End(this.Intern);
        return true;
    }

    public virtual bool Clear()
    {
        // Extern.Tune_Clear(this.Intern);
        return true;
    }

    public virtual bool ExecuteWave(long waveCount, long amplitude, long destIndex, Range sourceRange)
    {
        return true;
    }

    public virtual bool ExecuteAudio(AudioAudio audio, Range destRange, Range sourceRange)
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
}