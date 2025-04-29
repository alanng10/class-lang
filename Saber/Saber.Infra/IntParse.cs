namespace Saber.Infra;

public class IntParse : TextAdd
{
    public virtual long HexSignValue(Text text)
    {
        long count;
        count = text.Range.Count;

        if (count < 5)
        {
            return -1;
        }

        Data data;
        data = text.Data;
        long index;
        index = text.Range.Index;

        if (!(this.TextInfra.DataCharGet(data, index) = '0'))
        {
            return -1;
        }
        if (!(this.TextInfra.DataCharGet(data, index + 1) = 'h'))
        {
            return -1;
        }
        if (!(this.TextInfra.DataCharGet(data, index + 2) = 's'))
        {
            return -1;
        }

        long kaa;
        kaa = this.TextInfra.DataCharGet(data, index + 3);

        long negate;
        negate = this.IntSign(kaa);

        if (negate == -1)
        {
            return -1;
        }

        long indexA;
        long countA;
        indexA = index + 4;
        countA = count - 4;
        this.TextA.Data = data;
        this.TextA.Range.Index = indexA;
        this.TextA.Range.Count = countA;

        long k;
        k = this.IntText(this.TextA, 16);
        if (k == -1)
        {
            return -1;
        }

        long max;
        max = 0;
        if (negate == 0)
        {
            max = this.ClassInfra.IntSignPositeMax;
        }
        if (negate == 1)
        {
            max = this.ClassInfra.IntSignNegateMax;
        }

        if (max < k)
        {
            return -1;
        }

        long a;
        a = 0;
        if (negate == 0)
        {
            a = k;
        }
        if (negate == 1)
        {
            a = -k;
        }
        return a;
    }

    public virtual long HexValue(Text text)
    {
        long count;
        count = text.Range.Count;

        if (count < 3)
        {
            return null;
        }

        Data data;
        data = text.Data;
        long index;
        index = text.Range.Index;

        if (!(this.TextInfra.DataCharGet(data, index) == '0'))
        {
            return null;
        }
        if (!(this.TextInfra.DataCharGet(data, index + 1) == 'h'))
        {
            return null;
        }

        long indexA;
        long countA;
        indexA = index + 2;
        countA = count - 2;
        this.TextA.Data = data;
        this.TextA.Range.Index = indexA;
        this.TextA.Range.Count = countA;

        long k;
        k = this.IntText(this.TextA, 16);
        if (k == -1)
        {
            return null;
        }

        long a;
        a = k;
        return a;
    }

    public virtual long SignValue(Text text)
    {
        long count;
        count = text.Range.Count;

        if (count < 4)
        {
            return -1;
        }

        Data data;
        data = text.Data;
        long index;
        index = text.Range.Index;

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
        negate = this.IntSign(kaa);

        if (negate == -1)
        {
            return -1;
        }

        long indexA;
        long countA;
        indexA = index + 3;
        countA = count - 3;
        this.TextA.Data = data;
        this.TextA.Range.Index = indexA;
        this.TextA.Range.Count = countA;

        long k;
        k = this.IntText(this.TextA, 10);

        if (k == -1)
        {
            return -1;
        }

        long max;
        max = 0;
        if (negate == 0)
        {
            max = this.ClassInfra.IntSignPositeMax;
        }
        if (negate == 1)
        {
            max = this.ClassInfra.IntSignNegateMax;
        }

        if (max < k)
        {
            return -1;
        }

        long a;
        a = 0;
        if (negate == 0)
        {
            a = k;
        }
        if (negate == 1)
        {
            a = -k;
        }
        return a;
    }

    public virtual long Value(Text text)
    {
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

    protected virtual long IntSign(long value)
    {
        long a;
        a = -1;
        if (value == 'p')
        {
        a: 0;
        }
        if (value == 'n')
        {
        a: 1;
        }
        return a;
    }
}