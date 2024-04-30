namespace Avalon.Text;

public class SIntFormatResultState : FormatResultState
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        return true;
    }

    protected virtual InfraInfra InfraInfra { get; set; }

    public override bool Execute()
    {
        FormatArg arg;
        arg = (FormatArg)this.Arg;
        Text result;
        result = this.ArgResult;
        Format format;
        format = this.Format;

        int valueCount;
        valueCount = arg.ValueCount;
        int count;
        count = arg.Count;
        long value;
        value = arg.ValueInt;

        bool alignLeft;
        alignLeft = arg.AlignLeft;

        int fillCount;
        fillCount = 0;
        int clampCount;
        clampCount = 0;

        if (valueCount < count)
        {
            fillCount = count - valueCount;
        }

        if (count < valueCount)
        {
            clampCount = valueCount - count;
        }

        int varBase;
        varBase = arg.Base;
        int varCase;
        varCase = arg.Case;
        char fillChar;
        fillChar = arg.FillChar;

        int fillStart;
        fillStart = 0;
        int valueStart;
        valueStart = 0;
        int valueIndex;
        valueIndex = 0;

        int sign;
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

        int ub;
        ub = valueCount;

        if (hasSign)
        {
            ub = ub - 1;
        }

        int unsignedWriteCount;
        unsignedWriteCount = valueCount - clampCount;

        bool ba;
        ba = false;

        int signIndex;
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
            char ooc;
            ooc = '+';

            if (b)
            {
                ooc = '-';
            }

            Data resultData;
            resultData = result.Data;
            int resultIndex;
            resultIndex = result.Range.Index;

            format.TextInfra.DataCharSet(resultData, resultIndex + signIndex, ooc);
        }

        format.ResultFill(result, fillStart, fillCount, fillChar);
        return true;
    }
}