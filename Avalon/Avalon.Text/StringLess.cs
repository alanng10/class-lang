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
    public virtual Form LiteForm { get; set; }
    public virtual Form RiteForm { get; set; }
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

        Form liteForm;
        Form riteForm;
        liteForm = this.LiteForm;
        riteForm = this.RiteForm;

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
            long na;
            long nb;
            na = stringComp.Char(liteString, i);
            nb = stringComp.Char(riteString, i);

            na = liteForm.Execute(na);
            nb = riteForm.Execute(nb);

            long oo;
            oo = charLess.Execute(na, nb);
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