class Math : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.Extern : share Extern;
        this.Intern : 0;
        return true;
    }

    field private Extern Extern { get { return data; } set { data : value; } }
    field private Int Intern { get { return data; } set { data : value; } }

    maide prusate Int Value(var Comp comp)
    {
        var Int cand;
        cand : comp.Cand;
        var Int expo;
        expo : comp.Expo;

        var Int a;
        a : this.Extern.Math_Value(this.Intern, cand, expo);

        return a;
    }

    maide prusate Int ValueTen(var Comp comp)
    {
        var Int cand;
        cand : comp.Cand;
        var Int expoTen;
        expoTen : comp.Expo;

        var Int a;
        a : this.Extern.Math_ValueTen(this.Intern, cand, expoTen);
        return a;
    }

    maide prusate Bool Comp(var Comp result, var Int value)
    {
        var Int ka;
        ka : value;
        ka : bit <(ka, 10);
        ka : bit >(ka, 10);

        var Int kb;
        kb : value;
        kb : bit >>(kb, 50);

        result.Cand : ka;
        result.Expo : kb;
        return true;
    }

    maide prusate Bool Less(var Int valueA, var Int valueB)
    {
        var Int u;
        u : this.Extern.Math_Less(this.Intern, valueA, valueB);

        inf (u = null)
        {
            return null;
        }

        var Bool k;
        k : ~(u = 0);

        var Bool a;
        a : k;
        return a;
    }

    maide prusate Int Add(var Int valueA, var Int valueB)
    {
        var Int u;
        u : this.Extern.Math_Add(this.Intern, valueA, valueB);
        var Int a;
        a : u;
        return a;
    }

    maide prusate Int Sub(var Int valueA, var Int valueB)
    {
        var Int u;
        u : this.Extern.Math_Sub(this.Intern, valueA, valueB);
        var Int a;
        a : u;
        return a;
    }

    maide prusate Int Mul(var Int valueA, var Int valueB)
    {
        var Int u;
        u : this.Extern.Math_Mul(this.Intern, valueA, valueB);
        var Int a;
        a : u;
        return a;
    }

    maide prusate Int Div(var Int valueA, var Int valueB)
    {
        var Int u;
        u : this.Extern.Math_Div(this.Intern, valueA, valueB);
        var Int a;
        a : u;
        return a;
    }

    maide prusate Int Abs(var Int value)
    {
        var Int u;
        u : this.Extern.Math_Abs(this.Intern, value);
        var Int a;
        a : u;
        return a;
    }

    maide prusate Int Exp(var Int value)
    {
        var Int u;
        u : this.Extern.Math_Exp(this.Intern, value);
        var Int a;
        a : u;
        return a;
    }

    maide prusate Int Exp2(var Int value)
    {
        var Int u;
        u : this.Extern.Math_Exp2(this.Intern, value);
        var Int a;
        a : u;
        return a;
    }

    maide prusate Int Log(var Int value)
    {
        var Int u;
        u : this.Extern.Math_Log(this.Intern, value);
        var Int a;
        a : u;
        return a;
    }

    maide prusate Int Log10(var Int value)
    {
        var Int u;
        u : this.Extern.Math_Log10(this.Intern, value);
        var Int a;
        a : u;
        return a;
    }

    maide prusate Int Log2(var Int value)
    {
        var Int u;
        u : this.Extern.Math_Log2(this.Intern, value);
        var Int a;
        a : u;
        return a;
    }

    maide prusate Int Pow(var Int valueA, var Int valueB)
    {
        var Int u;
        u : this.Extern.Math_Pow(this.Intern, valueA, valueB);
        var Int a;
        a : u;
        return a;
    }

    maide prusate Int Ceil(var Int value)
    {
        var Int u;
        u : this.Extern.Math_Ceil(this.Intern, value);
        var Int a;
        a : u;
        return a;
    }

    maide prusate Int Floor(var Int value)
    {
        var Int u;
        u : this.Extern.Math_Floor(this.Intern, value);
        var Int a;
        a : u;
        return a;
    }

    maide prusate Int Trunc(var Int value)
    {
        var Int u;
        u : this.Extern.Math_Trunc(this.Intern, value);
        var Int a;
        a : u;
        return a;
    }

    maide prusate Int Round(var Int value)
    {
        var Int u;
        u : this.Extern.Math_Round(this.Intern, value);
        var Int a;
        a : u;
        return a;
    }

    maide prusate Int Sin(var Int value)
    {
        var Int u;
        u : this.Extern.Math_Sin(this.Intern, value);
        var Int a;
        a : u;
        return a;
    }

    maide prusate Int Cos(var Int value)
    {
        var Int u;
        u : this.Extern.Math_Cos(this.Intern, value);
        var Int a;
        a : u;
        return a;
    }

    maide prusate Int Tan(var Int value)
    {
        var Int u;
        u : this.Extern.Math_Tan(this.Intern, value);
        var Int a;
        a : u;
        return a;
    }

    maide prusate Int ASin(var Int value)
    {
        var Int u;
        u : this.Extern.Math_ASin(this.Intern, value);
        var Int a;
        a : u;
        return a;
    }

    maide prusate Int ACos(var Int value)
    {
        var Int u;
        u : this.Extern.Math_ACos(this.Intern, value);
        var Int a;
        a : u;
        return a;
    }

    maide prusate Int ATan(var Int value)
    {
        var Int u;
        u : this.Extern.Math_ATan(this.Intern, value);
        var Int a;
        a : u;
        return a;
    }

    maide prusate Int SinH(var Int value)
    {
        var Int u;
        u : this.Extern.Math_SinH(this.Intern, value);
        var Int a;
        a : u;
        return a;
    }

    maide prusate Int CosH(var Int value)
    {
        var Int u;
        u : this.Extern.Math_CosH(this.Intern, value);
        var Int a;
        a : u;
        return a;
    }

    maide prusate Int TanH(var Int value)
    {
        var Int u;
        u : this.Extern.Math_TanH(this.Intern, value);
        var Int a;
        a : u;
        return a;
    }

    maide prusate Int ASinH(var Int value)
    {
        var Int u;
        u : this.Extern.Math_ASinH(this.Intern, value);
        var Int a;
        a : u;
        return a;
    }

    maide prusate Int ACosH(var Int value)
    {
        var Int u;
        u : this.Extern.Math_ACosH(this.Intern, value);
        var Int a;
        a : u;
        return a;
    }

    maide prusate Int ATanH(var Int value)
    {
        var Int u;
        u : this.Extern.Math_ATanH(this.Intern, value);
        var Int a;
        a : u;
        return a;
    }
}