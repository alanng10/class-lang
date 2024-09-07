namespace Avalon.Text;

public class IntParse : Any
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.TextInfra = Infra.This;
        return true;
    }

    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual Infra TextInfra { get; set; }

    public virtual long Execute(Text text, long varBase, bool upperCase, CharForm form)
    {
        Infra textInfra;
        textInfra = this.TextInfra;

        if (varBase < 2 | 16 < varBase)
        {
            return -1;
        }

        ulong capValue;
        capValue = (ulong)this.InfraInfra.IntCapValue;
        ulong m;
        m = 0;
        ulong h;
        h = 1;
        ulong oe;
        oe = (ulong)varBase;
        ulong d;
        d = 0;

        bool baa;
        baa = (form == null);
        Data data;
        data = text.Data;
        Range range;
        range = text.Range;
        long count;
        count = range.Count;
        long start;
        start = range.Index;
        long i;
        i = 0;
        while (i < count)
        {
            if (!(h < capValue))
            {
                return -1;
            }

            long index;
            index = start + count - 1 - i;

            long oc;
            oc = textInfra.DataCharGet(data, index);
            
            if (!baa)
            {
                oc = form.Execute(oc);
            }

            long digitValue;
            digitValue = textInfra.DigitValue(oc, varBase, upperCase);
            if (digitValue == -1)
            {
                return -1;
            }

            d = (ulong)digitValue;

            ulong oo;
            oo = h * d;
            
            m = m + oo;

            if (!(m < capValue))
            {
                return -1;
            }

            h = h * oe;

            i = i + 1;
        }

        long a;
        a = (long)m;
        return a;
    }
}