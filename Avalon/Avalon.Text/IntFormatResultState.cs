namespace Avalon.Text;

public class IntFormatResultState : WriteResultState
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
        
        long mask;
        mask = this.InfraInfra.IntCapValue - 1;
        value = value & mask;

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

        long valueWriteCount;
        valueWriteCount = valueCount - clampCount;

        if (alignLeft)
        {
            fillStart = valueWriteCount;
            valueStart = 0;
            valueIndex = 0;
        }

        if (!alignLeft)
        {
            fillStart = 0;
            valueStart = fillCount;
            valueIndex = clampCount;
        }

        ulong valueA;
        valueA = (ulong)value;

        format.ResultInt(result, valueA, varBase, varCase, valueCount, valueWriteCount, valueStart, valueIndex);

        format.ResultFill(result, fillStart, fillCount, fillChar);
        return true;
    }
}