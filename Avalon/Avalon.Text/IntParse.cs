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

    public virtual long Execute(Text text, int varBase, bool upperCase)
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
        ulong oo;
        oo = 0;
        ulong oe;
        oe = (ulong)varBase;
        int digitValue;
        digitValue = 0;
        ulong d;
        d = 0;
        Data data;
        data = text.Data;
        Range range;
        range = text.Range;
        int count;
        count = range.Count;
        int index;
        index = 0;
        int start;
        start = range.Index;
        char oc;
        oc = (char)0;
        int i;
        i = 0;
        while (i < count)
        {
            if (!(h < capValue))
            {
                return -1;
            }
            
            index = start + count - 1 - i;
            oc = textInfra.DataCharGet(data, index);
            
            digitValue = textInfra.DigitValue(oc, varBase, upperCase);
            if (digitValue == -1)
            {
                return -1;
            }

            d = (ulong)digitValue;

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