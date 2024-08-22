namespace Avalon.Infra;

public class StringLess : Less
{
    public override bool Init()
    {
        base.Init();
        this.StringComp = StringComp.This;
        return true;
    }

    public virtual LessInt CharLess { get; set; }
    public virtual CharForm LeftCharForm { get; set; }
    public virtual CharForm RightCharForm { get; set; }
    protected virtual StringComp StringComp { get; set; }

    public override long Execute(object lite, object rite)
    {
        StringComp stringComp;
        stringComp = this.StringComp;

        String liteString;
        String riteString;
        liteString = (String)lite;
        riteString = (String)rite;

        long liteCount;
        long riteCount;
        liteCount = stringComp.Count(liteString);
        riteCount = stringComp.Count(riteString);

        LessInt charLess;
        charLess = this.CharLess;

        CharForm liteCharForm;
        CharForm riteCharForm;
        liteCharForm = this.LeftCharForm;
        riteCharForm = this.RightCharForm;

        long count;
        count = liteCount;
        if (riteCount < count)
        {
            count = riteCount;
        }

        long i;
        i = 0;
        while (i < count)
        {
            uint oca;
            uint ocb;
            oca = (uint)stringComp.Char(liteString, i);
            ocb = (uint)stringComp.Char(riteString, i);

            oca = (uint)liteCharForm.Execute(oca);
            ocb = (uint)riteCharForm.Execute(ocb);

            long oo;
            oo = charLess.Execute(oca, ocb);
            if (!(oo == 0))
            {
                return oo;
            }

            i = i + 1;
        }

        long k;
        k = liteCount - riteCount;
        
        long a;
        a = 0;
        if (k < 0)
        {
            a = -1;
        }

        if (0 < k)
        {
            a = 1;
        }
        return a;
    }
}