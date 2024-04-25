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
        if (varBase < 2 | 16 < varBase)
        {
            return -1;
        }

        ulong capValue;
        capValue = (ulong)this.InfraInfra.IntCapValue;
        Infra textInfra;
        textInfra = this.TextInfra;
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
        InfraRange range;
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
            
            digitValue = this.DigitValue(oc, varBase, upperCase);
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

    protected virtual int DigitValue(char oc, int varBase, bool upperCase)
    {
        int oa;
        oa = 0;
        bool b;
        b = (varBase < 10);
        if (b)
        {
            oa = varBase;
        }
        if (!b)
        {
            oa = 10;
        }
        int oaa;
        oaa = 0;
        if (!b)
        {
            oaa = varBase - 10;
        }
        char oca;
        oca = 'a';
        if (upperCase)
        {
            oca = 'A';
        }

        Infra textInfra;
        textInfra = this.TextInfra;
        
        if (textInfra.IsDigit(oc))
        {
            int ooa;
            ooa = oc - '0';
            if (!(ooa < oa))
            {
                return -1;
            }

            return ooa;
        }

        if (!textInfra.IsLetter(oc, upperCase))
        {
            return -1;
        }

        int oob;
        oob = oc - oca;
        if (!(oob < oaa))
        {
            return -1;
        }

        return oob + 10;
    }
}