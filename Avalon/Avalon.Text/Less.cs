namespace Avalon.Text;

public class Less : InfraLess
{
    public override bool Init()
    {
        base.Init();
        this.TextInfra = Infra.This;
        return true;
    }

    public virtual LessInt CharLess { get; set; }
    public virtual CharForm LiteCharForm { get; set; }
    public virtual CharForm RiteCharForm { get; set; }
    protected virtual Infra TextInfra { get; set; }

    public override long Execute(object lite, object rite)
    {
        Infra textInfra;
        textInfra = this.TextInfra;

        Text liteText;
        Text riteText;
        liteText = (Text)lite;
        riteText = (Text)rite;

        if (!textInfra.ValidRange(liteText))
        {
            return 0;
        }
        if (!textInfra.ValidRange(riteText))
        {
            return 0;
        }

        Data liteData;
        Data riteData;
        liteData = liteText.Data;
        riteData = riteText.Data;

        Range liteRange;
        Range riteRange;
        liteRange = liteText.Range;
        riteRange = riteText.Range;

        long liteIndex;
        long liteCount;
        liteIndex = liteRange.Index;
        liteCount = liteRange.Count;

        long riteIndex;
        long riteCount;
        riteIndex = riteRange.Index;
        riteCount = riteRange.Count;

        LessInt charLess;
        charLess = this.CharLess;

        CharForm liteCharForm;
        CharForm riteCharForm;
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
            uint oca;
            uint ocb;
            oca = textInfra.DataCharGet(liteData, liteIndex + i);
            ocb = textInfra.DataCharGet(riteData, riteIndex + i);

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