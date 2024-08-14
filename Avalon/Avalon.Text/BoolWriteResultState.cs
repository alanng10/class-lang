namespace Avalon.Text;

public class BoolWriteResultState : WriteResultState
{
    public override bool Execute()
    {
        WriteResultArg kke;
        kke = (WriteResultArg)this.Arg;
        WriteArg arg;
        arg = kke.Arg;
        Text result;
        result = kke.Result;
        Write format;
        format = this.Format;
        
        long valueCount;
        valueCount = arg.ValueCount;
        long count;
        count = arg.Count;
        bool value;
        value = arg.Value.Bool;
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

        format.ResultBool(result, value, varCase, valueWriteCount, valueStart, valueIndex);

        format.ResultFill(result, fillStart, fillCount, fillChar);
        return true;
    }
}