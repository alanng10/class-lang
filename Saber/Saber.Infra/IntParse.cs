namespace Saber.Infra;

public class IntParse : TextAdd
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.ClassInfra = Infra.This;
        return true;
    }

    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual Infra ClassInfra { get; set; }

    public virtual long HexSignValue(Text text)
    {
        long count;
        long index;
        index = text.Range.Index;
        count = text.Range.Count;

        if (count < 5)
        {
            return -1;
        }

        Data data;
        data = text.Data;

        if (!(this.TextInfra.DataCharGet(data, index) == '0'))
        {
            return -1;
        }
        if (!(this.TextInfra.DataCharGet(data, index + 1) == 'h'))
        {
            return -1;
        }
        if (!(this.TextInfra.DataCharGet(data, index + 2) == 's'))
        {
            return -1;
        }

        long kaa;
        kaa = this.TextInfra.DataCharGet(data, index + 3);

        long negate;
        negate = this.Sign(kaa);

        if (negate == -1)
        {
            return -1;
        }

        long indexA;
        long countA;
        indexA = index + 4;
        countA = count - 4;
        text.Range.Index = indexA;
        text.Range.Count = countA;

        long k;
        k = this.IntText(text, 16);

        text.Range.Index = index;
        text.Range.Count = count;

        if (k == -1)
        {
            return -1;
        }

        long a;
        a = this.Negate(!(negate == 0), k);
        return a;
    }

    public virtual long HexValue(Text text)
    {
        long index;
        long count;
        index = text.Range.Index;
        count = text.Range.Count;

        if (count < 3)
        {
            return -1;
        }

        Data data;
        data = text.Data;

        if (!(this.TextInfra.DataCharGet(data, index) == '0'))
        {
            return -1;
        }
        if (!(this.TextInfra.DataCharGet(data, index + 1) == 'h'))
        {
            return -1;
        }

        long indexA;
        long countA;
        indexA = index + 2;
        countA = count - 2;
        text.Range.Index = indexA;
        text.Range.Count = countA;

        long k;
        k = this.IntText(text, 16);

        text.Range.Index = index;
        text.Range.Count = count;

        if (k == -1)
        {
            return -1;
        }

        long a;
        a = k;
        return a;
    }

    public virtual long SignValue(Text text)
    {
        long index;
        long count;
        index = text.Range.Index;
        count = text.Range.Count;

        if (count < 4)
        {
            return -1;
        }

        Data data;
        data = text.Data;

        if (!(this.TextInfra.DataCharGet(data, index) == '0'))
        {
            return -1;
        }
        if (!(this.TextInfra.DataCharGet(data, index + 1) == 's'))
        {
            return -1;
        }

        long kaa;
        kaa = this.TextInfra.DataCharGet(data, index + 2);

        long negate;
        negate = this.Sign(kaa);

        if (negate == -1)
        {
            return -1;
        }

        long indexA;
        long countA;
        indexA = index + 3;
        countA = count - 3;
        text.Range.Index = indexA;
        text.Range.Count = countA;

        long k;
        k = this.IntText(text, 10);

        text.Range.Index = index;
        text.Range.Count = count;

        if (k == -1)
        {
            return -1;
        }

        long a;
        a = this.Negate(!(negate == 0), k);
        return a;
    }

    public virtual long Value(Text text)
    {
        if (text.Range.Count < 1)
        {
            return -1;
        }

        long k;
        k = this.IntText(text, 10);

        if (k == -1)
        {
            return -1;
        }

        long a;
        a = k;
        return a;
    }

    protected virtual long Negate(bool negate, long value)
    {
        if (value < 0)
        {
            return -1;
        }

        long max;
        max = 0;
        if (!negate)
        {
            max = this.ClassInfra.IntSignPositeMax;
        }
        if (negate)
        {
            max = this.ClassInfra.IntSignNegateMax;
        }

        if (max < value)
        {
            return -1;
        }

        long k;
        k = 0;
        if (!negate)
        {
            k = value;
        }
        if (negate)
        {
            k = 0 - value;
        }

        long ka;
        ka = this.InfraInfra.IntCapValue;
        ka = ka - 1;

        k = k & ka;

        long a;
        a = k;
        return a;
    }

    protected virtual long Sign(long value)
    {
        long a;
        a = -1;
        if (value == 'p')
        {
            a = 0;
        }
        if (value == 'n')
        {
            a = 1;
        }
        return a;
    }
}