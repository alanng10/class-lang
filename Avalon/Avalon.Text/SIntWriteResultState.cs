namespace Avalon.Text;

public class SIntWriteResultState : WriteResultState
{
    public override bool Init()
    {
        base.Init();
        this.TextInfra = Infra.This;
        return true;
    }

    protected virtual Infra TextInfra { get; set; }

    public override bool Execute()
    {
        WriteArg arg;
        arg = (WriteArg)this.Arg;
        Text result;
        result = this.ArgResult;
        Write format;
        format = this.Format;

        long valueCount;
        valueCount = arg.ValueCount;
        long count;
        count = arg.Count;
        long value;
        value = arg.Value.Int;

        bool alignLeft;
        alignLeft = arg.AlignLeft;

        long fillCount;
        fillCount = 0;
        long clampCount;
        clampCount = 0;

        if (valueCount < count)
        {
            fillCount = count - valueCount;
        }

        if (count < valueCount)
        {
            clampCount = valueCount - count;
        }

        long varBase;
        varBase = arg.Base;
        long varCase;
        varCase = arg.Case;
        uint fillChar;
        fillChar = arg.FillChar;

        long fillStart;
        fillStart = 0;
        long valueStart;
        valueStart = 0;
        long valueIndex;
        valueIndex = 0;

        long sign;
        sign = arg.Sign;

        long valueA;
        valueA = value;
        valueA = valueA << 4;
        valueA = valueA >> 4;

        long oa;
        oa = valueA;

        bool b;
        b = (oa < 0);

        bool hasSign;
        hasSign = false;

        if (!b)
        {
            if (sign == 1)
            {
                hasSign = true;
            }
            if ((sign == 2) & (!(oa == 0)))
            {
                hasSign = true;
            }
        }

        if (b)
        {
            hasSign = true;
        }

        if (b)
        {
            oa = -oa;
        }

        ulong ua;
        ua = (ulong)oa;

        long ub;
        ub = valueCount;

        if (hasSign)
        {
            ub = ub - 1;
        }

        long unsignedWriteCount;
        unsignedWriteCount = valueCount - clampCount;

        bool ba;
        ba = false;

        long signIndex;
        signIndex = 0;

        if (alignLeft)
        {
            fillStart = valueCount - clampCount;

            valueStart = 0;

            valueIndex = 0;

            if (hasSign)
            {
                valueStart = valueStart + 1;

                if (0 < unsignedWriteCount)
                {
                    unsignedWriteCount = unsignedWriteCount - 1;
                }

                if (0 < count)
                {
                    signIndex = 0;
                    ba = true;
                }
            }
        }

        if (!alignLeft)
        {
            fillStart = 0;

            valueStart = fillCount;

            valueIndex = clampCount;

            if (hasSign)
            {
                if (clampCount == 0)
                {
                    valueStart = valueStart + 1;

                    if (0 < unsignedWriteCount)
                    {
                        unsignedWriteCount = unsignedWriteCount - 1;
                    }

                    signIndex = fillCount;
                    ba = true;
                }

                if (0 < clampCount)
                {
                    valueIndex = valueIndex - 1;
                }
            }
        }

        format.ResultInt(result, ua, varBase, varCase, ub, unsignedWriteCount, valueStart, valueIndex);

        if (ba)
        {
            uint ooc;
            ooc = '+';

            if (b)
            {
                ooc = '-';
            }

            Data resultData;
            resultData = result.Data;
            long resultIndex;
            resultIndex = result.Range.Index;

            this.TextInfra.DataCharSet(resultData, resultIndex + signIndex, ooc);
        }

        format.ResultFill(result, fillStart, fillCount, fillChar);
        return true;
    }
}