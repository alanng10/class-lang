namespace Avalon.Text;

public class StringLess : InfraLess
{
    public override bool Init()
    {
        base.Init();
        this.StringComp = StringComp.This;
        return true;
    }

    public virtual LessInt CharLess { get; set; }
    public virtual Form LiteCharForm { get; set; }
    public virtual Form RiteCharForm { get; set; }
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

        Form liteCharForm;
        Form riteCharForm;
        liteCharForm = this.LiteCharForm;
        riteCharForm = this.RiteCharForm;

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
            long oca;
            long ocb;
            oca = stringComp.Char(liteString, i);
            ocb = stringComp.Char(riteString, i);

            oca = liteCharForm.Execute(oca);
            ocb = riteCharForm.Execute(ocb);

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