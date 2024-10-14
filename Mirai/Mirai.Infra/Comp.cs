namespace Mirai.Infra;

public class Comp : Any
{
    public override bool Init()
    {
        base.Init();
        this.MathInfra = MathInfra.This;
        this.ViewInfra = Infra.This;
        this.Math = MathMath.This;

        this.ModEvent = this.CreateModEvent();
        this.ModArg = this.CreateModArg();
        this.MathComp = this.CreateMathComp();
        return true;
    }

    public virtual Mod ModArg { get; set; }
    public virtual EventEvent ModEvent { get; set; }
    protected virtual MathInfra MathInfra { get; set; }
    protected virtual Infra ViewInfra { get; set; }
    protected virtual MathMath Math { get; set; }
    protected virtual MathComp MathComp { get; set; }

    protected virtual EventEvent CreateModEvent()
    {
        EventEvent a;
        a = new EventEvent();
        a.Init();
        return a;
    }

    protected virtual Mod CreateModArg()
    {
        Mod a;
        a = new Mod();
        a.Init();
        return a;
    }

    protected virtual MathComp CreateMathComp()
    {
        MathComp a;
        a = new MathComp();
        a.Init();
        return a;
    }

    public virtual bool Mod(Field varField, Mod mod)
    {
        return true;
    }

    protected virtual bool Event(Field varField)
    {
        this.ModArg.Comp = this;
        this.ModArg.Field = varField;
        this.ModEvent.Execute(this.ModArg);
        return true;
    }

    protected virtual long MathInt(long n)
    {
        MathInfra mathInfra;
        mathInfra = this.MathInfra;

        MathComp mathComp;
        mathComp = this.MathComp;

        long a;
        a = mathInfra.Int(mathComp, n);
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